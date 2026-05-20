using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietNhanVien
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        //lấy ds
        public IQueryable LayDanhSachLenGrid()
        {
            var ds = from s in db.ChiTietNhanViens
                     select new
                     {
                         s.MaNhanVien,
                         s.SoDienThoai,
                         s.EmailCaNhan,
                         s.EmailCongTy,
                         s.DiaChiThuongTru,
                         s.SoCCCD,
                         s.NgayCapCCCD,
                         s.NoiCapCCCD,
                         s.MaSoThue,
                         s.SoTaiKhoan,
                         s.TenNganHang
                     };
            return ds;
        }
        // Lấy chi tiết nhân viên theo Mã NV
        public IQueryable LayChiTietNhanVien(string maNV)
        {
            var chiTiet = from ct in db.ChiTietNhanViens
                          where ct.MaNhanVien == maNV
                          select new
                          {
                              ct.MaNhanVien,
                              ct.SoDienThoai,
                              ct.EmailCaNhan,
                              ct.EmailCongTy,
                              ct.DiaChiThuongTru,
                              ct.SoCCCD,
                              ct.NgayCapCCCD,
                              ct.NoiCapCCCD,
                              ct.MaSoThue,
                              ct.SoTaiKhoan,
                              ct.TenNganHang
                          };
            return chiTiet;
        }
    }
}
