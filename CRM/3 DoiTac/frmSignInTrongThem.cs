using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CRM
{
    public partial class frmSignInTrongThem : DevExpress.XtraEditors.XtraForm
    {
        public frmSignInTrongThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmSignInTrongThem(O_SIGNINTRONG si)
        {
            InitializeComponent();
            _SignInO = si;
            Text += " sửa";
        }


        private void frmThemSignIn_Load(object sender, EventArgs e)
        {
            hangBayOBindingSource.DataSource = new D_HANGBAY().DuLieu().Where(w => w.SapXep);
            if (hangBayOBindingSource.Count < 21)
                iHangBay.Properties.DropDownRows = hangBayOBindingSource.Count;
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _SignInO);
            ClsChucNang.OpenForm(this);
        }

        #region Biến
        O_SIGNINTRONG _SignInO = new O_SIGNINTRONG();
        D_SIGNINTRONG _SignInD = new D_SIGNINTRONG();
        #endregion

        #region Sự kiện nút
        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iSignIn,_Tu=2,_Den = 20,_ChoQua = !new D_SIGNIN().KiemTraTonTai(_SignInO.ID,"SignIn",iSignIn.Text), _ThongBao2 = "Đã tồn tại" }};

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            long CapNhatNum = (_SignInO.ID > 0) ? (_SignInD.CapNhat(dic, _SignInO.ID) > 0 ? _SignInO.ID : 0) : _SignInD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                if (Owner is frmSignIn)
                    (Owner as frmSignIn).TaiLaiSignIn();
                if (!checkEdit1.Checked)
                    Close();
            }
        }
        #endregion

        private void frmSignInTrongThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.E)
                Close();
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.S)
                btnLuu.PerformClick();
        }


        ChromeDriver driver;
        IJavaScriptExecutor js;
        WebDriverWait wait;
        private void btnTT_Click(object sender, EventArgs e)
        {
            if (iHangBay.EditValue.ToString() == "7024")
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/div[2]")));
                driver.FindElement(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/div[2]")).Click();
                new SelectElement(driver.FindElement(By.Name("ta-agent-country"))).SelectByValue("VN");
                new Actions(driver).SendKeys(driver.FindElement(By.Name("ta-agent-username")), "AG00011S" + aa.ToString() + Keys.Tab)
                    .SendKeys("THANH HOANG" + Keys.Tab)
                    .SendKeys("DAI LY" + Keys.Tab)
                    .SendKeys("138/70 Trương Công Định, P.14, Q.Tân Bình" + Keys.Tab)
                    .SendKeys("138/70 Trương Công Định, P.14, Q.Tân Bình" + Keys.Tab)
                    .SendKeys("HCM" + Keys.Tab)
                    .SendKeys("HCM" + Keys.Tab)
                    .SendKeys("700000" + Keys.Tab + Keys.Tab)
                    .SendKeys("TRAN THANH TUNG" + Keys.Tab)
                    .SendKeys("tungtranims@gmail.com" + Keys.Tab)
                    .SendKeys("0908878188" + Keys.Tab)
                    .SendKeys("0908878188" + Keys.Tab)
                    .Build().Perform();
                driver.FindElement(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/form/div[9]/div[1]/button")).Click();
                iSignIn.Text = "AG00011S" + aa.ToString();
                aa++;
            }
        }

        int aa = 281;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (iHangBay.EditValue.ToString() == "7024")
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                var options = new ChromeOptions();
                try { driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }
                catch { options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }

                js = driver as IJavaScriptExecutor;
                wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));

                driver.Navigate().GoToUrl("https://booking.vietravelairlines.vn/vi/ta");
                wait.Until(ExpectedConditions.ElementExists(By.Id("home-ta-login-button")));
                new Actions(driver).SendKeys(driver.FindElement(By.Id("home-ta-login-username")), "37100011" + Keys.Tab).SendKeys("Cuong@139" + Keys.Tab + Keys.Enter).Build().Perform();
                wait.Until(ExpectedConditions.ElementExists(By.Id("criteria-search-button")));
                js.ExecuteScript("document.getElementsByClassName('icon material-icons arrow-icon')[0].click()");
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/div[2]/header/div/div/div/div[2]/nav/ul/li[3]/div/div[2]/div[2]/div[4]/div/div")));
                driver.Navigate().GoToUrl("https://booking.vietravelairlines.vn/vi/ta/manage");
            }
        }
    }
}