﻿using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using mshtml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmCapSignIn : DevExpress.XtraEditors.XtraForm
    {
        MauEmailO ma = new MauEmailO();
        List<SignInO> lstSI = new List<SignInO>();
        List<SignInO> _lstSIChinh = new List<SignInO>();
        List<DaiLyO> _lstDL = new List<DaiLyO>();
        List<HangBayO> _lstHB = new List<HangBayO>();
        ChromeDriver driver;
        IJavaScriptExecutor js;
        WebDriverWait wait;
        public frmCapSignIn()
        {
            InitializeComponent();
        }

        private void frmCapSignIn_Load(object sender, EventArgs e)
        {
            ma = new MauEmailD().DuLieu()[5];
            _lstDL = new DaiLyD().All(false).Where(w => w.LoaiKhachHang.Equals(1)).ToList();

            for (int i = 0; i < _lstDL.Count; i++)
            {
                _lstDL[i].TenTam = (_lstDL[i].Ten + "_" + _lstDL[i].MaAGS).ToUpper();
            }

            daiLyOBindingSource.DataSource = _lstDL;
            _lstHB = new HangBayD().DuLieu().Where(w => w.SapXep).ToList(); ;
            hangBayOBindingSource.DataSource = _lstHB;
            List<NCCO> nc = new NCCD().DuLieu();
            lstSI = new SignInD().DuLieu();

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
            if ((key.GetValue("TepDinhKemSignIn") ?? string.Empty) != string.Empty)
            {
                txtFileDinhKem.Properties.Tokens.Clear();
                List<string> filenames = key.GetValue("TepDinhKemSignIn").ToString().Split(',').ToList();

                foreach (var item in filenames)
                {
                    string filename = Path.GetFileName(item);
                    var token_item = new TokenEditToken(filename + $" [{GetFileSizeFromFileNameURL(item)}]", item);
                    txtFileDinhKem.Properties.Tokens.Add(token_item);
                }
                try
                {
                    txtFileDinhKem.EditValue = string.Join(",", filenames);
                    txtFileDinhKem.Properties.PopupPanel = flyEmail;
                }
                catch (Exception ex)
                {
                    XuLyGiaoDien.Alert(ex.Message, Form_Alert.enmType.Warning);
                }
            }
        }

        private void iDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            DaiLyO dl = iDaiLy.GetSelectedDataRow() as DaiLyO;
            lSignIn.EditValue = null;
            signInOBindingSource.DataSource = lstSI.Where(w => w.DaiLy.Equals(dl.ID)).ToList();
            iMatKhau.Text = RandomPassword();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SignInO si = lSignIn.GetSelectedDataRow() as SignInO;
            if (si != null)
            {
                iHangBay.EditValue = si.HangBay;
                iSignIn.EditValue = si.SignIn;
                iChinh.Checked = si.Chinh;
            }
        }

        private void iHangBay_EditValueChanged(object sender, EventArgs e)
        {
            iMatKhau.Text = RandomPassword();
        }

        public string RandomPassword()
        {
            var passwordBuilder = new StringBuilder();

            passwordBuilder.Append(RandomString());
            passwordBuilder.Append(RandomString(3));
            passwordBuilder.Append(RandomNumber(1000, 9999));
            passwordBuilder.Append(RandomString(1).ToLower());
            passwordBuilder.Append(RandomString(1).ToUpper());

            return passwordBuilder.ToString();
        }

        private readonly Random _random = new Random();
        private static Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string RandomString(int size)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghiklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomString()
        {
            const string chars = "!@#$";
            return new string(Enumerable.Repeat(chars, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        void XulyDulieuKhiThem()
        {
            List<DaiLyO> dloz = _lstDL.Where(w => (_lstSIChinh.Select(u => u.DaiLy)).Contains(w.ID)).ToList();
            daiLyOBindingSource1.DataSource = dloz;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_lstSIChinh.Where(w => w.SignIn.Equals(iSignIn.Text) && iSignIn.Text.Length > 0).Count() == 0)
            {
                GCSI.DataSource = null;
                List<KiemTra> kiemTras = new List<KiemTra>();
                kiemTras.Add(new KiemTra() { _Control = icmb, _Tu = 1, _Den = 50 });
                kiemTras.Add(new KiemTra() { _Control = iHangBay, _Tu = 1, _Den = 50 });
                kiemTras.Add(new KiemTra() { _Control = iSignIn, _Tu = 1, _Den = 50, _ChoQuaThang = icmb.SelectedIndex == 0 });
                XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
                if (!dxValidationProvider1.Validate())
                {
                    XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                    return;
                }

                SignInO si = new SignInO();
                si.CanLam = icmb.SelectedIndex;
                si.DaiLy = (int)iDaiLy.EditValue;
                si.HangBay = (int)iHangBay.EditValue;
                si.SignIn = iSignIn.Text;
                si.MatKhau = iMatKhau.Text;
                si.Chinh = iChinh.Checked;
                _lstSIChinh.Add(si);
                GCSI.DataSource = _lstSIChinh;
                GVSI.ExpandAllGroups();
                XulyDulieuKhiThem();
            }
        }

        private void GVSI_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SignInO si = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
            if (si != null)
            {
                _lstSIChinh.Remove(si);
                GCSI.DataSource = null;
                GCSI.DataSource = _lstSIChinh;
                GVSI.ExpandAllGroups();
            }
        }

        private void icmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (icmb.SelectedIndex > 0 && lSignIn.EditValue == null)
                icmb.SelectedIndex = 0;
        }

        IWebElement ChromeFindElementByClassName(string _TagName, string _ClassName, int _ViTri = 0)
        {
            IList<IWebElement> lst = driver.FindElements(By.TagName(_TagName));
            int _viTri = 0;
            foreach (IWebElement ele in lst)
            {
                if (ele.GetAttribute("className") == _ClassName)
                {
                    if (_viTri == _ViTri)
                        return ele;
                    _viTri++;
                }
            }
            return null;
        }

        int CountElementByClassName(IWebDriver web, string _TagName, string _ClassName, string _Text = "")
        {
            IList<IWebElement> lst = web.FindElements(By.TagName(_TagName));
            int _viTri = 0;
            if (_Text == string.Empty)
                foreach (IWebElement ele in lst)
                {
                    if ((ele.GetAttribute("className") ?? string.Empty) == _ClassName)
                        _viTri++;
                }
            else
                foreach (IWebElement ele in lst)
                {
                    if ((ele.GetAttribute("className") ?? string.Empty) == _ClassName)
                        if (ele.Text == _Text)
                            _viTri++;
                }
            return _viTri;
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

            switch (int.Parse(e.Button.Properties.Tag.ToString()))
            {
                case 0:
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
                            da.Fill(dt);
                            _lstSIChinh.Clear();
                            foreach (DataRow row in dt.Rows)
                            {
                                SignInO signInO = new SignInO();
                                signInO.DaiLy = _lstDL.Where(w => w.TenTam.ToUpper().Equals(row[0].ToString().ToUpper())).First().ID;
                                signInO.HangBay = _lstHB.Where(w => w.TenTat.Equals(row[1].ToString())).First().ID;
                                signInO.SignIn = ((row[2] ?? null) ?? string.Empty).ToString();
                                signInO.MatKhau = row[3].ToString();
                                signInO.Chinh = row[4].ToString() != "False";
                                signInO.CanLam = int.Parse(row[5].ToString());
                                signInO.End = row[6].ToString() != "False";
                                _lstSIChinh.Add(signInO);
                            }
                            GCSI.DataSource = null;
                            GCSI.DataSource = _lstSIChinh;
                            _lstSIChinh = _lstSIChinh.OrderBy(w => w.HangBay).OrderBy(w => w.Khoa).ToList();
                            XulyDulieuKhiThem();
                            GVSI.ExpandAllGroups();
                        }
                    }
                    break;
                case 1:
                    colDaiLyTT.GroupIndex = -1;
                    XuLyGiaoDien.ExportExcel(GCSI, GVSI, "Cấp Sign-" + DateTime.Now.ToString("dd-MM-yyy"));
                    colDaiLyTT.GroupIndex = 0;
                    GVSI.ExpandAllGroups();
                    break;
                case 2:
                    List<Dictionary<string, object>> lstdic = new List<Dictionary<string, object>>();
                    for (int i = 0; i < _lstSIChinh.Count; i++)
                    {
                        if (lstSI.Where(w => w.SignIn.Equals(_lstSIChinh[i].SignIn)).Count() == 0)
                        {
                            Dictionary<string, object> keyValues = new Dictionary<string, object>();
                            keyValues.Add("DaiLy", _lstSIChinh[i].DaiLy);
                            keyValues.Add("SignIn", _lstSIChinh[i].SignIn);
                            keyValues.Add("HangBay", _lstSIChinh[i].HangBay);
                            keyValues.Add("Chinh", _lstSIChinh[i].Chinh);
                            keyValues.Add("Khoa", _lstSIChinh[i].Khoa);
                            keyValues.Add("MatKhau", _lstSIChinh[i].MatKhau);
                            lstdic.Add(keyValues);
                        }
                    }
                    if (lstdic.Count > 0)
                    {
                        if (new SignInD().ThemNhieu1Ban(lstdic) > 0)
                            XuLyGiaoDien.Alert("Thêm sign in thành công", Form_Alert.enmType.Success);
                    }
                    break;
                default:
                    _lstSIChinh = _lstSIChinh.OrderBy(w => w.HangBay).OrderBy(w => w.CanLam).ToList();

                    if (_lstSIChinh.Where(w => w.HangBay.Equals(2)).OrderBy(w => w.CanLam).ToList().Count > 0)
                    {
                        Thread thread1 = new Thread(Wb);
                        thread1.Start();
                    }
                    if (_lstSIChinh.Where(w => w.HangBay.Equals(3)).OrderBy(w => w.CanLam).ToList().Count > 0)
                    {
                        iVN = 0;
                        wVJ.Navigate("http://ags.thanhhoang.vn/Login.aspx");
                        List<int> lstA = _lstSIChinh.Where(w => w.HangBay.Equals(3)).Select(w => w.DaiLy).ToList();
                        lstDLAGS = _lstDL.Where(w => lstA.Contains(w.ID)).Select(w => w.MaAGS).ToList();
                    }
                    break;
            }
        }

        bool ThemDaiLy = false;
        void Wb()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            //chromeDriverService.HideCommandPromptWindow = true;

            try { driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }
            catch { options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }

            js = driver as IJavaScriptExecutor;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));

            for (int i = 0; i < _lstSIChinh.Count; i++)
            {
                if (_lstSIChinh[i].End || _lstSIChinh[i].HangBay != 2)
                    continue;

                #region VJ
                if (!driver.Url.Contains("vietjetair"))
                {
                    driver.Navigate().GoToUrl("https://www.vietjetair.com/Sites/Web/vi-VN/Home");
                    wait.Until(d => d.PageSource.Contains("https://agents.vietjetair.com/sitelogin.aspx?lang=vi"));
                    js.ExecuteScript("location.href = 'https://agents.vietjetair.com/sitelogin.aspx?lang=vi';");
                    wait.Until(d => d.PageSource.Contains("javascript:SubmitForm();"));
                    driver.FindElement(By.CssSelector("input[name='txtAgentID']")).SendKeys("AG38261201");//thẻ có tên là
                    driver.FindElement(By.CssSelector("#txtAgentPswd")).SendKeys("Doimoi2021$");// # ID
                    driver.FindElement(By.CssSelector(".button")).Click();// . Class
                    wait.Until(d => d.PageSource.Contains("button_big subAgencgyBtn"));
                    driver.FindElement(By.LinkText("Đại lý con")).Click();
                    wait.Until(d => CountElementByClassName(driver, "a", "user-icon ng-scope") == 5);
                    ChromeFindElementByClassName("a", "user-icon ng-scope", 0).Click();
                    wait.Until(d => d.FindElements(By.LinkText("New user")).Count > 0);
                    wait.Until(d => d.PageSource.Contains("base-loading-class") == false);
                }

                DaiLyO dl = _lstDL.Where(w => w.ID.Equals(_lstSIChinh[i].DaiLy)).ToList()[0];

                switch (_lstSIChinh[i].CanLam)
                {
                    case 0:
                        driver.FindElement(By.LinkText("New user")).Click();
                        wait.Until(d => d.PageSource.Contains("btn btn-secondary ng-binding"));
                        Thread.Sleep(1000);
                        wait.Until(d => d.PageSource.Contains("form-control ng-pristine ng-untouched ng-valid-we-validate ng-valid-maxlength ng-valid ng-valid-required"));

                        Thread.Sleep(2000);
                        object a = ChromeFindElementByClassName("input", "form-control ng-pristine ng-untouched ng-valid-we-validate ng-valid-maxlength ng-valid ng-valid-required", 0).GetAttribute("value");
                        Invoke(new MethodInvoker(delegate ()
                        {
                            _lstSIChinh[i].SignIn = a.ToString();
                            GCSI.DataSource = null;
                            GCSI.DataSource = _lstSIChinh;
                            GVSI.ExpandAllGroups();

                        }));

                        Actions build = new Actions(driver);
                        Thread.Sleep(1000);
                        build.Click(ChromeFindElementByClassName("div", "ui-select-container ui-select-multiple ui-select-bootstrap dropdown form-control ng-valid ng-valid-ui-select-required", 0)).Build().Perform();

                        Thread.Sleep(1000);
                        wait.Until(d => d.FindElements(By.LinkText("TA")).Count > 0);
                        driver.FindElement(By.LinkText("TA HOLD")).Click();

                        if (_lstSIChinh[i].Chinh)
                        {
                            wait.Until(d => d.PageSource.Contains("base-loading-class") == false);
                            js.ExecuteScript("document.getElementsByClassName('ui-select-search input-xs ng-pristine ng-valid ng-touched')[0].click()");
                            driver.FindElement(By.LinkText("TA")).Click();
                        }

                        ChromeFindElementByClassName("input", "form-control ng-pristine ng-untouched ng-invalid ng-invalid-required", 0).SendKeys(_lstSIChinh[i].MatKhau);
                        ChromeFindElementByClassName("input", "form-control ng-pristine ng-untouched ng-valid-we-validate ng-invalid ng-invalid-required", 0).SendKeys(_lstSIChinh[i].MatKhau);
                        ChromeFindElementByClassName("input", "form-control ng-pristine ng-untouched ng-valid-we-validate ng-invalid ng-invalid-required ng-valid-maxlength ng-valid-email", 0).SendKeys((dl.EmailGiaoDich ?? "tungtranims@gmail.com").Replace("\r\n", "|").Split('|')[0]);
                        ChromeFindElementByClassName("input", "form-control ng-pristine ng-untouched ng-valid-we-validate ng-invalid ng-invalid-required ng-valid-maxlength", 0).SendKeys(dl.DiDong ?? "0778516185");
                        ChromeFindElementByClassName("input", "form-control ng-pristine ng-untouched ng-invalid ng-invalid-required ng-valid-maxlength", 0).SendKeys(_lstSIChinh[i].SignIn + "-" + XuLyDuLieu.NotVietKey(dl.Ten).Replace(" ", string.Empty));

                        new SelectElement(ChromeFindElementByClassName("select", "form-control ng-pristine ng-untouched ng-invalid ng-invalid-required")).SelectByIndex(47);

                        ChromeFindElementByClassName("button", "btn btn-secondary ng-binding", 0).Submit();

                        Thread.Sleep(1000);
                        wait.Until(d => d.PageSource.Contains("base-loading-class") == false);
                        wait.Until(d => d.FindElements(By.LinkText("New user")).Count > 0);
                        _lstSIChinh[i].End = true;

                        break;
                }
                #endregion
            }
            driver.Close();
            driver.Quit();
        }

        private void frmCapSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("chromedriver"))
            { process.Kill(); }
        }

        List<string> lstdic = new List<string>();
        List<string> lstDLAGS = new List<string>();
        List<string> lstQAGS = new List<string>();
        List<string> lstMaAGSW = new List<string>();//lưu mã ags trên web
        int iVN = 0;
        DaiLyO dldl = new DaiLyO();
        private void wVJ_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wVJ.ReadyState == WebBrowserReadyState.Complete && !wVJ.IsBusy)
            {
                HtmlElement head = wVJ.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = wVJ.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                if (wVJ.Url.ToString().Contains("/Login.aspx")) // Đăng nhập
                {
                    wVJ.Document.GetElementById("txtUsernameVNiSC").SetAttribute("value", "admin");
                    wVJ.Document.GetElementById("txtMatKhau").SetAttribute("value", "11223399");
                    wVJ.Document.GetElementById("txtAgentCode").SetAttribute("value", "THD");

                    dynamic body = wVJ.Document.Body.DomElement;
                    dynamic controlRange = body.createControlRange();
                    dynamic element1 = wVJ.Document.GetElementById("imgImageValidate").DomElement;
                    controlRange.add(element1);
                    controlRange.execCommand("Copy", false, null);

                    string res = string.Empty;
                RetunA:
                    try
                    {
                        res = XuLyGiaoDien.ConvertImgToText((Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap));
                        if (res.Length < 3)
                            goto RetunA;
                    }
                    catch { wVJ.Navigate("http://ags.thanhhoang.vn/Login.aspx"); }
                    wVJ.Document.GetElementById("txtImageValidate").SetAttribute("value", res);
                    wVJ.Visible = true;
                    wVJ.Document.GetElementById("btnLogin").InvokeMember("click");
                }  // Đăng nhập
                else if (wVJ.Url.ToString().Contains("/Default.aspx") || wVJ.Url.AbsolutePath.Contains("/Booking.aspx")) //Vào trang thêm đại lý
                    wVJ.Navigate("http://ags.thanhhoang.vn/Agent.aspx?Do=SubAgent");
                else if (wVJ.Url.ToString().EndsWith("Agent.aspx?Do=SubAgent&Act=Add"))// Thêm đại lý
                {
                    dldl = _lstDL.Where(w => w.MaAGS.Equals(lstDLAGS[0])).First();
                    wVJ.Document.GetElementById("ctl08_txtAgentCode").SetAttribute("value", lstDLAGS[0]);
                    wVJ.Document.GetElementById("ctl08_txtAgentName").SetAttribute("value", dldl.Ten);
                    if (lstDLAGS.Count > 0)
                    {
                        if (_lstSIChinh.Where(w => w.DaiLy.Equals(dldl.ID) && w.HangBay.Equals(3) && w.Chinh).Count() > 0)
                            lstQAGS.Remove(lstDLAGS[0]);
                        lstDLAGS.Remove(lstDLAGS[0]);
                    }
                    wVJ.Document.GetElementById("ctl08_btOK").InvokeMember("click");
                }// Thêm đại lý
                else if (wVJ.Url.ToString().EndsWith("Agent.aspx?Do=SubAgent"))//Kiểm tra tồn tại đại lý
                {
                    if (lstDLAGS.Count == 0)
                    {
                        if (lstQAGS.Count == 0)
                            wVJ.Navigate("http://ags.thanhhoang.vn/Agent.aspx?Do=Ticketing");
                        else
                            wVJ.Navigate("http://ags.thanhhoang.vn/Accounting.aspx?Do=Deposit");
                    }
                    else
                    {
                        if (!ThemDaiLy)
                        {
                            HtmlElementCollection hc = wVJ.Document.GetElementsByTagName("div");
                            for (int i = 0; i < hc.Count; i++)
                            {
                                if (hc[i].GetAttribute("classname") == "item first")
                                    if (lstDLAGS.Contains(hc[i].InnerText))
                                        lstDLAGS.Remove(hc[i].InnerText);
                            }
                        }

                        ThemDaiLy = lstDLAGS.Count > 0;
                        if (lstDLAGS.Count > 0)
                            wVJ.Navigate("http://ags.thanhhoang.vn/Agent.aspx?Do=SubAgent&Act=Add");
                        else
                            wVJ.Navigate("http://ags.thanhhoang.vn/Agent.aspx?Do=Ticketing");
                    }
                }//Kiểm tra tồn tại đại lý
                else if (wVJ.Url.ToString().EndsWith("Accounting.aspx?Do=Deposit&Act=Add"))// Thêm quỹ
                {
                    HtmlElementCollection hc = wVJ.Document.GetElementsByTagName("option");
                    for (int i = 4; i < hc.Count; i++)
                    {
                        lstdic.Add(hc[i].InnerText);
                    }

                    int o = lstdic.FindIndex(x => x.StartsWith("0"));
                    if (o < 0)
                    {
                        XtraMessageBox.Show("Đại lý chưa được thêm trên ags", "Thông báo");
                        Dispose();
                        Close();
                    }
                    else
                    {
                        element.text = @"function doPost() { document.getElementById('ctl08_ddlSubAgent').options.item(" + o + ").selected = true; }";
                        head.AppendChild(scriptEl);
                        wVJ.Document.InvokeScript("doPost");

                        wVJ.Document.GetElementById("ctl08_txtAmount").SetAttribute("value", "20000000");
                        wVJ.Document.GetElementById("ctl08_txtDocNo").SetAttribute("value", "1");
                        wVJ.Document.GetElementById("ctl08_txtDocDate").SetAttribute("value", DateTime.Now.ToString("dd/MM/yyyy"));
                        wVJ.Document.Window.ScrollTo(0, 170);
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("SoCT", 2);
                        new DaiLyD().CapNhat(dic, _lstDL.Where(w => w.MaAGS.Equals(lstDLAGS[0])).First().ID);
                    }
                }// Thêm quỹ
                else if (wVJ.Url.ToString().Contains("Accounting.aspx?Do=Deposit"))
                {
                    if (lstQAGS.Count > 0)
                        wVJ.Document.GetElementById("ctl08_btnAddNew").InvokeMember("click");
                }// Thêm quỹ
                else if (wVJ.Url.ToString().EndsWith("Agent.aspx?Do=Ticketing&Act=Add"))
                {
                    dldl = _lstDL.Where(w => w.ID.Equals(_lstSIChinh[iVN].DaiLy)).First();
                    lstMaAGSW = lstMaAGSW.OrderByDescending(w => w).ToList();
                    HtmlElementCollection hc = wVJ.Document.GetElementsByTagName("option");
                    for (int i = 4; i < hc.Count; i++)
                    {
                        lstdic.Add(hc[i].InnerText);
                    }

                    int o = lstdic.FindIndex(x => x.StartsWith(dldl.MaAGS));
                    string _a = "AG" + dldl.MaAGS + "1";

                    if (lstMaAGSW.Where(w => w.Contains(dldl.MaAGS)).Count() > 0)
                    {
                        string a = lstMaAGSW.Where(w => w.Contains(dldl.MaAGS)).First();
                        _a = a.Substring(0, a.Length - 1) + (int.Parse(a.Substring(a.Length - 1, 1)) + 1);
                    }

                    wVJ.Document.GetElementById("ctl08_txtTenDangNhap").SetAttribute("value", _a);
                    wVJ.Document.GetElementById("ctl08_txtMatKhau").SetAttribute("value", _lstSIChinh[iVN].MatKhau);
                    wVJ.Document.GetElementById("ctl08_chkChangePassNextLogin").InvokeMember("click");
                    wVJ.Document.GetElementById("ctl08_txtHoTen").SetAttribute("value", dldl.Ten);

                    element.text = @"function doPost() { document.getElementById('ctl08_ddlSubAgent').options.item(" + o + ").selected = true; }";
                    head.AppendChild(scriptEl);
                    wVJ.Document.InvokeScript("doPost");

                    if (_lstSIChinh[iVN].Chinh)
                    {
                        element.text = @"function doPost() { document.getElementById('ctl08_ddlPermission').options.item(1).selected = true; }";
                        head.AppendChild(scriptEl);
                        wVJ.Document.InvokeScript("doPost");
                    }
                    Invoke(new MethodInvoker(delegate ()
                    {
                        _lstSIChinh[iVN].End = true;
                        _lstSIChinh[iVN].SignIn = _a.ToString();
                        GCSI.DataSource = null;
                        GCSI.DataSource = _lstSIChinh;
                        GVSI.ExpandAllGroups();

                    }));
                    iVN++;

                }
                else if (wVJ.Url.ToString().EndsWith("Agent.aspx?Do=Ticketing"))
                {
                    if (lstMaAGSW.Count == 0)
                    {
                        HtmlElementCollection hc = wVJ.Document.GetElementsByTagName("tr");
                        for (int i = 1; i < hc.Count; i++)
                        {
                            lstMaAGSW.Add(hc[i].Document.GetElementsByTagName("tr")[1].InnerText);
                        }
                    }

                    for (; iVN < _lstSIChinh.Count; iVN++)
                    {
                        if (_lstSIChinh[iVN].End || _lstSIChinh[iVN].HangBay != 3)
                            continue;
                        else
                        {
                            wVJ.Navigate("http://ags.thanhhoang.vn/Agent.aspx?Do=Ticketing&Act=Add");
                            break;
                        }
                    }
                }
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DaiLyO dl = searchLookUpEdit1.GetSelectedDataRow() as DaiLyO;
            string[] EmailKeToanString = Regex.Replace(dl.EmailKeToan ?? string.Empty, @"\t|\n|\r", "|").Replace("||", "|").Split('|');
            if (EmailKeToanString.Count() > 0)
                txtTen.Text = (checkEdit1.Checked) ? EmailKeToanString[0] : "cuongdt@thanhhoang.vn";
            else
                txtTen.Text = "cuongdt@thanhhoang.vn";
            txtTieuDe.Text = "{Quan Trọng} CẤP SIGIN-IN ĐẠI LÝ " + dl.Ten.ToUpper() + " " + dl.MaDL.ToUpper();

            List<SignInO> signInOs = _lstSIChinh.Where(w => w.DaiLy.Equals(dl.ID)).OrderBy(w => w.HangBay).OrderBy(w => w.Khoa).ToList();


            string VJ = string.Empty;
            string QH = string.Empty;
            string VN = string.Empty;
            string BL = string.Empty;
            string VU = string.Empty;
            for (int i = 0; i < signInOs.Count; i++)
            {
                switch (signInOs[i].HangBay)
                {
                    case 1:
                        BL += string.Format(@"<span class='csD4C8F03B'>
                                                   TK {2}     : {0}<br />
                                                   Mật khẩu    : {1}
                                              </span>", signInOs[i].SignIn, signInOs[i].MatKhau, signInOs[i].Chinh ? "Xuất" : "Book");
                        BL += @"<p class='cs5E94DF1'><span class='csA16174BA'>&nbsp;</span></p>";
                        break;
                    case 2:
                        VJ += string.Format(@"<span class='csD4C8F03B'>
                                                   TK {2}     : {0}<br />
                                                   Mật khẩu    : {1}
                                              </span>", signInOs[i].SignIn, signInOs[i].MatKhau, signInOs[i].Chinh ? "Xuất" : "Book");
                        VJ += @"<p class='cs5E94DF1'><span class='csA16174BA'>&nbsp;</span></p>";
                        break;
                    case 3:
                        VN += string.Format(@"<span class='csD4C8F03B'>
                                                   Mã đại lý   : THD<br />
                                                   TK {2}     : {0}<br />
                                                   Mật khẩu    : {1}
                                              </span>", signInOs[i].SignIn, signInOs[i].MatKhau, signInOs[i].Chinh ? "Xuất" : "Book");
                        VN += @"<p class='cs5E94DF1'><span class='csA16174BA'>&nbsp;</span></p>";
                        break;
                    case 6013:
                        QH += string.Format(@"<span class='csD4C8F03B'>
                                                   Mã đại lý   : 3780054 <br />
                                                   TK {2}     : {0}<br />
                                                   Mật khẩu    : {1}
                                              </span>", signInOs[i].SignIn, signInOs[i].MatKhau, signInOs[i].Chinh ? "Xuất" : "Book");
                        QH += @"<p class='cs5E94DF1'><span class='csA16174BA'>&nbsp;</span></p>";
                        break;
                    default:
                        VU += string.Format(@"<span class='csD4C8F03B'>
                                                   TK {2}     : {0}<br />
                                                   Mật khẩu    : {1}
                                              </span>", signInOs[i].SignIn, signInOs[i].MatKhau, signInOs[i].Chinh ? "Xuất" : "Book");
                        VU += @"<p class='cs5E94DF1'><span class='csA16174BA'>&nbsp;</span></p>";
                        break;
                }
            }

            if (VU.Length > 10)
            {
                VU = string.Format(@"<p class='cs5E94DF1'>
                <span class='cs9886E0DD'>VIETRAVEL:</span><span class='csD4C8F03B'>&nbsp;&nbsp;</span>
                <span class='cs5D2DD445'>
                    <a class='cs2356F87D' href='https://booking.vietravelairlines.vn/vi/ta' target='_blank'><span class='csA47FD31'>https://booking.vietravelairlines.vn/vi/ta</span></a>
                </span> 
                <span class='csD4C8F03B'>&nbsp;&nbsp;</span><span class='cs7AFC66BE'><br /></span>
                {0}
                </span>
            </p>", VU);
            }
            if (BL.Length > 10)
            {
                BL = string.Format(@"<p class='cs5E94DF1'>
                <span class='cs9886E0DD'>JETSTAR:</span><span class='csD4C8F03B'>&nbsp;&nbsp;</span>
                <span class='cs5D2DD445'>
                    <a class='cs2356F87D' href='https://booking.jetstar.com/agenthub/#/login?culture=vi-VN' target='_blank'><span class='csA47FD31'>https://booking.jetstar.com/agenthub/#/login?culture=vi-VN</span></a>
                </span> 
                <span class='csD4C8F03B'>&nbsp;&nbsp;</span><span class='cs7AFC66BE'><br /></span>
                {0}
                </span>
            </p>", BL);
            }
            if (VJ.Length > 10)
            {
                VJ = string.Format(@"<p class='cs5E94DF1'>
                <span class='cs9886E0DD'>VIETJET:</span><span class='csD4C8F03B'>&nbsp;&nbsp;</span>
                <span class='cs5D2DD445'>
                    <a class='cs2356F87D' href='https://www.vietjetair.com/Sites/Web/vi-VN/Home' target='_blank'><span class='csA47FD31'>https://www.vietjetair.com/Sites/Web/vi-VN/Home</span></a>
                </span> 
                <span class='csD4C8F03B'>&nbsp;&nbsp;</span><span class='cs7AFC66BE'><br /></span>
                {0}
                </span>
            </p>", VJ);
            }
            if (VN.Length > 10)
            {
                VN = string.Format(@"<p class='cs5E94DF1'>
                <span class='cs9886E0DD'>VIETNAM AIRLINES:</span><span class='csD4C8F03B'>&nbsp;&nbsp;</span>
                <span class='cs5D2DD445'>
                    <a class='cs2356F87D' href='http://ags.thanhhoang.vn/Login.aspx' target='_blank'><span class='csA47FD31'>http://ags.thanhhoang.vn/Login.aspx</span></a>
                </span> | 
                    <a class='cs2356F87D' href='http://muadi.com.vn/Login.aspx' target='_blank'><span class='csA47FD31'>http://muadi.com.vn/Login.aspx</span></a>
                <span class='csD4C8F03B'>&nbsp;&nbsp;</span><span class='cs7AFC66BE'><br /></span>
                {0}
                </span>
            </p>", VN);
            }
            if (QH.Length > 10)
            {
                QH = string.Format(@"<p class='cs5E94DF1'>
                <span class='cs9886E0DD'>BAMBOO:</span><span class='csD4C8F03B'>&nbsp;&nbsp;</span>
                <span class='cs5D2DD445'>
                    <a class='cs2356F87D' href='https://www.bambooairways.com/reservation/ibe/login?locale=vi' target='_blank'><span class='csA47FD31'>https://www.bambooairways.com/reservation/ibe/login?locale=vi</span></a>
                </span> 
                <span class='csD4C8F03B'>&nbsp;&nbsp;</span><span class='cs7AFC66BE'><br /></span>
                <span class='csD4C8F03B'>
                {0}
                </span>
            </p>", QH);
            }

            txtMauEmail.HtmlText = ma.NoiDung.Replace("{VN}", VN).Replace("{VJ}", VJ).Replace("{QH}", QH).Replace("{VU}", VU).Replace("{BL}", BL);
        }

        private void txtFileDinhKem_BeforeShowPopupPanel(object sender, TokenEditBeforeShowPopupPanelEventArgs e)
        {
            lblName.Text = e.Description;
            btn_open_file.Tag = e.Value.ToString();
            pic_extension_file.Image = Icon.ExtractAssociatedIcon(e.Value.ToString()).ToBitmap();
        }

        private void txtFileDinhKem_CustomDrawTokenGlyph(object sender, TokenEditCustomDrawTokenGlyphEventArgs e)
        {
            var file_name = e.Value.ToString();
            //Image image = icEmail.Images[0];
            var image = Icon.ExtractAssociatedIcon(file_name).ToBitmap();
            if (image != null) e.Cache.Paint.DrawImage(e.Graphics, image, e.GlyphBounds, new Rectangle(Point.Empty, image.Size), true);
            e.Handled = true;
        }

        private void btnFILE_Click(object sender, EventArgs e)
        {
            using (XtraOpenFileDialog xtraOpenFileDialog = new XtraOpenFileDialog())
            {
                xtraOpenFileDialog.Multiselect = true;
                xtraOpenFileDialog.RestoreDirectory = true;
                if (xtraOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileDinhKem.Properties.Tokens.Clear();
                    var filenames = xtraOpenFileDialog.FileNames;

                    foreach (var item in filenames)
                    {
                        string filename = Path.GetFileName(item);
                        var token_item = new TokenEditToken(filename + $" [{GetFileSizeFromFileNameURL(item)}]", item);
                        txtFileDinhKem.Properties.Tokens.Add(token_item);
                    }
                    try
                    {
                        txtFileDinhKem.EditValue = string.Join(",", filenames);
                        txtFileDinhKem.Properties.PopupPanel = flyEmail;
                    }
                    catch (Exception ex)
                    {
                        XuLyGiaoDien.Alert(ex.Message, Form_Alert.enmType.Warning);
                    }

                }
            }
        }

        private void btnTepCoDinh_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
            key.SetValue("TepDinhKemSignIn", (txtFileDinhKem.EditValue ?? string.Empty));
            key.Close();
        }

        public readonly string[] SizeSuffixes =
                 { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public string GetFileSizeFromFileNameURL(string filename)
        {
            FileInfo file_info = new FileInfo(filename);
            long value = file_info.Length;
            if (value < 0) { return "-"; }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            string file = btn_open_file.Tag as string;
            System.Diagnostics.Process.Start(file);
        }

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn gửi mail ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> vs = new List<string>();
                if ((txtFileDinhKem.EditValue ?? string.Empty) != string.Empty)
                    vs = txtFileDinhKem.EditValue.ToString().Split(',').ToList();

                CauHinhSMTPO cauHinhSMTPO = new CauHinhSMTPD().DuLieu();
                MauEmailO ma = new MauEmailD().DuLieu()[0];

                SmtpClient client = new SmtpClient();
                client.Port = cauHinhSMTPO.Port;
                client.Host = cauHinhSMTPO.Host;
                client.EnableSsl = cauHinhSMTPO.SSL;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("tungtranims@gmail.com", "time0326");

                if (txtTen.Text.Length > 5)
                {
                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress("tungtranims@gmail.com", "Thành Hoàng");
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mm.IsBodyHtml = true;
                    RichEditMailMessageExporter exporter = new RichEditMailMessageExporter(txtMauEmail, mm);
                    exporter.Export();
                    mm.To.Add(new MailAddress(txtTen.Text));
                    mm.Subject = txtTieuDe.Text;

                    foreach (string g in vs)
                    {
                        if (g.Count() > 0)
                            mm.Attachments.Add(new Attachment(g));
                    }
                    try
                    {
                        client.Send(mm);
                        XuLyGiaoDien.Alert("Gửi mail thành công", Form_Alert.enmType.Success);
                    }
                    catch (Exception ex) { XuLyGiaoDien.Alert(ex.Message, Form_Alert.enmType.Error); }
                }
            }
        }
    }
}