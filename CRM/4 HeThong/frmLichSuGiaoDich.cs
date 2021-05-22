using DataAccessLayer;
using DevExpress.XtraEditors;
using System;

namespace CRM
{
    public partial class frmLichSu : DevExpress.XtraEditors.XtraForm
    {
        public frmLichSu()
        {
            InitializeComponent();
            ChonThoiGian = DuLieuTaoSan.MocThoiGian("NgayThucHien");
            DuLieu();
        }

        public frmLichSu(string code)
        {
            InitializeComponent();
            bar1.Visible = colMaCho.Visible = colFormName.Visible = false;
            lichSuGDOBindingSource.DataSource = new LichSuD().LayDanhSachTheoCode(code);
        }

        void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            lichSuGDOBindingSource.DataSource = new LichSuD().LayDanhSach(ChonThoiGian[idThoiGian], btnHeThong.Checked);
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        private void frmLichSu_Load(object sender, EventArgs e)
        {
            DSNhanVien.DataSource = new DaiLyD().NhanVien();
        }

        #region Biến
        string[] ChonThoiGian;
        int idThoiGian = 0;
        #endregion

        #region Sự kiện nút
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            idThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }

        #endregion

        private void btnHeThong_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCLS, GVLS, "ExLS-" + DateTime.Now.ToString("dd-MM-yyy"));
        }
    }
}