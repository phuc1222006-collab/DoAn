using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;
using ClassLibrary3;

namespace QLNS
{
    public partial class FrmDashboard : Form
    {
        // Khởi tạo các đối tượng BUS
        private BUS_Dashboard busDashboard = new BUS_Dashboard();

        // Thêm BUS Tài khoản để gọi hàm LayThongTinDangNhap
        private BUS_TaiKhoang busTaiKhoan = new BUS_TaiKhoang(); // Lưu ý: Tên class BUS_TaiKhoang (có chữ g) của bạn phải khớp nhé

        // Các biến toàn cục lưu trữ quyền
        private string maNhomQuyenUser = "";
        private string maPhongBanUser = "";

        // =================================================================
        // THÊM LẠI HÀM NÀY: Hàm khởi tạo Form (Bắt buộc phải có)
        // =================================================================
        public FrmDashboard()
        {
            InitializeComponent(); // Dòng này ra lệnh cho C# vẽ giao diện lên
            this.Load += FrmDashboard_Load; // Đăng ký sự kiện khi Form vừa tải xong
        }
        // =================================================================

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            string username = Properties.Settings.Default.Username;

            // Nếu không có user đăng nhập thì thoát luôn (không load dữ liệu)
            if (string.IsNullOrEmpty(username)) return;

            var thongTinUser = busTaiKhoan.LayThongTinDangNhap(username);
            if (thongTinUser != null)
            {
                // Gán quyền và mã phòng ban
                maNhomQuyenUser = thongTinUser.MaNhomQuyen;
                maPhongBanUser = thongTinUser.MaPhongBan;

                LoadThongKeTongQuat();
                LoadBieuDoPhongBan();
                LoadBieuDoGioiTinh();
            }
        }

        private void LoadThongKeTongQuat()
        {
            try
            {
                ET_Dashboard summary = busDashboard.GetSummaryData(maNhomQuyenUser, maPhongBanUser);

                lblTongNhanSu_Value.Text = summary.TongNhanSu.ToString();
                lblNhanVienMoi_Value.Text = "+" + summary.NhanVienMoi.ToString();
                lblDonNghiPhep_Value.Text = summary.DonChoDuyet.ToString("D2");
                lblTuyenDung_Value.Text = summary.CvUngVien.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void LoadBieuDoPhongBan()
        {
            try
            {
                datasetBarChart.DataPoints.Clear();
                List<ET_ChartData> data = busDashboard.GetChartNhanSuPhongBan(maNhomQuyenUser, maPhongBanUser);
                foreach (var item in data) { datasetBarChart.DataPoints.Add(item.Label, item.Value); }
                chartNhanSuPhongBan.Update();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void LoadBieuDoGioiTinh()
        {
            try
            {
                datasetDoughnutChart.DataPoints.Clear();
                List<ET_ChartData> data = busDashboard.GetChartGioiTinh(maNhomQuyenUser, maPhongBanUser);
                foreach (var item in data) { datasetDoughnutChart.DataPoints.Add(item.Label, item.Value); }
                chartGioiTinh.Update();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}