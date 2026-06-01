using DAL;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CaLam
    {
        // 1. Đổi tên biến cho đúng chuẩn, tránh nhầm lẫn
        DAL_CaLam dalCaLam = new DAL_CaLam();

        public List<ET_CaLam> LayDanhSachCaLam()
        {
            var data = dalCaLam.layDanhSachCaLam();

            return data.Select(td => new ET_CaLam
            {
                MaCa = td.MaCa,
                TenCa = td.TenCa,
                GioBatDau = td.GioBatDau,  
                GioKetThuc = td.GioKetThuc
            }).ToList();
        }

        // 2. Đổi hàm ThemChiNhanh thành ThemCaLam và truyền đúng Entity
        public bool ThemCaLam(ET_CaLam et)
        {
            try
            {
                // 3. Khởi tạo đối tượng CaLam (Giả định Entity class trong DAL của bạn tên là CaLam)
                CaLamViec cl = new CaLamViec
                {
                    MaCa = et.MaCa,
                    TenCa = et.TenCa,
                    GioBatDau = et.GioBatDau,
                    GioKetThuc = et.GioKetThuc
                };

                // Gọi phương thức DAL để thêm vào database (Bạn nhớ kiểm tra lại tên hàm bên DAL nhé)
                return dalCaLam.ThemCaLam(cl);
            }
            catch (Exception ex)
            {
                // Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}