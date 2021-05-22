using DataAccessLayer;
using DataTransferObject;
using DevExpress.Export;
using DevExpress.Export.Xl;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmHoaDonGui : DevExpress.XtraEditors.XtraForm
    {
        List<O_HOADON> lst = new List<O_HOADON>();
        List<O_DAILY> lstDaiLy = new List<O_DAILY>();
        public frmHoaDonGui()
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCHD, GVHD);
        }

        private void frmHoaDonGui_Load(object sender, EventArgs e)
        {
            txtMauEmail.HtmlText = new D_MAUEMAIL().DuLieu()[1].NoiDung;
            DateTime dtp = DateTime.Now;
            bdtpTu.EditValue = new DateTime(dtp.Year, dtp.Month == 1 ? 1 : dtp.Month - 1, 1);
            bdtpDen.EditValue = new DateTime(dtp.Year, dtp.Month == 1 ? 1 : dtp.Month - 1, 1).AddDays(-1);
            tuyenBayOBindingSource.DataSource = new D_TUYENBAY().DuLieu();
        }

        private void btnM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMauEmail.Visible = !txtMauEmail.Visible;
            txtMauEmail.Size = new Size(665, 479);
        }
        void op_CustomizeCell(CustomizeCellEventArgs e)
        {
            long _mark = long.Parse((GVG.GetRowCellValue(e.RowHandle, "ID") ?? 0).ToString());
            XlCellFormatting formatting = new XlCellFormatting();
            formatting.Font = new XlFont();
            formatting.Font.Bold = true;
            formatting.Font.Name = "Times New Roman";

            if (_mark == 0)
            {
                formatting.Border = XlBorder.OutlineBorders(Color.FromArgb(216, 228, 188));
                if (e.ColumnFieldName == "CongTy")
                    formatting.Border.RightColor = Color.Black;
                formatting.Fill = XlFill.SolidFill(Color.FromArgb(216, 228, 188));
                e.Formatting.FormatType = FormatType.None;
                e.Value = string.Empty;
            }
            else
            {
                XlCellAlignment alignment = new XlCellAlignment();
                alignment.HorizontalAlignment = XlHorizontalAlignment.Center;
                alignment.VerticalAlignment = XlVerticalAlignment.Center;

                if (e.AreaType == SheetAreaType.Header)
                {
                    e.Formatting.Alignment = alignment;
                    formatting.Fill = XlFill.SolidFill(Color.DarkSeaGreen);
                    formatting.Font.Size = 15;
                }
                else if (_mark == -1)
                {
                    formatting.Border = XlBorder.OutlineBorders(Color.DarkSeaGreen);
                    if (!"MaCho HanhTrinhDi MaHD SoVe".Contains(e.ColumnFieldName))
                        formatting.Border.RightColor = Color.Black;

                    formatting.Border.BottomColor = Color.Black;
                    formatting.Fill = XlFill.SolidFill(Color.DarkSeaGreen);
                    formatting.Font.Size = 12;
                    if (e.ColumnFieldName == "HanhTrinhVe")
                        e.Value = "Tổng";
                    if ((e.Value ?? string.Empty).ToString() == "0")
                        e.Value = string.Empty;
                }
                else
                {

                    formatting.Fill = XlFill.SolidFill(Color.White);
                    if (e.Value is string)
                        e.Formatting.Alignment = alignment;
                }
            }
            e.Formatting.CopyFrom(formatting, FormatType.None);
            e.Handled = true;
        }

        private void GVHD_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "HanhTrinhVe" || e.Column.FieldName == "HanhTrinhDi" || e.Column.FieldName == "SoVe")
            {
                string _mark = (view.GetRowCellValue(e.RowHandle1, "MaCho") ?? string.Empty).ToString();
                string _mark2 = (view.GetRowCellValue(e.RowHandle2, "MaCho") ?? string.Empty).ToString();
                string _mark3 = (view.GetRowCellValue(e.RowHandle1, e.Column) ?? string.Empty).ToString();
                string _mark4 = (view.GetRowCellValue(e.RowHandle2, e.Column) ?? string.Empty).ToString();
                e.Merge = _mark == _mark2 && _mark3 == _mark4;
                e.Handled = true;
            }
            else if (e.Column.FieldName == "CongTy")
            {
                string _mark = (view.GetRowCellValue(e.RowHandle1, "MaHD") ?? string.Empty).ToString();
                string _mark2 = (view.GetRowCellValue(e.RowHandle2, "MaHD") ?? string.Empty).ToString();
                string _mark3 = (view.GetRowCellValue(e.RowHandle1, e.Column) ?? string.Empty).ToString();
                string _mark4 = (view.GetRowCellValue(e.RowHandle2, e.Column) ?? string.Empty).ToString();
                e.Merge = _mark == _mark2 && _mark3 == _mark4;
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int n = lstDaiLyz.CheckedItems.Count;
            if (n == 0)
                XuLyGiaoDien.Alert("Chưa chọn đại lý tìm!", Form_Alert.enmType.Info);
            else
            {
                if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.ShowWaitForm();
                string daily = string.Format("{0}", lstDaiLyz.CheckedItems[0]);
                for (int i = 1; i < n; i++)
                {
                    daily += string.Format(",{0}", lstDaiLyz.CheckedItems[i]);
                }
                lst = new D_HOADON().DuLieu(string.Format("CONVERT(date, NgayThucHien) BETWEEN '{0}' AND '{1}' AND MaHD <> '0' AND ((GiaYeuCau - GiaHeThong) * PhanTram / 100) > 0 AND IDKhachHang in ({2}) ORDER BY IDKhachHang,MaHD,MaCho,GiaHeThong Desc", bdtpTu.DateTime.ToString("yyyyMMdd"), bdtpDen.DateTime.ToString("yyyyMMdd"), daily));
                hoaDonOBindingSource.DataSource = lst;
                if (XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.CloseWaitForm();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xuất excel ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int n = lstDaiLyz.CheckedItems.Count;
                if (n == 0)
                    XuLyGiaoDien.Alert("Chưa chọn đại lý tìm", Form_Alert.enmType.Info);
                else
                {
                    GCG.Visible = true;
                    if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.ShowWaitForm();
                    List<long> a = new List<long>();
                    string daily = string.Format("{0}", lstDaiLyz.CheckedItems[0]);
                    a.Add(long.Parse(lstDaiLyz.CheckedItems[0].ToString()));
                    for (int i = 1; i < n; i++)
                    {
                        a.Add(long.Parse(lstDaiLyz.CheckedItems[i].ToString()));
                        daily += string.Format(",{0}", lstDaiLyz.CheckedItems[i]);
                    }

                    lst = new D_HOADON().DuLieu(string.Format("CONVERT(date, NgayThucHien) BETWEEN '{0}' AND '{1}' AND MaHD <> '0' AND ((GiaYeuCau - GiaHeThong) * PhanTram / 100) > 0 AND IDKhachHang in ({2}) ORDER BY IDKhachHang,MaHD,MaCho,GiaHeThong Desc", bdtpTu.DateTime.ToString("yyyyMMdd"), bdtpDen.DateTime.ToString("yyyyMMdd"), daily));

                    foreach (int b in a)
                    {
                        O_DAILY dl = lstDaiLy.Where(w => w.ID.Equals(b)).ToList()[0];
                        XuLyGiaoDien.wait.SetWaitFormDescription("Excel cho: " + dl.Ten);
                        List<O_HOADON> lstTam1 = lst.Where(w => w.IDKhachHang.Equals(b)).OrderBy(w => w.MaHD.Replace(" ", string.Empty)).ToList();
                        List<O_HOADON> lstTam = new List<O_HOADON>();
                        string newrow = string.Empty;
                        foreach (O_HOADON hd in lstTam1)
                        {
                            if (newrow != hd.MaHD && newrow.Length > 0)
                                lstTam.Add(new O_HOADON());
                            lstTam.Add(hd);
                            newrow = hd.MaHD;
                        }

                        lstTam.Add(new O_HOADON()
                        {
                            ID = -1,
                            GiaHeThong = lstTam.Sum(w => w.GiaHeThong),
                            GiaYeuCau = lstTam.Sum(w => w.GiaYeuCau),
                            CL1 = lstTam.Sum(w => w.CL1),
                            CL2 = lstTam.Sum(w => w.CL2),
                        });

                        DevExpress.XtraPrinting.XlsxExportOptionsEx opt = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                        opt.CustomizeCell += op_CustomizeCell;
                        opt.SheetName = "Bản CTHD";
                        guiOBindingSource.DataSource = lstTam;
                        opt.ApplyFormattingToEntireColumn = DefaultBoolean.False;
                        opt.ShowGridLines = false;
                        string strFile = @"C:\HoaDon\CT HoaDon " + dl.Ten + ".xlsx";
                        Directory.CreateDirectory(@"C:\HoaDon");
                        GVG.ExportToXlsx(strFile, opt);
                    }
                    GCG.Visible = false;
                    if (XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.CloseWaitForm();
                }
            }
        }

        private void btnMau_Click(object sender, EventArgs e)
        {
            txtMauEmail.Visible = !txtMauEmail.Visible;
            txtMauEmail.Size = new Size(665, 479);
        }

        private void btnTimDL_Click(object sender, EventArgs e)
        {
            if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
            {
                lstDaiLy = new D_DAILY().HoaDon(bdtpTu.DateTime, bdtpDen.DateTime);
                daiLyOBindingSource.DataSource = lstDaiLy;
                chkAll.Checked = false;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                lstDaiLyz.CheckAll();
            else
                lstDaiLyz.UnCheckAll();
        }

        private void lstDaiLyz_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            lblChon.Text = string.Format("Đã chọn: {0} đại lý", lstDaiLyz.CheckedItems.Count);
        }

        D_CAUHINHSMTP cauHinhSMTPD = new D_CAUHINHSMTP();
        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn gửi mail ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int n = lstDaiLyz.CheckedItems.Count;
                if (n == 0)
                    XuLyGiaoDien.Alert("Chưa chọn đại lý tìm", Form_Alert.enmType.Info);
                else
                {
                    O_CAUHINHSMTP cauHinhSMTPO = cauHinhSMTPD.DuLieu();
                    O_MAUEMAIL ma = new D_MAUEMAIL().DuLieu()[0];

                    SmtpClient client = new SmtpClient();
                    client.Port = cauHinhSMTPO.Port;
                    client.Host = cauHinhSMTPO.Host;
                    client.EnableSsl = cauHinhSMTPO.SSL;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(cauHinhSMTPO.Email, cauHinhSMTPO.Password);


                    GCG.Visible = true; if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.ShowWaitForm();
                    List<long> a = new List<long>();
                    string daily = string.Format("{0}", lstDaiLyz.CheckedItems[0]);
                    a.Add(long.Parse(lstDaiLyz.CheckedItems[0].ToString()));
                    for (int i = 1; i < n; i++)
                    {
                        a.Add(long.Parse(lstDaiLyz.CheckedItems[i].ToString()));
                        daily += string.Format(",{0}", lstDaiLyz.CheckedItems[i]);
                    }

                    lst = new D_HOADON().DuLieu(string.Format("CONVERT(date, NgayThucHien) BETWEEN '{0}' AND '{1}' AND MaHD <> '0' AND ((GiaYeuCau - GiaHeThong) * PhanTram / 100) > 0 AND IDKhachHang in ({2}) ORDER BY IDKhachHang,MaHD,MaCho,GiaHeThong Desc", bdtpTu.DateTime.ToString("yyyyMMdd"), bdtpDen.DateTime.ToString("yyyyMMdd"), daily));

                    DevExpress.XtraPrinting.XlsxExportOptionsEx opt = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                    opt.CustomizeCell += op_CustomizeCell;
                    opt.SheetName = "Bản CTHD";
                    opt.ApplyFormattingToEntireColumn = DefaultBoolean.False;
                    opt.ShowGridLines = false;

                    bool sendOK = false;
                    foreach (int b in a)
                    {
                        O_DAILY dl = lstDaiLy.Where(w => w.ID.Equals(b)).ToList()[0];
                        txtMauEmail.HtmlText = ma.NoiDung.Replace("{0}", dl.MaDL).Replace("{1}", XuLyDuLieu.NotVietKey(dl.Ten));
                        string[] EmailKeToanString = System.Text.RegularExpressions.Regex.Replace(dl.EmailKeToan, @"\t|\n|\r", "|").Replace("||", "|").Split('|');
                        for (int ii = 0; ii < EmailKeToanString.Count(); ii++)
                        {
                            if (EmailKeToanString[ii].Length > 5)
                            {
                                List<O_HOADON> lstTam1 = lst.Where(w => w.IDKhachHang.Equals(b)).OrderBy(w => w.MaHD.Replace(" ", string.Empty)).ToList();
                                List<O_HOADON> lstTam = new List<O_HOADON>();
                                string newrow = string.Empty;
                                foreach (O_HOADON hd in lstTam1)
                                {
                                    if (newrow != hd.MaHD && newrow.Length > 0)
                                        lstTam.Add(new O_HOADON());
                                    lstTam.Add(hd);
                                    newrow = hd.MaHD;
                                }

                                lstTam.Add(new O_HOADON()
                                {
                                    ID = -1,
                                    GiaHeThong = lstTam.Sum(w => w.GiaHeThong),
                                    GiaYeuCau = lstTam.Sum(w => w.GiaYeuCau),
                                    CL1 = lstTam.Sum(w => w.CL1),
                                    CL2 = lstTam.Sum(w => w.CL2),
                                });

                                MailMessage mm = new MailMessage();
                                mm.From = new MailAddress("ketoan02@thanhhoang.vn", "Thành Hoàng");
                                mm.BodyEncoding = UTF8Encoding.UTF8;
                                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                mm.IsBodyHtml = true;
                                RichEditMailMessageExporter exporter = new RichEditMailMessageExporter(txtMauEmail, mm);
                                exporter.Export();
                                mm.To.Add(new MailAddress(EmailKeToanString[ii]));
                                //mm.To.Add(new MailAddress("tungtranims@gmail.com"));

                                XuLyGiaoDien.wait.SetWaitFormDescription("Excel cho: " + dl.Ten);
                                guiOBindingSource.DataSource = lstTam;
                                string strFile = @"C:\HoaDon\CT HoaDon " + dl.Ten + ".xlsx";
                                System.IO.Directory.CreateDirectory(@"C:\HoaDon");
                                GVG.ExportToXlsx(strFile, opt);

                                mm.Attachments.Add(new Attachment(strFile));
                                mm.Subject = "Bảng kê hóa đơn Tháng " + bdtpTu.DateTime.Month + " - " + dl.Ten;
                                client.Send(mm);
                                sendOK = true;
                                mm.Attachments.Dispose();
                                if (File.Exists(strFile))
                                    File.Delete(strFile);
                            }

                        }
                    }
                    GCG.Visible = false;
                    if (XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.CloseWaitForm();
                    if (sendOK)
                        XuLyGiaoDien.Alert("Gửi mail thành công", Form_Alert.enmType.Success);
                    else
                        XuLyGiaoDien.Alert("Gửi mail không thành công", Form_Alert.enmType.Warning);
                }
            }
        }

        private void btnTHu_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn thêm phí ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int n = lstDaiLyz.CheckedItems.Count;
                if (n == 0)
                    XuLyGiaoDien.Alert("Chưa chọn đại lý tìm", Form_Alert.enmType.Info);
                else
                {
                    if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.ShowWaitForm();
                    List<long> a = new List<long>();
                    string daily = string.Format("{0}", lstDaiLyz.CheckedItems[0]);
                    a.Add(long.Parse(lstDaiLyz.CheckedItems[0].ToString()));
                    for (int i = 1; i < n; i++)
                    {
                        a.Add(long.Parse(lstDaiLyz.CheckedItems[i].ToString()));
                        daily += string.Format(",{0}", lstDaiLyz.CheckedItems[i]);
                    }

                    lst = new D_HOADON().DuLieu(string.Format("CONVERT(date, NgayThucHien) BETWEEN '{0}' AND '{1}' AND MaHD <> '0'  AND ((GiaYeuCau - GiaHeThong) * PhanTram / 100) > 0 AND IDKhachHang in ({2}) ORDER BY IDKhachHang,MaHD,MaCho,GiaHeThong Desc", bdtpTu.DateTime.ToString("yyyyMMdd"), bdtpDen.DateTime.ToString("yyyyMMdd"), daily));

                    O_GIAODICH gdo;

                    O_KHOANGAY kn = new D_KHOANGAY().KiemTraNgayKhoa(bdtpTu.DateTime);
                    if (kn.KhoaAdmin)
                        return;

                    D_GIAODICH giaoDichD = new D_GIAODICH();
                    foreach (int b in a)
                    {
                        O_DAILY dl = lstDaiLy.Where(w => w.ID.Equals(b)).ToList()[0];
                        XuLyGiaoDien.wait.SetWaitFormDescription("Thu phí: " + dl.Ten);

                        gdo = new O_GIAODICH();
                        gdo.LoaiKhachHang = dl.LoaiKhachHang;
                        gdo.IDKhachHang = dl.ID;
                        gdo.MaCho = "HD";
                        gdo.NVGiaoDich = DuLieuTaoSan.NV.ID;
                        gdo.GiaThu = gdo.GiaHeThong = long.Parse(lst.Where(w => w.IDKhachHang.Equals(b)).Sum(w => w.CL2).ToString());
                        gdo.TenKhach = "Phí hóa đơn tháng " + bdtpTu.DateTime.Month;
                        gdo.CoDinh = true;
                        gdo.HTTT = 1;
                        gdo.LoaiGiaoDich = 5;
                        if (gdo.GiaHeThong > 0)
                            giaoDichD.ThemMoi(XuLyDuLieu.ConvertClassToDic(gdo));
                    }
                    if (XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.CloseWaitForm();
                    XuLyGiaoDien.Alert("Thêm giao dịch thành công!", Form_Alert.enmType.Success);
                }
            }
        }
    }
}