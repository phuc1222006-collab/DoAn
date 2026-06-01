USE QuanLyNhanSu;
GO

-- =====================================================================
-- BƯỚC 1: TẠO DANH MỤC CHỨC DANH (Bảng không phụ thuộc)
-- =====================================================================
-- Xóa lỗi nếu chạy lại nhiều lần, ta dùng IF NOT EXISTS
IF NOT EXISTS (SELECT 1 FROM ChucDanh WHERE MaChucDanh = 'CD_TP')
    INSERT INTO ChucDanh (MaChucDanh, TenChucDanh, CapBac) VALUES ('CD_TP', N'Trưởng phòng', N'Quản lý');

IF NOT EXISTS (SELECT 1 FROM ChucDanh WHERE MaChucDanh = 'CD_NV')
    INSERT INTO ChucDanh (MaChucDanh, TenChucDanh, CapBac) VALUES ('CD_NV', N'Nhân viên', N'Nhân viên');
GO

-- =====================================================================
-- BƯỚC 2: TẠO 2 CHI NHÁNH (Bảng không phụ thuộc)
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM ChiNhanh WHERE MaChiNhanh = 'CN_HN')
BEGIN
    INSERT INTO ChiNhanh (MaChiNhanh, TenChiNhanh, DiaChi, Hotline) 
    VALUES 
    ('CN_HN', N'Chi nhánh Hà Nội', N'Đống Đa, Hà Nội', '0241000000'),
    ('CN_HCM', N'Chi nhánh Hồ Chí Minh', N'Quận 1, TP.HCM', '0281000000');
END
GO

-- =====================================================================
-- BƯỚC 3: TẠO 10 PHÒNG BAN (Phụ thuộc Chi nhánh - Trưởng phòng để NULL)
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM PhongBan WHERE MaPhongBan = 'PB_HN_KD')
BEGIN
    INSERT INTO PhongBan (MaPhongBan, MaChiNhanh, TenPhongBan) 
    VALUES 
    -- 5 Phòng thuộc Hà Nội
    ('PB_HN_KD', 'CN_HN', N'Phòng Kinh Doanh HN'),
    ('PB_HN_KT', 'CN_HN', N'Phòng Kế Toán HN'),
    ('PB_HN_NS', 'CN_HN', N'Phòng Nhân Sự HN'),
    ('PB_HN_IT', 'CN_HN', N'Phòng Công Nghệ HN'),
    ('PB_HN_MKT', 'CN_HN', N'Phòng Marketing HN'),
    
    -- 5 Phòng thuộc Hồ Chí Minh
    ('PB_HCM_KD', 'CN_HCM', N'Phòng Kinh Doanh HCM'),
    ('PB_HCM_KT', 'CN_HCM', N'Phòng Kế Toán HCM'),
    ('PB_HCM_NS', 'CN_HCM', N'Phòng Nhân Sự HCM'),
    ('PB_HCM_IT', 'CN_HCM', N'Phòng Công Nghệ HCM'),
    ('PB_HCM_MKT', 'CN_HCM', N'Phòng Marketing HCM');
END
GO

