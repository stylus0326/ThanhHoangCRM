using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_LOAIGIAODICH : DataProcess
    {

        public List<O_LOAIGIAODICH> DuLieu()
        {
            return LayDuLieu<O_LOAIGIAODICH>(true);
        }

        public List<O_LOAIGIAODICH> DuLieu_NganHang_TheoLoai(int LoaiKhach, bool All)
        {
            return LayDuLieu<O_LOAIGIAODICH>(true, " WHERE NganHang = 1" + (All ? "" : " and LoaiKhach = " + LoaiKhach));
        }

        public List<O_LOAIGIAODICH> DuLieu_CongNo_TheoLoai(int LoaiKhach)
        {
            return LayDuLieu<O_LOAIGIAODICH>(true, string.Format(" WHERE CongNo = 1 and LoaiKhach in (0,{0})", LoaiKhach));
        }
    }
}
