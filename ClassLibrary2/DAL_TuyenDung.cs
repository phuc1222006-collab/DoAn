using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class DAL_TuyenDung
    {
        // 1. HIỂN THỊ DANH SÁCH
        public IQueryable<ViTriTuyenDung> LayDanhSachLenGrid()
        {
            // Luôn tạo db mới để lấy dữ liệu tươi
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.ViTriTuyenDungs;
        }

        // 2. THÊM VỊ TRÍ TUYỂN DỤNG
        public bool ThemTuyenDung(ViTriTuyenDung td)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.ViTriTuyenDungs.InsertOnSubmit(td);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // 3. SỬA VỊ TRÍ TUYỂN DỤNG
        public bool SuaTuyenDung(ViTriTuyenDung td)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var existingTD = db.ViTriTuyenDungs.FirstOrDefault(x => x.MaTuyenDung == td.MaTuyenDung);
                    if (existingTD != null)
                    {
                        existingTD.MaPhongBan = td.MaPhongBan;
                        existingTD.MaChucDanh = td.MaChucDanh;
                        existingTD.SoLuongCanTuyen = td.SoLuongCanTuyen;
                        existingTD.HanChotNopHoSo = td.HanChotNopHoSo;
                        existingTD.MucLuongDuKien = td.MucLuongDuKien;
                        existingTD.TrangThai = td.TrangThai;

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
        public IQueryable<ViTriTuyenDung> LayDanhSachTuyenDungDangMo()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            var query = db.ViTriTuyenDungs
                          .Where(vt => vt.TrangThai == "Đang mở");

            return query; 
        }

    }
}
