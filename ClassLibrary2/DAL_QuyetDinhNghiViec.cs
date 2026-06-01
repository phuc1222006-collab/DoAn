using System;
using System.Collections.Generic;
using System.Linq;
using ET;

namespace DAL
{
    public class DAL_QuyetDinhNghiViec
    {
        // Lấy thông tin
        public ET_QuyetDinhNghiViec LayThongTinNghiViec(string maNV)
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                var qd = db.QuyetDinhNghiViecs.FirstOrDefault(x => x.MaNhanVien == maNV);
                if (qd != null)
                {
                    return new ET_QuyetDinhNghiViec
                    {
                        MaQuyetDinh = qd.MaQuyetDinh,
                        MaNhanVien = qd.MaNhanVien,
                        NgayNopDon = qd.NgayNopDon.GetValueOrDefault(),
                        NgayNghiChinhThuc = qd.NgayNghiChinhThuc.GetValueOrDefault(),
                        LyDoNghi = qd.LyDoNghi,
                        TrangThaiBanGiao = qd.TrangThaiBanGiao,
                        NguoiDuyet = qd.NguoiDuyet // Đã bổ sung
                    };
                }
                return null;
            }
        }
        // lấy tòan bộ quyết định nghỉ việc
        public List<ET_QuyetDinhNghiViec> LayToanBoDanhSach()
        {
            using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
            {
                return db.QuyetDinhNghiViecs.Select(qd => new ET_QuyetDinhNghiViec
                {
                    MaQuyetDinh = qd.MaQuyetDinh,
                    MaNhanVien = qd.MaNhanVien,
                    NgayNopDon = qd.NgayNopDon.GetValueOrDefault(),
                    NgayNghiChinhThuc = qd.NgayNghiChinhThuc.GetValueOrDefault(),
                    LyDoNghi = qd.LyDoNghi,
                    TrangThaiBanGiao = qd.TrangThaiBanGiao,
                    NguoiDuyet = qd.NguoiDuyet
                }).ToList();
            }
        }
        // Thêm
        public bool ThemQuyetDinh(ET_QuyetDinhNghiViec etQuyetDinh)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    QuyetDinhNghiViec qdMoi = new QuyetDinhNghiViec
                    {
                        MaQuyetDinh = etQuyetDinh.MaQuyetDinh,
                        MaNhanVien = etQuyetDinh.MaNhanVien,
                        NgayNopDon = etQuyetDinh.NgayNopDon,
                        NgayNghiChinhThuc = etQuyetDinh.NgayNghiChinhThuc,
                        LyDoNghi = etQuyetDinh.LyDoNghi,
                        TrangThaiBanGiao = etQuyetDinh.TrangThaiBanGiao,
                        NguoiDuyet = etQuyetDinh.NguoiDuyet // Đã bổ sung
                    };
                    db.QuyetDinhNghiViecs.InsertOnSubmit(qdMoi);

                    // Cập nhật trạng thái nhân viên
                    var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == etQuyetDinh.MaNhanVien);
                    if (nv != null)
                    {
                        nv.TrangThaiLamViec = "Đã nghỉ việc";
                    }

                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm quyết định: " + ex.Message);
                return false;
            }
        }

        //Sửa
        public bool SuaQuyetDinh(ET_QuyetDinhNghiViec etQuyetDinh)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var qdSua = db.QuyetDinhNghiViecs.FirstOrDefault(qd => qd.MaQuyetDinh == etQuyetDinh.MaQuyetDinh);
                    if (qdSua != null)
                    {
                        qdSua.NgayNopDon = etQuyetDinh.NgayNopDon;
                        qdSua.NgayNghiChinhThuc = etQuyetDinh.NgayNghiChinhThuc;
                        qdSua.LyDoNghi = etQuyetDinh.LyDoNghi;
                        qdSua.TrangThaiBanGiao = etQuyetDinh.TrangThaiBanGiao;
                        qdSua.NguoiDuyet = etQuyetDinh.NguoiDuyet; // Đã bổ sung
                        
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi sửa quyết định: " + ex.Message);
                return false;
            }
        }

        // Xóa
        public bool XoaQuyetDinh(string maQuyetDinh)
        {
            try
            {
                using (QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext())
                {
                    var qdXoa = db.QuyetDinhNghiViecs.FirstOrDefault(qd => qd.MaQuyetDinh == maQuyetDinh);
                    if (qdXoa != null)
                    {
                        string maNV = qdXoa.MaNhanVien;
                        db.QuyetDinhNghiViecs.DeleteOnSubmit(qdXoa);

                        // Khôi phục trạng thái nhân viên
                        var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == maNV);
                        if (nv != null)
                        {
                            nv.TrangThaiLamViec = "Đang làm việc";
                        }

                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa quyết định: " + ex.Message);
                return false;
            }
        }
    }
}