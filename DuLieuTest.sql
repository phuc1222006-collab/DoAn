USE QuanLyNhanSu;
GO

-- =====================================================================
-- BƯỚC 1: TẠO DANH MỤC CHỨC DANH
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM ChucDanh WHERE MaChucDanh = 'CD_GD')
    INSERT INTO ChucDanh (MaChucDanh, TenChucDanh, CapBac) VALUES ('CD_GD', N'Giám đốc', N'Quản lý cấp cao');

IF NOT EXISTS (SELECT 1 FROM ChucDanh WHERE MaChucDanh = 'CD_TP')
    INSERT INTO ChucDanh (MaChucDanh, TenChucDanh, CapBac) VALUES ('CD_TP', N'Trưởng phòng', N'Quản lý');

IF NOT EXISTS (SELECT 1 FROM ChucDanh WHERE MaChucDanh = 'CD_NV')
    INSERT INTO ChucDanh (MaChucDanh, TenChucDanh, CapBac) VALUES ('CD_NV', N'Nhân viên', N'Nhân viên');
GO

-- =====================================================================
-- BƯỚC 2: TẠO 2 CHI NHÁNH
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM ChiNhanh WHERE MaChiNhanh = 'CN_HN')
    INSERT INTO ChiNhanh (MaChiNhanh, TenChiNhanh, DiaChi, Hotline) 
    VALUES ('CN_HN', N'Chi nhánh Hà Nội', N'Tòa nhà A, Đống Đa, Hà Nội', '0241000000');

IF NOT EXISTS (SELECT 1 FROM ChiNhanh WHERE MaChiNhanh = 'CN_HCM')
    INSERT INTO ChiNhanh (MaChiNhanh, TenChiNhanh, DiaChi, Hotline) 
    VALUES ('CN_HCM', N'Chi nhánh Hồ Chí Minh', N'Tòa nhà B, Quận 1, TP.HCM', '0281000000');
GO

-- =====================================================================
-- BƯỚC 3: TẠO 10 PHÒNG BAN (Để NULL MaTruongPhong tạm thời)
-- =====================================================================
-- 5 Phòng ban Chi nhánh Hà Nội
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HN_KD')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HN_KD', 'CN_HN', N'Phòng Kinh Doanh HN');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HN_KT')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HN_KT', 'CN_HN', N'Phòng Kế Toán HN');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HN_NS')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HN_NS', 'CN_HN', N'Phòng Nhân Sự HN');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HN_IT')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HN_IT', 'CN_HN', N'Phòng Công Nghệ HN');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HN_MKT')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HN_MKT', 'CN_HN', N'Phòng Marketing HN');

-- 5 Phòng ban Chi nhánh Hồ Chí Minh
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HCM_KD')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HCM_KD', 'CN_HCM', N'Phòng Kinh Doanh HCM');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HCM_KT')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HCM_KT', 'CN_HCM', N'Phòng Kế Toán HCM');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HCM_NS')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HCM_NS', 'CN_HCM', N'Phòng Nhân Sự HCM');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HCM_IT')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HCM_IT', 'CN_HCM', N'Phòng Công Nghệ HCM');
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HCM_MKT')
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) VALUES ('PB_HCM_MKT', 'CN_HCM', N'Phòng Marketing HCM');
GO

-- =====================================================================
-- BƯỚC 4: TẠO NHÂN VIÊN (Mỗi phòng 1 Trưởng phòng & 1 Nhân viên)
-- =====================================================================
-- Nhân sự Chi nhánh Hà Nội
IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV_HN_KD_TP')
BEGIN
    INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, NgaySinh, MaPhongBan, MaChucDanh) VALUES 
    ('NV_HN_KD_TP', N'Lê Văn Kinh Doanh', N'Nam', '1985-01-15', 'PB_HN_KD', 'CD_TP'),
    ('NV_HN_KD_NV', N'Trần Thị Bán Hàng', N'Nữ', '1995-05-20', 'PB_HN_KD', 'CD_NV'),
    ('NV_HN_KT_TP', N'Phạm Kế Toán', N'Nữ', '1988-02-10', 'PB_HN_KT', 'CD_TP'),
    ('NV_HN_KT_NV', N'Nguyễn Thu Ngân', N'Nữ', '1998-08-11', 'PB_HN_KT', 'CD_NV'),
    ('NV_HN_NS_TP', N'Hoàng Nhân Sự', N'Nam', '1986-03-22', 'PB_HN_NS', 'CD_TP'),
    ('NV_HN_NS_NV', N'Đỗ Tuyển Dụng', N'Nữ', '1996-09-05', 'PB_HN_NS', 'CD_NV'),
    ('NV_HN_IT_TP', N'Vũ Công Nghệ', N'Nam', '1990-11-11', 'PB_HN_IT', 'CD_TP'),
    ('NV_HN_IT_NV', N'Ngô Lập Trình', N'Nam', '1999-12-01', 'PB_HN_IT', 'CD_NV'),
    ('NV_HN_MKT_TP', N'Đặng Marketing', N'Nữ', '1989-07-07', 'PB_HN_MKT', 'CD_TP'),
    ('NV_HN_MKT_NV', N'Bùi Quảng Cáo', N'Nam', '1997-04-14', 'PB_HN_MKT', 'CD_NV');
