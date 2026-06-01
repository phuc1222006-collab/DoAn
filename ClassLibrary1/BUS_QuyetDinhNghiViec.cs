using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using DAL;
using ET;

namespace BUS
{
    public class BUS_QuyetDinhNghiViec
    {
        private DAL_QuyetDinhNghiViec dalNghiViec = new DAL_QuyetDinhNghiViec();

        public ET_QuyetDinhNghiViec LayThongTinNghiViec(string maNV)
        {
            return dalNghiViec.LayThongTinNghiViec(maNV);
        }

        public List<ET_QuyetDinhNghiViec> LayToanBoDanhSach()
        {
            return dalNghiViec.LayToanBoDanhSach();
        }

        public bool ThemQuyetDinh(ET_QuyetDinhNghiViec etQuyetDinh)
        {
            return dalNghiViec.ThemQuyetDinh(etQuyetDinh);
        }

        public bool SuaQuyetDinh(ET_QuyetDinhNghiViec etQuyetDinh)
        {
            return dalNghiViec.SuaQuyetDinh(etQuyetDinh);
        }

        public bool XoaQuyetDinh(string maQuyetDinh)
        {
            return dalNghiViec.XoaQuyetDinh(maQuyetDinh);
        }
    }
}