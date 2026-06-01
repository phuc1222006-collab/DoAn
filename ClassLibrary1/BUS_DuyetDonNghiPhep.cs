using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary3;

namespace BUS
{
    public class BUS_DuyetDonNghiPhep
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu
        private DAL_DuyetDonNghiPhep dalDonNghi = new DAL_DuyetDonNghiPhep();

        public List<ET_DonNghiPhep> LayDanhSachDonChoDuyet(string capBac, string maPhongBan)
        {

            // 1. Kiểm tra an toàn dữ liệu: Nếu cấp bậc rỗng thì trả về danh sách trống
            if (string.IsNullOrEmpty(capBac))
            {
                return new List<ET_DonNghiPhep>();
            }

            // 2. Kiểm tra phân quyền: Nếu là "Nhân viên" bình thường thì tuyệt đối không cho lấy dữ liệu
            if (capBac == "Nhân viên")
            {
                return new List<ET_DonNghiPhep>();
            }

            // Nếu dữ liệu hợp lệ và có quyền (Quản lý, Giám đốc, Admin...), gọi DAL để lấy dữ liệu
            return dalDonNghi.LayDanhSachDonChoDuyet(capBac, maPhongBan);
        }

        public bool DuyetDon(string maDon,bool trangthai)
        {

            // 1. Đảm bảo mã đơn không bị rỗng hoặc null
            if (string.IsNullOrWhiteSpace(maDon))
            {
                return false;
            }

            // Gọi DAL để cập nhật database
            return dalDonNghi.DuyetDon(maDon, trangthai);
        }
        public List<ET_DonNghiPhep> TimKiemDonChoDuyet(string capBac, string maPhongBan, string tuKhoa)
        {
            if (string.IsNullOrEmpty(capBac) || capBac == "Nhân viên")
            {
                return new List<ET_DonNghiPhep>();
            }

            return dalDonNghi.TimKiemDonChoDuyet(capBac, maPhongBan, tuKhoa);
        }
    }
}
