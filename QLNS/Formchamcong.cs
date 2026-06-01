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
using BUS;
using ET;

namespace QLNS
{
    public partial class Formchamcong : Form
    {

        public Formchamcong()
        {
            InitializeComponent();
        }
        #region 1.main
        BUS_NhanVien BUS_nhanvien = new BUS_NhanVien();
        Decimal SoGioOT = 0;
        BUS_ChamCong BUS_chamcong = new BUS_ChamCong();
        BUS_DuyetDonNghiPhep BUS_donNghiPhep = new BUS_DuyetDonNghiPhep();
        BUS_TaiKhoang BUS_taiKhoan = new BUS_TaiKhoang();
        BUS_HinhThucChamCong busht = new BUS_HinhThucChamCong();
        BUS_CaLam BUS_calam = new BUS_CaLam();
        string maQuyen = "";
        string maPhongBanDangNhap = "";
        bool isLoadChamCong = false;
        bool isLoadDulieuChamCong = false;
        bool isLoadDuyetNghiPhep = false;
        private void LoadDataForCurrentTab()
        {
            if (tabChamCong.SelectedIndex == 0 && !isLoadDulieuChamCong)
            {
                loadDuLieuChamCong();
                isLoadChamCong=false;
                isLoadDuyetNghiPhep=false;
                isLoadDulieuChamCong = true;


            }
            else if (tabChamCong.SelectedIndex == 1 && !isLoadDuyetNghiPhep)
            {
                loadDuyetNghiPhep();
                isLoadChamCong = false;
                isLoadDuyetNghiPhep = true;
                isLoadDulieuChamCong = false;

            }
            else if (tabChamCong.SelectedIndex == 2 && !isLoadChamCong)
            {
                loadcbotabchamcong();
                isLoadChamCong = true;
                isLoadDuyetNghiPhep = false;
                isLoadDulieuChamCong = false;
            }
        }
        private void Formchamcong_Load(object sender, EventArgs e)
        {
            // 1. Đọc Username từ Settings đã lưu lúc đăng nhập
            string user = Properties.Settings.Default.Username;

            // 2. Gọi DB để lấy cấp bậc và phòng ban
            var thongTinUser = BUS_taiKhoan.LayThongTinDangNhap(user);

            if (thongTinUser != null)
            {
                if (thongTinUser.MaNhomQuyen == "NQ_ADMIN")
                {
                    // Ngoại lệ cho Admin: Cấp toàn quyền
                    maQuyen = thongTinUser.MaNhomQuyen;
                    maPhongBanDangNhap = "ALL";
                }
                // Gán vào biến toàn cục của Form
                maQuyen = thongTinUser.MaNhomQuyen;
                maPhongBanDangNhap = thongTinUser.MaPhongBan; // Ví dụ: 'PB_IT'
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiên đăng nhập! Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Hoặc đẩy về Form Đăng nhập
                return;
            }
            LoadDataForCurrentTab();
        }

        private void tabChamCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForCurrentTab();
        }
        #endregion
        #region 2. Dữ Liệu chấm công
        private void loadDuLieuChamCong() 
        {
            dgvChamCong.DataSource = BUS_chamcong.LayDanhSachLenGrid();

        }

        #endregion

        #region 3. Duyệt đơn Nghỉ Phép
        private void loadDuyetNghiPhep()
        {
            // Tạm ngắt sự kiện để không bị lỗi khi đang gán DataSource
            cbodoncanduyet.SelectedIndexChanged -= cbodoncanduyet_SelectedIndexChanged;

            // Lấy danh sách các đơn "Chờ duyệt" từ Database (thông qua BUS)
            var dsChoDuyet = BUS_donNghiPhep.LayDanhSachDonChoDuyet(maQuyen, maPhongBanDangNhap);

            cbodoncanduyet.DataSource = dsChoDuyet;
            cbodoncanduyet.DisplayMember = "MaDon"; // Hiển thị Mã đơn lên ComboBox
            cbodoncanduyet.ValueMember = "MaDon";   // Giá trị ngầm định mang theo
            cbodoncanduyet.SelectedIndex = -1;      // Để trống ComboBox lúc mới load

            // Làm trống DataGridView lúc ban đầu
            dgvNghiPhep.DataSource = null;

            // Bật lại sự kiện
            cbodoncanduyet.SelectedIndexChanged += cbodoncanduyet_SelectedIndexChanged;
        }

