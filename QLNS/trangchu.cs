using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using Guna.UI2.WinForms;

namespace QLNS
{
    public partial class trangchu : Form
    {
        private Form currentFormChild;
        BUS_TaiKhoang busTK = new BUS_TaiKhoang();
        Bus_NhatKy busNK =new Bus_NhatKy();
        public trangchu()
        {
            InitializeComponent();
        }

        private void btnDanhSachNV_Click(object sender, EventArgs e)
        {

            FormNhanVien frm = new FormNhanVien();
            OpenChildForm(frm);


        }

        private void btnTuyenDung_Click(object sender, EventArgs e)
        {


            Formtuyendung frm = new Formtuyendung();
            OpenChildForm(frm);


        }

        private void btnchamcong_Click(object sender, EventArgs e)
        {


            Formchamcong frm = new Formchamcong();
            OpenChildForm(frm);


        }

        private void btnTaiChinh_Click(object sender, EventArgs e)
        {


            Formtaichinh frm = new Formtaichinh();
            OpenChildForm(frm);


        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {


            Formdanhmuc frm = new Formdanhmuc();
            OpenChildForm(frm);


        }

        private void btnBaoMat_Click(object sender, EventArgs e)
        {

            Formhethong frm = new Formhethong();
            OpenChildForm(frm);
        }
        private void OpenChildForm(Form childForm)
        {// Kiểm tra: Nếu đã có form đang mở VÀ form đó cùng loại với form sắp mở
            if (currentFormChild != null && currentFormChild.GetType() == childForm.GetType())
            {
                return;
            }

            // Nếu là form khác, tiến hành đóng form cũ đi để giải phóng RAM
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild.Dispose();
            }

            // Xóa sạch Panel (đề phòng)
            if (pnDesktop.Controls.Count > 0)
            {
                pnDesktop.Controls.Clear();
            }

            // Gán form mới vào biến theo dõi
            currentFormChild = childForm;

            // Cấu hình form mới và nhúng vào Panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; // Tự động co giãn vừa khít Panel

            pnDesktop.Controls.Add(childForm);
            pnDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtntrangchu_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            OpenChildForm(frm);
        }

        private void rbtnthoat_Click(object sender, EventArgs e)
        {

            // 1. Khởi tạo hộp thoại của Guna
            Guna.UI2.WinForms.Guna2MessageDialog msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();

            // 2. Cấu hình nội dung và giao diện
            msgDialog.Caption = "Xác nhận";
            msgDialog.Text = "Bạn có chắc chắn muốn thoát phần mềm không?";
            msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light; // Nền trắng hiện đại

            // 3. Hiển thị và xử lý kết quả
            DialogResult rs = msgDialog.Show();

            if (rs == DialogResult.Yes)
            {
                Application.Exit(); // Tắt toàn bộ ứng dụng
            }
        }

        private void trangchu_Load(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            OpenChildForm(frm);
            // 2. Lấy Username đã lưu trong Settings từ lần đăng nhập trước
            string savedUsername = Properties.Settings.Default.Username;

            // 3. Thực hiện phân quyền
            if (!string.IsNullOrEmpty(savedUsername))
            {
                var tk = busTK.LayThongTinTaiKhoan(savedUsername);
                if (tk != null)
                {
                    // Dùng Trim() để xóa khoảng trắng thừa nếu có trong Database
                    XuLyPhanQuyenGiaoDien(tk.MaNhomQuyen.Trim());
                }
            }
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string currentUser = Properties.Settings.Default.Username;
                busNK.GhiNhatKy(currentUser, "Đăng xuất", "Người dùng tự đăng xuất khỏi hệ thống");
                // 1. Xóa trí nhớ đăng nhập
                Properties.Settings.Default.IsRemembered = false;
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Save();

                // 2. Khởi động lại ứng dụng (App sẽ chạy lại file Program.cs, thấy IsRemembered = false nên tự động mở Form Đăng Nhập)
                Application.Restart();
            }
        }
        // Hàm xử lý ẩn/hiện các nút bấm Menu dựa vào mã quyền
        private void XuLyPhanQuyenGiaoDien(string maNhomQuyen)
        {
            // Mặc định cho hiện tất cả (dành cho quyền ADMIN)
            btnDanhSachNV.Visible = true;
            btnTuyenDung.Visible = true;
            btnchamcong.Visible = true;
            btnTaiChinh.Visible = true;
            ribbonButton1.Visible = true; // Nút danh mục
            btnBaoMat.Visible = true;     // Nút hệ thống

            //if (maNhomQuyen == "NV")
            //{
            //    // Quyền Nhân viên: Ẩn quản lý cấp cao
            //    btnDanhSachNV.Visible = false;
            //    btnTuyenDung.Visible = false;
            //    btnTaiChinh.Visible = false;
            //    btnBaoMat.Visible = false;
            //}
            if (maNhomQuyen == "HR")
            {
                // Quyền Nhân sự: Ẩn Tài chính và Hệ thống
                btnTaiChinh.Visible = false;
                btnBaoMat.Visible = false;
            }
            else if (maNhomQuyen == "KT")
            {
                // Quyền Kế toán: Ẩn Tuyển dụng và Hệ thống
                btnTuyenDung.Visible = false;
                btnBaoMat.Visible = false;
            }
        }
    }
}