END

-- Nhân sự Chi nhánh Hồ Chí Minh
IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV_HCM_KD_TP')
BEGIN
    INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, NgaySinh, MaPhongBan, MaChucDanh) VALUES 
    ('NV_HCM_KD_TP', N'Trương Kinh Doanh', N'Nam', '1984-06-18', 'PB_HCM_KD', 'CD_TP'),
    ('NV_HCM_KD_NV', N'Lý Bán Hàng', N'Nữ', '1994-01-25', 'PB_HCM_KD', 'CD_NV'),
    ('NV_HCM_KT_TP', N'Hồ Kế Toán', N'Nữ', '1987-10-30', 'PB_HCM_KT', 'CD_TP'),
    ('NV_HCM_KT_NV', N'Châu Thu Ngân', N'Nữ', '1996-03-12', 'PB_HCM_KT', 'CD_NV'),
    ('NV_HCM_NS_TP', N'Dương Nhân Sự', N'Nam', '1983-12-05', 'PB_HCM_NS', 'CD_TP'),
    ('NV_HCM_NS_NV', N'Tô Tuyển Dụng', N'Nữ', '1995-11-20', 'PB_HCM_NS', 'CD_NV'),
    ('NV_HCM_IT_TP', N'Tạ Công Nghệ', N'Nam', '1991-08-08', 'PB_HCM_IT', 'CD_TP'),
    ('NV_HCM_IT_NV', N'Đinh Lập Trình', N'Nam', '1998-05-15', 'PB_HCM_IT', 'CD_NV'),
    ('NV_HCM_MKT_TP', N'Đoàn Marketing', N'Nữ', '1990-09-09', 'PB_HCM_MKT', 'CD_TP'),
    ('NV_HCM_MKT_NV', N'Lâm Quảng Cáo', N'Nam', '1997-02-28', 'PB_HCM_MKT', 'CD_NV');
END
GO

-- =====================================================================
-- BƯỚC 5: CẬP NHẬT TRƯỞNG PHÒNG CHO CÁC PHÒNG BAN (Đóng vòng lặp khóa ngoại)
-- =====================================================================
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_KD_TP' WHERE MaPhongBan = 'PB_HN_KD';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_KT_TP' WHERE MaPhongBan = 'PB_HN_KT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_NS_TP' WHERE MaPhongBan = 'PB_HN_NS';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_IT_TP' WHERE MaPhongBan = 'PB_HN_IT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_MKT_TP' WHERE MaPhongBan = 'PB_HN_MKT';

UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_KD_TP' WHERE MaPhongBan = 'PB_HCM_KD';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_KT_TP' WHERE MaPhongBan = 'PB_HCM_KT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_NS_TP' WHERE MaPhongBan = 'PB_HCM_NS';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_IT_TP' WHERE MaPhongBan = 'PB_HCM_IT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_MKT_TP' WHERE MaPhongBan = 'PB_HCM_MKT';
GO

-- =====================================================================
-- BƯỚC 6: TẠO CHI TIẾT NHÂN VIÊN CHO MỘT VÀI NGƯỜI (Tránh lỗi UNIQUE)
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM ChiTietNhanVien WHERE MaNhanVien = 'NV_HN_IT_TP')
BEGIN
    INSERT INTO ChiTietNhanVien (MaNhanVien, SoDienThoai, EmailCongTy, SoCCCD, NgayCapCCCD, MaSoThue, SoTaiKhoan, TenNganHang)
    VALUES 
    ('NV_HN_IT_TP', '0912345678', 'it_hn_tp@congty.com', '001090123456', '2021-05-10', '0101234567', '190311112222', 'Techcombank'),
    ('NV_HCM_IT_TP', '0987654321', 'it_hcm_tp@congty.com', '079091654321', '2022-08-15', '0307654321', '0123456789', 'Vietcombank');
