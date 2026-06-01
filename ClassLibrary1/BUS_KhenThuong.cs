using ClassLibrary2;
using ClassLibrary3;
using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KhenThuong
    {
        DAL_KhenThuong khenthuong = new DAL_KhenThuong();

        public List<ET_KhenThuong> LayDanhSachKhenThuong()
        {
            var data = khenthuong.LayDanhSachLenGrid();

            return data.Select(td => new ET_KhenThuong
            {
                MaQuyetDinh = td.MaQuyetDinh,
                MaNhanVien = td.MaNhanVien,
                LoaiQuyetDinh = td.LoaiQuyetDinh,
                NgayQuyetDinh = td.NgayQuyetDinh,
                LyDo = td.LyDo,
                NguoiQuyetDinh = td.NguoiQuyetDinh,
                SoTien = td.SoTien
            }).ToList();
        }

        // ĐÃ SỬA CHÍNH TẢ: Đổi từ ThemKenThuong thành ThemKhenThuong (thêm chữ H)
        public bool ThemKhenThuong(ET_KhenThuong et)
        {
            try
            {
                KhenThuongKyLuat uv = new KhenThuongKyLuat
                {
                    MaQuyetDinh = et.MaQuyetDinh,
                    MaNhanVien = et.MaNhanVien,
                    LoaiQuyetDinh = et.LoaiQuyetDinh,
                    NgayQuyetDinh = et.NgayQuyetDinh,
                    LyDo = et.LyDo,
                    NguoiQuyetDinh = et.NguoiQuyetDinh,
                    SoTien = et.SoTien
                };

                return khenthuong.ThemKhenThuong(uv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SuaKhenThuong(ET_KhenThuong et)
        {
            try
            {
                // ĐÃ SỬA CỰC KỲ QUAN TRỌNG: Bổ sung đầy đủ thông tin LoaiQuyetDinh và NgayQuyetDinh
                // để tránh việc Entity Framework/SQL cập nhật giá trị NULL hoặc lỗi ràng buộc dữ liệu
                KhenThuongKyLuat uv = new KhenThuongKyLuat
                {
                    MaQuyetDinh = et.MaQuyetDinh,
                    MaNhanVien = et.MaNhanVien,
                    LoaiQuyetDinh = et.LoaiQuyetDinh, // Đã bổ sung
                    NgayQuyetDinh = et.NgayQuyetDinh, // Đã bổ sung
                    LyDo = et.LyDo,
                    SoTien = et.SoTien,
                    NguoiQuyetDinh = et.NguoiQuyetDinh
                };

                return khenthuong.SuaKhenThuong(uv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}