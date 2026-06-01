using DAL;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ChiNhanh
    {
        DAL_ChiNhanh chinhanh = new DAL_ChiNhanh();

        public List<ET_ChiNhanh> LayDanhSachChiNhanh()
        {
            var data = chinhanh.layDanhSachChiNhanh();

            return data.Select(td => new ET_ChiNhanh
            {
                MaChiNhanh = td.MaChiNhanh,
                TenChiNhanh = td.TenChiNhanh,
                DiaChi = td.DiaChi,
                Hotline = td.Hotline,
                MaNguoiDungDau = td.MaNguoiDungDau,

            }).ToList();
        }
        public bool ThemChiNhanh(ET_ChiNhanh et)
        {
            try
            {
                ChiNhanh uv = new ChiNhanh                {
                    MaChiNhanh = et.MaChiNhanh,
                    TenChiNhanh = et.TenChiNhanh,
                    DiaChi = et.DiaChi,
                    Hotline = et.Hotline,
                    MaNguoiDungDau = et.MaNguoiDungDau
                };

                // Gọi phương thức DAL để thêm vào database
                return chinhanh.ThemChiNhanh(uv);
            }
            catch (Exception ex)
            {
                // ĐÃ SỬA: Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
