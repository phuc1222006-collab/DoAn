USE QuanLyNhanSu;
GO

-- =====================================================================
-- SCRIPT ĐỘC LẬP: CẤU HÌNH NHÓM QUYỀN ADMIN & DANH MỤC CHỨC NĂNG
-- =====================================================================

-- ---------------------------------------------------------------------
-- BƯỚC 1 & 2 & 3: KHỞI TẠO TÀI KHOẢN ADMIN (FULL QUYỀN)
-- ---------------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_ADMIN')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) VALUES ('NQ_ADMIN', N'Administrator', N'Toàn quyền quản trị');

IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV_ADMIN_ROOT')
    INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, NgaySinh, MaPhongBan, MaChucDanh, TrangThaiLamViec) VALUES ('NV_ADMIN_ROOT', N'Quản Trị Viên Tối Cao', N'Nam', '1999-01-01', NULL, NULL, N'Đang làm việc');

IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'admin')
    INSERT INTO TaiKhoan (TenDangNhap, MaNhanVien, MatKhau, MaNhomQuyen, TrangThaiHoatDong) VALUES ('admin', 'NV_ADMIN_ROOT', '123456', 'NQ_ADMIN', 1);
GO


-- ---------------------------------------------------------------------
-- BƯỚC 4: ĐỒNG BỘ DANH SÁCH CÁC CHỨC NĂNG (GOM NHÓM CHA - CON)
-- ---------------------------------------------------------------------

-- 🌟 CẤP 1: CÁC MENU ROOT (Cha = NULL)
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'MENU_NHANSU')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('MENU_NHANSU', N'Quản lý nhân sự', 'rbNhanSu', N'Menu Ribbon Quản lý nhân sự', NULL);
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'MENU_CHAMCONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('MENU_CHAMCONG', N'Chấm công/Tài chính', 'rbChamCong', N'Menu Ribbon Chấm công', NULL);
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'MENU_HETHONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('MENU_HETHONG', N'Hệ thống', 'rbHeThong', N'Menu Ribbon Hệ thống', NULL);


-- =====================================================================
-- 📂 NHÓM 1: THUỘC MENU QUẢN LÝ NHÂN SỰ (Cha = MENU_NHANSU)
-- =====================================================================

    -- 🔹 1.1 FORM: HỒ SƠ NHÂN VIÊN
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_HOSONV')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_HOSONV', N'Hồ sơ nhân viên', 'frmHoSoNhanVien', N'Form Hồ sơ', 'MENU_NHANSU');
        
        -- Các Tab nằm trong Form Hồ Sơ:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HS_DAOTAO')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HS_DAOTAO', N'Đào tạo', 'tabDaoTao', N'Tab Đào tạo', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HS_NGHIVIEC')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HS_NGHIVIEC', N'Nghỉ Việc', 'tabNghiViecHS', N'Tab Nghỉ việc', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HS_HOPDONG')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HS_HOPDONG', N'Hợp đồng LĐ', 'tabHopDong', N'Tab Hợp đồng', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HS_BHXH')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HS_BHXH', N'BHXH', 'tabBHXH', N'Tab BHXH', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HS_GIAMTRU')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HS_GIAMTRU', N'Giảm trừ GC', 'tabGiamTru', N'Tab Giảm trừ', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HS_TAISAN')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HS_TAISAN', N'Tài sản cấp phát', 'tabTaiSan', N'Tab Tài sản', 'MENU_NHANSU');

    -- 🔹 1.2 FORM: HÀNH CHÍNH
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_HANHCHINH')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_HANHCHINH', N'Hành Chính', 'frmhanhchinh', N'Form Hành chính', 'MENU_NHANSU');
        
        -- Các Tab nằm trong Form Hành Chính:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HC_CONGTAC')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HC_CONGTAC', N'Hồ Sơ Cộng Tác', 'tabCongTac', N'Tab Công tác', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HC_NGHIVIEC')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HC_NGHIVIEC', N'Nghỉ việc', 'tabNghiViecHC', N'Tab Nghỉ việc (HC)', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_HC_XINNGHI')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_HC_XINNGHI', N'Xin nghỉ phép', 'tabXinNghi', N'Tab Xin nghỉ phép', 'MENU_NHANSU');

    -- 🔹 1.3 FORM: TUYỂN DỤNG
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_TUYENDUNG')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_TUYENDUNG', N'Tuyển dụng', 'frmTuyenDung', N'Form Tuyển dụng', 'MENU_NHANSU');
        
        -- Các Tab nằm trong Form Tuyển Dụng:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TD_KEHOACH')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_TD_KEHOACH', N'Kế Hoạch Tuyển Dụng', 'tabKeHoachTD', N'Tab Kế hoạch', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TD_HOSO')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_TD_HOSO', N'Hồ Sơ Ứng Viên', 'tabHoSoUngVien', N'Tab Hồ sơ', 'MENU_NHANSU');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TD_PHONGVAN')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_TD_PHONGVAN', N'Lịch Phỏng Vấn', 'tabLichPhongVan', N'Tab Phỏng vấn', 'MENU_NHANSU');


