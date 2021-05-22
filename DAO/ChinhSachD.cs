using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class ChinhSachD : DataProcess
    {
        public ChinhSachD()
        {
            TableName = "CHINHSACH";
        }

        public List<ChinhSachO> All()
        {
            return LayDuLieu<ChinhSachO>(false, "SELECT ID,Ten FROM CHINHSACH order by ID desc");
        }

        public List<ChinhSachO> DuLieu(bool TatCa, int LoaiKhachHang)
        {
            if (!TatCa)
                return LayDuLieu<ChinhSachO>(true, string.Format("WHERE ID in (select ChinhSach from DAILY where LoaiKhachHang = {0})  order by Ten desc", LoaiKhachHang));
            else
                return LayDuLieu<ChinhSachO>(true, string.Format("WHERE LoaiKhachHang = {0} order by Ten desc", LoaiKhachHang));
        }

        public List<ChinhSachO> DuLieuDL( int LoaiKhachHang)
        {
            return LayDuLieu<ChinhSachO>(true, string.Format("WHERE AN = 0 AND LoaiKhachHang = {0} order by Ten desc", LoaiKhachHang));
        }
    }

    public class CTChinhSachD : DataProcess
    {
        public CTChinhSachD()
        {
            TableName = "CTCHINHSACH";
        }

        public List<CTChinhSachO> DuLieu(long ID = 0)
        {
            return LayDuLieu<CTChinhSachO>(true, string.Format("WHERE IDChinhSach = '{0}'", ID));
        }

        public List<CTChinhSachO> SoDuDL(long ID, DateTime dtp1, DateTime dtp2)
        {
            return LayDuLieu<CTChinhSachO>(false, string.Format(@"select ChinhSachID,Ngay,SoDuCuoi
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
