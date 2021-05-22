using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading;

namespace CRM
{
    public partial class frmSoSanhVN : DevExpress.XtraEditors.XtraForm
    {
        public frmSoSanhVN()
        {
            InitializeComponent();
        }

        GiaoDichD giaoDich = new GiaoDichD();
        List<GiaoDichO> lstGDSCty = new List<GiaoDichO>();
        List<GiaoDichO> lstGDRCty = new List<GiaoDichO>();
        List<GiaoDichO> lstGDVCty = new List<GiaoDichO>();


        List<GiaoDichO> lstGDS3 = new List<GiaoDichO>();
        List<GiaoDichO> lstGDR4 = new List<GiaoDichO>();
        List<GiaoDichO> lstGDVHang = new List<GiaoDichO>();
        List<GiaoDichO> lstGDSHang = new List<GiaoDichO>();
        List<GiaoDichO> lstGDRHang = new List<GiaoDichO>();

        private void SoSanhVN_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            Ky(false);
        }

        private void btnex_Click(object sender, EventArgs e)
        {
            lstGDVHang = new List<GiaoDichO>();
            lstGDSHang = new List<GiaoDichO>();
            lstGDRHang = new List<GiaoDichO>();
            XtraOpenFileDialog ofd = new XtraOpenFileDialog();
            ofd.Title = "Mở File";
            ofd.Filter = "Excel File (*.xls) | *.xls";
            ofd.DefaultExt = ".xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ChuoiKetNoi = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + "; Extended Properties='HTML Import;HDR=No;IMEX=1';";//.xls
                using (OleDbConnection conn = new OleDbConnection(ChuoiKetNoi))
                {
                    conn.Open();
                    DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string CauTruyVan = "SELECT * FROM [" + dbSchema.Rows[0].Field<string>("TABLE_NAME").Replace("'", string.Empty) + ']';
                    OleDbDataAdapter da = new OleDbDataAdapter(CauTruyVan, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        GiaoDichO gd = new GiaoDichO();
                        switch (row[3].ToString())
                        {
                            case "S": //Vé
                                gd.GhiChu = "Cty thiếu";
                                gd.SoVeVN = row[2].ToString();
                                gd.GiaNet = long.Parse(row[7].ToString());
                                gd.NgayGD = DateTime.ParseExact(row[4].ToString().Substring(0, 10), "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
                                if (gd.GiaNet != 0)
                                    lstGDSHang.Add(gd);
                                break;
                            case "R": //Hoàn
                                gd.GhiChu = "Cty thiếu";
                                gd.SoVeVN = row[2].ToString();
                                gd.GiaNet = long.Parse(row[7].ToString());
                                if (row[5].ToString().Length > 5)
                                    gd.NgayGD = DateTime.ParseExact(row[5].ToString().Substring(0, 10), "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
                                else
                                    gd.NgayGD = DateTime.ParseExact(row[4].ToString().Substring(0, 10), "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
                                lstGDRHang.Add(gd);
                                break;
                            case "V": //Void
                                gd.SoVeVN = row[2].ToString();
                                gd.GiaNet = long.Parse(row[7].ToString());
                                gd.NgayGD = DateTime.ParseExact(row[4].ToString().Substring(0, 10), "yyyy/MM/dd", null);
                                lstGDVHang.Add(gd);
                                break;
                        }
                    }
                    gridControl1.DataSource = lstGDSHang.OrderBy(w => w.SoVeVN);
                    gridControl3.DataSource = lstGDRHang.OrderBy(w => w.SoVeVN);
                    gridControl7.DataSource = lstGDVHang.OrderBy(w => w.SoVeVN);
                    gridView1.BestFitColumns();
                    gridView6.BestFitColumns();
                    gridView15.BestFitColumns();
                }
            }
        }

        void Ky(bool sp)
        {
            DateTime date = DateTime.Now;
            if (sp)
                switch (spinEdit1.Value)
                {
                    case 1:
                        dateEdit1.DateTime = new DateTime(date.Year, date.Month, 1);
                        dateEdit2.DateTime = new DateTime(date.Year, date.Month, 7);
                        break;
                    case 2:
                        dateEdit1.DateTime = new DateTime(date.Year, date.Month, 8);
                        dateEdit2.DateTime = new DateTime(date.Year, date.Month, 15);
                        break;
                    case 3:
                        dateEdit1.DateTime = new DateTime(date.Year, date.Month, 16);
                        dateEdit2.DateTime = new DateTime(date.Year, date.Month, 23);
                        break;
                    case 4:
                        dateEdit1.DateTime = new DateTime(date.Year, date.Month, 24);
                        dateEdit2.DateTime = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
                        break;
                }
            else
            {
                if (date.Day < 9) spinEdit1.Value = 1;
                else if (date.Day < 16) spinEdit1.Value = 2;
                else if (date.Day < 24) spinEdit1.Value = 3;
                else spinEdit1.Value = 4;
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Ky(true);
        }

        List<GiaoDichO> ChuyenDoi(List<GiaoDichO> lst)
        {
            List<GiaoDichO> giaoDichOs = new List<GiaoDichO>();
            foreach (GiaoDichO giao in lst)
            {
                GiaoDichO giaoDich = new GiaoDichO(giao);
                giaoDichOs.Add(giaoDich);
            }
            return giaoDichOs.OrderBy(w => w.SoVeVN).ToList();
        }

        #region lấy dữ liệu
        private void groupControl7_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (lstGDSHang.Count > 0)
            {
                if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.ShowWaitForm();
                XuLyGiaoDien.wait.SetWaitFormDescription("Xử lý vé");
                lstGDSCty = giaoDich.VeVN(lstGDSHang.OrderBy(w => w.SoVeVN).Select(w => w.SoVeVN.Replace(" ", string.Empty)).ToList(), dateEdit1.DateTime, dateEdit2.DateTime).OrderBy(w => w.SoVeVN).ToList();
                GRS.DataSource = lstGDSCty;
                GVS.BestFitColumns();
                if (XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.CloseWaitForm();
            }//Lấy GD
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

            if (lstGDRHang.Count > 0)
            {
                if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.ShowWaitForm();
                XuLyGiaoDien.wait.SetWaitFormDescription("Xử lý vé hoàn");
                lstGDRCty = giaoDich.HoanVN(lstGDRHang.OrderBy(w => w.SoVeVN).Select(w => w.SoVeVN.Replace(" ", string.Empty)).ToList(), dateEdit1.DateTime, dateEdit2.DateTime).OrderBy(w => w.SoVeVN).ToList();
                GRR.DataSource = lstGDRCty;
                GVR.BestFitColumns();
                if (XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.CloseWaitForm();
            }//Lấy GD
        }
        private void groupControl9_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (lstGDVHang.Count > 0)
            {
                if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.ShowWaitForm();
                XuLyGiaoDien.wait.SetWaitFormDescription("Xử lý vé void");
                lstGDVCty = giaoDich.VoidVN(lstGDVHang.OrderBy(w => w.SoVeVN).Select(w => w.SoVeVN.Replace(" ", string.Empty)).ToList());
                gridControl6.DataSource = lstGDVCty;
                gridView12.BestFitColumns();
                if (XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.CloseWaitForm();
            }//Lấy GD
        }
        #endregion

        #region So sánh
        private void groupControl6_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            lstGDS3 = ChuyenDoi(lstGDSHang);
            List<GiaoDichO> lstGDS4 = ChuyenDoi(lstGDSCty);

            for (int u = 0; u < lstGDS4.Count; u++)//thông tin từ cty
            {
                for (int i = 0; i < lstGDS3.Count; i++)//thông tin từ hãng
                {
                    if (lstGDS4[u].SoVeVN.Replace(" ", string.Empty).Equals(lstGDS3[i].SoVeVN.Replace(" ", string.Empty)))//cùng số vé
                    {
                        lstGDS3[i].TinhCongNo = lstGDS4[u].TinhCongNo;
                        if (lstGDS4[u].NgayGD.ToString("ddMMyy").Equals(lstGDS3[i].NgayGD.ToString("ddMMyy")))//cùng ngày
                        {
                            if (lstGDS4[u].GiaNet - lstGDS3[i].GiaNet == 0)//cùng giá
                                lstGDS3.Remove(lstGDS3[i]);
                            else
                                lstGDS3[i].GhiChu = "Khác giá hệ thống";
                        }
                        else
                        {
                            if (lstGDS4[u].NgayGD >= dateEdit1.DateTime && dateEdit2.DateTime >= lstGDS4[u].NgayGD)//cùng kì
                            {
                                lstGDS3[i].GhiChu = "Khác ngày";
                                if (lstGDS4[u].GiaNet - lstGDS3[i].GiaNet != 0)//khác giá
                                    lstGDS3[i].GhiChu += " ,Khác giá hệ thống";
                                else
                                    lstGDS3[i].ID = lstGDS4[u].ID;
                            }
                            else
                            {
                                lstGDS3[i].GhiChu = "Khác kì";
                                if (lstGDS4[u].GiaNet - lstGDS3[i].GiaNet != 0)//khác giá
                                    lstGDS3[i].GhiChu += " ,Khác giá hệ thống";
                                else
                                    lstGDS3[i].ID = lstGDS4[u].ID;
                            }
                        }
                        lstGDS4.Remove(lstGDS4[u]);
                        u--;
                        break;
                    }
                }
            }

            if (lstGDS4.Count > 0)
                lstGDS3.AddRange(lstGDS4);

            gridControl5.DataSource = lstGDS3.Where(w => !w.GiaNet.Equals(0)).OrderBy(w => w.SoVeVN);
            gridView10.BestFitColumns();
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            List<GiaoDichO> lstGDR3 = ChuyenDoi(lstGDRHang);
            lstGDR4 = ChuyenDoi(lstGDRCty);

            for (int i = 0; i < lstGDR3.Count; i++)//thông tin từ hãng
            {
                for (int u = 0; u < lstGDR4.Count; u++)//thông tin từ cty
                {
                    if (lstGDR4[u].SoVeVN.Replace(" ", string.Empty).Equals(lstGDR3[i].SoVeVN.Replace(" ", string.Empty)))//cùng số vé
                    {
                        if (lstGDR4[u].NgayGD.ToString("ddMMyy").Equals(lstGDR3[i].NgayGD.ToString("ddMMyy")))//cùng ngày
                        {

                            if (lstGDR4[u].GiaNet - lstGDR3[i].GiaNet == 0)//cùng giá
                            {
                                if (lstGDR4[u].TinhCongNo)
                                    lstGDR4.Remove(lstGDR4[u]);
                                else
                                    lstGDR4[u].GhiChu = "Chưa nhận";
                            }
                            else
                            {
                                if (!lstGDR4[u].TinhCongNo)
                                    lstGDR4[u].GhiChu = "Chưa nhận, ";
                                else
                                    lstGDR4[u].GhiChu = string.Empty;
                                lstGDR4[u].GhiChu += "Khác giá hệ thống";
                            }

                        }
                        else
                        {
                            if (lstGDR4[u].NgayGD >= dateEdit1.DateTime && dateEdit2.DateTime >= lstGDR4[u].NgayGD)//cùng kì
                            {
                                lstGDR4[u].NgayGD = lstGDR3[i].NgayGD;
                                if (!lstGDR4[u].TinhCongNo)
                                    lstGDR4[u].GhiChu = "Chưa nhận, ";
                                else
                                    lstGDR4[u].GhiChu = string.Empty;
                                lstGDR4[u].GhiChu += "Khác ngày";
                                if (lstGDR4[u].GiaNet - lstGDR3[i].GiaNet != 0)//khác giá
                                    lstGDR4[u].GhiChu += ", Khác giá hệ thống";
                            }
                            else
                            {
                                lstGDR4[u].NgayGD = lstGDR3[i].NgayGD;
                                if (!lstGDR4[u].TinhCongNo)
                                    lstGDR4[u].GhiChu = "Chưa nhận, ";
                                else
                                    lstGDR4[u].GhiChu = string.Empty;
                                lstGDR4[u].GhiChu += "Khác kì";
                                if (lstGDR4[u].GiaNet - lstGDR3[i].GiaNet != 0)//khác giá
                                    lstGDR4[u].GhiChu += ", Khác giá hệ thống";
                            }
                        }
                        lstGDR3.Remove(lstGDR3[i]);
                        i--;
                        break;
                    }
                }
            }

            if (lstGDR3.Count > 0)
                lstGDR4.AddRange(lstGDR3);

            gridControl4.DataSource = lstGDR4.OrderBy(w => w.SoVeVN);
            gridView8.BestFitColumns();
        }
        #endregion

        #region Chỉnh ngày
        private void groupControl4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            GiaoDichD giaoDichD = new GiaoDichD();
            List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
            List<string> lstTb = new List<string>();
            List<string> lstCTV = new List<string>();
            List<string> lstThem = new List<string>();
            lstThem.Add("S");
            lstThem.Add("T");
            lstTb.Add("GIAODICH");
            lstTb.Add("LS_GIAODICH");

            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            List<GiaoDichO> sss = lstGDS3.Where(w => w.GhiChu.Contains("Khác kì") || w.GhiChu.Contains("Khác ngày")).ToList();
            for (int i = 0; i < sss.Count(); i++)
            {
                GiaoDichO gd = sss[i];
                XuLyGiaoDien.wait.SetWaitFormDescription(string.Format("Đang chỉnh ngày GD {0}/{1}", i, sss.Count()));
                Thread.Sleep(10);

                Dictionary<string, object> dicS = new Dictionary<string, object>();
                dicS.Add("NgayGD", gd.NgayGD);
                lstCTV.Add(string.Format("WHERE ID = {0}", gd.ID));
                lstDicS.Add(dicS);

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", "Tự động");
                dic.Add("MaCho", gd.SoVeVN);
                dic.Add("NoiDung", "[Vé thường]: Chỉnh ngày bằng so sánh VN");
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                lstCTV.Add(string.Empty);
                lstDicS.Add(dic);

                if (lstDicS.Count == 2)
                {
                    giaoDichD.CapNhat_ThemNhieu(lstDicS, lstTb, lstCTV, lstThem);
                    lstDicS.Clear();
                    lstCTV.Clear();
                }
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        private void groupControl3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            GiaoDichD giaoDichD = new GiaoDichD();
            List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
            List<string> lstTb = new List<string>();
            List<string> lstCTV = new List<string>();
            List<string> lstThem = new List<string>();
            lstThem.Add("S");
            lstThem.Add("S");
            lstThem.Add("T");
            lstTb.Add("GIAODICH");
            lstTb.Add("GIAODICH");
            lstTb.Add("LS_GIAODICH");
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            List<GiaoDichO> sss = lstGDR4.Where(w => w.GhiChu.Contains("Khác kì") || w.GhiChu.Contains("Khác ngày")).ToList();
            for (int i = 0; i < sss.Count(); i += 2)
            {
                XuLyGiaoDien.wait.SetWaitFormDescription(string.Format("Đang chỉnh ngày GD {0}/{1}", i, sss.Count()));
                Thread.Sleep(10);
                GiaoDichO gd = sss[i];
                GiaoDichO gd2 = sss[i + 1];
                Dictionary<string, object> dicS = new Dictionary<string, object>();
                Dictionary<string, object> dicS3 = new Dictionary<string, object>();
                dicS3.Add("NgayGD", gd2.NgayGD);
                lstCTV.Add(string.Format("WHERE ID = {0}", gd2.ID));
                lstDicS.Add(dicS3);

                dicS.Add("NgayGD", gd.NgayGD);
                lstCTV.Add(string.Format("WHERE ID = {0}", gd.ID));
                lstDicS.Add(dicS);

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", "Tự động");
                dic.Add("MaCho", gd.SoVeVN);
                dic.Add("NoiDung", "[Vé hoàn]: Chỉnh ngày bằng so sánh VN");
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                lstCTV.Add(string.Empty);
                lstDicS.Add(dic);

                if (lstDicS.Count == 3)
                {
                    giaoDichD.CapNhat_ThemNhieu(lstDicS, lstTb, lstCTV, lstThem);
                    lstDicS.Clear();
                    lstCTV.Clear();
                }
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

    }
}