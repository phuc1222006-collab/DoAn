using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using BUS;
using BUS;
namespace QLNS
{
    public class TienIch
    {
        // 1. Thêm chữ "static" vào đây để hàm bên dưới có thể nhìn thấy nó
        Bus_NhatKy bNK = new Bus_NhatKy();

        public void GanSuKienGhiLogChoMoiNut(Control parentControl)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button || ctrl is Button)
                {
                    if (ctrl.Tag != null && ctrl.Tag.ToString() == "GhiLog")
                    {
                        ctrl.Click += (sender, e) =>
                        {
                            string tenNut = !string.IsNullOrWhiteSpace(ctrl.Text) ? ctrl.Text.Trim() : ctrl.Name;
                            string user = Properties.Settings.Default.Username;

                            // 2. Gọi trực tiếp biến bNK đã khai báo ở trên, không cần chữ "new" nữa
                            bNK.GhiNhatKy(user, "Thao tác dữ liệu", "Đã bấm: " + tenNut);
                        };
                    }
                }

                if (ctrl.HasChildren)
                {
                    GanSuKienGhiLogChoMoiNut(ctrl);
                }
            }
        }
    }
}
