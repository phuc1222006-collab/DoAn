using System;
using System.Linq;
using ClassLibrary2;

namespace ClassLibrary2
{
    public class DAL_NhatKy
    {
        public IQueryable<NhatKyHoatDong> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.NhatKyHoatDongs;
        }
        public bool GhiNhatKy(string tenDangNhap, string hanhDong, string chiTiet)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    NhatKyHoatDong nk = new NhatKyHoatDong
                    {
                        TenDangNhap = tenDangNhap,
                        ThoiGian = DateTime.Now,
                        HanhDong = hanhDong,
                        ChiTiet = chiTiet,
                        // Mẹo: Lưu Tên máy tính đang chạy phần mềm vào cột IPAddress
                        IPAddress = Environment.MachineName
                    };

                    db.NhatKyHoatDongs.InsertOnSubmit(nk);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false; // Lỗi kết nối thì bỏ qua, không làm crash phần mềm chính
            }
        }

        // Trả về IQueryable để tầng BUS/GUI có thể lọc tiếp hoặc .ToList() khi cần
        public IQueryable<NhatKyHoatDong> TimKiemNhatKy(string tenDangNhap, DateTime? ngayChon, string mode)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            // 1. Luôn luôn lọc theo TenDangNhap (vì bắt buộc phải có)
            // Dùng .Where để lọc ngay từ đầu
            var query = db.NhatKyHoatDongs.Where(nk => nk.TenDangNhap.Contains(tenDangNhap));

            // 2. Chỉ lọc theo ngày/tháng/năm nếu người dùng có chọn ngày (ngayChon.HasValue)
            if (ngayChon.HasValue)
            {
                DateTime dt = ngayChon.Value;

                if (mode == "Ngày")
                {
                    query = query.Where(nk => nk.ThoiGian.Value.Date == dt.Date);
                }
                else if (mode == "Tháng")
                {
                    query = query.Where(nk => nk.ThoiGian.Value.Month == dt.Month && nk.ThoiGian.Value.Year == dt.Year);
                }
                else if (mode == "Năm")
                {
                    query = query.Where(nk => nk.ThoiGian.Value.Year == dt.Year);
                }
            }

            // Trả về kết quả đã sắp xếp mới nhất lên đầu
            return query.OrderByDescending(nk => nk.ThoiGian);
        }
    }
}