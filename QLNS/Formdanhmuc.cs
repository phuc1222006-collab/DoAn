using  BUS;
using ClassLibrary3;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    public partial class Formdanhmuc : Form
    {
        #region 1. KHỞI TẠO ĐỐI TƯỢNG & BIẾN TOÀN CỤC

        // Tầng BUS xử lý dữ liệu
        BUS_DanhMucPhuCap phucap = new BUS_DanhMucPhuCap();
        BUS_ChucDanh chucdanh = new BUS_ChucDanh();
        BUS_PhongBan phongban = new BUS_PhongBan();
        BUS_ChiNhanh chiNhanh = new BUS_ChiNhanh();
        BUS_HinhThucChamCong ChamCong = new BUS_HinhThucChamCong();
        BUS_CaLam calam = new BUS_CaLam();

        // Biến trạng thái kiểm tra Load dữ liệu
        bool LoadPhuCap = false;
        bool loadChucDanh = false;
        bool loadPhongban = false;
        bool loadChiNanh = false;
        bool loadChamCong = false;
        bool loadCaLam = false;

        public Formdanhmuc()
        {
            InitializeComponent();
        }

        #endregion

        #region 2. SỰ KIỆN LOAD FORM

        private void Formdanhmuc_Load(object sender, EventArgs e)
        {
            try
            {
                // Cấu hình dữ liệu ComboBox Chi nhánh trực thuộc Phòng ban
                cboChiNhanh_PB.DataSource = chiNhanh.LayDanhSachChiNhanh();
                cboChiNhanh_PB.DisplayMember = "TenChiNhanh";
                cboChiNhanh_PB.ValueMember = "MaChiNhanh";
                cboChiNhanh_PB.SelectedIndex = -1; // Mặc định để trống khi mới vào form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Chi nhánh lên ComboBox: " + ex.Message, "Thông báo");
            }

            // Tải dữ liệu lên các bảng DataGridView
            LoadDataDanhMucPhuCap();
            LoadDataChucDanh();
            LoadDataPhongBan();
            LoadDataChiNhanh();
            LoadDataChamCong();
            LoadDataCaLam();
        }

        #endregion

        #region 3. HÀM TẢI DỮ LIỆU LÊN DATAGRIDVIEW

        public void LoadDataCaLam()
        {
            try
            {
                dgvCaLamViec.DataSource = calam.LayDanhSachCaLam();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải danh sách Phụ cấp: " + ex.Message, "Thông báo");
            }
        }

        public void LoadDataDanhMucPhuCap()
        {
            try
            {
                dgvPhuCap.DataSource = phucap.layDanhSachPhucap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải danh sách Phụ cấp: " + ex.Message, "Thông báo");
            }
        }

        public void LoadDataChamCong()
        {
            try
            {
                dgvHinhThucCC.DataSource = ChamCong.LayDanhSachChamCong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải danh sách Chi Nhánh: " + ex.Message, "Thông báo");
            }
        }

        public void LoadDataChucDanh()
        {
            try
            {
                dgvChucDanh.DataSource = chucdanh.layDanhSachChucDanh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải danh sách Chức danh: " + ex.Message, "Thông báo");
            }
        }

        public void LoadDataPhongBan()
        {
            try
            {
                dgvPhongBan.DataSource = phongban.LayDanhSachPhongBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải danh sách Phòng ban: " + ex.Message, "Thông báo");
            }
        }

        public void LoadDataChiNhanh()
        {
            try
            {
                dgvChiNhanh.DataSource = chiNhanh.LayDanhSachChiNhanh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tải danh sách Phòng ban: " + ex.Message, "Thông báo");
            }
        }

        #endregion

        #region 4. SỰ KIỆN CLICK CHỌN DÒNG (CELLCLICK)

        private void dgvPhuCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvPhuCap.Rows[e.RowIndex];

                    txtMaPhuCap.Text = row.Cells["MaPhuCap"].Value?.ToString();
                    txtTenPhuCap.Text = row.Cells["TenPhuCap"].Value?.ToString();
                    txtMucTien.Text = row.Cells["MucPhuCap"].Value?.ToString();

                    txtMaPhuCap.Enabled = false;
                    LoadPhuCap = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu mục phụ cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChucDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvChucDanh.Rows[e.RowIndex];

                    txtMaChucDanh.Text = row.Cells["MaChucDanh"].Value?.ToString();
                    txtTenChucDanh.Text = row.Cells["TenChucDanh"].Value?.ToString();
                    txtCapBac.Text = row.Cells["CapBac"].Value?.ToString();

                    txtMaChucDanh.Enabled = false;
                    loadChucDanh = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu mục chức danh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvPhongBan.Rows[e.RowIndex];

                    txtMaPhongBan.Text = row.Cells["MaPhongBan"].Value?.ToString();
                    txtTenPhongBan.Text = row.Cells["TenPhongBan"].Value?.ToString();

                    string maCN = row.Cells["MaChiNhanh"].Value?.ToString();

                    // Đổ dữ liệu mã chi nhánh vào ComboBox
                    if (cboChiNhanh_PB.DataSource != null && !string.IsNullOrEmpty(maCN))
                    {
                        cboChiNhanh_PB.SelectedValue = maCN;
                    }
                    else
                    {
                        cboChiNhanh_PB.Text = maCN;
                    }

                    txtMaPhongBan.Enabled = false;
                    loadPhongban = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu phòng ban: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvChiNhanh.Rows[e.RowIndex];

                    txtMaChiNhanh.Text = row.Cells["MaChiNhanh"].Value?.ToString();
                    txtTenChiNhanh.Text = row.Cells["TenChiNhanh"].Value?.ToString();
                    txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                    txtHotline.Text = row.Cells["Hotline"].Value?.ToString();

                    txtMaChucDanh.Enabled = false;
                    loadChiNanh = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu mục chức danh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCaLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCaLamViec.Rows[e.RowIndex];

                    txtMaCa.Text = row.Cells["MaCa"].Value?.ToString();
                    txtTenCa.Text = row.Cells["TenCa"].Value?.ToString();
                    if (DateTime.TryParse(row.Cells["GioBatDau"].Value?.ToString(), out DateTime gioBD))
                    {
                        dtpGioBatDau.Value = gioBD;
                    }

                    if (DateTime.TryParse(row.Cells["GioKetThuc"].Value?.ToString(), out DateTime gioKT))
                    {
                        dtpGioKetThuc.Value = gioKT;
                    }
                    txtMaCa.Enabled = false;
                    loadCaLam = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu mục ca làm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHinhThucCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHinhThucCC.Rows[e.RowIndex];

                    txtMaHTCC.Text = row.Cells["MaHinhThuc"].Value?.ToString();
                    txtTenHTCC.Text = row.Cells["TenHinhThuc"].Value?.ToString();

                    txtMaHTCC.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu mục hình thưc chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 5. HÀM ĐÓNG GÓI DỮ LIỆU TỪ FORM (GET ENTITY)

        public ET_DanhMucPhuCap LayDuLieuTuForm()
        {
            return new ET_DanhMucPhuCap
            {
                MaPhuCap = txtMaPhuCap.Text.Trim(),
                TenPhuCap = txtTenPhuCap.Text.Trim(),
                MucPhuCap = Convert.ToDecimal(txtMucTien.Text.Trim())
            };
        }

        public ET_CaLam LayDuLieuTuFormCaLam()
        {
            return new ET_CaLam
            {
                MaCa = txtMaCa.Text.Trim(),
                TenCa = txtTenCa.Text.Trim(),

                // ĐÃ SỬA: Thêm .TimeOfDay để chuyển từ DateTime sang TimeSpan
                GioBatDau = dtpGioBatDau.Value.TimeOfDay,
                GioKetThuc = dtpGioKetThuc.Value.TimeOfDay
            };
        }

        public ET_HinhThucChamCong LayDuLieuChamCong()
        {
            return new ET_HinhThucChamCong
            {
                MaHinhThuc = txtMaHTCC.Text.Trim(),
                TenHinhThuc = txtTenHTCC.Text.Trim(),
            };
        }

        public ET_ChucDanh LayDuLieuTuFormChucDanh()
        {
            return new ET_ChucDanh
            {
                MaChucDanh = txtMaChucDanh.Text.Trim(),
                TenChucDanh = txtTenChucDanh.Text.Trim(),
                CapBac = txtCapBac.Text.Trim()
            };
        }

        public ET_ChiNhanh LayDuLieuTuFormChiNhanh()
        {
            return new ET_ChiNhanh
            {
                MaChiNhanh = txtMaChiNhanh.Text.Trim(),
                TenChiNhanh = txtTenChiNhanh.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Hotline = txtHotline.Text.Trim(),
            };
        }

        public ET_PhongBan LayDuLieuTuFormPhongBan()
        {
            string maCN = "";
            if (cboChiNhanh_PB.SelectedValue != null)
                maCN = cboChiNhanh_PB.SelectedValue.ToString();
            else if (cboChiNhanh_PB.SelectedItem != null)
                maCN = cboChiNhanh_PB.SelectedItem.ToString();
            else
                maCN = cboChiNhanh_PB.Text.Trim();

            return new ET_PhongBan
            {
                MaPhongBan = txtMaPhongBan.Text.Trim(),
                MaChiNhanh = maCN,
                TenPhongBan = txtTenPhongBan.Text.Trim(),
                MaPhongBanCha = null,
                MaTruongPhong = null
            };
        }

        #endregion

        #region 6. XỬ LÝ SỰ KIỆN CÁC NÚT LƯU (THÊM MỚI)

        private void btnLuuPhuCap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhuCap.Text) ||
                string.IsNullOrWhiteSpace(txtTenPhuCap.Text) ||
                string.IsNullOrWhiteSpace(txtMucTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin phụ cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = LayDuLieuTuForm();
                if (phucap.ThemDanhMucPHuCap(et))
                {
                    MessageBox.Show("Thêm phụ cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataDanhMucPhuCap();
                    ResetFormDanhMuc();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Có thể do trùng mã phụ cấp)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm phụ cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuChucDanh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChucDanh.Text) ||
                string.IsNullOrWhiteSpace(txtTenChucDanh.Text) ||
                string.IsNullOrWhiteSpace(txtCapBac.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin chức danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = LayDuLieuTuFormChucDanh();
                if (chucdanh.ThemDanhMucChucDanh(et))
                {
                    MessageBox.Show("Thêm chức danh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataChucDanh();
                    ResetFormChucDanh();
                }
                else
                {
                    MessageBox.Show("Thêm chức danh thất bại (Có thể do trùng mã chức danh)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm chức danh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuPhongBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhongBan.Text) ||
                string.IsNullOrWhiteSpace(txtTenPhongBan.Text) ||
                cboChiNhanh_PB.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng ban và chọn Chi nhánh trực thuộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = LayDuLieuTuFormPhongBan();
                if (phongban.ThemPhongban(et))
                {
                    MessageBox.Show("Thêm cơ cấu phòng ban mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhongBan();
                    ResetFormPhongBan();
                }
                else
                {
                    MessageBox.Show("Thêm phòng ban thất bại (Có thể do trùng mã phòng ban)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm phòng ban: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuChiNhanh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChiNhanh.Text) ||
               string.IsNullOrWhiteSpace(txtTenChiNhanh.Text) ||
               string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
               string.IsNullOrWhiteSpace(txtHotline.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin chi nhánh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = LayDuLieuTuFormChiNhanh();
                if (chiNhanh.ThemChiNhanh(et))
                {
                    MessageBox.Show("Thêm chi nhánh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataChiNhanh();
                    ResetFormChiNhanh();
                }
                else
                {
                    MessageBox.Show("Thêm chi nhánh thất bại (Có thể do trùng mã chức danh)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuHTCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHTCC.Text) ||
              string.IsNullOrWhiteSpace(txtTenHTCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin chấm công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var et = LayDuLieuChamCong();
                if (ChamCong.ThemChiNhanh(et))
                {
                    MessageBox.Show("Thêm chấm công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataChamCong();
                    ResetFormChamCong();
                }
                else
                {
                    MessageBox.Show("Thêm chấm công thất bại (Có thể do trùng mã chức danh)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuCa_Click(object sender, EventArgs e)
        {
            // 1. Sửa lỗi cú pháp và đổi câu thông báo
            if (string.IsNullOrWhiteSpace(txtMaCa.Text) ||
                string.IsNullOrWhiteSpace(txtTenCa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã ca và tên ca!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // (Tùy chọn) Kiểm tra giờ bắt đầu phải nhỏ hơn giờ kết thúc
            if (dtpGioBatDau.Value.TimeOfDay >= dtpGioKetThuc.Value.TimeOfDay)
            {
                MessageBox.Show("Giờ bắt đầu phải trước giờ kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Lấy dữ liệu từ form Ca Làm 
                var et = LayDuLieuTuFormCaLam();

                // 3. Gọi đúng BUS của Ca Làm Việc
                if (calam.ThemCaLam(et))
                {
                    MessageBox.Show("Thêm ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Gọi đúng các hàm xử lý hiển thị của Ca Làm
                    LoadDataCaLam();
                    ResetFormCaLamViec();
                }
                else
                {
                    MessageBox.Show("Thêm ca làm việc thất bại (Có thể do trùng mã ca)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi thêm ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 7. HÀM RESET LÀM TRỐNG FORM NHẬP LIỆU

        public void ResetFormDanhMuc()
        {
            txtMaPhuCap.Clear();
            txtTenPhuCap.Clear();
            txtMucTien.Clear();
            txtMaPhuCap.Enabled = true;
            LoadPhuCap = false;
        }

        public void ResetFormChucDanh()
        {
            txtMaChucDanh.Clear();
            txtTenChucDanh.Clear();
            txtCapBac.Clear();
            txtMaChucDanh.Enabled = true;
            loadChucDanh = false;
        }

        public void ResetFormPhongBan()
        {
            txtMaPhongBan.Clear();
            txtTenPhongBan.Clear();
            cboChiNhanh_PB.SelectedIndex = -1;
            txtMaPhongBan.Enabled = true;
            loadPhongban = false;
        }

        public void ResetFormChiNhanh()
        {
            txtMaChiNhanh.Clear();
            txtTenChiNhanh.Clear();
            txtDiaChi.Clear();
            txtHotline.Clear();
            txtMaChiNhanh.Enabled = true;
            loadChiNanh = false;
        }

        public void ResetFormChamCong()
        {
            txtMaHTCC.Clear();
            txtTenHTCC.Clear();
            txtMaHTCC.Enabled = true;
            loadChiNanh = false; // Có thể bạn cần đổi lại thành loadChamCong = false
        }

        public void ResetFormCaLamViec()
        {
            txtMaCa.Clear();
            txtTenCa.Clear();
            dtpGioBatDau.Value = DateTime.Now;
            dtpGioKetThuc.Value = DateTime.Now;
            txtMaCa.Enabled = true;
        }

        #endregion
    }
}