using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary3;

namespace BUS
{
    public class Bus_NhatKy
    {
        private DAL_NhatKy dalNK = new DAL_NhatKy();
        public List<ET_NhatKy> LayDanhSachLenGrid()
        {
            var data = dalNK.LayDanhSachLenGrid();

            // Map từ LINQ Entity sang ET
            return data.Select(nk => new ET_NhatKy
            {
                LogID = nk.LogID,
                TenDangNhap = nk.TenDangNhap,
                ThoiGian = nk.ThoiGian,
                HanhDong = nk.HanhDong,
                ChiTiet = nk.ChiTiet,
                IPAddress = nk.IPAddress
            }).ToList();
        }
        public void GhiNhatKy(string tenDangNhap, string hanhDong, string chiTiet = "")
        {
            // Nếu không có tên đăng nhập (do lỗi hoặc chưa đăng nhập) thì hủy ghi log
            if (string.IsNullOrWhiteSpace(tenDangNhap)) return;

            dalNK.GhiNhatKy(tenDangNhap, hanhDong, chiTiet);
        }
        public List<ET_NhatKy> TimKiemNhatKy(string tenDangNhap, DateTime? ngayChon, string mode)
        {
            // 1. Lấy dữ liệu từ DAL
            var data = dalNK.TimKiemNhatKy(tenDangNhap, ngayChon, mode);

            // 2. Chuyển đổi (Map) sang List<ET_NhatKy>
            return data.Select(nk => new ET_NhatKy
            {
                LogID = nk.LogID,
                TenDangNhap = nk.TenDangNhap,
                ThoiGian = nk.ThoiGian,
                HanhDong = nk.HanhDong,
                ChiTiet = nk.ChiTiet,
                IPAddress = nk.IPAddress
            }).ToList();
        }
    }
}