-- =====================================================================
-- BƯỚC 4: TẠO 50 NHÂN VIÊN (Phụ thuộc Phòng ban & Chức danh)
-- =====================================================================
-- Mỗi phòng có người số 1 là CD_TP (Trưởng phòng), còn lại là CD_NV (Nhân viên)
IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV_HN_KD1')
BEGIN
    INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, NgaySinh, MaPhongBan, MaChucDanh, TrangThaiLamViec) 
    VALUES 
    -- Nhân sự phòng Kinh Doanh HN
    ('NV_HN_KD1', N'Trần Kinh Doanh HN 1', N'Nam', '1990-01-01', 'PB_HN_KD', 'CD_TP', N'Đang làm việc'),
    ('NV_HN_KD2', N'Lê Kinh Doanh HN 2', N'Nữ', '1995-02-02', 'PB_HN_KD', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_KD3', N'Phạm Kinh Doanh HN 3', N'Nam', '1996-03-03', 'PB_HN_KD', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_KD4', N'Hoàng Kinh Doanh HN 4', N'Nữ', '1997-04-04', 'PB_HN_KD', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_KD5', N'Vũ Kinh Doanh HN 5', N'Nam', '1998-05-05', 'PB_HN_KD', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng Kế Toán HN
    ('NV_HN_KT1', N'Trần Kế Toán HN 1', N'Nữ', '1990-01-01', 'PB_HN_KT', 'CD_TP', N'Đang làm việc'),
    ('NV_HN_KT2', N'Lê Kế Toán HN 2', N'Nam', '1995-02-02', 'PB_HN_KT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_KT3', N'Phạm Kế Toán HN 3', N'Nữ', '1996-03-03', 'PB_HN_KT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_KT4', N'Hoàng Kế Toán HN 4', N'Nam', '1997-04-04', 'PB_HN_KT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_KT5', N'Vũ Kế Toán HN 5', N'Nữ', '1998-05-05', 'PB_HN_KT', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng Nhân Sự HN
    ('NV_HN_NS1', N'Trần Nhân Sự HN 1', N'Nữ', '1990-01-01', 'PB_HN_NS', 'CD_TP', N'Đang làm việc'),
    ('NV_HN_NS2', N'Lê Nhân Sự HN 2', N'Nam', '1995-02-02', 'PB_HN_NS', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_NS3', N'Phạm Nhân Sự HN 3', N'Nữ', '1996-03-03', 'PB_HN_NS', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_NS4', N'Hoàng Nhân Sự HN 4', N'Nam', '1997-04-04', 'PB_HN_NS', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_NS5', N'Vũ Nhân Sự HN 5', N'Nữ', '1998-05-05', 'PB_HN_NS', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng IT HN
    ('NV_HN_IT1', N'Trần Công Nghệ HN 1', N'Nam', '1990-01-01', 'PB_HN_IT', 'CD_TP', N'Đang làm việc'),
    ('NV_HN_IT2', N'Lê Công Nghệ HN 2', N'Nữ', '1995-02-02', 'PB_HN_IT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_IT3', N'Phạm Công Nghệ HN 3', N'Nam', '1996-03-03', 'PB_HN_IT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_IT4', N'Hoàng Công Nghệ HN 4', N'Nữ', '1997-04-04', 'PB_HN_IT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_IT5', N'Vũ Công Nghệ HN 5', N'Nam', '1998-05-05', 'PB_HN_IT', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng MKT HN
    ('NV_HN_MKT1', N'Trần Marketing HN 1', N'Nữ', '1990-01-01', 'PB_HN_MKT', 'CD_TP', N'Đang làm việc'),
    ('NV_HN_MKT2', N'Lê Marketing HN 2', N'Nam', '1995-02-02', 'PB_HN_MKT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_MKT3', N'Phạm Marketing HN 3', N'Nữ', '1996-03-03', 'PB_HN_MKT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_MKT4', N'Hoàng Marketing HN 4', N'Nam', '1997-04-04', 'PB_HN_MKT', 'CD_NV', N'Đang làm việc'),
    ('NV_HN_MKT5', N'Vũ Marketing HN 5', N'Nữ', '1998-05-05', 'PB_HN_MKT', 'CD_NV', N'Đang làm việc'),

    -- ===========================================================
    -- Nhân sự phòng Kinh Doanh HCM
    ('NV_HCM_KD1', N'Ngô Kinh Doanh HCM 1', N'Nam', '1990-01-01', 'PB_HCM_KD', 'CD_TP', N'Đang làm việc'),
    ('NV_HCM_KD2', N'Bùi Kinh Doanh HCM 2', N'Nữ', '1995-02-02', 'PB_HCM_KD', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_KD3', N'Đỗ Kinh Doanh HCM 3', N'Nam', '1996-03-03', 'PB_HCM_KD', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_KD4', N'Hồ Kinh Doanh HCM 4', N'Nữ', '1997-04-04', 'PB_HCM_KD', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_KD5', N'Dương Kinh Doanh HCM 5', N'Nam', '1998-05-05', 'PB_HCM_KD', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng Kế Toán HCM
    ('NV_HCM_KT1', N'Ngô Kế Toán HCM 1', N'Nữ', '1990-01-01', 'PB_HCM_KT', 'CD_TP', N'Đang làm việc'),
    ('NV_HCM_KT2', N'Bùi Kế Toán HCM 2', N'Nam', '1995-02-02', 'PB_HCM_KT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_KT3', N'Đỗ Kế Toán HCM 3', N'Nữ', '1996-03-03', 'PB_HCM_KT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_KT4', N'Hồ Kế Toán HCM 4', N'Nam', '1997-04-04', 'PB_HCM_KT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_KT5', N'Dương Kế Toán HCM 5', N'Nữ', '1998-05-05', 'PB_HCM_KT', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng Nhân Sự HCM
    ('NV_HCM_NS1', N'Ngô Nhân Sự HCM 1', N'Nữ', '1990-01-01', 'PB_HCM_NS', 'CD_TP', N'Đang làm việc'),
    ('NV_HCM_NS2', N'Bùi Nhân Sự HCM 2', N'Nam', '1995-02-02', 'PB_HCM_NS', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_NS3', N'Đỗ Nhân Sự HCM 3', N'Nữ', '1996-03-03', 'PB_HCM_NS', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_NS4', N'Hồ Nhân Sự HCM 4', N'Nam', '1997-04-04', 'PB_HCM_NS', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_NS5', N'Dương Nhân Sự HCM 5', N'Nữ', '1998-05-05', 'PB_HCM_NS', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng IT HCM
    ('NV_HCM_IT1', N'Ngô Công Nghệ HCM 1', N'Nam', '1990-01-01', 'PB_HCM_IT', 'CD_TP', N'Đang làm việc'),
    ('NV_HCM_IT2', N'Bùi Công Nghệ HCM 2', N'Nữ', '1995-02-02', 'PB_HCM_IT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_IT3', N'Đỗ Công Nghệ HCM 3', N'Nam', '1996-03-03', 'PB_HCM_IT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_IT4', N'Hồ Công Nghệ HCM 4', N'Nữ', '1997-04-04', 'PB_HCM_IT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_IT5', N'Dương Công Nghệ HCM 5', N'Nam', '1998-05-05', 'PB_HCM_IT', 'CD_NV', N'Đang làm việc'),

    -- Nhân sự phòng MKT HCM
    ('NV_HCM_MKT1', N'Ngô Marketing HCM 1', N'Nữ', '1990-01-01', 'PB_HCM_MKT', 'CD_TP', N'Đang làm việc'),
    ('NV_HCM_MKT2', N'Bùi Marketing HCM 2', N'Nam', '1995-02-02', 'PB_HCM_MKT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_MKT3', N'Đỗ Marketing HCM 3', N'Nữ', '1996-03-03', 'PB_HCM_MKT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_MKT4', N'Hồ Marketing HCM 4', N'Nam', '1997-04-04', 'PB_HCM_MKT', 'CD_NV', N'Đang làm việc'),
    ('NV_HCM_MKT5', N'Dương Marketing HCM 5', N'Nữ', '1998-05-05', 'PB_HCM_MKT', 'CD_NV', N'Đang làm việc');
END
GO

-- =====================================================================
-- BƯỚC 5: TẠO CHI TIẾT 50 NHÂN VIÊN (Đã bổ sung MaSoThue để fix lỗi UNIQUE NULL)
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM ChiTietNhanVien WHERE MaNhanVien = 'NV_HN_KD1')
BEGIN
    INSERT INTO ChiTietNhanVien (MaNhanVien, SoDienThoai, EmailCongTy, SoCCCD, NgayCapCCCD, NoiCapCCCD, MaSoThue) 
    VALUES 
    -- Chi tiết HN (Mã số thuế đầu 100...)
    ('NV_HN_KD1', '0901000001', 'hn_kd1@congty.com', '001000000001', '2021-01-01', N'Cục CS QLHC', '1000000001'),
    ('NV_HN_KD2', '0901000002', 'hn_kd2@congty.com', '001000000002', '2021-01-01', N'Cục CS QLHC', '1000000002'),
    ('NV_HN_KD3', '0901000003', 'hn_kd3@congty.com', '001000000003', '2021-01-01', N'Cục CS QLHC', '1000000003'),
    ('NV_HN_KD4', '0901000004', 'hn_kd4@congty.com', '001000000004', '2021-01-01', N'Cục CS QLHC', '1000000004'),
    ('NV_HN_KD5', '0901000005', 'hn_kd5@congty.com', '001000000005', '2021-01-01', N'Cục CS QLHC', '1000000005'),

    ('NV_HN_KT1', '0901000006', 'hn_kt1@congty.com', '001000000006', '2021-01-01', N'Cục CS QLHC', '1000000006'),
    ('NV_HN_KT2', '0901000007', 'hn_kt2@congty.com', '001000000007', '2021-01-01', N'Cục CS QLHC', '1000000007'),
    ('NV_HN_KT3', '0901000008', 'hn_kt3@congty.com', '001000000008', '2021-01-01', N'Cục CS QLHC', '1000000008'),
    ('NV_HN_KT4', '0901000009', 'hn_kt4@congty.com', '001000000009', '2021-01-01', N'Cục CS QLHC', '1000000009'),
    ('NV_HN_KT5', '0901000010', 'hn_kt5@congty.com', '001000000010', '2021-01-01', N'Cục CS QLHC', '1000000010'),

    ('NV_HN_NS1', '0901000011', 'hn_ns1@congty.com', '001000000011', '2021-01-01', N'Cục CS QLHC', '1000000011'),
    ('NV_HN_NS2', '0901000012', 'hn_ns2@congty.com', '001000000012', '2021-01-01', N'Cục CS QLHC', '1000000012'),
    ('NV_HN_NS3', '0901000013', 'hn_ns3@congty.com', '001000000013', '2021-01-01', N'Cục CS QLHC', '1000000013'),
    ('NV_HN_NS4', '0901000014', 'hn_ns4@congty.com', '001000000014', '2021-01-01', N'Cục CS QLHC', '1000000014'),
    ('NV_HN_NS5', '0901000015', 'hn_ns5@congty.com', '001000000015', '2021-01-01', N'Cục CS QLHC', '1000000015'),

    ('NV_HN_IT1', '0901000016', 'hn_it1@congty.com', '001000000016', '2021-01-01', N'Cục CS QLHC', '1000000016'),
    ('NV_HN_IT2', '0901000017', 'hn_it2@congty.com', '001000000017', '2021-01-01', N'Cục CS QLHC', '1000000017'),
    ('NV_HN_IT3', '0901000018', 'hn_it3@congty.com', '001000000018', '2021-01-01', N'Cục CS QLHC', '1000000018'),
    ('NV_HN_IT4', '0901000019', 'hn_it4@congty.com', '001000000019', '2021-01-01', N'Cục CS QLHC', '1000000019'),
    ('NV_HN_IT5', '0901000020', 'hn_it5@congty.com', '001000000020', '2021-01-01', N'Cục CS QLHC', '1000000020'),

    ('NV_HN_MKT1', '0901000021', 'hn_mkt1@congty.com', '001000000021', '2021-01-01', N'Cục CS QLHC', '1000000021'),
    ('NV_HN_MKT2', '0901000022', 'hn_mkt2@congty.com', '001000000022', '2021-01-01', N'Cục CS QLHC', '1000000022'),
    ('NV_HN_MKT3', '0901000023', 'hn_mkt3@congty.com', '001000000023', '2021-01-01', N'Cục CS QLHC', '1000000023'),
    ('NV_HN_MKT4', '0901000024', 'hn_mkt4@congty.com', '001000000024', '2021-01-01', N'Cục CS QLHC', '1000000024'),
    ('NV_HN_MKT5', '0901000025', 'hn_mkt5@congty.com', '001000000025', '2021-01-01', N'Cục CS QLHC', '1000000025'),

    -- Chi tiết HCM (Mã số thuế đầu 200...)
    ('NV_HCM_KD1', '0902000001', 'hcm_kd1@congty.com', '079000000001', '2021-01-01', N'Cục CS QLHC', '2000000001'),
    ('NV_HCM_KD2', '0902000002', 'hcm_kd2@congty.com', '079000000002', '2021-01-01', N'Cục CS QLHC', '2000000002'),
    ('NV_HCM_KD3', '0902000003', 'hcm_kd3@congty.com', '079000000003', '2021-01-01', N'Cục CS QLHC', '2000000003'),
    ('NV_HCM_KD4', '0902000004', 'hcm_kd4@congty.com', '079000000004', '2021-01-01', N'Cục CS QLHC', '2000000004'),
    ('NV_HCM_KD5', '0902000005', 'hcm_kd5@congty.com', '079000000005', '2021-01-01', N'Cục CS QLHC', '2000000005'),

    ('NV_HCM_KT1', '0902000006', 'hcm_kt1@congty.com', '079000000006', '2021-01-01', N'Cục CS QLHC', '2000000006'),
    ('NV_HCM_KT2', '0902000007', 'hcm_kt2@congty.com', '079000000007', '2021-01-01', N'Cục CS QLHC', '2000000007'),
    ('NV_HCM_KT3', '0902000008', 'hcm_kt3@congty.com', '079000000008', '2021-01-01', N'Cục CS QLHC', '2000000008'),
    ('NV_HCM_KT4', '0902000009', 'hcm_kt4@congty.com', '079000000009', '2021-01-01', N'Cục CS QLHC', '2000000009'),
    ('NV_HCM_KT5', '0902000010', 'hcm_kt5@congty.com', '079000000010', '2021-01-01', N'Cục CS QLHC', '2000000010'),

    ('NV_HCM_NS1', '0902000011', 'hcm_ns1@congty.com', '079000000011', '2021-01-01', N'Cục CS QLHC', '2000000011'),
    ('NV_HCM_NS2', '0902000012', 'hcm_ns2@congty.com', '079000000012', '2021-01-01', N'Cục CS QLHC', '2000000012'),
    ('NV_HCM_NS3', '0902000013', 'hcm_ns3@congty.com', '079000000013', '2021-01-01', N'Cục CS QLHC', '2000000013'),
    ('NV_HCM_NS4', '0902000014', 'hcm_ns4@congty.com', '079000000014', '2021-01-01', N'Cục CS QLHC', '2000000014'),
    ('NV_HCM_NS5', '0902000015', 'hcm_ns5@congty.com', '079000000015', '2021-01-01', N'Cục CS QLHC', '2000000015'),

    ('NV_HCM_IT1', '0902000016', 'hcm_it1@congty.com', '079000000016', '2021-01-01', N'Cục CS QLHC', '2000000016'),
    ('NV_HCM_IT2', '0902000017', 'hcm_it2@congty.com', '079000000017', '2021-01-01', N'Cục CS QLHC', '2000000017'),
    ('NV_HCM_IT3', '0902000018', 'hcm_it3@congty.com', '079000000018', '2021-01-01', N'Cục CS QLHC', '2000000018'),
    ('NV_HCM_IT4', '0902000019', 'hcm_it4@congty.com', '079000000019', '2021-01-01', N'Cục CS QLHC', '2000000019'),
    ('NV_HCM_IT5', '0902000020', 'hcm_it5@congty.com', '079000000020', '2021-01-01', N'Cục CS QLHC', '2000000020'),

    ('NV_HCM_MKT1', '0902000021', 'hcm_mkt1@congty.com', '079000000021', '2021-01-01', N'Cục CS QLHC', '2000000021'),
    ('NV_HCM_MKT2', '0902000022', 'hcm_mkt2@congty.com', '079000000022', '2021-01-01', N'Cục CS QLHC', '2000000022'),
    ('NV_HCM_MKT3', '0902000023', 'hcm_mkt3@congty.com', '079000000023', '2021-01-01', N'Cục CS QLHC', '2000000023'),
    ('NV_HCM_MKT4', '0902000024', 'hcm_mkt4@congty.com', '079000000024', '2021-01-01', N'Cục CS QLHC', '2000000024'),
    ('NV_HCM_MKT5', '0902000025', 'hcm_mkt5@congty.com', '079000000025', '2021-01-01', N'Cục CS QLHC', '2000000025');
END
GO

-- =====================================================================
-- BƯỚC 6: CẬP NHẬT TRƯỞNG PHÒNG CHO 10 PHÒNG BAN (Đóng vòng lặp khóa ngoại)
-- =====================================================================
-- Cập nhật cho 5 phòng ban Hà Nội (Gán người số 1 của phòng làm Trưởng phòng)
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_KD1' WHERE MaPhongBan = 'PB_HN_KD';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_KT1' WHERE MaPhongBan = 'PB_HN_KT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_NS1' WHERE MaPhongBan = 'PB_HN_NS';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_IT1' WHERE MaPhongBan = 'PB_HN_IT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HN_MKT1' WHERE MaPhongBan = 'PB_HN_MKT';

-- Cập nhật cho 5 phòng ban Hồ Chí Minh
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_KD1' WHERE MaPhongBan = 'PB_HCM_KD';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_KT1' WHERE MaPhongBan = 'PB_HCM_KT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_NS1' WHERE MaPhongBan = 'PB_HCM_NS';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_IT1' WHERE MaPhongBan = 'PB_HCM_IT';
UPDATE PhongBan SET MaTruongPhong = 'NV_HCM_MKT1' WHERE MaPhongBan = 'PB_HCM_MKT';
GO


-- =====================================================================
-- BƯỚC 1: KHỞI TẠO CÁC NHÓM QUYỀN HỢP LÝ
-- =====================================================================
IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_QUANLY')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) 
    VALUES ('NQ_QUANLY', N'Quản lý / Trưởng phòng', N'Duyệt đơn, đánh giá KPI nhân viên cấp dưới');

IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_HR')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) 
    VALUES ('NQ_HR', N'Phòng Nhân Sự', N'Quản lý hồ sơ, chấm công, tính lương, tuyển dụng');

IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_NHANVIEN')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) 
    VALUES ('NQ_NHANVIEN', N'Nhân viên', N'Xem thông tin cá nhân, nộp đơn từ');
GO

-- =====================================================================
-- BƯỚC 2: TỰ ĐỘNG TẠO 50 TÀI KHOẢN VÀ PHÂN QUYỀN THÔNG MINH
-- =====================================================================
INSERT INTO TaiKhoan (TenDangNhap, MaNhanVien, MatKhau, MaNhomQuyen, TrangThaiHoatDong)
SELECT 
    LOWER(MaNhanVien), -- Tên đăng nhập là mã nhân viên viết chữ thường (vd: nv_hn_kd1)
    MaNhanVien,
    '123456',          -- Mật khẩu mặc định chung là 123456
    CASE 
        -- Nếu thuộc phòng Nhân Sự (mã phòng ban kết thúc bằng _NS) -> Cấp quyền HR
        WHEN MaPhongBan LIKE '%_NS' THEN 'NQ_HR'
        
        -- Nếu là Trưởng phòng (Mã chức danh CD_TP) -> Cấp quyền Quản lý
        WHEN MaChucDanh = 'CD_TP' THEN 'NQ_QUANLY'
        
        -- Còn lại tất cả -> Cấp quyền Nhân viên bình thường
        ELSE 'NQ_NHANVIEN' 
    END,
    1 -- Trạng thái hoạt động = 1 (Đang mở)
FROM NhanVien
-- Điều kiện: Chỉ tạo cho những người chưa có tài khoản (Tránh lỗi trùng lặp khi chạy lại lệnh)
WHERE MaNhanVien NOT IN (SELECT MaNhanVien FROM TaiKhoan);
GO

-- 1. Tạo một Nhân viên ngoại lệ (Không thuộc phòng ban nào để tránh ràng buộc)
IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV_ADMIN_99')
BEGIN
    INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, NgaySinh, MaPhongBan, MaChucDanh, TrangThaiLamViec) 
    VALUES ('NV_ADMIN_99', N'Quản Trị Hệ Thống', N'Nam', '1990-01-01', NULL, NULL, N'Đang làm việc');
END
GO

-- 2. Bổ sung Nhóm quyền Admin nếu chưa có
IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_ADMIN')
BEGIN
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) 
    VALUES ('NQ_ADMIN', N'Administrator', N'Toàn quyền quản trị hệ thống');
END
GO

-- 3. Cấp tài khoản đăng nhập Admin cho nhân viên NV_ADMIN_99 (Đã được tạo thành công ở lệnh trước)
IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'admin_hethong')
BEGIN
    INSERT INTO TaiKhoan (TenDangNhap, MaNhanVien, MatKhau, MaNhomQuyen, TrangThaiHoatDong) 
    VALUES ('admin_hethong', 'NV_ADMIN_99', '123456', 'NQ_ADMIN', 1);
END
GO





-- =========================================================
-- BƯỚC 1: THÊM MENU TỔNG (Cấp Cha - MaChucNangCha để NULL)
-- =========================================================
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'MENU_NHANSU')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('MENU_NHANSU', N'Quản lý nhân sự', 'rbNhanSu', N'Tab Menu Ribbon Quản lý nhân sự', NULL);

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'MENU_CHAMCONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('MENU_CHAMCONG', N'Chấm công/Tài chính', 'rbChamCong', N'Tab Menu Ribbon Chấm công và Tài chính', NULL);

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'MENU_HETHONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('MENU_HETHONG', N'Hệ thống', 'rbHeThong', N'Tab Menu Ribbon Quản trị hệ thống', NULL);
GO

-- =========================================================
-- BƯỚC 2: THÊM FORM/TAB CON THUỘC MENU "NHÂN SỰ"
-- =========================================================
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_HOSONV')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_HOSONV', N'Hồ sơ nhân viên', 'frmHoSoNhanVien', N'Quản lý thông tin cá nhân', 'MENU_NHANSU');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_HANHCHINH')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_HANHCHINH', N'hành Chính', 'frmhanhchinh', N'hành hính', 'MENU_NHANSU');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_TUYENDUNG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_TUYENDUNG', N'Tuyển dụng', 'frmTuyenDung', N'Màn hình Tuyển dụng gốc', 'MENU_NHANSU');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TD_KEHOACH')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_TD_KEHOACH', N'Kế Hoạch Tuyển Dụng', 'tabKeHoachTD', N'Tab kế hoạch tuyển dụng', 'MENU_NHANSU');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TD_HOSO')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_TD_HOSO', N'Hồ Sơ Ứng Viên', 'tabHoSoUngVien', N'Tab hồ sơ ứng viên', 'MENU_NHANSU');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TD_PHONGVAN')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_TD_PHONGVAN', N'Lịch Phỏng Vấn', 'tabLichPhongVan', N'Tab lịch phỏng vấn', 'MENU_NHANSU');

