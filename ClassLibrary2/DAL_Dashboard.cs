using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary3;

namespace DAL
{
    public class DAL_Dashboard
    {
        public ET_Dashboard GetSummaryData(string maNhomQuyen, string maPhongBan)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                var summary = new ET_Dashboard();
                // Phân quyền: Admin hoặc Nhân sự thì xem tất cả. Còn lại xem theo phòng.
                bool isToanQuyen = (maNhomQuyen == "NQ_ADMIN" || maNhomQuyen == "NQ_HR");

                // 1. Tổng nhân sự đang làm việc
                summary.TongNhanSu = db.NhanViens.Count(nv => nv.TrangThaiLamViec == "Đang làm việc"
                                                           && (isToanQuyen || nv.MaPhongBan == maPhongBan));

                // 2. Nhân viên mới (Lọc trùng bằng Distinct)
                var thangHienTai = DateTime.Now.Month;
                var namHienTai = DateTime.Now.Year;
                summary.NhanVienMoi = (from hd in db.HopDongLaoDongs
                                       join nv in db.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                                       where hd.NgayHieuLuc.HasValue
                                          && hd.NgayHieuLuc.Value.Month == thangHienTai
                                          && hd.NgayHieuLuc.Value.Year == namHienTai
                                          && (isToanQuyen || nv.MaPhongBan == maPhongBan)
                                       select hd.MaNhanVien).Distinct().Count();

                // 3. Đơn chờ duyệt
                summary.DonChoDuyet = (from d in db.DonNghiPheps
                                       join nv in db.NhanViens on d.MaNhanVien equals nv.MaNhanVien
                                       where d.TrangThaiDuyet == "Chờ duyệt"
                                          && (isToanQuyen || nv.MaPhongBan == maPhongBan)
                                       select d).Count();

                // 4. CV Ứng viên (Lọc theo phòng ban đang tuyển dụng)
                summary.CvUngVien = (from uv in db.UngViens
                                     join vt in db.ViTriTuyenDungs on uv.MaTuyenDung equals vt.MaTuyenDung
                                     where (isToanQuyen || vt.MaPhongBan == maPhongBan)
                                     select uv).Count();

                return summary;
            }
        }

        public List<ET_ChartData> GetChartNhanSuPhongBan(string maNhomQuyen, string maPhongBan)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                bool isToanQuyen = (maNhomQuyen == "NQ_ADMIN" || maNhomQuyen == "NQ_HR");

                var query = from nv in db.NhanViens
                            join pb in db.PhongBans on nv.MaPhongBan equals pb.MaPhongBan
                            where nv.TrangThaiLamViec == "Đang làm việc"
                               && (isToanQuyen || nv.MaPhongBan == maPhongBan)
                            group nv by pb.TenPhongBan into g
                            select new ET_ChartData { Label = g.Key, Value = g.Count() };

                return query.ToList();
            }
        }

        public List<ET_ChartData> GetChartGioiTinh(string maNhomQuyen, string maPhongBan)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                bool isToanQuyen = (maNhomQuyen == "NQ_ADMIN" || maNhomQuyen == "NQ_HR");

                // Kéo dữ liệu thô về RAM
                var rawData = (from nv in db.NhanViens
                               where nv.TrangThaiLamViec == "Đang làm việc"
                                  && (isToanQuyen || nv.MaPhongBan == maPhongBan)
                               group nv by nv.GioiTinh into g
                               select new { GioiTinh = g.Key, SoLuong = g.Count() }).ToList();

                // Xử lý chuỗi rỗng bằng C#
                var finalData = rawData.Select(item => new ET_ChartData
                {
                    Label = string.IsNullOrEmpty(item.GioiTinh) ? "Khác" : item.GioiTinh,
                    Value = item.SoLuong
                }).ToList();

                return finalData;
            }
        }
    }
}