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
            daiLyOBindingSource.DataSource = new D_DAILY().All();
            DuLieu();
        }

        #region CongCuTimKiem

        string[] _SV_MC = new string[] { };
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            string _Query = string.Empty;
            if (chk1.Checked)
                _Query = DuLieuTaoSan.ThoiGianRutGon("NgayGD")[_IDThoiGian];
            else if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    _Query = string.Format("AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk3.Checked && _SV_MC.Length > 0)
                _Query = string.Format("AND REPLACE(COALESCE(SoVeVN,''),' ','') in ('{0}')", String.Join("' ,'", _SV_MC));
            else if (chk4.Checked && _SV_MC.Length > 0)
                _Query = string.Format("AND REPLACE(COALESCE(MaCho,''),' ','') in ('{0}')", String.Join("' ,'", _SV_MC));

            if (_Query != string.Empty)
            {
                _ListGiaoDichO = new D_GIAODICH().DuLieu(string.Format("TheoDoi = 1 AND ({0}{1})", _Query.Substring(3), chkAll.Checked ? " or TinhCongNo = 0" : string.Empty), DuLieuTaoSan.Q.VeAdmin);
                giaoDichOBindingSource.DataSource = _ListGiaoDichO;
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        private void ecmbThoiGian_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _IDThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }

        private void bdtpDen_EditValueChanged(object sender, EventArgs e)
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

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barEditItem1.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            barMaCho.Enabled = chk4.Checked;
            barSoVe.Enabled = chk3.Checked;
            DuLieu();
        }
        #endregion

        #region Biến
        int _IDThoiGian = 2; //vị trí phần tử combobox
        D_GIAODICH _GiaoDichD = new D_GIAODICH();//Gọi xử lí dữ liệu
        O_GIAODICH _GiaoDichO = new O_GIAODICH();//Dữ liệu cần xử lí
        List<O_GIAODICH> _ListGiaoDichO = new List<O_GIAODICH>();//Dữ liệu chính dùng để lọc dữ liệu cần xử lí
        #endregion

        #region Giao diện
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                O_GIAODICH dl = View.GetRow(e.RowHandle) as O_GIAODICH;
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

        private void chkAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<object> lstCtv = new List<object>();

            _GiaoDichO = GVH.GetRow(GVH.GetSelectedRows()[0]) as O_GIAODICH;

            List<O_GIAODICH> lst = _ListGiaoDichO.Where(w => (w.SoVeVN ?? "").Equals((_GiaoDichO.SoVeVN ?? "")) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang)).ToList();

            O_KHOANGAY kn = new D_KHOANGAY().KiemTraNgayKhoa(_GiaoDichO.NgayGD);
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

            foreach (O_GIAODICH gdoz in lst)
            {
                lstCtv.Add(gdoz.ID);
            }

            if (XuLyGiaoDien.ThongBao(Text, _GiaoDichD.XoaNhieu1Ban(lstCtv) > 0, true))
            {
                if (_GiaoDichO.TinhCongNo)
                {
                    new D_DAILY().ChayLaiPhi(_GiaoDichO.NgayGD);
                    string NoiDung = string.Format("Xóa vé hoàn\r\n");
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("FormName", Text);
                    dic.Add("MaCho", _GiaoDichO.MaCho);
                    dic.Add("NoiDung", NoiDung);
                    dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                    dic.Add("LoaiKhachHang", _GiaoDichO.LoaiKhachHang);
                    dic.Add("Ma", _GiaoDichO.IDKhachHang);
                    if (NoiDung.Length > 10)
                        new D_LS_GIAODICH().ThemMoi(dic);
                }
                DuLieu();
            }
        }
        #endregion

        #region Sự khiện bản 
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _GiaoDichO = GVH.GetRow(GVH.GetSelectedRows()[0]) as O_GIAODICH;
            List<O_GIAODICH> lst = _ListGiaoDichO.Where(w => w.MaCho.Equals(_GiaoDichO.MaCho) && w.IDKhachHang.Equals(_GiaoDichO.IDKhachHang) && w.TinhCongNo.Equals(_GiaoDichO.TinhCongNo) && w.NgayGD.Date.Equals(_GiaoDichO.NgayGD.Date)).ToList();

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
        #endregion

        private void btnEx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCH, GVH, "ExH-" + DateTime.Now.ToString("dd-MM-yyy"));
        }
    }
}