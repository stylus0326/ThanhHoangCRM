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
            ClsChucNang.OpenForm(this);
            intStringBindingSource.DataSource = DuLieuTaoSan.LoaiPhi(false);
        }

        #region Dữ liệu 
        public void DuLieu()
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            _NCCD.ChayLaiSD();
            hangBindingSource.DataSource = new D_HANGBAY().DuLieu();
            _lstNCCO = _NCCD.DuLieu(true);
            nCCOBindingSource.DataSource = _lstNCCO;
            nCCGDOBindingSource.DataSource = new D_NHACUNGCAP_GIAODICHPHATSINH().DuLieu();
            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        O_NHACUNGCAP_GIAODICHPHATSINH _NCCGDO = new O_NHACUNGCAP_GIAODICHPHATSINH();
        O_HANGBAY _HangBay = new O_HANGBAY();
        List<O_NHACUNGCAP> _lstNCCO = new List<O_NHACUNGCAP>();
        O_NHACUNGCAP _NCC = new O_NHACUNGCAP();
        D_NHACUNGCAP _NCCD = new D_NHACUNGCAP();
        #endregion

        #region Sự kiện nút
        private void btnLoadHB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void GVHB_DoubleClick(object sender, EventArgs e)
        {
            _HangBay = GVHB.GetRow(GVHB.GetSelectedRows()[0]) as O_HANGBAY;
            if (_HangBay != null)
                new frmHangBayThem(_HangBay).ShowDialog(this);
        }

        private void GVNCC_DoubleClick(object sender, EventArgs e)
        {
            if (GVNCC.GetSelectedRows().Count() > 0)
            {
                _NCC = GVNCC.GetRow(GVNCC.GetSelectedRows()[0]) as O_NHACUNGCAP;
                if (_NCC != null)
                {
                    new frmNCCThem(_NCC).ShowDialog(this);
                }
            }
        }
        #endregion


        private void GVNCCGD_DoubleClick(object sender, EventArgs e)
        {
            if (GVNCCGD.GetSelectedRows().Count() > 0)
            {
                _NCCGDO = GVNCCGD.GetRow(GVNCCGD.GetSelectedRows()[0]) as O_NHACUNGCAP_GIAODICHPHATSINH;
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

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GrHang.Visible = barCheckItem1.Checked;
        }

        private void rbtn_Click(object sender, EventArgs e)
        {
            if (GVNCC.GetSelectedRows().Count() > 0)
            {
                O_NHACUNGCAP _NCCO = GVNCC.GetRow(GVNCC.GetSelectedRows()[0]) as O_NHACUNGCAP;
                if (_NCCO != null)
                    if (_NCCO.KhachSan)
                        new frmCongNoKS(_NCCO).ShowDialog(this);
            }
        }
    }
}