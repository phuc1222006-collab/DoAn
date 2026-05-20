using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BUS;
using ET;
namespace QLNS
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        //lấy ds nv
        public void LoadNhanVien()
        {
            try {
                BUS_NhanVien busNhanVien = new BUS_NhanVien();
                dgvNhanVien.DataSource = busNhanVien.LayDanhSachLenGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbChiTietNV_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            //BUS_ChiTietNhanVien bUS_ChiTietNhanVien = new BUS_ChiTietNhanVien();
            //string maNV = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            //txtMaNv.Text = maNV;
            //txtCCCD.Text = bUS_ChiTietNhanVien.LayChiTietNhanVien(maNV);
        }
    }
}
