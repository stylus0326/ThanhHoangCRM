using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_SODU_NGANHANG : DataProcess
    {
        public long ChayLaiSD()
        {
            return EXECUP("RSSoDuNH");
        }

        public List<O_SODU_NGANHANG> LayDanhSach(int ID, DateTime dtp1, DateTime dtp2)
        {
            return LayDuLieu<O_SODU_NGANHANG>(true, string.Format("WHERE CONVERT(date,Ngay) between '{1}' and '{2}' AND NganHangID = {0} order by CONVERT(date,Ngay)", ID, dtp1.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }
    }
}
