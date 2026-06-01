using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using ClassLibrary1;
using ClassLibrary3.ET.ET;
using ET;

namespace QLNS
{
    public partial class Formhethong : Form
    {
        #region 1. KHAI BÁO BIẾN VÀ KHỞI TẠO FORM

        // --- Biến cho Nhóm Quyền ---
        BUS_NhomQuyen busNQ = new BUS_NhomQuyen();
        bool isEditingNhom = false;
        bool isLoadedNhomQuyen = false; // Biến cờ: Đánh dấu xem Tab Nhóm Quyền đã load dữ liệu chưa

        // --- Biến cho Tài Khoản ---
        BUS_TaiKhoang busTK = new BUS_TaiKhoang();
        bool isEditingTaiKhoan = false;
        bool isLoadedTaiKhoan = false; // Biến cờ: Đánh dấu xem Tab Tài Khoản đã load dữ liệu chưa

        BUS_NhanVien busNV = new BUS_NhanVien();

        public Formhethong()
        {
            InitializeComponent();
        }

        private void Formhethong_Load(object sender, EventArgs e)
        {
            // KHI VỪA MỞ FORM: XÓA HẾT CÁC LỆNH LOAD CŨ. 
            // Chỉ gọi hàm kiểm tra Tab hiện tại
            LoadDataForCurrentTab();
        }

        // Sự kiện khi người dùng click chuyển Tab (Hàm này VS vừa sinh ra ở Bước 1)
        private void tabHeThong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForCurrentTab();
        }

        // --- HÀM TỐI ƯU HIỆU NĂNG (LAZY LOADING) ---
        private void LoadDataForCurrentTab()
        {
            // tabHeThong.SelectedIndex == 0 là Tab Tài Khoản
            if (tabHeThong.SelectedIndex == 0 && !isLoadedTaiKhoan)
            {
                LoadComboBoxTaiKhoan();
                LoadDataTaiKhoan();
                isLoadedTaiKhoan = true; // Đánh dấu đã load xong, lần sau click lại tab này sẽ không load lại nữa
            }
            // tabHeThong.SelectedIndex == 1 là Tab Nhóm Quyền
            else if (tabHeThong.SelectedIndex == 1 && !isLoadedNhomQuyen)
            {
                LoadDataNhomQuyen();
                isLoadedNhomQuyen = true;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ResetFormNhomQuyen();
            ResetFormTaiKhoan();
        }
        #endregion


        #region 2. XỬ LÝ TAB: NHÓM QUYỀN

        private void LoadDataNhomQuyen()
        {
            dgvNhomQuyen.DataSource = null;
            dgvNhomQuyen.DataSource = busNQ.LayDanhSachLenGrid().ToList();
        }

        private ET_NhomQuyen ET_nhomquyen() => new ET_NhomQuyen
        {
            MaNhomQuyen = txtMaNhom.Text,
            TenNhomQuyen = txtTenNhom.Text,
            MoTa = txtMoTa.Text
        };

        private void btnLuuNhom_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNhom.Text)) { MessageBox.Show("Nhập mã nhóm!"); return; }

                var et = ET_nhomquyen();

                if (isEditingNhom)
                {
                    if (busNQ.SuaNhomQuyen(et))
                    {
                        MessageBox.Show("Sửa Thành công!");
                        ResetFormNhomQuyen();
                        LoadDataNhomQuyen();
                    }
                    else { MessageBox.Show("Sửa Thất bại!"); }
                }
                else
                {
                    if (busNQ.ThemNhomQuyen(et))
                    {
                        MessageBox.Show("Thêm Thành công!");
                        ResetFormNhomQuyen();
                        LoadDataNhomQuyen();
                    }
                    else { MessageBox.Show("Thêm Thất bại!"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var et = ET_nhomquyen();
                if (busNQ.XoaNhomQuyen(et))
                {
                    ResetFormNhomQuyen();
                    LoadDataNhomQuyen();
                }
            }
        }

        private void dgvNhomQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            isEditingNhom = true;

            var row = dgvNhomQuyen.Rows[e.RowIndex];
            txtMaNhom.Text = row.Cells["MaNhomQuyen"].Value?.ToString();
            txtTenNhom.Text = row.Cells["TenNhomQuyen"].Value?.ToString();
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();

            txtMaNhom.Enabled = false;
        }

        private void ResetFormNhomQuyen()
        {
            txtMaNhom.Clear();
            txtTenNhom.Clear();
            txtMoTa.Clear();
            txtMaNhom.Enabled = true;
            isEditingNhom = false;
        }
        #endregion


        #region 3. XỬ LÝ TAB: TÀI KHOẢN 

        private void LoadComboBoxTaiKhoan()
        {
            try
            {
                cboNhomQuyen.DataSource = busNQ.LayDanhSachLenGrid();
                cboNhomQuyen.DisplayMember = "TenNhomQuyen";
                cboNhomQuyen.ValueMember = "MaNhomQuyen";


                cboNhanVien.DataSource = busNV.LayDanhSachLenGrid();
                cboNhanVien.DisplayMember = "HoTen"; 
                cboNhanVien.ValueMember = "MaNhanVien";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu hộp thoại: " + ex.Message);
            }
        }

        private void LoadDataTaiKhoan()
        {
            dgvTaiKhoan.DataSource = null;
            dgvTaiKhoan.DataSource = busTK.LayDanhSachLenGrid();
        }

        private ET_TaiKhoan GetETTaiKhoan() => new ET_TaiKhoan
        {
            TenDangNhap = txtTenDangNhap.Text.Trim(),
            MatKhau = txtMatKhau.Text.Trim(),
            MaNhanVien = cboNhanVien.SelectedValue?.ToString(),
            MaNhomQuyen = cboNhomQuyen.SelectedValue?.ToString(),
            TrangThaiHoatDong = swTrangThai.Checked
        };

        private void btnLuuTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!");
                    return;
                }

                var et = GetETTaiKhoan();
                bool success = isEditingTaiKhoan ? busTK.SuaTaiKhoan(et) : busTK.ThemTaiKhoan(et);

                if (success)
                {
                    MessageBox.Show((isEditingTaiKhoan ? "Sửa" : "Thêm") + " tài khoản thành công!");
                    ResetFormTaiKhoan();
                    LoadDataTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Thất bại! Kiểm tra lại Tên đăng nhập (có thể trùng) hoặc Mã nhân viên đã có tài khoản.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Hệ Thống: " + ex.Message);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            isEditingTaiKhoan = true;

            var row = dgvTaiKhoan.Rows[e.RowIndex];

            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();

            cboNhanVien.SelectedValue = row.Cells["MaNhanVien"].Value;
            cboNhomQuyen.SelectedValue = row.Cells["MaNhomQuyen"].Value;

            if (row.Cells["TrangThaiHoatDong"].Value != null)
            {
                bool trangThai;
                if (bool.TryParse(row.Cells["TrangThaiHoatDong"].Value.ToString(), out trangThai))
                {
                    swTrangThai.Checked = trangThai;
                }
            }

            txtTenDangNhap.Enabled = false;
            cboNhanVien.Enabled = false;
        }

        private void ResetFormTaiKhoan()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            swTrangThai.Checked = true;

            txtTenDangNhap.Enabled = true;
            cboNhanVien.Enabled = true;
            isEditingTaiKhoan = false;
        }

        #endregion

    }
}