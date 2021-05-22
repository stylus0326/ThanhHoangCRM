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
            DaiLyDB.DataSource = new DaiLyD().All(false).Where(w => w.LoaiKhachHang.Equals(1)).ToList();
        }

        private void frmBieuDoDaiLy_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            iIDKhachHang.EditValue = A;
        }

        private void iIDKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (iIDKhachHang.EditValue != null)
            {
                DaiLyO dl = (DaiLyO)iIDKhachHang.Properties.GetRowByKeyValue(iIDKhachHang.EditValue);
                if (dl != null)
                    bieuDoOBindingSource.DataSource = new BieuDoD().DuLieu1(dl.ID, dl.NgayKiQuy);
            }
        }
    }
}