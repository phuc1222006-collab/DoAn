using DAL;
using ClassLibrary3;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HinhThucChamCong
    {
        DAL_HinhThucChamCong chinhanh = new DAL_HinhThucChamCong();

        public List<ET_HinhThucChamCong> LayDanhSachChamCong()
        {
            var data = chinhanh.layDanhSachChiNhanh();

            return data.Select(td => new ET_HinhThucChamCong
            {
                MaHinhThuc = td.MaHinhThuc,
                TenHinhThuc = td.TenHinhThuc,
                

            }).ToList();
        }
        public bool ThemChiNhanh(ET_HinhThucChamCong et)
        {
            try
            {
                HinhThucChamCong uv = new HinhThucChamCong
                {
                    MaHinhThuc = et.MaHinhThuc,
                    TenHinhThuc = et.TenHinhThuc,
                  
                };

                // Gọi phương thức DAL để thêm vào database
                return chinhanh.ThemHinhThucChamCong(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
