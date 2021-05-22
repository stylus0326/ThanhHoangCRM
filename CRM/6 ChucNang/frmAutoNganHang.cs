using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmAutoNganHang : DevExpress.XtraEditors.XtraForm
    {
        List<O_NGANHANG> _LNganHangO = new List<O_NGANHANG>();
        O_NGANHANG _NganHangO = new O_NGANHANG();
        DateTime iTu = new DateTime();
        List<O_DAILY> dl = new List<O_DAILY>();
        public frmAutoNganHang()
        {
            InitializeComponent();
        }

        string Macode = string.Empty;
        private void frmAutoNganHang_Load(object sender, EventArgs e)
        {
            eNgay.EditValue = DateTime.Now;
            _LNganHangO = new D_NGANHANG().DuLieu(false).Where(w => w.Ex.Equals(true) && w.Nhom < 2).ToList();
            if (_LNganHangO.Count < 21)
                rNganHang.DropDownRows = _LNganHangO.Count;
            nganHangOBindingSource.DataSource = _LNganHangO;
            dl = new D_DAILY().DuLieu(1);
            DataTen.DataSource = DuLieuTaoSan.NganHangLoaiKhachHang(1);
            DataHinhThuc.DataSource = LoaiGiaoDich_NganHang_TatCa();
            DataLoaiKhach.DataSource = LoaiKhachHang_NganHang();
        }

        public static List<IntString> LoaiGiaoDich_NganHang_TatCa()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { Loai = 1, ID = 2, Name = "Nộp quỹ" }); ;//
            lst.Add(new IntString() { Loai = 1, ID = 3, Name = "Rút quỹ" });//
            lst.Add(new IntString() { Loai = 6, ID = 12, Name = "Excel" });
            return lst;
        }

        public static List<IntString> LoaiKhachHang_NganHang()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 1, Name = "Đại lý" });
            lst.Add(new IntString() { ID = 6, Name = "Khác" });
            return lst;
        }

        private void btnLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            _LNganHangO = new D_NGANHANG().DuLieu(false).Where(w => w.Ex.Equals(true) && w.Nhom < 2).ToList();
            nganHangOBindingSource.DataSource = _LNganHangO;
        }

        private void rNganHang_EditValueChanged(object sender, EventArgs e)
        {
            _NganHangO = (sender as LookUpEdit).GetSelectedDataRow() as O_NGANHANG;
            lblSD1.Caption = _NganHangO.SoDuCuoi.ToString("Số dư phần mềm: #,###");
        }

        private void eNgay_EditValueChanged(object sender, EventArgs e)
        {
            iTu = (DateTime)eNgay.EditValue;
        }

        public static int SoLanXuatHien(string Chuoi, string CanDem)
        {
            int strt = 0;
            int cnt = -1;
            int idx = -1;
            while (strt != -1)
            {
                strt = Chuoi.IndexOf(CanDem, idx + 1);
                cnt += 1;
                idx = strt;
            }
            return cnt;
        }

        long SoDu = 0;
        IWebElement ChromeFindElementByClassName(string _TagName, string _ClassName, int _ViTri = 0)
        {
            IList<IWebElement> lst = chromeDriver.FindElements(By.TagName(_TagName));
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

        ChromeDriver chromeDriver;
        IJavaScriptExecutor js;
        WebDriverWait wait;
        private void btnCH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized --window-size=1440,900");
            //chromeDriverService.HideCommandPromptWindow = true;
            if (chromeDriver != null)
            {
                try { chromeDriver.Navigate().GoToUrl("https://www.google.com.vn/"); }
                catch { chromeDriver = null; }
            }

            if (chromeDriver == null)
            {
                try { chromeDriver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }
                catch { options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; chromeDriver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }
                js = chromeDriver as IJavaScriptExecutor;
                wait = new WebDriverWait(chromeDriver, TimeSpan.FromMinutes(5));
                btnLo.Visibility = BarItemVisibility.Always;
            }
        }

        private void btnLo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Macode = DateTime.Now.ToString("ddMMMyymmss");
            SoDu = 0;
            if (_NganHangO != null)
            {
                try
                {
                    chromeDriver.Navigate().GoToUrl(_NganHangO.WURL);
                    switch (_NganHangO.ID)
                    {
                        case 2:
                            {
                                chromeDriver.SwitchTo().Frame(0);
                                chromeDriver.FindElement(By.Id("txtUsername")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("txtPassword")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Name("bu_2")).Click();
                                break;
                            }
                        case 3:
                            {
                                wait.Until(driver => driver.PageSource.Contains("inter"));
                                chromeDriver.FindElement(By.Id("inter")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("inter1")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.ClassName("inpCaptcha")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.ClassName("inpCaptcha")).GetAttribute("value").Length > 4);
                                chromeDriver.FindElement(By.Id("doOK")).Click();
                                if (chromeDriver.PageSource.Contains("Sai mã xác nhận"))
                                    return;
                                break;
                            }
                        case 4:
                        case 2020:
                            {
                                if (chromeDriver.Url.Contains("pageId=1"))
                                    ChromeFindElementByClassName("a", "button-blue", (_NganHangO.ID == 4) ? 0 : 1).Click();
                                wait.Until(driver => driver.FindElement(By.Id("password-password")));
                                chromeDriver.FindElement(By.Id("user-user")).SendKeys(_NganHangO.TenDangNhap);
                                js.ExecuteScript("document.getElementById('password-password').value = '" + _NganHangO.MatKhau + "'; document.getElementById('password-clear').value = '" + _NganHangO.MatKhau + "'");
                                try { chromeDriver.FindElement(By.Id("code-clear")).SendKeys(string.Empty); } catch { }
                                js.ExecuteScript(@"$(function() { $('#code-code').keyup(function() { this.value = this.value.toLocaleUpperCase();});});");
                                wait.Until(driver => driver.FindElement(By.Id("code-code")).GetAttribute("value").Length > 4);
                                chromeDriver.FindElement(By.ClassName("button-blue")).Click();
                                if (chromeDriver.PageSource.Contains("Sai mã xác thực"))
                                    return;
                                break;
                            }
                        case 6:
                            {
                                wait.Until(driver => driver.Url.Contains("BrowserServlet"));
                                chromeDriver.FindElement(By.Id("signOnName")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("password")).SendKeys(_NganHangO.MatKhau);
                                ChromeFindElementByClassName("input", "button red medium").Click();
                                break;
                            }
                        case 7:
                            {
                                chromeDriver.FindElement(By.ClassName("ilogin")).SendKeys(_NganHangO.TenDangNhap);
                                js.ExecuteScript("document.getElementsByClassName('ilogin ilogin-readonly')[0].value = '" + _NganHangO.MatKhau + "'");
                                chromeDriver.FindElement(By.ClassName("blogin")).Click();
                                break;
                            }
                        case 8:
                            {
                                chromeDriver.FindElement(By.Id("userNo")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("userPin")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Id("cap1")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.Id("cap1")).GetAttribute("value").Length > 4);
                                chromeDriver.FindElement(By.Id("LOGIN")).Click();
                                if (chromeDriver.PageSource.Contains("Mã Captch không hợp lệ"))
                                    return;
                                if (chromeDriver.Url.EndsWith("RBXLoginServlet"))
                                    return;
                                break;
                            }
                        case 9:
                        case 12:
                            {
                                chromeDriver.FindElement(By.Id("AuthenticationFG.USER_PRINCIPAL")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("AuthenticationFG.VERIFICATION_CODE")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.Id("AuthenticationFG.VERIFICATION_CODE")).GetAttribute("value").Length > 3);
                                chromeDriver.FindElement(By.Id("STU_VALIDATE_CREDENTIALS")).Click();

                                if (chromeDriver.PageSource.Contains("Vui lòng nhập những ký tự hiển thị trong hình"))
                                    return;

                                wait.Until(driver => driver.Url.Contains("jsessionid"));
                                chromeDriver.FindElement(By.ClassName("span-checkbox")).Click();
                                chromeDriver.FindElement(By.Id("AuthenticationFG.ACCESS_CODE")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Id("VALIDATE_STU_CREDENTIALS_UX")).Click();
                                break;
                            }
                        case 10:
                        case 1020:
                            {
                                chromeDriver.FindElement(By.Id("username")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("app_password_login")).SendKeys(_NganHangO.MatKhau);
                                //ChromeFindElementByClassName("input", "input input-xs input-material inputkey ng-untouched ng-pristine ng-invalid").SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Name("captcha")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.Name("captcha")).GetAttribute("value").Length > 4);
                                Thread.Sleep(1000);
                                ChromeFindElementByClassName("button", "no-m ubtn ubg-primary ubtn-md ripple").Click();
                                if (chromeDriver.PageSource.Contains("Mã kiểm tra không chính xác. Quý khách vui lòng kiểm tra lại"))
                                    return;
                                if (chromeDriver.PageSource.Contains("Mã kiểm tra đã hết hạn. Quý khách vui lòng kiểm tra lại"))
                                    return;
                                if (chromeDriver.PageSource.Contains("Hệ thống tạm thời gián đoạn. Quý khách vui lòng thử lại"))
                                    return;
                                break;
                            }
                        case 11:
                        case 13:
                            {
                                chromeDriver.SwitchTo().Frame(0);
                                chromeDriver.SwitchTo().Frame(0);
                                Thread.Sleep(2000);
                                if (ChromeFindElementByClassName("a", "btn btn-warning", 0) != null)
                                    ChromeFindElementByClassName("a", "btn btn-warning", 0).Click();
                                if (_NganHangO.ID == 13)
                                {
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.Id("logo-corp")).Click();
                                }
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.Id("txtUserName")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("txtPassKey")).SendKeys(_NganHangO.MatKhau);
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.Name("btnLogin")).Click();
                                break;
                            }
                        case 19:
                        case 2022:
                            {
                                chromeDriver.FindElement(By.Name("signOnName")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Name("password")).SendKeys(_NganHangO.MatKhau);
                                Thread.Sleep(1500);
                                ChromeFindElementByClassName("input", "btn_grey").Click();
                                break;
                            }
                        case 20:
                            {
                                chromeDriver.FindElement(By.Id("txtUserId")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("txtPassword")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Id("inputCaptcha")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.Id("inputCaptcha")).GetAttribute("value").Length > 5);
                                chromeDriver.FindElement(By.Id("btnSignIn")).Click();
                                if (chromeDriver.PageSource.Contains("Mã xác thực không khớp"))
                                    return;
                                break;
                            }
                        case 2023:
                            {
                                chromeDriver.FindElement(By.Id("ctl00_Content_Login_TenTC")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("ctl00_Content_Login_MatKH")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Id("ctl00_Content_Login_ImgStr")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.Id("ctl00_Content_Login_ImgStr")).GetAttribute("value").Length > 5);
                                chromeDriver.FindElement(By.Id("ctl00_Content_Login_LoginBtn")).Click();
                                break;
                            }
                        case 2024:
                            {
                                chromeDriver.FindElement(By.Id("username")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("password")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.Id("captcha")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.Id("captcha")).GetAttribute("value").Length > 5);
                                chromeDriver.FindElement(By.Id("btLogin")).Click();
                                break;
                            }
                        case 2026:
                            {
                                chromeDriver.FindElement(By.Id("corp-id")).SendKeys("0312171360");
                                chromeDriver.FindElement(By.Id("user-id")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("password")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.XPath("//*[@id='main-content']/mbb-welcome/div/div/div[2]/div[1]/mbb-login/form/div[1]/div[1]/mbb-word-captcha/div/div[2]/div[1]/input")).SendKeys(string.Empty);
                                wait.Until(driver => driver.FindElement(By.XPath("//*[@id='main-content']/mbb-welcome/div/div/div[2]/div[1]/mbb-login/form/div[1]/div[1]/mbb-word-captcha/div/div[2]/div[1]/input")).GetAttribute("value").Length > 5);
                                chromeDriver.FindElement(By.Id("login-btn")).Click();
                                break;
                            }
                        case 2027:
                            {
                                chromeDriver.FindElement(By.Id("j_username")).SendKeys(_NganHangO.TenDangNhap);
                                chromeDriver.FindElement(By.Id("password")).SendKeys(_NganHangO.MatKhau);
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[1]/form/div[2]/button")).Click();
                                break;
                            }
                        case 2028:
                            {
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.Id("j_username")).SendKeys(_NganHangO.TenDangNhap);
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.Id("loginSubmitButton")).Click();
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.Id("password")).SendKeys(_NganHangO.MatKhau);
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.Id("loginSubmitButton")).Click();
                                break;
                            }
                    }
                }
                catch { return; }
            }
            btnBC.Visibility = BarItemVisibility.Always;
        }

        private void btnBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                switch (_NganHangO.ID)
                {
                    case 2:
                        {
                            wait.Until(driver => driver.Url.Contains("home"));
                            chromeDriver.Navigate().GoToUrl("https://ebanking.vietinbank.vn/rcas/portal/web/retail/account-transaction-history");
                            wait.Until(driver => driver.Url.Contains("account-transaction-history"));
                            chromeDriver.SwitchTo().Frame(0);

                            chromeDriver.FindElement(By.ClassName("advanced-search-button")).Click();

                            wait.Until(driver => driver.Url.Contains("account-transaction-history"));
                            chromeDriver.FindElement(By.Id("searchStartDate")).Clear();
                            chromeDriver.FindElement(By.Id("searchEndDate")).Clear();
                            chromeDriver.FindElement(By.Id("searchStartDate")).SendKeys(iTu.ToString("dd/MM/yyyy"));
                            chromeDriver.FindElement(By.Id("searchEndDate")).SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));

                            ChromeFindElementByClassName("input", "button primary search").Click();
                            break;
                        }
                    case 3:
                        {
                            wait.Until(driver => driver.Url.EndsWith("ibank/"));
                            chromeDriver.Navigate().GoToUrl("https://ibank.agribank.com.vn/ibank/trans.jsp?cat=0");

                            wait.Until(driver => driver.Url.EndsWith("trans.jsp?cat=0"));
                            chromeDriver.Navigate().GoToUrl("https://ibank.agribank.com.vn/ibank/trans.jsp?cat=3&userAccNo=1606205771265");

                            wait.Until(driver => driver.Url.EndsWith("trans.jsp?cat=3&userAccNo=1606205771265"));
                            chromeDriver.FindElement(By.Id("datepickerFrom")).Clear();
                            chromeDriver.FindElement(By.Id("datepickerTo")).Clear();
                            chromeDriver.FindElement(By.Id("datepickerFrom")).SendKeys(" " + iTu.ToString("dd/MM/yyyy"));
                            chromeDriver.FindElement(By.Id("datepickerTo")).SendKeys(" " + DateTime.Now.ToString("dd/MM/yyyy"));
                            ChromeFindElementByClassName("div", "row_btn").FindElement(By.TagName("button")).Click();
                            break;
                        }
                    case 4:
                    case 2020:
                        {
                            wait.Until(driver => driver.Url.EndsWith("Request"));
                            ChromeFindElementByClassName("td", "table-style").Click();
                            wait.Until(driver => driver.Url.Contains("Request"));
                            chromeDriver.FindElement(By.Id("FromDate")).Clear();
                            chromeDriver.FindElement(By.Id("ToDate")).Clear();
                            chromeDriver.FindElement(By.Id("FromDate")).SendKeys(" " + iTu.ToString("dd/MM/yyyy"));
                            chromeDriver.FindElement(By.Id("ToDate")).SendKeys(" " + DateTime.Now.ToString("dd/MM/yyyy"));
                            ChromeFindElementByClassName("input", "nut1 button-blue").Click();
                            wait.Until(driver => driver.Url.Contains("Request"));
                            break;
                        }
                    case 6:
                        {
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "qwfieldset") == 4);
                            chromeDriver.FindElement(By.Name("AI.QCK.ACCOUNT")).Click();
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "contract_screen_div") == 3);
                            chromeDriver.FindElement(By.Id("fieldName:START.DATE")).SendKeys(iTu.ToString("dd/MM/yyyy"));
                            Thread.Sleep(2000);
                            js.ExecuteScript("document.getElementById('fieldName:END.DATE').value = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'");
                            wait.Until(driver => driver.FindElement(By.Id("fieldName:END.DATE")).GetAttribute("value") == DateTime.Now.ToString("dd/MM/yyyy"));

                        GetEX:
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "textbtn") == 4);
                            ChromeFindElementByClassName("a", "textbtn", 3).Click();
                            try { chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]); }
                            catch { Thread.Sleep(1000); goto GetEX; }
                            wait.Until(driver => driver.Url.Contains("BrowserServlet"));
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]).Close();
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                            ChromeFindElementByClassName("a", "textbtn", 2).Click();
                            wait.Until(driver => driver.PageSource.Contains("enquiryDataScroller"));
                            break;
                        }
                    case 7:
                        {
                            Thread.Sleep(1);
                            wait.Until(d => d.PageSource.Contains("dtsc-ebankinternet-customize-hyperlink"));
                            chromeDriver.FindElement(By.ClassName("dtsc-ebankinternet-customize-hyperlink")).Click();
                            wait.Until(driver => driver.PageSource.Contains("dtsc-table-transfer"));
                            Thread.Sleep(2000);

                            wait.Until(d => d.PageSource.Contains("Số dư cuối kỳ"));
                            js.ExecuteScript("document.getElementsByClassName('datePickerFromDate dtsc-format-calendar hasDatepicker')[0].value = '" + iTu.ToString("dd/MM/yyyy") + "'");
                            js.ExecuteScript("document.getElementsByClassName('datePickerToDate dtsc-format-calendar hasDatepicker')[0].value = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'");
                            chromeDriver.FindElement(By.ClassName("dtsc-hover-bt")).Click();

                            wait.Until(d => SoLanXuatHien(d.PageSource, "dtsc-table-transfer") == 2);
                            if (!chromeDriver.PageSource.Contains("Không có kết quả hoặc thời gian tra cứu không hợp lệ. Quý khách vui lòng kiểm tra lại."))
                            {
                                var education = chromeDriver.FindElement(By.ClassName("listBoxPageSize"));
                                var selectElement = new SelectElement(education);
                                selectElement.SelectByValue("25");
                            }
                            else
                            {
                                XtraMessageBox.Show("Không có giao dịch");
                                chromeDriver.Close();
                                chromeDriver.Quit();
                                return;
                            }
                            break;
                        }
                    case 8:
                        {
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "excardwsicon") == 40 && !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));
                            ChromeFindElementByClassName("div", "excardwsicon", 1).Click();
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "div-ab-wrap") == 3 && !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));
                            ChromeFindElementByClassName("div", "div-ab-wrap", 1).Click();
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "x-form-trigger x-form-arrow-trigger") == 1 && !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));

                            Actions build = new Actions(chromeDriver);
                            build.MoveToElement(ChromeFindElementByClassName("img", "x-form-trigger x-form-arrow-trigger", 0)).Click().Build().Perform();
                            Thread.Sleep(500);
                            build = new Actions(chromeDriver);
                            build.MoveToElement(ChromeFindElementByClassName("div", "x-combo-list-inner").FindElements(By.TagName("div"))[2]).Click().Build().Perform();

                            wait.Until(driver => !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));
                            ChromeFindElementByClassName("img", "x-form-trigger x-form-date-trigger").Click();

                            IWebElement webElement = chromeDriver.FindElement(By.ClassName("x-menu-list"));
                            string Thang = iTu.ToString("MMMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"));
                            while (XuLyDuLieu.NotVietKey(webElement.FindElement(By.ClassName(" x-btn-text")).Text.ToLower()).Replace(" ", string.Empty).Replace(".", "uoi") != XuLyDuLieu.NotVietKey(Thang.ToLower()).Replace(" ", string.Empty))
                            {
                                Thread.Sleep(500);
                                webElement.FindElement(By.ClassName("x-date-right")).FindElement(By.ClassName(" x-unselectable")).Click();
                            }
                            Thread.Sleep(1000);
                            IList<IWebElement> Lg = webElement.FindElement(By.ClassName("x-date-inner")).FindElements(By.TagName("td"));

                            foreach (IWebElement webElement1 in Lg)
                            {
                                if (XuLyDuLieu.IsNumeric(webElement1.Text))
                                    if (int.Parse(webElement1.Text) == int.Parse(iTu.ToString("dd")) && webElement1.GetAttribute("class").Contains("x-date-active"))
                                    {
                                        webElement1.Click();
                                        wait.Until(driver => !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));
                                        ChromeFindElementByClassName("button", " x-btn-text x-btn-wraplabel", 1).Click();
                                        Thread.Sleep(1000);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 9:
                        {
                            Thread.Sleep(2000);
                            js.ExecuteScript("document.getElementById('Ti-khon-v-Th_Tng-quan-Ti-khon-v-Th').click()");
                            wait.Until(driver => driver.PageSource.Contains("PageConfigurationMaster_RACCTSW__1:CUSTOM_VIEW_STATEMENT[0]4"));
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_RACCTSW__1:CUSTOM_VIEW_STATEMENT[0]4').click()");
                            wait.Until(driver => driver.PageSource.Contains("PageConfigurationMaster_RACCTSW__1:Caption18127034"));
                            Thread.Sleep(1000);
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_RACCTSW__1:Caption18127034').click()");
                            Thread.Sleep(2000);
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_RACCTSW__1:CustomViewStatementFG.TRANSACTION_DATE_FROM').value = '" + iTu.ToString("dd-MM-yyyy") + "'");
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_RACCTSW__1:CustomViewStatementFG.TRANSACTION_DATE_TO').value = '" + DateTime.Now.ToString("dd-MM-yyyy") + "'");
                            chromeDriver.FindElement(By.Id("PageConfigurationMaster_RACCTSW__1:Button23602705")).Click();
                            break;
                        }
                    case 12:
                        {
                            Thread.Sleep(2000);
                            js.ExecuteScript("document.getElementById('Ti-khon_Tng-quan-ti-khon').click()");
                            wait.Until(driver => driver.PageSource.Contains("PageConfigurationMaster_CACCTSW__1:CUSTOM_VIEW_STATEMENT[0]0"));
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_CACCTSW__1:CUSTOM_VIEW_STATEMENT[0]0').click()");
                            wait.Until(driver => driver.PageSource.Contains("PageConfigurationMaster_CACCTSW__1:Caption18127034"));
                            Thread.Sleep(1000);
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_CACCTSW__1:Caption18127034').click()");
                            Thread.Sleep(2000);
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_CACCTSW__1:CustomViewStatementFG.TRANSACTION_DATE_FROM').value = '" + iTu.ToString("dd-MM-yyyy") + "'");
                            js.ExecuteScript("document.getElementById('PageConfigurationMaster_CACCTSW__1:CustomViewStatementFG.TRANSACTION_DATE_TO').value = '" + DateTime.Now.ToString("dd-MM-yyyy") + "'");
                            chromeDriver.FindElement(By.Id("PageConfigurationMaster_CACCTSW__1:Button23602705")).Click();
                            break;
                        }
                    case 10:
                    case 1020:
                        {
                            wait.Until(driver => driver.PageSource.Contains("link h6 hover-line"));

                        One:
                            try { ChromeFindElementByClassName("a", "link h6 hover-line").Click(); }
                            catch { goto One; }
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "item-link-arrow ubg-white-2") > ((_NganHangO.ID == 10) ? 5 : 4));

                            ChromeFindElementByClassName("div", "item-link-arrow ubg-white-2", 4).Click();
                            Thread.Sleep(2000);


                            Actions build = new Actions(chromeDriver);
                            build.MoveToElement(chromeDriver.FindElements(By.ClassName("select2-selection__rendered"))[1]).Click().Build().Perform();
                            wait.Until(driver => driver.PageSource.Contains("select2-container select2-container--default select2-container--open"));
                            IWebElement webElement = chromeDriver.FindElement(By.ClassName("select2-results__options"));
                            IList<IWebElement> webElements = webElement.FindElements(By.TagName("li"));
                            webElement = webElements[2];
                            build.MoveToElement(webElement).Click().Build();
                            Thread.Sleep(1);

                            build = new Actions(chromeDriver);
                            build.MoveToElement(webElement).Click().Build().Perform();
                            js.ExecuteScript("document.getElementById('TimeRange').value = '" + iTu.ToString("dd/MM/yyyy") + " - " + DateTime.Now.ToString("dd/MM/yyyy") + "'");
                            ChromeFindElementByClassName("a", "ubtn ubg-primary ubtn-md ripple").Click();
                            break;
                        }
                    case 11:
                    case 13:
                        {
                            Thread.Sleep(1000);
                            IList<IWebElement> G11 = chromeDriver.FindElements(By.ClassName("link"));
                            Actions action11 = new Actions(chromeDriver);
                            action11.MoveToElement(chromeDriver.FindElement(By.Id("drop4"))).Perform();
                            if (_NganHangO.ID == 11)
                                G11[3].Click();
                            else
                                G11[6].Click();
                            G11 = chromeDriver.FindElements(By.ClassName("span1"));
                            G11[0].Clear(); G11[1].Clear(); G11[2].Clear(); G11[3].Clear();
                            G11[0].SendKeys(iTu.ToString("dd"));
                            G11[1].SendKeys(iTu.ToString("MM"));
                            G11[2].SendKeys(DateTime.Now.ToString("dd"));
                            G11[3].SendKeys(DateTime.Now.ToString("MM"));
                            G11 = chromeDriver.FindElements(By.ClassName("span2"));
                            G11[0].Clear(); G11[1].Clear();
                            G11[0].SendKeys(iTu.ToString("yyyy"));
                            G11[1].SendKeys(DateTime.Now.ToString("yyyy"));
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.Id("kkkkkout")).Click();
                            break;
                        }
                    case 19:
                    case 2022:
                        {
                            wait.Until(driver => driver.PageSource.Contains("MenuLink"));
                            Thread.Sleep(1000);
                            chromeDriver.FindElement(By.ClassName("clsHasKids")).Click();
                            Thread.Sleep(1000);
                            chromeDriver.FindElement(By.ClassName("MenuLink")).Click();
                            wait.Until(driver => driver.PageSource.Contains("textbtn"));
                            chromeDriver.FindElement(By.Id("fieldName:FIELD.1")).SendKeys((_NganHangO.ID == 2022) ? "19132933336012" : "19132933336012");
                            Thread.Sleep(1000);
                            js.ExecuteScript("document.getElementById('fieldName:DATE.FIELD.1').value = '" + iTu.ToString("dd/MM/yyyy") + "'");
                            Thread.Sleep(1000);
                            js.ExecuteScript("document.getElementById('fieldName:DATE.FIELD.2').value = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'");
                            Thread.Sleep(2000);
                            chromeDriver.FindElement(By.ClassName("textbtn")).Click();
                            break;
                        }
                    case 20:
                        {
                            wait.Until(driver => driver.Url.Contains("Request"));
                            chromeDriver.FindElement(By.ClassName("childMenuTree")).Click();
                            Thread.Sleep(500);
                            ChromeFindElementByClassName("a", "dijitLabelBase submenu", 0).Click();
                            Thread.Sleep(500);
                            chromeDriver.SwitchTo().Frame(0);
                            wait.Until(driver => SoLanXuatHien(driver.PageSource, "Số dư hiện tại ") == 1);
                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("table", "dojoxGridRowTable", 1).FindElements(By.TagName("td"))[2].Text.Replace(".00", string.Empty));
                            LuuSoDu();
                            Thread.Sleep(500);
                            chromeDriver.SwitchTo().DefaultContent();
                            ChromeFindElementByClassName("a", "dijitLabelBase submenu", 1).Click();
                            Thread.Sleep(500);
                            js.ExecuteScript("window.frames[0].document.getElementById('transaction_inquiry_fromDateValue').value = '" + iTu.ToString("dd/MM/yyyy") + "'");
                            js.ExecuteScript("window.frames[0].document.getElementById('transaction_inquiry_toDateValue').value = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'");
                            chromeDriver.SwitchTo().Frame(0);
                            IList<IWebElement> GG = chromeDriver.FindElements(By.ClassName("dijitLabelBase"));
                            GG[9].Click();
                            Thread.Sleep(500);
                            GG[14].Click();
                            break;
                        }
                    case 2023:
                        {
                            chromeDriver.FindElement(By.XPath("//*[@id='vcbHeader']/div[1]/section/div/div/div[2]/div[1]/section/div/nav/ul/li[1]/a")).Click();
                            SoDu = XuLyDuLieu.ConvertStringToLong(chromeDriver.FindElement(By.XPath("//*[@id='dstkdd-tbody']/tr/td[3]")).Text);
                            LuuSoDu();
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.XPath("//*[@id='dstkdd-tbody']/tr/td[1]/a")).Click();
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.Id("ctl00_Content_TransactionDetail_TxtFromDate")).SendKeys(" " + iTu.ToString("dd/MM/yyyy"));
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.Id("ctl00_Content_TransactionDetail_TxtToDate")).SendKeys(" " + DateTime.Now.ToString("dd/MM/yyyy"));
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.Id("TransByDate")).Click();
                            break;
                        }
                    case 2024:
                        {
                            chromeDriver.Navigate().GoToUrl("https://www.bidv.vn/iBank/MainEB.html?transaction=PaymentAccount&method=main");
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.XPath("//*[@id='grid']/div[2]/table/tbody/tr[1]")).Click();
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.XPath("//*[@id='grid']/div[2]/table/tbody/tr[2]/td/div/div[3]/a[1]")).Click();
                            Thread.Sleep(500);

                            if (iTu.Date != DateTime.Now.Date)
                            {
                                chromeDriver.FindElement(By.XPath("//*[@id='tab1Button']")).Click();
                                js.ExecuteScript($"document.getElementById('fromDate').value = '{iTu.ToString("dd/MM/yyyy")}'");
                                chromeDriver.FindElement(By.Id("btSelectSearch")).Click();

                            }
                            Thread.Sleep(500);
                            break;
                        }
                    case 2026:
                        {
                            SoDu = XuLyDuLieu.ConvertStringToLong(chromeDriver.FindElement(By.XPath("/html/body/app-root/div/ng-component/div[1]/div/div/div[1]/div/div/div/mbb-dashboard/div/div[3]/div[1]/mbb-finance-information/div/div[2]/mbb-account-deposit/div[1]/div/div/span[2]")).Text);
                            LuuSoDu(); 
                            chromeDriver.Navigate().GoToUrl("https://ebank.mbbank.com.vn/cp/account-info/transaction-inquiry");
                            Thread.Sleep(500);
                            new Actions(chromeDriver).MoveToElement(chromeDriver.FindElement(By.Id("mat-input-0"))).Click().Build().Perform();
                            Thread.Sleep(500);
                            new Actions(chromeDriver).MoveToElement(chromeDriver.FindElement(By.ClassName("mat-option-text"))).Click().Build().Perform();
                            Thread.Sleep(500);
                            #region Chọn ngày từ
                            new Actions(chromeDriver).MoveToElement(chromeDriver.FindElement(By.Id("mat-input-1"))).Click().Build().Perform();
                            Thread.Sleep(500);


                        St:
                            if (chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/mat-card/div[1]/div/mat-calendar/mat-calendar-header/div/div/button[1]/span")).Text.EndsWith(iTu.ToString("M yyyy")))
                            {
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/mat-card/div[2]/div[1]/div[2]/div[1]/div")).Click();
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/mat-card/div[2]/div[2]/div[2]/div[1]/div")).Click();
                                Thread.Sleep(500);
                                IList<IWebElement> w = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/mat-card/div[1]/div/mat-calendar/div/mat-month-view/table")).FindElements(By.TagName("td"));
                                foreach (IWebElement s in w)
                                {
                                    if (s.Text == iTu.Day.ToString(string.Empty))
                                    {
                                        s.Click();
                                        break;
                                    }
                                }
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div/button")).Click();
                            }
                            else
                            {
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/mat-card/div[1]/div/mat-calendar/mat-calendar-header/div/div/button[3]/div[2]")).Click();
                                goto St;
                            }
                            #endregion

                            #region Chọn ngày Đến
                            new Actions(chromeDriver).MoveToElement(chromeDriver.FindElement(By.Id("mat-input-2"))).Click().Build().Perform();
                            Thread.Sleep(500);

                            try { chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/mat-card/div[1]/div/mat-calendar/mat-calendar-header/div/div/button[1]/span")).Text.EndsWith(iTu.ToString("M yyyy")); }
                            catch { new Actions(chromeDriver).MoveToElement(chromeDriver.FindElement(By.Id("mat-input-2"))).Click().Build().Perform(); }
                        St1:
                            if (chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/mat-card/div[1]/div/mat-calendar/mat-calendar-header/div/div/button[1]/span")).Text.EndsWith(iTu.ToString("M yyyy")))
                            {
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/mat-card/div[2]/div[1]/div[2]/div[24]/div")).Click();
                                Thread.Sleep(500);
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/mat-card/div[2]/div[2]/div[2]/div[60]/div")).Click();
                                Thread.Sleep(500);
                                IList<IWebElement> w = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/mat-card/div[1]/div/mat-calendar/div/mat-month-view/table")).FindElements(By.TagName("td"));
                                foreach (IWebElement s in w)
                                {
                                    if (s.Text == iTu.Day.ToString(string.Empty))
                                    {
                                        s.Click();
                                        break;
                                    }
                                }
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[2]/div/button")).Click();
                            }
                            else
                            {
                                chromeDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div[1]/mat-card/div[1]/div/mat-calendar/mat-calendar-header/div/div/button[3]/div[2]")).Click();
                                goto St1;
                            }
                            #endregion

                            Thread.Sleep(500);
                            js.ExecuteScript("document.getElementById('btn-query').click()");
                            Thread.Sleep(500);
                            SoDu = XuLyDuLieu.ConvertStringToLong(chromeDriver.FindElement(By.XPath("//*[@id='has-data-screen']/div[5]/div/div[2]/label")).Text);
                            LuuSoDu();
                            break;
                        }
                    case 2027:
                        {
                            chromeDriver.Navigate().GoToUrl("https://ebanking.vietinbank.vn/efast/account/detail.do");
                            var education = chromeDriver.FindElement(By.Id("accountNo"));
                            var selectElement = new SelectElement(education);
                            selectElement.SelectByIndex(1);

                            chromeDriver.FindElement(By.Id("from")).Click();

                            IList<IWebElement> Lg = chromeDriver.FindElement(By.ClassName("pika-table")).FindElements(By.TagName("td"));
                            foreach (IWebElement webElement1 in Lg)
                            {
                                if (XuLyDuLieu.IsNumeric(webElement1.Text))
                                    if (int.Parse(webElement1.Text) == iTu.Date.Day)
                                    {
                                        webElement1.Click();
                                        break;
                                    }
                            }
                            chromeDriver.FindElement(By.Id("to")).Click();
                            Lg = chromeDriver.FindElements(By.ClassName("pika-table"))[1].FindElements(By.TagName("td"));
                            foreach (IWebElement webElement1 in Lg)
                            {
                                if (XuLyDuLieu.IsNumeric(webElement1.Text))
                                    if (int.Parse(webElement1.Text) == iTu.Date.Day)
                                    {
                                        webElement1.Click();
                                        break;
                                    }
                            }
                            chromeDriver.FindElement(By.Id("btnAccept")).Click();
                            break;
                        }
                    case 2028:
                        {
                            chromeDriver.FindElement(By.XPath("/html/body/div/section/span/div/div/div[2]/div/ng-transclude/div[2]/div[1]/div[1]/div/div[5]/div[1]/div[2]/div/div[1]/div/div[2]/a")).Click();
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.XPath("/html/body/div/section/span/div/div/div[2]/div/ng-transclude/div[2]/div[1]/div[1]/eb-ocb-full-screen-widget/div/div/div/div/div/div/div/div/div/div/div[2]/span[2]/span/span[1]/div/div/div[2]/div[1]/div[2]/span[2]/a[1]")).Click();
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.XPath("/html/body/div/section/span/div/div/div[2]/div/ng-transclude/div[2]/div[1]/div[1]/eb-ocb-full-screen-widget/div/div/div/div/div/div/div/div/div/div/form/section/div[1]/div/div[2]/div[2]/a")).Click();
                            Thread.Sleep(500);
                            chromeDriver.FindElement(By.XPath("/html/body/div/section/span/div/div/div[2]/div/ng-transclude/div[2]/div[1]/div[1]/eb-ocb-full-screen-widget/div/div/div/div/div/div/div/div/div/div/form/section/div[2]/div/div/div/div[1]/ul/li[2]/div[1]/div")).Click();
                            //chromeDriver.FindElement(By.XPath("")).Click();

                            chromeDriver.FindElement(By.XPath("/html/body/div/section/span/div/div/div[2]/div/ng-transclude/div[2]/div[1]/div[1]/eb-ocb-full-screen-widget/div/div/div/div/div/div/div/div/div/div/form/section/div[2]/div/div/div/div[1]/ul/li[2]/div[2]/div[2]/div[2]/div/rb-datepicker/div/section/input")).SendKeys(iTu.Date.ToString("dd.MM.yyyy"));
                            chromeDriver.FindElement(By.XPath("/html/body/div/section/span/div/div/div[2]/div/ng-transclude/div[2]/div[1]/div[1]/eb-ocb-full-screen-widget/div/div/div/div/div/div/div/div/div/div/form/section/div[2]/div/div/div/div[1]/ul/li[2]/div[2]/div[2]/div[1]/div/rb-datepicker/div/section/input")).SendKeys(iTu.Date.ToString("dd.MM.yyyy"));
                            chromeDriver.FindElement(By.Id("search_button_mobile")).Click();
                        }
                        break;

                }
            }
            catch { }
            btnLBC.Visibility = BarItemVisibility.Always;
        }

        private void btnLBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lst.Clear();
                cTNganHangOBindingSource.DataSource = null;
                lblSD2.Caption = 0.ToString("Số dư ngân hàng: #,###");
                lblSD3.Caption = 0.ToString("Số dư tự tính: #,###");
                IList<IWebElement> G6 = null;
                IList<IWebElement> mytable = null;
                DataTable dt = new DataTable();
                dt.Columns.Add(_NganHangO.NgayGD);
                dt.Columns.Add(_NganHangO.Nap);
                dt.Columns.Add(_NganHangO.GhiChu);
                switch (_NganHangO.ID)
                {
                    case 2://
                        {
                            wait.Until(driver => driver.Url.Contains("account-transaction-history"));
                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("span", "account-info-amount").Text);
                            LuuSoDu();
                            if (ChromeFindElementByClassName("span", "pagination-info-current-page", 1).Text.Contains("-"))
                            {
                                string EndPage = ChromeFindElementByClassName("span", "pagination-info-total-page", 1).Text;
                                string StartPage = ChromeFindElementByClassName("span", "pagination-info-current-page", 1).Text.Split('-')[1];

                                if (StartPage != "50")
                                {
                                    StartPage = "50";
                                    ChromeFindElementByClassName("input", "button primary search").Click();
                                    Thread.Sleep(2000);
                                }

                                while (EndPage != StartPage)
                                {
                                    Thread.Sleep(2000);
                                    StartPage = ChromeFindElementByClassName("span", "pagination-info-current-page", 1).Text.Split('-')[1];
                                    IWebElement _tabble = ChromeFindElementByClassName("table", "table");
                                    if (_tabble == null)
                                        return;
                                    mytable = _tabble.FindElements(By.TagName("td"));

                                    for (int i = 0; i < mytable.Count; i += 5)
                                    {
                                        DataRow _ravi = dt.NewRow();
                                        _ravi[_NganHangO.NgayGD] = mytable[i].Text.Split('\r')[0];
                                        _ravi[_NganHangO.Nap] = mytable[i + 3].Text.Split('\r')[0];
                                        if (mytable[i + 3].GetAttribute("innerHTML").Contains("negative"))
                                            _ravi[_NganHangO.Nap] = "-" + _ravi[_NganHangO.Nap];
                                        _ravi[_NganHangO.GhiChu] = mytable[i + 2].Text.Split('\r')[0];

                                        dt.Rows.Add(_ravi);
                                    }
                                    if (EndPage != StartPage)
                                        ChromeFindElementByClassName("div", "pagination-next", 1).Click();
                                }
                            }
                            else
                            {
                                IWebElement _tabble = ChromeFindElementByClassName("table", "table");
                                if (_tabble == null)
                                    return;
                                mytable = _tabble.FindElements(By.TagName("td"));

                                for (int i = 0; i < mytable.Count; i += 5)
                                {
                                    DataRow _ravi = dt.NewRow();
                                    _ravi[_NganHangO.NgayGD] = mytable[i].Text.Split('\r')[0];
                                    _ravi[_NganHangO.Nap] = mytable[i + 3].Text.Split('\r')[0];
                                    if (mytable[i + 3].GetAttribute("innerHTML").Contains("negative"))
                                        _ravi[_NganHangO.Nap] = "-" + _ravi[_NganHangO.Nap];
                                    _ravi[_NganHangO.GhiChu] = mytable[i + 2].Text.Split('\r')[0];

                                    dt.Rows.Add(_ravi);
                                }
                            }
                            break;
                        }
                    case 3://
                        {
                            wait.Until(driver => driver.Url.EndsWith("trans.jsp"));
                            mytable = chromeDriver.FindElement(By.Id("ibTransList")).FindElements(By.TagName("tr"));

                            dt.Columns.Add(_NganHangO.PhepTinh);
                            dt.Columns.Add(_NganHangO.NgayHT);
                            dt.Columns.Remove(_NganHangO.GhiChu);
                            dt.Columns.Add(_NganHangO.GhiChu.Split('|')[0]);
                            dt.Columns.Add(_NganHangO.GhiChu.Split('|')[1]);

                            for (int i = 1; i < mytable.Count; i += 15)
                            {
                                DataRow _ravi = dt.NewRow();
                                IList<IWebElement> tds = mytable[i].FindElements(By.TagName("td"));
                                string NGD = mytable[i + 1].FindElements(By.TagName("tr"))[0].FindElements(By.TagName("td"))[1].GetAttribute("innerHTML");
                                _ravi[_NganHangO.NgayGD] = NGD;
                                _ravi[_NganHangO.NgayHT] = tds[1].Text;
                                if (NGD.Split('/')[0].Length < 2)
                                    _ravi[_NganHangO.NgayGD] = _ravi[_NganHangO.NgayHT];
                                _ravi[_NganHangO.PhepTinh] = tds[2].Text;
                                _ravi[_NganHangO.Nap] = tds[3].Text;
                                _ravi[_NganHangO.GhiChu.Split('|')[1]] = mytable[i + 1].FindElements(By.TagName("tr"))[2].FindElements(By.TagName("td"))[1].GetAttribute("innerHTML");
                                _ravi[_NganHangO.GhiChu.Split('|')[0]] = tds[6].Text;
                                if (i == 1)
                                { SoDu = XuLyDuLieu.ConvertStringToLong(tds[4].Text); LuuSoDu(); }
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 4://
                        {
                            mytable = ChromeFindElementByClassName("table", "table-style").FindElements(By.TagName("td"));

                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("span", "red_tieude", 3).Text);
                            LuuSoDu();
                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 0; i < mytable.Count; i += 6)
                            {
                                DataRow _ravi = dt.NewRow();

                                string dta = mytable[i].Text;
                                DateTime dtz = new DateTime(2000 + int.Parse(dta.Substring(6, 2)), int.Parse(dta.Substring(3, 2)), int.Parse(dta.Substring(0, 2)));
                                _ravi[_NganHangO.NgayGD] = dtz.ToString("MM/dd/yyyy");
                                _ravi[_NganHangO.Rut] = mytable[i + 3].Text;
                                _ravi[_NganHangO.Nap] = mytable[i + 4].Text;
                                _ravi[_NganHangO.GhiChu] = mytable[i + 2].Text;
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 2020://
                        {
                            mytable = ChromeFindElementByClassName("table", "table-style-double1").FindElements(By.TagName("td"));

                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("td", "success red_tieude", 1).Text);
                            LuuSoDu();
                            dt.Columns.Add(_NganHangO.NgayHT);
                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 0; i < mytable.Count; i += 10)
                            {
                                DataRow _ravi = dt.NewRow();

                                DateTime dtz = new DateTime(2000 + int.Parse(mytable[i].Text.Substring(6, 2)), int.Parse(mytable[i].Text.Substring(3, 2)), int.Parse(mytable[i].Text.Substring(0, 2)));
                                DateTime dtz2 = new DateTime(2000 + int.Parse(mytable[i + 1].Text.Substring(6, 2)), int.Parse(mytable[i + 1].Text.Substring(3, 2)), int.Parse(mytable[i + 1].Text.Substring(0, 2)));
                                _ravi[_NganHangO.NgayHT] = dtz2.ToString("MM/dd/yyyy");
                                _ravi[_NganHangO.NgayGD] = dtz.ToString("MM/dd/yyyy");
                                _ravi[_NganHangO.Rut] = mytable[i + 4].Text;
                                _ravi[_NganHangO.Nap] = mytable[i + 5].Text;
                                _ravi[_NganHangO.GhiChu] = mytable[i + 8].Text;
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 6://
                        {
                            dt.Columns.Add(_NganHangO.Rut);
                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("table", "enqheader").FindElements(By.TagName("td"))[4].Text);
                            LuuSoDu();
                            if (chromeDriver.PageSource.Contains("paging-toolbar"))
                            {
                                string EndPage = string.Empty;
                                IWebElement we = ChromeFindElementByClassName("div", "paging-toolbar");
                                IList<IWebElement> webElement = we.FindElements(By.TagName("td"))[2].FindElements(By.TagName("span"));
                                foreach (IWebElement webElement1 in webElement) { if (!String.IsNullOrWhiteSpace(webElement1.Text)) EndPage = webElement1.Text; }

                                if (EndPage != "1")
                                    we.FindElements(By.TagName("td"))[0].Click();

                                bool end = true;
                                while (end)
                                {
                                    wait.Until(driver => driver.PageSource.Contains("enquiryDataScroller"));
                                    IWebElement G26 = chromeDriver.FindElement(By.ClassName("enquiryDataScroller"));
                                    we = ChromeFindElementByClassName("div", "paging-toolbar");
                                    mytable = G26.FindElements(By.TagName("tr"));
                                    for (int i = 0; i < mytable.Count; i++)
                                    {
                                        G6 = mytable[i].FindElements(By.TagName("td"));
                                        DataRow _ravi = dt.NewRow();
                                        _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                        _ravi[_NganHangO.Nap] = G6[2].Text;
                                        _ravi[_NganHangO.GhiChu] = G6[1].Text;
                                        dt.Rows.Add(_ravi);
                                    }
                                    end = we.FindElements(By.TagName("td"))[3].GetAttribute("innerHTML").Contains("<a href=");
                                    if (end)
                                        we.FindElements(By.TagName("td"))[3].FindElement(By.TagName("a")).Click();
                                }
                            }
                            else
                            {
                                IWebElement G26 = chromeDriver.FindElement(By.ClassName("enquiryDataScroller"));
                                mytable = G26.FindElements(By.TagName("tr"));
                                for (int i = 0; i < mytable.Count; i++)
                                {
                                    G6 = mytable[i].FindElements(By.TagName("td"));
                                    DataRow _ravi = dt.NewRow();
                                    _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                    _ravi[_NganHangO.Nap] = G6[2].Text;
                                    _ravi[_NganHangO.GhiChu] = G6[1].Text;
                                    dt.Rows.Add(_ravi);
                                }
                            }
                            break;
                        }
                    case 7://
                        {
                            dt.Columns.Add(_NganHangO.Rut);
                            wait.Until(d => d.PageSource.Contains("ebankinternet-table-transaction-row-last"));
                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("tr", "ebankinternet-table-transaction-row-last").Text);
                            LuuSoDu();
                            //pagerPanel
                            if (SoLanXuatHien(chromeDriver.PageSource, "pagerPanel") == 3)
                            {
                                ChromeFindElementByClassName("div", "dtsc-transfer-paging-cell dtsc-paging-first").Click();
                                wait.Until(d => d.PageSource.Contains("Số dư cuối kỳ"));

                                bool end = false;
                                while (!end)
                                {
                                    wait.Until(d => d.PageSource.Contains("Số dư cuối kỳ"));
                                    mytable = chromeDriver.FindElement(By.ClassName("dtsc-table-transfer")).FindElements(By.TagName("td"));

                                    for (int i = 1; i < mytable.Count - 1; i += 7)
                                    {
                                        if (mytable[i].GetAttribute("class").Contains("GIL01"))
                                        {
                                            DataRow _ravi = dt.NewRow();
                                            _ravi[_NganHangO.NgayGD] = mytable[i + 1].Text;
                                            _ravi[_NganHangO.GhiChu] = mytable[i + 3].Text;
                                            if (!String.IsNullOrEmpty(mytable[i + 4].Text))
                                                _ravi[_NganHangO.GhiChu] += "|" + mytable[i + 4].Text;
                                            _ravi[_NganHangO.Nap] = mytable[i + 5].Text;
                                            _ravi[_NganHangO.Rut] = mytable[i + 6].Text;
                                            dt.Rows.Add(_ravi);
                                        }
                                    }
                                    end = chromeDriver.PageSource.Contains("dtsc-transfer-paging-cell dtsc-paging-next dtsc-paging-current");
                                    if (!end)
                                        ChromeFindElementByClassName("div", "dtsc-transfer-paging-cell dtsc-paging-next").Click();
                                }
                            }
                            else
                            {
                                mytable = chromeDriver.FindElement(By.ClassName("dtsc-table-transfer")).FindElements(By.TagName("td"));

                                for (int i = 1; i < mytable.Count - 1; i += 7)
                                {
                                    if (mytable[i].GetAttribute("class").Contains("GIL01"))
                                    {
                                        DataRow _ravi = dt.NewRow();
                                        _ravi[_NganHangO.NgayGD] = mytable[i + 1].Text;
                                        _ravi[_NganHangO.GhiChu] = mytable[i + 3].Text;
                                        if (!String.IsNullOrEmpty(mytable[i + 4].Text))
                                            _ravi[_NganHangO.GhiChu] += "|" + mytable[i + 4].Text;
                                        _ravi[_NganHangO.Nap] = mytable[i + 5].Text;
                                        _ravi[_NganHangO.Rut] = mytable[i + 6].Text;
                                        dt.Rows.Add(_ravi);
                                    }
                                }
                            }
                            break;
                        }
                    case 8://
                        {
                            wait.Until(driver => !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));

                            if (ChromeFindElementByClassName("input", "x-form-text x-form-field x-form-num-field x-tbar-page-number", 1).GetAttribute("value") != "1")
                            {
                                ChromeFindElementByClassName("button", " x-btn-text x-tbar-page-first", 1).Click();
                                wait.Until(driver => !driver.PageSource.Contains("Đang tải…Vui lòng đợi trong giây lát"));
                            }

                            IWebElement webElement = ChromeFindElementByClassName("div", "xtb-text", 4);
                            if (!webElement.GetAttribute("innerText").Contains("1"))
                            {

                                string Soa = webElement.GetAttribute("innerText").Replace("Tổng ", string.Empty).Replace(" trang", string.Empty);
                                string Sob = "b";

                                while (Soa != Sob)
                                {
                                    Thread.Sleep(3000);
                                    Sob = ChromeFindElementByClassName("input", "x-form-text x-form-field x-form-num-field x-tbar-page-number", 1).GetAttribute("value");

                                    mytable = chromeDriver.FindElements(By.ClassName("x-grid3-scroller"));
                                    List<string> a = mytable[1].Text.Replace("\r\n", "|").Split('|').ToList();
                                    Thread.Sleep(1);
                                    for (int i = 0; i < a.Count(); i += 4)
                                    {
                                        DataRow _ravi = dt.NewRow();
                                        _ravi[_NganHangO.NgayGD] = a[i];
                                        _ravi[_NganHangO.Nap] = a[i + 1];
                                        _ravi[_NganHangO.GhiChu] = a[i + 3];
                                        if (SoDu == 0)
                                        { SoDu = XuLyDuLieu.ConvertStringToLong(a[i + 2]); LuuSoDu(); }
                                        dt.Rows.Add(_ravi);
                                    }

                                    if (Soa != Sob)
                                        ChromeFindElementByClassName("button", " x-btn-text x-tbar-page-next", 1).Click();
                                }
                            }
                            else
                            {
                                mytable = chromeDriver.FindElements(By.ClassName("x-grid3-scroller"));
                                string a = mytable[1].Text;
                                mytable = mytable[1].FindElements(By.TagName("tr"));
                                for (int i = 0; i < mytable.Count; i++)
                                {
                                    G6 = mytable[i].FindElements(By.TagName("td"));
                                    DataRow _ravi = dt.NewRow();
                                    _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                    _ravi[_NganHangO.Nap] = G6[5].Text;
                                    _ravi[_NganHangO.GhiChu] = G6[9].Text;
                                    if (SoDu == 0)
                                    { SoDu = XuLyDuLieu.ConvertStringToLong(G6[8].Text); LuuSoDu(); }
                                    dt.Rows.Add(_ravi);
                                }
                            }
                            break;
                        }
                    case 9://
                    case 12://
                        {
                            dt.Columns.Add(_NganHangO.Rut);
                            dt.Columns.Add(_NganHangO.NgayHT);

                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("span", "stage3_previewconfirm_details_column", 1).Text);
                            LuuSoDu();
                            IWebElement web = null;
                            try { web = chromeDriver.FindElement(By.Id("PageConfigurationMaster_RACCTSW__1:CustomViewStatementFG.TransactionDetailsListing_REQUESTED_PAGE_NUMBER")); } catch { }
                            if (web != null)
                            {
                                web.SendKeys("1");
                                ChromeFindElementByClassName("span", "paginationPageNumberGOSpan").Click();

                                string Soa = "a";
                                string Sob = "b";

                                while (Soa != Sob)
                                {
                                    Thread.Sleep(3000);
                                    mytable = chromeDriver.FindElement(By.ClassName("tableoverflowwrapperhw")).FindElements(By.TagName("tr"));
                                    string[] asz = ChromeFindElementByClassName("label", "simple-text pagination-status").Text.Replace("của", "-").Replace(" ", string.Empty).Split('-');
                                    Soa = asz[1];
                                    Sob = asz[2];

                                    for (int i = 1; i < mytable.Count; i++)
                                    {
                                        G6 = mytable[i].FindElements(By.TagName("span"));
                                        DataRow _ravi = dt.NewRow();
                                        _ravi[_NganHangO.NgayGD] = G6[2].Text;
                                        _ravi[_NganHangO.NgayHT] = G6[1].Text;
                                        _ravi[_NganHangO.GhiChu] = G6[3].Text;
                                        _ravi[_NganHangO.Rut] = G6[5].Text;
                                        _ravi[_NganHangO.Nap] = G6[6].Text;
                                        dt.Rows.Add(_ravi);
                                    }
                                    if (Soa != Sob)
                                        js.ExecuteScript("document.getElementById('PageConfigurationMaster_RACCTSW__1:Action.TransactionDetailsListing.GOTO_NEXT__').click()");
                                }
                            }
                            else
                            {
                                mytable = chromeDriver.FindElement(By.ClassName("tableoverflowwrapperhw")).FindElements(By.TagName("tr"));
                                for (int i = 1; i < mytable.Count; i++)
                                {
                                    string a = mytable[i].Text;
                                    G6 = mytable[i].FindElements(By.TagName("span"));
                                    DataRow _ravi = dt.NewRow();
                                    _ravi[_NganHangO.NgayGD] = G6[2].Text;
                                    _ravi[_NganHangO.NgayHT] = G6[1].Text;
                                    _ravi[_NganHangO.GhiChu] = G6[3].Text;
                                    _ravi[_NganHangO.Rut] = G6[5].Text;
                                    _ravi[_NganHangO.Nap] = G6[6].Text;
                                    dt.Rows.Add(_ravi);
                                }
                            }
                            break;
                        }
                    case 10://
                    case 1020://
                        {
                            if (ChromeFindElementByClassName("div", "h5").Text.Contains("*"))
                                ChromeFindElementByClassName("label", "ubtn ubg-white-2 ripple tk-eye legitRipple").Click();
                            Thread.Sleep(1000);
                            SoDu = XuLyDuLieu.ConvertStringToLong(ChromeFindElementByClassName("div", "h5").Text); 
                            LuuSoDu();
                            mytable = ChromeFindElementByClassName("div", "tab-pane fade show active ph30 pv10").FindElements(By.ClassName("list-info-item"));

                            dt.Columns.Add(_NganHangO.PhepTinh);
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                IWebElement webElement = mytable[i].FindElement(By.ClassName("table"));
                                G6 = webElement.FindElements(By.TagName("div"));

                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayGD] = G6[0].FindElements(By.TagName("div"))[0].Text;
                                _ravi[_NganHangO.GhiChu] = G6[0].FindElements(By.TagName("div"))[1].Text;
                                string a = G6[3].FindElements(By.TagName("div"))[1].Text;
                                _ravi[_NganHangO.PhepTinh] = a.Substring(0, 1);
                                _ravi[_NganHangO.Nap] = a.Replace(",", string.Empty).Replace(_ravi[_NganHangO.PhepTinh].ToString(), string.Empty).Replace(" ", string.Empty);
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 11://
                    case 13://
                        {
                            if (SoLanXuatHien(chromeDriver.PageSource, "Không có báo cáo nào trong thời gian này.") == 2)
                            {
                                XtraMessageBox.Show("Không có dữ liệu", "Thông báo");
                                return;
                            }

                            Thread.Sleep(1000);
                            string sodu = ChromeFindElementByClassName("table", "data-table", 1).FindElements(By.TagName("td"))[13].Text;
                            SoDu = XuLyDuLieu.ConvertStringToLong(sodu) * (sodu.Contains("-") ? -1 : 1);
                            LuuSoDu();
                            if (SoLanXuatHien(chromeDriver.PageSource, "tableTemp") == 1)
                                return;

                            mytable = chromeDriver.FindElement(By.ClassName("tableTemp")).FindElements(By.TagName("tr"));
                            dt.Columns.Add(_NganHangO.Rut);
                            dt.Columns.Add(_NganHangO.NgayHT);

                            if (mytable[mytable.Count - 1].Text.Contains("Đầu tiên"))
                            {
                                G6 = chromeDriver.FindElement(By.TagName("b")).FindElements(By.TagName("font"));
                                if (G6[1].Text != "1")
                                    mytable[mytable.Count - 1].FindElement(By.TagName("a")).Click();

                                bool NotStop = true;
                                while (NotStop)
                                {
                                    Thread.Sleep(1000);
                                    mytable = chromeDriver.FindElement(By.ClassName("tableTemp")).FindElements(By.TagName("tr"));
                                    for (int i = 1; i < mytable.Count - 3; i++)
                                    {
                                        G6 = mytable[i].FindElements(By.TagName("td"));
                                        DataRow _ravi = dt.NewRow();
                                        _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                        _ravi[_NganHangO.NgayHT] = G6[1].Text;
                                        _ravi[_NganHangO.Nap] = G6[4].Text;
                                        _ravi[_NganHangO.Rut] = G6[3].Text;
                                        _ravi[_NganHangO.GhiChu] = G6[2].Text;
                                        dt.Rows.Add(_ravi);
                                    }
                                    NotStop = chromeDriver.PageSource.Contains(",parent.root.CurrentModule);parent.root.getNext()");
                                    if (NotStop)
                                    {
                                        G6 = chromeDriver.FindElement(By.ClassName("tableTemp")).FindElements(By.TagName("tr"))[12].FindElements(By.TagName("a"));
                                        G6[G6.Count - 2].Click();
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 1; i < mytable.Count - 3; i++)
                                {
                                    G6 = mytable[i].FindElements(By.TagName("td"));
                                    DataRow _ravi = dt.NewRow();
                                    _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                    _ravi[_NganHangO.NgayHT] = G6[1].Text;
                                    _ravi[_NganHangO.Nap] = G6[4].Text;
                                    _ravi[_NganHangO.Rut] = G6[3].Text;
                                    _ravi[_NganHangO.GhiChu] = G6[2].Text;
                                    dt.Rows.Add(_ravi);
                                }
                            }
                            break;
                        }
                    case 19://
                    case 2022:
                        {
                            wait.Until(d => ChromeFindElementByClassName("table", "enquirydata wrap_words", 1) != null);
                            mytable = ChromeFindElementByClassName("table", "enquirydata wrap_words", 1).FindElements(By.TagName("tr"));

                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                G6 = mytable[i].FindElements(By.TagName("td"));
                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                _ravi[_NganHangO.GhiChu] = G6[3].Text;
                                _ravi[_NganHangO.Rut] = G6[4].Text;
                                _ravi[_NganHangO.Nap] = G6[5].Text;
                                if (SoDu == 0)
                                { SoDu = XuLyDuLieu.ConvertStringToLong(G6[6].Text); LuuSoDu(); }
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 20://
                        {
                            Thread.Sleep(1);
                            IWebElement webElement = chromeDriver.FindElement(By.ClassName("dojoxGridMasterView"));
                            if (webElement == null) return;

                            mytable = webElement.FindElements(By.TagName("tr"));
                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                G6 = mytable[i].FindElements(By.TagName("td"));
                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayGD] = G6[1].Text;
                                _ravi[_NganHangO.GhiChu] = G6[7].Text;
                                if (G6[2].Text.Contains("-"))
                                    _ravi[_NganHangO.Rut] = "-" + G6[3].Text.Replace(".00", string.Empty);
                                else
                                    _ravi[_NganHangO.Nap] = G6[3].Text.Replace(".00", string.Empty);
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 2023:
                        {
                            IWebElement webElement = chromeDriver.FindElement(By.Id("tbTranHis"));
                            if (webElement == null) return;

                            mytable = webElement.FindElements(By.TagName("tr"));
                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 1; i < mytable.Count; i++)
                            {
                                G6 = mytable[i].FindElements(By.TagName("td"));
                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                _ravi[_NganHangO.GhiChu] = G6[4].Text;
                                _ravi[_NganHangO.Rut] = G6[2].Text;
                                _ravi[_NganHangO.Nap] = G6[3].Text;
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 2024:
                        {
                            SoDu = XuLyDuLieu.ConvertStringToLong(chromeDriver.FindElement(By.Id("lbSoDuCuoiKy")).Text);
                            LuuSoDu();
                            IWebElement webElement = chromeDriver.FindElement(By.ClassName("k-selectable"));
                            if (webElement == null) return;

                            mytable = webElement.FindElements(By.TagName("tr"));
                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                G6 = mytable[i].FindElements(By.TagName("td"));
                                if (G6.Count < 3)
                                    continue;
                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayGD] = G6[0].Text;
                                _ravi[_NganHangO.GhiChu] = G6[3].Text;
                                _ravi[_NganHangO.Rut] = G6[1].Text;
                                _ravi[_NganHangO.Nap] = G6[2].Text;
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 2026:
                        {
                            IWebElement webElement = chromeDriver.FindElement(By.Id("tbl-transaction-history"));
                            if (webElement == null) return;

                            mytable = webElement.FindElements(By.TagName("tr"));
                            dt.Columns.Add(_NganHangO.Rut);
                            dt.Columns.Add(_NganHangO.NgayHT);
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                G6 = mytable[i].FindElements(By.TagName("td"));
                                if (G6.Count < 3)
                                    continue;

                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayHT] = G6[10].Text;
                                _ravi[_NganHangO.NgayGD] = G6[9].Text;
                                _ravi[_NganHangO.GhiChu] = G6[8].Text;
                                if (G6[3].Text == "+")
                                {
                                    _ravi[_NganHangO.Nap] = G6[4].Text;
                                    _ravi[_NganHangO.Rut] = "0";
                                }
                                else
                                {
                                    _ravi[_NganHangO.Nap] = "0";
                                    _ravi[_NganHangO.Rut] = "-" + G6[4].Text;
                                }
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 2027:
                        {
                            SoDu = XuLyDuLieu.ConvertStringToLong(chromeDriver.FindElement(By.XPath("//*[@id='main']/div[2]/div[3]/div/div[1]/div[2]/div/p")).Text);
                            LuuSoDu();
                            IWebElement webElement = chromeDriver.FindElement(By.Id("tblTrx"));
                            if (webElement == null) return;

                            mytable = webElement.FindElements(By.TagName("tr"));
                            dt.Columns.Add(_NganHangO.Rut);
                            for (int i = 0; i < mytable.Count; i++)
                            {
                                G6 = mytable[i].FindElements(By.ClassName("content"));
                                if (G6.Count < 3)
                                    continue;
                                DataRow _ravi = dt.NewRow();
                                _ravi[_NganHangO.NgayGD] = G6[1].Text;
                                _ravi[_NganHangO.GhiChu] = G6[2].Text;
                                _ravi[_NganHangO.Nap] = G6[3].Text;
                                dt.Rows.Add(_ravi);
                            }
                            break;
                        }
                    case 2028:
                        {
                            if (chromeDriver.PageSource.Contains("Không giao dịch nào phù hợp với tiêu chuẩn tìm kiếm"))
                                return;
                        }
                        break;
                }
                BuocXulyCuoi(dt);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }

        List<O_CTNGANHANG> lst = new List<O_CTNGANHANG>();
        void BuocXulyCuoi(DataTable Dtt)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            List<O_CTNGANHANG> _LCTNganHangO = new D_CTNGANHANG().LayDanhSachTheoNganHang(_NganHangO.ID, iTu);
            foreach (DataRow row in Dtt.Rows)
            {
                if (row[_NganHangO.NgayGD].ToString().Trim().Length > 2)
                {
                    if (row[_NganHangO.NgayGD].ToString().Trim().Substring(10).Length > 15)
                        continue;
                    DateTime Day = DateTime.Now;
                    DateTime DayHT = DateTime.Now;
                    O_CTNGANHANG CT = new O_CTNGANHANG();
                    CT.NganHangID = _NganHangO.ID;
                    Day = XuLyDuLieu.IsDate(row[_NganHangO.NgayGD].ToString().Substring(0, 10));
                    DayHT = XuLyDuLieu.IsDate(row[_NganHangO.NgayHT].ToString().Substring(0, 10));
                    if (_NganHangO.ID == 3)
                    {
                        if (row[_NganHangO.GhiChu.Split('|')[0]].ToString().Replace(" ", string.Empty).Length < 1)
                            CT.GhiChu = row[_NganHangO.GhiChu.Split('|')[1]].ToString();
                        else
                            CT.GhiChu = row[_NganHangO.GhiChu.Split('|')[0]].ToString();
                    }
                    else
                        CT.GhiChu = row[_NganHangO.GhiChu].ToString();

                    string minus = row[_NganHangO.Rut].ToString().Replace("VND", string.Empty).Replace(" ", string.Empty);
                    string plus = row[_NganHangO.Nap].ToString().Replace("VND", string.Empty).Replace(" ", string.Empty);
                    string MStr = string.Empty;

                    if (_NganHangO.Rut == _NganHangO.Nap)
                    {
                        string PhepTinh = (_NganHangO.PhepTinh == null) ? string.Empty : ((_NganHangO.PhepTinh.Replace(" ", string.Empty).Length == 0) ? string.Empty : row[_NganHangO.PhepTinh].ToString());
                        if (plus.EndsWith(",00"))
                            MStr = minus.Replace(",00", string.Empty);
                        else if (plus.EndsWith(".00"))
                            MStr = minus.Replace(".00", string.Empty);
                        else
                            MStr = minus;
                        MStr = PhepTinh + MStr;
                    }
                    else
                    {
                        if (plus.EndsWith(",00"))
                        {
                            MStr = "-" + minus.Replace(",00", string.Empty).Replace("-", string.Empty);
                            if (MStr.Replace("0", string.Empty) == "-")
                                MStr = plus.Replace(",00", string.Empty);
                        }
                        else if (plus.EndsWith(".00"))
                        {
                            MStr = "-" + minus.Replace(".00", string.Empty).Replace("-", string.Empty);
                            if (MStr.Replace("0", string.Empty) == "-")
                                MStr = plus.Replace(".00", string.Empty);
                        }
                        else
                        {
                            MStr = "-" + minus.Replace("-", string.Empty);
                            if (MStr.Replace("0", string.Empty) == "-")
                                MStr = plus;
                        }
                    }

                    CT.SoTien = MStr.StartsWith("-") ? 0 - XuLyDuLieu.ConvertStringToLong(MStr) : XuLyDuLieu.ConvertStringToLong(MStr);
                    CT.NgayGD = Day;
                    CT.NgayHT = DayHT;
                    CT.NgayTT = DayHT;
                    CT.NVGiaoDich = DuLieuTaoSan.NV.ID;

                    CT.LoaiKhachHang = 6;
                    CT.LoaiGiaoDich = (CT.SoTien > 0) ? 12 : 7;
                    CT.TrangThaiID = (CT.SoTien > 0) ? false : true;
                    CT.MaDL = 0;
                    CT.MaCode = Macode;
                    List<O_CTNGANHANG> LstCF = _LCTNganHangO.Where(W => W.NgayGD.ToString("ddMMyyyy").Equals(CT.NgayGD.ToString("ddMMyyyy")) && W.SoTien.Equals(CT.SoTien) && W.GhiChu.Replace(" ", string.Empty).Contains((CT.GhiChu ?? string.Empty).Replace(" ", string.Empty))).ToList();
                    if (LstCF.Count == 0)
                    {
                        List<O_DAILY> _dl = dl.Where(w => CT.GhiChu.ToUpper().Replace("-", " ").Replace("  ", " ").Replace("NAP", "NOP").Replace("TIEN", "QUY").Contains(string.Format("{0} {1} NOP QUY", w.MaDL, XuLyDuLieu.NotVietKey(w.Ten)).ToUpper().Replace("  ", " "))).ToList();
                        if (_dl.Count > 0)
                        {
                            CT.TrangThaiID = true;
                            CT.LoaiKhachHang = 1;
                            CT.MaDL = _dl[0].ID;
                            CT.LoaiGiaoDich = (CT.SoTien > 0) ? 2 : 3;
                        }
                        lst.Add(CT);
                    }
                    else
                        _LCTNganHangO.Remove(LstCF[0]);
                }
            }

            lblSD2.Caption = SoDu.ToString("Số dư ngân hàng: #,##0");
            lblSD3.Caption = (_NganHangO.SoDuCuoi + lst.Sum(w => w.SoTien)).ToString("Số dư tự tính: #,##0");
            cTNganHangOBindingSource.DataSource = lst;

           
            if (SoDu != _NganHangO.SoDuCuoi + lst.Sum(w => w.SoTien))
            {
                XtraMessageBox.Show("Số dư ngân hàng không bằng số dư tự tính", "Thông báo");
                return;
            }

            if (lst.Count == 0)
                XtraMessageBox.Show("Không có dữ liệu mới", "Thông báo");
            else
                XtraMessageBox.Show("Lấy dữ liệu thành công", "Thông báo");
        }

        void LuuSoDu()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("SoDu", SoDu);
            new D_NGANHANG().CapNhat(dic, _NganHangO.ID);
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_NganHangO != null)
            {
                string sysUIFormat = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                lst = new List<O_CTNGANHANG>();
                XtraOpenFileDialog ofd = new XtraOpenFileDialog();
                ofd.Title = "Mở File";
                ofd.Filter = " Excel File (*.xls, *.xlsx) | *.xls; *.xlsx";
                ofd.DefaultExt = ".xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ChuoiKetNoi = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + "; Extended Properties='Excel 12.0 Macro;HDR=YES';";

                    using (OleDbConnection conn = new OleDbConnection(ChuoiKetNoi))
                    {
                        conn.Open();
                        DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string CauTruyVan = "SELECT * FROM [" + dbSchema.Rows[0].Field<string>("TABLE_NAME").Replace("'", string.Empty) + "]";
                        OleDbDataAdapter da = new OleDbDataAdapter(CauTruyVan, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        BuocXulyCuoi(dt);
                        conn.Close();
                    }
                }
            }
        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lst.Count > 0)
            {
                if (lst.Where(w => w.LoaiKhachHang.Equals(1) && w.MaDL < 1).Count() > 0)
                    return;
                long ThemNhieu = new D_CTNGANHANG().ThemMoiTuExcel(lst, "usp_InsertCTNGANHANG");
                XuLyGiaoDien.ThongBao("Giao dịch ngân hàng thêm", ThemNhieu > 0);
                lst.Clear();
                cTNganHangOBindingSource.DataSource = null;
                lblSD2.Caption = 0.ToString("Số dư ngân hàng: #,###");
                lblSD3.Caption = 0.ToString("Số dư tự tính: #,###");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            O_CTNGANHANG ct = (GVCTNH.GetRow(GVCTNH.GetSelectedRows()[0]) as O_CTNGANHANG);
            lst.Remove(ct);

            lblSD2.Caption = SoDu.ToString("Số dư ngân hàng: #,###");
            lblSD3.Caption = (_NganHangO.SoDuCuoi + lst.Sum(w => w.SoTien)).ToString("Số dư tự tính: #,###");
            cTNganHangOBindingSource.DataSource = lst;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;

        }

        private void GVCTNH_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (view.FocusedColumn.FieldName == "LoaiGiaoDich")
                {
                    LookUpEdit edit;
                    DataView clone;

                    edit = (LookUpEdit)view.ActiveEditor;

                    O_CTNGANHANG ct = (GVCTNH.GetRow(GVCTNH.GetSelectedRows()[0]) as O_CTNGANHANG);

                    clone = new DataView(ToDataTable(LoaiGiaoDich_NganHang_TatCa()));
                    clone.RowFilter = "[Loai] = '" + ct.LoaiKhachHang.ToString() + "'";
                    edit.Properties.DataSource = clone;
                }
                else if (view.FocusedColumn.FieldName == "MaDL")
                {
                    SearchLookUpEdit edit;
                    DataView clone;

                    edit = (SearchLookUpEdit)view.ActiveEditor;

                    clone = new DataView(ToDataTable(DuLieuTaoSan.NganHangLoaiKhachHang(1)));
                    O_CTNGANHANG ct = (GVCTNH.GetRow(GVCTNH.GetSelectedRows()[0]) as O_CTNGANHANG);
                    clone.RowFilter = "[Loai] = '" + ct.LoaiKhachHang.ToString() + "'";
                    edit.Properties.DataSource = clone;
                }
            }
            catch { }
        }


        private void GVCTNH_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "LoaiKhachHang")
            {
                GVCTNH.SetRowCellValue(e.RowHandle, GVCTNH.Columns["LoaiGiaoDich"], LoaiGiaoDich_NganHang_TatCa().Where(w => w.Loai.Equals(e.Value)).ToList()[0].ID);
                GVCTNH.SetRowCellValue(e.RowHandle, GVCTNH.Columns["TrangThaiID"], e.Value.ToString() == "1" ? 1 : 0);
            }
        }

        private void frmAutoNganHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                chromeDriver.Close();
                chromeDriver.Quit();
            }
            catch { }
        }
    }

}