using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DAL_ChiNhanh
    {
        public IQueryable<ChiNhanh> layDanhSachChiNhanh()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.ChiNhanhs;
        }
        public bool ThemChiNhanh(ChiNhanh tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.ChiNhanhs.InsertOnSubmit(tu);
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
