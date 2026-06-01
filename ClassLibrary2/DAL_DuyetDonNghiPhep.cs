using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3;

namespace DAL
{
    public class DAL_DuyetDonNghiPhep
    {
        public List<ET_DonNghiPhep> LayDanhSachDonChoDuyet(string maNhomQuyen, string maPhongBan)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            // Join bảng DonNghiPhep và NhanVien
            var query = from d in db.DonNghiPheps
                        join n in db.NhanViens on d.MaNhanVien equals n.MaNhanVien
                        where d.TrangThaiDuyet == "Chờ duyệt"
                        select new { d, n };

            // Phân quyền rõ ràng dựa trên Nhóm quyền
            if (maNhomQuyen == "NQ_ADMIN")
            {
                // LÀ ADMIN: Ép bỏ qua mọi điều kiện lọc phòng ban. 
            }
            else if (maNhomQuyen == "NQ_QUANLY")
            {
                // LÀ QUẢN LÝ: Chỉ lấy đơn của nhân viên thuộc phòng ban mình
                query = query.Where(x => x.n.MaPhongBan == maPhongBan);
            }
            else
            {
                // LÀ NHÂN VIÊN THƯỜNG: Vô tình lọt vào đây thì cho về tay không
                return new List<ET_DonNghiPhep>();
            }

            // Đổ dữ liệu ra danh sách
            var danhSach = query.Select(x => new ET_DonNghiPhep
            {
                MaDon = x.d.MaDon,
                MaNhanVien = x.d.MaNhanVien,
                LoaiNghiPhep = x.d.LoaiNghiPhep,
                TuNgay = x.d.TuNgay,
                DenNgay = x.d.DenNgay,
                LyDo = x.d.LyDo,
                TrangThaiDuyet = x.d.TrangThaiDuyet
            }).ToList();

            return danhSach;
        }

        public List<ET_DonNghiPhep> TimKiemDonChoDuyet(string maNhomQuyen, string maPhongBan, string tuKhoa)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            var query = from d in db.DonNghiPheps
                        join n in db.NhanViens on d.MaNhanVien equals n.MaNhanVien
                        where d.TrangThaiDuyet == "Chờ duyệt"
                        select new { d, n };

            // Phân quyền giống hệt hàm lấy danh sách
            if (maNhomQuyen == "NQ_ADMIN")
            {
                // Lấy hết
            }
            else if (maNhomQuyen == "NQ_QUANLY")
            {
                query = query.Where(x => x.n.MaPhongBan == maPhongBan);
            }
            else
            {
                return new List<ET_DonNghiPhep>();
            }

            // Lọc theo từ khóa tìm kiếm (nếu có)
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = tuKhoa.ToLower();
                // Tìm kiếm theo Mã nhân viên (có thể mở rộng thêm mã đơn hoặc loại nghỉ phép)
                query = query.Where(x => x.d.MaNhanVien.ToLower().Contains(tuKhoa) ||
                                         x.d.MaDon.ToLower().Contains(tuKhoa));
            }

            return query.Select(x => new ET_DonNghiPhep
            {
                MaDon = x.d.MaDon,
                MaNhanVien = x.d.MaNhanVien,
                LoaiNghiPhep = x.d.LoaiNghiPhep,
                TuNgay = x.d.TuNgay,
                DenNgay = x.d.DenNgay,
                LyDo = x.d.LyDo,
                TrangThaiDuyet = x.d.TrangThaiDuyet
            }).ToList();
        }

        // --------------------------------------------------------------------------------
        // 3. DUYỆT ĐƠN (Cho phép Duyệt hoặc Từ chối)
        // --------------------------------------------------------------------------------
        public bool DuyetDon(string maDon, bool isDuyet)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            try
            {
                var donNghi = db.DonNghiPheps.FirstOrDefault(d => d.MaDon == maDon);

                if (donNghi != null)
                {
                    // Cập nhật trạng thái tương ứng với nút bấm (Duyệt/Từ chối)
                    donNghi.TrangThaiDuyet = isDuyet ? "Đã duyệt" : "Từ chối";
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}