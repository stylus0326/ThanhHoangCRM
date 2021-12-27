using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmCTVTheoDoi : DevExpress.XtraEditors.XtraForm
    {
        public frmCTVTheoDoi()
        {
            InitializeComponent();
        }

        List<O_THEODOIHOAN> _lstTheoDoi = new List<O_THEODOIHOAN>();
        public void TaiLaiDuLieu()
        {
            if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
            {
                if (!ClsChucNang.wait.IsSplashFormVisible)
                    ClsChucNang.wait.ShowWaitForm();

                _lstTheoDoi = new D_THEODOIHOAN().DuLieu((DateTime)bdtpTu.EditValue, (DateTime)bdtpDen.EditValue, 2, barCheckItem1.Checked);

                theoDoiOBindingSource.DataSource = _lstTheoDoi;

                if (ClsChucNang.wait.IsSplashFormVisible)
                    ClsChucNang.wait.CloseWaitForm();
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

        private void frmCTVTheoDoi_Load(object sender, EventArgs e)
        {
            bdtpTu.EditValue = bdtpDen.EditValue = DateTime.Now.AddDays(-1);
        }

        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiDuLieu();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            string ret = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "ID").ToString();
            new frmCongNoPhu(ret, (DateTime)bdtpTu.EditValue, (DateTime)bdtpDen.EditValue).ShowDialog();
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiDuLieu();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(gridControl1, bandedGridView1, "ExCTVTD-" + DateTime.Now.ToString("dd-MM-yyy"));
        }
    }
}