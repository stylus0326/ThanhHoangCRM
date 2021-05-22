using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmNo3Ngay : DevExpress.XtraEditors.XtraForm
    {
        public frmNo3Ngay()
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
        }

        private void frmNo3Ngay_Load(object sender, EventArgs e)
        {
            dateEdit1.Properties.MaxValue = DateTime.Now.AddDays(-1);
            dateEdit1.EditValue = DateTime.Now.AddDays(-1);
            XuLyGiaoDien.OpenForm(this);
        }

        #region Biến
        List<O_DAILY> lstDaiLy;
        int num = 0;
        #endregion

        #region Sự kiện nút
        private void xóaKhỏiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void btnn_Click(object sender, EventArgs e)
        {
            if (new D_DAILY().KiemTraNgay(num) > 0)
                XtraMessageBox.Show("Đã phạt âm quỹ ngày này", "Thông báo");
            else
            {
                List<Dictionary<string, object>> lstdic = new List<Dictionary<string, object>>();
                for (int i = 0; i < lstDaiLy.Count; i++)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("NgayGD", dateEdit1.DateTime);
                    dic.Add("NgayCuonChieu", "getdate()");
                    dic.Add("LoaiKhachHang", 1);
                    dic.Add("LoaiGiaoDich", 10);
                    dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                    dic.Add("IDKhachHang", lstDaiLy[i].ID);
                    dic.Add("TenKhach", "Phạt âm nợ 3 ngày liên tiếp, số dư cuối " + gridView1.Columns[4].Caption + " :" + (0 - lstDaiLy[i].SoDuCuoi1).ToString("#,###") + " * " + lstDaiLy[i].PhatQuyAm);
                    dic.Add("GiaHeThong", lstDaiLy[i].TienPhat);
                    dic.Add("GiaThu", lstDaiLy[i].TienPhat);
                    dic.Add("CoDinh", 1);
                    new D_GIAODICH().ThemMoi(dic);
                };
                XtraMessageBox.Show("Thực thi thành công", "Thông báo");
                (Owner.ActiveMdiChild as frmTongHop).NapDatCho();
                Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            btnn.Enabled = true;
            lstDaiLy = new D_DAILY().LayDanhSachNo3NgayLienTiep(dateEdit1.DateTime);
            daiLyOBindingSource.DataSource = lstDaiLy;
            try
            {
                gridView1.Columns[4].Caption = dateEdit1.DateTime.AddDays(-1).ToString("d/M");
                gridView1.Columns[5].Caption = dateEdit1.DateTime.AddDays(-2).ToString("d/M");
                gridView1.Columns[6].Caption = dateEdit1.DateTime.AddDays(-3).ToString("d/M");
            }
            catch
            {
                XtraMessageBox.Show("Không có nợ trong ngày vừa qua", "Thông báo");
            }
        }
        #endregion

        #region Sự khiện bản 
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            O_DAILY gd = (O_DAILY)gridView1.GetRow(gridView1.GetSelectedRows()[0]);
            GridView view = sender as GridView;
            view.FocusedRowHandle = e.HitInfo.RowHandle;
            contextMenu.Show(view.GridControl, e.Point);
        }
        #endregion
    }
}