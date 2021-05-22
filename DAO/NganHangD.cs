using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class NganHangD : DataProcess
    {
        public NganHangD()
        {
            TableName = "NGANHANG";
        }

        #region GiaoDichNganHang
        public List<NganHangO> All()
        {
            return LayDuLieu<NganHangO>(true, "order by Nhom,ID");
        }

        public List<NganHangO> DuLieu(bool TienMat)
        {
            string asd = @"SELECT ID ,Ten ,SoTK ,TenTK ,TenDangNhap ,MatKhau ,SoDuCuoi ,NgayGD ,NgayHT ,Nap ,Rut ,PhepTinh ,GhiChu ,WURL ,Ex,SoDu,Nhom  FROM NGANHANG NH
left join (SELECT CONVERT(DATE,Ngay) Ngay,NganHangID,SoDuCuoi FROM SODU_NGANHANG WHERE CONVERT(DATE,Ngay) = CONVERT(DATE,GETDATE()))SD ON SD.NganHangID = NH.ID WHERE Xoa = 0 and {0} order by Nhom,ID";
            if (TienMat)
                return LayDuLieu<NganHangO>(false, string.Format(asd, "ID = 1"));
            else
                return LayDuLieu<NganHangO>(false, string.Format(asd, "ID <> 1"));
        }

        public long ChayLaiSD()
        {
            return EXECUP("RSSoDuNH");
        }

        public long ChayLaiSoDu()
        {
            return EXECUP("RSSoDuNH");
        }
        #endregion

    }
}
