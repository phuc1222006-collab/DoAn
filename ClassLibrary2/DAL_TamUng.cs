using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TamUng
    {
    
        public IQueryable<TamUng> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.TamUngs;
        }
        public bool ThemNo(TamUng tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.TamUngs.InsertOnSubmit(tu);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);

            }
            
        }
        public bool SuaTamUng(TamUng tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var existingUV = db.TamUngs.FirstOrDefault(x => x.MaTamUng == tu.MaTamUng);
                    if (existingUV != null)
                    {
                        existingUV.MaNhanVien = tu.MaNhanVien;
                        existingUV.SoTien = tu.SoTien;
                        existingUV.LyDo = tu.LyDo;
                        existingUV.TrangThai = tu.TrangThai;
                        existingUV.NguoiDuyet = tu.NguoiDuyet;

                        existingUV.NgayTamUng = tu.NgayTamUng;
                        existingUV.ThangKhauTru = tu.ThangKhauTru;
                        existingUV.NamKhauTru = tu.NamKhauTru;
                        // Trạng thái ở đây thường dùng để đánh dấu: "Đang chờ", "Hẹn phỏng vấn", "Trúng tuyển", "Trượt"


                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy mã phiếu tạm ứng này trong DB!");
                    }
                }
            }
            catch (Exception ex)
            {
                // QUAN TRỌNG: Ném thẳng lỗi của SQL lên để Form bắt được
                throw new Exception("Lỗi từ DB: " + ex.Message);
            }
        }
    }

}

