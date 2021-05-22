using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using mshtml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmQuyAGS : DevExpress.XtraEditors.XtraForm
    {
        DaiLyO dl = new DaiLyO();
        public frmQuyAGS(DaiLyO _dl)
        {
            InitializeComponent();
            dl = _dl;
            _SoCT = dl.SoCT;
        }


        bool DaSave = false;
        int _SoCT = 0;
        private void wVJ_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Text = wVJ.Url.ToString();
            if (wVJ.ReadyState == WebBrowserReadyState.Complete && !wVJ.IsBusy)
            {
                HtmlElement head = wVJ.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = wVJ.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                if (wVJ.Url.AbsolutePath.Contains("/Login.aspx")) // Trang login
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

                    if (wVJ.Document.GetElementById("RequiredFieldValidator3").OuterHtml.Contains("VISIBILITY: hidden"))
                    {
                        wVJ.Document.GetElementById("txtImageValidate").SetAttribute("value", res);
                        wVJ.Visible = true;
                        wVJ.Document.GetElementById("btnLogin").InvokeMember("click");
                    }
                    else
                        goto RetunA;
                }
                else if (wVJ.Url.AbsolutePath.Contains("/Default.aspx") || wVJ.Url.AbsolutePath.Contains("/Booking.aspx"))
                {
                    wVJ.Navigate("http://ags.thanhhoang.vn/Accounting.aspx?Do=Deposit");
                }
                else if (wVJ.Url.ToString().EndsWith("Accounting.aspx?Do=Deposit&Act=Add"))
                {

                    HtmlElementCollection hc = wVJ.Document.GetElementsByTagName("option");
                    for (int i = 4; i < hc.Count; i++)
                    {
                        lstdic.Add(hc[i].InnerText);
                    }

                    int o = lstdic.FindIndex(x => x.StartsWith(dl.MaAGS));
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

                        wVJ.Document.GetElementById("ctl08_txtAmount").SetAttribute("value", spinEdit1.Value.ToString());
                        if (!wVJ.Document.Body.InnerHtml.Contains("Số chứng từ đã tồn tại"))
                            _SoCT += 1;
                        else
                            _SoCT += 2;
                        wVJ.Document.GetElementById("ctl08_txtDocNo").SetAttribute("value", _SoCT.ToString());
                        wVJ.Document.GetElementById("ctl08_txtDocDate").SetAttribute("value", DateTime.Now.ToString("dd/MM/yyyy"));
                        wVJ.Document.Window.ScrollTo(0, 170);
                    }
                }
                else if (wVJ.Url.AbsolutePath.Contains("/Accounting.aspx"))
                {
                    if (!DaSave)
                        wVJ.Document.GetElementById("ctl08_btnAddNew").InvokeMember("click");
                    else
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("SoCT", _SoCT);
                        new DaiLyD().CapNhat(dic, dl.ID);
                        XuLyGiaoDien.Alert("Nhập quỹ AGS thành công", Form_Alert.enmType.Success);
                        Close();
                    }
                    DaSave = !DaSave;
                }
            }
        }

        List<string> lstdic = new List<string>();
        private void btnCapQuy_Click(object sender, EventArgs e)
        {
            if ((long)spinEdit1.Value > 1000000)
                wVJ.Navigate("http://ags.thanhhoang.vn/Login.aspx");
        }

        private void frmQuyAGS_Load(object sender, EventArgs e)
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            RegKey.SetValue("Display Inline Images", "yes");

            XuLyGiaoDien.OpenForm(this);
        }
    }
}