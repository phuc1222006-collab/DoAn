using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_CaLam
    {
        private string maCa;
        private string tenCa;
        private TimeSpan? gioBatDau;
        private TimeSpan? gioKetThuc;

        public ET_CaLam(string maCa, string tenCa, TimeSpan? gioBatDau, TimeSpan? gioKetThuc)
        {
            this.MaCa = maCa;
            this.TenCa = tenCa;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
        }
        public ET_CaLam()
        {
           
        }

        public string MaCa { get => maCa; set => maCa = value; }
        public string TenCa { get => tenCa; set => tenCa = value; }
        public TimeSpan? GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public TimeSpan? GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
    }
}
