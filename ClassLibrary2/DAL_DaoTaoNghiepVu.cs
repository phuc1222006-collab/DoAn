using System;
using System.Collections.Generic;
using System.Linq;
using ET;

namespace DAL
{
    public class DAL_DaoTaoNghiepVu
    {
        // 1. LẤY TOÀN BỘ DANH SÁCH (Dùng cho Tab Đào tạo độc lập)
        public List<ET_DaoTaoNghiepVu> LayToanBoDanhSach()
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                // Thực hiện JOIN 2 bảng để lấy được Tên Nhân Viên
                var query = from dt in db.DaoTaoNghiepVus
                            join nv in db.NhanViens on dt.MaNhanVien equals nv.MaNhanVien
                            select new ET_DaoTaoNghiepVu
                            {
                                MaDaoTao = dt.MaDaoTao,
                                MaNhanVien = dt.MaNhanVien,
                                TenNhanVien = nv.HoTen, // Ánh xạ tên nhân viên
                                TenKhoaDaoTao = dt.TenKhoaDaoTao,
                                NguoiHuongDan = dt.NguoiHuongDan,
                                NgayBatDau = dt.NgayBatDau,
                                NgayKetThuc = dt.NgayKetThuc,
                                KetQuaDanhGia = dt.KetQuaDanhGia
                            };
                return query.ToList();
            }
        }

        // 2. LẤY DANH SÁCH THEO MÃ (Dự phòng nếu sau này cần dùng lại)
        public List<ET_DaoTaoNghiepVu> LayDsTheoMa(string maNV)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                var query = from dt in db.DaoTaoNghiepVus
                            join nv in db.NhanViens on dt.MaNhanVien equals nv.MaNhanVien
                            where dt.MaNhanVien == maNV
                            select new ET_DaoTaoNghiepVu
                            {
                                MaDaoTao = dt.MaDaoTao,
                                MaNhanVien = dt.MaNhanVien,
                                TenNhanVien = nv.HoTen,
                                TenKhoaDaoTao = dt.TenKhoaDaoTao,
                                NguoiHuongDan = dt.NguoiHuongDan,
                                NgayBatDau = dt.NgayBatDau,
                                NgayKetThuc = dt.NgayKetThuc,
                                KetQuaDanhGia = dt.KetQuaDanhGia
                            };
                return query.ToList();
            }
        }

        // 3. THÊM
        public bool ThemDaoTao(ET_DaoTaoNghiepVu etDaoTao)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    DaoTaoNghiepVu dtMoi = new DaoTaoNghiepVu
                    {
                        MaDaoTao = etDaoTao.MaDaoTao,
                        MaNhanVien = etDaoTao.MaNhanVien,
                        TenKhoaDaoTao = etDaoTao.TenKhoaDaoTao,
                        NguoiHuongDan = etDaoTao.NguoiHuongDan,
                        NgayBatDau = etDaoTao.NgayBatDau,
                        NgayKetThuc = etDaoTao.NgayKetThuc,
                        KetQuaDanhGia = etDaoTao.KetQuaDanhGia
                    };
                    db.DaoTaoNghiepVus.InsertOnSubmit(dtMoi);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm đào tạo: " + ex.Message);
                return false;
            }
        }

        // 4. SỬA
        public bool SuaDaoTao(ET_DaoTaoNghiepVu etDaoTao)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var dtSua = db.DaoTaoNghiepVus.FirstOrDefault(dt => dt.MaDaoTao == etDaoTao.MaDaoTao);
                    if (dtSua != null)
                    {
                        // Cho phép sửa cả Mã Nhân viên đề phòng người dùng chọn nhầm người học
                        dtSua.MaNhanVien = etDaoTao.MaNhanVien;
                        dtSua.TenKhoaDaoTao = etDaoTao.TenKhoaDaoTao;
                        dtSua.NguoiHuongDan = etDaoTao.NguoiHuongDan;
                        dtSua.NgayBatDau = etDaoTao.NgayBatDau;
                        dtSua.NgayKetThuc = etDaoTao.NgayKetThuc;
                        dtSua.KetQuaDanhGia = etDaoTao.KetQuaDanhGia;

                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi sửa đào tạo: " + ex.Message);
                return false;
            }
        }

        // 5. XÓA
        public bool XoaDaoTao(string maDaoTao)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var dtXoa = db.DaoTaoNghiepVus.FirstOrDefault(dt => dt.MaDaoTao == maDaoTao);
                    if (dtXoa != null)
                    {
                        db.DaoTaoNghiepVus.DeleteOnSubmit(dtXoa);
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa đào tạo: " + ex.Message);
                return false;
            }
        }
    }
}