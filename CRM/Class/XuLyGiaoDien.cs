using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using IronOcr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    class XuLyGiaoDien
    {
        #region Memory

        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
        #endregion

        public static void ShowToolTip(Control textEdit, string body, int duration = 2000)
        {
            Cursor.Position = textEdit.PointToScreen(new Point(20, 10));
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ToolTipTitle = "Thông báo";



            toolTip.Show(body, textEdit, 0, -70, duration);

            if (textEdit is LookUpEdit)
            {
                (textEdit as LookUpEdit).ShowPopup();
                Cursor.Position = textEdit.PointToScreen(new Point(20, 10));
            }
            else if (textEdit is SearchLookUpEdit)
            {
                (textEdit as SearchLookUpEdit).ShowPopup();
                Cursor.Position = textEdit.PointToScreen(new Point(40, 132));
            }
            else
                textEdit.Focus();
        }


        public static void ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextEdit).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        public static string ConvertImgToText(Bitmap bt)
        {
            var Ocr = new IronTesseract();
            // Fast Dictionary
            Ocr.Language = OcrLanguage.EnglishFast;
            // Latest Engine 
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            //AI OCR only without font analysis
            //Ocr.Configuration.EngineMode = TesseractEngineMode.LstmOnly;
            //Turn off unneeded options
            Ocr.Configuration.ReadBarCodes = false;
            Ocr.Configuration.RenderSearchablePdfsAndHocr = false;
            // Assume text is laid out neatly in an orthagonal document
            Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            using (var Input = new OcrInput(bt))
            {
                var Result = Ocr.Read(Input);
                return Result.Text;
            }
        }

        #region Mở Form mờ
        public static void OpenForm(Form frm)
        {
            new Thread(() =>
            {
                frm.KeyPreview = true;
                for (double i = 0; i <= 1; i += 0.1)
                {
                    frm.Invoke(new MethodInvoker(() =>
                    {
                        frm.Opacity = i;
                    }));
                    Thread.Sleep(10);
                }
                frm.KeyDown += (s, e) =>
                {
                    if (e.Control && e.KeyCode == Keys.D1 && !frm.Name.Equals("frmChinh"))
                    {
                        using (var g = new Bitmap(frm.Width, frm.Height))
                        {
                            frm.DrawToBitmap(g, new Rectangle(0, 0, g.Width, g.Height));
                            Clipboard.SetImage(g);

                            if (!wait.IsSplashFormVisible)
                                wait.ShowWaitForm();
                            wait.SetWaitFormCaption("Thông báo");
                            wait.SetWaitFormDescription("Đã sao chép hình ảnh");
                            Thread.Sleep(500);
                            if (wait.IsSplashFormVisible)
                                wait.CloseWaitForm();
                        }
                    }
                    else if (e.Control && e.KeyCode == Keys.D2)
                    {
                        frm.TopMost = true;
                        Bitmap g;
                        if (frm.Name.Equals("frmChinh"))
                        {
                            g = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                          Screen.PrimaryScreen.Bounds.Height);
                            Graphics graphics = Graphics.FromImage(g as Image);
                            graphics.CopyFromScreen(0, 0, 0, 0, g.Size);
                        }
                        else
                        {
                            g = new Bitmap(frm.Width, frm.Height);
                            frm.DrawToBitmap(g, new Rectangle(0, 0, g.Width, g.Height));
                        }
                        new Snipping(g).ShowDialog(frm);
                    }
                };

                GridViewHelper.SetFromGrid(frm);
            }).Start();
        }

        public static DevExpress.XtraSplashScreen.SplashScreenManager wait;
        public static void SplashScreen(Form frm)
        {
            wait = new DevExpress.XtraSplashScreen.SplashScreenManager(frm, typeof(global::CRM.CRMWaitForm), true, true);
        }
        #endregion

        #region Tạo thông báo
        public static void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        public static bool ThongBao(string Ten, bool ThanhCong, bool Xoa = false)
        {
            string noiDung = Ten + (Xoa ? " xóa" : string.Empty) + (ThanhCong ? " thành công ...!" : " không thành công...!");
            Alert(noiDung, (ThanhCong ? Form_Alert.enmType.Success : Form_Alert.enmType.Error));
            return ThanhCong;
        }
        #endregion

        #region Kiểm tra
        public static void KiemTra(List<KiemTra> lstThongBao, DXValidationProvider dx)
        {
            foreach (KiemTra ctl in lstThongBao)
            {
                if (ctl._ChoQuaThang)
                    dx.SetValidationRule(ctl._Control, new TextValidationRule(string.Empty, true));
                else if (ctl._Mail)
                {
                    ctl._Control.Text = ctl._Control.Text ?? string.Empty;
                    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(strRegex);
                    if (ctl._Control.Text.Length > 9 && re.IsMatch(ctl._Control.Text.TrimEnd().TrimStart()))
                        dx.SetValidationRule(ctl._Control, new TextValidationRule(ctl._ThongBao2, ctl._ChoQua));
                    else
                        dx.SetValidationRule(ctl._Control, new TextValidationRule("Mail không hợp lệ", false));
                }
                else if (ctl._SDT)
                {
                    if (ctl._Control.Text.Length > 9)
                    {
                        if (XuLyDuLieu.IsNumeric(ctl._Control.Text.Replace("+", string.Empty)))
                            dx.SetValidationRule(ctl._Control, new TextValidationRule(ctl._ThongBao2, ctl._ChoQua));
                        else
                            dx.SetValidationRule(ctl._Control, new TextValidationRule("Số điện thoại không hợp lệ", false));
                    }
                    else
                        dx.SetValidationRule(ctl._Control, new TextValidationRule("Ít nhất 10 kí tự", false));
                }
                else if (ctl._KiemTraChuoi)
                {
                    int Te = ctl._Control.Text.Replace(" ", string.Empty).Replace("\r\n", "").Length;
                    if (Te > ctl._Tu - 1 && ctl._Den + 1 > Te)
                        dx.SetValidationRule(ctl._Control, new TextValidationRule(ctl._ThongBao2, ctl._ChoQua));
                    else
                        dx.SetValidationRule(ctl._Control, new TextValidationRule(string.Format("Nhập từ {0} đến {1}", ctl._Tu, ctl._Den), false));
                }
            }
        }

        #endregion

        #region Export Excel
        public static void ExportExcel(GridControl Grc, GridView Grv, string Fin)
        {
            XtraSaveFileDialog sfd = new XtraSaveFileDialog();
            sfd.Title = "Lưu File";
            sfd.Filter = "Excel File (*.xlsx) | *.xlsx";
            sfd.DefaultExt = ".xlsx";
            sfd.FileName = Fin + ".xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsxExportOptionsEx op = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                Grv.OptionsPrint.AutoWidth = false;
                op.CustomizeCell += op_CustomizeCell;
                Grc.ExportToXlsx(sfd.FileName);
                if (XtraMessageBox.Show("Xuất excel thành công, mở file ngay!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }


        static void op_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs ea)
        {
            DateTime testDT = new DateTime();
            if (ea.Value is DateTime)
            {
                if (ea.Value == null)
                {
                    ea.Formatting.FormatType = DevExpress.Utils.FormatType.None;
                    ea.Value = string.Empty;
                    ea.Handled = true;
                }
                else if ((DateTime)ea.Value == testDT || ea.Value.ToString().Contains("1900"))
                {
                    ea.Formatting.FormatType = DevExpress.Utils.FormatType.None;
                    ea.Value = string.Empty;
                    ea.Handled = true;
                }
            }

        }
        #endregion
    }

    class KiemTra
    {
        public Control _Control { set; get; }
        public bool _KiemTraChuoi { set; get; } = true;
        public int _Tu { set; get; } = 3;
        public int _Den { set; get; } = 20;
        public string _ThongBao1 { set; get; }
        public string _ThongBao2 { set; get; }
        public bool _ChoQua { set; get; } = true;
        public bool _SDT { set; get; } = false;
        public bool _Mail { set; get; } = false;
        public bool _ChoQuaThang { set; get; }
    }

    class TextValidationRule : ValidationRule
    {
        string txt = string.Empty;
        bool n = false;
        public TextValidationRule(string tst, bool N)
        {
            txt = tst;
            n = N;
        }

        public override bool Validate(Control control, object value)
        {
            ErrorText = txt;
            return n;
        }
    }

    class TypeAssistant
    {
        public event EventHandler Idled = delegate { };
        public int WaitingMilliSeconds { get; set; }
        System.Threading.Timer waitingTimer;

        public TypeAssistant(int waitingMilliSeconds = 300)
        {
            WaitingMilliSeconds = waitingMilliSeconds;
            waitingTimer = new System.Threading.Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }
        public void TextChanged()
        {
            waitingTimer.Change(WaitingMilliSeconds, System.Threading.Timeout.Infinite);
        }
    }
}
