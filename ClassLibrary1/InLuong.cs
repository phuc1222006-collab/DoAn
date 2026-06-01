using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ET;

namespace BUS
{
    public class BUS_BangLuong
    {
        private DAL_BangLuong dalBangLuong = new DAL_BangLuong();

        public List<ET_BangLuong> LayDanhSachPhieuLuong(int thang, int nam)
        {
            // 1. Rào lỗi nhập liệu (Tháng)
            if (thang < 1 || thang > 12)
            {
                throw new ArgumentException("Tháng không hợp lệ! Vui lòng chọn từ tháng 1 đến tháng 12.");
            }

            // 2. Rào lỗi nhập liệu (Năm) - Nâng cấp xíu: Cho phép từ năm 2020 đến năm hiện tại + 1
            if (nam < 2020 || nam > DateTime.Now.Year + 1)
            {
                throw new ArgumentException($"Năm không hợp lệ! Vui lòng nhập năm từ 2020 đến {DateTime.Now.Year + 1}.");
            }

            // 3. Nếu dữ liệu ngon lành thì đẩy xuống DAL xử lý
            return dalBangLuong.TuTruyXuatBangLuong(thang, nam);
        }
    }
}