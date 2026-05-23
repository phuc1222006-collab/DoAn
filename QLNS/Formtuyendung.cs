using System;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary1; 
using ClassLibrary3;
using ET;            

namespace QLNS
{
    public partial class Formtuyendung : Form
    {
        #region 1. KHAI BÁO BIẾN & KHỞI TẠO FORM

        // --- Biến cho Kế Hoạch Tuyển Dụng ---
        BUS_TuyenDung busTD = new BUS_TuyenDung();
        bool isLoadedTuyenDung = false;

        // --- Biến cho Hồ Sơ Ứng Viên ---
        BUS_HoSo busUV = new BUS_HoSo();
        bool isLoadedUngVien = false;

        // --- Biến cho ComboBox Danh mục phụ trợ ---
        /* GHI CHÚ: Mở khóa các dòng này nếu bạn đã có BUS Phòng Ban & Chức Danh
        BUS_PhongBan busPB = new BUS_PhongBan();
        BUS_ChucDanh busCD = new BUS_ChucDanh();
        */

        public Formtuyendung()
        {
            InitializeComponent();
        }

        private void Formtuyendung_Load(object sender, EventArgs e)
        {
            // Cài đặt cứng các Trạng thái thường dùng vào ComboBox
            LoadTrangThaiComboBox();

            // Kích hoạt nạp dữ liệu cho Tab đang mở đầu tiên (Lazy Loading)
            LoadDataForCurrentTab();

            // Liên kết sự kiện Click cho 2 lưới (Bạn nhớ gắn sự kiện này bên Designer nhé)
            dgvViTri.CellClick += dgvViTri_CellClick;
            dgvUngVien.CellClick += dgvUngVien_CellClick;

            // Liên kết sự kiện chuyển Tab
            tabTuyenDung.SelectedIndexChanged += tabTuyenDung_SelectedIndexChanged;
        }

        private void LoadTrangThaiComboBox()
        {
            // Trạng thái Tuyển dụng
            cboTrangThaiTD.Items.Add("Đang Mở");
            cboTrangThaiTD.Items.Add("Tạm Dừng");
            cboTrangThaiTD.Items.Add("Đã Đóng");
            cboTrangThaiTD.SelectedIndex = 0; // Chọn mặc định cái đầu tiên

            // Trạng thái Ứng Viên
            cboTrangThaiUV.Items.Add("Mới Nộp");
            cboTrangThaiUV.Items.Add("Đang Phỏng Vấn");
            cboTrangThaiUV.Items.Add("Đã Đậu");
            cboTrangThaiUV.Items.Add("Đã Rớt");
            cboTrangThaiUV.SelectedIndex = 0;
        }

        // Kỹ thuật Lazy Loading: Chuyển đến Tab nào mới Load dữ liệu Tab đó
        private void tabTuyenDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForCurrentTab();
        }

        private void LoadDataForCurrentTab()
        {
            // Tab 0: Kế Hoạch Tuyển Dụng
            if (tabTuyenDung.SelectedIndex == 0 && !isLoadedTuyenDung)
            {
                LoadComboBoxTuyenDung(); // Load PB và Chức danh
                LoadDataTuyenDung();     // Load Grid
                isLoadedTuyenDung = true;
            }
            // Tab 1: Hồ Sơ Ứng Viên
            else if (tabTuyenDung.SelectedIndex == 1 && !isLoadedUngVien)
            {
                LoadComboBoxUngVien();   // Load danh sách Đợt tuyển dụng vào ComboBox
                LoadDataUngVien();       // Load Grid
                isLoadedUngVien = true;
            }
        }
        #endregion


        #region 2. TAB KẾ HOẠCH TUYỂN DỤNG

