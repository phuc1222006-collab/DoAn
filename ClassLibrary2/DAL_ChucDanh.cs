using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ClassLibrary2
{
    public class DAL_ChucDanh
    {
        
        public IQueryable<ChucDanh> layDanhSachChuDanh()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.ChucDanhs;
        }
        public bool ThemChucDanh(ChucDanh tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.ChucDanhs.InsertOnSubmit(tu);
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
