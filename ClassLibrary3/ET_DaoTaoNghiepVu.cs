using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_DaoTaoNghiepVu
    {
        public string MaDaoTao { get; set; }
        public string MaNhanVien { get; set; }
        public string TenKhoaDaoTao { get; set; }
        public string TenNhanVien { get; set; }//hiển thị lên 
        public string NguoiHuongDan { get; set; } //lấy mã
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string KetQuaDanhGia { get; set; }
    }
}