-- =========================================================
-- BƯỚC 3: THÊM FORM/TAB CON THUỘC MENU "CHẤM CÔNG/TÀI CHÍNH"
-- =========================================================
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_CHAMCONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_CHAMCONG', N'Chấm công & Đơn từ', 'frmChamCong', N'Màn hình Chấm công gốc', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_TAMUNG_THUONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_TAMUNG_THUONG', N'Tạm ứng & Khen thưởng', 'frmTamUngKhenThuong', N'Màn hình Tạm ứng gốc', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TAMUNG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_TAMUNG', N'Quản Lý Tạm Ứng', 'tabTamUng', N'Tab xét duyệt tạm ứng lương', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_KHENTHUONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_KHENTHUONG', N'Khen Thưởng / Kỷ Luật', 'tabKhenThuong', N'Tab khen thưởng kỷ luật', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_PHUCAPNV')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_PHUCAPNV', N'Phụ Cấp Nhân Viên', 'tabPhuCapNV', N'Tab phụ cấp nhân viên', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_CC_DULIEU')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_CC_DULIEU', N'Bảng Dữ Liệu Chấm Công', 'tabDuLieuChamCong', N'Tab tổng hợp công', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_CC_DUYETNGHI')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_CC_DUYETNGHI', N'Duyệt Đơn Nghỉ Phép', 'tabDuyetNghiPhep', N'Tab duyệt đơn nghỉ', 'MENU_CHAMCONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_CC_CHITIET')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_CC_CHITIET', N'Chấm Công', 'tabChamCongChiTiet', N'Tab chấm công chi tiết', 'MENU_CHAMCONG');

