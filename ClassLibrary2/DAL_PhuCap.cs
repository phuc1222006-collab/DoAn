using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
namespace DAL
{
    public class DAL_PhuCap
    {
        public IQueryable<PhuCapNhanVien> LayDanhSachPhuCap()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.PhuCapNhanViens;
        }
        public bool ThemPhuCap(PhuCapNhanVien pc)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.PhuCapNhanViens.InsertOnSubmit(pc);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool SuaPhuCap(PhuCapNhanVien pc)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var existingUV = db.PhuCapNhanViens.FirstOrDefault(x => x.MaPhuCap == pc.MaPhuCap);
                    if (existingUV != null)
                    {
                        existingUV.MaPhuCap = pc.MaPhuCap;
                        existingUV.MaNhanVien = pc.MaNhanVien;
                        existingUV.NgayCapTien = pc.NgayCapTien;
                        existingUV.DanhMucPhuCap = pc.DanhMucPhuCap;


                       

                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
