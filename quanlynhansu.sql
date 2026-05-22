CREATE DATABASE QuanLyNhanSu;
GO
USE QuanLyNhanSu;
GO

-- =====================================================================
-- NHÓM 1: CÁC BẢNG DANH MỤC GỐCS
-- =====================================================================

CREATE TABLE ChiNhanh (
    MaChiNhanh VARCHAR(20) PRIMARY KEY,
    TenChiNhanh NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    Hotline VARCHAR(20),
    MaNguoiDungDau VARCHAR(20) 
);

CREATE TABLE ChucDanh (
    MaChucDanh VARCHAR(20) PRIMARY KEY,
    TenChucDanh NVARCHAR(100) NOT NULL,
    CapBac NVARCHAR(50) 
);

CREATE TABLE CaLamViec (
    MaCa VARCHAR(20) PRIMARY KEY,
    TenCa NVARCHAR(100), 
    GioBatDau TIME,
    GioKetThuc TIME
);

CREATE TABLE HinhThucChamCong (
    MaHinhThuc VARCHAR(20) PRIMARY KEY,
    TenHinhThuc NVARCHAR(100) NOT NULL 
);

CREATE TABLE DanhMucPhuCap (
    MaPhuCap VARCHAR(20) PRIMARY KEY,
    TenPhuCap NVARCHAR(100), 
    MucTien DECIMAL(18,2)
);

CREATE TABLE NhomQuyen (
    MaNhomQuyen VARCHAR(20) PRIMARY KEY,
    TenNhomQuyen NVARCHAR(100) NOT NULL, 
    MoTa NVARCHAR(255)
);

-- =====================================================================
-- NHÓM 2: CÁC BẢNG CƠ SỞ CHÍNH
-- =====================================================================

CREATE TABLE PhongBan (
    MaPhongBan VARCHAR(20) PRIMARY KEY,
    MaChiNhanh VARCHAR(20),
    TenPhongBan NVARCHAR(100) NOT NULL,
    MaPhongBanCha VARCHAR(20), 
    MaTruongPhong VARCHAR(20), -- Sẽ tạo FK sau khi có bảng NhanVien
    FOREIGN KEY (MaChiNhanh) REFERENCES ChiNhanh(MaChiNhanh)
);

CREATE TABLE ViTriTuyenDung (
    MaTuyenDung VARCHAR(20) PRIMARY KEY,
    MaPhongBan VARCHAR(20),
    MaChucDanh VARCHAR(20),
    SoLuongCanTuyen INT,
    HanChotNopHoSo DATE,
    MucLuongDuKien NVARCHAR(100),
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaChucDanh) REFERENCES ChucDanh(MaChucDanh)
);

CREATE TABLE UngVien (
    MaUngVien VARCHAR(20) PRIMARY KEY,
    MaTuyenDung VARCHAR(20),
    HoTen NVARCHAR(100),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    LinkCV VARCHAR(255),
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaTuyenDung) REFERENCES ViTriTuyenDung(MaTuyenDung)
);

CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    MaPhongBan VARCHAR(20),
    MaChucDanh VARCHAR(20),
    TrangThaiLamViec NVARCHAR(50) DEFAULT N'Đang làm việc',
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaChucDanh) REFERENCES ChucDanh(MaChucDanh)
);

-- =====================================================================
-- NHÓM 3: CÁC BẢNG NGHIỆP VỤ
-- =====================================================================

