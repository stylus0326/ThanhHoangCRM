using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmTongHop : XtraForm
    {
        List<O_DAILY> lstDaiLy = new List<O_DAILY>();
        public frmTongHop()
        {
            InitializeComponent();
        }

        private void frmTongHop_Load(object sender, EventArgs e)
        {
            loaiGiaoDichOBindingSource.DataSource = new D_LOAIGIAODICH().DuLieu_CongNo_TheoLoai(0);
            DSLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_GiaoDich();
            lstDaiLy = new D_DAILY().All();
            daiLyOBindingSource.DataSource = lstDaiLy;
            btn2.Visibility = DuLieuTaoSan.Q.Lv2KhacAdmin ? BarItemVisibility.Always : BarItemVisibility.Never;
            btn4.Visibility = DuLieuTaoSan.Q.KhacThemSua ? BarItemVisibility.Always : BarItemVisibility.Never;
            NapDatCho();
        }

        #region Dữ liệu 
        public void NapDatCho()
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            string query = "LoaiGiaoDich in (0,1,5,6,7,10,11,12)";
            if (query.Length > 0)
            {
                if (chk2.Checked)
                {
                    if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    {
                        query = string.Format("({2}) AND (convert(date, NgayGD) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"), query);
                        lstGDDC = new D_GIAODICH().DuLieu(query, DuLieuTaoSan.Q.VeAdmin);
                    }
                }
                else if (chk1.Checked)
                {
                    query = string.Format("({0}) {1}", query, DuLieuTaoSan.ThoiGianRutGon("NgayGD")[idThoiGian]);
                    lstGDDC = new D_GIAODICH().DuLieu(query, DuLieuTaoSan.Q.VeAdmin);
                }
                giaoDichOBindingSource.DataSource = lstGDDC;
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }
        #endregion

        #region Biến
        List<O_GIAODICH> lstGDDC = new List<O_GIAODICH>();
        int idThoiGian = 0;
        #endregion

        #region Giao diện
        #endregion

        #region Sự kiện nút

        private void btnLoadDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            NapDatCho();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmNo3Ngay().ShowDialog(ParentForm);
        }
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmTongHopThem().ShowDialog(ParentForm);
        }

        private void btnXDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            O_GIAODICH GD = (GVDC.GetRow(GVDC.GetSelectedRows()[0]) as O_GIAODICH);

            switch (GD.LoaiGiaoDich)
            {
                case 1:
                case 0:
                    if (!DuLieuTaoSan.Q.KhacXoa)
                        return;
                    break;
                default:
                    if (!DuLieuTaoSan.Q.KhacAdminXoa)
                        return;
                    break;

            }

            if (XuLyGiaoDien.ThongBao("giao dịch", new D_GIAODICH().Xoa(GD.ID) > 0, true))
            {
                string NoiDung = string.Format("Xóa GD ", GD.GhiChu);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", GD.MaCho);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", GD.LoaiKhachHang);
                dic.Add("Ma", GD.IDKhachHang);
                new D_LS_GIAODICH().ThemMoi(dic);
                NapDatCho();
            }
            else
                XuLyGiaoDien.Alert("Xóa không thành công", Form_Alert.enmType.Error);
        }

        private void barCheckItem3_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpTu.Enabled = bdtpDen.Enabled = chk2.Checked;
            NapDatCho();
            if (chk1.Checked)
                bcmbThoiGian.Links[0].Focus();
            else if (chk2.Checked)
                bdtpTu.Links[0].Focus();
        }

        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            idThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            NapDatCho();
        }

        private void rdptTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            NapDatCho();
        }

        #endregion

        #region Sự khiện bản 
        private void grvDatCho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                new frmTongHopThem((GVDC.GetRow(GVDC.GetSelectedRows()[0]) as O_GIAODICH)).ShowDialog(ParentForm);
        }
        private void grvDatCho_DoubleClick(object sender, EventArgs e)
        {
            O_GIAODICH giaoDichO = (GVDC.GetRow(GVDC.GetSelectedRows()[0]) as O_GIAODICH);
            if (giaoDichO.LoaiGiaoDich != 10)
                new frmTongHopThem(giaoDichO).ShowDialog(ParentForm);
        }
        #endregion

        private void btnEx_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dal = XtraMessageBox.Show("Thu hồi chọn [OK], trả chiết khấu chọn [Cancel]", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (XtraMessageBox.Show("Chỉ dùng cho đại lý. File gồm các cột [TenDaiLy,Gia,NoiDung]", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                return;

            List<Dictionary<string, object>> lstdic = new List<Dictionary<string, object>>();
            List<O_GIAODICH> giaoDichOs = new List<O_GIAODICH>();
            XtraOpenFileDialog ofd = new XtraOpenFileDialog();
            ofd.Title = "Mở File";
            ofd.Filter = "Excel File (*.xlsx, *.xls) | *.xlsx; *.xls";
            ofd.DefaultExt = ".xlsx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ChuoiKetNoi = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + "; Extended Properties='Excel 12.0 Xml;HDR=YES';";
                using (OleDbConnection conn = new OleDbConnection(ChuoiKetNoi))
                {
                    conn.Open();
                    DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string CauTruyVan = "SELECT * FROM [" + dbSchema.Rows[0].Field<string>("TABLE_NAME").Replace("'", string.Empty) + ']';
                    OleDbDataAdapter da = new OleDbDataAdapter(CauTruyVan, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        if ((row["TenDaiLy"] ?? "").ToString().Length > 0 && int.Parse((row["Gia"] ?? 0).ToString()) != 0)
                        {
                            if (lstDaiLy.Where(w => w.Ten.ToUpper().Equals(row["TenDaiLy"].ToString().Replace(" Total", "").ToUpper())).Count() > 0)
                            {
                                Dictionary<string, object> dic = new Dictionary<string, object>();
                                dic.Add("NgayGD", "getdate()");
                                dic.Add("NgayCuonChieu", "getdate()");
                                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                                dic.Add("CoDinh", 1);
                                dic.Add("LoaiKhachHang", "1");
                                dic.Add("IDKhachHang", lstDaiLy.Where(w => w.Ten.ToUpper().Equals(row["TenDaiLy"].ToString().Replace(" Total", "").ToUpper())).First().ID);

                                if (dal == DialogResult.OK)
                                {
                                    dic.Add("GiaHeThong", int.Parse(row["Gia"].ToString().Replace("-", "")));
                                    dic.Add("GiaThu", int.Parse(row["Gia"].ToString().Replace("-", "")));
                                    dic.Add("LoaiGiaoDich", 6);
                                    dic.Add("GiaHoan",0);
                                }
                                else
                                {
                                    dic.Add("GiaHeThong", 0);
                                    dic.Add("GiaThu", 0);
                                    dic.Add("LoaiGiaoDich", 12);
                                    dic.Add("GiaHoan", int.Parse(row["Gia"].ToString().Replace("-", "")));
                                }

                                dic.Add("TenKhach", row["NoiDung"].ToString());
                                lstdic.Add(dic);
                            }
                            else
                            {
                                XuLyGiaoDien.Alert($"Thông tin đại lý dòng {i} sai", Form_Alert.enmType.Error);
                                return;
                            }
                        }
                        else
                        {
                            XuLyGiaoDien.Alert("Cột Tên đại lý hoặc Giá thiếu thông tin", Form_Alert.enmType.Error);
                            return;
                        }
                    }

                    if (dt.Rows.Count == lstdic.Count)
                    {
                        if (XuLyGiaoDien.ThongBao(Text, new D_GIAODICH().ThemNhieu1Ban(lstdic) > 0))
                        {
                            NapDatCho();
                            Close();
                        }
                    }
                }
            }
        }
    }
}