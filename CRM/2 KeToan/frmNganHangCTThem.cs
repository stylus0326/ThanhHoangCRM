using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNganHangCTThem : DevExpress.XtraEditors.XtraForm
    {
        public frmNganHangCTThem(bool isTienMat)
        {
            InitializeComponent();
            CTM = new CTNganHangO();
            CTM.NgayGD = CTM.NgayHT = CTM.NgayTT = DateTime.Now;
            CTM.NganHangID = isTienMat ? 1 : 0;
            iNganHangID.Enabled = !isTienMat;
        }

        public frmNganHangCTThem(CTNganHangO ct, int MaLienKet)
        {
            InitializeComponent();
            CTM = ct;
            if (!iTrangThaiID.Enabled)
                iTrangThaiID.Enabled = true;
            iLoaiGiaoDich.Enabled = iLoaiKhachHang.Enabled = !(CTM.LoaiKhachHang != 6);
            if (CTM.LoaiGiaoDich == 5 && CTM.MaLienKet != null)
                btnLuu.Enabled = CTM.MaLienKet.Length < 3;
            iMaDL.Enabled = !(CTM.LoaiGiaoDich == 4);
            iNganHangID.Enabled = false;
            ID = MaLienKet;
            iNganHangID.Enabled = ct.NganHangID != 1;
        }

        public void DSSOVE(List<GiaoDichO> gd)
        {
            if (iMaDL.Text.Length < 1)
                iMaDL.EditValue = gd[0].IDKhachHang;
            _GiaoDich = gd;
            giaoDichOBindingSource.DataSource = null;
            giaoDichOBindingSource.DataSource = _GiaoDich;
            if (iSoTien.Value == 0)
            {
                iSoTien.Value = _GiaoDich.Sum(w => w.GiaThu + w.GiaHeThong - w.GiaHoan);
                if (iSoTien.Value == 0)
                    iSoTien.Value = _GiaoDich.Sum(w => w.GiaThu + w.GiaHeThong - w.GiaHoan);
            }
            GVNCC.InvalidateFooter();
        }

        private void frmThemGiaoDichTK_Load(object sender, EventArgs e)
        {
            DataLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_NganHang();
            _NganHang = new NganHangD().All();
            nganHangNguonBindingSource.DataSource = _NganHang;
            nhanVienOBindingSource.DataSource = new DaiLyD().NhanVien();
            IntStringBindingSource.DataSource = DuLieuTaoSan.TrangThai_NganHang();

            if (CTM.NVGiaoDich < 1)
                CTM.NVGiaoDich = DuLieuTaoSan.NV.ID;

            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, CTM);
            XuLyGiaoDien.OpenForm(this);
            if (!CTM.TrangThaiID)
                iTrangThaiID.EditValue = true;

            if (CTM.LoaiKhachHang == 3 && CTM.ID > 0)
            {
                List<GiaoDichO> g = new GiaoDichD().DuLieuNganHang(CTM.IDGiaoDich);
                foreach (GiaoDichO gz in g)
                {
                    GiaoDichO gza = gz;
                    if (gza.LoaiGiaoDich != 9)
                        gza.GiaHeThong = 0;
                    _GiaoDich.Add(gza);
                    _GiaoDichOLD.Add(gza);
                }
                giaoDichOBindingSource.DataSource = _GiaoDich;
                GVNCC.InvalidateFooter();
            }
        }

        #region Biến
        int ID = 0;
        List<GiaoDichO> _GiaoDichOLD = new List<GiaoDichO>();
        List<GiaoDichO> _GiaoDich = new List<GiaoDichO>();
        List<NganHangO> _NganHang = new List<NganHangO>();
        CTNganHangO CTM;
        CTNganHangD ct = new CTNganHangD();
        #endregion

        #region Sự kiện nút

        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            int LoaiKhachHang = (int)iLoaiKhachHang.EditValue;
            DataHinhThuc.DataSource = DuLieuTaoSan.HinhThuc_NganHang(LoaiKhachHang);
            DataTen.DataSource = DuLieuTaoSan.NganHangLoaiKhachHang(LoaiKhachHang, (int)(iNganHangID.EditValue ?? 0));

            colName2.Visible = LoaiKhachHang == 1;
            groupControl1.Enabled = LoaiKhachHang == 3;
            if (!CTM.TrangThaiID)
                if ((int)iLoaiKhachHang.EditValue != 6)
                {
                    iTrangThaiID.EditValue = true;
                    iTrangThaiID.Enabled = false;
                }
                else
                {
                    iTrangThaiID.EditValue = false;
                    iTrangThaiID.Enabled = true;
                }
        }

        private void iLoaiGiaoDich_EditValueChanged(object sender, EventArgs e) //Giói hạn tiền
        {
            int[] AryMinus = new int[] { 0, 1, 3, 5, 7, 10, 11, 15, 17, 20, 22, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
            if ((int)iLoaiGiaoDich.EditValue == 13)
            {
                iSoTien.Properties.MinValue = -20000000000;
                iSoTien.Properties.MaxValue = 20000000000;
            }
            else if (AryMinus.Contains((int)iLoaiGiaoDich.EditValue))
            {
                if (iSoTien.Value > 0) iSoTien.Value = 0 - iSoTien.Value;
                iSoTien.Properties.MaxValue = 0;
                iSoTien.Properties.MinValue = -20000000000;

                if ((int)iLoaiGiaoDich.EditValue == 5 && CTM.MaLienKet != null)
                {
                    if (iSoTien.Value < 0) iSoTien.Value = 0 - iSoTien.Value;
                    iSoTien.Properties.MaxValue = 20000000000;
                    iSoTien.Properties.MinValue = 0;
                }
            }
            else
            {
                if (iSoTien.Value < 0) iSoTien.Value = 0 - iSoTien.Value;
                iSoTien.Properties.MaxValue = 20000000000;
                iSoTien.Properties.MinValue = 0;
            }
        }

        private void iTrangThaiID_EditValueChanged(object sender, EventArgs e)
        {
            if ((bool)iTrangThaiID.EditValue == true)
                iTrangThaiID.BackColor = Color.Green;
            else
                iTrangThaiID.BackColor = Color.Red;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iNganHangID,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iLoaiGiaoDich,_Tu=2 ,_Den = 50} ,
             new KiemTra() { _Control = iMaDL,_Tu=2 ,_Den = 50,_ChoQuaThang =new List<int>(){ 6,9}.Contains((int)iLoaiKhachHang.EditValue) } ,
            new KiemTra() { _Control = iLoaiKhachHang,_Tu=2,_Den = 50 } };

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            List<Dictionary<string, object>> lstDic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            if (iLoaiKhachHang.EditValue.ToString() == "3")
            {
                if (_GiaoDich.Count == 0 && (iLoaiGiaoDich.EditValue.ToString() == "4" || iLoaiGiaoDich.EditValue.ToString() == "30"))
                {
                    XtraMessageBox.Show("Không có giao dịch để thanh toán");
                    return;
                }
                dic.Add("IDGiaoDich", string.Join(",", _GiaoDich.Select(w => w.ID).ToArray()));
                dic.Add("MaCode", string.Join(",", _GiaoDich.Select(w => w.MaCho).Distinct().ToArray()));
            }
            bool ThanhCong = false;
            switch ((int)iLoaiGiaoDich.EditValue)
            {
                case 23:
                case 24:
                    #region Dic
                    Dictionary<string, object> dicnh = new Dictionary<string, object>();
                    dicnh.Add("NgayGD", iNgayGD.DateTime);
                    dicnh.Add("NganHangID", iMaDL.EditValue);
                    dicnh.Add("MaDL", iNganHangID.EditValue);
                    dicnh.Add("SoTien", 0 - iSoTien.Value);
                    dicnh.Add("GhiChu", iGhiChu.Text);
                    dicnh.Add("TrangThaiID", iTrangThaiID.EditValue);
                    dicnh.Add("NgayHT", iNgayHT.DateTime);
                    dicnh.Add("LoaiGiaoDich", ((int)iLoaiGiaoDich.EditValue % 2 == 0) ? int.Parse(iLoaiGiaoDich.EditValue.ToString()) - 1 : int.Parse(iLoaiGiaoDich.EditValue.ToString()) + 1);
                    dicnh.Add("LoaiKhachHang", iLoaiKhachHang.EditValue);
                    dicnh.Add("NVGiaoDich", iNVGiaoDich.EditValue);
                    dicnh.Add("GhiChuNV", iGhiChuNV.Text);
                    if (CTM.ID == 0)
                    {
                        string Ma = ct.LayGioServer().ToString("yyyyMMddhhmmssttt");
                        dicnh.Add("MaLienKet", Ma);
                        dic.Add("MaLienKet", Ma);
                        lstDic.Add(dic);
                        lstDic.Add(dicnh);
                        ThanhCong = ct.ThemNhieu1Ban(lstDic) > 1;
                    }
                    else
                    {
                        List<string> lstCTV = new List<string>() { string.Format("WHERE ID = {0}", CTM.ID), string.Format("WHERE ID = {0}", ID) };
                        lstDic.Add(dic);
                        lstDic.Add(dicnh);
                        if ((int)iLoaiGiaoDich.EditValue != CTM.LoaiGiaoDich)
                        {
                            string Ma = ct.LayGioServer().ToString("yyyyMMddhhmmssttt");
                            dicnh.Add("MaLienKet", Ma);
                            dic.Add("MaLienKet", Ma);
                            List<string> lstTb = new List<string>();
                            List<string> lstThem = new List<string>();
                            lstThem.Add("S");
                            lstThem.Add("T");
                            lstTb.Add("CTNGANHANG");
                            lstTb.Add("CTNGANHANG");
                            ThanhCong = ct.CapNhat_ThemNhieu(lstDic, lstTb, lstCTV, lstThem) > 1;
                        }
                        else
                            ThanhCong = ct.SuaNhieu1Ban(lstDic, lstCTV) > 1;
                    }
                    #endregion
                    break;
                default:
                    ThanhCong = ((CTM.ID == 0) ? ct.ThemMoi(dic) : ct.CapNhat(dic, CTM.ID)) > 0;
                    break;
            }

            if (XuLyGiaoDien.ThongBao(iLoaiGiaoDich.Text + (CTM.ID != 0 ? " sửa" : " thêm"), ThanhCong))
            {
                new NganHangD().ChayLaiSD();
                if (new List<int>() { 1, 2, 3 }.Contains((int)iLoaiKhachHang.EditValue))
                {
                    if (CTM.NgayGD < iNgayHT.DateTime)
                        new DaiLyD().ChayLaiPhi(CTM.NgayGD);
                    else
                        new DaiLyD().ChayLaiPhi(((DateTime)iNgayHT.EditValue));
                    if ((int)iLoaiKhachHang.EditValue == 3)
                    {
                        if (_GiaoDichOLD.Count > 0)
                        {
                            XuLiKhachLE(_GiaoDichOLD, false);
                            XuLiKhachLE(_GiaoDich, true);
                        }
                        else
                            XuLiKhachLE(_GiaoDich, true);
                    }
                }
                if (CTM.NganHangID == 1)
                { (Owner.ActiveMdiChild as frmTienMat).TaiLaiDuLieu(); }
                else
                {
                    (Owner.ActiveMdiChild as frmNganHang).LayDLNganHang();
                    (Owner.ActiveMdiChild as frmNganHang).TaiLaiDuLieu();
                }
                GhiChuCmt(CTM.ID);
                Close();
            }
        }

        void XuLiKhachLE(List<GiaoDichO> g, bool a)
        {
            List<Dictionary<string, object>> lstdic2 = new List<Dictionary<string, object>>();
            List<string> CTV = new List<string>();
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int i = 0; i < g.Count; i++)
            {
                GiaoDichO gd = g[i];

                dic2 = new Dictionary<string, object>();

                CTV.Add(string.Format("WHERE ID = {0}", gd.ID));
                dic2.Add("Khoa", a);
                if (gd.SMS == true)
                    dic2.Add("NgayCuonChieu", iNgayHT.DateTime);
                lstdic2.Add(dic2);
            }

            new GiaoDichD().SuaNhieu1Ban(lstdic2, CTV);
        }

        #region Tạo Ghi Chú
        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", string.Empty);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", iLoaiKhachHang.EditValue);
                dic.Add("Ma", iMaDL.EditValue);
                if (NoiDung.Length > 10)
                    new LichSuD().ThemMoi(dic);
            }
        }
        #endregion

        #endregion

        private void btnLS_Click(object sender, EventArgs e)
        {
            if ((int)iNganHangID.EditValue > 0)
                new frmNganHangKL(iNganHangID.EditValue, (int)iLoaiGiaoDich.EditValue == 30 ? true : false, iMaDL.EditValue, false, _GiaoDich).ShowDialog(this);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if ((int)iNganHangID.EditValue > 0)
                new frmNganHangKL(iNganHangID.EditValue, (int)iLoaiGiaoDich.EditValue == 30 ? true : false, iMaDL.EditValue, true, _GiaoDich).ShowDialog(this);
        }

        private void frmNganHangCTThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
            else if (e.Alt && e.KeyCode == Keys.A)
                btnAll.PerformClick();
        }

        private void GVNCC_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            GridSummaryItem summary = e.Info.SummaryItem;
            if (e.Column.FieldName == "GiaThu" && (summary.Tag ?? 0).ToString() == "1")
                e.Info.DisplayText = _GiaoDich.Sum(w => w.GiaThu + w.GiaHeThong - w.GiaHoan).ToString("#,##0");
        }
    }
}
