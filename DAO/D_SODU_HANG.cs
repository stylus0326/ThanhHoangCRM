using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_SODU_HANG : DataProcess
    {
        public long ChayLaiSD()
        {
            return EXECUP("RSSoDuHB");
        }

        public List<O_SODU_HANG> DuLieu(string ID, DateTime ftp1, DateTime dtp2)
        {
            return LayDuLieu<O_SODU_HANG>(false, string.Format(@"declare @TuNgay date = '{0}'
declare @DenNgay date = '{1}'
declare @ID INT = {2}

SELECT T5.SoDuDau ,T1.Ngay,T1.SoDuThucTe,coalesce(T2.TienVe,0) + coalesce(G5.GiaNet,0) 'TienVe',T3.NopQuy,T2.PhiHoan,coalesce(T2.Hoan,0) + coalesce(G5.SoTienBaoLuu,0) Hoan,T4.Incentive,T4.HangThu,T1.Error,T1.SoDuCuoi
FROM	  (SELECT CONVERT(DATE,Ngay) 'Ngay',SoDuCuoi,SoDuThucTe,Error  FROM SODU_HANG WHERE NCCID = @ID AND CONVERT(DATE,Ngay) BETWEEN @TuNgay AND @DenNgay) T1

LEFT JOIN (SELECT CONVERT(date,NgayGD) NgayGD,NhaCungCap,COALESCE(sum(HangHoan),0) Hoan, COALESCE(sum((case when LoaiGiaoDich = 9 then 0 else GiaNet end)),0) TienVe, COALESCE(sum((case when LoaiGiaoDich = 9 then GiaNet else 0 end)),0) PhiHoan  
			from GIAODICH 
			WHERE TinhCongNo = 1 AND CONVERT(date, NgayGD) BETWEEN @TuNgay AND @DenNgay AND NhaCungCap = @ID
			GROUP BY NhaCungCap, CONVERT(date,NgayGD)) T2 
			ON T1.Ngay = T2.NgayGD

LEFT JOIN (SELECT CONVERT(date,NgayHT) NgayHT,MaDL,COALESCE(sum(SoTien),0) NopQuy 
			FROM CTNGANHANG WHERE CONVERT(date,NgayHT) BETWEEN @TuNgay AND @DenNgay and LoaiGiaoDich = 1 and MaDL = @ID
			GROUP BY MaDL,CONVERT(date,NgayHT)) T3 
			ON T1.Ngay = T3.NgayHT

LEFT JOIN (SELECT NGAYGD,NCC,SUM((case when LoaiGiaoDich = 1 then SoTien else 0 end)) 'Incentive' ,SUM((case when LoaiGiaoDich != 1 then SoTien else 0 end)) 'HangThu'
			FROM NHACUNGCAP_GIAODICHPHATSINH
			WHERE CONVERT(date,NGAYGD) BETWEEN @TuNgay AND @DenNgay AND NCC = @ID
			GROUP BY NCC,NGAYGD) T4
			on T4.NGAYGD = T1.Ngay

LEFT JOIN (SELECT CONVERT(date,NgayGD) NgayGD,KhachSan,COALESCE(sum(SoTienBaoLuu),0) SoTienBaoLuu, COALESCE(sum(Gianet),0) Gianet  from KHACHSAN 
							WHERE CONVERT(date, NgayGD)BETWEEN @TuNgay AND @DenNgay AND COALESCE(KhachSan,0)>0 and KhachSan = @ID
							GROUP BY KhachSan,CONVERT(date,NgayGD) ) G5 
							on G5.NgayGD = T1.Ngay

LEFT JOIN (SELECT CONVERT(DATE, DATEADD(DAY,1,Ngay)) 'Ngay',SoDuCuoi 'SoDuDau'  FROM SODU_HANG WHERE NCCID = @ID AND CONVERT(DATE,Ngay) BETWEEN DATEADD(DAY,-1,@TuNgay) AND DATEADD(DAY,-1,@DenNgay)) T5
			on T5.NGAY = T1.Ngay

order by Ngay", ftp1.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd"), ID));
        }
    }
}
