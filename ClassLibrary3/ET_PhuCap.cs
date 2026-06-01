using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_PhuCap
    {
        private string maNhanVien;
        private string maPhuCap;
        private DateTime ngayPhuCap;
        private string lyDoCap;

        public ET_PhuCap(string maNhanVien, string maPhuCap, DateTime ngayPhuCap, string lyDoCap)
        {
            this.MaNhanVien = maNhanVien;
            this.MaPhuCap = maPhuCap;
            this.NgayPhuCap = ngayPhuCap;
            this.LyDoCap = lyDoCap;
        }
        public ET_PhuCap()
        {
            
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaPhuCap { get => maPhuCap; set => maPhuCap = value; }
        public DateTime NgayPhuCap { get => ngayPhuCap; set => ngayPhuCap = value; }
        public string LyDoCap { get => lyDoCap; set => lyDoCap = value; }
    }
}
