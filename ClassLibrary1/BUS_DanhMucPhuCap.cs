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
    public class BUS_DanhMucPhuCap
    {
        DAL_DanhMucPhuCap pc = new DAL_DanhMucPhuCap();
        public List<ET_DanhMucPhuCap> layDanhSachPhucap()
        {
            var data = pc.layDanhSachPhuCap();

            return data.Select(td => new ET_DanhMucPhuCap
            {
                MaPhuCap = td.MaPhuCap,
                TenPhuCap = td.TenPhuCap,
                MucPhuCap = td.MucTien,
            }).ToList();
        }
        public bool ThemDanhMucPHuCap(ET_DanhMucPhuCap et)
        {
            try
            {
                DanhMucPhuCap uv = new DanhMucPhuCap
                {
                    MaPhuCap = et.MaPhuCap,
                    TenPhuCap = et.TenPhuCap,
                    MucTien = et.MucPhuCap,
                   
                };

                // Gọi phương thức DAL để thêm vào database
                return pc.ThemDanhMucPhuCap(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
