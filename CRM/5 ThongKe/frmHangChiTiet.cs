using DataAccessLayer;
using System;

namespace CRM
{
    public partial class frmHangChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public frmHangChiTiet(string ID, DateTime d1, DateTime d2)
        {
            InitializeComponent();
            soDuHangOBindingSource.DataSource = new D_SODU_HANG().DuLieu(ID, d1, d2);
            GVHBSD.BestFitColumns();
        }

        private void frmHangChiTiet_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
        }
    }
}