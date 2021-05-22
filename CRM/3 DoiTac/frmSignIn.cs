using DataAccessLayer;
using DataTransferObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CRM
{
    public partial class frmSignIn : DevExpress.XtraEditors.XtraForm
    {
        int _dl = 0;
        public frmSignIn()
        {
            InitializeComponent();
        }

        public frmSignIn(O_DAILY dl)
        {
            InitializeComponent();
            splitterControl1.Visible = groupControl2.Visible = false;
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            _dl = dl.ID;
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {
            daiLyOBindingSource.DataSource = new D_DAILY().All();
            hangBayOBindingSource.DataSource = new D_HANGBAY().DuLieu();
            btnThem.Visibility = DuLieuTaoSan.Q.SignInXoa ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            colMatKhau.Visible = DuLieuTaoSan.Q.DaiLyAdmin;
            TaiLaiSignIn();
            XuLyGiaoDien.OpenForm(this);
            //TaoSignInVU();
        }

        #region Dữ liệu 
        public void TaiLaiSignIn()
        {
            List<O_SIGNIN> lstSI = new D_SIGNIN().DuLieu();
            signInOBindingSource.DataSource = _dl == 0 ? lstSI : lstSI.Where(w => w.DaiLy.Equals(_dl));
            signInTrongOBindingSource.DataSource = new D_SIGNINTRONG().DuLieu();
            GVSI.FocusedRowHandle = _index;
        }
        #endregion

        #region Biến
        O_SIGNIN _SignInO = new O_SIGNIN();
        int _index = 0;
        #endregion

        #region Sự kiện nút
        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiSignIn();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmSignInThem().ShowDialog(this);
        }
        #endregion

        #region Sự khiện bản 
        private void GVSI_DoubleClick(object sender, EventArgs e)
        {
            if (DuLieuTaoSan.Q.SignInThemSua)
            {
                _index = GVSI.GetFocusedDataSourceRowIndex();
                _SignInO = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as O_SIGNIN;
                if (_SignInO != null)
                    new frmSignInThem(_SignInO).ShowDialog(this);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (DuLieuTaoSan.Q.SignInThemSua)
            {
                _index = gridView1.GetFocusedDataSourceRowIndex();
                O_SIGNINTRONG _SignInO = gridView1.GetRow(gridView1.GetSelectedRows()[0]) as O_SIGNINTRONG;
                if (_SignInO != null)
                    new frmSignInTrongThem(_SignInO).ShowDialog(this);
            }
        }
        #endregion

        string RanDomTen()
        {
            string[] Ho = new string[] { "NGUYEN", "TRAN", "LE", "PHAM", "HUYNH", "HOANG", "PHAN", "VU", "VO", "DANG", "BUI", "DO", "HO", "NGO", "DUONG", "LY" };
            string[] Ten = new string[] { "Anh", "Bá", "Bách", "Bàng", "Bảo", "Bích", "Bổn", "Chi", "Cương", "Cường", "Dũng", "Duy", "Gia", "Giang", "Hà", "Hải", "Hòa", "Hoài", "Hoàng" };

            return Ho[new Random().Next(Ho.Count())] + " " + XuLyDuLieu.NotVietKey(Ten[new Random().Next(Ten.Count())].ToUpper()) + " VIET";
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            new frmSignInTrongThem().ShowDialog();
        }


        void TaoSignInVU()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            ChromeDriver driver;
            IJavaScriptExecutor js;
            WebDriverWait wait;
            try { driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }
            catch { options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }

            js = driver as IJavaScriptExecutor;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));

            driver.Navigate().GoToUrl("https://booking.vietravelairlines.vn/vi/ta");
            wait.Until(ExpectedConditions.ElementExists(By.Id("home-ta-login-button")));
            new Actions(driver).SendKeys(driver.FindElement(By.Id("home-ta-login-username")), "37100011" + OpenQA.Selenium.Keys.Tab).SendKeys("Cuong@139" + OpenQA.Selenium.Keys.Tab + OpenQA.Selenium.Keys.Enter).Build().Perform();
            wait.Until(ExpectedConditions.ElementExists(By.Id("criteria-search-button")));
            js.ExecuteScript("document.getElementsByClassName('icon material-icons arrow-icon')[0].click()");
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/div[2]/header/div/div/div/div[2]/nav/ul/li[3]/div/div[2]/div[2]/div[4]/div/div")));
            driver.Navigate().GoToUrl("https://booking.vietravelairlines.vn/vi/ta/manage");
            int i = 261;
        Gasc:
            i++;
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/div[2]")));
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/div[2]")).Click();
            Thread.Sleep(1);
            new SelectElement(driver.FindElement(By.Name("ta-agent-country"))).SelectByValue("VN");
            new Actions(driver).SendKeys(driver.FindElement(By.Name("ta-agent-username")), "AG00011S" + i.ToString() + OpenQA.Selenium.Keys.Tab)
                .SendKeys("THANH HOANG" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("DAI LY" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("138/70 Trương Công Định, P.14, Q.Tân Bình" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("138/70 Trương Công Định, P.14, Q.Tân Bình" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("HCM" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("HCM" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("700000" + OpenQA.Selenium.Keys.Tab + OpenQA.Selenium.Keys.Tab)
                .SendKeys("TRAN THANH TUNG" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("tungtranims@gmail.com" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("0908878188" + OpenQA.Selenium.Keys.Tab)
                .SendKeys("0908878188" + OpenQA.Selenium.Keys.Tab)
                .Build().Perform();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/form/div[9]/div[1]/button")).Click();
            Thread.Sleep(1);
            goto Gasc;
        }
    }
}