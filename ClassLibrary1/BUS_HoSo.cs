using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary3;

namespace BUS
{
    public class BUS_HoSo
    {
        DAL_HoSo dalUV = new DAL_HoSo();

        // 1. HÀM HIỂN THỊ (Lấy Entity từ DAL chuyển thành List ET đưa lên Form)
        public List<ET_UngVien> LayDanhSachLenGrid()
        {
            var data = dalUV.LayDanhSachLenGrid();

            return data.Select(uv => new ET_UngVien
            {
                MaUngVien = uv.MaUngVien,
                MaTuyenDung = uv.MaTuyenDung,
                HoTen = uv.HoTen,
                SoDienThoai = uv.SoDienThoai,
                Email = uv.Email,
                LinkCV = uv.LinkCV,
                TrangThai = uv.TrangThai
            }).ToList();
        }

        // 2. HÀM THÊM ỨNG VIÊN MỚI
        public bool ThemUngVien(ET_UngVien et)
        {
            UngVien uv = new UngVien
            {
                MaUngVien = et.MaUngVien,
                MaTuyenDung = et.MaTuyenDung,
                HoTen = et.HoTen,
                SoDienThoai = et.SoDienThoai,
                Email = et.Email,
                LinkCV = et.LinkCV,
                TrangThai = et.TrangThai
            };

            return dalUV.ThemUngVien(uv);
        }

        // 3. HÀM SỬA THÔNG TIN / TRẠNG THÁI ỨNG VIÊN
        public bool SuaUngVien(ET_UngVien et)
        {
            UngVien uv = new UngVien
            {
                MaUngVien = et.MaUngVien,
                MaTuyenDung = et.MaTuyenDung,
                HoTen = et.HoTen,
                SoDienThoai = et.SoDienThoai,
                Email = et.Email,
                LinkCV = et.LinkCV,
                TrangThai = et.TrangThai
            };

            return dalUV.SuaUngVien(uv);
        }
        public List<ET_UngVien> LayDanhSachUngVienCanPhongVan()
        {
            var data = dalUV.LayDanhSachUngVienCanPhongVan();

            return data.Select(uv => new ET_UngVien
            {
                MaUngVien = uv.MaUngVien,
                MaTuyenDung = uv.MaTuyenDung,
                HoTen = uv.HoTen,
                SoDienThoai = uv.SoDienThoai,
                Email = uv.Email,
                LinkCV = uv.LinkCV,
                TrangThai = uv.TrangThai
            }).ToList();
        }
    }
}
