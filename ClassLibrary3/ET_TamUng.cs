using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_TamUng
    {
        
        public string MaTamUng { get; set; }

        
        public string MaNhanVien { get; set; }

        public DateTime? NgayTamUng { get; set; }

       
        public string LyDo { get; set; }

      
        public decimal SoTien { get; set; }

      
        public byte? TrangThai { get; set; }

        public int? ThangKhauTru { get; set; }
        public int? NamKhauTru { get; set; }
        public string NguoiDuyet { get; set; }

        // Mối quan hệ với bảng NhanVien
    }
}
