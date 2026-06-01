using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ET;  // Nhớ using tầng Entity
using BUS;
using BUS;
using ClassLibrary3; // Nhớ using tầng BUS

namespace QLNS
{
    public partial class Caidatquyen : Form
    {
        // Khởi tạo đối tượng BUS để giao tiếp với CSDL
        BUS_Phanquyen busPQ = new BUS_Phanquyen();

        private string maNhomDuocChon = "";
        private string tenNhomDuocChon = "";

        // Thay thế DataTable bằng List Object (Mô hình 3 lớp)
        private List<ET_Phanquyen> lstQuyenTong;

        private string maMenuDangChon = "";
        private string maChucNangDangChon = "";

        public Caidatquyen(string maNhom, string tenNhom)
        {
            InitializeComponent();
            this.maNhomDuocChon = maNhom;
            this.tenNhomDuocChon = tenNhom;
            this.Text = "Cài đặt quyền - Nhóm: " + tenNhom;

            // Nối các sự kiện tự động bằng code để lưới Checkbox cực nhạy
            this.dgvMenu.CurrentCellDirtyStateChanged += DgvMenu_CurrentCellDirtyStateChanged;
            this.dgvMenu.CellValueChanged += DgvMenu_CellValueChanged;

            this.dgvChucNangCon.CurrentCellDirtyStateChanged += DgvChucNangCon_CurrentCellDirtyStateChanged;
            this.dgvChucNangCon.CellValueChanged += DgvChucNangCon_CellValueChanged;
        }

        private void Caidatquyen_Load(object sender, EventArgs e)
        {
            lblNhomQuyen.Text = "Đang phân quyền cho nhóm: " + tenNhomDuocChon.ToUpper();
            LoadDuLieuVaoBoNhoTam();
        }

        // ========================================================
        // 1. TẢI DỮ LIỆU & HIỂN THỊ DGV MENU BẰNG LINQ & BUS
        // ========================================================
        private void LoadDuLieuVaoBoNhoTam()
        {
            try
            {
                // Gọi tầng BUS để lấy dữ liệu thay vì viết câu SQL ở đây
                lstQuyenTong = busPQ.LayMaTranQuyen(maNhomDuocChon);

                // Dùng LINQ lọc ra các Menu (MaChucNangCha bị NULL hoặc rỗng)
                var lstMenu = lstQuyenTong.Where(x => string.IsNullOrEmpty(x.MaChucNangCha)).ToList();

                // Ép sang BindingList để DataGridView hỗ trợ click Checkbox mượt hơn
                dgvMenu.DataSource = new BindingList<ET_Phanquyen>(lstMenu);

                dgvMenu.Columns["MaChucNang"].Visible = false;
                dgvMenu.Columns["MaChucNangCha"].Visible = false;
                dgvMenu.Columns["QuyenThem"].Visible = false;
                dgvMenu.Columns["QuyenSua"].Visible = false;
                dgvMenu.Columns["QuyenXoa"].Visible = false;

                dgvMenu.Columns["TenChucNang"].HeaderText = "1. Menu Chính";
                dgvMenu.Columns["TenChucNang"].ReadOnly = true;
                dgvMenu.Columns["QuyenXem"].HeaderText = "Được Xem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu quyền: " + ex.Message);
            }
        }

