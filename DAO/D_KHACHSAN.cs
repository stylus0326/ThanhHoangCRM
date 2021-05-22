using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class D_KHACHSAN : DataProcess
    {

        public List<O_KHACHSAN> DuLieu(string CTV)
        {
            string a = string.Format(@"select KS.*,coalesce(bc.SoTien1,0) KhachThanhToan,coalesce(BC2.SoTien2,0) ThanhToanKS,ks.GiaHeThong - coalesce(bc.SoTien1,0) KhachThanhToanNo,ks.GiaNet -coalesce(BC2.SoTien2,0) ThanhToanKSNo,ks.SoTienBaoLuu -coalesce(BC3.SoTien3,0) ThanhToanBL
from KHACHSAN KS
LEFT JOIN (SELECT IDGDLienKet,SUM(SoTien) SoTien1 FROM BAOCAOCTNH WHERE LoaiGiaoDich = 1 AND THU = 0 GROUP BY IDGDLienKet) BC ON BC.IDGDLienKet = KS.ID
LEFT JOIN (SELECT IDGDLienKet,SUM(SoTien) SoTien2 FROM BAOCAOCTNH WHERE LoaiGiaoDich = 1 AND THU = 1 GROUP BY IDGDLienKet) BC2 ON BC2.IDGDLienKet = KS.ID
LEFT JOIN (SELECT IDGDLienKet,SUM(SoTien) SoTien3 FROM BAOCAOCTNH WHERE LoaiGiaoDich = 2 AND THU = 0 GROUP BY IDGDLienKet) BC3 ON BC3.IDGDLienKet = KS.ID
");
            return LayDuLieu<O_KHACHSAN>(false, a + CTV);
        }

        public List<O_KHACHSAN> DuLieu_ID(long ID)
        {
            return LayDuLieu<O_KHACHSAN>(true, "WHERE ID = " + ID);
        }

        List<int> lstDaiLyID;
        List<long> lstDaiLyLuyKe;
        public List<O_KHACHSAN> LayDanhSachCN(DateTime Tu, DateTime Toi, string ID)
        {
            lstDaiLyID = new List<int>();
            lstDaiLyLuyKe = new List<long>();

            List<O_KHACHSAN> lst = new List<O_KHACHSAN>();
            // Lấy số dư cuối ngày của các đại lý

            string CauTruyVan = string.Format(@"select dl.ID, dl.Ten, COALESCE(sd.SoDuCuoi, 0) as SoDuCuoi, COALESCE(gd.TongTien, 0) as SoDuVN from NHACUNGCAP dl 
left join (select * from SODU_HANG  where convert(date, Ngay)='{1}') sd on sd.NCCID = dl.ID 
left join (select SUM(COALESCE(GiaHeThong,0)-COALESCE(SoTienBaoLuu,0)) 'TongTien',KhachSan from KHACHSAN where convert(date, NgayGD) between DATEADD(DAY,1,EOMONTH('{1}',-1)) and '{1}' group by KhachSan) gd on gd.KhachSan = dl.ID 
where dl.ID = {0}", ID, Tu.AddDays(-1).ToString("yyyy-MM-dd"));
            DataTable data = LayDataTable(CauTruyVan);
            foreach (DataRow item in data.Rows)
            {
                int DaiLy = (int)item["ID"];
                O_KHACHSAN gd = new O_KHACHSAN();
                gd.ID = -1;
                gd.NgayGD = Tu;
                gd.GhiChu = "Số dư đầu kỳ";
                gd.IDKhachHang = DaiLy;
                gd.LuyKe = int.Parse(item["SoDuCuoi"].ToString());

                lst.Add(gd);
                lstDaiLyLuyKe.Add(gd.LuyKe);
                lstDaiLyID.Add(DaiLy);
            }

            string a = string.Format(@" SELECT * 
                                        FROM 
	                                        (SELECT [ID],[NgayGD],[MaCho], [Booking],KhachSan,'' GhiChu,GiaNet,0 TaiKhoanCo,coalesce(SoTienBaoLuu,0) SoTienBaoLuu, 0 LoaiGiaoDich , 0 LuyKe 
	                                         FROM KhachSan GD 
	                                         WHERE KhachSan IN ({0}) AND (convert(date, NgayGD) BETWEEN '{1}' and '{2}')
	                                         union all
	                                         SELECT CT.ID,NgayHT,'','',MaDL,GhiChu,0,0-SoTien,0,2,0
	                                         FROM CTNGANHANG CT
											 left join (select ID,Ten FROM NGANHANG) NH ON CT.NganHangID = NH.ID
	                                         WHERE MaDL IN ({0}) AND LoaiKhachHang = 8 AND (convert(date, NgayHT) BETWEEN '{1}' and '{2}')) GD
                                        ORDER BY convert(date, NgayGD), (case when LoaiGiaoDich = 2  then 0 else 1 end) ,ID", ID, Tu.ToString("yyyy/MM/dd"), Toi.ToString("yyyy/MM/dd"));

            DataTable q = LayDataTable(a);
            if (q.Rows.Count > 0)
                lst.AddRange(LayBanCongNoKS<O_KHACHSAN>(q, lstDaiLyID, lstDaiLyLuyKe));

            return lst;
        }

        public string GetSTT(DateTime d)
        {
            return (GetOneVale(string.Format("SELECT TOP 1 MaCho FROM KHACHSAN where MaCho like '{0}%' order by MaCho desc", d.ToString("yy") + "T" + d.ToString("MM"))) ?? "00T00-0000").ToString();
        }

        public List<O_KHACHSAN> DuLieuKS(bool NCC, int KS)
        {
            string a = string.Format(@"select * 
from KHACHSAN KS
LEFT JOIN (SELECT IDGDLienKet, SUM(SoTien) SoTien FROM BAOCAOCTNH WHERE Thu = '{0}' and LoaiGiaoDich = 1 group by IDGDLienKet) BC ON BC.IDGDLienKet = KS.ID
WHERE {2} = {3} and COALESCE(KS.{1},0) <> COALESCE(BC.SoTien,0)", NCC, NCC ? "GiaNet" : "GiaHeThong", NCC ? "KS.KhachSan" : "KS.IDKhachHang", KS);
            return LayDuLieu<O_KHACHSAN>(false, a);
        }

        public List<O_KHACHSAN> DuLieuKSBL(bool NCC)
        {
            string a = string.Format(@"select * 
from KHACHSAN KS
LEFT JOIN (SELECT IDGDLienKet, SUM(SoTien) SoTien FROM BAOCAOCTNH WHERE Thu = '{0}' and LoaiGiaoDich = 2 group by IDGDLienKet) BC ON BC.IDGDLienKet = KS.ID
WHERE COALESCE(KS.SoTienBaoLuu,0) <> COALESCE(BC.SoTien,0)", NCC);
            return LayDuLieu<O_KHACHSAN>(false, a);
        }
    }
}
