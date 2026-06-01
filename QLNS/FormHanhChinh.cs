using BUS;
using BUS;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class FormHanhChinh : Form
    {
        // Khai báo các lớp xử lý nghiệp vụ (BUS)
        BUS_HoSoCongTac congtac = new BUS_HoSoCongTac();
        BUS_NhanVien nv = new BUS_NhanVien();
        BUS_ChiTietBanGiao bangiao = new BUS_ChiTietBanGiao();
        BUS_DonNghiPhep donnghi = new BUS_DonNghiPhep();

        bool loadBanGiao = false;
        bool loadCongTac = false;
        bool loadDonNghi = false;

        public FormHanhChinh()
        {
            InitializeComponent();
        }

        // Các sự kiện trống chưa dùng đến
        private void txtHotline_TextChanged(object sender, EventArgs e) { }
        private void dgvChamCong_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        #region 1. XỬ LÝ DỮ LIỆU BAN ĐẦU (LOAD FORM)

        public void layDuLieuDonNghiPhep()
        {
            dgvNghiPhep.DataSource = donnghi.LayDanhSachDonNghi();
        }

        public void layDuLieuCongTac()
        {
            dgvCongTac.DataSource = congtac.LayDanhSachHoSoCongTac();
        }

        public void layDuLieuBanGiao()
        {
            dgvBanGiaoCongViec.DataSource = bangiao.LayDanhSachBanGiao();
        }

        // ĐÃ GỘP CHUNG: Tải danh sách nhân viên 1 lần chuẩn xác để tránh xung đột
        private void LoadComboBoxNhanVien()
        {
            try
            {
                var dsNhanVien = nv.LayDanhSachLenGrid();

                // Nếu bạn có nhiều ComboBox cho từng tab, hãy gán DataSource cho từng cái ở đây
                cboNhanvien.DataSource = dsNhanVien;
                cboNhanvien.DisplayMember = "TenNhanVien"; // Luôn hiển thị Tên cho người dùng xem
                cboNhanvien.ValueMember = "MaNhanVien";    // Lấy giá trị ngầm là Mã để lưu DB

                //thiếu này
                CboNhanVienXinNghi.DataSource = dsNhanVien;
                CboNhanVienXinNghi.DisplayMember = "TenNhanVien";
                CboNhanVienXinNghi.ValueMember = "MaNhanVien";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHanhChinh_Load(object sender, EventArgs e)
        {
            LoadComboBoxNhanVien();

            layDuLieuBanGiao();
            layDuLieuCongTac();
            layDuLieuDonNghiPhep();

            loadCongTac = true;
            loadBanGiao = true;
            loadDonNghi = true;
        }

        #endregion

        #region 2. CHỨC NĂNG THÊM / LƯU DỮ LIỆU

        // --- LƯU HỒ SƠ CÔNG TÁC ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCongTac.Text) || string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã công tác và Địa điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNhanvien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân viên đi công tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtptime.Value.Date > DTpNgayKetThuc.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal chiPhi = 0;
                decimal.TryParse(txtChiPhiDuKien.Text.Trim(), out chiPhi);

                var et = new ET_HoSoCongTac
                {
                    MaCongTac = txtMaCongTac.Text.Trim(),
                    DiaDiem1 = txtDiaDiem.Text.Trim(),
                    MucDich = txtMucDich.Text.Trim(),
                    MaNhanVien = cboNhanvien.SelectedValue.ToString(),
                    ChiPhiDuKien = chiPhi,
                    TuNgay = dtptime.Value,
                    DenNgay = DTpNgayKetThuc.Value,
                    TrangThaiDuyet1 = "Chờ duyệt"
                };

                if (congtac.ThemHoSoCongTac(et))
                {
                    MessageBox.Show("Thêm hồ sơ công tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    layDuLieuCongTac();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Trùng Mã công tác)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LƯU CHI TIẾT BÀN GIAO ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBanGiao.Text) || string.IsNullOrWhiteSpace(txtMaQuyetDinh.Text) ||
                string.IsNullOrWhiteSpace(txtHangMuc.Text) || string.IsNullOrWhiteSpace(txtNguoiNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ chi tiết bàn giao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = new ET_ChiTietBanGiao
                {
                    MaBanGiao = txtBanGiao.Text.Trim(),
                    MaQuyetDinh = txtMaQuyetDinh.Text.Trim(),
                    HangMucBanGiao = txtHangMuc.Text.Trim(),
                    NguoiNhanBanGiao = txtNguoiNhan.Text.Trim(),
                    TrangThai = "Chờ duyệt",
                    GhiChu = txtGhiChu.Text.Trim()
                };

                if (bangiao.ThemBanGiao(et))
                {
                    MessageBox.Show("Thêm bàn giao thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    layDuLieuBanGiao();
                    ResetFormBanGiao();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Trùng Mã bàn giao)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LƯU ĐƠN NGHỈ PHÉP ---
        private void btnLuuDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDon.Text) || string.IsNullOrWhiteSpace(txtLoaiNghiPhep.Text) || string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã đơn, Loại nghỉ phép và Lý do!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNhanvien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân viên xin nghỉ phép!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = new ET_DonNghiPhep
                {
                    MaDon = txtMaDon.Text.Trim(),
                    MaNhanVien = cboNhanvien.SelectedValue.ToString(),
                    LoaiNghiPhep = txtLoaiNghiPhep.Text.Trim(),
                    TuNgay = dtpTuNgay.Value,
                    DenNgay = dtpDenNgay.Value,
                    LyDo = txtLyDo.Text.Trim(),
                    TrangThaiDuyet = "Chờ duyệt" // ĐÃ SỬA: Phải là TrangThaiDuyet theo đúng Entity của bạn
                };

                if (donnghi.ThemDonNghiPhep(et))
                {
                    MessageBox.Show("Tạo đơn nghỉ phép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    layDuLieuDonNghiPhep();
                    ResetFormNghiPhep();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Trùng Mã đơn)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 3. CHỨC NĂNG LÀM MỚI FORM (RESET)

        public void ResetForm() // Reset Công tác
        {
            txtMaCongTac.Clear();
            txtDiaDiem.Clear();
            txtMucDich.Clear();
            txtChiPhiDuKien.Clear();

            if (cboNhanvien.Items.Count > 0) cboNhanvien.SelectedIndex = 0;

            dtptime.Value = DateTime.Now;
            DTpNgayKetThuc.Value = DateTime.Now;
            txtMaCongTac.Focus();
        }

        public void ResetFormBanGiao()
        {
            txtBanGiao.Clear();
            txtMaQuyetDinh.Clear();
            txtHangMuc.Clear();
            txtNguoiNhan.Clear();
            txtGhiChu.Clear();
            txtBanGiao.Focus();
        }

        public void ResetFormNghiPhep()
        {
            txtMaDon.Clear();
            txtLoaiNghiPhep.Clear();
            txtLyDo.Clear();

            if (cboNhanvien.Items.Count > 0) cboNhanvien.SelectedIndex = 0;

            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;
            txtMaDon.Focus();
        }

        #endregion

        #region 4. SỰ KIỆN CELLCLICK (ĐẨY DỮ LIỆU NGƯỢC LÊN FORM)

        private void dgvCongTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCongTac.Rows[e.RowIndex];

                txtMaCongTac.Text = row.Cells["MaCongTac"].Value?.ToString();
                txtDiaDiem.Text = row.Cells["DiaDiem1"].Value?.ToString() ?? row.Cells["DiaDiem"].Value?.ToString();
                txtMucDich.Text = row.Cells["MucDich"].Value?.ToString();
                txtChiPhiDuKien.Text = row.Cells["ChiPhiDuKien"].Value?.ToString();

                string maNV = row.Cells["MaNhanVien"].Value?.ToString();
                if (!string.IsNullOrEmpty(maNV)) cboNhanvien.SelectedValue = maNV;

                if (row.Cells["TuNgay"].Value != null && row.Cells["TuNgay"].Value != DBNull.Value)
                    dtptime.Value = Convert.ToDateTime(row.Cells["TuNgay"].Value);

                if (row.Cells["DenNgay"].Value != null && row.Cells["DenNgay"].Value != DBNull.Value)
                    DTpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["DenNgay"].Value);
            }
        }

        private void dgvBanGiaoCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBanGiaoCongViec.Rows[e.RowIndex];

                txtBanGiao.Text = row.Cells["MaBanGiao"].Value?.ToString();
                txtMaQuyetDinh.Text = row.Cells["MaQuyetDinh"].Value?.ToString();
                txtHangMuc.Text = row.Cells["HangMucBanGiao"].Value?.ToString();
                txtNguoiNhan.Text = row.Cells["NguoiNhanBanGiao"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }

        // ĐÃ BỔ SUNG: Click vào danh sách nghỉ phép để hiện lên ô nhập
        private void dgvNghiPhep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNghiPhep.Rows[e.RowIndex];

                txtMaDon.Text = row.Cells["MaDon"].Value?.ToString();
                txtLoaiNghiPhep.Text = row.Cells["LoaiNghiPhep"].Value?.ToString();
                txtLyDo.Text = row.Cells["LyDo"].Value?.ToString();

                string maNV = row.Cells["MaNhanVien"].Value?.ToString();
                if (!string.IsNullOrEmpty(maNV)) cboNhanvien.SelectedValue = maNV;

                if (row.Cells["TuNgay"].Value != null && row.Cells["TuNgay"].Value != DBNull.Value)
                    dtpTuNgay.Value = Convert.ToDateTime(row.Cells["TuNgay"].Value);

                if (row.Cells["DenNgay"].Value != null && row.Cells["DenNgay"].Value != DBNull.Value)
                    dtpDenNgay.Value = Convert.ToDateTime(row.Cells["DenNgay"].Value);
            }
        }


        #endregion

        private void dgvNghiPhep_Click(object sender, EventArgs e)
        {

        }
    }
}