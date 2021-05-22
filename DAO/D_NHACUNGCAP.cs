using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_NHACUNGCAP : DataProcess
    {
        public List<O_NHACUNGCAP> DuLieu(bool all = false, bool khachsan = false)
        {
            string a = string.Format(@"SELECT SD.SoDuCuoi [SoDu], NC.*
FROM NHACUNGCAP NC
LEFT JOIN (SELECT * FROM SODU_HANG WHERE CONVERT(date,Ngay) =CONVERT(date,GETDATE())) SD ON NC.ID = SD.NCCID ");

            if (!all)
                a += string.Format("where NC.KhachSan = '{0}'", khachsan);
            return LayDuLieu<O_NHACUNGCAP>(false, a);
        }
        public List<O_NHACUNGCAP> DuLieu_GiaoDich()
        {
            return LayDuLieu<O_NHACUNGCAP>(false, "SELECT [ID], (case when Hang = 1 then N'Hãng' else Ten end) Ten ,[SoDu] ,[HangBay] FROM NHACUNGCAP");
        }

        public long ChayLaiSD()
        {
            return EXECUP("RSSoDuHB");
        }
    }
}
