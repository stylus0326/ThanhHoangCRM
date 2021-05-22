using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmDaiLy : XtraForm
    {
        public frmDaiLy()
        {
            InitializeComponent();
        }

        private void frmDaiLy_Load(object sender, EventArgs e)//
        {
            btnSI.Visibility = DuLieuTaoSan.Q.Lv2SignIn ? BarItemVisibility.Always : BarItemVisibility.Never;
            btneXCEL.Visibility = DuLieuTaoSan.Q.DaiLyAdmin ? BarItemVisibility.Always : BarItemVisibility.Never;
            DuLieu();
            DSNhanVien.DataSource = _DaiLyD.NhanVien();
            btnChiTiet.Click += BtnChiTiet_Click;
            btnThonKe.Click += BtnThonKe_Click;
            btnUpQuy.Click += BtnUpQuy_Click;
            btnSIC.Click += BtnSIC_Click;
        }

        private void BtnSIC_Click(object sender, EventArgs e)
        {
            O_DAILY dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as O_DAILY;
            if (dl.SIC > 0)
                new frmSignIn(dl).ShowDialog();
        }


        #region Dữ liệu 
        int KieuHienThi = 0;
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            tinhTrangOBindingSource.DataSource = new D_TRANGTHAI().DuLieu(0, true);
            chinhSachOBindingSource.DataSource = new D_CHINHSACH().All();
            _DaiLyD.ChaySoDu();
            if (KieuHienThi == 3)
                daiLyOBindingSource.DataSource = _DaiLyD.DuLieu(index);
            else
                daiLyOBindingSource.DataSource = _DaiLyD.DuLieu(index).Where(w => w.TrangThaiHoatDong.Equals(KieuHienThi));
            XuLyGiaoDien.wait.CloseWaitForm();
            colQuyAGS.Visible = DuLieuTaoSan.Q.NganHangThemSua;
        }
        #endregion

        #region Biến
        D_DAILY _DaiLyD = new D_DAILY();
        int index = 1;
        #endregion

        #region Giao diện
        private void grvDaiLy_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0 && index != 3)
            {
                O_DAILY dl = View.GetRow(e.RowHandle) as O_DAILY;
                if (dl != null)
                {
                    if (dl.SoDu < 0 - dl.QuyChet)
                        if (e.Column.FieldName == "Ten" || e.Column.FieldName == "SoDu")
                            e.Appearance.BackColor = Color.IndianRed;
                    if (dl.SoDu < 0 - dl.HanMuc && dl.HanMuc > 0)
                        if (e.Column.FieldName == "HanMuc")
                            e.Appearance.BackColor = Color.IndianRed;
                }
            }
        }

        string EmailKeToan = "-";
        string EmailGiaoDich = "-";
        string DienThoai = "-";
        string DiDong = "-";
        string Zalo = "-";
        string Skype = "-";
        string EmailHD = "-";
        string DienThoaiHD = "-";

        bool IsTrue = false;
        private void grvDaiLy_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (!DuLieuTaoSan.Q.DaiLyAdmin)
            {
                IsTrue = !(GVDL.RowCount > 1);

                colEmailKeToan.OptionsColumn.AllowEdit =
                colEmailGiaoDich.OptionsColumn.AllowEdit =
                colDienThoai.OptionsColumn.AllowEdit =
                colDiDong.OptionsColumn.AllowEdit =
                colZalo.OptionsColumn.AllowEdit =
                colEmailHD.OptionsColumn.AllowEdit = IsTrue;

                if (!IsTrue)
                {
                    switch (e.Column.FieldName)
                    {
                        case "EmailKeToan":
                            e.DisplayText = EmailKeToan;
                            break;
                        case "EmailGiaoDich":
                            e.DisplayText = EmailGiaoDich;
                            break;
                        case "DienThoai":
                            e.DisplayText = DienThoai;
                            break;
                        case "DiDong":
                            e.DisplayText = DiDong;
                            break;
                        case "Zalo":
                            e.DisplayText = Zalo;
                            break;
                        case "Skype":
                            e.DisplayText = Skype;
                            break;
                        case "EmailHD":
                            e.DisplayText = EmailHD;
                            break;
                        case "DienThoaiHD":
                            e.DisplayText = DienThoaiHD;
                            break;
                    }
                }
            }
        }

        private void txtEmailKeToan_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit Txt = (sender as TextEdit);
            EmailKeToan = Txt.Text;
            if (Txt.Text == string.Empty)
                EmailKeToan = "-";
        }

        private void txtEmailGiaoDich_EditValueChanged(object sender, EventArgs e)
        {
            if (index != 3)
            {
                TextEdit Txt = (sender as TextEdit);
                EmailGiaoDich = Txt.Text;
                if (Txt.Text == string.Empty)
                    EmailGiaoDich = "-";
            }
        }

        private void txtDiDong_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit Txt = (sender as TextEdit);
            DiDong = Txt.Text;
            if (Txt.Text == string.Empty)
                DiDong = "-";
        }

        private void txtDienThoai_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit Txt = (sender as TextEdit);
            DienThoai = Txt.Text;
            if (Txt.Text == string.Empty)
                DienThoai = "-";
        }

        private void txtZalo_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit Txt = (sender as TextEdit);
            Zalo = Txt.Text;
            if (Txt.Text == string.Empty)
                Zalo = "-";
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit Txt = (sender as TextEdit);
            DienThoaiHD = Txt.Text;
            if (Txt.Text == string.Empty)
                DienThoaiHD = "-";
        }
        #endregion

        #region Sự kiện nút
        private void BtnChiTiet_Click(object sender, EventArgs e)
        {
            O_DAILY dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as O_DAILY;
            new frmCongNoPhu(dl).ShowDialog();
        }

        private void BtnThonKe_Click(object sender, EventArgs e)
        {
            if (index == 1)
            {
                O_DAILY dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as O_DAILY;
                new frmBieuDoDaiLy(dl.ID).ShowDialog();
            }
        }

        private void BtnUpQuy_Click(object sender, EventArgs e)
        {
            O_DAILY dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as O_DAILY;
            new frmQuyAGS(dl).ShowDialog(this);
        }

        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void chkCty_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            index = int.Parse((sender as BarCheckItem).Tag.ToString());
            DuLieu();
            Text = (sender as BarCheckItem).Caption;
            btnSI.Visibility = DuLieuTaoSan.Q.Lv2SignIn ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        private void btnSI_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmSignIn().ShowDialog();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDaiLyThem f = new frmDaiLyThem(index);
            f.Text = index == 1 ? "Đại lý" : "Cộng tác viên";
            f.ShowDialog(ParentForm);
        }

        private void btnNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmNhomKhachHang(index).ShowDialog(this);
        }
        #endregion

        #region Sự khiện bản 
        private void GVDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                new frmDaiLyThem(GVDL.GetRow(GVDL.GetSelectedRows()[0]) as O_DAILY).ShowDialog(ParentForm);
        }
        private void grvDaiLy_DoubleClick(object sender, EventArgs e)
        {
            new frmDaiLyThem(GVDL.GetRow(GVDL.GetSelectedRows()[0]) as O_DAILY).ShowDialog(ParentForm);
        }

        private void grvDaiLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
                e.Handled = true;
        }

        #endregion

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.Info == null && e.SelectedControl == GCDL)
            {
                GridView view = GCDL.FocusedView as GridView;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (view == null)
                    return;
                if (info.InRowCell)
                {
                    string _Text = string.Empty;
                    switch (info.Column.Name)
                    {
                        case "colChiTiet":
                            _Text = "Xem công nợ";
                            break;
                        case "colThongKe":
                            _Text = "thống kê hoạt động 12 tháng gần nhất";
                            break;
                        case "colQuyAGS":
                            _Text = "Up quỹ AGS";
                            break;
                    }
                    if (_Text != string.Empty)
                    {
                        string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                        e.Info = new DevExpress.Utils.ToolTipControlInfo(cellKey, _Text);
                    }
                }
            }
        }

        private void btneXCEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCDL, GVDL, "DS khách-" + DateTime.Now.ToString("dd-MM-yyy"));
        }

        private void rCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            KieuHienThi = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }
    }
}