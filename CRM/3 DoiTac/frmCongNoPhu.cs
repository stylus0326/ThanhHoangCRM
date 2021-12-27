using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmCongNoPhu : DevExpress.XtraEditors.XtraForm
    {
        O_DAILY daiLyO = new O_DAILY();
        List<O_GIAODICH> lstCongNo = new List<O_GIAODICH>();
        public frmCongNoPhu(O_DAILY dl)
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCN, GVCN);
            daiLyO = dl;
            dtp1.EditValue = DateTime.ParseExact("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), "d/M/yyyy", null);
            dtp2.EditValue = (DateTime.Today.Day == 1) ? DateTime.Today : DateTime.Today;
            DuLieu();
            Text += " " + dl.Ten;
        }

        public frmCongNoPhu(string A, DateTime dtp1s, DateTime dtp2s)
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCN, GVCN);
            dtp1.EditValue = dtp1s;
            dtp2.EditValue = dtp2s;
            lstCongNo = new D_GIAODICH().LayDanhSachCN(dtp1.DateTime, dtp2.DateTime, A);
            giaoDichOBindingSource.DataSource = lstCongNo;
        }

        private void frmCongNoPhu_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
            tuyenBayOBindingSource.DataSource = new D_TUYENBAY().DuLieu();
            loaiGiaoDichOBindingSource.DataSource = new D_LOAIGIAODICH().DuLieu_CongNo_TheoLoai(daiLyO.LoaiKhachHang);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DuLieu();
        }

        void DuLieu()
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            lstCongNo = new D_GIAODICH().LayDanhSachCN(dtp1.DateTime, dtp2.DateTime, daiLyO.ID.ToString());
            giaoDichOBindingSource.DataSource = lstCongNo;
            ClsChucNang.wait.CloseWaitForm();
        }
    }
}