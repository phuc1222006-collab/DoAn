using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_ChiNhanh
    {
        private string maChiNhanh;
        private string tenChiNhanh;
        private string diaChi;
        private string hotline;
        private string maNguoiDungDau;

        public ET_ChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi, string hotline, string maNguoiDungDau)
        {
            this.MaChiNhanh = maChiNhanh;
            this.TenChiNhanh = tenChiNhanh;
            this.DiaChi = diaChi;
            this.Hotline = hotline;
            this.MaNguoiDungDau = maNguoiDungDau;
        }
        public ET_ChiNhanh()
        {
           
        }

        public string MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string TenChiNhanh { get => tenChiNhanh; set => tenChiNhanh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Hotline { get => hotline; set => hotline = value; }
        public string MaNguoiDungDau { get => maNguoiDungDau; set => maNguoiDungDau = value; }
    }
}
