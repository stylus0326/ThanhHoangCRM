using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_NGANHANG : DataProcess
    {
        #region GiaoDichNganHang
        public List<O_NGANHANG> All()
        {
            return LayDuLieu<O_NGANHANG>(true, "order by Nhom,ID");
        }

        public List<O_NGANHANG> DuLieu(bool TienMat)
        {
            string asd = @"SELECT ID ,Ten ,SoTK ,TenTK ,TenDangNhap ,MatKhau ,SoDuCuoi ,NgayGD ,NgayHT ,Nap ,Rut ,PhepTinh ,GhiChu ,WURL ,Ex,SoDu,Nhom  FROM NGANHANG NH
left join (SELECT CONVERT(DATE,Ngay) Ngay,NganHangID,SoDuCuoi FROM SODU_NGANHANG WHERE CONVERT(DATE,Ngay) = CONVERT(DATE,GETDATE()))SD ON SD.NganHangID = NH.ID WHERE Xoa = 0 and {0} order by Nhom,ID";
            if (TienMat)
                return LayDuLieu<O_NGANHANG>(false, string.Format(asd, "ID = 1"));
            else
                return LayDuLieu<O_NGANHANG>(false, string.Format(asd, "ID <> 1"));
        }

        public List<O_NGANHANG> DuLieu()
        {
            string asd = @"SELECT ID ,Ten ,SoTK ,TenTK ,TenDangNhap ,MatKhau ,SoDuCuoi ,NgayGD ,NgayHT ,Nap ,Rut ,PhepTinh ,GhiChu ,WURL ,Ex,SoDu,Nhom  FROM NGANHANG NH
left join (SELECT CONVERT(DATE,Ngay) Ngay,NganHangID,SoDuCuoi FROM SODU_NGANHANG WHERE CONVERT(DATE,Ngay) = CONVERT(DATE,GETDATE()))SD ON SD.NganHangID = NH.ID WHERE Xoa = 0 order by Nhom,ID";
            return LayDuLieu<O_NGANHANG>(false, asd);
        }

        public long ChayLaiSD()
        {
            return EXECUP("RSSoDuNH");
        }

        #endregion
    }
}
