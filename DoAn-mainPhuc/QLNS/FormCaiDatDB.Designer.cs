namespace QLNS
{
    partial class FormCaiDatDB
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
            this.components = new System.ComponentModel.Container();
            this.cboServer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboDatabase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkWinAuth = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.SuspendLayout();
            // 
            // cboServer
            // 
            this.cboServer.BackColor = System.Drawing.Color.Transparent;
            this.cboServer.BorderRadius = 8;
            this.cboServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServer.FocusedColor = System.Drawing.Color.Empty;
            this.cboServer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboServer.ItemHeight = 39;
            this.cboServer.Location = new System.Drawing.Point(50, 100);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(400, 45);
            this.cboServer.TabIndex = 1;
            this.cboServer.DropDown += new System.EventHandler(this.cboServer_DropDown);
            // 
            // cboDatabase
            // 
            this.cboDatabase.BackColor = System.Drawing.Color.Transparent;
            this.cboDatabase.BorderRadius = 8;
            this.cboDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FocusedColor = System.Drawing.Color.Empty;
            this.cboDatabase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDatabase.ItemHeight = 39;
            this.cboDatabase.Location = new System.Drawing.Point(50, 160);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(400, 45);
            this.cboDatabase.TabIndex = 2;
            this.cboDatabase.DropDown += new System.EventHandler(this.cboDatabase_DropDown);
            // 
            // txtUser
            // 
            this.txtUser.BorderRadius = 8;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.Enabled = false;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUser.Location = new System.Drawing.Point(50, 260);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "User SQL (VD: sa)";
            this.txtUser.SelectedText = "";
            this.txtUser.Size = new System.Drawing.Size(190, 45);
            this.txtUser.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.BorderRadius = 8;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.DefaultText = "";
            this.txtPass.Enabled = false;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPass.Location = new System.Drawing.Point(260, 260);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.PlaceholderText = "Mật khẩu SQL";
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(190, 45);
            this.txtPass.TabIndex = 5;
            // 
            // chkWinAuth
            // 
            this.chkWinAuth.AutoSize = true;
            this.chkWinAuth.Checked = true;
            this.chkWinAuth.CheckedState.BorderRadius = 0;
            this.chkWinAuth.CheckedState.BorderThickness = 0;
            this.chkWinAuth.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            this.chkWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWinAuth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkWinAuth.Location = new System.Drawing.Point(50, 220);
            this.chkWinAuth.Name = "chkWinAuth";
            this.chkWinAuth.Size = new System.Drawing.Size(288, 27);
            this.chkWinAuth.TabIndex = 3;
            this.chkWinAuth.Text = "Sử dụng Windows Authentication";
            this.chkWinAuth.UncheckedState.BorderRadius = 0;
            this.chkWinAuth.UncheckedState.BorderThickness = 0;
            this.chkWinAuth.CheckedChanged += new System.EventHandler(this.chkWinAuth_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(50, 330);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(400, 50);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "KIỂM TRA VÀ LƯU KẾT NỐI";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BorderColor = System.Drawing.Color.Gray;
            this.btnThoat.BorderRadius = 8;
            this.btnThoat.BorderThickness = 1;
            this.btnThoat.FillColor = System.Drawing.Color.White;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.Gray;
            this.btnThoat.Location = new System.Drawing.Point(50, 390);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(400, 50);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "THOÁT PHẦN MỀM";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.labelTitle.Location = new System.Drawing.Point(50, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(388, 38);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "LỖI KẾT NỐI CƠ SỞ DỮ LIỆU";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // FormCaiDatDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.chkWinAuth);
            this.Controls.Add(this.cboDatabase);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCaiDatDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt CSDL";
            this.Load += new System.EventHandler(this.FormCaiDatDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cboServer; // Đã thêm
        private Guna.UI2.WinForms.Guna2ComboBox cboDatabase;
        private Guna.UI2.WinForms.Guna2CheckBox chkWinAuth;
        private Guna.UI2.WinForms.Guna2TextBox txtUser;
        private Guna.UI2.WinForms.Guna2TextBox txtPass;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}