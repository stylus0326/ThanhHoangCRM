using DevExpress.XtraEditors;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class XtraForm4 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm4()
        {
            InitializeComponent();
        }


        ChromeDriver driver;
        IJavaScriptExecutor js;
        WebDriverWait wait;
        private void XtraForm4_Load(object sender, EventArgs e)
        {
            DataVJ.Columns.Add("Full name", typeof(string));
            DataVJ.Columns.Add("Logon name", typeof(string));
            DataVJ.Columns.Add("Status", typeof(string));
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            //chromeDriverService.HideCommandPromptWindow = true;

            try { driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }
            catch { options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(300)); }

            js = driver as IJavaScriptExecutor;
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(5));

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
                ChromeFindElementByClassName("a", "user-icon ng-scope", 4).Click();
                wait.Until(d => d.FindElements(By.LinkText("New user")).Count > 0);
                wait.Until(d => d.PageSource.Contains("base-loading-class") == false);
                wait.Until(d => d.PageSource.Contains("base-loading-class") == false);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(@"/html/body/main/select")));
                new SelectElement(driver.FindElement(By.XPath(@"/html/body/main/select"))).SelectByIndex(2);

                for (int i = 0; i < 25; i++)
                {
                    IList<IWebElement> d = driver.FindElement(By.XPath("/html/body/main/table/tbody")).FindElements(By.TagName("tr"));

                    foreach (IWebElement webElement in d)
                    {
                        IList<IWebElement> d2 = webElement.FindElements(By.TagName("td"));
                        DataRow dataRow = DataVJ.NewRow();
                        dataRow[0] = d2[1].Text;
                        dataRow[1] = d2[2].Text;
                        dataRow[2] = d2[3].Text;
                        DataVJ.Rows.Add(dataRow);
                    }

                    driver.FindElement(By.PartialLinkText("Next")).Click();
                }
            }

            #endregion
            //driver.Close();
            //driver.Quit();
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

        DataTable DataVJ = new DataTable();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraSaveFileDialog sfd = new XtraSaveFileDialog();
            sfd.Title = "Save text Files";
            sfd.DefaultExt = "xlsx";
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.FileName = $"SiInVJ.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(sfd.FileName)))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sub 1");
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