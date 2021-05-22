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
            tuyenBayOBindingSource.DataSource = new D_TUYENBAY().DuLieu();
            DSLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_GiaoDich();
            khachHangOBindingSource.DataSource = new D_DAILY().All();
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu();
            DuLieu();
        }

        #region Dữ liệu 
        string[] _SV_MC = new string[] { };
        public void DuLieu()
        {
            string _Query = string.Empty;
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();

            if (chk1.Checked)
                _Query = DuLieuTaoSan.ThoiGianRutGon("NgayThucHien")[idThoiGian].Substring(3);
            else if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    _Query = string.Format("(convert(date, NgayThucHien) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk3.Checked && _SV_MC.Length > 0)
                _Query += string.Format("REPLACE(COALESCE(SoVe,''),' ','') in ('{0}')", String.Join("' ,'", _SV_MC));
            else if (chk4.Checked && _SV_MC.Length > 0)
                _Query += string.Format("REPLACE(COALESCE(MaCho,''),' ','') in ('{0}')", String.Join("' ,'", _SV_MC));
            else if (chk5.Checked && _SV_MC.Length > 0)
                _Query += string.Format("REPLACE(COALESCE(MaHD,''),' ','') in ('{0}')", String.Join("' ,'", _SV_MC));

            if (_Query.Length > 0)
            {
                hoaDonOs = hoaDonD.DuLieu(_Query);
                hoaDonOBindingSource.DataSource = hoaDonOs;
                GVHD.BestFitColumns();
            }

            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        private void aMaCho_Leave(object sender, EventArgs e)
        {
            string[] BB = _SV_MC;
            _SV_MC = (sender as MemoExEdit).Text.Replace(" ", "").Replace("\r\n", "|").Split('|').ToArray();
            _SV_MC = _SV_MC.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (String.Join("' ,'", BB) != String.Join("' ,'", _SV_MC))
                DuLieu();
        }

        private void barCheckItem3_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            barSoVe.Enabled = chk3.Checked;
            barMaCho.Enabled = chk4.Checked;
            barMHD.Enabled = chk5.Checked;
            DuLieu();
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

        #region Biến
        int idThoiGian = 0;
        D_HOADON hoaDonD = new D_HOADON();
        List<O_HOADON> hoaDonOs = new List<O_HOADON>();
        #endregion

        #region Sự kiện nút
        private void btnLoadDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DuLieu();
        }

        #endregion

        #region Sự khiện bản 
        private void grvDatCho_DoubleClick(object sender, EventArgs e)
        {
            O_HOADON GD = (GVHD.GetRow(GVHD.GetSelectedRows()[0]) as O_HOADON);
            List<O_HOADON> lst = new List<O_HOADON>();
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
            O_HOADON GD = (GVHD.GetRow(GVHD.GetSelectedRows()[0]) as O_HOADON);
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

        D_HOADON _HoaDonD = new D_HOADON();
        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult da = XtraMessageBox.Show("Bạn muốn xóa tất cả trong HD", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            O_HOADON GD = (GVHD.GetRow(GVHD.GetSelectedRows()[0]) as O_HOADON);
            List<O_HOADON> lst = hoaDonOs.Where(w => w.SoChungTu.Equals(GD.SoChungTu) && w.IDKhachHang.Equals(GD.IDKhachHang) && w.NgayThucHien.ToString("ddMMyyy").Equals(GD.NgayThucHien.ToString("ddMMyyy"))).ToList();
            long A = 0;
            switch (da)
            {
                case DialogResult.Yes:
                    List<object> s = new List<object>();
                    foreach (O_HOADON z in lst)
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
    }
}