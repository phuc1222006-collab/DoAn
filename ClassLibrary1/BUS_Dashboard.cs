using System;
using System.Collections.Generic;
using DAL; // Gọi DAL
using ClassLibrary3; // Gọi Entity

namespace BUS
{
    public class BUS_Dashboard
    {
        private DAL_Dashboard dalDashboard = new DAL_Dashboard();

        public ET_Dashboard GetSummaryData(string maNhomQuyen, string maPhongBan)
        {
            if (string.IsNullOrEmpty(maNhomQuyen)) throw new Exception("Lỗi: Không xác định được quyền hạn!");
            return dalDashboard.GetSummaryData(maNhomQuyen, maPhongBan);
        }

        public List<ET_ChartData> GetChartNhanSuPhongBan(string maNhomQuyen, string maPhongBan)
        {
            if (string.IsNullOrEmpty(maNhomQuyen)) throw new Exception("Lỗi: Không xác định được quyền hạn!");
            return dalDashboard.GetChartNhanSuPhongBan(maNhomQuyen, maPhongBan);
        }

        public List<ET_ChartData> GetChartGioiTinh(string maNhomQuyen, string maPhongBan)
        {
            if (string.IsNullOrEmpty(maNhomQuyen)) throw new Exception("Lỗi: Không xác định được quyền hạn!");
            return dalDashboard.GetChartGioiTinh(maNhomQuyen, maPhongBan);
        }
    }
}