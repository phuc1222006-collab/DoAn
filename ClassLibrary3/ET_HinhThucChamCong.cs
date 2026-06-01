using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_HinhThucChamCong
    {
        private string maHinhThuc;
        private string tenHinhThuc;

        public ET_HinhThucChamCong(string maHinhThuc, string tenHinhThuc)
        {
            this.MaHinhThuc = maHinhThuc;
            this.TenHinhThuc = tenHinhThuc;
        }
        public ET_HinhThucChamCong()
        {
            
        }

        public string MaHinhThuc { get => maHinhThuc; set => maHinhThuc = value; }
        public string TenHinhThuc { get => tenHinhThuc; set => tenHinhThuc = value; }
    }
}
