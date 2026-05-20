using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using ET;
namespace BUS
{
    public class BUS_ChiTietNhanVien
    {
        DAL_ChiTietNhanVien dAL_ChiTietNhanVien = new DAL_ChiTietNhanVien();
        //lấy ds
        public IQueryable LayDanhSachLenGrid()
        {
            return dAL_ChiTietNhanVien.LayDanhSachLenGrid();
        }

        // Lấy chi tiết nhân viên
        public IQueryable LayChiTietNhanVien(string maNV)
        {
            return dAL_ChiTietNhanVien.LayChiTietNhanVien(maNV);
        }
    }
}
