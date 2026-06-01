using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;
using DAL;
using ET;

namespace BUS
{
    public class BUS_NhomQuyen
    {
            DAL_NhomQuyen DAL_nhomquyen = new DAL_NhomQuyen();

        public List<ET_NhomQuyen> LayDanhSachLenGrid()
        {
            // Lấy dữ liệu từ DAL 
            var dataFromDAL = DAL_nhomquyen.LayDanhSachLenGrid();

            // Chuyển đổi từ Entity LINQ sang đối tượng ET an toàn
            var listET = dataFromDAL.Select(nq => new ET_NhomQuyen
            {
                MaNhomQuyen = nq.MaNhomQuyen,
                TenNhomQuyen = nq.TenNhomQuyen,
                MoTa = nq.MoTa
            }).ToList();

            // Trả về danh sách ET
            return listET;
        }

        // Chỉnh các hàm Thêm, Xóa, Sửa để dùng ET_NhomQuyen
        public bool ThemNhomQuyen(ET_NhomQuyen et)
            {
                // Chuyển ET sang Entity gốc
                NhomQuyen nq = new NhomQuyen
                {
                    MaNhomQuyen = et.MaNhomQuyen,
                    TenNhomQuyen = et.TenNhomQuyen,
                    MoTa = et.MoTa
                };
                return DAL_nhomquyen.ThemNhomQuyen(nq);
            }

            public bool XoaNhomQuyen(ET_NhomQuyen et)
            {
                // Chuyển ET sang Entity gốc
                NhomQuyen nq = new NhomQuyen
                {
                    MaNhomQuyen = et.MaNhomQuyen,
                    TenNhomQuyen = et.TenNhomQuyen,
                    MoTa = et.MoTa
                };
                return DAL_nhomquyen.XoaNhomQuyen(nq);
            }

            public bool SuaNhomQuyen(ET_NhomQuyen et)
            {
                // Chuyển ET sang Entity gốc
                NhomQuyen nq = new NhomQuyen
                {
                    MaNhomQuyen = et.MaNhomQuyen,
                    TenNhomQuyen = et.TenNhomQuyen,
                    MoTa = et.MoTa
                };
                return DAL_nhomquyen.SuaNhomQuyen(nq);
            }
        }
    }