        // 2. Sự kiện nhấn chọn ComboBox -> Đổ dữ liệu của đơn đó xuống DataGridView
        private void cbodoncanduyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbodoncanduyet.SelectedIndex != -1 && cbodoncanduyet.SelectedValue != null)
            {
                string maDonDuocChon = cbodoncanduyet.SelectedValue.ToString();

                // Lấy lại danh sách chờ duyệt và lọc ra đúng cái đơn đang được chọn
                var donChiTiet = BUS_donNghiPhep.LayDanhSachDonChoDuyet(maQuyen, maPhongBanDangNhap)
                                                .Where(d => d.MaDon == maDonDuocChon)
                                                .ToList();

                // Đổ đích danh đơn đó xuống DataGridView
                dgvNghiPhep.DataSource = donChiTiet;
            }
        }
        // Sự kiện nhấn nút PHÊ DUYỆT ĐƠN
        private void btnDuyetDon_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhep.CurrentRow != null)
            {
                string maDon = dgvNghiPhep.CurrentRow.Cells["MaDon"].Value.ToString();

                // Gọi hàm DAL/BUS để update thành "Đã duyệt"
                if (BUS_donNghiPhep.DuyetDon(maDon,true))
                {
                    MessageBox.Show("Đã phê duyệt đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xử lý xong thì tải lại để đơn vừa duyệt biến mất khỏi danh sách chờ
                    loadDuyetNghiPhep();
                }
                else
                {
                    MessageBox.Show("Duyệt đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn từ danh sách để duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLocNP_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa từ ô tìm kiếm
            string tuKhoa = txtkey.Text.Trim();

            // Tạm ngắt sự kiện để không bị lỗi lúc gán dữ liệu mới
            cbodoncanduyet.SelectedIndexChanged -= cbodoncanduyet_SelectedIndexChanged;

            // Gọi hàm BUS đã có sẵn của bạn để tìm kiếm xuống thẳng Database
            var dsDaLoc = BUS_donNghiPhep.TimKiemDonChoDuyet(maQuyen, maPhongBanDangNhap, tuKhoa);

            // Đổ danh sách kết quả vào ComboBox
            cbodoncanduyet.DataSource = dsDaLoc;
            cbodoncanduyet.DisplayMember = "MaDon";
            cbodoncanduyet.ValueMember = "MaDon";

            // Reset lại lựa chọn về rỗng
            cbodoncanduyet.SelectedIndex = -1;

            // Làm trắng DataGridView vì danh sách đã bị thay đổi, sếp chưa chọn đơn cụ thể
            dgvNghiPhep.DataSource = null;

            // Bật lại sự kiện
            cbodoncanduyet.SelectedIndexChanged += cbodoncanduyet_SelectedIndexChanged;

            // Thông báo nếu danh sách trả về rỗng (không tìm thấy)
            if (dsDaLoc.Count == 0 && !string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Không tìm thấy đơn chờ duyệt nào khớp với từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion
        #region 4. Chấm Công
        private void loadcbotabchamcong() 
        {
            cboNhanVien.DataSource = BUS_nhanvien.LayDanhSachLenGrid();
            cboNhanVien.DisplayMember= "HoTenHoTen";
            cboNhanVien.ValueMember= "MaNhanVien";

            cboHinhThuc.DataSource = busht.LayDanhSachChamCong();
            cboHinhThuc.DisplayMember = "tenHinhThuc";
            cboHinhThuc.ValueMember = "maHinhThuc";

            cboCaLam.DataSource=BUS_calam.LayDanhSachCaLam();
            cboCaLam.ValueMember = "maCa";
            cboCaLam.DisplayMember = "tenCa";
        }
        private ET_ChamCong et_cc() => new ET_ChamCong
        {
            ID =null,
            MaNhanVien = cboNhanVien.SelectedValue?.ToString(),
            NgayChamCong = DateTime.Today,
            MaCa = cboCaLam.SelectedValue?.ToString(),
            GioVao = DateTime.Now.TimeOfDay,
            GioRa =null,
            SoGioOT = SoGioOT,
            MaHinhThuc = cboHinhThuc.SelectedValue?.ToString(),
            TrangThai = "DangLam"
        };
        private void btnthem_Click(object sender, EventArgs e)
        {
            ET_ChamCong eT_ChamCong = BUS_chamcong.check(cboNhanVien.SelectedValue.ToString());
            if (eT_ChamCong!=null)
            {
        TimeSpan giora = DateTime.Now.TimeOfDay;

                eT_ChamCong.GioRa = giora;
                TimeSpan thoiGianLam = giora - eT_ChamCong.GioVao.Value;
                eT_ChamCong.SoGioOT = Convert.ToDecimal(thoiGianLam.TotalHours);
                eT_ChamCong.TrangThai = "đã Ra";
                BUS_chamcong.SuaChamCong(eT_ChamCong);
                MessageBox.Show("đã sửa");
            }
            else
            {
                BUS_chamcong.ThemChamcong(et_cc());
            }
        }


        


        private void btnLocCC_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu và làm sạch khoảng trắng dư thừa
            string maNV = txtTimNV.Text.Trim();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            // 2. CHỐT CHẶN 1: Kiểm tra xem người dùng có để trống ô nhập mã không
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimNV.Focus(); // Trỏ chuột lại vào ô nhập liệu
                return;
            }

            // 3. CHỐT CHẶN 2: Kiểm tra logic ngày tháng
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 5. Đổ dữ liệu vào lưới DataGridView
            if (maNV == null)
            {
                dgvChamCong.DataSource = BUS_chamcong.LayDanhSachLenGrid();
            }
            else { dgvChamCong.DataSource = BUS_chamcong.LocDataChamCong(maNV, tuNgay, denNgay); }
            #endregion

        }

        private void btnTuChoiDon_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhep.CurrentRow != null)
            {
                string maDon = dgvNghiPhep.CurrentRow.Cells["MaDon"].Value.ToString();

                // Gọi hàm DAL/BUS để update thành "Đã duyệt"
                if (BUS_donNghiPhep.DuyetDon(maDon, false))
                {
                    MessageBox.Show("Đã từ chối đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xử lý xong thì tải lại để đơn vừa duyệt biến mất khỏi danh sách chờ
                    loadDuyetNghiPhep();
                }
                else
                {
                    MessageBox.Show("từ chối đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn từ danh sách để duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
