using DataAccessLayer;
using DataTransferObject;
using System;
using System.Linq;

namespace CRM
{
    public partial class frmBieuDoDaiLy : DevExpress.XtraEditors.XtraForm
    {
        int A = 0;
        public frmBieuDoDaiLy(int a)
        {
            InitializeComponent();
            A = a;
        }

        private void frmBieuDoDaiLy_Load(object sender, EventArgs e)
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            DaiLyDB.DataSource = new D_DAILY().All(false).Where(w => w.LoaiKhachHang.Equals(1)).ToList();
            iIDKhachHang.EditValue = A;
            ClsChucNang.OpenForm(this);
            ClsChucNang.wait.CloseWaitForm();
        }

        private void iIDKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (iIDKhachHang.EditValue != null)
            {
                O_DAILY dl = (O_DAILY)iIDKhachHang.Properties.GetRowByKeyValue(iIDKhachHang.EditValue);
                if (dl != null)
                    bieuDoOBindingSource.DataSource = new BieuDoD().DuLieu1(dl.ID, dl.NgayKiQuy);
            }
        }
    }
}