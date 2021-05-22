using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmChinh : RibbonForm
    {
        public frmChinh()
        {
            InitializeComponent();
            Text += DuLieuTaoSan.Instance.PhienBan + ")";
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            XuLyGiaoDien.OpenForm(this);
            PhanQuyenHienThi();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM");
            chlDG.Checked = !(key.GetValue("TKNC").ToString().ToLower() == "true");

            Bdpi.Caption = "KPI: " + DuLieuTaoSan.NV.Diem;
            if (DuLieuTaoSan.Q.Lv2Ve)
            {
                frmVe f = new frmVe();
                f.MdiParent = this;
                f.Show();
                GridViewHelper.SetFromGrid(f);
                tabbedView1.Documents[0].Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            }
        }

        #region Dữ liệu 
        void PhanQuyenHienThi()
        {
            O_NHOMQUYEN Q = DuLieuTaoSan.Q;
            R1.Visible = Q.Lv1TheoDoi;
            R2.Visible = Q.Lv1ThongKe;
            R3.Visible = Q.Lv1ChucNang;
            Ve.Visibility = Q.Lv2Ve ? BarItemVisibility.Always : BarItemVisibility.Never;
            TongHop.Visibility = Q.Lv2TongHop ? BarItemVisibility.Always : BarItemVisibility.Never;
            TheoDoiHoan.Visibility = Q.Lv2TheoDoiHoan ? BarItemVisibility.Always : BarItemVisibility.Never;
            NganHang.Visibility = Q.Lv2NganHang ? BarItemVisibility.Always : BarItemVisibility.Never;
            TienMat.Visibility = Q.Lv2TienMat ? BarItemVisibility.Always : BarItemVisibility.Never;
            HoaDon.Visibility = Q.Lv2HoaDon ? BarItemVisibility.Always : BarItemVisibility.Never;
            HoaDonGui.Visibility = Q.Lv2HoaDonGui ? BarItemVisibility.Always : BarItemVisibility.Never;
            CongNo.Visibility = Q.Lv2CongNo ? BarItemVisibility.Always : BarItemVisibility.Never;
            DaiLy.Visibility = Q.Lv2DaiLy ? BarItemVisibility.Always : BarItemVisibility.Never;
            KhachLe.Visibility = Q.Lv2KhachLe ? BarItemVisibility.Always : BarItemVisibility.Never;
            ChinhSach.Visibility = Q.Lv2ChinhSach ? BarItemVisibility.Always : BarItemVisibility.Never;
            NhanVien.Visibility = Q.Lv2NhanVien ? BarItemVisibility.Always : BarItemVisibility.Never;
            QuyenNhanVien.Visibility = Q.Lv2QuyenNhanVien ? BarItemVisibility.Always : BarItemVisibility.Never;
            HangBay.Visibility = Q.Lv2HangBay ? BarItemVisibility.Always : BarItemVisibility.Never;
            LichSu.Visibility = Q.Lv2LichSu ? BarItemVisibility.Always : BarItemVisibility.Never;
            TuyenBay.Visibility = Q.Lv2TuyenBay ? BarItemVisibility.Always : BarItemVisibility.Never;
            DaiLyTheoDoi.Visibility = Q.Lv2DaiLyTheoDoi ? BarItemVisibility.Always : BarItemVisibility.Never;
            ThongKeDoanhSo.Visibility = Q.Lv2ThongKeDoanhSo ? BarItemVisibility.Always : BarItemVisibility.Never;
            CTVTheoDoi.Visibility = Q.Lv2CTVTheoDoi ? BarItemVisibility.Always : BarItemVisibility.Never;
            KhachLeNo.Visibility = Q.Lv2KhachLeNo ? BarItemVisibility.Always : BarItemVisibility.Never;
            NCCTheoDoi.Visibility = Q.Lv2NCCTheoDoi ? BarItemVisibility.Always : BarItemVisibility.Never;
            NHTheoDoi.Visibility = Q.Lv2NHTheoDoi ? BarItemVisibility.Always : BarItemVisibility.Never;
            ThongKe.Visibility = Q.Lv2ThongKe ? BarItemVisibility.Always : BarItemVisibility.Never;
            CauHinhEmail.Visibility = Q.Lv2CauHinhEmail ? BarItemVisibility.Always : BarItemVisibility.Never;
            AutoNganHang.Visibility = Q.Lv2AutoNganHang ? BarItemVisibility.Always : BarItemVisibility.Never;
            KhoaNgay.Visibility = Q.Lv2KhoaNgay ? BarItemVisibility.Always : BarItemVisibility.Never;
            SoSanh.Visibility = Q.Lv2SoSanh ? BarItemVisibility.Always : BarItemVisibility.Never;
            SoSanhVN.Visibility = Q.Lv2SoSanhVN ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
        #endregion

        #region Sự kiện nút

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đăng xuất?", "Thành Hoàng CRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabbedView1.Documents.Clear();
                Controls.Clear();
                Owner.Show();
                Dispose();
            }
        }
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.TopMost = true;
        }

        private void chkGD1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarCheckItem checkEdit = sender as BarCheckItem;
            switch (checkEdit.Name)
            {
                case "chkGD1":
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black");
                    break;
                case "chkGD2":
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");
                    break;
                case "chkGD3":
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2016 Black");
                    break;
                case "chkGD4":
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Dark");
                    break;
                default:
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
                    break;
            }
        }

        private void chlDG_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarCheckItem checkEdit = sender as BarCheckItem;
            switch (checkEdit.Name)
            {
                case "chlDG":
                    WindowsFormsSettings.ColumnAutoFilterMode = ColumnAutoFilterMode.Text;
                    WindowsFormsSettings.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
                    WindowsFormsSettings.DefaultSettingsCompatibilityMode = SettingsCompatibilityMode.v18_1;
                    break;
                default:
                    WindowsFormsSettings.ColumnAutoFilterMode = ColumnAutoFilterMode.Value;
                    WindowsFormsSettings.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.Default;
                    WindowsFormsSettings.DefaultSettingsCompatibilityMode = SettingsCompatibilityMode.Latest;
                    break;
            }
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
            key.SetValue("TKNC", chkNC.Checked);
            key.Close();
        }

        private void BitemCWF_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        private void btnThoatNhanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Dispose();
            Application.Exit();
        }
        #endregion

        #region Sự khiện khác 
        private void frmChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs(this, "Bạn muốn đăng xuất ?", "Thành Hoàng", new DialogResult[] { DialogResult.Yes, DialogResult.No }, System.Drawing.SystemIcons.Question, 0);
            args.Showing += Args_Showing;
            if (XtraMessageBox.Show(args) == DialogResult.Yes)
            {
                Dispose();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        private void LinkClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string Chinh = e.Item.Name.ToString();
                if (ModifierKeys == Keys.Control && Chinh == "DaiLy") { }
                else
                    foreach (var form in MdiChildren.Where(frm => frm.GetType().Name == "frm" + Chinh))
                    {
                        form.Activate();
                        return;
                    }

                XuLyGiaoDien.wait.ShowWaitForm();
                var f = Activator.CreateInstance(Type.GetType(string.Format("CRM.frm{0}", Chinh), true)) as XtraForm;
                f.MdiParent = this;
                f.Text = e.Item.Caption;
                f.Show();
                GridViewHelper.SetFromGrid(f);
                XuLyGiaoDien.FlushMemory();
            }
            catch
            {
                XtraMessageBox.Show("Chức năng chưa được tích hợp hoặc đang bảo trì");
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        private void LinkClickOpenF(object sender, ItemClickEventArgs e)
        {
            try
            {
                var f = Activator.CreateInstance(Type.GetType(string.Format("CRM.frm{0}", e.Item.Name.ToString()), true)) as XtraForm;
                f.Text = e.Item.Caption;
                f.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show("Chức năng chưa được tích hợp hoặc đang bảo trì");
            }
        }

        #endregion
    }
}