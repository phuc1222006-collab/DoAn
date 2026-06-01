using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_KhenThuong
    {
        private string maQuyetDinh;
        private string maNhanVien;
        private string loaiQuyetDinh;
        private DateTime? ngayQuyetDinh;
        private string lyDo;
        private string nguoiQuyetDinh;
        private decimal? soTien;

        public ET_KhenThuong()
        {
           
        }
        public ET_KhenThuong(string maQuyetDinh, string maNhanVien, string loaiQuyetDinh, DateTime? ngayQuyetDinh, string lyDo, string nguoiQuyetDinh, decimal? soTien)
        {
            this.MaQuyetDinh = maQuyetDinh;
            this.MaNhanVien = maNhanVien;
            this.LoaiQuyetDinh = loaiQuyetDinh;
            this.NgayQuyetDinh = ngayQuyetDinh;
            this.LyDo = lyDo;
            this.nguoiQuyetDinh = nguoiQuyetDinh;
            this.soTien = soTien;
        }

        public string MaQuyetDinh { get => maQuyetDinh; set => maQuyetDinh = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string LoaiQuyetDinh { get => loaiQuyetDinh; set => loaiQuyetDinh = value; }
        public DateTime? NgayQuyetDinh { get => ngayQuyetDinh; set => ngayQuyetDinh = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public string NguoiQuyetDinh { get => nguoiQuyetDinh; set => nguoiQuyetDinh = value; }
        public decimal? SoTien { get => soTien; set => soTien = value; }
    }
}

        
