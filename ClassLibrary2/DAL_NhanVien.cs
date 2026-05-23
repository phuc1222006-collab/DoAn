using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary2; 

namespace DAL
{
    public class DAL_NhanVien
    {
        public IQueryable<NhanVien> LayDanhSachLenGrid()
        {
            // BẮT BUỘC KHỞI TẠO db MỚI Ở ĐÂY ĐỂ TRÁNH CACHE DỮ LIỆU CŨ
            QuanLyNhanSuDataContext dbMoi = new QuanLyNhanSuDataContext();
            return dbMoi.NhanViens;
        }

        // 2. THÊM
        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                // BẮT BUỘC DÙNG USING Ở ĐÂY
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.NhanViens.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // 3. XÓA
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

        // 4. SỬA
        public bool SuaNhanVien(NhanVien nv)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                var existingNV = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
                if (existingNV != null)
                {
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