using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CRM
{
    public partial class frmThongKe : DevExpress.XtraEditors.XtraForm
    {
        List<BanTongHopO> lst = new List<BanTongHopO>();
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            List<DaiLyO> l = new DaiLyD().All();
            daiLyOBindingSource.DataSource = l.Where(w => w.ID > 0);
            nCCOBindingSource.DataSource = new NCCD().DuLieu();
            nganHangOBindingSource.DataSource = new NganHangD().All();
            DuLieu();
            GVTK.BestFitColumns();
        }

        #region a
        //private void GVTK_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    BanTongHopO cat = view.GetRow(e.RowHandle) as BanTongHopO;
        //    if (cat != null)
        //        e.IsEmpty = !lst.Any(w => w.NgaySDKH == cat.NgaySDKH);
        //}

        //private void GVTK_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    BanTongHopO cat = view.GetRow(e.RowHandle) as BanTongHopO;
        //    if (cat != null)
        //    {
        //        XuLyGiaoDien.wait.ShowWaitForm();
        //        e.ChildList = new CTBanTongHopD().DuLieu1(cat.NgaySDKH);
        //        XuLyGiaoDien.wait.CloseWaitForm();
        //    }
        //}

        //private void GVTK_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        //{
        //    e.RelationCount = 1;
        //    bandedGridView2.BestFitColumns();
        //}

        //private void GVTK_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        //{
        //    e.RelationName = "ChiTiet";
        //    bandedGridView2.BestFitColumns();
        //}
        #endregion

        private void bandedGridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Value ?? 0).ToString() == "0")
                e.DisplayText = string.Empty;
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DuLieu();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCTK, GVTK, "ExTK-" + DateTime.Now.ToString("dd-MM-yyy"));
        }

        void DuLieu()
        {
            lst = new BanTongHopD().DuLieu1(new DateTime(2020, 11, 30));
            long B = 0;
            long C = lst.Sum(w => w.BienDong);
            lst[0].LNCD = C;
            for (int i = 0; i < lst.Count; i++)
            {
                long A = 0;
                C -= lst[i].BienDong;
                foreach (PropertyInfo propertyInfo in lst[i].GetType().GetProperties())
                {
                    if ("SDC_Am_NV,SDC_Am_DL,SDC_Am_CTV,SDC_Duong_HB,SDC_Duong_NH,SDC_Am_KL".Contains(propertyInfo.Name))
                        A += (long)propertyInfo.GetValue(lst[i]);
                    else if ("SDC_Duong_DL,SDC_Duong_CTV,SDC_Am_HB,SDC_Am_NH,SDC_Duong_KL,QuyCoc,SDC_Duong_NV".Contains(propertyInfo.Name))
                        A -= (long)propertyInfo.GetValue(lst[i]);
                }
                if (i > 0)
                {
                    lst[i - 1].ChenhLech = B - A;
                    lst[i - 1].CL = B - A - lst[i - 1].BienDong - lst[i - 1].BienDongVon + lst[i - 1].ChenhLechTien;
                }
                B = lst[i].V = A;
                if (i < lst.Count - 1)
                    lst[i + 1].LNCD = C;
            }
            banTongHopOBindingSource.DataSource = lst;
        }
    }
}