using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace CRM
{
    public partial class frmKhachLe : XtraForm
    {
        O_DAILY _DaiLyO = new O_DAILY();
        D_DAILY _DaiLyD = new D_DAILY();
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
            daiLyOBindingSource.DataSource = new D_DAILY().KhachLe();

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
                _DaiLyO = GVKL.GetRow(GVKL.GetSelectedRows()[0]) as O_DAILY;
                if (_DaiLyO != null)
                    new frmKhachLeThem(_DaiLyO).ShowDialog(this);
            }
        }
        #endregion

    }
}