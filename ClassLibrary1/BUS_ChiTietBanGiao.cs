using DAL;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ChiTietBanGiao
    {

        // 1. Đổi tên biến cho đúng chuẩn, tránh nhầm lẫn
        DAL_ChiTietBanGiao banggiao = new DAL_ChiTietBanGiao();

        public List<ET_ChiTietBanGiao> LayDanhSachBanGiao()
        {
            var data = banggiao.layDanhSachChiTietBanGiap();

            return data.Select(td => new ET_ChiTietBanGiao
            {
                MaBanGiao = td.MaBanGiao,
                MaQuyetDinh= td.MaQuyetDinh,
                HangMucBanGiao = td.HangMucBanGiao,
                NguoiNhanBanGiao = td.NguoiNhanBanGiao,
                TrangThai = td.TrangThai,
               GhiChu  = td.GhiChu
            }).ToList();
        }

        // 2. Đổi hàm ThemChiNhanh thành ThemCaLam và truyền đúng Entity
        public bool ThemBanGiao(ET_ChiTietBanGiao et)
        {
            try
            {
                // 3. Khởi tạo đối tượng CaLam (Giả định Entity class trong DAL của bạn tên là CaLam)
               ChiTietBanGiao cl = new ChiTietBanGiao
                {

                    MaBanGiao = et.MaBanGiao,
                    MaQuyetDinh = et.MaQuyetDinh,
                    HangMucBanGiao = et.HangMucBanGiao,
                    NguoiNhanBanGiao = et.NguoiNhanBanGiao,
                    TrangThai = et.TrangThai,
                    GhiChu = et.GhiChu
                };

                // Gọi phương thức DAL để thêm vào database (Bạn nhớ kiểm tra lại tên hàm bên DAL nhé)
                return banggiao.ThemChiTietBanGiao(cl);
            }
            catch (Exception ex)
            {
                // Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
