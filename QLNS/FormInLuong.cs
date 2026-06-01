using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // Bắt buộc có để dùng hàm .Where lọc danh sách
using System.Windows.Forms;
using ET;
using BUS;

namespace QLNS
{
    public partial class FormInLuong : Form
    {
        public FormInLuong()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form vừa mở lên
        private void FormInLuong_Load(object sender, EventArgs e)
        {
            // 1. Tự động load 12 tháng vào combobox
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }
            cboThang.SelectedItem = DateTime.Now.Month;
            txtNam.Value = DateTime.Now.Year;

            // 2. Tải danh sách nhân viên lên ComboBox
            LoadDanhSachNhanVien();
        }

        // Hàm tải danh sách nhân viên đơn giản nhất
        private void LoadDanhSachNhanVien()
        {
            try
            {
                BUS_NhanVien busNhanVien = new BUS_NhanVien();

                // Lấy thẳng danh sách thật từ tầng BUS
                var listNV = busNhanVien.LayDanhSachLenGrid();

                // Tạo 1 dòng giả để làm tùy chọn "In tất cả"
                ET_NhanVienView nvAll = new ET_NhanVienView();
                nvAll.MaNhanVien = "ALL";
                nvAll.HoTen = "--- In toàn bộ công ty ---";

                // Chèn lên đầu danh sách (vị trí số 0)
                listNV.Insert(0, nvAll);

                // Đổ vào ComboBox
                cboNhanVien.DataSource = listNV;
                cboNhanVien.DisplayMember = "hoTen";      // Chỉ hiện tên cho gọn
                cboNhanVien.ValueMember = "maNhanVien";   // Giữ lại Mã NV ở dưới để code xử lý
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi bấm nút Xem Phiếu Lương
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy các tham số người dùng đang chọn
                int thang = Convert.ToInt32(cboThang.SelectedItem);
                int nam = Convert.ToInt32(txtNam.Value);
                string maNVChon = cboNhanVien.SelectedValue?.ToString();

                // 1. Lấy dữ liệu lương từ DB (Thông qua tầng BUS)
                BUS_BangLuong bus = new BUS_BangLuong();
                List<ET_BangLuong> danhSachData = bus.LayDanhSachPhieuLuong(thang, nam);

                // Kiểm tra nếu tháng đó chưa tính lương
                if (danhSachData == null || danhSachData.Count == 0)
                {
                    MessageBox.Show($"Không có dữ liệu bảng lương cho Tháng {thang}/{nam}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    crystalReportViewer1.ReportSource = null;
                    return;
                }

                // 2. Lọc theo nhân viên (Nếu không chọn "In toàn bộ công ty")
                if (maNVChon != "ALL")
                {
                    danhSachData = danhSachData.Where(nv => nv.MaNhanVien == maNVChon).ToList();

                    // Nhỡ may nhân viên này tháng đó nghỉ không lương
                    if (danhSachData.Count == 0)
                    {
                        MessageBox.Show("Nhân viên này không có dữ liệu lương trong tháng được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        crystalReportViewer1.ReportSource = null;
                        return;
                    }
                }

                // 3. Đổ dữ liệu vào bản vẽ Crystal Report
                rbBangLuong rpt = new rbBangLuong();
                // 2. TRUYỀN GIÁ TRỊ VÀO 2 BIẾN ĐÃ TẠO
                rpt.DataDefinition.FormulaFields["pThang"].Text = "" + thang;
                rpt.DataDefinition.FormulaFields["pNam"].Text = "" + nam;
                rpt.SetDataSource(danhSachData);

                // 4. Hiển thị lên màn hình
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất báo cáo: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}