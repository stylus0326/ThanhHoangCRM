using DataAccessLayer;
using DataTransferObject;
using System;
using System.Linq;

namespace CRM
{

    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        DaiLyO _KhachHangO = new DaiLyO();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DuLieu();
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNhanVienThem().ShowDialog(this);
        }

        private void GVNV_DoubleClick(object sender, EventArgs e)
        {
            if (GVNV.GetSelectedRows().Count() > 0)
            {
                _KhachHangO = GVNV.GetRow(GVNV.GetSelectedRows()[0]) as DaiLyO;
                if (_KhachHangO != null)
                    new frmNhanVienThem(_KhachHangO).ShowDialog(this);
            }
        }

        public void DuLieu()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            khachHangOBindingSource.DataSource = new DaiLyD().DuLieu(0);
            quyenNhanVienOBindingSource.DataSource = new QuyenNhanVienD().DuLieu();
            gioiTinhBindingSource.DataSource = DuLieuTaoSan.GioiTinh();
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        private void rBut_Click(object sender, EventArgs e)
        {
            DaiLyO dl = GVNV.GetRow(GVNV.GetSelectedRows()[0]) as DaiLyO;
            new frmCongNoPhu(dl).ShowDialog();
        }
    }
}