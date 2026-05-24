using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QLNS
{
    public partial class FormCaiDatDB : Form
    {
            string currentConfigName = "";

            public FormCaiDatDB(string configName)
            {
                InitializeComponent();
                currentConfigName = configName;

                // Điền sẵn tên máy tính hiện tại vào cho nhanh
                cboServer.Text = Environment.MachineName + "\\SQLEXPRESS";
            }

            private void chkWinAuth_CheckedChanged(object sender, EventArgs e)
            {
                txtUser.Enabled = !chkWinAuth.Checked;
                txtPass.Enabled = !chkWinAuth.Checked;
            }

            // =========================================================
            // TỰ ĐỘNG TÌM SQL SERVER TRÊN MÁY KHI BẤM XỔ XUỐNG
            // =========================================================
            private void cboServer_DropDown(object sender, EventArgs e)
            {
                // Nếu đã quét rồi thì không quét lại nữa để tránh lag
                if (cboServer.Items.Count > 0) return;

                Cursor.Current = Cursors.WaitCursor; // Hiển thị chuột xoay xoay báo hiệu đang load
                try
                {
                    // 1. Nạp nhanh các tên Server phổ biến ở máy cục bộ
                    string localMachine = Environment.MachineName;
                    cboServer.Items.Add(localMachine);                 // VD: DESKTOP-ABC
                    cboServer.Items.Add(localMachine + "\\SQLEXPRESS"); // VD: DESKTOP-ABC\SQLEXPRESS
                    cboServer.Items.Add(".\\SQLEXPRESS");
                    cboServer.Items.Add("(local)");

                    // 2. Chạy hàm quét sâu của Windows (Sẽ mất khoảng 2-5 giây)
                    DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
                    foreach (DataRow row in dt.Rows)
                    {
                        string serverName = row["ServerName"].ToString();
                        string instanceName = row["InstanceName"].ToString();

                        // Ghép tên (Nếu có Instance thì thêm dấu \, không thì thôi)
                        string fullName = string.IsNullOrEmpty(instanceName) ? serverName : serverName + "\\" + instanceName;

                        // Nếu trong danh sách chưa có thì mới thêm vào
                        if (!cboServer.Items.Contains(fullName))
                        {
                            cboServer.Items.Add(fullName);
                        }
                    }
                }
                catch { }
                Cursor.Current = Cursors.Default;
            }

            // =========================================================
            // TỰ ĐỘNG TÌM DATABASE KHI ĐÃ CÓ TÊN SERVER
            // =========================================================
            private void cboDatabase_DropDown(object sender, EventArgs e)
            {
                // Đổi từ txtServer sang cboServer
                string server = cboServer.Text.Trim();

                if (string.IsNullOrWhiteSpace(server))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Tên Server trước!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string masterConnStr = chkWinAuth.Checked
                    ? $"Server={server};Database=master;Integrated Security=True;TrustServerCertificate=True"
                    : $"Server={server};Database=master;User Id={txtUser.Text};Password={txtPass.Text};TrustServerCertificate=True";

                try
                {
                    cboDatabase.Items.Clear();
                    using (SqlConnection conn = new SqlConnection(masterConnStr))
                    {
                        conn.Open();
                        string query = "SELECT name FROM sys.databases WHERE database_id > 4";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cboDatabase.Items.Add(reader["name"].ToString());
                                }
                            }
                        }
                    }

                    if (cboDatabase.Items.Count > 0)
                    {
                        int index = cboDatabase.FindStringExact("QuanLyNhanSu");
                        if (index >= 0) cboDatabase.SelectedIndex = index;
                    }
                    else
                    {
                        cboDatabase.Items.Add("Không có Database nào hợp lệ!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối đến Server để lấy danh sách Database.\nChi tiết: " + ex.Message, "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // =========================================================
            // KIỂM TRA VÀ LƯU
            // =========================================================
            private void btnLuu_Click(object sender, EventArgs e)
            {
                string server = cboServer.Text.Trim(); // Lấy từ ComboBox
                string db = cboDatabase.SelectedItem?.ToString() ?? cboDatabase.Text.Trim();
                string newConnString = "";

                if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(db))
                {
                    MessageBox.Show("Vui lòng chọn Tên Server và Database!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chkWinAuth.Checked)
                    newConnString = $"Data Source={server};Initial Catalog={db};Integrated Security=True;TrustServerCertificate=True";
                else
                    newConnString = $"Data Source={server};Initial Catalog={db};User Id={txtUser.Text};Password={txtPass.Text};TrustServerCertificate=True";

                try
                {
                    using (SqlConnection conn = new SqlConnection(newConnString))
                    {
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối thất bại! Vui lòng kiểm tra lại.\n\nLỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings[currentConfigName].ConnectionString = newConnString;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");

                    MessageBox.Show("Đã lưu kết nối thành công! Phần mềm sẽ tự động khởi động lại.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ghi file cấu hình: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnThoat_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

        }
}
