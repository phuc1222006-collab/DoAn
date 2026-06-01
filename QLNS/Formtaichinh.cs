using BUS;
using BUS;
using ClassLibrary3;
using ET;
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
    public partial class Formtaichinh : Form
    {
        #region 1. KHAI BÁO BIẾN & KHỞI TẠO FORM
        BUS_TamUng busTamUng = new BUS_TamUng();
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        BUS_KhenThuong khenthuong = new BUS_KhenThuong();
        BUS_PhuCap phucap = new BUS_PhuCap();
        BUS_TaiKhoang bustk = new BUS_TaiKhoang();
        BUS_DanhMucPhuCap busdmpk=new BUS_DanhMucPhuCap();

        bool isLoadedNo = false; // Trạng thái Thêm/Sửa của Tạm Ứng
        bool khen = false;       // Trạng thái Thêm/Sửa của Khen Thưởng
        bool LuuLai = false;
        bool pc = false;

        public Formtaichinh()
        {
            InitializeComponent();
        }

        private void Formtaichinh_Load(object sender, EventArgs e)
        {
            LoadDataTamUng();
            LoadDataKhenThuong();
            LoadDataPhuCap(); 
            LoadAllComboBoxNhanVien();
        }
        private void LoadDataPhuCap()
        {
            // Gọi đúng hàm LayDanhSachPhuCap từ tầng BUS của bạn
            dgvPhuCapNV.DataSource = phucap.LayDanhSachPhuCap();
        }
        #endregion

        #region 2. NẠP DỮ LIỆU (LOAD DATA & COMBOBOX)
        private void LoadDataTamUng()
        {
            dgvTamUng.DataSource = busTamUng.LayDanhSachLenGrid();
        }

        private void LoadDataKhenThuong()
        {
            dgvKhenThuong.DataSource = khenthuong.LayDanhSachKhenThuong();
        }
        public ET_PhuCap ET_phucap()
        {
            string maNV = "";
            if (cboNhanVienPC.SelectedValue != null)
                maNV = cboNhanVienPC.SelectedValue.ToString();
            else
                maNV = cboNhanVienPC.Text;

            string maPC = "";
            if (cboPhuCap.SelectedValue != null)
                maPC = cboPhuCap.SelectedValue.ToString();
            else
                maPC = cboPhuCap.Text;

            return new ET_PhuCap
            {
                MaPhuCap = maPC,
                MaNhanVien = maNV,
                NgayPhuCap = dtpNgayCap.Value,  // Điền đúng tên DateTimePicker của bạn
                LyDoCap = txtLyDoPC.Text.Trim() // Điền đúng tên TextBox ghi chú lý do của bạn
            };
        }
        private void LoadAllComboBoxNhanVien()
        {
            try
            {
                // Lấy danh sách nhân viên từ tầng BUS
                var listNhanVien = busNhanVien.LayDanhSachLenGrid();

                // 1. Nạp dữ liệu cho ComboBox Nhân Viên bên tab Tạm Ứng
                cboNhanVienTU.DataSource = new BindingSource(listNhanVien, null);
                cboNhanVienTU.DisplayMember = "MaNhanVien";
                cboNhanVienTU.ValueMember = "MaNhanVien";
                cboNhanVienTU.SelectedIndex = -1;

                // 2. Nạp dữ liệu cho ComboBox Nhân Viên bên tab Khen Thưởng
                cboNhanVienKT.DataSource = new BindingSource(listNhanVien, null);
                cboNhanVienKT.DisplayMember = "MaNhanVien";
                cboNhanVienKT.ValueMember = "MaNhanVien";
                cboNhanVienKT.SelectedIndex = -1;

                // ==========================================================
                // KHÚC NÀY BỊ THIẾU NÀY - ĐÃ BỔ SUNG CHO BẠN:
                // ==========================================================

                // 3. Nạp dữ liệu cho ComboBox Nhân Viên bên tab PHỤ CẤP
                cboNhanVienPC.DataSource = new BindingSource(listNhanVien, null);
                cboNhanVienPC.DisplayMember = "MaNhanVien"; // Bạn có thể đổi thành "TenNhanVien" nếu muốn hiện tên người
                cboNhanVienPC.ValueMember = "MaNhanVien";
                cboNhanVienPC.SelectedIndex = -1;

                // 4. Nạp dữ liệu cho ComboBox Loại Phụ Cấp
                // (Lưu ý: Nếu tầng BUS của bạn có hàm riêng để lấy "Danh Mục Loại Phụ Cấp" thì đổi tên hàm tại đây nhé)
                cboPhuCap.DataSource = busdmpk.layDanhSachPhucap();
                cboPhuCap.DisplayMember = "tenPhuCap"; // Bạn có thể đổi thành "TenPhuCap" nếu muốn hiện tên loại phụ cấp
                cboPhuCap.ValueMember = "maPhuCap";
                cboPhuCap.SelectedIndex = -1;

                cboLoaiQD.Items.Clear();
                cboLoaiQD.Items.Add("Khen Thưởng");
                cboLoaiQD.Items.Add("kỉ luật");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 3. XỬ LÝ ĐỐI TƯỢNG TRUNG GIAN (ET)
        public ET_TamUng ET_tamung()
        {
            // Lấy mã nhân viên
            string maNV = "";
            if (cboNhanVienTU.SelectedValue != null)
                maNV = cboNhanVienTU.SelectedValue.ToString();
            else if (cboNhanVienTU.SelectedItem != null)
                maNV = cboNhanVienTU.SelectedItem.ToString();
            else
                maNV = cboNhanVienTU.Text;
            // Hàm Split sẽ chặt bỏ phần thập phân sau dấu chấm/phẩy, chỉ lấy phần số nguyên
            string chuoiSoTien = txtSoTienTU.Text.Split('.')[0].Split(',')[0].Trim();
            int soTien = 0;
            int.TryParse(chuoiSoTien, out soTien); // Ép kiểu an toàn, không bao giờ văng app
            DateTime ngayTamUng = DateTime.Now; // Mặc định là hôm nay (nếu tạo mới)

            // isLoadedNo = true nghĩa là bạn đang click vào lưới để Sửa hoặc Duyệt
            if (isLoadedNo == true && dgvTamUng.CurrentRow != null)
            {
                if (dgvTamUng.CurrentRow.Cells["NgayTamUng"].Value != null)
                {
                    // Lấy lại ngày cũ từ dưới lưới lên
                    ngayTamUng = Convert.ToDateTime(dgvTamUng.CurrentRow.Cells["NgayTamUng"].Value);
                }
            }

            return new ET_TamUng
            {
                MaTamUng = txtMaTamUng.Text.Trim(),
                SoTien = soTien,
                MaNhanVien = maNV,
                LyDo = txtLyDoTU.Text.Trim(),

                // Luôn để mặc định là 0 và null. 
                // Khi ấn nút Duyệt, code ở nút Duyệt sẽ tự động đè lại giá trị này thành 1 và Tên tài khoản.
                TrangThai = 0,
                NguoiDuyet = null,

                // Dùng biến ngayTamUng đã xử lý ở trên
                NgayTamUng = ngayTamUng,
                ThangKhauTru = ngayTamUng.Month,
                NamKhauTru = ngayTamUng.Year
            };
        }
        public ET_KhenThuong ET_KhenThuong()
        {
            string maNV = "";
            if (cboNhanVienKT.SelectedValue != null)
                maNV = cboNhanVienKT.SelectedValue.ToString();
            else if (cboNhanVienKT.SelectedItem != null)
                maNV = cboNhanVienKT.SelectedItem.ToString();
            else
                maNV = cboNhanVienKT.Text;

            string loaiqt = "";
            if (cboLoaiQD.SelectedValue != null)
                loaiqt = cboLoaiQD.SelectedValue.ToString();
            else if (cboLoaiQD.SelectedItem != null)
                loaiqt = cboLoaiQD.SelectedItem.ToString();
            else
                loaiqt = cboLoaiQD.Text;

            // ĐÃ CHỈNH SỬA: Ép kiểu an toàn tránh lỗi khoảng trắng hoặc định dạng số tiền
            string cleanSoTien = txtSoTienKT.Text.Replace(".", "").Replace(",", "").Trim();
            int conversionSoTien = 0;
            int.TryParse(cleanSoTien, out conversionSoTien);
            ET_TaiKhoan ettk = bustk.LayThongTinTaiKhoan(Properties.Settings.Default.Username);
            ET_NhanVien etnv = busNhanVien.LayThongTinCoBan(ettk.MaNhanVien);
            return new ET_KhenThuong
            {
                MaQuyetDinh = txtMaQD.Text.Trim(),
                MaNhanVien = maNV,
                LoaiQuyetDinh = loaiqt,
                LyDo = txtLyDoKT.Text.Trim(),
                NguoiQuyetDinh = etnv.HoTen.ToString(),
                NgayQuyetDinh = DateTime.Now,
                SoTien = conversionSoTien,
            };
        }
        #endregion

        #region 4. SỰ KIỆN CLICK LƯỚI (CELL CLICK)
        private void dgvTamUng_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvTamUng.Rows[e.RowIndex];

                    txtMaTamUng.Text = row.Cells["MaTamUng"].Value?.ToString();
                    if (row.Cells["SoTien"].Value != null && row.Cells["SoTien"].Value.ToString() != "")
                    {
                        // Ép sang decimal rồi dùng ToString("0") để ép nó thành số nguyên (bỏ dấu .00 đi)
                        decimal soTien = Convert.ToDecimal(row.Cells["SoTien"].Value);
                        txtSoTienTU.Text = soTien.ToString("0");
                    }
                    else
                    {
                        txtSoTienTU.Text = "0";
                    }

                    if (cboNhanVienTU.DataSource != null)
                        cboNhanVienTU.SelectedValue = row.Cells["MaNhanVien"].Value?.ToString();
                    else
                        cboNhanVienTU.Text = row.Cells["MaNhanVien"].Value?.ToString();

                    txtLyDoTU.Text = row.Cells["LyDo"].Value?.ToString();

                    txtMaTamUng.Enabled = false;
                    isLoadedNo = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu Tạm ứng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ĐÃ ĐỔI: Chuyển hoàn toàn từ sự kiện CellContentClick sang CellClick để click dòng nào cũng ăn mượt mà
        private void dgvKhenThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #endregion

        #region 5. XỬ LÝ LƯU DỮ LIỆU (THÊM / SỬA)
        private void btnLuuTU_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaTamUng.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã tạm ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTamUng.Focus();
                    return;
                }

                var et = ET_tamung();

                if (et.SoTien <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ và lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTienTU.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(et.MaNhanVien))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần tạm ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNhanVienTU.Focus();
                    return;
                }

                if (isLoadedNo == true)
                {
                    if (busTamUng.SuaTamUng(et))
                    {
                        MessageBox.Show("Cập nhật thông tin tạm ứng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataTamUng();
                        ResetFormTamUng();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại! Vui lòng kiểm tra lại.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (busTamUng.ThemTamUng(et))
                    {
                        MessageBox.Show("Thêm mới yêu cầu tạm ứng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataTamUng();
                        ResetFormTamUng();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại! Vui lòng kiểm tra lại ràng buộc dữ liệu.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống gặp lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuKT_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaQD.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã quyết định khen thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaQD.Focus();
                    return;
                }

                var et = ET_KhenThuong();

                if (et.SoTien <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền hợp lệ và lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTienKT.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(et.MaNhanVien))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNhanVienKT.Focus();
                    return;
                }

                if (khen == true)
                {
                    if (khenthuong.SuaKhenThuong(et))
                    {
                        MessageBox.Show("Cập nhật quyết định khen thưởng/kỷ luật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataKhenThuong();
                        ResetFormKhenThuong();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại! Vui lòng kiểm tra lại.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // ĐÃ SỬA: Gọi đúng tên hàm ThemKhenThuong (có chữ h) ở tầng BUS để không bị lỗi compile
                    if (khenthuong.ThemKhenThuong(et))
                    {
                        MessageBox.Show("Thêm mới quyết định khen thưởng/kỷ luật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataKhenThuong();
                        ResetFormKhenThuong();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại! Vui lòng kiểm tra lại ràng buộc dữ liệu.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống gặp lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvKhenThuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvKhenThuong.Rows[e.RowIndex];

                    txtMaQD.Text = row.Cells["MaQuyetDinh"].Value?.ToString();
                    txtSoTienKT.Text = row.Cells["SoTien"].Value?.ToString();

                    if (cboNhanVienKT.DataSource != null)
                        cboNhanVienKT.SelectedValue = row.Cells["MaNhanVien"].Value?.ToString();
                    else
                        cboNhanVienKT.Text = row.Cells["MaNhanVien"].Value?.ToString();

                    cboLoaiQD.Text = row.Cells["LoaiQuyetDinh"].Value?.ToString();
                    txtLyDoKT.Text = row.Cells["LyDo"].Value?.ToString();

                    txtMaQD.Enabled = false;
                    khen = true; // Chuyển trạng thái sửa thành công!
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu Khen thưởng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuuPC_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào cơ bản
                if (string.IsNullOrWhiteSpace(cboNhanVienPC.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNhanVienPC.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cboPhuCap.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại phụ cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboPhuCap.Focus();
                    return;
                }

                var et = ET_phucap();

                if (pc == true) // Chế độ Cập nhật dữ liệu
                {
                    if (phucap.SuaPhuCap(et)) // Gọi hàm SuaPhuCap từ file BUS của bạn
                    {
                        MessageBox.Show("Cập nhật thông tin phụ cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataPhuCap();
                        ResetFormPhuCap();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại! Vui lòng kiểm tra lại hệ thống.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Chế độ Thêm mới cấp phát
                {
                    // LƯU Ý: Ở đây gọi hàm "ThemTamUng" vì trong file BUS_PhuCap.cs bạn đang đặt tên như vậy
                    if (phucap.ThemPHuCap(et))
                    {
                        MessageBox.Show("Cấp phát phụ cấp cho nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataPhuCap();
                        ResetFormPhuCap();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại! Nhân viên này có thể đã được cấp loại phụ cấp này rồi.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống phụ cấp gặp lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvPhuCapNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvPhuCapNV.Rows[e.RowIndex];

                    // Đổ dữ liệu ngược lại ComboBox thông qua ValueMember
                    if (cboNhanVienPC.DataSource != null)
                        cboNhanVienPC.SelectedValue = row.Cells["MaNhanVien"].Value?.ToString();
                    else
                        cboNhanVienPC.Text = row.Cells["MaNhanVien"].Value?.ToString();

                    if (cboPhuCap.DataSource != null)
                        cboPhuCap.SelectedValue = row.Cells["MaPhuCap"].Value?.ToString();
                    else
                        cboPhuCap.Text = row.Cells["MaPhuCap"].Value?.ToString();

                    // Đổ dữ liệu ngày tháng và lý do
                    if (row.Cells["NgayPhuCap"].Value != null)
                        dtpNgayCap.Value = Convert.ToDateTime(row.Cells["NgayPhuCap"].Value);

                    txtLyDoPC.Text = row.Cells["LyDoCap"].Value?.ToString();

                    // Khóa chế độ chọn mã khi đang ở trạng thái sửa dữ liệu
                    cboNhanVienPC.Enabled = false;
                    cboPhuCap.Enabled = false;
                    pc = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu phụ cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 6. RESET FORM
        public void ResetFormTamUng()
        {
            txtMaTamUng.Clear();
            txtSoTienTU.Clear();
            if (txtLyDoTU != null) txtLyDoTU.Clear();
            cboNhanVienTU.SelectedIndex = -1;
            txtMaTamUng.Enabled = true;
            isLoadedNo = false;
        }

        public void ResetFormKhenThuong()
        {
            txtMaQD.Clear();
            txtSoTienKT.Clear();
            txtLyDoKT.Clear();
            cboNhanVienKT.SelectedIndex = -1;
            cboLoaiQD.SelectedIndex = -1;
            txtMaQD.Enabled = true;
            khen = false;
        }

        public void ResetFormPhuCap()
        {
            cboNhanVienPC.SelectedIndex = -1;
            cboPhuCap.SelectedIndex = -1;
            dtpNgayCap.Value = DateTime.Now;
            txtLyDoPC.Clear();

            // Mở lại khóa để cho phép thêm mới dòng khác
            cboNhanVienPC.Enabled = true;
            cboPhuCap.Enabled = true;
            pc = false;
        }

        #endregion

        private void cboNhanVienTU_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvTamUng_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDuyetTU_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra xem người dùng đã chọn phiếu tạm ứng nào chưa
                if (string.IsNullOrWhiteSpace(txtMaTamUng.Text))
                {
                    MessageBox.Show("Vui lòng chọn một phiếu tạm ứng trên lưới để duyệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Hỏi xác nhận tránh bấm nhầm
                if (MessageBox.Show($"Bạn có chắc chắn muốn duyệt phiếu tạm ứng: {txtMaTamUng.Text}?", "Xác nhận duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 3. Sử dụng hàm ET_tamung() có sẵn của bạn để gom dữ liệu trên Form thành 1 Object
                    var et = ET_tamung();

                    // 4. Bơm thêm dữ liệu DUYỆT vào Object đó
                    et.TrangThai = 1;

                    // Gọi hàm lấy thông tin Tài khoản (chỗ này bạn đã có sẵn BUS_TaiKhoang ở đầu Form)
                    var tk = bustk.LayThongTinTaiKhoan(Properties.Settings.Default.Username);

                    if (tk != null)
                    {
                        // Gán bằng Mã Nhân Viên thực sự của tài khoản đó thay vì Username
                        et.NguoiDuyet = tk.MaNhanVien;

                        // ========================================================
                        // BỔ SUNG Ở ĐÂY: Hứng kết quả, báo lỗi/thành công và tải lại lưới
                        // ========================================================
                        bool ketQua = busTamUng.SuaTamUng(et);

                        if (ketQua)
                        {
                            MessageBox.Show("Duyệt phiếu tạm ứng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataTamUng();  // Làm mới lại lưới DataGridView
                            ResetFormTamUng(); // Dọn dẹp các TextBox
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại! Phiếu này có thể không tồn tại hoặc lỗi CSDL.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không xác định được mã nhân viên của người duyệt!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống gặp lỗi trong quá trình duyệt: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}