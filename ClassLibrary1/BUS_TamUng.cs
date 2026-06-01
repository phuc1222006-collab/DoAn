using ClassLibrary2;
using ClassLibrary3;
using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TamUng
    {
        DAL_TamUng tamung = new DAL_TamUng();

        public List<ET_TamUng> LayDanhSachLenGrid()
        {
            var data = tamung.LayDanhSachLenGrid();

            return data.Select(td => new ET_TamUng
            {
                MaTamUng = td.MaTamUng,
                MaNhanVien = td.MaNhanVien,
                NgayTamUng = td.NgayTamUng,
                LyDo = td.LyDo,
                SoTien = td.SoTien,
                TrangThai = td.TrangThai,
                ThangKhauTru = td.ThangKhauTru,
                NamKhauTru = td.NamKhauTru,
                NguoiDuyet = td.NguoiDuyet
            }).ToList();
        }

        public bool ThemTamUng(ET_TamUng et)
        {
            try
            {
                TamUng uv = new TamUng
                {
                    MaTamUng = et.MaTamUng,
                    MaNhanVien = et.MaNhanVien,
                    NgayTamUng = et.NgayTamUng,
                    LyDo = et.LyDo,
                    SoTien = et.SoTien,
                    TrangThai = et.TrangThai,
                    ThangKhauTru = et.ThangKhauTru,
                    NamKhauTru = et.NamKhauTru,
                    NguoiDuyet = et.NguoiDuyet
                };

                // Gọi phương thức DAL để thêm vào database
                return tamung.ThemNo(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
        public bool SuaTamUng(ET_TamUng et)
        {
            TamUng uv = new TamUng
            {
                MaTamUng = et.MaTamUng, 

                MaNhanVien = et.MaNhanVien,
                SoTien = et.SoTien,
                LyDo = et.LyDo,
                TrangThai = et.TrangThai,
                NguoiDuyet = et.NguoiDuyet,

                NgayTamUng = et.NgayTamUng,       
                ThangKhauTru = et.ThangKhauTru,   
                NamKhauTru = et.NamKhauTru
            };

            return tamung.SuaTamUng(uv);
        }
    }
}