using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;

namespace CRM
{
    public partial class frmQuyenNhanVien : XtraForm
    {
        public frmQuyenNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuyenNhanVien_Load(object sender, System.EventArgs e)
        {
            LoadDL();
        }

        #region Dữ liệu 

        public void LoadDL()
        {
            QuyenNhanVienOBindingSource.DataSource = new D_NHOMQUYEN().DuLieu();
        }
        #endregion

        #region Sự kiện nút
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmQuyenNhanVienThem().ShowDialog(ParentForm);
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDL();
        }
        #endregion

        #region Sự khiện bản 
        private void grvQuyenNhanVien_DoubleClick(object sender, System.EventArgs e)
        {
            new frmQuyenNhanVienThem(grvQuyenNhanVien.GetRow(grvQuyenNhanVien.GetSelectedRows()[0]) as O_NHOMQUYEN).ShowDialog(ParentForm);
        }
        #endregion

    }
}