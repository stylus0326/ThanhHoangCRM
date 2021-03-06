using DataAccessLayer;
using DataTransferObject;
using System;
using System.Linq;

namespace CRM
{

    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        O_DAILY _KhachHangO = new O_DAILY();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DuLieu();
            btnAdd.Visibility = ClsDuLieu.Quyen.NhanVienThemSua ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNhanVienThem(false).ShowDialog(this);
        }

        private void GVNV_DoubleClick(object sender, EventArgs e)
        {
            if (GVNV.GetSelectedRows().Count() > 0 && ClsDuLieu.Quyen.NhanVienThemSua)
            {
                _KhachHangO = GVNV.GetRow(GVNV.GetSelectedRows()[0]) as O_DAILY;
                if (_KhachHangO != null)
                    new frmNhanVienThem(_KhachHangO).ShowDialog(this);
            }
        }

        public void DuLieu()
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            khachHangOBindingSource.DataSource = new D_DAILY().NhanVien(ClsDuLieu.NhanVien.TenDangNhapCty.ToLower());
            quyenNhanVienOBindingSource.DataSource = new D_NHOMQUYEN().DuLieu();
            gioiTinhBindingSource.DataSource = DuLieuTaoSan.GioiTinh();
            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
        }

        private void rBut_Click(object sender, EventArgs e)
        {
            O_DAILY dl = GVNV.GetRow(GVNV.GetSelectedRows()[0]) as O_DAILY;
            new frmCongNoPhu(dl).ShowDialog();
        }

        private void rSi_Click(object sender, EventArgs e)
        {
            O_DAILY dl = GVNV.GetRow(GVNV.GetSelectedRows()[0]) as O_DAILY;
            string[] sic = dl.SIC.Split('/');
            if (int.Parse(sic[1]) > 0)
                new frmSignIn(dl).ShowDialog();
        }
    }
}