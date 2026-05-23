using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary2; // Chứa DAL_TaiKhoan và LINQ DataContext
using ClassLibrary3.ET.ET;
using ET;            // Chứa ET_TaiKhoan

namespace ClassLibrary1
{
    public class BUS_TaiKhoang
    {
        DAL_TaiKhoan DAL_taikhoang = new DAL_TaiKhoan();

        // --- 1. HÀM HIỂN THỊ (LẤY DỮ LIỆU TỪ DAL LÊN FORM) ---
        public List<ET_TaiKhoan> LayDanhSachLenGrid()
        {
            var data = DAL_taikhoang.LayDanhSachLenGrid();

            // Map từ LINQ Entity sang ET
            return data.Select(tk => new ET_TaiKhoan
            {
                TenDangNhap = tk.TenDangNhap,
                MaNhanVien = tk.MaNhanVien,
                MatKhau = tk.MatKhau,
                MaNhomQuyen = tk.MaNhomQuyen,
                TrangThaiHoatDong = tk.TrangThaiHoatDong
            }).ToList();
        }

        // --- 2. HÀM THÊM TÀI KHOẢN ---
        public bool ThemTaiKhoan(ET_TaiKhoan et)
        {
            TaiKhoan tk = new TaiKhoan
            {
                TenDangNhap = et.TenDangNhap,
                MaNhanVien = et.MaNhanVien,
                MatKhau = et.MatKhau,
                MaNhomQuyen = et.MaNhomQuyen,
                // Lấy giá trị ET, nếu null thì gán mặc định là true (hoạt động)
                TrangThaiHoatDong = et.TrangThaiHoatDong ?? true
            };

            return DAL_taikhoang.ThemTaiKhoan(tk);
        }

        // --- 3. HÀM SỬA TÀI KHOẢN ---
        public bool SuaTaiKhoan(ET_TaiKhoan et)
        {
            TaiKhoan tk = new TaiKhoan
            {
                TenDangNhap = et.TenDangNhap,
                MaNhanVien = et.MaNhanVien,
                MatKhau = et.MatKhau,
                MaNhomQuyen = et.MaNhomQuyen,
                TrangThaiHoatDong = et.TrangThaiHoatDong
            };

            return DAL_taikhoang.SuaTaiKhoan(tk);
        }
    }
}