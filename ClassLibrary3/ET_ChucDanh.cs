using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_ChucDanh
    {
        private string maChucDanh;
        private string tenChucDanh;
        private string capBac;

        public ET_ChucDanh(string maChucDanh, string tenChucDanh, string capBac)
        {
            this.MaChucDanh = maChucDanh;
            this.TenChucDanh = tenChucDanh;
            this.CapBac = capBac;
        }
        public ET_ChucDanh() 
        {

        }

        public string MaChucDanh { get => maChucDanh; set => maChucDanh = value; }
        public string TenChucDanh { get => tenChucDanh; set => tenChucDanh = value; }
        public string CapBac { get => capBac; set => capBac = value; }
    }
}
