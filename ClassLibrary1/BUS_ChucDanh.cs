using ClassLibrary2;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using DAL;
namespace BUS
{
    public class BUS_ChucDanh
    {
        DAL_ChucDanh cd = new DAL_ChucDanh();
        public List<ET_ChucDanh> layDanhSachChucDanh()
        {
            var data = cd.layDanhSachChuDanh();

            return data.Select(td => new ET_ChucDanh
            {
                MaChucDanh = td.MaChucDanh,
                TenChucDanh = td.TenChucDanh,
                CapBac = td.CapBac,
            }).ToList();
        }
        public bool ThemDanhMucChucDanh(ET_ChucDanh et)
        {
            try
            {
                ChucDanh uv = new ChucDanh
                {
                    MaChucDanh = et.MaChucDanh,
                    TenChucDanh = et.TenChucDanh,
                    CapBac = et.CapBac,

                };

                // Gọi phương thức DAL để thêm vào database
                return cd.ThemChucDanh(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
