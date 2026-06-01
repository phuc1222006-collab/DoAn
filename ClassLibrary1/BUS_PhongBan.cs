using DAL;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_PhongBan
    {
        DAL_PhongBan phongban = new DAL_PhongBan();

        public List<ET_PhongBan> LayDanhSachPhongBan()
        {
            var data = phongban.LayDanhSachPhongBan();

            return data.Select(td => new ET_PhongBan
            {
                MaPhongBan = td.MaPhongBan,
                MaChiNhanh = td.MaChiNhanh,
                TenPhongBan = td.TenPhongBan,
                MaPhongBanCha = td.MaPhongBanCha,
                MaTruongPhong = td.MaTruongPhong,
               
            }).ToList();
        }

        public bool ThemPhongban(ET_PhongBan et)
        {
            try
            {
                PhongBan uv = new PhongBan
                {
                    MaPhongBan = et.MaPhongBan,
                    MaChiNhanh = et.MaChiNhanh,
                    TenPhongBan = et.TenPhongBan,
                    MaPhongBanCha = et.MaPhongBanCha,
                    MaTruongPhong = et.MaTruongPhong,

                };

                // Gọi phương thức DAL để thêm vào database
                return phongban.ThemPhongBan(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
