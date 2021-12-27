using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace CRM
{
    public partial class frmKPIHangMuc : DevExpress.XtraEditors.XtraForm
    {
        public frmKPIHangMuc()
        {
            InitializeComponent();
        }

        private void frmKPIHangMuc_Load(object sender, EventArgs e)
        {
            TaiLaiKPI();
            ClsChucNang.OpenForm(this);
        }
        List<O_KPIHANGMUC> lstSI = new List<O_KPIHANGMUC>();
        #region Dữ liệu 
        public void TaiLaiKPI()
        {
            lstSI = new D_KPIHANGMUC().DuLieu();
            kPIHangMucOBindingSource.DataSource = lstSI.Where(w => !w.Nhom.Equals("Mục"));
            gridControl1.DataSource = lstSI.Where(w => w.Nhom.Equals("Mục"));
            GVKPI.ExpandAllGroups();
            GVKPI.FocusedRowHandle = _index;
        }
        #endregion

        #region Biến
        O_KPIHANGMUC _SignInO = new O_KPIHANGMUC();
        int _index = 0;
        #endregion

        #region Sự kiện nút
        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaiLaiKPI();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmKPIHangMucThem().ShowDialog(this);
        }
        #endregion

        #region Sự khiện bản 
        private void GVSI_DoubleClick(object sender, EventArgs e)
        {
            _index = GVKPI.GetFocusedDataSourceRowIndex();
            _SignInO = GVKPI.GetRow(GVKPI.GetSelectedRows()[0]) as O_KPIHANGMUC;
            if (_SignInO != null)
                new frmKPIHangMucThem(_SignInO).ShowDialog(this);
        }
        #endregion

        string plu = "";

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                O_KPIHANGMUC dl = View.GetRow(e.RowHandle) as O_KPIHANGMUC;
                if (e.Column.FieldName == "VietTat")
                {
                    if (plu.Contains((dl.VietTat ?? "").ToString()))
                        e.Appearance.BackColor = Color.BurlyWood;
                    else
                        e.Appearance.BackColor = default;
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (GVKPI.GetSelectedRows().Count() < 1) return;
            _SignInO = GVKPI.GetRow(GVKPI.GetSelectedRows()[0]) as O_KPIHANGMUC;
            if (_SignInO != null)
            {
                plu = (_SignInO.VietTat ?? "");
                gridControl1.DataSource = lstSI.Where(w => w.Nhom.Equals("Mục"));
            }
        }
    }
}