using DataAccessLayer;
using System;

namespace CRM
{
    public partial class frmSoDuNganHang : DevExpress.XtraEditors.XtraForm
    {
        public frmSoDuNganHang(int iDs)
        {
            InitializeComponent();
            id = iDs;
            dateEdit1.EditValue = DateTime.Now.AddDays(-15);
            dateEdit2.EditValue = DateTime.Now;
        }


        private void frmSoDuNganHang_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
        }

        #region Dữ liệu 
        void loadDL()
        {
            soDuNganHangOBindingSource.DataSource = new D_SODU_NGANHANG().LayDanhSach(id, dateEdit1.DateTime, dateEdit2.DateTime);
        }
        #endregion

        #region Biến
        int id = 0;
        #endregion

        #region Sự kiện nút
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.EditValue != null && dateEdit2.EditValue != null)
                loadDL();
        }
        #endregion
    }
}