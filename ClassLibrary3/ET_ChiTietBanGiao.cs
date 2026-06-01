using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class ET_ChiTietBanGiao
    {
        private string maBanGiao;
        private string maQuyetDinh;
        private string hangMucBanGiao;
        private string nguoiNhanBanGiao;
        private string trangThai;
        private string ghiChu;

        public ET_ChiTietBanGiao(string maBanGiao, string maQuyetDinh, string hangMucBanGiao, string nguoiNhanBanGiao, string trangThai, string ghiChu)
        {
            this.MaBanGiao = maBanGiao;
            this.MaQuyetDinh = maQuyetDinh;
            this.HangMucBanGiao = hangMucBanGiao;
            this.NguoiNhanBanGiao = nguoiNhanBanGiao;
            this.TrangThai = trangThai;
            this.GhiChu = ghiChu;
        }
        public ET_ChiTietBanGiao()
        {
           
        }

        public string MaBanGiao { get => maBanGiao; set => maBanGiao = value; }
        public string MaQuyetDinh { get => maQuyetDinh; set => maQuyetDinh = value; }
        public string HangMucBanGiao { get => hangMucBanGiao; set => hangMucBanGiao = value; }
        public string NguoiNhanBanGiao { get => nguoiNhanBanGiao; set => nguoiNhanBanGiao = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
