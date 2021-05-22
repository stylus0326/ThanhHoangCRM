using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_NHOMDAILY : DataProcess
    {
        public List<O_NHOMDAILY> DuLieu(int LoaiKhach, bool TatCa = false)
        {
            if (TatCa)
                return LayDuLieu<O_NHOMDAILY>();
            else
                return LayDuLieu<O_NHOMDAILY>(true, string.Format(@"WHERE LoaiKhachHang = {0}", LoaiKhach)); ;
        }
    }
}
