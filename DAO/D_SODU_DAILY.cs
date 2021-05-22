using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_SODU_DAILY : DataProcess
    {
        public List<O_SODU_DAILY> DuLieu(long ID, DateTime dtp1, DateTime dtp2)
        {
            return LayDuLieu<O_SODU_DAILY>(true, string.Format(@"WHERE DAILYID= {0} and convert(date,Ngay) between '{1}' and '{2}'                  
                                                order by ngay desc", ID, dtp1.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }
    }
}
