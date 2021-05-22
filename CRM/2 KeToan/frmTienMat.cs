using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmTienMat : DevExpress.XtraEditors.XtraForm
    {
        public frmTienMat()
        {
            InitializeComponent();
        }

        private void frmTienMat_Load(object sender, EventArgs e)
        {
            bdtpDen1.MinValue = DateTime.Now.AddDays(-30);
            bdtpDen1.MaxValue = DateTime.Now.AddDays(-1);
            bdtpDen12.EditValue = DateTime.Now.AddDays(-1);
            ibtnThemMoi.Visibility = DuLieuTaoSan.Q.TienMatThemSua ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnDel.Visibility = DuLieuTaoSan.Q.TienMatXoa ? BarItemVisibility.Always : BarItemVisibility.Never;
            LayDLNganHang();
            TaiLaiDuLieu();
            LayDLKhac();
            intStringBindingSource2.DataSource = DuLieuTaoSan.LoaiKhachHang_NganHang();
            DSNhanVien.DataSource = new DaiLyD().NhanVien();
        }

        #region Dữ liệu 
        public void TaiLaiDuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    CTV = string.Format("AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            else if (chk1.Checked)
                CTV = DuLieuTaoSan.MocThoiGian("NgayGD")[idThoiGian];
            else if (chk3.Checked && B != string.Empty)
                CTV = string.Format("AND MaCode = '{0}'", B);

            nhD.ChayLaiSD();
            cTNganHangOBindingSource.DataSource = new CTNganHangD().DuLieu(CTV, true);
            btnM.Caption = "Số dư: " + nhD.DuLieu(true)[0].SoDuCuoi.ToString("#,### VNĐ");
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        public void LayDLNganHang()
        {
            nganHangOBindingSource.DataSource = nhD.DuLieu(false);
        }

        public void LayDLKhac()
        {
            IntStringBindingSource.DataSource = DuLieuTaoSan.TrangThai_NganHang();
            IntStringBindingSource1.DataSource = DuLieuTaoSan.LoaiGiaoDich_NganHang_TatCa();
        }
        #endregion

        #region Biến
        string B = string.Empty;
        int idThoiGian = 0;
        string CTV = string.Empty;
        CTNganHangO cTNgan;
        NganHangD nhD = new NganHangD();
        List<CTNganHangO> _listCTNganHangO = new List<CTNganHangO>();
        #endregion

        #region Sự kiện nút
        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiDuLieu();
        }

        private void ibtnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNganHangCTThem(true).ShowDialog(this.ParentForm);
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

            cTNgan = (GVCTTM.GetRow(GVCTTM.GetSelectedRows()[0]) as CTNganHangO);
            CTNganHangD nh = new CTNganHangD();
            List<object> lstCtv = new List<object>();

            switch (cTNgan.LoaiGiaoDich)
            {

                case 24:
                case 23:
                    List<CTNganHangO> cTNganHangOs = new CTNganHangD().Dem($"WHERE MaLienKet = '{cTNgan.MaLienKet}'");
                    if (cTNganHangOs.Count == 2)
                    {
                        lstCtv.Add(cTNganHangOs[0].ID);
                        lstCtv.Add(cTNganHangOs[1].ID);
                    }
                    else
                    {
                        XuLyGiaoDien.Alert("Sai định dạng!", Form_Alert.enmType.Warning);
                        return;
                    }
                    break;
                default:
                    lstCtv.Add(cTNgan.ID);
                    break;
            }

            if (XuLyGiaoDien.ThongBao(Text, nh.XoaNhieu1Ban(lstCtv, "CTNGANHANG") > 0, true))
            {
                if (cTNgan.LoaiKhachHang == 1 || cTNgan.LoaiKhachHang == 2)
                    new DaiLyD().ChayLaiPhi(cTNgan.NgayHT);
                else if (cTNgan.LoaiKhachHang == 4 || cTNgan.LoaiKhachHang == 30)
                {
                    List<GiaoDichO> _GiaoDich = new GiaoDichD().DuLieuNganHang(cTNgan.IDGiaoDich);
                    List<Dictionary<string, object>> lstdic2 = new List<Dictionary<string, object>>();
                    List<string> CTV = new List<string>();
                    Dictionary<string, object> dic2 = new Dictionary<string, object>();
                    for (int i = 0; i < _GiaoDich.Count; i++)
                    {
                        GiaoDichO gd = _GiaoDich[i];
                        dic2 = new Dictionary<string, object>();
                        CTV.Add(string.Format("WHERE ID = {0}", gd.ID));
                        dic2.Add("Khoa", false);
                        lstdic2.Add(dic2);
                    }
                    new GiaoDichD().SuaNhieu1Ban(lstdic2, CTV);
                }
                new NganHangD().ChayLaiSD();

                string NoiDung = string.Format("Xóa GD Ngân Hàng : {0} VNĐ [{1}]", cTNgan.SoTien.ToString("#,###"), cTNgan.GhiChu);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", cTNgan.MaLienKet);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", cTNgan.LoaiKhachHang);
                dic.Add("Ma", cTNgan.MaDL);
                if (NoiDung.Length > 10)
                    new LichSuD().ThemMoi(dic);
                TaiLaiDuLieu();
            }
        }

        private void btnPri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVCTTM.RowCount > 0)
            {
                cTNgan = (GVCTTM.GetRow(GVCTTM.GetSelectedRows()[0]) as CTNganHangO);
                new frmInVe(cTNgan).ShowDialog();
            }
        }



        private void btnM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            nhD.ChayLaiSD();
            frmSoDuNganHang frmSoDu = new frmSoDuNganHang(1);
            frmSoDu.ShowDialog();
        }
        #endregion

        #region Sự khiện bản 
        private void gridCtNganHang_Click(object sender, EventArgs e)
        {
            if (GVCTTM.RowCount > 0)
                cTNgan = (GVCTTM.GetRow(GVCTTM.GetSelectedRows()[0]) as CTNganHangO);
        }
        private void grvGiaoDich_DoubleClick(object sender, EventArgs e)
        {
            if (DuLieuTaoSan.Q.TienMatThemSua)
            {
                cTNgan = (GVCTTM.GetRow(GVCTTM.GetSelectedRows()[0]) as CTNganHangO);
                int Ma = cTNgan.ID;
                if (cTNgan.LoaiGiaoDich == 23 || cTNgan.LoaiGiaoDich == 24)
                {
                    List<CTNganHangO> cTNganHangOs = _listCTNganHangO.Where(w => w.MaLienKet.Equals(cTNgan.MaLienKet)).ToList();
                    if (cTNganHangOs.Count == 2)
                    {
                        Ma = cTNgan.ID == cTNganHangOs[0].ID ? Ma : cTNganHangOs[0].ID;
                        Ma = cTNgan.ID == cTNganHangOs[1].ID ? Ma : cTNganHangOs[1].ID;
                        new frmNganHangCTThem(cTNgan, Ma).ShowDialog(ParentForm);
                    }
                    else
                        XuLyGiaoDien.Alert("Sai định dạng!", Form_Alert.enmType.Warning);
                }
                else
                    new frmNganHangCTThem(cTNgan, 0).ShowDialog(ParentForm);
            }
        }
        #endregion

        private void GVCTTM_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }
    }
}