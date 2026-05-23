using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;
using ClassLibrary3;

namespace ClassLibrary1
{
    public class BUS_TuyenDung
    {
        DAL_TuyenDung dalTD = new DAL_TuyenDung();

        // 1. HÀM HIỂN THỊ (Lấy Entity từ DAL chuyển thành List ET đưa lên Form)
        public List<ET_TuyenDung> LayDanhSachLenGrid()
        {
            var data = dalTD.LayDanhSachLenGrid();

            return data.Select(td => new ET_TuyenDung
            {
                MaTuyenDung = td.MaTuyenDung,
                MaPhongBan = td.MaPhongBan,
                MaChucDanh = td.MaChucDanh,
                SoLuongCanTuyen = td.SoLuongCanTuyen,
                HanChotNopHoSo = td.HanChotNopHoSo,
                MucLuongDuKien = td.MucLuongDuKien,
                TrangThai = td.TrangThai
            }).ToList();
        }

        // 2. HÀM THÊM VỊ TRÍ TUYỂN DỤNG
        public bool ThemTuyenDung(ET_TuyenDung et)
        {
            ViTriTuyenDung td = new ViTriTuyenDung
            {
                MaTuyenDung = et.MaTuyenDung,
                MaPhongBan = et.MaPhongBan,
                MaChucDanh = et.MaChucDanh,
                SoLuongCanTuyen = et.SoLuongCanTuyen,
                HanChotNopHoSo = et.HanChotNopHoSo,
                MucLuongDuKien = et.MucLuongDuKien,
                TrangThai = et.TrangThai
            };

            return dalTD.ThemTuyenDung(td);
        }

        // 3. HÀM SỬA VỊ TRÍ TUYỂN DỤNG
        public bool SuaTuyenDung(ET_TuyenDung et)
        {
            ViTriTuyenDung td = new ViTriTuyenDung
            {
                MaTuyenDung = et.MaTuyenDung,
                MaPhongBan = et.MaPhongBan,
                MaChucDanh = et.MaChucDanh,
                SoLuongCanTuyen = et.SoLuongCanTuyen,
                HanChotNopHoSo = et.HanChotNopHoSo,
                MucLuongDuKien = et.MucLuongDuKien,
                TrangThai = et.TrangThai
            };

            return dalTD.SuaTuyenDung(td);
        }
    }
}
