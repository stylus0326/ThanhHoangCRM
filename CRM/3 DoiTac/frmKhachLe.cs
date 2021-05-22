using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace CRM
{
    public partial class frmKhachLe : XtraForm
    {
        DaiLyO _DaiLyO = new DaiLyO();
        DaiLyD _DaiLyD = new DaiLyD();
        public frmKhachLe()
        {
            InitializeComponent();
        }

        private void frmKhachLe_Load(object sender, EventArgs e)//
        {
            nhanVienOBindingSource.DataSource = _DaiLyD.NhanVien();
            DuLieu();
            XuLyGiaoDien.OpenForm(this);
        }

        #region Dữ liệu 
        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            daiLyOBindingSource.DataSource = new DaiLyD().KhachLe();

            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Sự kiện nút
        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmKhachLeThem().ShowDialog(this);
        }
        #endregion

        #region Sự khiện bản 
        private void GVKL_DoubleClick(object sender, EventArgs e)
        {
            if (GVKL.GetSelectedRows().Count() > 0)
            {
                _DaiLyO = GVKL.GetRow(GVKL.GetSelectedRows()[0]) as DaiLyO;
                if (_DaiLyO != null)
                    new frmKhachLeThem(_DaiLyO).ShowDialog(this);
            }
        }
        #endregion

    }
}