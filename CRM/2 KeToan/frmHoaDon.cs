using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmHoaDon : XtraForm
    {
        public frmHoaDon()
        {
            InitializeComponent();

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            tuyenBayOBindingSource.DataSource = new TuyenBayD().DuLieu();
            DSLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_GiaoDich();
            khachHangOBindingSource.DataSource = new DaiLyD().All();
            nCCOBindingSource.DataSource = new NCCD().DuLieu();
            DuLieu();
        }

        #region Dữ liệu 
        string _query = string.Empty;
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();

            if (chk1.Checked)
                _query = DuLieuTaoSan.ThoiGianRutGon("NgayThucHien")[idThoiGian].Substring(3);
            if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    _query = string.Format("(convert(date, NgayThucHien) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk3.Checked && _SV_MC.Length > 4)
                _query += string.Format("AND (SoVe = '{0}' or SoVe2 = '{0}')", _SV_MC);
            else if (chk4.Checked && _SV_MC.Length > 4)
                _query += string.Format("AND (MaCho = '{0}' or MaCho2 = '{0}')", _SV_MC);

            if (_query.Length > 0)
            {
                hoaDonOs = hoaDonD.DuLieu(_query);
                hoaDonOBindingSource.DataSource = hoaDonOs;
                GVHD.BestFitColumns();
            }

            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        int idThoiGian = 0;
        HoaDonD hoaDonD = new HoaDonD();
        List<HoaDonO> hoaDonOs = new List<HoaDonO>();
        #endregion

        #region Sự kiện nút
        private void btnLoadDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void barCheckItem3_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            barSoVe.Enabled = chk3.Checked;
            barMacho.Enabled = chk4.Checked;
            DuLieu();

            if (chk1.Checked)
                bcmbThoiGian.Links[0].Focus();
            else if (chk2.Checked)
                bdtpTu.Links[0].Focus();
            else if (chk3.Checked)
                barSoVe.Links[0].Focus();
            else if (chk4.Checked)
                barMacho.Links[0].Focus();
        }

        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            idThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }

        private void rdptTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            DuLieu();
        }
        #endregion

        #region Sự khiện bản 
        private void grvDatCho_DoubleClick(object sender, EventArgs e)
        {
            HoaDonO GD = (GVHD.GetRow(GVHD.GetSelectedRows()[0]) as HoaDonO);
            List<HoaDonO> lst = new List<HoaDonO>();
            lst = hoaDonOs.Where(w => w.SoChungTu.Equals(GD.SoChungTu) && w.IDKhachHang.Equals(GD.IDKhachHang) && w.NgayThucHien.ToString("ddMMyyy").Equals(GD.NgayThucHien.ToString("ddMMyyy"))).ToList();
            if (lst.Count() > 1)
            {
                if (XtraMessageBox.Show("Bạn muốn chỉnh sửa tất cả", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    lst = hoaDonOs.Where(w => w.ID.Equals(GD.ID)).ToList();
            }
            else
                lst = hoaDonOs.Where(w => w.ID.Equals(GD.ID)).ToList();
            frmHoaDonThem frm = new frmHoaDonThem(lst);
            frm.ShowDialog(ParentForm);
        }
        #endregion

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmHoaDonThem().ShowDialog(this);
        }

        private void btnThemRow_ItemClick(object sender, ItemClickEventArgs e)
        {
            HoaDonO GD = (GVHD.GetRow(GVHD.GetSelectedRows()[0]) as HoaDonO);
            frmHoaDonThem frm = new frmHoaDonThem(GD);
            frm.ShowDialog(ParentForm);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }

        HoaDonD _HoaDonD = new HoaDonD();
        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult da = XtraMessageBox.Show("Bạn muốn xóa tất cả trong HD", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            HoaDonO GD = (GVHD.GetRow(GVHD.GetSelectedRows()[0]) as HoaDonO);
            List<HoaDonO> lst = hoaDonOs.Where(w => w.SoChungTu.Equals(GD.SoChungTu) && w.IDKhachHang.Equals(GD.IDKhachHang) && w.NgayThucHien.ToString("ddMMyyy").Equals(GD.NgayThucHien.ToString("ddMMyyy"))).ToList();
            long A = 0;
            switch (da)
            {
                case DialogResult.Yes:
                    List<object> s = new List<object>();
                    foreach (HoaDonO z in lst)
                    {
                        s.Add(z.ID);
                    }
                    A = _HoaDonD.XoaNhieu1Ban(s); DuLieu();
                    break;
                case DialogResult.No:
                    A = _HoaDonD.Xoa(GD.ID); DuLieu();
                    break;
                case DialogResult.Cancel:
                    return;
            }
        }

        private void GVHD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.FieldName == "NgayGDV2" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "GiaHeThong2").ToString() == "0")
                    e.DisplayText = string.Empty;
            }
        }

        private void rDaBaoGia_KeyDown(object sender, KeyEventArgs e)
        {
            TextEdit z = (sender as TextEdit);
            string a = z.Text;
            if ((e.KeyCode == Keys.Enter) && Text.Length > 4)
                if (XuLyDuLieu.IsNumeric(a))
                {
                    z.Text = string.Empty;
                    hoaDonD.CapNhatTrangThai(z.Properties.Name.Substring(1), a.Replace(" ", string.Empty));
                    DuLieu();
                }
        }


        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCHD, GVHD, "Bản HD " + DateTime.Now.ToString("dd-MM-yy HH-mm"));
        }

        string _SV_MC = string.Empty;
        private void aMaCho_KeyDown(object sender, KeyEventArgs e)
        {
            _SV_MC = (sender as TextEdit).Text;
            if (e.KeyCode == Keys.Enter)
                DuLieu();
        }
    }
}