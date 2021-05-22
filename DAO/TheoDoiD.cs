using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class TheoDoiD : DataProcess
    {
        public List<TheoDoiO> DuLieu(DateTime Tu, DateTime Den, int LoaiKhach, bool All)
        {
            return LayDuLieu<TheoDoiO>(false, string.Format(@"declare @TuNgay date = '{0}'
declare @DenNgay date = '{1}'
select Ten,dl1.ID,DL1.MaDL ,(case when coalesce(SoDuDau,0) >0 then coalesce(SoDuDau,0) else 0 end) 'SoDuDauDuong',(case when coalesce(SoDuDau,0) < 0 then 0 - coalesce(SoDuDau,0) else 0 end) 'SoDuDauAm'
,coalesce(GiaThu,0) GiaDuong,coalesce(GiaHoan,0) GiaAm ,coalesce(NopTien,0) NopTien,coalesce(RutTien,0) RutTien
,(case when coalesce(SoDuCuoiCoDinh,0) >0 then coalesce(SoDuCuoiCoDinh,0) else 0 end) 'SoDuCuoiDuong',(case when coalesce(SoDuCuoiCoDinh,0) < 0 then 0 - coalesce(SoDuCuoiCoDinh,0) else 0 end) 'SoDuCuoiAm'
,coalesce(SoDuDau,0)-coalesce(GiaThu,0)+coalesce(GiaHoan,0) + coalesce(NopTien,0) - coalesce(RutTien,0) SoDuCuoiTuDong
from (select Ten,ID,MaDL from DAILY where LoaiKhachHang = {2}) DL1
left join (select SoDuCuoi 'SoDuDau', CONVERT(date,Ngay) NgayGD0,DaiLyID from SODU_DAILY WHERE convert(date, Ngay) =DATEADD(day,-1,@TuNgay) ) SD on SD.DaiLyID = DL1.ID
left join (select sum(coalesce(GiaHoan,0)) GiaHoan, sum(coalesce(GiaThu,0)) GiaThu, IDKhachHang from GIAODICH WHERE  (convert(date, NgayGD) BETWEEN @TuNgay AND @DenNgay) and TinhCongNo = 1 GROUP BY IDKhachHang) GD ON Gd.IDKhachHang = DL1.ID
left join (select sum(coalesce((case when SoTien > 0 then SoTien else 0 end),0)) NopTien ,sum(coalesce((case when SoTien < 0 then SoTien else 0 end),0)) RutTien, MaDL from CTNGANHANG WHERE (convert(date, NgayHT) BETWEEN @TuNgay AND @DenNgay) and LoaiGiaoDich in(2,3) GROUP BY MaDL) NH ON NH.MaDL = DL1.ID
left join (select SoDuCuoi 'SoDuCuoiCoDinh' , CONVERT(date,Ngay) NgayGD0,DaiLyID from SODU_DAILY WHERE  convert(date, Ngay) = @DenNgay) SD2 on SD2.DaiLyID = DL1.ID
{3}", Tu.ToString("yyyyMMdd"), Den.ToString("yyyyMMdd"), LoaiKhach, All ? "" : "where coalesce(IDKhachHang,0) + coalesce(NH.MaDL,0) >0"));
        }

        public List<TheoDoiO> DuLieuNCC(DateTime Tu, DateTime Den, bool All)
        {
            return LayDuLieu<TheoDoiO>(false, string.Format(@"declare @TuNgay date = '{0}'
declare @DenNgay date = '{1}'
select TenDayDu 'Ten',dl1.ID,DL1.Ten 'MaDL' ,(case when coalesce(SoDuDau,0) >0 then coalesce(SoDuDau,0) else 0 end) 'SoDuDauDuong',(case when coalesce(SoDuDau,0) < 0 then 0 - coalesce(SoDuDau,0) else 0 end) 'SoDuDauAm'
,coalesce(GiaNet,0) GiaDuong,coalesce(HangHoan,0) GiaAm , 0-coalesce(NopTien,0) + coalesce(SoTienDuong,0) 'NopTien',coalesce(SoTienAm,0) + coalesce(RutTien,0) 'RutTien'
,(case when coalesce(SoDuCuoiCoDinh,0) >0 then coalesce(SoDuCuoiCoDinh,0) else 0 end) 'SoDuCuoiDuong',(case when coalesce(SoDuCuoiCoDinh,0) < 0 then 0 - coalesce(SoDuCuoiCoDinh,0) else 0 end) 'SoDuCuoiAm'

from (select TenDayDu ,ID,Ten from NHACUNGCAP) DL1
left join (select SoDuCuoi 'SoDuDau',NCCID from SODU_HANG WHERE convert(date, Ngay) =DATEADD(day,-1,@TuNgay) ) SD on SD.NCCID = DL1.ID
left join (select sum(coalesce(HangHoan,0)) 'HangHoan', sum(coalesce(GiaNet,0)) 'GiaNet', NhaCungCap from GIAODICH WHERE  (convert(date, NgayGD) BETWEEN @TuNgay AND @DenNgay) and TinhCongNo = 1 GROUP BY NhaCungCap) GD ON Gd.NhaCungCap = DL1.ID
left join (select sum(coalesce((case when SoTien < 0 then SoTien else 0 end),0)) NopTien ,sum(coalesce((case when SoTien > 0 then SoTien else 0 end),0)) RutTien , MaDL from CTNGANHANG WHERE (convert(date, NgayHT) BETWEEN @TuNgay AND @DenNgay) and LoaiKhachHang = 8 GROUP BY MaDL) NH ON NH.MaDL = DL1.ID
left join (select SoDuCuoi 'SoDuCuoiCoDinh' ,NCCID from SODU_HANG WHERE  convert(date, Ngay) = @DenNgay) SD2 on SD2.NCCID = DL1.ID
left join (select SUM((case when LoaiGiaoDich = 1 then SoTien else 0 end)) 'SoTienDuong',SUM((case when LoaiGiaoDich != 1 then SoTien else 0 end)) 'SoTienAm',NCC  from NHACUNGCAP_GIAODICHPHATSINH where convert(date, NgayGD) BETWEEN @TuNgay AND @DenNgay group by NCC ) NCCPS on NCCPS.NCC = DL1.ID
{2}", Tu.ToString("yyyyMMdd"), Den.ToString("yyyyMMdd"), All ? "" : "where coalesce(NhaCungCap,0) + coalesce(NH.MaDL,0) >0"));
        }

        public List<TheoDoiO> DuLieuNH(DateTime Tu, DateTime Den, bool All)
        {
            return LayDuLieu<TheoDoiO>(false, string.Format(@"declare @TuNgay date = '{0}'
declare @DenNgay date = '{1}'
select Ten,TenTK 'MaDL',ID,coalesce(SoDuDauDuong,0) 'SoDuDauDuong',coalesce(GiaDuong,0) 'GiaDuong',coalesce(GiaAm,0) 'GiaAm',coalesce(SoDuCuoiDuong,0) 'SoDuCuoiDuong'
from (select Ten,TenTK,ID from NGANHANG) T1
left join (select NganHangID
				, coalesce(SoDuCuoi,0) SoDuDauDuong
				from SODU_NGANHANG where CONVERT(date,Ngay) = DATEADD(day,-1,@TuNgay)) T2 on T1.ID = T2.NganHangID
left join (select NganHangID
				, SUM((CASE WHEN coalesce(SoTien,0) > 0 THEN coalesce(SoTien,0) ELSE 0 END)) GiaDuong
				, SUM((CASE WHEN coalesce(SoTien,0) < 0 THEN 0 - coalesce(SoTien,0) ELSE 0 END)) GiaAm 
				from CTNGANHANG where TrangThaiID = 1 and CONVERT(date,NgayGD) BETWEEN @TuNgay AND @DenNgay group by NganHangID) GD2 on T1.ID = GD2.NganHangID
left join (select NganHangID
				, coalesce(SoDuCuoi,0) SoDuCuoiDuong
				from SODU_NGANHANG where CONVERT(date,Ngay) = @DenNgay) T3 on T1.ID = T3.NganHangID
{2}
", Tu.ToString("yyyyMMdd"), Den.ToString("yyyyMMdd"), All ? "" : "where coalesce(GiaDuong,0)>0 or coalesce(GiaAm,0)>0"));
        }
    }
}
