using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmNHKSCT : DevExpress.XtraEditors.XtraForm
    {
        bool _nCC = false;
        int ID = 0;

        public frmNHKSCT(bool ncc, int _ID)
        {
            InitializeComponent();
            GVDSC.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            ID = _ID;
            _nCC = ncc;
        }

        private void frmNHKSCT_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            khachSanOBindingSource.DataSource = new D_KHACHSAN().DuLieuKSBL(_nCC);
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
                    bc.LoaiGiaoDich = 2;
                    bc.IDGDLienKet = gd.ID;
                    bc.IDCTNganHang = ID;
                    bc.SoTien = 0 - gd.SoTienBaoLuu;
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
                iGiaThu += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns["SoTienBaoLuu"]).ToString());
            }
            GVDSC.InvalidateFooter();
        }

        #endregion

        private void GVDSC_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "SoTienBaoLuu")
                e.Info.DisplayText = iGiaThu.ToString("#,##0");
            else if (e.Column.FieldName == "MaCho")
                e.Info.DisplayText = GVDSC.GetSelectedRows().Count().ToString();
        }
    }
}