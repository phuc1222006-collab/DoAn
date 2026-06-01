using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using ET;

namespace BUS
{
    public class BUS_HopDongLaoDong
    {
        private DAL_HopDongLaoDong dalHopDong = new DAL_HopDongLaoDong();

        // Lấy danh sách map sang List để đổ lên DataGridView
        public List<ET_HopDongLaoDong> LayDsTheoMa(string maNV)
        {
            var query = dalHopDong.LayDsTheoMa(maNV);
            return query.Select(item => new ET_HopDongLaoDong
            {
                SoHopDong = item.SoHopDong,
                MaNhanVien = item.MaNhanVien,
                LoaiHopDong = item.LoaiHopDong,
                // Dùng GetValueOrDefault nếu LINQ trả về DateTime?, nếu SQL set Not Null thì bỏ GetValueOrDefault()
                NgayKy = item.NgayKy.GetValueOrDefault(),
                NgayHieuLuc = item.NgayHieuLuc.GetValueOrDefault(),
                NgayHetHan = item.NgayHetHan, // Có thể Null
                LuongCung = item.LuongCung,
                TrangThai = item.TrangThai
            }).ToList();
        }
        public List<string> LayDanhSachLoaiHopDong()
        {
            return dalHopDong.LayDanhSachLoaiHopDong();
        }

        public bool ThemHopDong(ET_HopDongLaoDong etHopDong)
        {
            return dalHopDong.ThemHopDong(etHopDong);
        }

        public bool SuaHopDong(ET_HopDongLaoDong etHopDong)
        {
            return dalHopDong.SuaHopDong(etHopDong);
        }

        public bool XoaHopDong(string soHopDong)
        {
            return dalHopDong.XoaHopDong(soHopDong);
        }
    }
}