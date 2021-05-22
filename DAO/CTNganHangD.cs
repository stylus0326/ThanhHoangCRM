using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CTNganHangD : DataProcess
    {
        public CTNganHangD()
        {
            TableName = "CTNganHang";
        }

        public List<CTNganHangO> DuLieu(string CTV, bool TienMat)
        {
            return LayDuLieu<CTNganHangO>(false, string.Format(@"SELECT ct.*,(case when ct.LoaiKhachHang = 4 then (select 'Hãng '+ TenHang from HANGBAY hb where hb.id = ct.MaDL)
													 when ct.LoaiKhachHang = 8 then (select TenDayDu from NHACUNGCAP hb where hb.ID = ct.MaDL)
			                                         when ct.LoaiKhachHang in (5,7) then (select Ten from NGANHANG nh where nh.id = ct.MaDL)
			                                         else dl.Ten end) Ten
                                        FROM CTNGANHANG ct
										left join DAILY dl on dl.id = ct.MaDL
                                        where NganHangID {1} 1 {0} order by ct.NgayGD desc", CTV, TienMat ? "=" : "<>"));
        }

        public List<CTNganHangO> Dem(string CTV)
        {
            return LayDuLieu<CTNganHangO>(true, CTV);
        }

        public List<CTNganHangO> LayDanhSachTheoNganHang(int ID, DateTime Tu)
        {
            string CauTruyVan = string.Format("SELECT convert(date,NgayGD) NgayGD,sum(SoTien) SoTien,GhiChu  FROM CTNGANHANG WHERE NganHangID = {0} and CONVERT(date,NgayGD) > '{1}' group by (case when GhiChuNV is null then cast(ID as nvarchar(10)) else GhiChuNV end) ,convert(date,NgayGD),GhiChu", ID, Tu.AddDays(-1).ToString("yyyyMMdd"));
            return LayDuLieu<CTNganHangO>(false,CauTruyVan);
        }
    }
}
