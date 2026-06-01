using System;
using System.Collections.Generic;
using System.Linq;
using DAL; // Chứa Data Model (Entity Framework/LINQ to SQL)
using ClassLibrary3;
using ET;

namespace BUS
{
    public class BUS_LichPhongVan
    {
        // Sử dụng class DAL tương ứng
        DAL_LichPhongVan DAL_lich = new DAL_LichPhongVan();

        public List<ET_LichPhongVan> LayDanhSachLenGrid()
        {
            var dataFromDAL = DAL_lich.LayDanhSachLenGrid(); // Giả định tên hàm trong DAL

            return dataFromDAL.Select(l => new ET_LichPhongVan
            {
                MaPhongVan = l.MaPhongVan,
                MaUngVien = l.MaUngVien,
                MaNguoiPhongVan = l.MaNguoiPhongVan,
                NgayGioPhongVan = l.NgayGioPhongVan,
                HinhThuc = l.HinhThuc,
                KetQuaDanhGia = l.KetQuaDanhGia
            }).ToList();
        }

        public bool ThemLichPhongVan(ET_LichPhongVan et)
        {
            LichPhongVan lpv = new LichPhongVan
            {
                MaPhongVan = et.MaPhongVan,
                MaUngVien = et.MaUngVien,
                MaNguoiPhongVan = et.MaNguoiPhongVan,
                NgayGioPhongVan = et.NgayGioPhongVan,
                HinhThuc = et.HinhThuc,
                KetQuaDanhGia = et.KetQuaDanhGia
            };
            return DAL_lich.ThemLich(lpv);
        }



        public bool SuaLichPhongVan(ET_LichPhongVan et)
        {
            LichPhongVan lpv = new LichPhongVan
            {
                MaPhongVan = et.MaPhongVan,
                MaUngVien = et.MaUngVien,
                MaNguoiPhongVan = et.MaNguoiPhongVan,
                NgayGioPhongVan = et.NgayGioPhongVan,
                HinhThuc = et.HinhThuc,
                KetQuaDanhGia = et.KetQuaDanhGia
            };
            return DAL_lich.SuaLich(lpv);
        }
    }
}