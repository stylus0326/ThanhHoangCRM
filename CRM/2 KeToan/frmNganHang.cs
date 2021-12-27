using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNganHang : DevExpress.XtraEditors.XtraForm
    {
        RefreshHelper helper;
        public frmNganHang()
        {
            InitializeComponent();
            KeyPreview = true;
            ToRight.Click += ToRight_Click;
            ToLeft.Click += ToLeft_Click;
            sControl.SizeChanged += SControl_SizeChanged;
            sControl.SplitterMoved += SControl_SplitterMoved;
            sControl.LocationChanged += SControl_LocationChanged;
            KeyDown += Frm_KeyDown;
            helper = new RefreshHelper(GVCTNH, "id");
        }

        #region panel
        private void SControl_LocationChanged(object sender, EventArgs e)
        {
            int a = (sControl.Height - 80) / 2;
            ToRight.Location = new Point(sControl.Location.X, a + 56);
            ToLeft.Location = new Point(sControl.Location.X, a - 1);
        }

        private void Frm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && e.Alt)
            {
                ToLeft.PerformClick();
            }
            else if (e.KeyCode == Keys.Right && e.Alt)
            {
                ToRight.PerformClick();
            }
            else if (grpL.Visible && grpR.Visible)
            {
                if (e.KeyCode == Keys.Left && e.Control)
                    grpL.Width -= 5;
                else if (e.KeyCode == Keys.Right && e.Control)
                    grpL.Width += 5;
            }
        }
        private void ToLeft_Click(object sender, EventArgs e)
        {
            if (!grpR.Visible)
            {
                ToRight.Visible = grpR.Visible = true;
                sControl.Dock = grpL.Dock = DockStyle.Left;
                grpL.Width = toLeftW;
            }
            else
                ToLeft.Visible = grpL.Visible = false;
            ToRight.Location = new Point(sControl.Location.X, ToRight.Location.Y);
            ToLeft.Location = new Point(sControl.Location.X, ToLeft.Location.Y);
        }

        int toLeftW = 0;
        private void ToRight_Click(object sender, EventArgs e)
        {
            if (!grpL.Visible)
            {
                ToLeft.Visible = grpL.Visible = true;
            }
            else
            {
                toLeftW = grpL.Width;
                ToRight.Visible = grpR.Visible = false;
                grpL.Width = Width - sControl.Width;
                grpL.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom);
                grpL.Height = Height;
                sControl.Dock = DockStyle.Right;
            }

            ToRight.Location = new Point(sControl.Location.X, ToRight.Location.Y);
            ToLeft.Location = new Point(sControl.Location.X, ToLeft.Location.Y);
        }

        private void SControl_SizeChanged(object sender, EventArgs e)
        {
            int a = (sControl.Height - 80) / 2;
            ToRight.Location = new Point(sControl.Location.X, a + 56);
            ToLeft.Location = new Point(sControl.Location.X, a - 1);
        }

        private void SControl_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ToRight.Location = new Point(sControl.Location.X, ToRight.Location.Y);
            ToLeft.Location = new Point(sControl.Location.X, ToLeft.Location.Y);
        }


        #endregion

        private void frmNganHang_Load(object sender, EventArgs e)
        {
            int a = (sControl.Height - 80) / 2;
            ToRight.Location = new Point(sControl.Location.X, a + 56);
            ToLeft.Location = new Point(sControl.Location.X, a - 1);

            bdtpDen1.MinValue = DateTime.Now.AddDays(-90);
            bdtpDen1.MaxValue = DateTime.Now.AddDays(-1);
            bdtpDen12.EditValue = DateTime.Now.AddDays(-1);
            btnThemMoi.Visibility = btnAdd.Visibility = ClsDuLieu.Quyen.NganHangThemSua ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnDel.Visibility = ClsDuLieu.Quyen.NganHangXoa ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnXuat.Visibility = ClsDuLieu.Quyen.NganHangExcel ? BarItemVisibility.Always : BarItemVisibility.Never;
            LayDLNganHang();
            TaiLaiDuLieu();
            LayDLKhac();
            DSNhanVien.DataSource = new D_DAILY().NhanVien();
        }

        #region Dữ liệu 
        public void TaiLaiDuLieu(bool reSave = false)
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            if (reSave)
                helper.SaveViewInfo();

            if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    CTV = string.Format("AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk1.Checked)
                CTV = DuLieuTaoSan.MocThoiGian("NgayGD")[idThoiGian];
            else if (chk3.Checked && B != string.Empty)
                CTV = string.Format("AND MaCode like '%{0}%'", B);

            if (!chk3.Checked)
            {
                if (chkKLT.Checked)
                    CTV += string.Format(" OR LoaiGiaoDich = 8");
                if (!chkNganHang.Checked)
                    CTV += " AND NganHangID = " + kh.ID;
            }

            if (iCTKN.Checked)
                _listCTNganHangO = new D_CTNGANHANG().DuLieu(CTV);
            else
                _listCTNganHangO = new D_CTNGANHANG().DuLieu(CTV, false);

            cTNganHangOBindingSource.DataSource = _listCTNganHangO;

            if (reSave)
                helper.LoadViewInfo();
            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
        }


        public void LayDLNganHang()
        {
            if (iCTKN.Checked)
                nganHangOBindingSource.DataSource = nhD.DuLieu();
            else
                nganHangOBindingSource.DataSource = nhD.DuLieu(false);
            rBank.DataSource = nhD.All();
            GVNH.BestFitColumns();
            GVNH.ExpandAllGroups();
        }

        public void LayDLKhac()
        {
            IntStringBindingSource.DataSource = DuLieuTaoSan.TrangThai_NganHang();
            loaiGiaoDichOBindingSource.DataSource = new D_LOAIGIAODICH().DuLieu();
            intStringBindingSource2.DataSource = DuLieuTaoSan.LoaiKhachHang_NganHang();
        }
        #endregion

        #region Biến 
        int idThoiGian = 0;
        string CTV = string.Empty;
        O_NGANHANG kh;
        string B = string.Empty;
        O_CTNGANHANG cTNgan;
        D_NGANHANG nhD = new D_NGANHANG();
        List<O_CTNGANHANG> _listCTNganHangO = new List<O_CTNGANHANG>();
        #endregion

        #region Giao diện

        private void grvCtNganHang_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    O_CTNGANHANG dl = View.GetRow(e.RowHandle) as O_CTNGANHANG;
                    if (e.Column.FieldName == "TrangThaiID")
                        if (dl.TrangThaiID)
                            e.Appearance.BackColor = Color.Green;
                        else
                            e.Appearance.BackColor = Color.Crimson;
                    if (e.Column.FieldName == "LoaiGiaoDich")
                        if (dl.LoaiGiaoDich == 8)
                            e.Appearance.BackColor = Color.Silver;
                        else if (dl.LoaiGiaoDich == 12)
                            e.Appearance.BackColor = Color.Gold;
                }
            }
            catch { }
        }
        #endregion

        #region Sự kiện nút
        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiDuLieu(true);
        }

        private void ibtnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNHCTThem(false).ShowDialog(this.ParentForm);
        }

        private void chk1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            txtC.Enabled = chk3.Checked;
            TaiLaiDuLieu();

            if (chk1.Checked)
                bcmbThoiGian.Links[0].Focus();
            else if (chk2.Checked)
                bdtpTu.Links[0].Focus();
            else if (chk3.Checked)
                txtC.Links[0].Focus();
        }

        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit cmb = sender as ComboBoxEdit;
            idThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            TaiLaiDuLieu();
        }

        private void bdtpTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            TaiLaiDuLieu();
        }


        private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            B = (sender as TextEdit).Text;
            if ((e.KeyCode == Keys.Enter) && B.Length > 4)
                TaiLaiDuLieu();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            cTNgan = (GVCTNH.GetRow(GVCTNH.GetSelectedRows()[0]) as O_CTNGANHANG);
            D_CTNGANHANG nh = new D_CTNGANHANG();

            List<object> lstCtv = new List<object>();

            if (cTNgan.LoaiKhachHang == 7)
            {
                List<O_CTNGANHANG> cTNganHangOs = new D_CTNGANHANG().Dem($"WHERE MaLienKet = '{cTNgan.MaLienKet}'");
                if (cTNganHangOs.Count == 2)
                {
                    lstCtv.Add(cTNganHangOs[0].ID);
                    lstCtv.Add(cTNganHangOs[1].ID);
                }
                else
                {
                    XuLyGiaoDien.Alert("Sai định dạng", Form_Alert.enmType.Info);
                    return;
                }
            }
            else
            {
                lstCtv.Add(cTNgan.ID);
                new D_BAOCAOCTNH().Xoa(cTNgan.ID, "WHERE IDCTNganHang = {0}");
            }

            if (XuLyGiaoDien.ThongBao(Text, nh.XoaNhieu1Ban(lstCtv, "CTNGANHANG") > 0, true))
            {
                if (cTNgan.LoaiKhachHang == 1 || cTNgan.LoaiKhachHang == 2)
                    new D_DAILY().ChayLaiPhi(cTNgan.NgayHT);
                else if (cTNgan.LoaiKhachHang == 4 || cTNgan.LoaiKhachHang == 30)
                {
                    List<O_GIAODICH> _GiaoDich = new D_GIAODICH().DuLieuNganHang(cTNgan.IDGiaoDich);
                    List<Dictionary<string, object>> lstdic2 = new List<Dictionary<string, object>>();
                    List<string> CTV = new List<string>();
                    Dictionary<string, object> dic2 = new Dictionary<string, object>();
                    for (int i = 0; i < _GiaoDich.Count; i++)
                    {
                        O_GIAODICH gd = _GiaoDich[i];
                        dic2 = new Dictionary<string, object>();
                        CTV.Add(string.Format("WHERE ID = {0}", gd.ID));
                        dic2.Add("Khoa", false);
                        lstdic2.Add(dic2);
                    }
                    new D_GIAODICH().SuaNhieu1Ban(lstdic2, CTV);
                }
                nhD.ChayLaiSD();

                string NoiDung = string.Format("Xóa GD Ngân Hàng : {0} VNĐ [{1}]", cTNgan.SoTien.ToString("#,###"), cTNgan.GhiChu);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", cTNgan.MaLienKet);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", ClsDuLieu.NhanVien.ID);
                dic.Add("LoaiKhachHang", cTNgan.LoaiKhachHang);
                dic.Add("Ma", cTNgan.MaDL);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
                TaiLaiDuLieu();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmSoSanh().ShowDialog(this.ParentForm);
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCCTNH, GVCTNH, "ExNH-" + DateTime.Now.ToString("dd-MM-yyy"));
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            nhD.ChayLaiSD();
            LayDLNganHang();

            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNganHangThem().ShowDialog(ParentForm);
        }
        #endregion

        #region Sự khiện bản 
        private void gridCtNganHang_Click(object sender, EventArgs e)
        {
            if (GVCTNH.RowCount > 0)
                cTNgan = (GVCTNH.GetRow(GVCTNH.GetSelectedRows()[0]) as O_CTNGANHANG);
        }

        private void GVCTNH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                ChinhSua();
        }

        private void grvGiaoDich_DoubleClick(object sender, EventArgs e)
        {
            ChinhSua();
        }

        void ChinhSua()
        {
            if (ClsDuLieu.Quyen.NganHangThemSua)
            {
                cTNgan = (GVCTNH.GetRow(GVCTNH.GetSelectedRows()[0]) as O_CTNGANHANG);
                int Ma = cTNgan.ID;
                if (cTNgan.LoaiGiaoDich == 23 || cTNgan.LoaiGiaoDich == 24)
                {
                    List<O_CTNGANHANG> cTNganHangOs = _listCTNganHangO.Where(w => (w.MaLienKet ?? string.Empty).Equals(cTNgan.MaLienKet)).ToList();
                    if (cTNganHangOs.Count == 2)
                    {
                        Ma = cTNgan.ID == cTNganHangOs[0].ID ? Ma : cTNganHangOs[0].ID;
                        Ma = cTNgan.ID == cTNganHangOs[1].ID ? Ma : cTNganHangOs[1].ID;
                        new frmNHCTThem(cTNgan, Ma).ShowDialog(ParentForm);
                    }
                    else
                        XuLyGiaoDien.Alert("Sai định dạng", Form_Alert.enmType.Info);
                }
                else
                    new frmNHCTThem(cTNgan, 0).ShowDialog(ParentForm);
            }
        }

        private void grvNganHang_DoubleClick(object sender, EventArgs e)
        {
            if (ClsDuLieu.Quyen.NganHangThemSua)
            {
                kh = (GVNH.GetRow(GVNH.GetSelectedRows()[0]) as O_NGANHANG);
                if (kh != null)
                    new frmNganHangThem(kh).ShowDialog(ParentForm);
            }
        }

        private void grvNganHang_Click(object sender, EventArgs e)
        {
            kh = (GVNH.GetRow(GVNH.GetSelectedRows()[0]) as O_NGANHANG);
            if (!chkNganHang.Checked)
                TaiLaiDuLieu();
        }
        #endregion

        private void btnNapSD_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (kh == null)
                return;
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            nhD.ChayLaiSD();
            LayDLNganHang();

            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
        }

        private void GVNH_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                O_NGANHANG dl = View.GetRow(e.RowHandle) as O_NGANHANG;
                switch (e.Column.FieldName)
                {
                    case "SoDuCuoi":
                        if (dl.SoDu != dl.SoDuCuoi)
                            e.Appearance.BackColor = Color.FromArgb(169, 209, 217);
                        break;
                }
            }
        }

        private void iCTKN_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSoDu_ItemClick(object sender, ItemClickEventArgs e)
        {
            kh = (O_NGANHANG)GVNH.GetFocusedRow();
            frmSoDuNganHang frm = new frmSoDuNganHang(kh.ID);
            frm.ShowDialog();
        }

        private void barToggleSwitchItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            kh = (O_NGANHANG)GVNH.GetFocusedRow();
            if (kh != null)
                TaiLaiDuLieu();
        }

        private void barToggleSwitchItem1_CheckedChanged_1(object sender, ItemClickEventArgs e)
        {
            if (iCTKN.Checked)
            {
                colLoaiKhachHang.GroupIndex = 0;
                colLoaiGiaoDich.GroupIndex = 1;
            }
            else
                colLoaiKhachHang.GroupIndex = colLoaiGiaoDich.GroupIndex = -1;
            LayDLNganHang();
            TaiLaiDuLieu();
        }

        private void btnNganHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmNganHangChinh().ShowDialog();
        }
    }
}