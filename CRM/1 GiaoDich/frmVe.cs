using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmVe : DevExpress.XtraEditors.XtraForm
    {
        public frmVe()
        {
            InitializeComponent();
        }

        #region Dữ liệu 
        private void frmVe_Load(object sender, EventArgs e)
        {
            if (!DuLieuTaoSan.Q.VeAdmin)
            {
                GVGD.Columns.Remove(colEmail);
                GVGD.Columns.Remove(colDienThoaiKhachHang);
            }

            rLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();
            rTrangThai.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve(true);
            rHinHThuc.DataSource = DuLieuTaoSan.HinhThuc_Ve_TatCa();
            rHoaDon.DataSource = DuLieuTaoSan.HinhThucHoaDon();
            btnExportExcel.Visibility = DuLieuTaoSan.Q.VeExcel ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnThem.Visibility = DuLieuTaoSan.Q.VeThemSua ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnXoa.Visibility = DuLieuTaoSan.Q.VeXoa ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnHoan.Visibility = DuLieuTaoSan.Q.TheoDoiHoanAdmin ? BarItemVisibility.Always : BarItemVisibility.Never;

            tuyenBayOBindingSource.DataSource = new TuyenBayD().DuLieu();
            nganHangOBindingSource.DataSource = new NganHangD().All();
            hangBayOBindingSource.DataSource = new HangBayD().DuLieu();
            nCCOBindingSource.DataSource = new NCCD().DuLieu_GiaoDich();
            _ListKhoaNgayO = new KhoaNgayD().DuLieu();
            DuLieu();
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tuyenBayOBindingSource.DataSource = new TuyenBayD().DuLieu();
            nganHangOBindingSource.DataSource = new NganHangD().All();
            hangBayOBindingSource.DataSource = new HangBayD().DuLieu();
            nCCOBindingSource.DataSource = new NCCD().DuLieu_GiaoDich();
            _ListKhoaNgayO = new KhoaNgayD().DuLieu();
            DuLieu();
        }

        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();

            _index = GVGD.GetFocusedDataSourceRowIndex() - 10;

            _Query = "LoaiGiaoDich in (4,8,9,13,14) AND TinhCongNo = 1";

            if (chk1.Checked)
                _Query += DuLieuTaoSan.MocThoiGian()[_IDThoiGian];
            else if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    _Query += string.Format("AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk3.Checked && _SV_MC.Length > 4)
                _Query += string.Format("AND SoVeVN = '{0}'", _SV_MC);
            else if (chk4.Checked && _SV_MC.Length > 4)
                _Query += string.Format("AND MaCho = '{0}'", _SV_MC);

            if (_Query != "LoaiGiaoDich in (4,8,9,13,14) AND TinhCongNo = 1")
            {
                khachHangOBindingSource.DataSource = DaiLyD.All();
                _ListGiaoDichO = new GiaoDichD().DuLieu(_Query, DuLieuTaoSan.Q.VeAdmin);
                giaoDichOBindingSource.DataSource = _ListGiaoDichO;
            }

            Size textSize = TextRenderer.MeasureText(_ListGiaoDichO.Count.ToString(), new Font("Tahoma", 9, FontStyle.Regular));
            GVGD.IndicatorWidth = textSize.Width + 5;
            GVGD.FocusedRowHandle = _index;

            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        int _index = 0;
        string _Query = string.Empty;
        string _SV_MC = string.Empty;
        DaiLyD DaiLyD = new DaiLyD();
        List<GiaoDichO> _ListGiaoDichO = new List<GiaoDichO>();
        List<KhoaNgayO> _ListKhoaNgayO = new List<KhoaNgayO>();
        int _IDThoiGian = 0;
        GiaoDichD _GiaoDichD = new GiaoDichD();
        GiaoDichO _GiaoDichO = new GiaoDichO();

        #endregion

        #region Giao diện
        private void GVGD_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }

        private void GVGD_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GiaoDichO dl = View.GetRow(e.RowHandle) as GiaoDichO;
                switch (e.Column.FieldName)
                {
                    case "IDKhachHang":
                        e.Appearance.BackColor = Color.Transparent;
                        break;
                    case "LoaiKhachHang":
                        if (dl.LoaiKhachHang == 0)
                            e.Appearance.BackColor = Color.ForestGreen;
                        break;
                    case "HTTT":
                        if (dl.HTTT == 7)
                            e.Appearance.BackColor = Color.Yellow;
                        break;
                    case "NgayGD":
                        List<KhoaNgayO> khoaNgayO = _ListKhoaNgayO.Where(w => w.TuNgay.ToString("ddMMyy").Equals(dl.NgayGD.ToString("ddMMyy"))).ToList();
                        if (khoaNgayO.Count > 0)
                            if (khoaNgayO[0].HoatDong)
                                e.Appearance.BackColor = Color.Gold;
                        break;
                    case "ChieuDi":
                        if (dl.TuyenBayDi == 0)
                            e.Appearance.BackColor = Color.Gold;
                        break;
                    case "ChieuVe":
                        if (dl.TuyenBayVe == 0 && dl.SoLuongVe == 2)
                            e.Appearance.BackColor = Color.Gold;
                        break;
                }
            }
        }

        private void GVGD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            switch (e.Column.FieldName)
            {
                case "GioBayVe":
                case "GioBayVe_Den":
                    if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        if ((view.GetListSourceRowCellValue(e.ListSourceRowIndex, "SoHieuVe") ?? string.Empty).ToString().Length == 0)
                            e.DisplayText = string.Empty;
                    }
                    break;
            }
        }
        #endregion

        #region Sự kiện nút

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVeThem frm = new frmVeThem();
            frm.ShowDialog(ParentForm);
        }

        private void CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpDen.Enabled = bdtpTu.Enabled = chk2.Checked;
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
            _IDThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }

        private void bdtpTu_EditValueChanged(object sender, EventArgs e)
        {
            DuLieu();
        }

        private void aMaCho_KeyDown(object sender, KeyEventArgs e)
        {
            _SV_MC = (sender as TextEdit).Text;
            if (e.KeyCode == Keys.Enter)
                DuLieu();
        }

        private void btnHoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmVeHoanThem().ShowDialog(ParentForm);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _GiaoDichO = GVGD.GetRow(GVGD.GetSelectedRows()[0]) as GiaoDichO;

            KhoaNgayO kn = new KhoaNgayD().KiemTraNgayKhoa(_GiaoDichO.NgayGD);
            if (_GiaoDichO.TinhCongNo)
                if (!DuLieuTaoSan.Q.VeAdmin)
                    if ((kn.HoatDong) && !(kn.Code ?? string.Empty).Contains(_GiaoDichO.MaCho.Replace(" ", string.Empty)))
                    {
                        XuLyGiaoDien.Alert("Ngày đã bị khóa", Form_Alert.enmType.Warning);
                        return;
                    }

            if (DateTime.Now.Date.Subtract(_GiaoDichO.NgayGD.Date).Days > 30)
            {
                XuLyGiaoDien.Alert("Ngày đã bị khóa", Form_Alert.enmType.Warning);
                return;
            }

            List<object> lstCtv = new List<object>();
            List<GiaoDichO> lst = _ListGiaoDichO.Where(w => w.MaCho.Equals(_GiaoDichO.MaCho) && w.LoaiGiaoDich.Equals(_GiaoDichO.LoaiGiaoDich) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang) && w.NgayGD.ToString("ddMMyyy").Equals(_GiaoDichO.NgayGD.ToString("ddMMyyy")) && w.NhaCungCap.Equals(_GiaoDichO.NhaCungCap) && w.TuyenBayDi.Equals(_GiaoDichO.TuyenBayDi)).ToList();

            bool ThanhCong = false;
            if (lst.Count == 1)
            {
                DialogResult dc = XtraMessageBox.Show("Bạn muốn xóa giao dịch ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dc)
                {
                    case DialogResult.Yes:
                        ThanhCong = _GiaoDichD.Xoa(_GiaoDichO.ID) > 0;
                        break;
                    default:
                        return;
                }
            }
            else
            {
                DialogResult dc = XtraMessageBox.Show("Bạn muốn xóa tất cả giao dịch cùng Mã Chỗ ?", "Câu hỏi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dc)
                {
                    case DialogResult.Yes:
                        foreach (GiaoDichO gdoz in lst)
                        {
                            lstCtv.Add(gdoz.ID);
                        }
                        ThanhCong = _GiaoDichD.XoaNhieu1Ban(lstCtv) > 0;
                        break;
                    case DialogResult.No:
                        ThanhCong = _GiaoDichD.Xoa(_GiaoDichO.ID) > 0;
                        break;
                    default:
                        return;
                }
            }

            if (XuLyGiaoDien.ThongBao(Text, ThanhCong, true))
            {
                string NoiDung = string.Empty;
                if (_GiaoDichO.LoaiGiaoDich == 4)
                    NoiDung = string.Format("Xóa {0} GD với tổng giá hệ thống là {1} \r\n", lst.Count(), lst.Sum(w => w.GiaHeThong).ToString("#,###"));
                else
                    NoiDung = string.Format("Xóa {0} GD với tổng giá hoàn là {1} \r\n", lst.Count(), lst.Sum(w => w.GiaHoan).ToString("#,###"));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", _GiaoDichO.MaCho);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", _GiaoDichO.LoaiKhachHang);
                dic.Add("Ma", _GiaoDichO.IDKhachHang);
                new LichSuD().ThemMoi(dic);
                new DaiLyD().ChayLaiPhi(_GiaoDichO.NgayGD);
                DuLieu();
            }
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            //List<int> a = _ListGiaoDichO.Select(w => w.IDKhachHang).Distinct().ToList();
            //List<DaiLyO> dl = new DaiLyD().DuLieu(1);
            //foreach(int b in a)
            //{
            //    DevExpress.XtraPrinting.XlsxExportOptionsEx opt = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
            //    opt.CustomizeCell += op_CustomizeCell;
            //    opt.SheetName = "Bản CK";
            //    DaiLyO dla = dl.Where(w => w.ID.Equals(b)).ToList()[0];
            //    giaoDichOBindingSource.DataSource = null;
            //    giaoDichOBindingSource.DataSource = _ListGiaoDichO.Where(w => w.IDKhachHang.Equals(b)).ToList();
            //    string s = @"C:\Users\ICE Cold\Desktop\New folder (2)\"+ dla.Ten + ".xlsx";
            //    GVGD.ExportToXlsx(s, opt);
            //}    
            XuLyGiaoDien.ExportExcel(GCGD, GVGD, "ExGD-" + DateTime.Now.ToString("dd-MM-yyy"));
        }

        private void btnIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _GiaoDichO = GVGD.GetRow(GVGD.GetSelectedRows()[0]) as GiaoDichO;
                List<GiaoDichO> lst = _ListGiaoDichO.Where(w => w.MaCho.Equals(_GiaoDichO.MaCho) && w.LoaiGiaoDich.Equals(_GiaoDichO.LoaiGiaoDich) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang) && w.NgayGD.ToString("ddMMyyy").Equals(_GiaoDichO.NgayGD.ToString("ddMMyyy")) && w.NhaCungCap.Equals(_GiaoDichO.NhaCungCap) && w.TuyenBayDi.Equals(_GiaoDichO.TuyenBayDi)).ToList();
                frmInVe frm = new frmInVe(lst);
                frm.ShowDialog();
            }
            catch { }

        }
        #endregion

        #region Sự khiện bản 
        private void GVGD_DoubleClick(object sender, EventArgs e)
        {
            ChinhSua();
        }

        private void GVGD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                ChinhSua();
        }

        void ChinhSua()
        {
            _GiaoDichO = GVGD.GetRow(GVGD.GetSelectedRows()[0]) as GiaoDichO;

            List<GiaoDichO> lst = _ListGiaoDichO.Where(w => w.MaCho.Equals(_GiaoDichO.MaCho) && w.LoaiGiaoDich.Equals(_GiaoDichO.LoaiGiaoDich) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang) && w.NgayGD.ToString("ddMMyyy").Equals(_GiaoDichO.NgayGD.ToString("ddMMyyy")) && w.NhaCungCap.Equals(_GiaoDichO.NhaCungCap) && w.TuyenBayDi.Equals(_GiaoDichO.TuyenBayDi)).ToList();

            if (lst.Count > 1)
            {
                DialogResult dc = XtraMessageBox.Show("Bạn muốn sửa tất cả giao dịch cùng Mã Chỗ ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dc)
                {
                    case DialogResult.No:
                        lst = _ListGiaoDichO.Where(w => w.ID.Equals(_GiaoDichO.ID)).ToList();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }


            if (new List<int>() { 4, 13, 14 }.Contains(_GiaoDichO.LoaiGiaoDich))
            {
                frmVeThem frm = new frmVeThem(lst);
                frm.ShowDialog(ParentForm);
            }
            else
            {
                frmVeHoanThem frm2 = new frmVeHoanThem(lst);
                frm2.ShowDialog(ParentForm);
            }
        }
        #endregion
    }
}