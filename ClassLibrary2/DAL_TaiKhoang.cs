using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class DAL_TaiKhoan
    {
        // Khởi tạo DataContext

        public IQueryable<TaiKhoan> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            return db.TaiKhoans;
        }

        public bool ThemTaiKhoan(TaiKhoan tk)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            try
            {
                db.TaiKhoans.InsertOnSubmit(tk);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaTaiKhoan(TaiKhoan tk)
        {
            using (var db = new QuanLyNhanSuDataContext())
            {
                // Tìm tài khoản theo khóa chính là TenDangNhap
                var tkindb = db.TaiKhoans.FirstOrDefault(n => n.TenDangNhap == tk.TenDangNhap);
                if (tkindb == null) return false;

                // Sử dụng hàm UpdateEntity để cập nhật
                // Lưu ý: Bỏ qua "TenDangNhap" vì đây là khóa chính, không nên thay đổi
                // Nếu bạn có cột liên quan đến MaNhanVien và không muốn đổi nó, hãy thêm vào đây
                Sua.UpdateEntity(tk, tkindb, "TenDangNhap");

                db.SubmitChanges();
                return true;
            }
        }
    }
}