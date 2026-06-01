using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhongBan
    {
        public IQueryable<PhongBan> LayDanhSachPhongBan()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.PhongBans;
        }
        public bool ThemPhongBan(PhongBan tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.PhongBans.InsertOnSubmit(tu);
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
