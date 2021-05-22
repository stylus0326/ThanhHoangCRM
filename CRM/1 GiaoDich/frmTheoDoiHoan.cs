using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmTheoDoiHoan : XtraForm
    {
        public frmTheoDoiHoan()
        {
            InitializeComponent();
        }

        private void frmTheoDoiHoan_Load(object sender, EventArgs e)
        {
            _GiaoDichO.TheoDoi = true;
            btnAdd.Visibility = DuLieuTaoSan.Q.TheoDoiHoanThemSua ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnDel.Visibility = DuLieuTaoSan.Q.TheoDoiHoanXoa ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            loaiKhachOBindingSource.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();
            daiLyOBindingSource.DataSource = new DaiLyD().All();
            DuLieu();
        }

        #region Dữ liệu 
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            string query = string.Empty;
            if (chk1.Checked)
                query = DuLieuTaoSan.ThoiGianRutGon("NgayGD")[idThoiGian];
            else if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    query += string.Format("AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk3.Checked && _Bien != string.Empty)
                query = string.Format("AND SoVeVN = '{0}'", _Bien);
            else if (chk4.Checked && _Bien != string.Empty)
                query = string.Format("AND MaCho = '{0}'", _Bien);
            if (query != string.Empty)
            {
                _ListGiaoDichO = new GiaoDichD().DuLieu(string.Format("TheoDoi = 1 AND ({0}{1})", query.Substring(3), chkAll.Checked ? " or TinhCongNo = 0" : string.Empty), DuLieuTaoSan.Q.VeAdmin);
                //TinhCongNo = 0
                giaoDichOBindingSource.DataSource = _ListGiaoDichO;
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        int idThoiGian = 2; //vị trí phần tử combobox
        string _Bien = string.Empty; //Lưu Mã chỗ và số vé
        GiaoDichD _GiaoDichD = new GiaoDichD();//Gọi xử lí dữ liệu
        GiaoDichO _GiaoDichO = new GiaoDichO();//Dữ liệu cần xử lí
        List<GiaoDichO> _ListGiaoDichO = new List<GiaoDichO>();//Dữ liệu chính dùng để lọc dữ liệu cần xử lí
        #endregion

        #region Giao diện
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GiaoDichO dl = View.GetRow(e.RowHandle) as GiaoDichO;
                if (e.Column.FieldName == "TinhCongNo")
                    if (dl.TinhCongNo)
                        e.Appearance.BackColor = Color.Green;
                    else
                        e.Appearance.BackColor = Color.Crimson;
            }
        }
        #endregion

        #region Sự kiện nút
        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmVeHoanThem().ShowDialog(this.ParentForm);
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barEditItem1.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            txtMC.Enabled = chk4.Checked;
            txtSV.Enabled = chk3.Checked;
            DuLieu();

            if (chk2.Checked)
                bdtpTu.Links[0].Focus();
            else if (chk3.Checked)
                txtSV.Links[0].Focus();
            else if (chk4.Checked)
                txtMC.Links[0].Focus();
        }

        private void ecmbThoiGian_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            idThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }

        private void bdtpDen_EditValueChanged(object sender, EventArgs e)
        {
            DuLieu();
        }

        private void aSoVe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            _Bien = (sender as TextEdit).Text;
            if ((e.KeyCode == Keys.Enter) && _Bien.Length > 4)
                DuLieu();
        }

        private void aMaCho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            _Bien = (sender as TextEdit).Text;
            if ((e.KeyCode == Keys.Enter) && _Bien.Length > 4)
                DuLieu();
        }

        private void chkAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<object> lstCtv = new List<object>();

            _GiaoDichO = GVH.GetRow(GVH.GetSelectedRows()[0]) as GiaoDichO;

            List<GiaoDichO> lst = _ListGiaoDichO.Where(w => w.SoVeVN.Equals(_GiaoDichO.SoVeVN) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang)).ToList();

            KhoaNgayO kn = new KhoaNgayD().KiemTraNgayKhoa(_GiaoDichO.NgayGD);
            if (_GiaoDichO.TinhCongNo)
            {
                if (!DuLieuTaoSan.Q.TheoDoiHoanAdmin)
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
            }

            if (lst.Count > 1)
            {
                DialogResult dc = XtraMessageBox.Show("Bạn muốn xóa tất cả giao dịch cùng Mã Chỗ ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dc)
                {
                    case DialogResult.No:
                        lst = _ListGiaoDichO.Where(w => w.ID.Equals(_GiaoDichO.ID)).ToList();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            foreach (GiaoDichO gdoz in lst)
            {
                lstCtv.Add(gdoz.ID);
            }

            if (XuLyGiaoDien.ThongBao(Text, _GiaoDichD.XoaNhieu1Ban(lstCtv) > 0, true))
            {
                if (_GiaoDichO.TinhCongNo)
                {
                    new DaiLyD().ChayLaiPhi(_GiaoDichO.NgayGD);
                    string NoiDung = string.Format("Xóa vé hoàn\r\n");
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("FormName", Text);
                    dic.Add("MaCho", _GiaoDichO.MaCho);
                    dic.Add("NoiDung", NoiDung);
                    dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                    dic.Add("LoaiKhachHang", _GiaoDichO.LoaiKhachHang);
                    dic.Add("Ma", _GiaoDichO.IDKhachHang);
                    if (NoiDung.Length > 10)
                        new LichSuD().ThemMoi(dic);
                }
                DuLieu();
            }
        }
        #endregion

        #region Sự khiện bản 
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _GiaoDichO = GVH.GetRow(GVH.GetSelectedRows()[0]) as GiaoDichO;
            List<GiaoDichO> lst = _ListGiaoDichO.Where(w => w.MaCho.Equals(_GiaoDichO.MaCho) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang) && w.TinhCongNo.Equals(_GiaoDichO.TinhCongNo) && w.NgayGD.Date.Equals(_GiaoDichO.NgayGD.Date)).ToList();

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

            new frmVeHoanThem(lst).ShowDialog(this);
        }

        private void GVH_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }
        #endregion

        private void btnEx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCH, GVH, "ExH-" + DateTime.Now.ToString("dd-MM-yyy"));
        }
    }
}