using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmNHV : DevExpress.XtraEditors.XtraForm
    {
        bool _nCC = false;
        int ID = 0;
        int _NCC = 0;
        public frmNHV(int NCC, bool ncc, int _ID)
        {
            InitializeComponent();
            GVDSC.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            ID = _ID;
            _nCC = ncc;
            _NCC = NCC;
        }

        private void frmNHV_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            colGiaThu.FieldName = _nCC ? "GiaNet" : "GiaThu";
            giaoDichOBindingSource.DataSource = new D_GIAODICH().DuLieuVe(_nCC, _NCC);
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
                    bc.SoTien = _nCC ? gd.GiaNet : gd.GiaThu;
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
                iGiaThu += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns[_nCC ? "GiaNet" : "GiaThu"]).ToString());
            }
            GVDSC.InvalidateFooter();
        }
        #endregion

        private void GVDSC_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "GiaThu")
                e.Info.DisplayText = iGiaThu.ToString("#,##0");
            else if (e.Column.FieldName == "GiaNet")
                e.Info.DisplayText = iGiaThu.ToString("#,##0");
            else if (e.Column.FieldName == "MaCho")
                e.Info.DisplayText = GVDSC.GetSelectedRows().Count().ToString();
        }
    }
}