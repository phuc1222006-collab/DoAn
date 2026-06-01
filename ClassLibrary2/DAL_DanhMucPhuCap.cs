using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ET;
namespace ClassLibrary2
{
    public class DAL_DanhMucPhuCap
    {
       
        public IQueryable<DanhMucPhuCap> layDanhSachPhuCap()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.DanhMucPhuCaps;
        }
        public bool ThemDanhMucPhuCap(DanhMucPhuCap tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.DanhMucPhuCaps.InsertOnSubmit(tu);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}
