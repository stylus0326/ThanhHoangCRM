using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using mshtml;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmSoSanh : DevExpress.XtraEditors.XtraForm
    {
        List<O_NHACUNGCAP> _ListNCC = new List<O_NHACUNGCAP>();
        O_NHACUNGCAP _NCCO = new O_NHACUNGCAP();
        public frmSoSanh()
        {
            InitializeComponent();
        }

        private void frmNganHangAuto_Load(object sender, EventArgs e)
        {
            eDate1.EditValue = eDate2.EditValue = DateTime.Now.AddDays(-1);
            _ListNCC = new D_NHACUNGCAP().DuLieu();
            if (_ListNCC.Count < 21)
                rNCC.DropDownRows = _ListNCC.Count;
            NCCDB.DataSource = _ListNCC;
        }


        private void btnCH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<O_GIAODICH> l1 = new D_GIAODICH().GDRutGon(_NCCO.ID, ((DateTime)eDate1.EditValue), ((DateTime)eDate2.EditValue), false) as List<O_GIAODICH>;
            List<O_GIAODICH> l2 = new D_GIAODICH().GDRutGon(_NCCO.ID, ((DateTime)eDate1.EditValue), ((DateTime)eDate2.EditValue), true) as List<O_GIAODICH>;
            if (!chkMC.Checked)
            {
                for (int i = 0; i < l1.Count; i++) { l1[i].MaCho = l1[i].SoVeVN; }
                for (int i = 0; i < l2.Count; i++) { l2[i].MaCho = l2[i].SoVeVN; }
            }
            GCVTCT.DataSource = l1;
            GVVTCT.BestFitColumns();

            GCVHCT.DataSource = l2;
            GVVHCT.BestFitColumns();
        }

        private void rNganHang_EditValueChanged(object sender, EventArgs e)
        {
            _NCCO = (sender as LookUpEdit).GetSelectedDataRow() as O_NHACUNGCAP;
        }


        private void btnLo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetDataInExcel(true);
        }

        private void btnBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetDataInExcel(false);
        }

        private void btnLBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCKQT, GVKQT, string.Format("SoSanhVeThuong-{0}-{1}", _NCCO.Ten, DateTime.Now.ToString("dd-MM-yyy")));
            XuLyGiaoDien.ExportExcel(GCKQH, GVKQH, string.Format("SoSanhVeHoan-{0}-{1}", _NCCO.Ten, DateTime.Now.ToString("dd-MM-yyy")));
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<O_GIAODICH> VTCT = new List<O_GIAODICH>();
            List<O_GIAODICH> VTNCC = new List<O_GIAODICH>();
            List<O_GIAODICH> VHCT = new List<O_GIAODICH>();
            List<O_GIAODICH> VHNCC = new List<O_GIAODICH>();

            for (int i1 = 0; i1 < GVVTNCC.DataRowCount; i1++)
            {
                O_GIAODICH gd = GVVTNCC.GetRow(i1) as O_GIAODICH;
                gd.GhiChu = "Công ty thiếu vé";
                VTNCC.Add(gd);
            }// vé NCC
            for (int i1 = 0; i1 < GVVHNCC.DataRowCount; i1++)
            {
                O_GIAODICH gd = GVVHNCC.GetRow(i1) as O_GIAODICH;
                gd.GhiChu = "Công ty thiếu hoàn";
                VHNCC.Add(gd);
            }


            for (int i1 = 0; i1 < GVVTCT.DataRowCount; i1++)
            {
                O_GIAODICH gd = GVVTCT.GetRow(i1) as O_GIAODICH;
                if (VTNCC.Where(w => w.GiaNet.Equals(gd.GiaNet)
                && w.MaCho.Replace(" ", string.Empty).Equals(gd.MaCho.Replace(" ", string.Empty))).Count() == 0)
                {
                    gd.GhiChu = "Công ty dư vé";
                    VTCT.Add(gd);// tìm không thấy là vé dư
                }
                else
                    VTNCC.Remove(VTNCC.Where(w => w.GiaNet.Equals(gd.GiaNet)// tìm thấy xóa đi để tránh bị trùng
                && w.MaCho.Replace(" ", string.Empty).Equals(gd.MaCho.Replace(" ", string.Empty))).First());
            }
            VTCT.AddRange(VTNCC); //còn lại là code thiếu

            for (int i1 = 0; i1 < GVVHCT.DataRowCount; i1++)
            {
                O_GIAODICH gd = GVVHCT.GetRow(i1) as O_GIAODICH;
                if (VHNCC.Where(w => w.HangHoan.Equals(gd.HangHoan)
                && w.MaCho.Replace(" ", string.Empty).Equals(gd.MaCho.Replace(" ", string.Empty))).Count() == 0)
                {
                    gd.GhiChu = "Công ty dư hoàn";
                    VHCT.Add(gd);// tìm không thấy là vé dư
                }
                else
                    VHNCC.Remove(VHNCC.Where(w => w.HangHoan.Equals(gd.HangHoan)// tìm thấy xóa đi để tránh bị trùng
                && w.MaCho.Replace(" ", string.Empty).Equals(gd.MaCho.Replace(" ", string.Empty))).First());
            }
            VHCT.AddRange(VHNCC); //còn lại là code thiếu

            GCKQT.DataSource = VTCT;
            GCKQH.DataSource = VHCT;
        }


        int step = 0;
        int stepGetData = 0;
        List<O_GIAODICH> gdL = new List<O_GIAODICH>();
        string _Name = string.Empty;
        private void btnNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataVJ = new DataTable();
            gdL = new List<O_GIAODICH>();
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            if (_NCCO.ID == 1)
            {
                _Name = "VietJet";
                stepGetData = 0;
                wVJ.Visible = true;
                wVJ.Navigate("https://www.vietjetair.com/Sites/Web/vi-VN/Home");
                while (wVJ.IsBusy)
                {
                    Application.DoEvents();
                }
            }
            else if (_NCCO.ID == 5)
            {
                _Name = "BamBoo";
                step = 0;
                wQH.Visible = true;
                wQH.Navigate("https://www.bambooairways.com/reservation/ibe/login");
                while (wQH.IsBusy)
                {
                    Application.DoEvents();
                }
            }
        }

        private void wQH_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wQH.ReadyState == WebBrowserReadyState.Complete && !wQH.IsBusy)
            {
                Thread.Sleep(2000);
                HtmlElement head1 = wQH.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = wQH.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                if (wQH.Url.AbsolutePath.Contains("/login")) // Trang login
                {
                    wQH.Document.GetElementById("login-agency-code").SetAttribute("value", _NCCO.MaHang);
                    wQH.Document.GetElementById("login-agency-id").SetAttribute("value", _NCCO.TaiKhoan);
                    wQH.Document.GetElementById("login-password").SetAttribute("value", _NCCO.MatKhau);

                    element.text = @"function doPost() {submitLoginForm('en_US');}";
                    head1.AppendChild(scriptEl);
                    wQH.Document.InvokeScript("doPost");
                }
                else if (wQH.Url.AbsolutePath.Contains("/agent"))
                {
                    switch (step)
                    {
                        case 0:
                            element.text = @"function doPost() {createInvoice(event);}";
                            head1.AppendChild(scriptEl);
                            wQH.Document.InvokeScript("doPost");
                            break;
                        case 1:
                            wQH.Document.GetElementById("ir-start-date").SetAttribute("value", ((DateTime)eDate1.EditValue).ToString("dd/MM/yyyy"));
                            wQH.Document.GetElementById("ir-end-date").SetAttribute("value", ((DateTime)eDate2.EditValue).ToString("dd/MM/yyyy"));
                            element.text = @"function doPost() {doInvoice('/reservation','vi',true);}";
                            head1.AppendChild(scriptEl);
                            wQH.Document.InvokeScript("doPost");
                            break;
                        case 2:
                            if (((DateTime)eDate1.EditValue).Subtract(DateTime.Now).Days == 0)
                            {
                                element.text = @"function doPost() {viewdetails('0', 'VND', 'AG', '" + _NCCO.MaHang + "');}";
                                head1.AppendChild(scriptEl);
                                wQH.Document.InvokeScript("doPost");
                                step++;
                            }
                            else
                                wQH.Document.GetElementById("invoicedetails").InvokeMember("click");
                            break;
                        case 4:

                            HtmlElementCollection eleth = wQH.Document.GetElementsByTagName("th");
                            if (DataVJ.Columns.Count != 25)
                                for (int u = 0; u < eleth.Count; u++)
                                {
                                    DataVJ.Columns.Add(eleth[u].InnerText, (new int[] { 9, 10, 11, 13, 14, 15 }.Contains(u)) ? typeof(double) : typeof(string));
                                }
                            HtmlElementCollection ele = wQH.Document.GetElementsByTagName("tr");
                            List<O_GIAODICH> lst1 = new List<O_GIAODICH>();

                            foreach (HtmlElement eles in ele)
                            {
                                HtmlElementCollection elez = eles.GetElementsByTagName("td");

                                if (elez.Count == 0)
                                    continue;

                                List<string> lststr1 = new List<string>();
                                for (int u = 0; u < elez.Count; u++)
                                {
                                    if (elez[u].InnerText != null)
                                    {
                                        if (XuLyDuLieu.IsNumeric(elez[u].InnerText.Replace(",", string.Empty)))
                                            lststr1.Add(elez[u].InnerText.Replace(",", string.Empty));
                                        else
                                            lststr1.Add(elez[u].InnerText);
                                    }
                                    else
                                    {
                                        if (new int[] { 9, 10, 11, 13, 14, 15 }.Contains(u))
                                            lststr1.Add("0");
                                        else
                                            lststr1.Add(elez[u].InnerText);
                                    }
                                }
                                if (lststr1.Count == DataVJ.Columns.Count)
                                    DataVJ.Rows.Add(lststr1.ToArray());

                                O_GIAODICH gd = new O_GIAODICH();
                                string[] ten = elez[7].InnerText.Split('/');
                                gd.TenKhach = ten[1] + " " + ten[0];
                                gd.MaCho = elez[4].InnerText;

                                if (long.Parse(elez[15].InnerText.Replace(",", string.Empty)) < 0)
                                    gd.HangHoan = XuLyDuLieu.ConvertStringToLong(elez[15].InnerText);
                                else
                                    gd.GiaNet = XuLyDuLieu.ConvertStringToLong(elez[15].InnerText);
                                lst1.Add(gd);
                            }
                            GCVTNCC.DataSource = lst1.Where(w => w.GiaNet > 0);
                            GCVHNCC.DataSource = lst1.Where(w => w.HangHoan > 0);

                            if (ClsChucNang.wait.IsSplashFormVisible)
                                ClsChucNang.wait.CloseWaitForm();
                            XtraMessageBox.Show("Lấy dữ liệu thành công", "Thông báo");
                            wQH.Visible = false;
                            //element.text = @"function doPost() {invoiceDetailExport('xls','/reservation','vi');}";
                            //head1.AppendChild(scriptEl);
                            //wQH.Document.InvokeScript("doPost");
                            break;
                    }
                    step++;
                }
            }
        }

        DataTable DataVJ = new DataTable();
        private void wVJ_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wVJ.ReadyState == WebBrowserReadyState.Complete && !wVJ.IsBusy)
            {
                HtmlElement head = wVJ.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = wVJ.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                if (wVJ.Url.AbsolutePath.Contains("/CompanyPayRpt.aspx"))//lấy bản báo cáo ()
                {
                    int isM = 13 - (DateTime.Now.Year - ((DateTime)eDate1.EditValue).Year) * 12 - (DateTime.Now.Month - ((DateTime)eDate1.EditValue).Month);
                    int isM2 = 13 - (DateTime.Now.Year - ((DateTime)eDate2.EditValue).Year) * 12 - (DateTime.Now.Month - ((DateTime)eDate2.EditValue).Month);
                    string Datestr = string.Format(@"document.getElementById('dlstFromDate_Day').options.item({0}).selected = true; 
                                                              document.getElementById('dlstToDate_Day').options.item({1}).selected = true;
                                                              document.getElementById('dlstFromDate_Month').options.item({2}).selected = true;
                                                              document.getElementById('dlstToDate_Month').options.item({3}).selected = true;", ((DateTime)eDate2.EditValue).Day, ((DateTime)eDate1.EditValue).Day, isM2, isM);

                    int a = wVJ.Document.GetElementById("lstCompany").GetElementsByTagName("option").Count - 1;
                    switch (stepGetData)
                    {
                        case 0:
                            element.text = @"function doPost() { " + Datestr + " document.forms['CompanyPayments'].button.value='GetPaymnt';SubmitForm(); }";
                            head.AppendChild(scriptEl);
                            wVJ.Document.InvokeScript("doPost");
                            break;
                        default:
                            HtmlElement table = wVJ.Document.GetElementById("PayDetsGrd");
                            if (table != null)
                            {
                                HtmlElementCollection eles = wVJ.Document.GetElementsByTagName("tr");
                                foreach (HtmlElement ele in eles)
                                {
                                    switch (ele.GetAttribute("className"))
                                    {
                                        case "hdr_midTable":
                                            if (DataVJ.Columns.Count < 1)
                                            {
                                                HtmlElementCollection ths = ele.GetElementsByTagName("TH");
                                                if (ths.Count == 12)
                                                    for (int u = 0; u < 12; u++)
                                                    {
                                                        DataVJ.Columns.Add(ths[u].InnerText, ths[u].InnerText.StartsWith("Số tiền") ? typeof(double) : typeof(string));
                                                    }
                                            }
                                            break;
                                        case "GridPayDetsEven":
                                        case "GridPayDetsOdd":
                                            HtmlElementCollection tds = ele.GetElementsByTagName("TD");
                                            O_GIAODICH gd = new O_GIAODICH();

                                            gd.NgayGD = DateTime.ParseExact(tds[3].InnerText.Substring(0, tds[3].InnerText.IndexOf(' ')), "dd/MM/yyyy", null);
                                            gd.MaCho = tds[1].InnerText;
                                            gd.TenKhach = tds[2].InnerText.Replace(",", string.Empty);
                                            if (tds[11].InnerText.Contains("("))
                                                gd.HangHoan = long.Parse(new String(tds[9].InnerText.Where(Char.IsDigit).ToArray())) / 100;
                                            else
                                                gd.GiaNet = long.Parse(new String(tds[9].InnerText.Where(Char.IsDigit).ToArray())) / 100;
                                            if (gd.NgayGD.Date > ((DateTime)eDate1.EditValue).AddDays(-1).Date && gd.NgayGD.Date < ((DateTime)eDate2.EditValue).AddDays(1).Date)
                                                gdL.Add(gd);

                                            List<string> lststr1 = new List<string>();
                                            for (int u = 0; u < tds.Count; u++)
                                            {
                                                if (tds[u].InnerText != null)
                                                {
                                                    if (tds[u].InnerText.Contains("."))
                                                        lststr1.Add(tds[u].InnerText.Split('.')[0].Replace(",", string.Empty).Replace(")", string.Empty).Replace("(", "-"));
                                                    else
                                                        lststr1.Add(tds[u].InnerText);
                                                }
                                                else
                                                    lststr1.Add(tds[u].InnerText);
                                            }
                                            if (lststr1.Count == DataVJ.Columns.Count)
                                                DataVJ.Rows.Add(lststr1.ToArray());
                                            break;
                                    }
                                }
                            }

                            if (stepGetData != a)//chưa lấy hết sub nên chạy tiếp
                            {
                                element.text = @"function doPost() { document.getElementById('lstCompany').options.item(" + (stepGetData + 1) + ").selected = true; document.forms['CompanyPayments'].button.value='GetPaymnt';SubmitForm();}";
                                head.AppendChild(scriptEl);
                                wVJ.Document.InvokeScript("doPost");
                            }
                            else//xử lí dữ liệu sau khi đến sub cuối
                            {
                                GCVTNCC.DataSource = gdL.Where(w => w.GiaNet > 0);
                                GCVHNCC.DataSource = gdL.Where(w => w.HangHoan > 0);

                                if (ClsChucNang.wait.IsSplashFormVisible)
                                    ClsChucNang.wait.CloseWaitForm();
                                XtraMessageBox.Show("Lấy dữ liệu thành công", "Thông báo");
                                wVJ.Visible = false;
                            }
                            break;
                    }
                    stepGetData++;
                }
                else if (wVJ.Url.AbsolutePath.Contains("/AgentOptions.aspx"))//Đăng nhập thành công
                {
                    wVJ.Navigate("https://agents.vietjetair.com/CompanyPayRpt.aspx?lang=vi&st=sl&sesid=");
                }
                else if (wVJ.Url.AbsolutePath.Contains("/sitelogin.aspx"))//Bước đăng nhập
                {
                    head = wVJ.Document.GetElementById("wrapper");
                    if (head != null)
                        if (head.InnerText.ToLower().Contains("mật khẩu chưa đúng") || head.InnerText.ToLower().Contains("wrong password input"))
                            Close();
                    try
                    {
                        wVJ.Document.GetElementById("txtAgentID").SetAttribute("value", _NCCO.TaiKhoan);
                        wVJ.Document.GetElementById("txtAgentPswd").SetAttribute("value", _NCCO.MatKhau);
                        wVJ.Document.GetElementById("SiteLogin").InvokeMember("submit");
                    }
                    catch { }
                }
                else if (wVJ.Url.AbsolutePath.Contains("/Home"))
                {
                    element.text = "function doPost() { location.href = 'https://agents.vietjetair.com/sitelogin.aspx?lang=vi'; }";
                    head.AppendChild(scriptEl);
                    wVJ.Document.InvokeScript("doPost");
                }
            }
        }

        void GetDataInExcel(bool isCT)
        {
            XtraOpenFileDialog ofd = new XtraOpenFileDialog();
            ofd.Title = "Mở File";
            ofd.Filter = "Excel File (*.xlsx, *.xls) | *.xlsx; *.xls";
            ofd.DefaultExt = ".xlsx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ChuoiKetNoi = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + "; Extended Properties='Excel 12.0 Xml;HDR=YES';";
                using (OleDbConnection conn = new OleDbConnection(ChuoiKetNoi))
                {
                    conn.Open();
                    DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string CauTruyVan = "SELECT * FROM [" + dbSchema.Rows[0].Field<string>("TABLE_NAME").Replace("'", string.Empty) + ']';
                    OleDbDataAdapter da = new OleDbDataAdapter(CauTruyVan, conn);
                    DataTable dt = new DataTable();
                    int Dong = 0;
                    string Loi = string.Empty;
                    da.Fill(dt);
                    List<O_GIAODICH> lst = new List<O_GIAODICH>();
                    foreach (DataRow row in dt.Rows)
                    {
                        Dong++;
                        if (row["MaCho"].ToString().Length > 0 && (row["TienVe"].ToString().Length + row["TienHoan"].ToString().Length) > 0 && row["TenKhach"].ToString().Length > 0)
                        {
                            O_GIAODICH CVJ = new O_GIAODICH();
                            CVJ.TenKhach = row["TenKhach"].ToString();
                            CVJ.MaCho = row["MaCho"].ToString().Replace(" ", string.Empty);
                            if (long.Parse(row["TienVe"].ToString().Split('.')[0].Replace(",", string.Empty).Replace("-", string.Empty)) > 0)
                                CVJ.GiaNet = long.Parse(row["TienVe"].ToString().Split('.')[0].Replace(",", string.Empty).Replace("-", string.Empty));
                            else
                                CVJ.HangHoan = long.Parse(row["TienHoan"].ToString().Split('.')[0].Replace(",", string.Empty).Replace("-", string.Empty));
                            lst.Add(CVJ);
                        }
                        else
                        {
                            Loi += Dong.ToString() + ',';
                        }
                    }
                    if (isCT)
                    {
                        GCVTCT.DataSource = lst.Where(w => w.GiaNet > 0);
                        GCVHCT.DataSource = lst.Where(w => w.HangHoan > 0);
                    }
                    else
                    {
                        GCVTNCC.DataSource = lst.Where(w => w.GiaNet > 0);
                        GCVHNCC.DataSource = lst.Where(w => w.HangHoan > 0);
                    }
                }
            }
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DataVJ.Columns.Count > 5)
            {
                XtraSaveFileDialog sfd = new XtraSaveFileDialog();
                sfd.Title = "Save text Files";
                sfd.DefaultExt = "xlsx";
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.FileName = $"{_Name} {((DateTime)eDate1.EditValue).ToString("ddMMyy")}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage pck = new ExcelPackage(new FileInfo(sfd.FileName)))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                        ws.Cells["A1"].LoadFromDataTable(DataVJ, PrintHeaders: true);
                        for (var col = 1; col < DataVJ.Columns.Count + 1; col++)
                        {
                            if (DataVJ.Columns[col - 1].DataType == typeof(double))//col number 2 is equivalent to column B
                            {
                                ws.Column(col).Style.Numberformat.Format = "#,##0.00";//apply the number formatting you need
                                ws.Column(col).AutoFit();
                            }
                        }
                        var ms = new MemoryStream();
                        pck.Save();
                        XtraMessageBox.Show("Xong", "Thông báo");
                    }
                }
            }
        }
    }
}