-- =====================================================================
-- 📂 NHÓM 2: THUỘC MENU CHẤM CÔNG & TÀI CHÍNH (Cha = MENU_CHAMCONG)
-- =====================================================================

    -- 🔹 2.1 FORM: CHẤM CÔNG & ĐƠN TỪ
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_CHAMCONG')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_CHAMCONG', N'Chấm công & Đơn từ', 'frmChamCong', N'Form Chấm công', 'MENU_CHAMCONG');
        
        -- Các Tab nằm trong Form Chấm Công:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_CC_DULIEU')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_CC_DULIEU', N'Bảng Dữ Liệu Chấm Công', 'tabDuLieuChamCong', N'Tab Dữ liệu', 'MENU_CHAMCONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_CC_DUYETNGHI')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_CC_DUYETNGHI', N'Duyệt Đơn Nghỉ Phép', 'tabDuyetNghiPhep', N'Tab Duyệt đơn', 'MENU_CHAMCONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_CC_CHITIET')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_CC_CHITIET', N'Chấm Công Chi Tiết', 'tabChamCongChiTiet', N'Tab Chấm công CT', 'MENU_CHAMCONG');

    -- 🔹 2.2 FORM: TẠM ỨNG & KHEN THƯỞNG
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_TAMUNG_THUONG')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_TAMUNG_THUONG', N'Tạm ứng & Khen thưởng', 'frmTamUngKhenThuong', N'Form Tạm ứng', 'MENU_CHAMCONG');
        
        -- Các Tab nằm trong Form Tạm Ứng/Khen Thưởng:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TAMUNG')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_TAMUNG', N'Quản Lý Tạm Ứng', 'tabTamUng', N'Tab Tạm ứng', 'MENU_CHAMCONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_KHENTHUONG')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_KHENTHUONG', N'Khen Thưởng / Kỷ Luật', 'tabKhenThuong', N'Tab Khen thưởng', 'MENU_CHAMCONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_PHUCAPNV')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_PHUCAPNV', N'Phụ Cấp Nhân Viên', 'tabPhuCapNV', N'Tab Phụ cấp NV', 'MENU_CHAMCONG');

    -- 🔹 2.3 FORM: IN LƯƠNG
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_InLuong')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_InLuong', N'In Lương', 'frminLuong', N'Form In Lương', 'MENU_CHAMCONG');


-- =====================================================================
-- 📂 NHÓM 3: THUỘC MENU HỆ THỐNG (Cha = MENU_HETHONG)
-- =====================================================================

    -- 🔹 3.1 FORM: DANH MỤC HỆ THỐNG
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_DANHMUC')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_DANHMUC', N'Danh mục hệ thống', 'frmDanhMuc', N'Form Danh mục', 'MENU_HETHONG');
        
        -- Các Tab nằm trong Form Danh Mục:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_CHINHANH')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_DM_CHINHANH', N'Cơ sở / Chi nhánh', 'tabDMChiNhanh', N'Tab Chi nhánh', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_PHONGBAN')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_DM_PHONGBAN', N'Cơ Cấu Phòng Ban', 'tabDMPhongBan', N'Tab Phòng ban', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_CHUCDANH')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_DM_CHUCDANH', N'Chức Danh', 'tabDMChucDanh', N'Tab Chức danh', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_CALAMVIEC')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_DM_CALAMVIEC', N'Ca Làm Việc', 'tabDMCaLamViec', N'Tab Ca làm việc', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_LOAICHAMCONG')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_DM_LOAICHAMCONG', N'Loại Chấm Công', 'tabDMLoaiChamCong', N'Tab Loại CC', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_PHUCAP')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_DM_PHUCAP', N'Danh Mục Phụ Cấp', 'tabDMPhuCap', N'Tab DM Phụ cấp', 'MENU_HETHONG');

    -- 🔹 3.2 FORM: TÀI KHOẢN & PHÂN QUYỀN
    IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_TAIKHOAN_PQ')
        INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('CN_TAIKHOAN_PQ', N'Tài khoản & Phân quyền', 'Formhethong', N'Form Tài khoản PQ', 'MENU_HETHONG');
        
        -- Các Tab nằm trong Form Tài Khoản & Phân Quyền:
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TAIKHOAN')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_TAIKHOAN', N'Quản Lý Tài Khoản', 'tabTaiKhoan', N'Tab Tài khoản', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_NHOMQUYEN')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_NHOMQUYEN', N'Nhóm Quyền Hệ Thống', 'tabNhomQuyen', N'Tab Nhóm quyền', 'MENU_HETHONG');
        IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_NHATKY')
            INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha) VALUES ('TAB_NHATKY', N'Nhật Ký Hệ Thống', 'tabNhatKy', N'Tab Nhật ký', 'MENU_HETHONG');
GO


-- ---------------------------------------------------------------------
-- BƯỚC 5: CẤP QUYỀN TOÀN TẬP CHO ADMIN TRÊN TOÀN BỘ CHỨC NĂNG VỪA TẠO
-- ---------------------------------------------------------------------
DELETE FROM PhanQuyen WHERE MaNhomQuyen = 'NQ_ADMIN';

INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_ADMIN', MaChucNang, 1, 1, 1, 1 
FROM ChucNang;
GO