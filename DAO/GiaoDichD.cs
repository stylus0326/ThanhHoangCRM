
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DataAccessLayer
{
    public class GiaoDichD : DataProcess
    {
        public GiaoDichD()
        { TableName = "GIAODICH"; }

        #region Lấy dữ liệu tích hợp
        public long ThucThiSua(List<GiaoDichO> gd)
        {
            GiaoDichD gdD = new GiaoDichD();
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
                dic.Add("VeTuXuat", false);
                lstDic.Add(dic);
                lststr.Add("WHERE ID = " + gd[i].ID);
            }
            return gdD.SuaNhieu1Ban(lstDic, lststr);
        }

        public void ChaySD()
        {
            EXECUP("RSSoDuHB");
            EXECUP("UpdateNopQuyALL");
            EXECUP("RSSoDuNH");
            EXECUP("RSSoDu");
        }

        public void Them(List<GiaoDichO> gd)
        {
            //    var query = gd.Where(w => w.LoaiKhachHang != 3)
            //          .GroupBy(cm => cm.IDKhachHang)
            //          .Select(g => new GiaoDichO
            //          {
            //              IDKhachHang = g.Key,
            //              NgayGD = g.Min(cm => cm.NgayGD)
            //          });

            long a = 0;
            List<Dictionary<string, object>> lstDic = new List<Dictionary<string, object>>();
            for (int i = 0; i < gd.Count; i++)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (gd[i].IDKhachHang < 1)
                    gd[i].LoaiKhachHang = 0;
                if (gd[i].NVGiaoDich < 1)
                    gd[i].VeTuXuat = true;

                foreach (PropertyInfo propertyInfo in gd[i].GetType().GetProperties())
                {
                    if (propertyInfo.Name.ToLower() == "end")
                        break;
                    if (propertyInfo.GetValue(gd[i], null) != null)
                    {
                        if (propertyInfo.PropertyType == typeof(DateTime))
                            dic.Add(propertyInfo.Name, ((DateTime)propertyInfo.GetValue(gd[i], null)).ToString("yyyyMMdd HH:mm"));
                        else
                            dic.Add(propertyInfo.Name, propertyInfo.GetValue(gd[i], null));
                    }
                }
                dic.Remove("ID");
                if (gd[i].SoLuongVe == 1)
                {
                    dic.Remove("GioBayVe");
                    dic.Remove("GioBayVe_Den");
                    dic.Remove("TuyenBayVe");
                    dic.Remove("SoHieuVe");
                    dic.Remove("LoaiVeVe");
                    dic.Remove("HanhLyVe");
                }
                lstDic.Add(dic);
                if (lstDic.Count > 5)
                {
                    a += ThemNhieu1Ban(lstDic);
                    lstDic.Clear();
                }
            }

            if (lstDic.Count > 0)
            {
                a += ThemNhieu1Ban(lstDic);
                lstDic.Clear();
            }
        }

        public List<GiaoDichO> VeHoan(List<GiaoDichO> lst, int NCC)
        {

            string CauTruyVan = @"SELECT MaCho,GiaHoan,NgayGD,TenKhach FROM GIAODICH WHERE NhaCungCap = " + NCC + " AND LoaiGiaoDich = 9 AND (";
            foreach (GiaoDichO gd in lst)
            {
                CauTruyVan += string.Format("(Macho = '{0}' and GiaHoan = {1} and CONVERT(DATE,NgayGD) = '{2}' and TenKhach = N'{3}') OR ", gd.MaCho, gd.GiaHoan, gd.NgayGD.ToString("yyyyMMdd"), gd.TenKhach);
            }

            CauTruyVan = CauTruyVan.Substring(0, CauTruyVan.Length - 3) + ")";
            return LayDuLieu<GiaoDichO>(false, CauTruyVan);
        }

        public List<GiaoDichO> LayDaiLyVeHoan(List<GiaoDichO> lst, int NCC)
        {
            List<string> a = lst.Select(w => w.MaCho).Distinct().ToList();
            string CauTruyVan = @"SELECT MaCho,LoaiKhachHang,IDKhachHang,TenKhach,GiaThu,GiaNet 
                                    FROM GIAODICH WHERE NhaCungCap = " + NCC + " AND LoaiGiaoDich in (4,13,14) " +
                                    "AND '" + string.Join(" ,", a.ToArray()) + "' like '%' + MaCho + '%' ORDER BY MaCho";
            return LayDuLieu<GiaoDichO>(false, CauTruyVan);
        }

        public List<GiaoDichO> VeThuong(List<GiaoDichO> lst, int NCC)
        {
            string CauTruyVan = "";
            if (NCC == 1 || NCC == 9 || NCC == 16)
            {
                CauTruyVan = @"SELECT MaCho,GiaNet,NgayGD,TenKhach,BiDanh,SoVeVN FROM GIAODICH WHERE NhaCungCap = " + NCC + " AND LoaiGiaoDich in (4,13,14) AND (";
                foreach (GiaoDichO gd in lst)
                {
                    CauTruyVan += string.Format("(Macho = '{0}' and GiaNet = {1} and CONVERT(DATE,NgayGD) = '{2}' and REPLACE(TenKhach,',','') = N'{3}') OR ", gd.MaCho, gd.GiaNet, gd.NgayGD.ToString("yyyyMMdd"), gd.TenKhach.Replace(",", ""));
                }
            }
            else
            {
                CauTruyVan = @"SELECT MaCho,GiaNet,NgayGD,TenKhach,BiDanh,SoVeVN FROM GIAODICH WHERE NhaCungCap = " + NCC + " AND LoaiGiaoDich in (4,13,14) AND LEN(SoVeVN)>7 AND (";
                foreach (GiaoDichO gd in lst)
                {
                    CauTruyVan += string.Format("(SoVeVN = '{0}' and GiaNet = {1} and CONVERT(DATE,NgayGD) = '{2}' and REPLACE(TenKhach,',','') = N'{3}') OR ", gd.SoVeVN, gd.GiaNet, gd.NgayGD.ToString("yyyyMMdd"), gd.TenKhach.Replace(",", ""));
                }
            }
            CauTruyVan = CauTruyVan.Substring(0, CauTruyVan.Length - 3) + ")";
            return LayDuLieu<GiaoDichO>(false, CauTruyVan);
        }

        public List<GiaoDichO> LayVeThuong(List<string> lst, int IsHoan)
        {
            lst = lst.Select(s => "738" + s.Split(',')[1]).Distinct().ToList();
            string CauTruyVan = String.Join("' ,'", lst.ToArray());
            if (IsHoan == 9)
                CauTruyVan = "WHERE NhaCungCap = 2 AND LoaiGiaoDich = 9 AND SoVeVN IN ('" + CauTruyVan + "')  and convert(date,ngaygd) >= convert(date,GETDATE() -400)";
            else
                CauTruyVan = "WHERE NhaCungCap = 2 AND LoaiGiaoDich in (4,13,14) AND SoVeVN IN ('" + CauTruyVan + "')  and convert(date,ngaygd) >= convert(date,GETDATE() -400)";
            return LayDuLieu<GiaoDichO>(true, CauTruyVan);
        }


        #endregion

        #region So sánh VN
        public List<GiaoDichO> VoidVN(List<string> vs)
        {
            return LayDuLieu<GiaoDichO>(true, string.Format(@"WHERE Replace(SoVeVN,' ','') in ('{0}') and LoaiGiaoDich in (4,13,14) and NhaCungCap = 2 and Hang = 'VN' and NgayGD > '20190101'", String.Join("' ,'", vs.ToArray())));
        }

        public List<GiaoDichO> VeVN(List<string> vs, DateTime dtp, DateTime dtp2)
        {
            return LayDuLieu<GiaoDichO>(false, string.Format(@"SELECT  N'Cty dư' GhiChu, ID, CONVERT(Date,NgayGD) 'NgayGD' , (case when SoVeVN is null then MaCho else SoVeVN end )SoVeVN ,GiaNet                                      FROM GIAODICH WHERE GiaNet <> 0 and LoaiGiaoDich in (4,13,14) and          NhaCungCap = 2 and Hang = 'VN' and ((NgayGD > '20190101' and SoVeVN in ('{0}')) or CONVERT(DATE,NgayGD) between '{1}' and '{2}')", String.Join("' ,'", vs.ToArray()), dtp.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }

        public List<GiaoDichO> HoanVN(List<string> vs, DateTime dtp, DateTime dtp2)
        {
            return LayDuLieu<GiaoDichO>(false, string.Format(@"SELECT N'Cty dư' GhiChu ,ID ,TinhCongNo ,LoaiGiaoDich, CONVERT(Date,NgayGD) 'NgayGD' , (case when SoVeVN is null then MaCho else SoVeVN end )SoVeVN ,0-HangHoan+GiaNet 'GiaNet'  FROM GIAODICH WHERE LoaiGiaoDich in (8,9) and  NhaCungCap = 2 and Hang = 'VN' and ((NgayGD > '20190101' and SoVeVN in ('{0}')) or (CONVERT(DATE,NgayGD) between '{1}' and '{2}' and TinhCongNo = 1))", String.Join("' ,'", vs.ToArray()), dtp.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd")));
        }

        #endregion

        public List<GiaoDichO> KhachEMAILVJ2()
        {
            string CauTruyVan = string.Format("select distinct EmailKhachHang,IDKhachHang from GIAODICH where NhaCungCap in (9,16) and IDKhachHang > 1 and EmailKhachHang is not null and LoaiKhachHang = 1");
            return LayDuLieu<GiaoDichO>(false, CauTruyVan);
        }

        public bool KiemTraGiaoDichJ2(string MaCho)
        {
            return KiemTraDaTonTai(string.Format(@"where MaCho = '{0}'", MaCho));
        }

        public List<GiaoDichO> DuLieuNganHang(string a)
        {
            string CauTruyVan = string.Format("WHERE ID IN ({0})", a);
            return LayDuLieu<GiaoDichO>(true, CauTruyVan);
        }

        public List<GiaoDichO> VeThuongVN(List<GiaoDichO> lst)
        {
            string CauTruyVan = @"SELECT MaCho,GiaThu,NgayGD,TenKhach,BiDanh,SoVeVN FROM GIAODICH WHERE Hang = 'VN' AND NhaCungCap = 2 AND LoaiGiaoDich in (4,13,14) AND LEN(SoVeVN)>7 AND (";
            foreach (GiaoDichO gd in lst)
            {
                CauTruyVan += string.Format("(SoVeVN = '{0}') OR ", gd.SoVeVN);
            }
            CauTruyVan = CauTruyVan.Substring(0, CauTruyVan.Length - 3) + ")";
            return LayDuLieu<GiaoDichO>(false, CauTruyVan);
        }

        public bool KiemTraGiaoDich(string SoVe, bool isVNA)
        {
            return KiemTraDaTonTai(string.Format(@"where {0} = '{1}' AND LoaiGiaoDich in (8,9) ", isVNA ? "SoVeVN" : "MaCho", SoVe));
        }

        public List<GiaoDichO> LayGiaoDichHoan(string str, bool isVNA)
        {
            return LayDuLieu<GiaoDichO>(true, string.Format(@"WHERE {0} = '{1}' and LoaiGiaoDich in (4,13,14) ORDER BY NgayCapNhatLuyKe", isVNA ? "SoVeVN" : "MaCho", str));
        }

        public List<GiaoDichO> GDRutGon(object Hang, DateTime A, DateTime B, bool Hoan)
        {
            if (Hoan)
                return LayDuLieu<GiaoDichO>(true, string.Format(@"WHERE NhaCungCap = '{0}' and convert(date,NgayGD) between '{1}' and '{2}' and LoaiGiaoDich =9", Hang, A.ToString("yyyyMMdd"), B.ToString("yyyyMMdd")));
            else
                return LayDuLieu<GiaoDichO>(true, string.Format(@"WHERE NhaCungCap = '{0}' and convert(date,NgayGD) between '{1}' and '{2}' and LoaiGiaoDich in (4,13,14)", Hang, A.ToString("yyyyMMdd"), B.ToString("yyyyMMdd")));
        }

        public List<GiaoDichO> DuLieu(string CauTV, bool An)
        {
            return LayDuLieu<GiaoDichO>(true, $"WHERE {(An ? "" : "An = 0 and")} {CauTV} order by NgayGD desc", ",coalesce(GiaHeThong,0) + coalesce(PhiCK,0) + coalesce(PhiCoDinh,0) + coalesce(HoaHong,0) - coalesce(GiaNet,0) - coalesce(GiaHoan,0) + coalesce(HangHoan,0) 'LoiNhuan'");
        }

        List<int> lstDaiLyID;
        List<long> lstDaiLyLuyKe;
        List<long> lstDaiLyLuyKeTong;
        public List<GiaoDichO> LayDanhSachCN(DateTime tungay, DateTime denngay, string daily, bool total = false)
        {
            lstDaiLyID = new List<int>();
            lstDaiLyLuyKe = new List<long>();
            lstDaiLyLuyKeTong = new List<long>();

            List<GiaoDichO> lst = new List<GiaoDichO>();
            // Lấy số dư cuối ngày của các đại lý
            string daily_id = daily;

            string CauTruyVan = string.Format(@"select dl.ID, dl.Ten, COALESCE(sd.SoDuCuoi, 0) as SoDuCuoi, COALESCE(gd.TongTien, 0) as SoDuVN from DAILY dl 
left join (select * from SODU_DAILY  where convert(date, Ngay)='{1}') sd on sd.DaiLyID = dl.ID 
left join (select SUM(COALESCE(GiaThu,0)-COALESCE(GiaHoan,0)) 'TongTien',IDKhachHang from GIAODICH where convert(date, NgayGD)between DATEADD(DAY,1,EOMONTH('{1}',-1)) and '{1}' group by IDKhachHang) gd on gd.IDKhachHang = dl.ID 
where dl.ID in ({0})", daily_id.Replace("IDKhachHang", "ID"), tungay.AddDays(-1).ToString("yyyy-MM-dd"));
            DataTable data = LayDataTable(CauTruyVan);
            foreach (DataRow item in data.Rows)
            {
                int DaiLy = (int)item["ID"];
                GiaoDichO gd = new GiaoDichO();
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
			                                        [PhiCK], [GiaHeThong], [GiaThu], (case when LoaiGiaoDich = 12 then GiaHoan else 0 end) [TaiKhoanCo],0 [LuyKe],[LoaiGiaoDich],[GioBayDi],[GioBayVe],0 [LuyKeTong],SoLuongVe,[PhiCoDinh]
	                                         FROM GIAODICH GD 
	                                         WHERE IDKhachHang IN ({0}) AND (convert(date, NgayGD) BETWEEN '{1}' and '{2}')  and LoaiGiaoDich not in (2,3) AND TinhCongNo = 1
	                                         union all
	                                         SELECT CT.ID,MaDL,'',0,NgayHT,TEN +': '+GhiChu,'','','','','','','',0,0,0,SoTien,0,LoaiGiaoDich,'','',0,0,0
	                                         FROM CTNGANHANG CT
											 left join (select ID,Ten FROM NGANHANG) NH ON CT.NganHangID = NH.ID
	                                         WHERE MaDL IN ({0}) AND LoaiGiaoDich in (2,3) AND (convert(date, NgayHT) BETWEEN '{1}' and '{2}')) GD
                                        ORDER BY IDKhachHang, convert(date, NgayGD), (case when LoaiGiaoDich=2 or LoaiGiaoDich = 3 then 0 else 1 end) ,ID", daily, tungay.ToString("yyyyMMdd"), denngay.ToString("yyyyMMdd"));

            DataTable q = LayDataTable(a);
            if (q.Rows.Count > 0)
                lst.AddRange(LayBanCongNo<GiaoDichO>(q, lstDaiLyID, lstDaiLyLuyKe, lstDaiLyLuyKeTong));

            if (total)
            {
                foreach (DataRow item in data.Rows)
                {
                    int DaiLy = (int)item["ID"];
                    GiaoDichO gd = new GiaoDichO();
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