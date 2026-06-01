using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_ChamCong
    {
        public int? ID { get; set; }

        public string MaNhanVien { get; set; }

        public DateTime? NgayChamCong { get; set; }

        public string MaCa { get; set; }

        // Sử dụng TimeSpan hoặc DateTime tùy thuộc vào kiểu dữ liệu trong SQL
        public TimeSpan? GioVao { get; set; }

        public TimeSpan? GioRa { get; set; }

        public Decimal SoGioOT { get; set; } = 0;

        public string MaHinhThuc { get; set; }

        public string TrangThai { get; set; }
    }
}
