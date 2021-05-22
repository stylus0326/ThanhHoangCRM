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
    public partial class frmKhachSan : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachSan()
        {
            InitializeComponent();
        }

        #region Dữ liệu 
        private void frmKhachSan_Load(object sender, EventArgs e)
        {
            btnExportExcel.Visibility = DuLieuTaoSan.Q.VeExcel ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnThem.Visibility = DuLieuTaoSan.Q.VeThemSua ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnXoa.Visibility = DuLieuTaoSan.Q.VeXoa ? BarItemVisibility.Always : BarItemVisibility.Never;

            nganHangOBindingSource.DataSource = new D_NGANHANG().All();
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu(false, true);
            DuLieu();
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            nganHangOBindingSource.DataSource = new D_NGANHANG().All();
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu(false, true);
            DuLieu();
        }

        #endregion

        #region CongCuTimKiem
        string[] _SV_MC = new string[] { };
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();

            _index = GVGD.GetFocusedDataSourceRowIndex() - 10;
            _Query = "";

            if (chk1.Checked)
                _Query += "WHERE " + DuLieuTaoSan.MocThoiGian()[_IDThoiGian].Substring(4);
            else if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    _Query = string.Format("WHERE (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk4.Checked && _SV_MC.Length > 0)
                _Query += string.Format("WHERE REPLACE(COALESCE(Booking,''),' ','') in ('{0}')", String.Join("' ,'", _SV_MC));

            if (_Query != "")
            {
                khachHangOBindingSource.DataSource = DaiLyD.All();
                __ListKhachSanO = new D_KHACHSAN().DuLieu(_Query);
                khachSanOBindingSource.DataSource = __ListKhachSanO;
            }

            Size textSize = TextRenderer.MeasureText(__ListKhachSanO.Count.ToString(), new Font("Tahoma", 9, FontStyle.Regular));
            GVGD.IndicatorWidth = textSize.Width + 5;
            GVGD.FocusedRowHandle = _index;

            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion


        #region Biến
        int _index = 0;
        string _Query = "";
        D_DAILY DaiLyD = new D_DAILY();
        List<O_KHACHSAN> __ListKhachSanO = new List<O_KHACHSAN>();
        int _IDThoiGian = 0;
        D_KHACHSAN _KhachSanD = new D_KHACHSAN();
        O_KHACHSAN _KhachSanO = new O_KHACHSAN();

        #endregion

        #region Giao diện

        private void CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpDen.Enabled = bdtpTu.Enabled = chk2.Checked;
            barMaCho.Enabled = chk4.Checked;
            DuLieu();
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

        private void aMaCho_Leave(object sender, EventArgs e)
        {
            string[] BB = _SV_MC;
            _SV_MC = (sender as MemoExEdit).Text.Replace(" ", "").Replace("\r\n", "|").Split('|').ToArray();
            _SV_MC = _SV_MC.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (String.Join("' ,'", BB) != String.Join("' ,'", _SV_MC))
                DuLieu();
        }

        #endregion

        #region Sự kiện nút

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKhachSanThem frm = new frmKhachSanThem();
            frm.ShowDialog(ParentForm);
        }


        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _KhachSanO = GVGD.GetRow(GVGD.GetSelectedRows()[0]) as O_KHACHSAN;
            List<object> lstCtv = new List<object>();
            List<O_KHACHSAN> lst = __ListKhachSanO.Where(w => w.MaCho.Equals(_KhachSanO.MaCho) && w.IDKhachHang.Equals(_KhachSanO.IDKhachHang) && w.NgayGD.ToString("ddMMyyy").Equals(_KhachSanO.NgayGD.ToString("ddMMyyy"))).ToList();

            bool ThanhCong = false;
            if (lst.Count == 1)
            {
                DialogResult dc = XtraMessageBox.Show("Bạn muốn xóa giao dịch ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dc)
                {
                    case DialogResult.Yes:
                        ThanhCong = _KhachSanD.Xoa(_KhachSanO.ID) > 0;
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
                        foreach (O_KHACHSAN gdoz in lst)
                        {
                            lstCtv.Add(gdoz.ID);
                        }
                        ThanhCong = _KhachSanD.XoaNhieu1Ban(lstCtv) > 0;
                        break;
                    case DialogResult.No:
                        ThanhCong = _KhachSanD.Xoa(_KhachSanO.ID) > 0;
                        break;
                    default:
                        return;
                }
            }

            if (XuLyGiaoDien.ThongBao(Text, ThanhCong, true))
            {
                string NoiDung = string.Empty;
                NoiDung = string.Format("Xóa {0} GD với tổng giá hệ thống là {1} \r\n", lst.Count(), lst.Sum(w => w.GiaHeThong).ToString("#,###"));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", _KhachSanO.MaCho);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 1);
                dic.Add("Ma", _KhachSanO.IDKhachHang);
                new D_LS_GIAODICH().ThemMoi(dic);
                new D_DAILY().ChayLaiPhi(_KhachSanO.NgayGD);
                DuLieu();
            }
        }

        private void btnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCGD, GVGD, "ExKS-" + DateTime.Now.ToString("dd-MM-yyy"));
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
            _KhachSanO = GVGD.GetRow(GVGD.GetSelectedRows()[0]) as O_KHACHSAN;
            _index = GVGD.GetFocusedDataSourceRowIndex();

            List<O_KHACHSAN> lst = __ListKhachSanO.Where(w => w.MaCho.Equals(_KhachSanO.MaCho) && w.IDKhachHang.Equals(_KhachSanO.IDKhachHang) && w.NgayGD.ToString("ddMMyyy").Equals(_KhachSanO.NgayGD.ToString("ddMMyyy"))).ToList();

            if (lst.Count > 1)
            {
                DialogResult dc = XtraMessageBox.Show("Bạn muốn sửa tất cả giao dịch cùng Mã Chỗ ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dc)
                {
                    case DialogResult.No:
                        lst = __ListKhachSanO.Where(w => w.ID.Equals(_KhachSanO.ID)).ToList();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            new frmKhachSanThem(lst).ShowDialog(this);
        }
        #endregion

        private void GVGD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if("NgayBaoLuu SoTienBaoLuu".Contains(e.Column.FieldName))
            {
                if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    if (int.Parse((view.GetListSourceRowCellValue(e.ListSourceRowIndex, "SoTienBaoLuu") ?? 0).ToString()) == 0)
                        e.DisplayText = string.Empty;
                }
            }
        }
    }
}