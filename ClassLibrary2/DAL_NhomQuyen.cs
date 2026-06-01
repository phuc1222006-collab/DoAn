using System.Linq;
using ClassLibrary2; 

namespace DAL
{
    public class DAL_NhomQuyen
    {

        public IQueryable<NhomQuyen> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.NhomQuyens;
        }

        public bool ThemNhomQuyen(NhomQuyen nq)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            try
            {
                db.NhomQuyens.InsertOnSubmit(nq);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNhomQuyen(NhomQuyen nq)
        {
            try
            {
                using (var db = new QuanLyNhanSuDataContext())
                {
                    var nqindb = db.NhomQuyens.FirstOrDefault(n => n.MaNhomQuyen == nq.MaNhomQuyen);
                    if (nqindb == null) return false;
                    db.NhomQuyens.DeleteOnSubmit(nqindb);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SuaNhomQuyen(NhomQuyen nq)
        {
            using (var db = new QuanLyNhanSuDataContext())
            {
                // Tìm nhóm quyền theo khóa chính là MaNhomQuyen
                var nqindb = db.NhomQuyens.FirstOrDefault(n => n.MaNhomQuyen == nq.MaNhomQuyen);
                if (nqindb == null) return false;

                // Cập nhật dữ liệu, bỏ qua khóa chính
                Sua.UpdateEntity(nq, nqindb, "MaNhomQuyen");

                db.SubmitChanges();
                return true;
            }
        }
    }
}