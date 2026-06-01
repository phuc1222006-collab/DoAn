using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DonNghiPhep
    {
        public IQueryable<DonNghiPhep> layDanhSachDonNghiPhep()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.DonNghiPheps;
        }
        public bool ThemDonNghiPhep(DonNghiPhep ct)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.DonNghiPheps.InsertOnSubmit(ct);
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
