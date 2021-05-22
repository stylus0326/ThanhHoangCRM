using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_TRANGTHAI : DataProcess
    {
        public List<O_TRANGTHAI> DuLieu(int LoaiKhach, bool TatCa = false)
        {
            if (TatCa)
                return LayDuLieu<O_TRANGTHAI>();
            else
                return LayDuLieu<O_TRANGTHAI>(true, string.Format(@"WHERE LoaiKhachHang = {0}", LoaiKhach));
        }
    }
}
