using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmNHTheoDoi : DevExpress.XtraEditors.XtraForm
    {
        public frmNHTheoDoi()
        {
            InitializeComponent();
        }

        List<TheoDoiO> _lstTheoDoi = new List<TheoDoiO>();
        public void TaiLaiDuLieu()
        {
            if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
            {
                if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.ShowWaitForm();

                _lstTheoDoi = new TheoDoiD().DuLieuNH((DateTime)bdtpTu.EditValue, (DateTime)bdtpDen.EditValue, barCheckItem1.Checked);

                theoDoiOBindingSource.DataSource = _lstTheoDoi;

                if (XuLyGiaoDien.wait.IsSplashFormVisible)
                    XuLyGiaoDien.wait.CloseWaitForm();
            }
        }

        private void bdtpTu_EditValueChanged(object sender, EventArgs e)
        {
            TaiLaiDuLieu();
        }

        private void chk2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiDuLieu();
        }

        private void frmNHTheoDoi_Load(object sender, EventArgs e)
        {
            bdtpTu.EditValue = bdtpDen.EditValue = DateTime.Now.AddDays(-1);
        }

        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new SoDu_NganHangD().ChayLaiSD();
            TaiLaiDuLieu();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            string ret = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "ID").ToString();
            new frmNganHangChiTiet((DateTime)bdtpTu.EditValue, (DateTime)bdtpDen.EditValue, ret).ShowDialog();
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiDuLieu();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(gridControl1, bandedGridView1, "ExNHTD-" + DateTime.Now.ToString("dd-MM-yyy"));
        }
    }
}