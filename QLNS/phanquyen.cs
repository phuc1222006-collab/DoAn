using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using ClassLibrary3;

namespace QLNS
{
    public class phanquyen
    {
        // Danh sách chứa toàn bộ quyền của User đang đăng nhập
        public static List<ET_Phanquyen> DanhSachQuyen { get; set; } = new List<ET_Phanquyen>();

        // Hàm này gọi 1 lần duy nhất lúc đăng nhập hoặc load Trang chủ
        public static void TaiQuyen(string maNhomQuyen)
        {
            BUS_Phanquyen busPQ = new BUS_Phanquyen();
            DanhSachQuyen = busPQ.LayMaTranQuyen(maNhomQuyen);
        }

        // Kiểm tra xem User có quyền mở Form (Menu/Chức năng con) hay không?
        public static bool CoQuyenXem(string maChucNang)
        {
            if (DanhSachQuyen == null || DanhSachQuyen.Count == 0) return false;
            var quyen = DanhSachQuyen.FirstOrDefault(x => x.MaChucNang == maChucNang);
            return quyen != null && quyen.QuyenXem;
        }

        // Kiểm tra quyền Thêm
        public static bool CoQuyenThem(string maChucNang)
        {
            var quyen = DanhSachQuyen.FirstOrDefault(x => x.MaChucNang == maChucNang);
            return quyen != null && quyen.QuyenThem;
        }

        // Kiểm tra quyền Sửa
        public static bool CoQuyenSua(string maChucNang)
        {
            var quyen = DanhSachQuyen.FirstOrDefault(x => x.MaChucNang == maChucNang);
            return quyen != null && quyen.QuyenSua;
        }

        // Kiểm tra quyền Xóa
        public static bool CoQuyenXoa(string maChucNang)
        {
            var quyen = DanhSachQuyen.FirstOrDefault(x => x.MaChucNang == maChucNang);
            return quyen != null && quyen.QuyenXoa;
        }
    }
}
