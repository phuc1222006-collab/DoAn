using System;
using System.Collections.Generic;
using DAL;
using ET;

namespace BUS
{
    public class BUS_DaoTaoNghiepVu
    {
        private DAL_DaoTaoNghiepVu dalDaoTao = new DAL_DaoTaoNghiepVu();

        // Lấy danh sách toàn bộ khóa đào tạo của công ty
        public List<ET_DaoTaoNghiepVu> LayToanBoDanhSach()
        {
            return dalDaoTao.LayToanBoDanhSach();
        }

        // Lấy danh sách theo một nhân viên cụ thể
        public List<ET_DaoTaoNghiepVu> LayDsTheoMa(string maNV)
        {
            return dalDaoTao.LayDsTheoMa(maNV);
        }

        // Thêm khóa học
        public bool ThemDaoTao(ET_DaoTaoNghiepVu etDaoTao)
        {
            return dalDaoTao.ThemDaoTao(etDaoTao);
        }

        // Cập nhật thông tin khóa học
        public bool SuaDaoTao(ET_DaoTaoNghiepVu etDaoTao)
        {
            return dalDaoTao.SuaDaoTao(etDaoTao);
        }

        // Xóa khóa học
        public bool XoaDaoTao(string maDaoTao)
        {
            return dalDaoTao.XoaDaoTao(maDaoTao);
        }
    }
}