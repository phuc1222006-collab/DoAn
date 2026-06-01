using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_HoSoCongTac
    {
        private string maCongTac;
        private string maNhanVien;
        private string DiaDiem;

        // ĐÃ SỬA: Đổi TimeSpan? thành DateTime?
        private DateTime? tuNgay;
        private DateTime? denNgay;

        private string mucDich;
        private decimal? chiPhiDuKien;
        private string TrangThaiDuyet;

        // ĐÃ SỬA: Cập nhật lại kiểu dữ liệu trong tham số của Constructor
        public ET_HoSoCongTac(string maCongTac, string maNhanVien, string diaDiem, DateTime? tuNgay, DateTime? denNgay, string mucDich, decimal? chiPhiDuKien, string trangThaiDuyet)
        {
            this.MaCongTac = maCongTac;
            this.MaNhanVien = maNhanVien;
            DiaDiem1 = diaDiem;
            this.TuNgay = tuNgay;
            this.DenNgay = denNgay;
            this.MucDich = mucDich;
            this.ChiPhiDuKien = chiPhiDuKien;
            TrangThaiDuyet1 = trangThaiDuyet;
        }

        public ET_HoSoCongTac()
        {

        }

        public string MaCongTac { get => maCongTac; set => maCongTac = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string DiaDiem1 { get => DiaDiem; set => DiaDiem = value; }

        // ĐÃ SỬA: Cập nhật lại kiểu dữ liệu của Properties
        public DateTime? TuNgay { get => tuNgay; set => tuNgay = value; }
        public DateTime? DenNgay { get => denNgay; set => denNgay = value; }

        public string MucDich { get => mucDich; set => mucDich = value; }
        public decimal? ChiPhiDuKien { get => chiPhiDuKien; set => chiPhiDuKien = value; }
        public string TrangThaiDuyet1 { get => TrangThaiDuyet; set => TrangThaiDuyet = value; }
    }
}