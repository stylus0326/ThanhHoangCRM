using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_CTCHINHSACH : DataProcess
    {
        public List<O_CTCHINHSACH> DuLieu(long ID = 0)
        {
            return LayDuLieu<O_CTCHINHSACH>(true, string.Format("WHERE IDChinhSach = '{0}'", ID));
        }

        public List<O_CTCHINHSACH> SoDuDL(long ID, DateTime dtp1, DateTime dtp2)
        {
            return LayDuLieu<O_CTCHINHSACH>(false, string.Format(@"select ChinhSachID,Ngay,SoDuCuoi
                                                from SODU_DAILY
                                                where DAILYID= {0} and convert(date,Ngay) between '{1}' and '{2}'                  
                                                order by ngay desc", ID, dtp1.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }

        public int ChinhSuaSoDu(int ChinhSach, int ID, DateTime dtp1, DateTime dtp2)
        {
            string CauTruyVan = string.Format("update SODU_DAILY set ChinhSachID = {0} where DAILYID= {1} and convert(date,Ngay) between '{2}' and '{3};'", ChinhSach, ID, dtp1.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd"));
            CauTruyVan += string.Format(@"update DAILY set ChinhSach = (select ChinhSachID from CTCHINHSACH where DaiLyID = {0} and convert(date,NgayBD) = convert(date,GETDATE())) where ID = {0}", ID);
            return ChayCauTruyVan(CauTruyVan);
        }
    }
}
