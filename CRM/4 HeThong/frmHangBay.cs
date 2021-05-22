using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmHangBay : DevExpress.XtraEditors.XtraForm
    {
        public frmHangBay()
        {
            InitializeComponent();
        }

        private void frmHangBay_Load(object sender, EventArgs e)
        {
            DuLieu();
            XuLyGiaoDien.OpenForm(this);
            intStringBindingSource.DataSource = DuLieuTaoSan.LoaiPhi(false);
        }

        #region Dữ liệu 
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            hangBindingSource.DataSource = new HangBayD().DuLieu();
            _lstNCCO = new NCCD().DuLieu();
            nCCOBindingSource.DataSource = _lstNCCO;
            nCCGDOBindingSource.DataSource = new NCCGDD().DuLieu();
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        NCCGDO _NCCGDO = new NCCGDO();
        HangBayO _HangBay = new HangBayO();
        List<NCCO> _lstNCCO = new List<NCCO>();
        NCCO _NCC = new NCCO();
        #endregion

        #region Sự kiện nút
        private void btnLoadHB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void GVHB_DoubleClick(object sender, EventArgs e)
        {
            _HangBay = GVHB.GetRow(GVHB.GetSelectedRows()[0]) as HangBayO;
            if (_HangBay != null)
                new frmHangBayThem(_HangBay).ShowDialog(this);
        }

        private void GVNCC_DoubleClick(object sender, EventArgs e)
        {
            if (GVNCC.GetSelectedRows().Count() > 0)
            {
                _NCC = GVNCC.GetRow(GVNCC.GetSelectedRows()[0]) as NCCO;
                if (_NCC != null)
                    new frmNCCThem(_NCC).ShowDialog(this);
            }
        }
        #endregion


        private void GVNCCGD_DoubleClick(object sender, EventArgs e)
        {
            if (GVNCCGD.GetSelectedRows().Count() > 0)
            {
                _NCCGDO = GVNCCGD.GetRow(GVNCCGD.GetSelectedRows()[0]) as NCCGDO;
                if (_NCCGDO != null)
                    new frmNCCGD(_NCCGDO).ShowDialog(this);
            }
        }

        private void grpThem_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            new frmNCCGD().ShowDialog(this);
        }

        private void GrNCC_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            new frmNCCThem().ShowDialog(this);
        }

        private void GrHang_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            new frmHangBayThem().ShowDialog(this);
        }
    }
}