using DataAccessLayer;
using DataTransferObject;
using System;

namespace CRM
{
    public partial class frmSignIn : DevExpress.XtraEditors.XtraForm
    {
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {
            daiLyOBindingSource.DataSource = new DaiLyD().All();
            hangBayOBindingSource.DataSource = new HangBayD().DuLieu();
            btnXoa.Visibility = btnThem.Visibility = DuLieuTaoSan.Q.SignInXoa ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            TaiLaiSignIn();
            XuLyGiaoDien.OpenForm(this);
        }

        #region Dữ liệu 
        public void TaiLaiSignIn()
        {
            signInOBindingSource.DataSource = new SignInD().DuLieu();
            GVSI.FocusedRowHandle = _index;
        }
        #endregion

        #region Biến
        SignInO _SignInO = new SignInO();
        int _index = 0;
        #endregion

        #region Sự kiện nút
        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiSignIn();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmSignInThem().ShowDialog(this);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _index = GVSI.GetFocusedDataSourceRowIndex() - 1;
            _SignInO = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
            XuLyGiaoDien.ThongBao("Sign in", new SignInD().Xoa(_SignInO.ID) > 0, true);
            TaiLaiSignIn();
        }
        #endregion

        #region Sự khiện bản 
        private void GVSI_DoubleClick(object sender, EventArgs e)
        {
            if (DuLieuTaoSan.Q.SignInThemSua)
            {
                _index = GVSI.GetFocusedDataSourceRowIndex();
                _SignInO = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
                if (_SignInO != null)
                    new frmSignInThem(_SignInO).ShowDialog(this);
            }
        }
        #endregion
    }
}