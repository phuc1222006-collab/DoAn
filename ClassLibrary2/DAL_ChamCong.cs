using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DAL_ChamCong
    {
        public IQueryable<DataChamCong> LayDanhSachLenGrid()
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            return db.DataChamCongs;
        }
        public bool themDataChamCong(DataChamCong dtcc)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            try
            {
                db.DataChamCongs.InsertOnSubmit(dtcc);
                db.SubmitChanges();
            }
            catch (Exception ex) { return false; }
            return true;
        }
        public DataChamCong check(string maNV)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                // 1. Phải lọc theo Ngày Hôm Nay 
                // 2. Phải sắp xếp ID giảm dần (OrderByDescending) để lấy dòng mới nhất
                var ds = db.DataChamCongs
                           .Where(s => s.MaNhanVien == maNV
                                    // Đảm bảo chỉ xét dữ liệu của ngày hôm nay
                                    && s.NgayChamCong.Value.Date == DateTime.Today.Date)
                           .OrderByDescending(s => s.ID)
                           .FirstOrDefault();

                // Nếu tìm thấy dòng mới nhất của hôm nay mà chưa có Giờ Ra -> Cho phép Sửa
                if (ds != null && ds.GioVao != null && ds.GioRa == null)
                {
                    return ds;
                }

                // Nếu không có, hoặc có nhưng đã chốt Giờ Ra rồi -> Báo null để tạo dòng mới
                return null;

            }
        }
        public bool suaDataChamCong(DataChamCong dtcc)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            try
            {
                var dtccindb = db.DataChamCongs.FirstOrDefault(x => x.ID == dtcc.ID);
                if (dtccindb == null) return false;
                Sua.UpdateEntity(dtcc, dtccindb, "ID");
                db.SubmitChanges();
            }
            catch (Exception ex) { return false; }
            return true;
        }
        public IQueryable<DataChamCong> locDataChamCong(string maNV, DateTime tuNgay, DateTime denNgay)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();

            return db.DataChamCongs
         .Where(x => x.MaNhanVien == maNV
                  && x.NgayChamCong.Value.Date >= tuNgay.Date
                  && x.NgayChamCong.Value.Date <= denNgay.Date)
         .OrderByDescending(x => x.NgayChamCong);

        }

    }
}