-- =========================================================
-- BƯỚC 4: THÊM FORM/TAB CON THUỘC MENU "HỆ THỐNG"
-- =========================================================
IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_DANHMUC')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_DANHMUC', N'Danh mục hệ thống', 'frmDanhMuc', N'Màn hình Danh mục gốc', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'CN_TAIKHOAN_PQ')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('CN_TAIKHOAN_PQ', N'Tài khoản & Phân quyền', 'Formhethong', N'Màn hình Hệ thống gốc', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_TAIKHOAN')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_TAIKHOAN', N'Quản Lý Tài Khoản', 'tabTaiKhoan', N'Tab quản lý tài khoản', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_NHOMQUYEN')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_NHOMQUYEN', N'Nhóm Quyền Hệ Thống', 'tabNhomQuyen', N'Tab thiết lập nhóm quyền', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_NHATKY')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_NHATKY', N'Nhật Ký Hệ Thống', 'tabNhatKy', N'Tab xem lịch sử', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_PHUCAP')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_DM_PHUCAP', N'Danh Mục Phụ Cấp', 'tabDMPhuCap', N'Tab danh mục phụ cấp', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_PHONGBAN')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_DM_PHONGBAN', N'Cơ Cấu Phòng Ban', 'tabDMPhongBan', N'Tab sơ đồ phòng ban', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_CHUCDANH')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_DM_CHUCDANH', N'Chức Danh', 'tabDMChucDanh', N'Tab chức danh', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_CALAMVIEC')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_DM_CALAMVIEC', N'Ca Làm Việc', 'tabDMCaLamViec', N'Tab cài đặt thời gian', 'MENU_HETHONG');