CREATE TABLE ChiTietNhanVien (
    MaNhanVien VARCHAR(20) PRIMARY KEY,
    SoDienThoai VARCHAR(15),
    EmailCaNhan VARCHAR(100),
    EmailCongTy VARCHAR(100) UNIQUE,
    DiaChiThuongTru NVARCHAR(255),
    SoCCCD VARCHAR(12) UNIQUE NOT NULL,
    NgayCapCCCD DATE,
    NoiCapCCCD NVARCHAR(100),
    MaSoThue VARCHAR(14) UNIQUE,
    SoTaiKhoan VARCHAR(20),
    TenNganHang NVARCHAR(100),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE HopDongLaoDong (
    SoHopDong VARCHAR(50) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    LoaiHopDong NVARCHAR(100), 
    NgayKy DATE,
    NgayHieuLuc DATE,
    NgayHetHan DATE,
    LuongCung DECIMAL(18,2) NOT NULL, 
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng TamUng (Đã chỉnh sửa ngắn gọn, thực tế)
CREATE TABLE TamUng (
    MaTamUng VARCHAR(20) PRIMARY KEY,
    MaNhanVien VARCHAR(20) NOT NULL,
    NgayTamUng DATE DEFAULT GETDATE(),
    SoTien DECIMAL(18,2) NOT NULL,
    LyDo NVARCHAR(255),
    -- Trạng thái: 0: Chờ duyệt, 1: Đã chi tiền, 2: Đã khấu trừ vào lương, 3: Từ chối
    TrangThai TINYINT DEFAULT 0, 
    ThangKhauTru INT,
    NamKhauTru INT,
    NguoiDuyet VARCHAR(20),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (NguoiDuyet) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE DataChamCong (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    NgayChamCong DATE,
    MaCa VARCHAR(20),
    GioVao TIME,
    GioRa TIME,
    SoGioOT DECIMAL(4,2), 
    MaHinhThuc VARCHAR(20),
    TrangThai NVARCHAR(50), 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa),
    FOREIGN KEY (MaHinhThuc) REFERENCES HinhThucChamCong(MaHinhThuc)
);

CREATE TABLE DonNghiPhep (
    MaDon VARCHAR(20) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    LoaiNghiPhep NVARCHAR(50), 
    TuNgay DATETIME,
    DenNgay DATETIME,
    LyDo NVARCHAR(255),
    TrangThaiDuyet NVARCHAR(50), 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE DanhGiaKPI (
    MaDanhGia VARCHAR(20) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    ThangDanhGia INT,
    NamDanhGia INT,
    DiemSo DECIMAL(5,2), 
    XepLoai NVARCHAR(50), 
    NhanXet NVARCHAR(500),
    MaNguoiDanhGia VARCHAR(20), 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNguoiDanhGia) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE KhenThuongKyLuat (
    MaQuyetDinh VARCHAR(20) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    LoaiQuyetDinh NVARCHAR(50), 
    NgayQuyetDinh DATE,
    LyDo NVARCHAR(255),
    SoTien DECIMAL(18,2) DEFAULT 0,
    NguoiQuyetDinh VARCHAR(20),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE PhuCapNhanVien (
    MaNhanVien VARCHAR(20),
    MaPhuCap VARCHAR(20),
    NgayCapTien DATE,
    LyDoCap NVARCHAR(255),
    PRIMARY KEY (MaNhanVien, MaPhuCap, NgayCapTien),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaPhuCap) REFERENCES DanhMucPhuCap(MaPhuCap)
);

CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MaNhanVien VARCHAR(20) UNIQUE NOT NULL, 
    MatKhau VARCHAR(255) NOT NULL, 
    MaNhomQuyen VARCHAR(20),
    TrangThaiHoatDong BIT DEFAULT 1, 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaNhomQuyen) REFERENCES NhomQuyen(MaNhomQuyen)
);

CREATE TABLE QuyetDinhNghiViec (
    MaQuyetDinh VARCHAR(20) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    NgayNopDon DATE,
    NgayNghiChinhThuc DATE,
    LyDoNghi NVARCHAR(500),
    TrangThaiBanGiao NVARCHAR(50), 
    NguoiDuyet VARCHAR(20),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- =====================================================================
-- BƯỚC CUỐI: RÀNG BUỘC THAM CHIẾU VÒNG
-- =====================================================================
ALTER TABLE PhongBan
ADD CONSTRAINT FK_PhongBan_TruongPhong 
FOREIGN KEY (MaTruongPhong) REFERENCES NhanVien(MaNhanVien);