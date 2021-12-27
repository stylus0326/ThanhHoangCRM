using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CRM
{
    public partial class frmKhachLeNo : DevExpress.XtraEditors.XtraForm
    {
        List<O_GIAODICH> lstGD = new List<O_GIAODICH>();
        public frmKhachLeNo()
        {
            InitializeComponent();
        }

        private void frmKhachLeNo_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
            nganHangOBindingSource.DataSource = new D_NGANHANG().All();
            DSNhanVien.DataSource = new D_DAILY().All();
            LayDLCTNganHang();
        }

        #region Dữ liệu 
        public void LayDLCTNganHang()
        {
            string CTV = "SMS = 1 ";
            if (chk1.Checked)
                CTV += DuLieuTaoSan.ThoiGianRutGon("NgayCuonChieu")[idThoiGian];
            else if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                CTV += string.Format("AND (convert(date, NgayCuonChieu) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            if (chkDD.Checked)
                CTV += "OR (SMS = 1 and Khoa = 0)";
            lstGD = new D_GIAODICH().DuLieu(CTV, ClsDuLieu.Quyen.VeAdmin);
            giaoDichOBindingSource.DataSource = lstGD;
            GVKLN.BestFitColumns();
        }
        #endregion

        #region Biến
        int idThoiGian = 0;
        #endregion

        #region Giao diện
        private void grvGiaoDich_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    O_GIAODICH dl = View.GetRow(e.RowHandle) as O_GIAODICH;
                    if (e.Column.FieldName == "Khoa")
                        if (dl.Khoa)
                            e.Appearance.BackColor = Color.Green;
                        else
                            e.Appearance.BackColor = Color.Crimson;
                }
            }
            catch { }
        }
        #endregion

        #region Sự kiện nút
        private void ibtnNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayDLCTNganHang();
        }

        private void chkKLC_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayDLCTNganHang();
        }

        private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idThoiGian = (sender as DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex;
            LayDLCTNganHang();
        }

        private void bdtpDen_EditValueChanged(object sender, EventArgs e)
        {
            LayDLCTNganHang();
        }

        private void chk1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barEditItem1.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
        }
        #endregion
    }
}