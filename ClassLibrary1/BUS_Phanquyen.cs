using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary3;

namespace BUS
{
    public class BUS_Phanquyen
    {
        DAL_Phanquyen dalPQ = new DAL_Phanquyen();

        public List<ET_Phanquyen> LayMaTranQuyen(string maNhom)
        {
            return dalPQ.LayPhanQuyen(maNhom);
        }

        public bool LuuMaTranQuyen(string maNhom, List<ET_Phanquyen> dsQuyen)
        {
            return dalPQ.LuuPhanQuyen(maNhom, dsQuyen);
        }
    }
}
