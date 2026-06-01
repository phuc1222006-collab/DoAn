using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ClassLibrary3;
using ET;

namespace BUS
{
    public class BUS_ChamCong
    {
        DAL_ChamCong DAL_chamcong=new DAL_ChamCong();
        public List<ET_ChamCong> LayDanhSachLenGrid() 
        {
            var data = DAL_chamcong.LayDanhSachLenGrid();

            return data.Select(cc => new ET_ChamCong
            {
                ID = cc.ID,
                MaNhanVien=cc.MaNhanVien,
                NgayChamCong=cc.NgayChamCong,
                MaCa=cc.MaCa,
                GioVao=cc.GioVao,
                GioRa=cc.GioRa,
                SoGioOT=cc.SoGioOT??0,
                MaHinhThuc=cc.MaHinhThuc,
                TrangThai=cc.TrangThai

           
            }).ToList();
          
        }
        
        public bool ThemChamcong(ET_ChamCong cc) 
        {
            try
            {
                DataChamCong dtcc = new DataChamCong
                {
                    MaNhanVien = cc.MaNhanVien,
                    NgayChamCong = cc.NgayChamCong,
                    MaCa = cc.MaCa,
                    GioVao = cc.GioVao,
                    GioRa = cc.GioRa,
                    SoGioOT = cc.SoGioOT,
                    MaHinhThuc = cc.MaHinhThuc,
                    TrangThai = cc.TrangThai
                };
                DAL_chamcong.themDataChamCong(dtcc);
            }
            catch (Exception ex) { return false; }
            return true;
        }
        public ET_ChamCong check(string maNV)
        {
            ET_ChamCong et_cc=null;
            try
            {
                DataChamCong dtcc = DAL_chamcong.check(maNV);
                if (dtcc == null) { return null; }
                et_cc = new ET_ChamCong
                {
                    ID = dtcc.ID,
                    MaNhanVien = dtcc.MaNhanVien,
                    NgayChamCong = dtcc.NgayChamCong,
                    MaCa = dtcc.MaCa,
                    GioVao = dtcc.GioVao,
                    GioRa = dtcc.GioRa,
                    SoGioOT = dtcc.SoGioOT ?? 0,
                    MaHinhThuc = dtcc.MaHinhThuc,
                    TrangThai = dtcc.TrangThai
                };
                return et_cc;
            }
            catch (Exception ex) { throw new Exception(""+ex); }
        }
        public bool SuaChamCong(ET_ChamCong cc)
        {
            try
            {
                DataChamCong dtcc = new DataChamCong
                {
                    ID=cc.ID??0,
                    MaNhanVien = cc.MaNhanVien,
                    NgayChamCong = cc.NgayChamCong,
                    MaCa = cc.MaCa,
                    GioVao = cc.GioVao,
                    GioRa = cc.GioRa,
                    SoGioOT = cc.SoGioOT,
                    MaHinhThuc = cc.MaHinhThuc,
                    TrangThai = cc.TrangThai
                };
                DAL_chamcong.suaDataChamCong(dtcc);
            }
            catch (Exception ex) { return false; }
            return true;
        }
        public List<ET_ChamCong> LocDataChamCong(string maNV, DateTime tuNgay, DateTime denNgay)
        {
            // Gọi ĐÚNG hàm lọc dưới tầng DAL và truyền 3 tham số vào
            var data = DAL_chamcong.locDataChamCong(maNV, tuNgay, denNgay);

            // Phần Mapping của bạn giữ nguyên, làm rất chuẩn rồi
            return data.Select(cc => new ET_ChamCong
            {
                ID = cc.ID,
                MaNhanVien = cc.MaNhanVien,
                NgayChamCong = cc.NgayChamCong,
                MaCa = cc.MaCa,
                GioVao = cc.GioVao,
                GioRa = cc.GioRa,
                SoGioOT = cc.SoGioOT ?? 0,
                MaHinhThuc = cc.MaHinhThuc,
                TrangThai = cc.TrangThai
            }).ToList();
        }
    }
}
