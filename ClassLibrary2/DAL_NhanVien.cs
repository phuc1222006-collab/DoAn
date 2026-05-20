using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ClassLibrary2;
using ET;
namespace DAL
{

    public class DAL_NhanVien
    {

        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        //lấy ds
        public IQueryable LayDanhSachLenGrid()
        {
            var ds = from s in db.NhanViens
                     select new
                     {
                         s.MaNhanVien,
                         s.HoTen,
                         s.GioiTinh,
                         s.NgaySinh,
                         s.MaPhongBan,
                         s.MaChucDanh,
                         s.TrangThaiLamViec
                     };
            return ds;
        }



        //thêm
        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //xóa
        public bool XoaNhanVien(string maNV)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == maNV);
                if (nv != null)
                {
                    db.NhanViens.DeleteOnSubmit(nv);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        //sửa
        public bool SuaNhanVien(NhanVien nv)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                var existingNV = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
                if (existingNV != null)
                {
                    existingNV.MaNhanVien = nv.MaNhanVien;
                    existingNV.HoTen = nv.HoTen;
                    existingNV.GioiTinh = nv.GioiTinh;
                    existingNV.NgaySinh = nv.NgaySinh;
                    existingNV.MaPhongBan = nv.MaPhongBan;
                    existingNV.MaChucDanh = nv.MaChucDanh;
                    existingNV.TrangThaiLamViec = nv.TrangThaiLamViec;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
