using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ET;

namespace DAL
{
    public class DAL_HopDongLaoDong
    {
        // lấy ds theo mã nhân viên
        public IQueryable<HopDongLaoDong> LayDsTheoMa(string maNV)
        {
            QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
            return db.HopDongLaoDongs.Where(hd => hd.MaNhanVien == maNV);
        }
        //lấy ds
        public List<string> LayDanhSachLoaiHopDong()
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                // Lấy ra đúng cột LoaiHopDong, loại bỏ rỗng và dùng Distinct() để lọc trùng lặp
                return db.HopDongLaoDongs
                         .Select(hd => hd.LoaiHopDong)
                         .Where(loai => loai != null && loai != "")
                         .Distinct()
                         .ToList();
            }
        }

        // Thêm
        public bool ThemHopDong(ET_HopDongLaoDong etHopDong)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    HopDongLaoDong hdMoi = new HopDongLaoDong
                    {
                        SoHopDong = etHopDong.SoHopDong,
                        MaNhanVien = etHopDong.MaNhanVien,
                        LoaiHopDong = etHopDong.LoaiHopDong,
                        NgayKy = etHopDong.NgayKy,
                        NgayHieuLuc = etHopDong.NgayHieuLuc,
                        NgayHetHan = etHopDong.NgayHetHan,
                        LuongCung = etHopDong.LuongCung,
                        TrangThai = etHopDong.TrangThai
                    };
                    db.HopDongLaoDongs.InsertOnSubmit(hdMoi);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm hợp đồng: " + ex.Message);
                return false;
            }
        }

        // Sửa
        public bool SuaHopDong(ET_HopDongLaoDong etHopDong)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var hdSua = db.HopDongLaoDongs.FirstOrDefault(hd => hd.SoHopDong == etHopDong.SoHopDong);
                    if (hdSua != null)
                    {
                        hdSua.LoaiHopDong = etHopDong.LoaiHopDong;
                        hdSua.NgayKy = etHopDong.NgayKy;
                        hdSua.NgayHieuLuc = etHopDong.NgayHieuLuc;
                        hdSua.NgayHetHan = etHopDong.NgayHetHan;
                        hdSua.LuongCung = etHopDong.LuongCung;
                        hdSua.TrangThai = etHopDong.TrangThai;

                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi sửa hợp đồng: " + ex.Message);
                return false;
            }
        }

        // Xóa
        public bool XoaHopDong(string soHopDong)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var hdXoa = db.HopDongLaoDongs.FirstOrDefault(hd => hd.SoHopDong == soHopDong);
                    if (hdXoa != null)
                    {
                        db.HopDongLaoDongs.DeleteOnSubmit(hdXoa);
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa hợp đồng: " + ex.Message);
                return false;
            }
        }
    }
}