        private void LoadComboBoxTuyenDung()
        {
            try
            {
                /* GHI CHÚ: Bỏ comment khi bạn đã có lớp BUS
                cboPhongBan.DataSource = busPB.LayDanhSachLenGrid();
                cboPhongBan.DisplayMember = "TenPhongBan";
                cboPhongBan.ValueMember = "MaPhongBan";

                cboChucDanh.DataSource = busCD.LayDanhSachLenGrid();
                cboChucDanh.DisplayMember = "TenChucDanh";
                cboChucDanh.ValueMember = "MaChucDanh";
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load ComboBox: " + ex.Message);
            }
        }

        private void LoadDataTuyenDung()
        {
            dgvViTri.DataSource = null;
            dgvViTri.DataSource = busTD.LayDanhSachLenGrid();
        }

        private ET_TuyenDung GetETTuyenDung()
        {
            int? sl = null;
            if (int.TryParse(txtSoLuong.Text, out int result)) { sl = result; }

            return new ET_TuyenDung
            {
                MaTuyenDung = txtMaTD.Text.Trim(),
                MaPhongBan = cboPhongBan.SelectedValue?.ToString(),
                MaChucDanh = cboChucDanh.SelectedValue?.ToString(),
                SoLuongCanTuyen = sl,
                HanChotNopHoSo = dtpHanChot.Value, // Lấy ngày từ DateTimePicker
                MucLuongDuKien = txtMucLuong.Text,
                TrangThai = cboTrangThaiTD.SelectedItem?.ToString()
            };
        }

        // NÚT: MỞ ĐỢT TUYỂN (Thêm mới)
        private void btnLuuViTri_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTD.Text)) { MessageBox.Show("Nhập mã tuyển dụng!"); return; }

            var et = GetETTuyenDung();
            if (busTD.ThemTuyenDung(et))
            {
                MessageBox.Show("Đã mở đợt tuyển dụng mới thành công!");
                LoadDataTuyenDung();
            }
            else { MessageBox.Show("Lỗi: Mã tuyển dụng bị trùng hoặc CSDL từ chối."); }
        }

        // NÚT: SỬA THÔNG TIN TUYỂN DỤNG
        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTD.Text)) { MessageBox.Show("Chọn 1 dòng trên lưới để sửa!"); return; }

            var et = GetETTuyenDung();
            if (busTD.SuaTuyenDung(et))
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                LoadDataTuyenDung();
            }
            else { MessageBox.Show("Cập nhật thất bại!"); }
        }

        private void dgvViTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvViTri.Rows[e.RowIndex];
            txtMaTD.Text = row.Cells["MaTuyenDung"].Value?.ToString();
            cboPhongBan.SelectedValue = row.Cells["MaPhongBan"].Value;
            cboChucDanh.SelectedValue = row.Cells["MaChucDanh"].Value;
            txtSoLuong.Text = row.Cells["SoLuongCanTuyen"].Value?.ToString();
            txtMucLuong.Text = row.Cells["MucLuongDuKien"].Value?.ToString();

            // Xử lý DateTime an toàn
            if (row.Cells["HanChotNopHoSo"].Value != null && DateTime.TryParse(row.Cells["HanChotNopHoSo"].Value.ToString(), out DateTime d))
            {
                dtpHanChot.Value = d;
            }

            cboTrangThaiTD.SelectedItem = row.Cells["TrangThai"].Value?.ToString();
            txtMaTD.Enabled = false; // Không cho sửa khóa chính
        }

        #endregion


        #region 3. TAB HỒ SƠ ỨNG VIÊN

        private void LoadComboBoxUngVien()
        {
            try
            {
                // Khi nộp hồ sơ, phải chọn xem nộp vào đợt tuyển dụng nào
                cboMaTD.DataSource = busTD.LayDanhSachLenGrid();
                cboMaTD.DisplayMember = "MaTuyenDung"; // Hoặc bạn có thể tạo 1 trường hiển thị "TenChucDanh (MaTD)" cho đẹp
                cboMaTD.ValueMember = "MaTuyenDung";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load ComboBox Ứng viên: " + ex.Message);
            }
        }

        private void LoadDataUngVien()
        {
            dgvUngVien.DataSource = null;
            dgvUngVien.DataSource = busUV.LayDanhSachLenGrid();
        }

        private ET_UngVien GetETUngVien() => new ET_UngVien
        {
            MaUngVien = txtMaUV.Text.Trim(),
            MaTuyenDung = cboMaTD.SelectedValue?.ToString(),
            HoTen = txtHoTen.Text.Trim(),
            SoDienThoai = txtSDT.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            LinkCV = txtLinkCV.Text.Trim(),
            TrangThai = cboTrangThaiUV.SelectedItem?.ToString()
        };

        // NÚT: LƯU HỒ SƠ (Thêm mới)
        private void btnLuuUngVien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaUV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Ứng Viên và Họ tên!");
                return;
            }

            var et = GetETUngVien();
            if (busUV.ThemUngVien(et))
            {
                MessageBox.Show("Đã lưu hồ sơ ứng viên thành công!");
                LoadDataUngVien();
            }
            else { MessageBox.Show("Thêm thất bại (Mã bị trùng)!"); }
        }

        // NÚT: SỬA HỒ SƠ
        private void btnSuaHoSo_Click(object sender, EventArgs e)
        {

        }

        private void dgvUngVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUngVien.Rows[e.RowIndex];
            txtMaUV.Text = row.Cells["MaUngVien"].Value?.ToString();
            cboMaTD.SelectedValue = row.Cells["MaTuyenDung"].Value;
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtLinkCV.Text = row.Cells["LinkCV"].Value?.ToString();
            cboTrangThaiUV.SelectedItem = row.Cells["TrangThai"].Value?.ToString();

            txtMaUV.Enabled = false; // Bảo mật khóa chính
        }

        #endregion
    }
}