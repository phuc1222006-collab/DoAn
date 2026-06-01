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
    public class BUS_PhuCap
    {
        DAL_PhuCap phucap = new DAL_PhuCap();

        public List<ET_PhuCap> LayDanhSachPhuCap()
        {
            var data = phucap.LayDanhSachPhuCap();

            return data.Select(td => new ET_PhuCap
            {
                MaPhuCap = td.MaPhuCap,
                MaNhanVien = td.MaNhanVien,
                NgayPhuCap = td.NgayCapTien,
                LyDoCap = td.LyDoCap,
                
            }).ToList();
        }

        public bool ThemPHuCap(ET_PhuCap et)
        {
            try
            {
                PhuCapNhanVien uv = new PhuCapNhanVien
                {
                    MaPhuCap = et.MaPhuCap,
                    MaNhanVien = et.MaNhanVien,
                    NgayCapTien = et.NgayPhuCap,
                    LyDoCap = et.LyDoCap,
                    
                };

                // Gọi phương thức DAL để thêm vào database
                return phucap.ThemPhuCap(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
        public bool SuaPhuCap(ET_PhuCap et)
        {
            PhuCapNhanVien uv = new PhuCapNhanVien
            {
                MaPhuCap = et.MaPhuCap,
                MaNhanVien = et.MaNhanVien,
                NgayCapTien = et.NgayPhuCap,
                LyDoCap = et.LyDoCap,

            };

            return phucap.SuaPhuCap(uv);
        }
    }
}
