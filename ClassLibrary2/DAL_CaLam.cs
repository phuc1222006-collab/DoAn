using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DAL_CaLam
    {
        public IQueryable<CaLamViec> layDanhSachCaLam()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.CaLamViecs;
        }
        public bool ThemCaLam(CaLamViec tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.CaLamViecs.InsertOnSubmit(tu);
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
