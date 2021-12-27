using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_DAILY : DataProcess
    {
        #region Làm xong

        public List<O_DAILY> KhachLe()
        {

            return LayDuLieu<O_DAILY>(false, string.Format(@"SELECT DL.*,(case when CONVERT(date,NgayKiQuy)>CONVERT(date,GETDATE()-30) then N'Mới' else COALESCE(Nhom,'-') end ) Nhom,GiaoDichGanNhat 
FROM DAILY dl
LEFT JOIN(SELECT (case when SUM(COALESCE(giahethong,0) - COALESCE(hanghoan,0))<0 then 0 else SUM(COALESCE(giahethong,0) - COALESCE(hanghoan,0)) end) gia , IDKhachHang
			FROM GIAODICH WHERE LoaiGiaoDich in (4,8,9,13,14) group by IDKhachHang) g on dl.ID = g.IDKhachHang
LEFT JOIN(SELECT Ten 'Nhom', Tu,Den FROM NHOMDAILY WHERE LoaiKhachHang = 3 and id <> 17) g1 on g1.Tu -1 <COALESCE(Gia,0) and g1.Den + 1> COALESCE(Gia,0)
LEFT JOIN(SELECT MAX(NgayGD) 'GiaoDichGanNhat',IDKhachHang FROM GIAODICH GROUP BY IDKhachHang) NGN ON DL.ID = NGN.IDKhachHang
WHERE LoaiKhachHang = 3 order by GiaoDichGanNhat desc"));
        }

        public List<O_DAILY> NhanVien(string ten = "", string mk = "")
        {
            string a = @"SELECT 91 + coalesce(KPI,0) Diem,DL.* ,SoDu,COALESCE(SIC,0) SIC
FROM DAILY dl
LEFT JOIN (SELECT DaiLy,COUNT(SignIn) SIC FROM SIGNIN group by DaiLy) SI ON SI.DaiLy = DL.ID
LEFT JOIN (SELECT DaiLyID,SoDuCuoi 'SoDu' FROM SODU_DAILY WHERE CONVERT(DATE,Ngay) = CONVERT(DATE,GETDATE())) SD ON SD.DaiLyID = DL.ID
LEFT JOIN (SELECT SUM(Diem) KPI,NhanVien from KPI group by NhanVien) KPI on KPI.NhanVien = DL.ID
WHERE LoaiKhachHang = 0";

            if (mk.Length > 0)
                a += string.Format(" AND TenDangNhapCty = '{0}' AND MatKhauCty = '{1}'", ten, mk);
            else if (ten != "itadmin")
                a += " AND Nghi = 0";
            return LayDuLieu<O_DAILY>(false, a);
        }

        public List<O_DAILY> CongNo(int LoaiKhach, DateTime day1, DateTime day2)
        {
            return LayDuLieu<O_DAILY>(false, string.Format(@"SELECT ID, EmailKeToan, Ten, SoDuCuoi, MaDL FROM DAILY WHERE LoaiKhachHang = {2} and id in (select distinct IDKhachHang from GIAODICH where convert(date,NgayGD) BETWEEN '{0}' and '{1}') ORDER BY Ten", day1.ToString("yyyy/M/d"), day2.ToString("yyyy/M/d"), LoaiKhach));
        }

        public List<O_DAILY> HoaDon(DateTime day1, DateTime day2)
        {
            return LayDuLieu<O_DAILY>(false, string.Format(@"SELECT ID, EmailKeToan, Ten, SoDuCuoi, MaDL,LoaiKhachHang FROM DAILY WHERE id in (select distinct IDKhachHang from HOADON where convert(date,NgayThucHien) BETWEEN '{0}' and '{1}' AND MaHD <> '0' AND ((GiaYeuCau - GiaHeThong) * PhanTram / 100) > 0) and LoaiKhachHang in (1,2) ORDER BY Ten", day1.ToString("yyyyMMdd"), day2.ToString("yyyyMMdd")));
        }

        public List<O_DAILY> All(bool KL = true)
        {
            List<O_DAILY> lst = new List<O_DAILY>();
            lst.Add(new O_DAILY() { ID = -1, Ten = "-" });
            lst.Add(new O_DAILY() { ID = 0, Ten = "-" });
            string CRV = string.Format("SELECT ID, Ten, MaDL,LoaiKhachHang,EmailGiaoDich,EmailKeToan,NgayKiQuy,MaAGS, TenDangNhapCty FROM DAILY") + (KL ? "" : " where LoaiKhachHang <3");
            lst.AddRange(LayDuLieu<O_DAILY>(false, CRV));
            return lst;
        }

        public List<O_DAILY> DuLieu(int Loai)
        {
            string ctv = @"SELECT DL.*,(case when CONVERT(date,NgayKiQuy)>CONVERT(date,GETDATE()-30) then N'Mới' else COALESCE(Nhom,'-') end ) Nhom,GiaoDichGanNhat,QuyChet ,SoDu,cast(COALESCE(SICC,'0') as nvarchar(3))+'/'+cast(COALESCE(SIC,'0') as nvarchar(3)) SIC
FROM DAILY dl
LEFT JOIN (SELECT DaiLy,COUNT(SignIn) SIC FROM SIGNIN group by DaiLy) SI ON SI.DaiLy = DL.ID
LEFT JOIN (SELECT DaiLy,COUNT(SignIn) SICC FROM SIGNIN where Khoa = 0 group by DaiLy) SIK ON SIK.DaiLy = DL.ID
{0}
LEFT JOIN(SELECT Ten 'Nhom', Tu,Den FROM NHOMDAILY WHERE LoaiKhachHang = {1} and id <> 17) g1 on g1.Tu -1 <COALESCE(Gia,0) and g1.Den + 1> COALESCE(Gia,0)
LEFT JOIN(SELECT MAX(NgayGD) 'GiaoDichGanNhat',IDKhachHang FROM GIAODICH where LoaiGiaoDich  in (4,13,14) GROUP BY IDKhachHang) NGN ON DL.ID = NGN.IDKhachHang
LEFT JOIN(select coalesce(sum(SoTien),0) QuyChet,MaDL from CTNGANHANG where (LoaiGiaoDich = 14 or LoaiGiaoDich = 15) group by MaDL) QC ON QC.MaDL = NGN.IDKhachHang
LEFT JOIN (SELECT DaiLyID,SoDuCuoi 'SoDu' FROM SODU_DAILY WHERE CONVERT(DATE,Ngay) = CONVERT(DATE,GETDATE())) SD ON SD.DaiLyID = DL.ID
WHERE LoaiKhachHang = {1} and Nghi = 0 order by GiaoDichGanNhat desc";
            if (DateTime.Now.Day < 7)
                ctv = string.Format(ctv, @"LEFT JOIN(SELECT (case when SUM(COALESCE(giahethong,0) - COALESCE(hanghoan,0))<0 then 0 else SUM(COALESCE(giahethong,0) - COALESCE(hanghoan,0)) end) gia , IDKhachHang
			FROM GIAODICH WHERE CONVERT(date,NgayGD) BETWEEN DATEADD(DAY,1,EOMONTH(GETDATE(),-2)) and convert(date,EOMONTH (GETDATE(), -1 )) AND LoaiGiaoDich in (4,8,9,13,14) group by IDKhachHang) g on dl.ID = g.IDKhachHang", Loai);
            else
                ctv = string.Format(ctv, @"LEFT JOIN(SELECT (case when SUM(COALESCE(giahethong,0) - COALESCE(hanghoan,0))<0 then 0 else SUM(COALESCE(giahethong,0) - COALESCE(hanghoan,0)) end) gia , IDKhachHang
			FROM GIAODICH WHERE MONTH(NgayGD) = MONTH(GETDATE()) AND YEAR(NgayGD) = YEAR(GETDATE()) AND LoaiGiaoDich in (4,8,9,13,14) group by IDKhachHang) g on dl.ID = g.IDKhachHang", Loai);
            return LayDuLieu<O_DAILY>(false, ctv);
        }

        public enum Get { XoaAn, IDName }

        public List<O_DAILY> LayDanhSach(Get LayKieu, int LoaiKhach = 0, DateTime day1 = default(DateTime), DateTime day2 = default(DateTime))
        {
            string CTV = string.Empty;
            List<O_DAILY> lst = new List<O_DAILY>();
            switch (LayKieu)
            {
                case Get.XoaAn:
                    CTV = string.Format(@"SELECT * FROM DAILY WHERE LoaiKhachHang <> 4");
                    break;
                case Get.IDName:
                    CTV = string.Format(@"SELECT ID, Ten FROM DAILY WHERE LoaiKhachHang <  3");
                    break;

            }
            lst.AddRange(LayDuLieu<O_DAILY>(false, CTV));
            return lst;
        }

        public O_DAILY LayDaiLy(bool ID, string KieuDL)
        {
            string CTV = string.Empty;
            if (ID)
                CTV = string.Format(@"where ID = {0}", KieuDL);
            else
                CTV = string.Format("where Ten = N'{0}' and LoaiKhachHang <> 3", KieuDL);
            return LayMotDongDonGian<O_DAILY>(CTV);
        }
        #endregion

        #region Nợ


        public List<O_DAILY> LayDanhSachNo3NgayLienTiep(DateTime Ngay)
        {
            return LayDuLieu<O_DAILY>(false, string.Format(@"declare @Ngay datetime= '{0}' 
SELECT SD1.DaiLyID ID, Ten, DiDong, EmailKeToan, PhatQuyAm, SD1.SoDuCuoi 'SoDuCuoi1', COALESCE(SD2.SoDuCuoi,0) 'SoDuCuoi2',COALESCE(SD3.SoDuCuoi,0) 'SoDuCuoi3', CAST(0 - SD1.SoDuCuoi * CS.PhatQuyAm AS INT) 'TienPhat'
FROM		(SELECT DaiLyID,SoDuCuoi FROM SODU_DAILY WHERE SoDuCuoi < -400000 AND DATEDIFF(day, Ngay , @Ngay) = 1 AND LoaiKhachHangSD = 1) SD1
LEFT JOIN	(SELECT ID,ChinhSach,DiDong,EmailKeToan,Ten FROM DAILY	 WHERE MienPhat = 0) as SD0 ON SD0.ID = SD1.DaiLyID
LEFT JOIN	(SELECT DaiLyID,SoDuCuoi FROM SODU_DAILY WHERE SoDuCuoi < -400000 AND DATEDIFF(day, Ngay , @Ngay) = 2) SD2 ON SD2.DaiLyID = SD0.ID
LEFT JOIN	(SELECT DaiLyID,SoDuCuoi FROM SODU_DAILY WHERE SoDuCuoi < -400000 AND DATEDIFF(day, Ngay , @Ngay) = 3) SD3 ON SD3.DaiLyID = SD2.DaiLyID
LEFT JOIN	(SELECT IDKhachHang, MAX(LuyKe) LuyKe FROM GIAODICH WHERE DATEDIFF(day, NgayGD , @Ngay) IN (1,2,3) GROUP BY IDKhachHang) SD4 ON SD4.IDKhachHang = SD3.DaiLyID
LEFT JOIN	(SELECT ID,PhatQuyAm FROM CHINHSACH) CS ON CS.ID = SD0.ChinhSach 
WHERE COALESCE(SD2.SoDuCuoi,0) < 0 AND COALESCE(SD3.SoDuCuoi,0) < 0 AND COALESCE(LuyKe,0) < 1 AND (0 - SD1.SoDuCuoi * CS.PhatQuyAm > 999)
ORDER BY ID", Ngay.ToString("yyyyMMdd")));
        }
        #endregion

        public int KiemTraNgay(int num)
        {
            return (int)GetOneVale(string.Format("select count(*) from giaodich where loaigiaodich = 10 and convert(date,ngaygd) = convert(date,getdate() - {0})", num));
        }

        public long ChayLaiPhi(DateTime Tu)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("@Tungay", Tu.ToString("yyyyMMdd"));
            return EXECUP("UpdateNopQuyALL", dc);
        }

        public long ChaySoDu()
        {
            return ChayCauTruyVan(@"declare @TuNgay2 datetime = CONVERT(date, getdate()-60)
UPDATE SODU_DAILY SET SoDuCuoi = Sd.SoDu from 
	(
	SELECT * FROM (
	SELECT IDSD 'ID', G1.Ngay 'NgayGD',G1.DaiLyID 'DaiLyIDSD', COALESCE(G1.SoDuCuoi,0) 'SD', COALESCE(G.SoDuCuoi,0) + sum(COALESCE(G2.TongTien, 0) +  COALESCE(G3.SoTien, 0)) OVER (PARTITION BY G1.DaiLyID ORDER BY G1.DaiLyID, G1.Ngay) 'SoDu' 
	FROM 
	(SELECT DISTINCT CONVERT(DATE,Ngay) Ngay,IDSD,DaiLyID, SoDuCuoi FROM SODU_DAILY WHERE CONVERT(date, Ngay) > @Tungay2 - 1) G1
	LEFT JOIN (SELECT Ngay,DaiLyID,SoDuCuoi FROM SODU_DAILY WHERE CONVERT(date, Ngay) = @Tungay2 - 1) G ON G.DaiLyID = G1.DaiLyID

	LEFT JOIN (SELECT IDKhachHang, CONVERT(date,NgayGD) NgayGD, COALESCE(sum(GiaHoan),0) - COALESCE(sum(GiaThu),0) AS TongTien
				FROM GIAODICH WHERE TinhCongNo = 1 AND LoaiGiaoDich NOT IN (2,3,60) AND CONVERT(date, NgayGD) > @Tungay2 - 1
				GROUP BY IDKhachHang, CONVERT(date,NgayGD)) G2  
				on G2.NgayGD = G1.Ngay and G1.DaiLyID = G2.IDKhachHang

	LEFT JOIN (SELECT MaDL, CONVERT(date,NgayHT) NgayHT, COALESCE(sum(SoTien),0) SoTien 
				FROM CTNGANHANG WHERE CONVERT(date,NgayHT) > @Tungay2 - 1  and LoaiGiaoDich in (2, 3,46,47,32,43)
				GROUP BY MaDL,CONVERT(date,NgayHT)) G3 
				on G3.NgayHT = G1.Ngay and G1.DaiLyID = G3.MaDL ) Z
				WHERE SD<>SoDu
	) sD 
	where ID = SODU_DAILY.IDSD");
        }
    }
}
