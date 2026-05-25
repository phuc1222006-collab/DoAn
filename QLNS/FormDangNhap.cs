using System;
using System.Windows.Forms;
using ClassLibrary1; // Chứa tầng BUS

namespace QLNS
{
    public partial class FormDangNhap : Form
    {
        // Khởi tạo đối tượng BUS để xử lý nghiệp vụ tài khoản
        BUS_TaiKhoang busTK = new BUS_TaiKhoang();
        Bus_NhatKy busNK=new Bus_NhatKy();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        // ==========================================
        // SỰ KIỆN: NHẤN NÚT ĐĂNG NHẬP
        // ==========================================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi tầng BUS kiểm tra trong CSDL
            if (busTK.KiemTraDangNhap(user, pass))
            {
                // ============================================
                // THÊM 3 DÒNG NÀY ĐỂ LƯU TRẠNG THÁI ĐĂNG NHẬP
                Properties.Settings.Default.IsRemembered = true;
                Properties.Settings.Default.Username = user; // Lưu lại user để dùng sau này (ví dụ hiện "Xin chào, Admin")
                Properties.Settings.Default.Save(); // Bắt buộc gọi Save() để ghi vào ổ cứng
                // ============================================
                busNK.GhiNhatKy(txtTenDangNhap.Text, "Đăng nhập", "Đăng nhập thành công vào hệ thống");
                this.Hide();
                trangchu frm = new trangchu();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                // Đăng nhập sai hoặc tài khoản bị khóa
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng.\nHoặc tài khoản của bạn đã bị khóa!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Xóa mật khẩu cũ đi và nháy chuột lại vào ô mật khẩu cho người dùng nhập lại
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        // ==========================================
        // SỰ KIỆN: NHẤN NÚT THOÁT
        // ==========================================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ==========================================
        // SỰ KIỆN: BẤM ENTER ĐỂ ĐĂNG NHẬP NHANH
        // ==========================================
        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            // Nếu người dùng đang gõ mật khẩu mà bấm phím Enter trên bàn phím
            if (e.KeyCode == Keys.Enter)
            {
                // Mô phỏng lại việc click vào nút Đăng Nhập
                btnDangNhap_Click(sender, e);
            }
        }


    }
}