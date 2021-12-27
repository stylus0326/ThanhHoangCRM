using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmNHVH : DevExpress.XtraEditors.XtraForm
    {
        bool _nCC = false;
        int ID = 0;
        int _NCC = 0;
        public frmNHVH(int NCC, bool ncc, int _ID)
        {
            InitializeComponent();
            GVDSC.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            ID = _ID;
            _nCC = ncc;
            _NCC = NCC;
        }

        private void frmNHVH_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
            colGiaHoan.FieldName = _nCC ? "HangHoan" : "GiaHoan";
            giaoDichOBindingSource.DataSource = new D_GIAODICH().DuLieuVeHoan(_nCC, _NCC);
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu(true);
            daiLyOBindingSource.DataSource = new D_DAILY().All();
            GVDSC.BestFitColumns();
        }

        #region Sự kiện nút
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int seledtedCell = GVDSC.GetSelectedRows().Count();
            List<O_BAOCAOCTNH> lst = new List<O_BAOCAOCTNH>();
            if (seledtedCell > 0)
            {
                for (int i = 0; i < seledtedCell; i++)
                {
                    O_GIAODICH gd = GVDSC.GetRow(GVDSC.GetSelectedRows()[i]) as O_GIAODICH;
                    O_BAOCAOCTNH bc = new O_BAOCAOCTNH();
                    bc.LoaiGiaoDich = 0;
                    bc.IDGDLienKet = gd.ID;
                    bc.IDCTNganHang = ID;
                    bc.SoTien = _nCC ? gd.HangHoan : gd.GiaHoan;
                    bc.Thu = _nCC;
                    bc.Code = gd.MaCho;
                    lst.Add(bc);
                }
                    (Owner as frmNHCTThem).DSSOVE(lst);
                Close();
            }
        }
        #endregion

        #region Sự khiện bản     

        int iGiaHoan = 0;
        private void GVDSC_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            iGiaHoan = 0;
            int[] seledtedCell = GVDSC.GetSelectedRows();
            foreach (int ac in seledtedCell)
            {
                iGiaHoan += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns[_nCC ? "HangHoan" : "GiaHoan"]).ToString());
            }
            GVDSC.InvalidateFooter();
        }
        #endregion

        private void GVDSC_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "GiaHoan")
                e.Info.DisplayText = iGiaHoan.ToString("#,##0");
            else if (e.Column.FieldName == "HangHoan")
                e.Info.DisplayText = iGiaHoan.ToString("#,##0");
            else if (e.Column.FieldName == "MaCho")
                e.Info.DisplayText = GVDSC.GetSelectedRows().Count().ToString();
        }
    }
}