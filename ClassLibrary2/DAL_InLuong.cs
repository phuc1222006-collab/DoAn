using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class DAL_BangLuong
    {
        private QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

        public List<ET_BangLuong> TuTruyXuatBangLuong(int thang, int nam)
        {
            // Lấy danh sách nhân viên đang làm việc và tính toán các khoản phụ thuộc bằng subquery LINQ
            var query = from nv in db.NhanViens
                        where nv.TrangThaiLamViec == "Đang làm việc"
                        select new
                        {
                            nv.MaNhanVien,
                            nv.HoTen,
                            TenPhongBan = nv.PhongBan != null ? nv.PhongBan.TenPhongBan : "",
                            TenChucDanh = nv.ChucDanh != null ? nv.ChucDanh.TenChucDanh : "",

                            // 1. Lấy lương cứng từ hợp đồng đang hiệu lực
                            LuongCung = db.HopDongLaoDongs
                                      .Where(hd => hd.MaNhanVien == nv.MaNhanVien && hd.TrangThai == "Đang hiệu lực")
                                      .Select(hd => (decimal?)hd.LuongCung)
                                      .FirstOrDefault() ?? 0,

                            // 2. Đếm số ngày công đi làm trong tháng/năm
                            SoNgayCong = db.DataChamCongs
                                       .Count(cc => cc.MaNhanVien == nv.MaNhanVien
                                                 && cc.NgayChamCong != null
                                                 && cc.NgayChamCong.Value.Month == thang
                                                 && cc.NgayChamCong.Value.Year == nam),

                            // 3. Tính tổng phụ cấp được nhận trong tháng/năm
                            TongPhuCap = db.PhuCapNhanViens
                                       .Where(pc => pc.MaNhanVien == nv.MaNhanVien
                                                 && pc.NgayCapTien != null
                                                 && pc.NgayCapTien.Month == thang
                                                 && pc.NgayCapTien.Year == nam)
                                       .Sum(pc => (decimal?)pc.DanhMucPhuCap.MucTien) ?? 0,

                            // 4. Tiền thưởng
                            TienThuong = db.KhenThuongKyLuats
                                       .Where(kt => kt.MaNhanVien == nv.MaNhanVien
                                                 && kt.LoaiQuyetDinh == "Khen thưởng"
                                                 && kt.NgayQuyetDinh != null
                                                 && kt.NgayQuyetDinh.Value.Month == thang
                                                 && kt.NgayQuyetDinh.Value.Year == nam)
                                       .Sum(kt => (decimal?)kt.SoTien) ?? 0,

                            // 5. Tiền phạt kỷ luật
                            TienPhat = db.KhenThuongKyLuats
                                     .Where(kl => kl.MaNhanVien == nv.MaNhanVien
                                               && kl.LoaiQuyetDinh == "Kỷ luật"
                                               && kl.NgayQuyetDinh != null
                                               && kl.NgayQuyetDinh.Value.Month == thang
                                               && kl.NgayQuyetDinh.Value.Year == nam)
                                     .Sum(kl => (decimal?)kl.SoTien) ?? 0,

                            // 6. Tiền tạm ứng khấu trừ trong tháng này
                            TienTamUng = db.TamUngs
                                       .Where(tu => tu.MaNhanVien == nv.MaNhanVien
                                                 && tu.ThangKhauTru == thang
                                                 && tu.NamKhauTru == nam
                                                 && tu.TrangThai == 1)
                                       .Sum(tu => (decimal?)tu.SoTien) ?? 0,

                            // 7. Khấu trừ bảo hiểm xã hội
                            TienBHXH = db.BaoHiemXaHois
                                     .Where(bh => bh.MaNhanVien == nv.MaNhanVien && bh.TrangThai == "Đang tham gia")
                                     .Select(bh => (decimal?)bh.MucDong)
                                     .FirstOrDefault() ?? 0
                        };

            List<ET_BangLuong> convergenceList = new List<ET_BangLuong>();

            // Khai báo số ngày công chuẩn của công ty (Ví dụ: 26 ngày)
            decimal ngayCongChuan = 26m;

            // Duyệt qua kết quả LINQ để build danh sách DTO hoàn chỉnh và tính Thực Lãnh
            foreach (var item in query)
            {
                // BƯỚC 1: Tính tiền lương thực tế theo số ngày đi làm
                decimal tienLuongThucTe = 0;
                if (ngayCongChuan > 0)
                {
                    tienLuongThucTe = (item.LuongCung / ngayCongChuan) * item.SoNgayCong;
                }

                // BƯỚC 2: Gom nhóm Tổng Thu và Tổng Trừ
                decimal tongThu = Math.Round(tienLuongThucTe + item.TongPhuCap + item.TienThuong, 0);
                decimal tongTru = Math.Round(item.TienPhat + item.TienTamUng + item.TienBHXH, 0);

                // BƯỚC 3: Chốt sổ Thực Lãnh
                decimal thucLanh = tongThu - tongTru;

                convergenceList.Add(new ET_BangLuong
                {
                    MaNhanVien = item.MaNhanVien,
                    HoTen = item.HoTen,
                    TenPhongBan = item.TenPhongBan,
                    TenChucDanh = item.TenChucDanh,

                    LuongCung = item.LuongCung,
                    SoNgayCong = item.SoNgayCong,
                    TongPhuCap = item.TongPhuCap,
                    TienThuong = item.TienThuong,

                    TienPhat = item.TienPhat,
                    TienTamUng = item.TienTamUng,
                    TienBHXH = item.TienBHXH,

                    // Bơm 3 biến mới vào để in Report cực khỏe
                    TongThu = tongThu,
                    TongTru = tongTru,
                    ThucLanh = thucLanh
                });
            }

            return convergenceList;
        }
    }
}