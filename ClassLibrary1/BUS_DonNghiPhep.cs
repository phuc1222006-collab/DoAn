using DAL;
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DonNghiPhep
    {
        DAL_DonNghiPhep nghiphep = new DAL_DonNghiPhep();
        public List<ET_DonNghiPhep> LayDanhSachDonNghi()
        {
            var data = nghiphep.layDanhSachDonNghiPhep();

            return data.Select(td => new ET_DonNghiPhep
            {
                MaDon = td.MaDon,
                MaNhanVien = td.MaNhanVien,
                LoaiNghiPhep = td.LoaiNghiPhep,
                TuNgay = td.TuNgay,
                DenNgay = td.DenNgay,
                LyDo = td.LyDo,
                TrangThaiDuyet = td.TrangThaiDuyet
            }).ToList();
        }

        // 2. Đổi hàm ThemChiNhanh thành ThemCaLam và truyền đúng Entity
        public bool ThemDonNghiPhep(ET_DonNghiPhep et)
        {
            try
            {
                // 3. Khởi tạo đối tượng CaLam (Giả định Entity class trong DAL của bạn tên là CaLam)
                DonNghiPhep cl = new DonNghiPhep
                {
                    MaDon = et.MaDon,
                    MaNhanVien = et.MaNhanVien,
                    LoaiNghiPhep = et.LoaiNghiPhep,
                    TuNgay = et.TuNgay,
                    DenNgay = et.DenNgay,
                    LyDo = et.LyDo,
                    TrangThaiDuyet = et.TrangThaiDuyet
                };

                // Gọi phương thức DAL để thêm vào database (Bạn nhớ kiểm tra lại tên hàm bên DAL nhé)
                return nghiphep.ThemDonNghiPhep(cl);
            }
            catch (Exception ex)
            {
                // Ép hệ thống ném thẳng lỗi gốc lên tầng Form để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }
    }
}
