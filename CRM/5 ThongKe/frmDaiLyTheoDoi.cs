﻿using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmDaiLyTheoDoi : DevExpress.XtraEditors.XtraForm
    {
        public frmDaiLyTheoDoi()
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

                _lstTheoDoi = new TheoDoiD().DuLieu((DateTime)bdtpTu.EditValue, (DateTime)bdtpDen.EditValue, 1, barCheckItem1.Checked);

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

        private void frmDaiLyTheoDoi_Load(object sender, EventArgs e)
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
            XuLyGiaoDien.ExportExcel(gridControl1, bandedGridView1, "ExDLTD-" + DateTime.Now.ToString("dd-MM-yyy"));
        }
    }
}