IF NOT EXISTS (SELECT 1 FROM ChucNang WHERE MaChucNang = 'TAB_DM_LOAICHAMCONG')
    INSERT INTO ChucNang (MaChucNang, TenChucNang, TenForm, MoTa, MaChucNangCha)
    VALUES ('TAB_DM_LOAICHAMCONG', N'Loại Chấm Công', 'tabDMLoaiChamCong', N'Tab loại chấm công', 'MENU_HETHONG');
GO


-- =====================================================================
-- BƯỚC 1: KHỞI TẠO 4 NHÓM QUYỀN TỪ GIAO DIỆN CỦA BẠN
-- =====================================================================
-- Xóa quyền cũ nếu có để tránh lỗi trùng lặp khi chạy lại lệnh
DELETE FROM PhanQuyen WHERE MaNhomQuyen IN ('NQ_ADMIN', 'NQ_HR', 'NQ_NHANVIEN', 'NQ_QUANLY');

-- Thêm/Cập nhật Nhóm Quyền
IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_ADMIN')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) VALUES ('NQ_ADMIN', N'Administrator', N'Toàn quyền quản trị hệ thống');
    
IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_HR')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) VALUES ('NQ_HR', N'Phòng Nhân Sự', N'Quản lý hồ sơ, chấm công, tính lương, tuyển dụng');

IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_NHANVIEN')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) VALUES ('NQ_NHANVIEN', N'Nhân viên', N'Xem thông tin cá nhân, nộp đơn từ');

IF NOT EXISTS (SELECT 1 FROM NhomQuyen WHERE MaNhomQuyen = 'NQ_QUANLY')
    INSERT INTO NhomQuyen (MaNhomQuyen, TenNhomQuyen, MoTa) VALUES ('NQ_QUANLY', N'Quản lý / Trưởng phòng', N'Duyệt đơn, đánh giá KPI nhân viên cấp dưới');
GO

-- =====================================================================
-- BƯỚC 2: CẤP QUYỀN CHO ADMIN (TOÀN QUYỀN 100%)
-- =====================================================================
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_ADMIN', MaChucNang, 1, 1, 1, 1 FROM ChucNang;

-- =====================================================================
-- BƯỚC 3: CẤP QUYỀN CHO HR (PHÒNG NHÂN SỰ)
-- =====================================================================
-- Cho phép toàn quyền trên tất cả các Form...
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_HR', MaChucNang, 1, 1, 1, 1 FROM ChucNang
-- ... NGOẠI TRỪ các chức năng thuộc về Bảo mật Hệ Thống
WHERE MaChucNang NOT IN ('CN_TAIKHOAN_PQ', 'TAB_TAIKHOAN', 'TAB_NHOMQUYEN', 'TAB_NHATKY');

