using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CauHinhSMTPD : DataProcess
    {
        public CauHinhSMTPD()
        {
            TableName = "CAUHINHSMTP";
        }

        public CauHinhSMTPO DuLieu()
        {
            return LayMotDongDonGian<CauHinhSMTPO>();
        }
    }

    public class MauEmailD : DataProcess
    {
        public MauEmailD()
        {
            TableName = "MAUEMAIL";
        }
        public List<MauEmailO> DuLieu()
        {
            return LayDuLieu<MauEmailO>(true);
        }
    }
}