END
GO
-- =====================================================================
-- BƯỚC 7: TẠO DỮ LIỆU CA LÀM VIỆC
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM CaLamViec WHERE MaCa = 'CA_HC')
BEGIN
    INSERT INTO CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc) 
    VALUES 
    ('CA_HC', N'Ca hành chính (Full-time)', '08:00', '17:30'),
    ('CA_SANG', N'Ca sáng (Part-time)', '08:00', '12:00'),
    ('CA_CHIEU', N'Ca chiều (Part-time)', '13:30', '17:30'),
    ('CA_DEM', N'Ca đêm', '22:00', '06:00');
END
GO

-- =====================================================================
-- BƯỚC 8: TẠO DỮ LIỆU HÌNH THỨC CHẤM CÔNG (Loại chấm công)
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM HinhThucChamCong WHERE MaHinhThuc = 'HT_DILAM')
BEGIN
    INSERT INTO HinhThucChamCong (MaHinhThuc, TenHinhThuc) 
    VALUES 
    ('HT_DILAM', N'Đi làm bình thường'),
    ('HT_DITRE', N'Đi trễ'),
    ('HT_VESOM', N'Về sớm'),
    ('HT_OT_NGAY', N'Làm thêm giờ (OT ngày thường)'),
    ('HT_OT_CUOITUAN', N'Làm thêm giờ (OT cuối tuần/Lễ)'),
    ('HT_NGHILUONG', N'Nghỉ phép (Có lương)'),
    ('HT_NGHIKHONG', N'Nghỉ phép (Không lương)');
END
GO

-- =====================================================================
-- BƯỚC 9: TẠO DANH MỤC PHỤ CẤP
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM DanhMucPhuCap WHERE MaPhuCap = 'PC_ANTRUA')
BEGIN
    INSERT INTO DanhMucPhuCap (MaPhuCap, TenPhuCap, MucTien) 
    VALUES 
    ('PC_ANTRUA', N'Phụ cấp ăn trưa', 700000.00),    -- 700k
    ('PC_XANGXE', N'Phụ cấp xăng xe', 300000.00),    -- 300k
    ('PC_DIENTHOAI', N'Phụ cấp điện thoại', 200000.00), -- 200k
    ('PC_CHUYENCAN', N'Phụ cấp chuyên cần', 500000.00), -- 500k
    ('PC_TRACHNHIEM', N'Phụ cấp trách nhiệm', 1500000.00); -- 1.5 triệu (thường cho Quản lý)
END
GO
-- =====================================================================
-- BƯỚC 10: TẠO DỮ LIỆU HỢP ĐỒNG LAO ĐỘNG
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM HopDongLaoDong WHERE SoHopDong = 'HDLD_HN_KD_001')
BEGIN
    INSERT INTO HopDongLaoDong (SoHopDong, MaNhanVien, LoaiHopDong, NgayKy, NgayHieuLuc, NgayHetHan, LuongCung, TrangThai)
    VALUES 
    -- 1. Trưởng phòng KD Hà Nội: Hợp đồng không xác định thời hạn, lương cứng 25 triệu (NULL ngày hết hạn)
    ('HDLD_HN_KD_001', 'NV_HN_KD_TP', N'Không xác định thời hạn', '2023-01-05', '2023-01-05', NULL, 25000000.00, N'Đang hiệu lực'),

    -- 2. Nhân viên KD Hà Nội: Hợp đồng 1 năm, lương cứng 12 triệu
    ('HDLD_HN_KD_002', 'NV_HN_KD_NV', N'Xác định thời hạn 1 năm', '2025-05-20', '2025-05-20', '2026-05-20', 12000000.00, N'Đang hiệu lực'),

    -- 3. Trưởng phòng IT HCM: Hợp đồng 3 năm, lương cứng 30 triệu
    ('HDLD_HCM_IT_001', 'NV_HCM_IT_TP', N'Xác định thời hạn 3 năm', '2024-08-01', '2024-08-01', '2027-08-01', 30000000.00, N'Đang hiệu lực'),

    -- 4. Nhân viên IT HCM: Hợp đồng thử việc 2 tháng, lương cứng 10 triệu
    ('HDLD_HCM_IT_002', 'NV_HCM_IT_NV', N'Hợp đồng thử việc', '2026-05-01', '2026-05-01', '2026-07-01', 10000000.00, N'Đang hiệu lực'),
    
    -- 5. Trưởng phòng Kế toán Hà Nội (Kịch bản: Có hợp đồng cũ đã hết hạn, và hợp đồng mới đang hiệu lực)
    ('HDLD_HN_KT_OLD', 'NV_HN_KT_TP', N'Xác định thời hạn 1 năm', '2022-02-10', '2022-02-10', '2023-02-10', 18000000.00, N'Đã hết hạn'),
    ('HDLD_HN_KT_NEW', 'NV_HN_KT_TP', N'Không xác định thời hạn', '2023-02-11', '2023-02-11', NULL, 22000000.00, N'Đang hiệu lực');
END
GO