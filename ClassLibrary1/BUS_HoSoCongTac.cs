using DAL;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BUS
{
    public class BUS_HoSoCongTac
    {
        // 1. ĐÃ SỬA: Đổi tên biến từ 'chinhanh' thành 'dalHoSo' cho đúng ý nghĩa
        DAL_HoSoCongTac dalHoSo = new DAL_HoSoCongTac();

        public List<ET_HoSoCongTac> LayDanhSachHoSoCongTac()
        {
            var data = dalHoSo.layDanhSachHoSoCongTac();

            return data.Select(td => new ET_HoSoCongTac
            {
                MaCongTac = td.MaCongTac,
                MaNhanVien = td.MaNhanVien,
                DiaDiem1 = td.DiaDiem,

                // ĐÃ SỬA: Thêm .GetValueOrDefault() để khắc phục triệt để lỗi CS0266
                TuNgay = td.TuNgay.GetValueOrDefault(),
                DenNgay = td.DenNgay.GetValueOrDefault(),

                TrangThaiDuyet1 = td.TrangThaiDuyet
            }).ToList();
        }

        // 2. ĐÃ SỬA: Thay thế hàm ThemChiNhanh bằng hàm ThemHoSoCongTac
        public bool ThemHoSoCongTac(ET_HoSoCongTac et)
        {
            try
            {
                // Map dữ liệu từ Entity (ET_HoSoCongTac) sang đối tượng của Entity Framework (HoSoCongTac)
                HoSoCongTac hs = new HoSoCongTac
                {
                    MaCongTac = et.MaCongTac,
                    MaNhanVien = et.MaNhanVien,
                    DiaDiem = et.DiaDiem1, // Chú ý mapping đúng tên cột
                    TuNgay = et.TuNgay,
                    DenNgay = et.DenNgay,
                    TrangThaiDuyet = et.TrangThaiDuyet1
                };

                // Gọi phương thức DAL để thêm vào database 
                return dalHoSo.ThemHoSoCongTac(hs);
            }
            catch (Exception ex)
            {
                // Ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}