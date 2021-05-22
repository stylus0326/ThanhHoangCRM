using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class BieuDoD : DataProcess
    {

        public List<BieuDoO> DuLieu1(long IDKhachHang,DateTime dateTime)
        {
            string CTV = string.Format(@"declare @ID bigint= {0}
declare @NgayKiQuy datetime = '{1}'
select ABN1.Ngay +CHAR(13) + CHAR(10)+ (case when CONCAT(YEAR(@NgayKiQuy),'/',RIGHT(100+MONTH(@NgayKiQuy),2)) = ABN1.Ngay then N'Mới' else COALESCE(Nhom,'-') end ) Ngay,i2,i3,cast([4] as bigint) 'i4',cast([13] as bigint)'i13',cast([14] as bigint)'i14',cast([0] as bigint)'i0'
,cast([1] as bigint) 'i1',cast([5] as bigint) 'i5',cast([6] as bigint) 'i6',cast([10] as bigint) 'i10',cast([9] as bigint) 'i9'
,cast([7] as bigint) 'i7',cast([11] as bigint) 'i11',cast([12] as bigint) 'i12'
from(
select CONCAT(YEAR(NgayGD),'/',RIGHT(100+MONTH(NgayGD),2)) Ngay, SUM((case when loaigiaodich in (9,7,11,12) then GiaHoan - coalesce(GiaThu,0) else GiaThu end)) SoTien,LoaiGiaoDich
from GIAODICH 
where IDKhachHang=@ID and LoaiGiaoDich not in (3,2) and  convert(date,NgayGD) >= DATEADD(MONTH,-12,convert(date,getdate()))
group by  year(NgayGD),MONTH(NgayGD),LoaiGiaoDich) Y pivot (max(SoTien) for LoaiGiaoDich in ([0],[1],[4],[5],[6],[10],[13],[14],[9],[11],[12],[7])) as ABN1


LEFT JOIN (SELECT Ngay,cast([2] as bigint) 'i2',cast([3] as bigint)'i3' FROM (
select CONCAT(YEAR(NgayHT),'/',RIGHT(100+MONTH(NgayHT),2)) Ngay,SUM(SoTien) SoTien,LoaiGiaoDich
from CTNGANHANG 
where MaDL=@ID  and LoaiGiaoDich in (3,2) and  convert(date,NgayHT) >= DATEADD(MONTH,-12,convert(date,getdate()))
group by  year(NgayHT),MONTH(NgayHT),LoaiGiaoDich) Y pivot (max(SoTien) for LoaiGiaoDich IN([2],[3])) AS PV) ABN2 ON ABN1.Ngay = ABN2.Ngay

LEFT JOIN(SELECT Ten 'Nhom', Tu,Den FROM NHOMDAILY WHERE LoaiKhachHang = 1 and id <> 17) TB2 on TB2.Tu -1 < COALESCE(cast([4] as bigint),0) and TB2.Den + 1> COALESCE(cast([4] as bigint),0)
order by ABN1.Ngay", IDKhachHang, dateTime.ToString("yyyyMMdd"));

            return LayDuLieu<BieuDoO>(false, CTV);
        }
    }
}
