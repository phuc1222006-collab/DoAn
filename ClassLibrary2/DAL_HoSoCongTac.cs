using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoSoCongTac
    {
        public IQueryable<HoSoCongTac> layDanhSachHoSoCongTac()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.HoSoCongTacs;
        }
        public bool ThemHoSoCongTac(HoSoCongTac Ct)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.HoSoCongTacs.InsertOnSubmit(Ct);
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
