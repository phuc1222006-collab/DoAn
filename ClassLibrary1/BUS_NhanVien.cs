using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using ET;
using ClassLibrary2;
namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dAL_NhanVien = new DAL_NhanVien();

        //lấy ds
        public IQueryable LayDanhSachLenGrid()
        {
            return dAL_NhanVien.LayDanhSachLenGrid();
        }
    }
}
