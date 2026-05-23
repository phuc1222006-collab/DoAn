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
        public List<ET_NhanVien> LayDanhSachLenGrid()
        {
            var data = dAL_NhanVien.LayDanhSachLenGrid();
            return data.Select(nv => new ET_NhanVien
            {
                MaNhanVien = nv.MaNhanVien,
                HoTen = nv.HoTen
                
            }).ToList();
        }
    }
}
