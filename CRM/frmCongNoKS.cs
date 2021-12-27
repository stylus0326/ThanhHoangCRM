using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmCongNoKS : DevExpress.XtraEditors.XtraForm
    {
        O_NHACUNGCAP daiLyO = new O_NHACUNGCAP();
        List<O_KHACHSAN> lstCongNo = new List<O_KHACHSAN>();
        public frmCongNoKS(O_NHACUNGCAP dl)
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCN, GVCN);
            daiLyO = dl;
            dtp1.EditValue = DateTime.ParseExact("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), "d/M/yyyy", null);
            dtp2.EditValue = (DateTime.Today.Day == 1) ? DateTime.Today : DateTime.Today;
            DuLieu();
            Text += " " + dl.Ten;
        }

        private void frmCongNoKS_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DuLieu();
        }

        void DuLieu()
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            lstCongNo = new D_KHACHSAN().LayDanhSachCN(dtp1.DateTime, dtp2.DateTime, daiLyO.ID.ToString());
            khachSanOBindingSource.DataSource = lstCongNo;
            ClsChucNang.wait.CloseWaitForm();
        }
    }
}