-- Vẫn cho HR xem Menu Hệ thống và cài đặt Danh mục (nhưng không được đụng vào Tài khoản)
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_HR', MaChucNang, 1, 1, 1, 1 FROM ChucNang
WHERE MaChucNang IN ('CN_DANHMUC', 'TAB_DM_PHUCAP', 'TAB_DM_PHONGBAN', 'TAB_DM_CHUCDANH', 'TAB_DM_CALAMVIEC', 'TAB_DM_LOAICHAMCONG');

-- =====================================================================
-- BƯỚC 4: CẤP QUYỀN CHO QUẢN LÝ / TRƯỞNG PHÒNG
-- =====================================================================
-- 1. Cho phép XEM các Menu tổng và Form gốc
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_QUANLY', MaChucNang, 1, 0, 0, 0 FROM ChucNang 
WHERE MaChucNang IN ('MENU_NHANSU', 'MENU_CHAMCONG', 'CN_HOSONV', 'CN_CHAMCONG', 'CN_TAMUNG_THUONG', 'TAB_CC_DULIEU');

-- 2. Cho phép VỪA XEM VỪA SỬA (Duyệt) các Tab nghiệp vụ
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_QUANLY', MaChucNang, 1, 1, 1, 0 FROM ChucNang 
WHERE MaChucNang IN ('TAB_CC_DUYETNGHI', 'TAB_TAMUNG', 'TAB_KHENTHUONG');

-- =====================================================================
-- BƯỚC 5: CẤP QUYỀN CHO NHÂN VIÊN THƯỜNG
-- =====================================================================
-- 1. Cho phép XEM Menu Chấm công và Dữ liệu chấm công của mình
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_NHANVIEN', MaChucNang, 1, 0, 0, 0 FROM ChucNang 
WHERE MaChucNang IN ('MENU_CHAMCONG', 'CN_CHAMCONG', 'TAB_CC_DULIEU');

-- 2. Cho phép XEM và THÊM (Nộp) đơn nghỉ phép (Không cho Sửa/Xóa đơn đã duyệt)
INSERT INTO PhanQuyen (MaNhomQuyen, MaChucNang, QuyenXem, QuyenThem, QuyenSua, QuyenXoa)
SELECT 'NQ_NHANVIEN', MaChucNang, 1, 1, 0, 0 FROM ChucNang 
WHERE MaChucNang = 'TAB_CC_DUYETNGHI';
GO