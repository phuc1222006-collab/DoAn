using System;

namespace ClassLibrary3
{
    public class ET_DonNghiPhep
    {
        public string MaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string LoaiNghiPhep { get; set; }

        // Trong SQL bạn để DATETIME, nên C# dùng DateTime? là hợp lý
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }

        public string LyDo { get; set; }
        public string TrangThaiDuyet { get; set; }
    }
}