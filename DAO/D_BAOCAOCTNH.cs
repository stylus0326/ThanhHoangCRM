using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_BAOCAOCTNH : DataProcess
    {
        public List<O_BAOCAOCTNH> DuLieu(int iID)
        {
            return LayDuLieu<O_BAOCAOCTNH>(true, " WHERE IDCTNganHang = " + iID);
        }
    }
}
