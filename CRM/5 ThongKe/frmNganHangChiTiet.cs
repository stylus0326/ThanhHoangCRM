using DataAccessLayer;
using System;

namespace CRM
{
    public partial class frmNganHangChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public frmNganHangChiTiet(DateTime dtp1, DateTime dtp2, string ID)
        {
            InitializeComponent();//AND (convert(date, NgayGD) BETWEEN '20201001' AND '20201018') AND NganHangID = 8
            cTNganHangOBindingSource.DataSource = new D_CTNGANHANG().DuLieu(string.Format("AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')  AND NganHangID = {2}", dtp1.ToString("yyyyMMdd"), dtp2.ToString("yyyyMMdd"), ID), false);
        }

        private void frmNganHangChiTiet_Load(object sender, EventArgs e)
        {
            loaiGiaoDichOBindingSource.DataSource = new D_LOAIGIAODICH().DuLieu();
            ClsChucNang.OpenForm(this);
        }
    }
}