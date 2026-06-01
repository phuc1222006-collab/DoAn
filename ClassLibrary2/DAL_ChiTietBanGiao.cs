using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DAL_ChiTietBanGiao
    {
        public IQueryable<ChiTietBanGiao> layDanhSachChiTietBanGiap()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.ChiTietBanGiaos;
        }
        public bool ThemChiTietBanGiao(ChiTietBanGiao ct)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.ChiTietBanGiaos.InsertOnSubmit(ct);
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
