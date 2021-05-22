using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmNganHangKL : DevExpress.XtraEditors.XtraForm
    {
        string a = string.Empty;
        List<GiaoDichO> _GiaoDich = new List<GiaoDichO>();
        List<GiaoDichO> _GiaoDich1 = new List<GiaoDichO>();
        public frmNganHangKL(object TienMat, bool Hoan, object MaDL, bool all, List<GiaoDichO> vs1)
        {
            InitializeComponent();
            GVDSC.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            _GiaoDich = vs1;
            if (all)
                a = string.Format("Khoa = 0 and LoaiKhachHang = 3 and Coalesce(NganHang,0) = {0} and (GiaThu <> 0 or GiaHoan <> 0) AND LoaiGiaoDich {1} 9", TienMat, Hoan ? "=" : "<>");
            else
                a = string.Format("Khoa = 0 and IDKhachHang = {2} and Coalesce(NganHang,0) = {0} and (GiaThu <> 0 or GiaHoan <> 0) AND LoaiGiaoDich {1} 9", TienMat, Hoan ? "=" : "<>", MaDL);

            List<long> vs = vs1.Select(w => w.ID).ToList();
            if (vs.Count > 0)
                a += string.Format("AND ID NOT IN ({0})", string.Join(",", vs).Replace(vs[vs.Count - 1].ToString() + ",", vs[vs.Count - 1].ToString()));
        }

        private void frmNganHangKL_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            List<GiaoDichO> lstGD = new GiaoDichD().DuLieu(a, DuLieuTaoSan.Q.VeAdmin);
            foreach (GiaoDichO gz in lstGD)
            {
                GiaoDichO gza = gz;
                if (gza.LoaiGiaoDich != 9)
                    gza.GiaHeThong = 0;
                _GiaoDich1.Add(gza);
            }
            giaoDichOBindingSource.DataSource = _GiaoDich1;
            nganHangOBindingSource.DataSource = new NganHangD().All();
            daiLyOBindingSource.DataSource = new DaiLyD().KhachLe();
            GVDSC.BestFitColumns();
        }

        #region Sự kiện nút
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int seledtedCell = GVDSC.GetSelectedRows().Count();

            if (seledtedCell > 0)
            {
                for (int i = 0; i < seledtedCell; i++)
                {
                    GiaoDichO gd = GVDSC.GetRow(GVDSC.GetSelectedRows()[i]) as GiaoDichO;
                    if (gd.LoaiGiaoDich != 9)
                        gd.GiaHeThong = 0;
                    _GiaoDich.Add(gd);
                }
                    (Owner as frmNganHangCTThem).DSSOVE(_GiaoDich);
                Close();
            }
        }
        #endregion

        #region Sự khiện bản     

        int iGiaThu = 0;
        int iGiaHoan = 0;
        int iPhiHoan = 0;
        private void GVDSC_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            iGiaThu = 0;
            iGiaHoan = 0;
            iPhiHoan = 0;
            int[] seledtedCell = GVDSC.GetSelectedRows();
            foreach (int ac in seledtedCell)
            {
                iGiaThu += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns["GiaThu"]).ToString());
                iGiaHoan += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns["GiaHoan"]).ToString());
                iPhiHoan += int.Parse(GVDSC.GetRowCellValue(ac, GVDSC.Columns["GiaHeThong"]).ToString());
            }
            GVDSC.InvalidateFooter();
        }

        #endregion

        private void GVDSC_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "GiaThu")
                e.Info.DisplayText = iGiaThu.ToString("#,##0");
            else if (e.Column.FieldName == "GiaHeThong")
                e.Info.DisplayText = iPhiHoan.ToString("#,##0");
            else if (e.Column.FieldName == "GiaHoan")
                e.Info.DisplayText = iGiaHoan.ToString("#,##0");
            else if (e.Column.FieldName == "TenKhach")
                e.Info.DisplayText = "Tổng: " + (iGiaHoan - iPhiHoan).ToString("#,##0");
            else if (e.Column.FieldName == "MaCho")
                e.Info.DisplayText = GVDSC.GetSelectedRows().Count().ToString();
        }
    }
}