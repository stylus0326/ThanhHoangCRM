using DataAccessLayer;
using DataTransferObject;
using DevExpress.Export;
using DevExpress.Export.Xl;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmCongNo : DevExpress.XtraEditors.XtraForm
    {
        public frmCongNo()
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCN, GVCN);
        }

        private void frmCongNo_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
            if ((key.GetValue("TepDinhKem") ?? string.Empty) != string.Empty)
            {
                txtFileDinhKem.Properties.Tokens.Clear();
                List<string> filenames = key.GetValue("TepDinhKem").ToString().Split(',').ToList();

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
            key.Close();
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            dtpTuNgay.EditValue = DateTime.ParseExact("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), "d/M/yyyy", null);
            dtpDenNgay.EditValue = (DateTime.Today.Day == 1) ? DateTime.Today : DateTime.Today.AddDays(-1);
            dateEdit1.EditValue = DateTime.ParseExact("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), "d/M/yyyy", null).AddDays(-3);
            dateEdit2.EditValue = DateTime.Today;
            tuyenBayOBindingSource.DataSource = new TuyenBayD().DuLieu();
            loaiGiaoDichOBindingSource.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve_All(chk.Checked ? 1 : 2);
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            btnExcel.Enabled = DuLieuTaoSan.Q.Lv2Excel;
            btnGuiMail.Enabled = DuLieuTaoSan.Q.Lv2GuiMail;
            btnFILE.Enabled = DuLieuTaoSan.Q.Lv2ThemTep;
        }

        #region Dữ liệu 
        void No()
        {
            if (dateEdit1.EditValue != null && dateEdit2.EditValue != null)
            {
                if (chkAn.Checked)
                    lst = daiLyD.CongNo(LoaiKhach, new DateTime(2017, 1, 1), DateTime.Now);
                else
                    lst = daiLyD.CongNo(LoaiKhach, (DateTime)dateEdit1.EditValue, (DateTime)dateEdit2.EditValue);

                daiLyOBindingSource.DataSource = lst;
                chkAll.Checked = false;
            }
        }
        #endregion

        #region Biến
        public string NoiDungThem = string.Empty;
        CauHinhSMTPD cauHinhSMTPD = new CauHinhSMTPD();
        DateTime testDT = new DateTime();
        List<DaiLyO> lst = new List<DaiLyO>();
        int LoaiKhach = 1;
        DaiLyD daiLyD = new DaiLyD();
        #endregion

        #region Giao diện
        private void grvCTCongNo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GiaoDichO dl = View.GetRow(e.RowHandle) as GiaoDichO;
                if (dl.TenKhach.Equals("TỔNG CỘNG:"))
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
            }
        }

        private void grvCTCongNo_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            switch (e.Column.FieldName)
            {
                case "GioBayDi":
                    if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        if ((view.GetListSourceRowCellValue(e.ListSourceRowIndex, "LoaiVeDi") ?? string.Empty).ToString().Length == 0)
                            e.DisplayText = string.Empty;
                    }
                    break;
                case "GioBayVe":
                    if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        if ((view.GetListSourceRowCellValue(e.ListSourceRowIndex, "LoaiVeVe") ?? string.Empty).ToString().Length == 0)
                            e.DisplayText = string.Empty;
                    }
                    break;
            }
        }

        private void grvCongNo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GiaoDichO dl = View.GetRow(e.RowHandle) as GiaoDichO;
                if (e.Column.FieldName == "LoaiGiaoDich")
                {
                    switch (dl.LoaiGiaoDich)
                    {
                        case 0:
                        case 1:
                            e.Appearance.BackColor = Color.FromArgb(237, 105, 28);
                            e.Appearance.BackColor2 = Color.SeaShell;
                            break;
                        case 2:
                            e.Appearance.BackColor = Color.Lime;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            break;
                        case 5:
                            e.Appearance.BackColor = Color.Lime;
                            e.Appearance.BackColor = Color.FromArgb(66, 221, 245);
                            break;
                        case 6:
                        case 7:
                            e.Appearance.BackColor = Color.FromArgb(250, 52, 131);
                            e.Appearance.BackColor2 = Color.SeaShell;
                            break;
                        case 8:
                        case 9:
                            e.Appearance.BackColor = Color.FromArgb(232, 72, 72);
                            e.Appearance.BackColor2 = Color.SeaShell;
                            break;
                        case 10:
                            e.Appearance.BackColor = Color.Gold;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Sự kiện nút
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstDaiLy.CheckedItems.Count == 0)
                XuLyGiaoDien.Alert("Vui lòng nhập đầy đủ thông tin", Form_Alert.enmType.Info);
            else
            {
                if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.ShowWaitForm();
                //simpleButton1.Text = "Cần chạy lại: " + daiLyD.DemNgayPhiSai().ToString();
                GiaoDichD gdb = new GiaoDichD();
                string daily = string.Format("{0}", lstDaiLy.CheckedItems[0]);
                int n = lstDaiLy.CheckedItems.Count;
                for (int i = 1; i < n; i++)
                {
                    daily += string.Format(",{0}", lstDaiLy.CheckedItems[i]);
                }
                giaoDichOBindingSource.DataSource = gdb.LayDanhSachCN((DateTime)dtpTuNgay.EditValue, (DateTime)dtpDenNgay.EditValue, daily);
                if (giaoDichOBindingSource.DataSource != null)
                {
                    btnGuiMail.Enabled = true;
                    btnExcel.Enabled = true;
                }
                if (XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.CloseWaitForm();
            }
        }

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn gửi mail ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> vs = new List<string>();
                if ((txtFileDinhKem.EditValue ?? string.Empty) != string.Empty)
                    vs = txtFileDinhKem.EditValue.ToString().Split(',').ToList();

                int n = lstDaiLy.CheckedItems.Count;
                if (n == 0)
                    XuLyGiaoDien.Alert("Chưa chọn đại lý cần gửi", Form_Alert.enmType.Info);
                else
                {
                    CauHinhSMTPO cauHinhSMTPO = cauHinhSMTPD.DuLieu();
                    MauEmailO ma = new MauEmailD().DuLieu()[0];

                    SmtpClient client = new SmtpClient();
                    client.Port = cauHinhSMTPO.Port;
                    client.Host = cauHinhSMTPO.Host;
                    client.EnableSsl = cauHinhSMTPO.SSL;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(cauHinhSMTPO.Email, cauHinhSMTPO.Password);

                    grvCTCongNo.Columns["Hang"].Width = 50;
                    grvCTCongNo.Columns["SoVeVN"].Width = 90;
                    grvCTCongNo.Columns["LuyKe"].Width = 90;
                    grvCTCongNo.Columns["GiaThu"].Width = 90;
                    grvCTCongNo.Columns["GiaHeThong"].Width = 90;
                    grvCTCongNo.Columns["TaiKhoanCo"].Width = 90;
                    grvCTCongNo.Columns["TenKhach"].Width = 250;
                    grvCTCongNo.OptionsPrint.AutoWidth = false;
                    grvCTCongNo.OptionsView.ColumnAutoWidth = false;

                    XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                    opt.CustomizeCell += op_CustomizeCell;
                    opt.SheetName = "Bản Công Nợ";


                    GiaoDichD gdb = new GiaoDichD();
                    bool sendOK = false;
                    if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.ShowWaitForm();

                    for (int i = 0; i < n; i++)
                    {
                        DaiLyO dl = lstDaiLy.GetItem(lstDaiLy.CheckedIndices[0]) as DaiLyO;
                        string daily = string.Format("{0}", dl.ID);
                        List<GiaoDichO> lstCongNo = gdb.LayDanhSachCN((DateTime)dtpTuNgay.EditValue, (DateTime)dtpDenNgay.EditValue, daily, true);
                        txtMauEmail.HtmlText = ma.NoiDung.Replace("{0}", dl.MaDL).Replace("{1}", XuLyDuLieu.NotVietKey(dl.Ten));

                        if ((dl.EmailKeToan ?? string.Empty) == string.Empty)
                            goto RE1;

                        string[] EmailKeToanString = Regex.Replace(dl.EmailKeToan, @"\t|\n|\r", "|").Replace("||", "|").Split('|');
                        for (int ii = 0; ii < EmailKeToanString.Count(); ii++)
                        {
                            if (EmailKeToanString[ii].Length > 5)
                            {
                                MailMessage mm = new MailMessage();
                                mm.From = new MailAddress("ketoan02@thanhhoang.vn", "Thành Hoàng");
                                mm.BodyEncoding = UTF8Encoding.UTF8;
                                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                mm.IsBodyHtml = true;
                                RichEditMailMessageExporter exporter = new RichEditMailMessageExporter(txtMauEmail, mm);
                                exporter.Export();
                                mm.To.Add(new MailAddress(EmailKeToanString[ii]));
                                //mm.To.Add(new MailAddress("tungtranims@gmail.com"));
                                if (lstCongNo.Count > 1)
                                {
                                    XuLyGiaoDien.wait.SetWaitFormDescription("Gửi cho: " + dl.Ten + " (" + (i + 1) + "/" + n + ").");
                                    CTGiaoDichDindingSource.DataSource = lstCongNo;
                                    mm.Subject = "Công Nợ - " + dl.Ten + " - Từ ngày " + ((DateTime)dtpTuNgay.EditValue).ToString("dd_MM_yyyy") + " - đến ngày " + ((DateTime)dtpDenNgay.EditValue).ToString("dd_MM_yyyy");

                                    #region Xuất excel
                                    gridCTCongNo.ForceInitialize();
                                    string strFile = @"C:\CongNo\" + dl.Ten + " - " + ((DateTime)dtpTuNgay.EditValue).ToString("dd_MM_yyyy") + " - " + ((DateTime)dtpDenNgay.EditValue).ToString("dd_MM_yyyy") + ".xlsx";
                                    Directory.CreateDirectory(@"C:\CongNo");
                                    gridCTCongNo.ExportToXlsx(strFile, opt);
                                    #endregion

                                    mm.Attachments.Add(new Attachment(strFile));
                                    foreach (string g in vs)
                                    {
                                        if (g.Count() > 0)
                                            mm.Attachments.Add(new Attachment(g));
                                    }
                                    try
                                    {
                                        client.Send(mm);
                                    }
                                    catch (Exception ex) { XtraMessageBox.Show(ex.Message, "Thông báo"); }
                                    sendOK = true;
                                    mm.Attachments.Dispose();
                                    if (File.Exists(strFile))
                                        File.Delete(strFile);
                                }
                            }
                        }
                    RE1:
                        int index = lstDaiLy.FindItem(0, true, delegate (ListBoxFindItemArgs ei) { ei.IsFound = object.Equals(dl.ID, ei.ItemValue); });
                        lstDaiLy.SetItemChecked(index, false);
                    }

                    if (sendOK)
                        XuLyGiaoDien.Alert("Gửi mail thành công", Form_Alert.enmType.Success);
                    else
                        XuLyGiaoDien.Alert("Gửi mail không thành công", Form_Alert.enmType.Warning);
                    if (XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.CloseWaitForm();
                }
            }
        }

        private void lstDaiLy_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            lblChon.Text = string.Format("Đã chọn: {0} đại lý", lstDaiLy.CheckedItems.Count);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                lstDaiLy.CheckAll();
            else
                lstDaiLy.UnCheckAll();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            XtraFolderBrowserDialog fbd = new XtraFolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                GiaoDichD gdb = new GiaoDichD();
                bool isok = false;
                int n = lstDaiLy.CheckedItems.Count;
                for (int i = 0; i < n; i++)
                {
                    DaiLyO dl = lstDaiLy.GetItem(lstDaiLy.CheckedIndices[0]) as DaiLyO;
                    string daily = string.Format("{0}", dl.ID);
                    List<GiaoDichO> lstCongNo = gdb.LayDanhSachCN((DateTime)dtpTuNgay.EditValue, (DateTime)dtpDenNgay.EditValue, daily, true);

                    if (lstCongNo.Count > 1)
                    {
                        gridCTCongNo.Refresh();
                        isok = true;
                        CTGiaoDichDindingSource.DataSource = lstCongNo;
                        // Xuất excel
                        string strFile = fbd.SelectedPath + @"\" + dl.Ten + " - " + ((DateTime)dtpTuNgay.EditValue).ToString("dd_MM_yyyy") + " - " + ((DateTime)dtpDenNgay.EditValue).ToString("dd_MM_yyyy") + ".xlsx";

                        XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                        opt.CustomizeCell += op_CustomizeCell;
                        opt.SheetName = "Bản Công Nợ";
                        gridCTCongNo.ForceInitialize();
                        grvCTCongNo.Columns["LuyKe"].Width = 90;
                        grvCTCongNo.Columns["GiaThu"].Width = 90;
                        grvCTCongNo.Columns["GiaHeThong"].Width = 90;
                        grvCTCongNo.Columns["TaiKhoanCo"].Width = 90;
                        grvCTCongNo.Columns["TenKhach"].Width = 400;
                        grvCTCongNo.OptionsPrint.AutoWidth = false;
                        grvCTCongNo.OptionsView.ColumnAutoWidth = false;
                        gridCTCongNo.ExportToXlsx(strFile, opt);
                        int index = lstDaiLy.FindItem(0, true, delegate (ListBoxFindItemArgs ei) { ei.IsFound = object.Equals(dl.ID, ei.ItemValue); });
                        lstDaiLy.SetItemChecked(index, false);
                    }
                }
                if (isok)
                    XuLyGiaoDien.Alert("Xuất file thành công!", Form_Alert.enmType.Success);
                else
                    XuLyGiaoDien.Alert("Không có thông tin", Form_Alert.enmType.Info);
            }
        }

        void op_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs e)
        {
            string _mark = (grvCTCongNo.GetRowCellValue(e.RowHandle, "TenKhach") ?? string.Empty).ToString();
            int _LoaiGiaoDich = int.Parse((grvCTCongNo.GetRowCellValue(e.RowHandle, "LoaiGiaoDich") ?? -1).ToString());
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();

            if (e.Value is DateTime && (DateTime)e.Value == testDT || e.Value == null)
            {
                e.Formatting.FormatType = DevExpress.Utils.FormatType.None;
                e.Value = string.Empty;
            }

            if (e.AreaType == SheetAreaType.Header || _mark == "TỔNG CỘNG:")
            {
                formatting.Font.Bold = true;
                formatting.Fill = XlFill.SolidFill(Color.DarkSeaGreen);
                e.Handled = true;
                e.Formatting.CopyFrom(formatting, FormatType.None);
            }

            if (e.ColumnFieldName == "LoaiGiaoDich")
            {
                switch (_LoaiGiaoDich)
                {
                    case 0:
                    case 1:
                        formatting.Fill = XlFill.SolidFill(Color.FromArgb(237, 105, 28));
                        break;
                    case 2:
                        formatting.Fill = XlFill.SolidFill(Color.Lime);
                        break;
                    case 6:
                    case 7:
                        formatting.Fill = XlFill.SolidFill(Color.FromArgb(250, 52, 131));
                        break;
                    case 8:
                    case 9:
                        formatting.Fill = XlFill.SolidFill(Color.FromArgb(232, 72, 72));
                        break;
                    case 10:
                        formatting.Fill = XlFill.SolidFill(Color.Gold);
                        break;
                }
                e.Formatting.CopyFrom(formatting, FormatType.None);
            }

            e.Handled = true;
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            No();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            No();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            No();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
            { LoaiKhach = int.Parse((sender as CheckEdit).Tag.ToString()); No(); }
        }
        #endregion

        #region Tệp dính kèm

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
        private void btn_open_file_Click(object sender, EventArgs e)
        {
            string file = btn_open_file.Tag as string;
            System.Diagnostics.Process.Start(file);
        }

        void tkeEmail_BeforeShowPopupPanel(object sender, TokenEditBeforeShowPopupPanelEventArgs e)
        {
            lblName.Text = e.Description;
            btn_open_file.Tag = e.Value.ToString();
            pic_extension_file.Image = Icon.ExtractAssociatedIcon(e.Value.ToString()).ToBitmap();
        }

        void tkeEmail_CustomDrawTokenGlyph(object sender, TokenEditCustomDrawTokenGlyphEventArgs e)
        {
            var file_name = e.Value.ToString();
            //Image image = icEmail.Images[0];
            var image = Icon.ExtractAssociatedIcon(file_name).ToBitmap();
            if (image != null) e.Cache.Paint.DrawImage(e.Graphics, image, e.GlyphBounds, new Rectangle(Point.Empty, image.Size), true);
            e.Handled = true;
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
        #endregion

        private void btnTepCoDinh_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
            key.SetValue("TepDinhKem", (txtFileDinhKem.EditValue ?? string.Empty));
            key.Close();
        }
    }
}