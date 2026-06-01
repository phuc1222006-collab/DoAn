using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3;

namespace DAL
{
    public class DAL_Phanquyen
    {
        // Hàm 1: Lấy dữ liệu phân quyền bằng cú pháp LINQ (Left Join)
        public List<ET_Phanquyen> LayPhanQuyen(string maNhomQuyen)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            var query = from c in db.ChucNangs
                            // LEFT JOIN sang bảng PhanQuyen
                        join p in db.PhanQuyens.Where(x => x.MaNhomQuyen == maNhomQuyen)
                        on c.MaChucNang equals p.MaChucNang into GroupQuyen
                        from pq in GroupQuyen.DefaultIfEmpty()
                        select new ET_Phanquyen
                        {
                            MaChucNang = c.MaChucNang,
                            TenChucNang = c.TenChucNang,
                            MaChucNangCha = c.MaChucNangCha,
                            // Nếu chưa có quyền (pq == null) thì mặc định là false
                            QuyenXem = pq != null ? (pq.QuyenXem ?? false) : false,
                            QuyenThem = pq != null ? (pq.QuyenThem ?? false) : false,
                            QuyenSua = pq != null ? (pq.QuyenSua ?? false) : false,
                            QuyenXoa = pq != null ? (pq.QuyenXoa ?? false) : false
                        };

            return query.ToList();
        }

        // Hàm 2: Lưu danh sách quyền xuống CSDL bằng LINQ
        public bool LuuPhanQuyen(string maNhomQuyen, List<ET_Phanquyen> danhSachQuyen)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            try
            {
                foreach (var item in danhSachQuyen)
                {
                    // Tìm xem quyền này đã tồn tại trong DB chưa
                    var pq = db.PhanQuyens.FirstOrDefault(x => x.MaNhomQuyen == maNhomQuyen && x.MaChucNang == item.MaChucNang);

                    if (pq != null)
                    {
                        // Đã có -> Cập nhật (UPDATE)
                        pq.QuyenXem = item.QuyenXem;
                        pq.QuyenThem = item.QuyenThem;
                        pq.QuyenSua = item.QuyenSua;
                        pq.QuyenXoa = item.QuyenXoa;
                    }
                    else
                    {
                        // Chưa có -> Thêm mới (INSERT)
                        PhanQuyen moi = new PhanQuyen
                        {
                            MaNhomQuyen = maNhomQuyen,
                            MaChucNang = item.MaChucNang,
                            QuyenXem = item.QuyenXem,
                            QuyenThem = item.QuyenThem,
                            QuyenSua = item.QuyenSua,
                            QuyenXoa = item.QuyenXoa
                        };
                        db.PhanQuyens.InsertOnSubmit(moi);
                    }
                }

                // Commit tất cả thay đổi xuống DB cùng 1 lúc
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
