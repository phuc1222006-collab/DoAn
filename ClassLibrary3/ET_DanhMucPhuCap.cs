using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_DanhMucPhuCap
    {
        private string maPhuCap;
        private string tenPhuCap;
        private decimal? mucPhuCap;

        public ET_DanhMucPhuCap(string maPhuCap, string tenPhuCap, decimal? mucPhuCap)
        {
            this.MaPhuCap = maPhuCap;
            this.TenPhuCap = tenPhuCap;
            this.MucPhuCap = mucPhuCap;
        }
        public ET_DanhMucPhuCap()
        {

        }

        public string MaPhuCap { get => maPhuCap; set => maPhuCap = value; }
        public string TenPhuCap { get => tenPhuCap; set => tenPhuCap = value; }
        public decimal? MucPhuCap { get => mucPhuCap; set => mucPhuCap = value; }
    }
}
