namespace QLNS
{
    partial class Formhethong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabHeThong = new Guna.UI2.WinForms.Guna2TabControl();

            // TABS
            this.pageTaiKhoan = new System.Windows.Forms.TabPage();
            this.pageNhomQuyen = new System.Windows.Forms.TabPage();

            // ==========================================
            // 1. CONTROLS QUẢN LÝ TÀI KHOẢN
            // ==========================================
            this.pnInputTaiKhoan = new Guna.UI2.WinForms.Guna2Panel();
            this.cboNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTenDangNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboNhomQuyen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.swTrangThai = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.btnLuuTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTaiKhoan = new Guna.UI2.WinForms.Guna2DataGridView();

            // ==========================================
            // 2. CONTROLS NHÓM QUYỀN
            // ==========================================
            this.pnInputNhomQuyen = new Guna.UI2.WinForms.Guna2Panel();
            this.txtMaNhom = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenNhom = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLuuNhom = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaNhom = new Guna.UI2.WinForms.Guna2Button();
            this.dgvNhomQuyen = new Guna.UI2.WinForms.Guna2DataGridView();

            this.tabHeThong.SuspendLayout();

            this.pageTaiKhoan.SuspendLayout();
            this.pnInputTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();

            this.pageNhomQuyen.SuspendLayout();
            this.pnInputNhomQuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomQuyen)).BeginInit();

            this.SuspendLayout();

            // 
            // tabHeThong
            // 
            this.tabHeThong.Controls.Add(this.pageTaiKhoan);
            this.tabHeThong.Controls.Add(this.pageNhomQuyen);
            this.tabHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHeThong.ItemSize = new System.Drawing.Size(250, 50);
            this.tabHeThong.Location = new System.Drawing.Point(0, 0);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.SelectedIndex = 0;
            this.tabHeThong.Size = new System.Drawing.Size(1200, 700);
            this.tabHeThong.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tabHeThong.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabHeThong.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            this.tabHeThong.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(202)))), ((int)(((byte)(160)))));
            this.tabHeThong.TabMenuBackColor = System.Drawing.Color.White;
            this.tabHeThong.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;

            // =========================================================================
            // TAB 1: QUẢN LÝ TÀI KHOẢN
            // =========================================================================
            this.pageTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pageTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.pageTaiKhoan.Controls.Add(this.pnInputTaiKhoan);
            this.pageTaiKhoan.Location = new System.Drawing.Point(4, 54);
            this.pageTaiKhoan.Name = "pageTaiKhoan";
            this.pageTaiKhoan.Padding = new System.Windows.Forms.Padding(20);
            this.pageTaiKhoan.Size = new System.Drawing.Size(1192, 642);
            this.pageTaiKhoan.Text = "Quản Lý Tài Khoản";

            this.pnInputTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.pnInputTaiKhoan.BorderRadius = 10;
            this.pnInputTaiKhoan.Controls.Add(this.btnXoaTaiKhoan);
            this.pnInputTaiKhoan.Controls.Add(this.btnLuuTaiKhoan);
            this.pnInputTaiKhoan.Controls.Add(this.swTrangThai);
            this.pnInputTaiKhoan.Controls.Add(this.lblTrangThai);
            this.pnInputTaiKhoan.Controls.Add(this.cboNhomQuyen);
            this.pnInputTaiKhoan.Controls.Add(this.txtMatKhau);
            this.pnInputTaiKhoan.Controls.Add(this.txtTenDangNhap);
            this.pnInputTaiKhoan.Controls.Add(this.cboNhanVien);
            this.pnInputTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnInputTaiKhoan.FillColor = System.Drawing.Color.White;
            this.pnInputTaiKhoan.Location = new System.Drawing.Point(20, 20);
            this.pnInputTaiKhoan.Size = new System.Drawing.Size(1152, 140);

            // Dòng 1
            this.cboNhanVien.Location = new System.Drawing.Point(30, 20);
            this.cboNhanVien.Size = new System.Drawing.Size(350, 36);

            this.txtTenDangNhap.PlaceholderText = "Tên đăng nhập (Username)...";
            this.txtTenDangNhap.Location = new System.Drawing.Point(400, 20);
            this.txtTenDangNhap.Size = new System.Drawing.Size(250, 36);

            this.txtMatKhau.PlaceholderText = "Mật khẩu (Password)...";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Location = new System.Drawing.Point(670, 20);
            this.txtMatKhau.Size = new System.Drawing.Size(250, 36);

            // Dòng 2
            this.cboNhomQuyen.Location = new System.Drawing.Point(30, 75);
            this.cboNhomQuyen.Size = new System.Drawing.Size(350, 36);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(400, 85);
            this.lblTrangThai.Text = "Kích hoạt tài khoản:";

            this.swTrangThai.Checked = true;
            this.swTrangThai.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(202)))), ((int)(((byte)(160)))));
            this.swTrangThai.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(202)))), ((int)(((byte)(160)))));
            this.swTrangThai.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.swTrangThai.CheckedState.InnerColor = System.Drawing.Color.White;
            this.swTrangThai.Location = new System.Drawing.Point(540, 83);
            this.swTrangThai.Size = new System.Drawing.Size(45, 22);

            // Buttons
            this.btnLuuTaiKhoan.Text = "LƯU TÀI KHOẢN";
            this.btnLuuTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            this.btnLuuTaiKhoan.Location = new System.Drawing.Point(750, 75);
            this.btnLuuTaiKhoan.Size = new System.Drawing.Size(170, 36);
            this.btnLuuTaiKhoan.BorderRadius = 5;

            this.btnXoaTaiKhoan.Text = "XÓA";
            this.btnXoaTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnXoaTaiKhoan.Location = new System.Drawing.Point(930, 75);
            this.btnXoaTaiKhoan.Size = new System.Drawing.Size(100, 36);
            this.btnXoaTaiKhoan.BorderRadius = 5;

            // Grid Tài Khoản
            this.dgvTaiKhoan.Location = new System.Drawing.Point(20, 180);
            this.dgvTaiKhoan.Size = new System.Drawing.Size(1152, 440);
            this.dgvTaiKhoan.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            // =========================================================================
            // TAB 2: NHÓM QUYỀN
            // =========================================================================
            this.pageNhomQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pageNhomQuyen.Controls.Add(this.dgvNhomQuyen);
            this.pageNhomQuyen.Controls.Add(this.pnInputNhomQuyen);
            this.pageNhomQuyen.Location = new System.Drawing.Point(4, 54);
            this.pageNhomQuyen.Name = "pageNhomQuyen";
            this.pageNhomQuyen.Padding = new System.Windows.Forms.Padding(20);
            this.pageNhomQuyen.Size = new System.Drawing.Size(1192, 642);
            this.pageNhomQuyen.Text = "Nhóm Quyền Hệ Thống";

            this.pnInputNhomQuyen.BackColor = System.Drawing.Color.Transparent;
            this.pnInputNhomQuyen.BorderRadius = 10;
            this.pnInputNhomQuyen.Controls.Add(this.btnXoaNhom);
            this.pnInputNhomQuyen.Controls.Add(this.btnLuuNhom);
            this.pnInputNhomQuyen.Controls.Add(this.txtMoTa);
            this.pnInputNhomQuyen.Controls.Add(this.txtTenNhom);
            this.pnInputNhomQuyen.Controls.Add(this.txtMaNhom);
            this.pnInputNhomQuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnInputNhomQuyen.FillColor = System.Drawing.Color.White;
            this.pnInputNhomQuyen.Location = new System.Drawing.Point(20, 20);
            this.pnInputNhomQuyen.Size = new System.Drawing.Size(1152, 100);

            this.txtMaNhom.PlaceholderText = "Mã nhóm quyền (VD: ADMIN)...";
            this.txtMaNhom.Location = new System.Drawing.Point(30, 30);
            this.txtMaNhom.Size = new System.Drawing.Size(200, 36);

            this.txtTenNhom.PlaceholderText = "Tên nhóm quyền...";
            this.txtTenNhom.Location = new System.Drawing.Point(250, 30);
            this.txtTenNhom.Size = new System.Drawing.Size(250, 36);

            this.txtMoTa.PlaceholderText = "Mô tả vai trò...";
            this.txtMoTa.Location = new System.Drawing.Point(520, 30);
            this.txtMoTa.Size = new System.Drawing.Size(350, 36);

            this.btnLuuNhom.Text = "LƯU DỮ LIỆU";
            this.btnLuuNhom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            this.btnLuuNhom.Location = new System.Drawing.Point(890, 30);
            this.btnLuuNhom.Size = new System.Drawing.Size(130, 36);
            this.btnLuuNhom.BorderRadius = 5;

            this.btnXoaNhom.Text = "XÓA";
            this.btnXoaNhom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnXoaNhom.Location = new System.Drawing.Point(1030, 30);
            this.btnXoaNhom.Size = new System.Drawing.Size(90, 36);
            this.btnXoaNhom.BorderRadius = 5;

            // Grid Nhóm Quyền
            this.dgvNhomQuyen.Location = new System.Drawing.Point(20, 140);
            this.dgvNhomQuyen.Size = new System.Drawing.Size(1152, 480);
            this.dgvNhomQuyen.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            // 
            // FrmHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabHeThong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHeThong";
            this.Text = "Hệ Thống & Bảo Mật";

            this.tabHeThong.ResumeLayout(false);

            this.pageTaiKhoan.ResumeLayout(false);
            this.pnInputTaiKhoan.ResumeLayout(false);
            this.pnInputTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();

            this.pageNhomQuyen.ResumeLayout(false);
            this.pnInputNhomQuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomQuyen)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tabHeThong;

        // Tab Tài Khoản
        private System.Windows.Forms.TabPage pageTaiKhoan;
        private Guna.UI2.WinForms.Guna2Panel pnInputTaiKhoan;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhanVien;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDangNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhomQuyen;
        private System.Windows.Forms.Label lblTrangThai;
        private Guna.UI2.WinForms.Guna2ToggleSwitch swTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnLuuTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnXoaTaiKhoan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTaiKhoan;

        // Tab Nhóm Quyền
        private System.Windows.Forms.TabPage pageNhomQuyen;
        private Guna.UI2.WinForms.Guna2Panel pnInputNhomQuyen;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNhom;
        private Guna.UI2.WinForms.Guna2TextBox txtTenNhom;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
        private Guna.UI2.WinForms.Guna2Button btnLuuNhom;
        private Guna.UI2.WinForms.Guna2Button btnXoaNhom;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhomQuyen;
    }
}