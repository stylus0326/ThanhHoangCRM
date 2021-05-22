using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class PhongBanD : DataProcess
    {
        public PhongBanD()
        {
            TableName = "PHONGBAN";
        }

        public List<PhongBanO> DuLieu()
        {
            return LayDuLieu<PhongBanO>();
        }
    }
}
