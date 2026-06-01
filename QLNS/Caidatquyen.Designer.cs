namespace QLNS
{
    partial class Caidatquyen
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
            this.lblNhomQuyen = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.dgvChucNangCon = new System.Windows.Forms.DataGridView();
            this.dgvThaoTac = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucNangCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThaoTac)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNhomQuyen
            // 
            this.lblNhomQuyen.AutoSize = true;
            this.lblNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomQuyen.ForeColor = System.Drawing.Color.Navy;
            this.lblNhomQuyen.Location = new System.Drawing.Point(20, 20);
            this.lblNhomQuyen.Name = "lblNhomQuyen";
            this.lblNhomQuyen.Size = new System.Drawing.Size(323, 31);
            this.lblNhomQuyen.TabIndex = 0;
            this.lblNhomQuyen.Text = "Đang phân quyền cho nhóm:";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(890, 15);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(170, 42);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu Phân Quyền";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvMenu
            // 
            this.dgvMenu.AllowUserToAddRows = false;
            this.dgvMenu.AllowUserToDeleteRows = false;
            this.dgvMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenu.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenu.ColumnHeadersHeight = 40;
            this.dgvMenu.Location = new System.Drawing.Point(20, 75);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersVisible = false;
            this.dgvMenu.RowHeadersWidth = 51;
            this.dgvMenu.RowTemplate.Height = 35;
            this.dgvMenu.Size = new System.Drawing.Size(330, 450);
            this.dgvMenu.TabIndex = 2;
            this.dgvMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellClick);
            // 
            // dgvChucNangCon
            // 
            this.dgvChucNangCon.AllowUserToAddRows = false;
            this.dgvChucNangCon.AllowUserToDeleteRows = false;
            this.dgvChucNangCon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvChucNangCon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChucNangCon.BackgroundColor = System.Drawing.Color.White;
            this.dgvChucNangCon.ColumnHeadersHeight = 40;
            this.dgvChucNangCon.Location = new System.Drawing.Point(370, 75);
            this.dgvChucNangCon.Name = "dgvChucNangCon";
            this.dgvChucNangCon.RowHeadersVisible = false;
            this.dgvChucNangCon.RowHeadersWidth = 51;
            this.dgvChucNangCon.RowTemplate.Height = 35;
            this.dgvChucNangCon.Size = new System.Drawing.Size(340, 450);
            this.dgvChucNangCon.TabIndex = 3;
            this.dgvChucNangCon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChucNangCon_CellClick);
            // 
            // dgvThaoTac
            // 
            this.dgvThaoTac.AllowUserToAddRows = false;
            this.dgvThaoTac.AllowUserToDeleteRows = false;
            this.dgvThaoTac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThaoTac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThaoTac.BackgroundColor = System.Drawing.Color.White;
            this.dgvThaoTac.ColumnHeadersHeight = 40;
            this.dgvThaoTac.Location = new System.Drawing.Point(730, 75);
            this.dgvThaoTac.Name = "dgvThaoTac";
            this.dgvThaoTac.RowHeadersVisible = false;
            this.dgvThaoTac.RowHeadersWidth = 51;
            this.dgvThaoTac.RowTemplate.Height = 35;
            this.dgvThaoTac.Size = new System.Drawing.Size(330, 450);
            this.dgvThaoTac.TabIndex = 4;
            this.dgvThaoTac.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThaoTac_CellValueChanged);
            this.dgvThaoTac.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvThaoTac_CurrentCellDirtyStateChanged);
            // 
            // Caidatquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1080, 550);
            this.Controls.Add(this.dgvThaoTac);
            this.Controls.Add(this.dgvChucNangCon);
            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblNhomQuyen);
            this.Name = "Caidatquyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt phân quyền hệ thống";
            this.Load += new System.EventHandler(this.Caidatquyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucNangCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThaoTac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNhomQuyen;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridView dgvChucNangCon;
        private System.Windows.Forms.DataGridView dgvThaoTac;
    }
}