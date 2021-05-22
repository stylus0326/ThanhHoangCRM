using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_CHINHSACH : DataProcess
    {

        public List<O_CHINHSACH> All()
        {
            return LayDuLieu<O_CHINHSACH>(false, "SELECT ID,Ten FROM CHINHSACH order by ID desc");
        }

        public List<O_CHINHSACH> DuLieu(bool TatCa, int LoaiKhachHang)
        {
            if (!TatCa)
                return LayDuLieu<O_CHINHSACH>(true, string.Format("WHERE ID in (select ChinhSach from DAILY where LoaiKhachHang = {0})  order by Ten desc", LoaiKhachHang));
            else
                return LayDuLieu<O_CHINHSACH>(true, string.Format("WHERE LoaiKhachHang = {0} order by Ten desc", LoaiKhachHang));
        }

        public List<O_CHINHSACH> DuLieuDL(int LoaiKhachHang)
        {
            return LayDuLieu<O_CHINHSACH>(true, string.Format("WHERE AN = 0 AND LoaiKhachHang = {0} order by Ten desc", LoaiKhachHang));
        }
    }
}
