using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HinhThucChamCong
    {
        public IQueryable<HinhThucChamCong> layDanhSachChiNhanh()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.HinhThucChamCongs;
        }
        public bool ThemHinhThucChamCong(HinhThucChamCong tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.HinhThucChamCongs.InsertOnSubmit(tu);
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
