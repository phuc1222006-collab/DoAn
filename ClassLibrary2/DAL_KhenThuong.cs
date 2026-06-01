using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ET;   
namespace DAL
{
    public class DAL_KhenThuong
    {

        public IQueryable<KhenThuongKyLuat> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.KhenThuongKyLuats;
        }
        public bool ThemKhenThuong(KhenThuongKyLuat tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    db.KhenThuongKyLuats.InsertOnSubmit(tu);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool SuaKhenThuong(KhenThuongKyLuat tu)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var existingUV = db.KhenThuongKyLuats.FirstOrDefault(x => x.MaQuyetDinh == tu.MaQuyetDinh);
                    if (existingUV != null)
                    {
                        existingUV.MaQuyetDinh = tu.MaQuyetDinh;
                        existingUV.MaNhanVien = tu.MaNhanVien;
                        existingUV.LoaiQuyetDinh = tu.LoaiQuyetDinh;
                        existingUV.SoTien = tu.SoTien;
                        existingUV.LyDo = tu.LyDo;

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
