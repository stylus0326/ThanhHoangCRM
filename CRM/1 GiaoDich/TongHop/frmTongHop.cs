using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmTongHop : XtraForm
    {
        public frmTongHop()
        {
            InitializeComponent();
        }

        private void frmTongHop_Load(object sender, EventArgs e)
        {
            loaiGiaoDichOBindingSource.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve_All(-1);
            DSLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_GiaoDich();
            daiLyOBindingSource.DataSource = new DaiLyD().All();
            btn2.Visibility = DuLieuTaoSan.Q.Lv2KhacAdmin ? BarItemVisibility.Always : BarItemVisibility.Never;
            btn4.Visibility = DuLieuTaoSan.Q.KhacThemSua ? BarItemVisibility.Always : BarItemVisibility.Never;
            NapDatCho();
        }

        #region Dữ liệu 
        public void NapDatCho()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            string query = "LoaiGiaoDich in (0,1,5,6,7,10,11,12)";
            if (query.Length > 0)
            {
                if (chk2.Checked)
                {
                    if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    {
                        query = string.Format("({2}) AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"), query);
                        lstGDDC = new GiaoDichD().DuLieu(query, DuLieuTaoSan.Q.VeAdmin);
                    }
                }
                else if (chk1.Checked)
                {
                    query = string.Format("({0}) {1}", query, DuLieuTaoSan.ThoiGianRutGon("NgayGD")[idThoiGian]);
                    lstGDDC = new GiaoDichD().DuLieu(query, DuLieuTaoSan.Q.VeAdmin);
                }
                giaoDichOBindingSource.DataSource = lstGDDC;
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        List<GiaoDichO> lstGDDC = new List<GiaoDichO>();
        int idThoiGian = 0;
        #endregion

        #region Giao diện
        #endregion

        #region Sự kiện nút

        private void btnLoadDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            NapDatCho();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmNo3Ngay().ShowDialog(ParentForm);
        }
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmTongHopThem().ShowDialog(ParentForm);
        }

        private void btnXDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            GiaoDichO GD = (GVDC.GetRow(GVDC.GetSelectedRows()[0]) as GiaoDichO);

            switch (GD.LoaiGiaoDich)
            {
                case 1:
                case 0:
                    if (!DuLieuTaoSan.Q.KhacXoa)
                        return;
                    break;
                default:
                    if (!DuLieuTaoSan.Q.KhacAdminXoa)
                        return;
                    break;

            }

            if (XuLyGiaoDien.ThongBao("giao dịch", new GiaoDichD().Xoa(GD.ID) > 0, true))
            {
                string NoiDung = string.Format("Xóa GD ", GD.GhiChu);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", GD.MaCho);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", GD.LoaiKhachHang);
                dic.Add("Ma", GD.IDKhachHang);
                new LichSuD().ThemMoi(dic);
                NapDatCho();
            }
            else
                XuLyGiaoDien.Alert("Xóa không thành công", Form_Alert.enmType.Error);
        }

        private void barCheckItem3_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            NapDatCho();
            if (chk1.Checked)
                bcmbThoiGian.Links[0].Focus();
            else if (chk2.Checked)
                bdtpTu.Links[0].Focus();
        }

        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            idThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            NapDatCho();
        }

        private void rdptTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            NapDatCho();
        }

        #endregion

        #region Sự khiện bản 
        private void grvDatCho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                new frmTongHopThem((GVDC.GetRow(GVDC.GetSelectedRows()[0]) as GiaoDichO)).ShowDialog(ParentForm);
        }
        private void grvDatCho_DoubleClick(object sender, EventArgs e)
        {
            GiaoDichO giaoDichO = (GVDC.GetRow(GVDC.GetSelectedRows()[0]) as GiaoDichO);
            if (giaoDichO.LoaiGiaoDich != 10)
                new frmTongHopThem(giaoDichO).ShowDialog(ParentForm);
        }
        #endregion

    }
}