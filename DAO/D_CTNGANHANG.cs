using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_CTNGANHANG : DataProcess
    {
        public List<O_CTNGANHANG> DuLieu(string CTV, bool TienMat)
        {
            return LayDuLieu<O_CTNGANHANG>(false, string.Format(@"SELECT ct.*,(case when ct.LoaiKhachHang = 4 then (select 'Hãng '+ TenHang from HANGBAY hb where hb.id = ct.MaDL)
													 when ct.LoaiKhachHang = 8 then (select TenDayDu from NHACUNGCAP hb where hb.ID = ct.MaDL)
			                                         when ct.LoaiKhachHang in (5,7) then (select Ten from NGANHANG nh where nh.id = ct.MaDL)
			                                         else dl.Ten end) Ten,G2.LienKet
                                        FROM CTNGANHANG ct
										left join DAILY dl on dl.id = ct.MaDL
										left join (SELECT SS.IDCTNganHang, REPLACE(STUFF((SELECT CHAR(10) + cast(US.IDGDLienKet as varchar(15)) +' | '+ US.Code +' | '+ FORMAT(SoTien, '#,#0')
															  FROM BAOCAOCTNH US
															  WHERE US.IDCTNganHang = SS.IDCTNganHang
															  FOR XML PATH('')), 1, 1, ''),CHAR(10), CHAR(13)+CHAR(10)) LienKet
													FROM BAOCAOCTNH SS
													GROUP BY SS.IDCTNganHang) G2 on G2.IDCTNganHang = ct.ID
                                        where NganHangID {1} 1 {0} order by ct.NgayGD desc", CTV, TienMat ? "=" : "<>"));
        }

        public List<O_CTNGANHANG> DuLieu(string CTV)
        {
            return LayDuLieu<O_CTNGANHANG>(false, string.Format(@"SELECT ct.*,(case when ct.LoaiKhachHang = 4 then (select 'Hãng '+ TenHang from HANGBAY hb where hb.id = ct.MaDL)
													 when ct.LoaiKhachHang = 8 then (select TenDayDu from NHACUNGCAP hb where hb.ID = ct.MaDL)
			                                         when ct.LoaiKhachHang in (5,7) then (select Ten from NGANHANG nh where nh.id = ct.MaDL)
			                                         else dl.Ten end) Ten,G2.LienKet
                                        FROM CTNGANHANG ct
										left join DAILY dl on dl.id = ct.MaDL
										left join (SELECT SS.IDCTNganHang, REPLACE(STUFF((SELECT CHAR(10) + cast(US.IDGDLienKet as varchar(15)) +' | '+ US.Code +' | '+ FORMAT(SoTien, '#,#0')
															  FROM BAOCAOCTNH US
															  WHERE US.IDCTNganHang = SS.IDCTNganHang
															  FOR XML PATH('')), 1, 1, ''),CHAR(10), CHAR(13)+CHAR(10)) LienKet
													FROM BAOCAOCTNH SS
													GROUP BY SS.IDCTNganHang) G2 on G2.IDCTNganHang = ct.ID
                                        where NganHangID > 0 {0} order by ct.NgayGD desc", CTV));
        }

        public List<O_CTNGANHANG> Dem(string CTV)
        {
            return LayDuLieu<O_CTNGANHANG>(true, CTV);
        }

        public List<O_CTNGANHANG> LayDanhSachTheoNganHang(int ID, DateTime Tu)
        {
            string CauTruyVan = string.Format("SELECT convert(date,NgayGD) NgayGD,sum(SoTien) SoTien,GhiChu  FROM CTNGANHANG WHERE NganHangID = {0} and CONVERT(date,NgayGD) > '{1}' group by (case when GhiChuNV is null then cast(ID as nvarchar(10)) else GhiChuNV end) ,convert(date,NgayGD),GhiChu", ID, Tu.AddDays(-1).ToString("yyyyMMdd"));
            return LayDuLieu<O_CTNGANHANG>(false, CauTruyVan);
        }
    }
}
