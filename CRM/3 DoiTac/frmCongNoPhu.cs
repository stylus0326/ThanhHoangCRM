using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmCongNoPhu : DevExpress.XtraEditors.XtraForm
    {
        DaiLyO daiLyO = new DaiLyO();
        List<GiaoDichO> lstCongNo = new List<GiaoDichO>();
        public frmCongNoPhu(DaiLyO dl)
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCN, GVCN);
            daiLyO = dl;
            dtp1.EditValue = DateTime.ParseExact("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), "d/M/yyyy", null);
            dtp2.EditValue = (DateTime.Today.Day == 1) ? DateTime.Today : DateTime.Today;
            lstCongNo = new GiaoDichD().LayDanhSachCN(dtp1.DateTime, dtp2.DateTime, daiLyO.ID.ToString());
            giaoDichOBindingSource.DataSource = lstCongNo;
        }

        public frmCongNoPhu(string A, DateTime dtp1s, DateTime dtp2s)
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCN, GVCN);
            dtp1.EditValue = dtp1s;
            dtp2.EditValue = dtp2s;
            lstCongNo = new GiaoDichD().LayDanhSachCN(dtp1.DateTime, dtp2.DateTime, A);
            giaoDichOBindingSource.DataSource = lstCongNo;
        }

        private void frmCongNoPhu_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            tuyenBayOBindingSource.DataSource = new TuyenBayD().DuLieu();
            IntStringBindingSource.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve_All(daiLyO.LoaiKhachHang);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<GiaoDichO> lstCongNo = new GiaoDichD().LayDanhSachCN(dtp1.DateTime, dtp2.DateTime, daiLyO.ID.ToString());
            giaoDichOBindingSource.DataSource = lstCongNo;
        }
    }
}