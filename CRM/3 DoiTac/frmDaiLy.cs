using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Drawing;
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
            DuLieu();
            DSNhanVien.DataSource = _DaiLyD.NhanVien();
            btnChiTiet.Click += BtnChiTiet_Click;
            btnThonKe.Click += BtnThonKe_Click;
            btnUpQuy.Click += BtnUpQuy_Click;
        }


        #region Dữ liệu 
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            tinhTrangOBindingSource.DataSource = new TinhTrangD().DuLieu(0, true);
            chinhSachOBindingSource.DataSource = new ChinhSachD().All();
            _DaiLyD.ChaySoDu();
            daiLyOBindingSource.DataSource = _DaiLyD.DuLieu(index);
            XuLyGiaoDien.wait.CloseWaitForm();
            colThongKe.Visible = index == 1;
            colQuyAGS.Visible = DuLieuTaoSan.Q.NganHangThemSua;
        }
        #endregion

        #region Biến
        DaiLyD _DaiLyD = new DaiLyD();
        int index = 1;
        #endregion

        #region Giao diện
        private void grvDaiLy_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0 && index != 3)
            {
                DaiLyO dl = View.GetRow(e.RowHandle) as DaiLyO;
                if (dl != null)
                {
                    if (dl.SoDu < 0 - dl.QuyChet)
                        if (e.Column.FieldName == "Ten" || e.Column.FieldName == "SoDu")
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
            DaiLyO dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as DaiLyO;
            new frmCongNoPhu(dl).ShowDialog();
        }

        private void BtnThonKe_Click(object sender, EventArgs e)
        {
            DaiLyO dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as DaiLyO;
            new frmBieuDoDaiLy(dl.ID).ShowDialog();
        }

        private void BtnUpQuy_Click(object sender, EventArgs e)
        {
            DaiLyO dl = GVDL.GetRow(GVDL.GetSelectedRows()[0]) as DaiLyO;
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
                new frmDaiLyThem(GVDL.GetRow(GVDL.GetSelectedRows()[0]) as DaiLyO).ShowDialog(ParentForm);
        }
        private void grvDaiLy_DoubleClick(object sender, EventArgs e)
        {
            new frmDaiLyThem(GVDL.GetRow(GVDL.GetSelectedRows()[0]) as DaiLyO).ShowDialog(ParentForm);
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
    }
}