        // ========================================================
        // 2. XỬ LÝ LƯỚI MENU (DGV 1)
        // ========================================================
        private void DgvMenu_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMenu.IsCurrentCellDirty) dgvMenu.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvMenu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maMenu = dgvMenu.Rows[e.RowIndex].Cells["MaChucNang"].Value.ToString();
                bool isChecked = Convert.ToBoolean(dgvMenu.Rows[e.RowIndex].Cells["QuyenXem"].Value);

                // Cập nhật giá trị vào List tổng (LINQ)
                var obj = lstQuyenTong.FirstOrDefault(x => x.MaChucNang == maMenu);
                if (obj != null) obj.QuyenXem = isChecked;

                // NẾU TÍCH THÌ MỚI HIỆN LƯỚI 2, BỎ TÍCH THÌ DỌN SẠCH
                if (isChecked && maMenuDangChon == maMenu)
                    HienThiChucNangCon(maMenu);
                else
                {
                    dgvChucNangCon.DataSource = null;
                    dgvThaoTac.DataSource = null;
                }
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvMenu.ClearSelection();
                dgvMenu.Rows[e.RowIndex].Selected = true;

                maMenuDangChon = dgvMenu.Rows[e.RowIndex].Cells["MaChucNang"].Value.ToString();
                bool isChecked = Convert.ToBoolean(dgvMenu.Rows[e.RowIndex].Cells["QuyenXem"].Value);

                if (isChecked) HienThiChucNangCon(maMenuDangChon);
                else
                {
                    dgvChucNangCon.DataSource = null;
                    dgvThaoTac.DataSource = null;
                }
            }
        }

        private void HienThiChucNangCon(string maMenu)
        {
            // Dùng LINQ lọc ra các chức năng con của Menu đang chọn
            var lstCon = lstQuyenTong.Where(x => x.MaChucNangCha == maMenu).ToList();
            dgvChucNangCon.DataSource = new BindingList<ET_Phanquyen>(lstCon);

            dgvChucNangCon.Columns["MaChucNang"].Visible = false;
            dgvChucNangCon.Columns["MaChucNangCha"].Visible = false;
            dgvChucNangCon.Columns["QuyenThem"].Visible = false;
            dgvChucNangCon.Columns["QuyenSua"].Visible = false;
            dgvChucNangCon.Columns["QuyenXoa"].Visible = false;

            dgvChucNangCon.Columns["TenChucNang"].HeaderText = "2. Chức Năng Con";
            dgvChucNangCon.Columns["TenChucNang"].ReadOnly = true;
            dgvChucNangCon.Columns["QuyenXem"].HeaderText = "Được Xem";

            dgvThaoTac.DataSource = null;
        }

        // ========================================================
        // 3. XỬ LÝ LƯỚI CHỨC NĂNG CON (DGV 2)
        // ========================================================
        private void DgvChucNangCon_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChucNangCon.IsCurrentCellDirty) dgvChucNangCon.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvChucNangCon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maChucNang = dgvChucNangCon.Rows[e.RowIndex].Cells["MaChucNang"].Value.ToString();
                bool isChecked = Convert.ToBoolean(dgvChucNangCon.Rows[e.RowIndex].Cells["QuyenXem"].Value);

                // Cập nhật giá trị vào List tổng (LINQ)
                var obj = lstQuyenTong.FirstOrDefault(x => x.MaChucNang == maChucNang);
                if (obj != null) obj.QuyenXem = isChecked;

                // NẾU TÍCH THÌ MỚI HIỆN LƯỚI 3, BỎ TÍCH THÌ DỌN SẠCH
                if (isChecked && maChucNangDangChon == maChucNang)
                    HienThiThaoTac(maChucNang);
                else
                    dgvThaoTac.DataSource = null;
            }
        }

        private void dgvChucNangCon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvChucNangCon.ClearSelection();
                dgvChucNangCon.Rows[e.RowIndex].Selected = true;

                maChucNangDangChon = dgvChucNangCon.Rows[e.RowIndex].Cells["MaChucNang"].Value.ToString();
                bool isChecked = Convert.ToBoolean(dgvChucNangCon.Rows[e.RowIndex].Cells["QuyenXem"].Value);

                if (isChecked) HienThiThaoTac(maChucNangDangChon);
                else dgvThaoTac.DataSource = null;
            }
        }

        // Lớp trung gian siêu nhẹ để tạo DataGridView số 3
        class ThaoTacUI
        {
            public string TenThaoTac { get; set; }
            public bool ChoPhep { get; set; }
            public string ThuocTinhCode { get; set; }
        }

        private void HienThiThaoTac(string maChucNang)
        {
            var obj = lstQuyenTong.FirstOrDefault(x => x.MaChucNang == maChucNang);
            if (obj != null)
            {
                List<ThaoTacUI> lstThaoTac = new List<ThaoTacUI>
                {
                    new ThaoTacUI { TenThaoTac = "Quyền Thêm", ChoPhep = obj.QuyenThem, ThuocTinhCode = "Them" },
                    new ThaoTacUI { TenThaoTac = "Quyền Sửa", ChoPhep = obj.QuyenSua, ThuocTinhCode = "Sua" },
                    new ThaoTacUI { TenThaoTac = "Quyền Xóa", ChoPhep = obj.QuyenXoa, ThuocTinhCode = "Xoa" }
                };

                dgvThaoTac.DataSource = new BindingList<ThaoTacUI>(lstThaoTac);

                dgvThaoTac.Columns["ThuocTinhCode"].Visible = false; // Ẩn key
                dgvThaoTac.Columns["TenThaoTac"].HeaderText = "3. Thao Tác Chi Tiết";
                dgvThaoTac.Columns["TenThaoTac"].ReadOnly = true;
                dgvThaoTac.Columns["ChoPhep"].HeaderText = "Được Phép";
            }
        }

        // ========================================================
        // 4. XỬ LÝ LƯỚI THAO TÁC (DGV 3)
        // ========================================================
        private void dgvThaoTac_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvThaoTac.IsCurrentCellDirty) dgvThaoTac.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvThaoTac_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(maChucNangDangChon))
            {
                string key = dgvThaoTac.Rows[e.RowIndex].Cells["ThuocTinhCode"].Value.ToString();
                bool isChecked = Convert.ToBoolean(dgvThaoTac.Rows[e.RowIndex].Cells["ChoPhep"].Value);

                var obj = lstQuyenTong.FirstOrDefault(x => x.MaChucNang == maChucNangDangChon);
                if (obj != null)
                {
                    if (key == "Them") obj.QuyenThem = isChecked;
                    if (key == "Sua") obj.QuyenSua = isChecked;
                    if (key == "Xoa") obj.QuyenXoa = isChecked;
                }
            }
        }

        // ========================================================
        // 5. LƯU TẤT CẢ XUỐNG DATABASE THÔNG QUA LỚP BUS
        // ========================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Truyền toàn bộ List dữ liệu xuống tầng BUS để lưu
            bool ketQua = busPQ.LuuMaTranQuyen(maNhomDuocChon, lstQuyenTong);

            if (ketQua)
            {
                MessageBox.Show("Lưu ma trận phân quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu phân quyền! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}