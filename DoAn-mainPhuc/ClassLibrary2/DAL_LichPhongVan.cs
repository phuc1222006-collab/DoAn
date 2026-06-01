using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class DAL_LichPhongVan
    {
        // 1. HIỂN THỊ DANH SÁCH ỨNG VIÊN
        public IQueryable<LichPhongVan> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.LichPhongVans;
        }

        // 2. THÊM ỨNG VIÊN MỚI
        public bool ThemLich(LichPhongVan lpv)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.LichPhongVans.InsertOnSubmit(lpv);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // 3. CẬP NHẬT THÔNG TIN / TRẠNG THÁI ỨNG VIÊN
        public bool SuaLich(LichPhongVan lpv)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var lpvindb = db.LichPhongVans.FirstOrDefault(x => x.MaPhongVan == lpv.MaPhongVan);
                    if (lpvindb == null) return false;
                    Sua.UpdateEntity(lpv, lpvindb, "MaPhongVans");
                   
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
