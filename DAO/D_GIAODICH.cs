
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DataAccessLayer
{
    public class D_GIAODICH : DataProcess
    {
        #region Lấy dữ liệu tích hợp
        public long ThucThiSua(List<O_GIAODICH> gd)
        {
            D_GIAODICH gdD = new D_GIAODICH();
            List<string> lststr = new List<string>();
            List<Dictionary<string, object>> lstDic = new List<Dictionary<string, object>>();
            for (int i = 0; i < gd.Count; i++)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("IDKhachHang", gd[i].IDKhachHang);
                dic.Add("NVGiaoDich", gd[i].NVGiaoDich);
                dic.Add("LoaiKhachHang", gd[i].LoaiKhachHang);
                dic.Add("GhiChu", gd[i].GhiChu);
                dic.Add("GiaNet", gd[i].GiaNet);
                dic.Add("GiaHoan", gd[i].GiaHoan);
                dic.Add("HangHoan", gd[i].HangHoan);
                dic.Add("GiaHeThong", gd[i].GiaHeThong);
                dic.Add("TinhCongNo", gd[i].TinhCongNo);
                dic.Add("VeTuXuat", false);
                lstDic.Add(dic);
                lststr.Add("WHERE ID = " + gd[i].ID);
            }
            return gdD.SuaNhieu1Ban(lstDic, lststr);
        }
        #endregion

        #region So sánh VN
        public List<O_GIAODICH> VoidVN(List<string> vs)
        {
            return LayDuLieu<O_GIAODICH>(true, string.Format(@"WHERE Replace(SoVeVN,' ','') in ('{0}') and LoaiGiaoDich in (4,13,14) and NhaCungCap = 2 and Hang = 'VN' and NgayGD > '20190101'", String.Join("' ,'", vs.ToArray())));
        }

        public List<O_GIAODICH> VeVN(List<string> vs, DateTime dtp, DateTime dtp2)
        {
            return LayDuLieu<O_GIAODICH>(false, string.Format(@"SELECT  N'Cty dư' GhiChu, ID, CONVERT(Date,NgayGD) 'NgayGD' , (case when SoVeVN is null then MaCho else SoVeVN end )SoVeVN ,GiaNet                                      FROM GIAODICH WHERE GiaNet <> 0 and LoaiGiaoDich in (4,13,14) and          NhaCungCap = 2 and Hang = 'VN' and ((NgayGD > '20190101' and SoVeVN in ('{0}')) or CONVERT(DATE,NgayGD) between '{1}' and '{2}')", String.Join("' ,'", vs.ToArray()), dtp.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }

        public List<O_GIAODICH> HoanVN(List<string> vs, DateTime dtp, DateTime dtp2)
        {
            return LayDuLieu<O_GIAODICH>(false, string.Format(@"SELECT N'Cty dư' GhiChu ,ID ,TinhCongNo ,LoaiGiaoDich, CONVERT(Date,NgayGD) 'NgayGD' , (case when SoVeVN is null then MaCho else SoVeVN end )SoVeVN ,0-HangHoan+GiaNet 'GiaNet'  FROM GIAODICH WHERE LoaiGiaoDich in (8,9) and  NhaCungCap = 2 and Hang = 'VN' and ((NgayGD > '20190101' and SoVeVN in ('{0}')) or (CONVERT(DATE,NgayGD) between '{1}' and '{2}' and TinhCongNo = 1))", String.Join("' ,'", vs.ToArray()), dtp.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }

        #endregion

        public List<O_GIAODICH> DuLieu_ID(long ID)
        {
            return LayDuLieu<O_GIAODICH>(true, "WHERE ID = " + ID);
        }

        public List<O_GIAODICH> DuLieuNganHang(string a)
        {
            string CauTruyVan = string.Format("WHERE ID IN ({0})", a);
            return LayDuLieu<O_GIAODICH>(true, CauTruyVan);
        }

        public List<O_GIAODICH> VeThuongVN(List<O_GIAODICH> lst)
        {
            string CauTruyVan = @"SELECT MaCho,GiaThu,NgayGD,TenKhach,BiDanh,SoVeVN FROM GIAODICH WHERE Hang = 'VN' AND NhaCungCap = 2 AND LoaiGiaoDich in (4,13,14) AND LEN(SoVeVN)>7 AND (";
            foreach (O_GIAODICH gd in lst)
            {
                CauTruyVan += string.Format("(SoVeVN = '{0}') OR ", gd.SoVeVN);
            }
            CauTruyVan = CauTruyVan.Substring(0, CauTruyVan.Length - 3) + ")";
            return LayDuLieu<O_GIAODICH>(false, CauTruyVan);
        }

        public bool KiemTraGiaoDich(string SoVe, bool isVNA)
        {
            return KiemTraDaTonTai(string.Format(@"where {0} = '{1}' AND LoaiGiaoDich in (8,9) ", isVNA ? "SoVeVN" : "MaCho", SoVe));
        }

        public List<O_GIAODICH> LayGiaoDichHoan(string str, bool isVNA)
        {
            return LayDuLieu<O_GIAODICH>(true, string.Format(@"WHERE {0} = '{1}' and LoaiGiaoDich in (4,13,14) ORDER BY NgayCapNhatLuyKe", isVNA ? "SoVeVN" : "MaCho", str));
        }

        public List<O_GIAODICH> GDRutGon(object Hang, DateTime A, DateTime B, bool Hoan)
        {
            if (Hoan)
                return LayDuLieu<O_GIAODICH>(true, string.Format(@"WHERE NhaCungCap = '{0}' and convert(date,NgayGD) between '{1}' and '{2}' and LoaiGiaoDich =9", Hang, A.ToString("yyyyMMdd"), B.ToString("yyyyMMdd")));
            else
                return LayDuLieu<O_GIAODICH>(true, string.Format(@"WHERE NhaCungCap = '{0}' and convert(date,NgayGD) between '{1}' and '{2}' and LoaiGiaoDich in (4,13,14)", Hang, A.ToString("yyyyMMdd"), B.ToString("yyyyMMdd")));
        }

        public List<O_GIAODICH> DuLieu(string CauTV, bool An)
        {
            return LayDuLieu<O_GIAODICH>(true, $"WHERE {(An ? "" : "An = 0 and")} {CauTV} order by NgayGD desc", ",coalesce(GiaHeThong,0) + coalesce(PhiCK,0) + coalesce(PhiCoDinh,0) + coalesce(HoaHong,0) - coalesce(GiaNet,0) - coalesce(GiaHoan,0) + coalesce(HangHoan,0) 'LoiNhuan'");
        }

        public int ChayCapNhatLuyKe(List<int> DL)
        {
            return ChayCauTruyVan(string.Format(@" update GIAODICH set CapNhatLuyKe = 0 where CapNhatLuyKe = 1 and IDKhachHang in ({0})
                                            update CTNGANHANG set CapNhatLuyKeNH = 0 where CapNhatLuyKeNH = 1 and MaDL = ({0}) and LoaiKhachHang in (2,3)",string.Join(",",DL.ConvertAll<string>(x => x.ToString()).ToArray())));
        }

        public List<O_GIAODICH> DuLieuVe(bool NCC, int KH)
        {
            string a = string.Format(@"select GD.ID, GD.GiaNet, GD.GiaThu, GD.MaCho, GD.NgayGD, GD.IDKhachHang 
from GIAODICH GD
LEFT JOIN (SELECT IDGDLienKet, SUM(SoTien) SoTien FROM BAOCAOCTNH WHERE Thu = '{0}' and LoaiGiaoDich = 0 group by IDGDLienKet) BC ON BC.IDGDLienKet = GD.ID
WHERE {2} = {3} and COALESCE(GD.{1},0) <> COALESCE(BC.SoTien,0) and GD.TinhCongNo = 1 and GD.LoaiGiaoDich <> 9", NCC, NCC ? "GiaNet" : "GiaThu", NCC ? "GD.NhaCungCap" : "GD.IDKhachHang", KH);
            return LayDuLieu<O_GIAODICH>(false, a);
        }

        public List<O_GIAODICH> DuLieuVeHoan(bool NCC, int KH)
        {
            string a = string.Format(@"select GD.ID, GD.HangHoan, GD.GiaHoan, GD.MaCho, GD.NgayGD, GD.IDKhachHang 
from GIAODICH GD
LEFT JOIN (SELECT IDGDLienKet, SUM(SoTien) SoTien FROM BAOCAOCTNH WHERE Thu = '{0}' and LoaiGiaoDich = 3 group by IDGDLienKet) BC ON BC.IDGDLienKet = GD.ID
WHERE COALESCE(GD.{1},0) <> COALESCE(BC.SoTien,0) and GD.TinhCongNo = 1 and GD.LoaiGiaoDich = 9", NCC, NCC ? "HangHoan" : "GiaHoan", NCC ? "GD.NhaCungCap" : "GD.IDKhachHang", KH);
            return LayDuLieu<O_GIAODICH>(false, a);
        }

        List<int> lstDaiLyID;
        List<long> lstDaiLyLuyKe;
        List<long> lstDaiLyLuyKeTong;
        public List<O_GIAODICH> LayDanhSachCN(DateTime tungay, DateTime denngay, string daily, bool total = false)
        {
            lstDaiLyID = new List<int>();
            lstDaiLyLuyKe = new List<long>();
            lstDaiLyLuyKeTong = new List<long>();

            List<O_GIAODICH> lst = new List<O_GIAODICH>();
            // Lấy số dư cuối ngày của các đại lý
            string daily_id = daily;

            string CauTruyVan = string.Format(@"select dl.ID, dl.Ten, COALESCE(sd.SoDuCuoi, 0) as SoDuCuoi, COALESCE(gd.TongTien, 0) as SoDuVN from DAILY dl 
left join (select * from SODU_DAILY  where convert(date, Ngay)='{1}') sd on sd.DaiLyID = dl.ID 
left join (select SUM(COALESCE(GiaThu,0)-COALESCE(GiaHoan,0)) 'TongTien',IDKhachHang from GIAODICH where convert(date, NgayGD) between DATEADD(DAY,1,EOMONTH('{1}',-1)) and '{1}' group by IDKhachHang) gd on gd.IDKhachHang = dl.ID 
where dl.ID in ({0})", daily_id.Replace("IDKhachHang", "ID"), tungay.AddDays(-1).ToString("yyyy-MM-dd"));
            DataTable data = LayDataTable(CauTruyVan);
            foreach (DataRow item in data.Rows)
            {
                int DaiLy = (int)item["ID"];
                O_GIAODICH gd = new O_GIAODICH();
                gd.ID = -1;
                gd.NgayGD = tungay;
                gd.TenKhach = "Số dư đầu kỳ";
                gd.IDKhachHang = DaiLy;
                gd.LoaiGiaoDich = -1;
                gd.LuyKe = int.Parse(item["SoDuCuoi"].ToString());
                if (int.Parse(tungay.ToString("dd")) == 1)
                    gd.LuyKeTong = 0;
                else
                    gd.LuyKeTong = int.Parse(item["SoDuVN"].ToString());

                lst.Add(gd);
                lstDaiLyLuyKeTong.Add(gd.LuyKeTong);
                lstDaiLyLuyKe.Add(gd.LuyKe);
                lstDaiLyID.Add(DaiLy);
            }

            string a = string.Format(@" SELECT * 
                                        FROM 
	                                        (SELECT [ID],[IDKhachHang],Agent, (case when LoaiGiaoDich <> 12 then COALESCE([GiaHoan],0) else 0 end) GiaHoan, [NgayGD], [TenKhach], [MaCho], [Hang], [SoVeVN], [LoaiVeDi], [LoaiVeVe], [TuyenBayDi], [TuyenBayVe], 
			                                        [PhiCK], [GiaHeThong], [GiaThu], (case when LoaiGiaoDich = 12 then GiaHoan else 0 end) [TaiKhoanCo],0 [LuyKe],[LoaiGiaoDich],[GioBayDi],[GioBayVe],0 [LuyKeTong],SoLuongVe,[PhiCoDinh],CapNhatLuyKe
	                                         FROM GIAODICH GD 
	                                         WHERE IDKhachHang IN ({0}) AND (convert(date, NgayGD) BETWEEN '{1}' and '{2}')  and LoaiGiaoDich not in (2,3) AND TinhCongNo = 1 and LoaiGiaoDich <> 60
	                                         union all
	                                         SELECT CT.ID,MaDL,'',0,NgayHT,TEN +': '+GhiChu,'','','','','','','',0,0,0,SoTien,0,LoaiGiaoDich,'','',0,0,0,CapNhatLuyKeNH
	                                         FROM CTNGANHANG CT
											 left join (select ID,Ten FROM NGANHANG) NH ON CT.NganHangID = NH.ID
	                                         WHERE MaDL IN ({0}) AND LoaiGiaoDich in (2,3,46,47,32,43) AND (convert(date, NgayHT) BETWEEN '{1}' and '{2}')) GD
                                        ORDER BY IDKhachHang, convert(date, NgayGD), (case when LoaiGiaoDich in (2, 3,46,47,32,43) then 0 else 1 end) ,ID", daily, tungay.ToString("yyyyMMdd"), denngay.ToString("yyyyMMdd"));

            DataTable q = LayDataTable(a);
            if (q.Rows.Count > 0)
                lst.AddRange(LayBanCongNo<O_GIAODICH>(q, lstDaiLyID, lstDaiLyLuyKe, lstDaiLyLuyKeTong));

            if (total)
            {
                foreach (DataRow item in data.Rows)
                {
                    int DaiLy = (int)item["ID"];
                    O_GIAODICH gd = new O_GIAODICH();
                    gd.ID = -1;
                    gd.NgayGD = new DateTime();
                    gd.TenKhach = "TỔNG CỘNG:";
                    gd.IDKhachHang = DaiLy;
                    gd.LoaiGiaoDich = -1;
                    gd.GiaHeThong = lst.Where(t => t.IDKhachHang.Equals((int)item["ID"])).Sum(w => w.GiaHeThong);
                    gd.PhiCK = lst.Where(t => t.IDKhachHang.Equals((int)item["ID"])).Sum(w => w.PhiCK);
                    gd.PhiCoDinh = lst.Where(t => t.IDKhachHang.Equals((int)item["ID"])).Sum(w => w.PhiCoDinh);
                    gd.HoaHong = lst.Where(t => t.IDKhachHang.Equals((int)item["ID"])).Sum(w => w.HoaHong);
                    gd.GiaThu = lst.Where(t => t.IDKhachHang.Equals((int)item["ID"])).Sum(w => w.GiaThu);
                    gd.TaiKhoanCo = lst.Where(t => t.IDKhachHang.Equals((int)item["ID"])).Sum(w => w.TaiKhoanCo);
                    lst.Add(gd);
                }
            }
            return lst;
        }
    }
}