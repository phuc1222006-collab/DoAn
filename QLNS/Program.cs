using System;
using System.Configuration; // Bắt buộc phải có
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. TÌM CHÍNH XÁC CHUỖI KẾT NỐI TỪ APP.CONFIG
            string configName = "ClassLibrary2.Properties.Settings.QuanLyNhanSuConnectionString";
            string connString = "";

            if (ConfigurationManager.ConnectionStrings[configName] != null)
            {
                connString = ConfigurationManager.ConnectionStrings[configName].ConnectionString;
            }

            // 2. TEST KẾT NỐI NGẦM XEM DB CÓ SỐNG KHÔNG
            bool isConnected = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    isConnected = true; // Kết nối thành công!
                }
            }
            catch { } // Lỗi thì mặc kệ, biến isConnected vẫn là false

            // 3. QUYẾT ĐỊNH ĐIỀU HƯỚNG MỞ FORM
            if (!isConnected)
            {
                // Thất bại (Do đem qua máy khác, sai tên máy) -> Mở Form Cài Đặt
                Application.Run(new FormCaiDatDB(configName));
            }
            else
            {
                // Thành công -> Chạy luồng Đăng nhập bình thường
                if (Properties.Settings.Default.IsRemembered)
                {
                    Application.Run(new trangchu()); // Đã lưu trí nhớ -> Vào thẳng hệ thống
                }
                else
                {
                    Application.Run(new FormDangNhap()); // Chưa đăng nhập -> Vào form đăng nhập
                }
            }
        }
    }
}