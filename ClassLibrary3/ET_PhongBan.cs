using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_PhongBan
    {
        private string maPhongBan;
        private string maChiNhanh;
        private string tenPhongBan;
        private string maPhongBanCha;
        private string maTruongPhong;

        public ET_PhongBan(string maPhongBan, string maChiNhanh, string tenPhongBan, string maPhongBanCha, string maTruongPhong)
        {
            this.MaPhongBan = maPhongBan;
            this.MaChiNhanh = maChiNhanh;
            this.TenPhongBan = tenPhongBan;
            this.MaPhongBanCha = maPhongBanCha;
            this.MaTruongPhong = maTruongPhong;
        }
        public ET_PhongBan()
        {
           
        }

        public string MaPhongBan { get => maPhongBan; set => maPhongBan = value; }
        public string MaChiNhanh { get => maChiNhanh; set => maChiNhanh = value; }
        public string TenPhongBan { get => tenPhongBan; set => tenPhongBan = value; }
        public string MaPhongBanCha { get => maPhongBanCha; set => maPhongBanCha = value; }
        public string MaTruongPhong { get => maTruongPhong; set => maTruongPhong = value; }
    }
}
