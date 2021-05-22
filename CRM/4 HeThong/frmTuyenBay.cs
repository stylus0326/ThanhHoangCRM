using DataAccessLayer;
using DataTransferObject;
using System;

namespace CRM
{
    public partial class frmTuyenBay : DevExpress.XtraEditors.XtraForm
    {
        public frmTuyenBay()
        {
            InitializeComponent();
        }

        private void frmTuyenBay_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            DuLieuSanBay();
            DuLieuTuyenBay();
        }

        #region SanBay
        private void GVSB_DoubleClick(object sender, EventArgs e)
        {
            if (GVSB.GetSelectedRows().Length > 0)
            {
                sanBayO = GVSB.GetRow(GVSB.GetSelectedRows()[0]) as SanBayO;
                if (sanBayO != null)
                {
                    frmSanBayThem f = new frmSanBayThem(sanBayO);
                    f.ShowDialog(ParentForm);
                }
            }
        }

        SanBayD sanBayD = new SanBayD();
        SanBayO sanBayO = new SanBayO();
        private void btnLoad1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieuSanBay();
        }

        private void btnThem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmSanBayThem().ShowDialog(ParentForm);
        }

        public void DuLieuSanBay()
        {
            sanBayOBindingSource.DataSource = sanBayD.DuLieu();
        }
        #endregion

        #region TuyenBay
        private void GVTB_DoubleClick(object sender, EventArgs e)
        {
            if (GVTB.GetSelectedRows().Length > 0)
            {
                tuyenBayO = GVTB.GetRow(GVTB.GetSelectedRows()[0]) as TuyenBayO;
                if (tuyenBayO != null)
                {
                    frmTuyenBayThem f = new frmTuyenBayThem(tuyenBayO);
                    f.ShowDialog(ParentForm);
                }
            }
        }

        TuyenBayD tuyenBayD = new TuyenBayD();
        TuyenBayO tuyenBayO = new TuyenBayO();

        private void btnLoad2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieuTuyenBay();
        }

        private void btnThem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmTuyenBayThem().ShowDialog(ParentForm);
        }

        public void DuLieuTuyenBay()
        {
            tuyenBayOBindingSource.DataSource = tuyenBayD.DuLieu();
        }
        #endregion

    }
}