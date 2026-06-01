using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class DAL_HoSo
    {
        // 1. HIỂN THỊ DANH SÁCH ỨNG VIÊN
        public IQueryable<UngVien> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.UngViens;
        }

        // 2. THÊM ỨNG VIÊN MỚI
        public bool ThemUngVien(UngVien uv)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.UngViens.InsertOnSubmit(uv);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // 3. CẬP NHẬT THÔNG TIN / TRẠNG THÁI ỨNG VIÊN
        public bool SuaUngVien(UngVien uv)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var existingUV = db.UngViens.FirstOrDefault(x => x.MaUngVien == uv.MaUngVien);
                    if (existingUV != null)
                    {
                        existingUV.MaTuyenDung = uv.MaTuyenDung;
                        existingUV.HoTen = uv.HoTen;
                        existingUV.SoDienThoai = uv.SoDienThoai;
                        existingUV.Email = uv.Email;
                        existingUV.LinkCV = uv.LinkCV;

                        // Trạng thái ở đây thường dùng để đánh dấu: "Đang chờ", "Hẹn phỏng vấn", "Trúng tuyển", "Trượt"
                        existingUV.TrangThai = uv.TrangThai;

                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
