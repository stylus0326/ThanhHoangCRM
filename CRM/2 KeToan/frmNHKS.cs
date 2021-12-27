using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmNHKS : DevExpress.XtraEditors.XtraForm
    {
        bool _nCC = false;
        int ID = 0;
        int _NCC = 0;

        public frmNHKS(int NCC, bool ncc, int _ID)
        {
            InitializeComponent();
            GVDSC.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            ID = _ID;
            _nCC = ncc;
            _NCC = NCC;
        }

        private void frmNHKS_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
            colGiaThu.FieldName = _nCC ? "GiaNet" : "GiaHeThong";
            khachSanOBindingSource.DataSource = new D_KHACHSAN().DuLieuKS(_nCC, _NCC);
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
                    O_KHACHSAN gd = GVDSC.GetRow(GVDSC.GetSelectedRows()[i]) as O_KHACHSAN;
                    O_BAOCAOCTNH bc = new O_BAOCAOCTNH();
                    bc.LoaiGiaoDich = 1;
                    bc.IDGDLienKet = gd.ID;
                    bc.IDCTNganHang = ID;
                    bc.SoTien = _nCC ? gd.GiaNet : gd.GiaHeThong;
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

        int iGiaThu = 0;
        private void GVDSC_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            iGiaThu = 0;
            int[] seledtedCell = GVDSC.GetSelectedRows();
            foreach (int ac in seledtedCell)
            {
                iGiaThu += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns[_nCC ? "GiaNet" : "GiaHeThong"]).ToString());
            }
            GVDSC.InvalidateFooter();
        }

        #endregion

        private void GVDSC_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "GiaHeThong")
                e.Info.DisplayText = iGiaThu.ToString("#,##0");
            else if (e.Column.FieldName == "GiaNet")
                e.Info.DisplayText = iGiaThu.ToString("#,##0");
            else if (e.Column.FieldName == "MaCho")
                e.Info.DisplayText = GVDSC.GetSelectedRows().Count().ToString();
        }
    }
}