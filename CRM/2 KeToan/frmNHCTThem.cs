using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNHCTThem : DevExpress.XtraEditors.XtraForm
    {
        public frmNHCTThem(bool isTienMat)
        {
            InitializeComponent();
            CTM = new O_CTNGANHANG();
            CTM.NgayGD = CTM.NgayHT = CTM.NgayTT = DateTime.Now;
            CTM.NganHangID = isTienMat ? 1 : 0;
            iNganHangID.Enabled = !isTienMat;
            groupControl1.Enabled = false;
            _NganHang = new D_NGANHANG().DuLieu(isTienMat);
            nganHangNguonBindingSource.DataSource = _NganHang;
        }

        public frmNHCTThem(O_CTNGANHANG ct, int MaLienKet)
        {
            InitializeComponent();
            CTM = ct;
            iMaDL.Enabled = iLoaiGiaoDich.Enabled = iLoaiKhachHang.Enabled = ct.LoaiKhachHang != 7;
            iNganHangID.Enabled = false;
            ID = MaLienKet;

            List<O_BAOCAOCTNH> g = new D_BAOCAOCTNH().DuLieu(CTM.ID);
            foreach (O_BAOCAOCTNH gz in g)
            {
                O_BAOCAOCTNH gza = gz;
                _GiaoDich.Add(gza);
                _GiaoDichOLD.Add(gza);
            }
            baoCaoCTNHOBindingSource.DataSource = _GiaoDich;
            _NganHang = new D_NGANHANG().All();
            nganHangNguonBindingSource.DataSource = _NganHang;
        }


        private void frmThemGiaoDichTK_Load(object sender, EventArgs e)
        {
            loaiGiaoDichOBindingSource.DataSource = new D_LOAIGIAODICH().DuLieu_NganHang_TheoLoai(0, true);
            DataLoaiKhach.DataSource = DuLieuTaoSan.LoaiKhachHang_NganHang();
           
            nhanVienOBindingSource.DataSource = new D_DAILY().NhanVien();
            IntStringBindingSource.DataSource = DuLieuTaoSan.TrangThai_NganHang();

            if (CTM.NVGiaoDich < 1)
                CTM.NVGiaoDich = ClsDuLieu.NhanVien.ID;

            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, CTM);
            ClsChucNang.OpenForm(this);
            if (!CTM.TrangThaiID)
                iTrangThaiID.EditValue = true;

        }

        #region Biến
        int ID = 0;
        List<O_BAOCAOCTNH> _GiaoDichOLD = new List<O_BAOCAOCTNH>();
        List<O_BAOCAOCTNH> _GiaoDich = new List<O_BAOCAOCTNH>();
        List<O_NGANHANG> _NganHang = new List<O_NGANHANG>();
        O_CTNGANHANG CTM;
        D_CTNGANHANG ct = new D_CTNGANHANG();
        #endregion

        #region Sự kiện nút

        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            int LoaiKhachHang = (int)iLoaiKhachHang.EditValue;
            loaiGiaoDichOBindingSource.DataSource = new D_LOAIGIAODICH().DuLieu_NganHang_TheoLoai(LoaiKhachHang, false);
            DataTen.DataSource = DuLieuTaoSan.NganHangLoaiKhachHang(LoaiKhachHang, (int)(iNganHangID.EditValue ?? 0));

            colName2.Visible = LoaiKhachHang == 1;
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
            O_LOAIGIAODICH _NCCO = iLoaiGiaoDich.GetSelectedDataRow() as O_LOAIGIAODICH;
            decimal a = iSoTien.Value;
            if (_NCCO != null)
            {
                if (_NCCO.Am && _NCCO.Duong)
                {
                    iSoTien.Properties.MaxValue = 20000000000;
                    iSoTien.Properties.MinValue = -20000000000;
                }
                else
                {

                    if (_NCCO.Duong)
                        iSoTien.Properties.MaxValue = 20000000000;
                    else
                        iSoTien.Properties.MaxValue = 0;

                    if (_NCCO.Am)
                        iSoTien.Properties.MinValue = -20000000000;
                    else
                        iSoTien.Properties.MinValue = 0;
                }

                if ((iSoTien.Properties.MinValue == 0 && a < 0) || (iSoTien.Properties.MaxValue == 0 && a > 0))
                    iSoTien.Value = 0 - a;
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
            if (gridView2.RowCount > 0 && gridView2.Columns["SoTien"].SummaryItem.SummaryValue.ToString() != (iSoTien.Value * (iLoaiKhachHang.EditValue.ToString() == "8" ? -1 : 1)).ToString())
            {
                XuLyGiaoDien.Alert("Tổng tiền chi tiết không bằng giao dịch", Form_Alert.enmType.Warning);
                return;
            }

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

            bool ThanhCong = false;
            if (int.Parse(iLoaiKhachHang.EditValue.ToString()) == 7)
            {
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
                    List<string> lstCTV = new List<string>() { string.Format("WHERE ID = {0}", CTM.ID), string.Format("WHERE MaLienKet = '{1}' and ID <> {0}", CTM.ID, CTM.MaLienKet) };
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
            }
            else
                ThanhCong = ((CTM.ID == 0) ? ct.ThemMoi(dic) : ct.CapNhat(dic, CTM.ID)) > 0;

            if (XuLyGiaoDien.ThongBao(iLoaiGiaoDich.Text + (CTM.ID != 0 ? " sửa" : " thêm"), ThanhCong))
            {
                if (_GiaoDichOLD.Count > 0 || _GiaoDich.Count > 0)
                {
                    List<Dictionary<string, object>> lstDicT = new List<Dictionary<string, object>>();
                    List<string> lstTb = new List<string>();
                    List<string> lstThem = new List<string>();
                    List<string> lstCTV = new List<string>();
                    foreach (O_BAOCAOCTNH d in _GiaoDich)
                    {
                        if (_GiaoDichOLD.Contains(d))
                        {
                            lstDicT.Add(XuLyDuLieu.ConvertClassToDic(d));
                            lstThem.Add("S");
                        }
                        else
                        {
                            lstDicT.Add(XuLyDuLieu.ConvertClassToDic(d));
                            lstThem.Add("T");
                        }
                        lstCTV.Add(string.Format("WHERE ID = {0}", d.ID));
                        lstTb.Add("BAOCAOCTNH");
                    }
                    new D_BAOCAOCTNH().CapNhat_ThemNhieu(lstDicT, lstTb, lstCTV, lstThem);

                    List<object> lstCTVBC = new List<object>();
                    foreach (O_BAOCAOCTNH d in _GiaoDichOLD)
                    {
                        if (!_GiaoDich.Contains(d))
                            lstCTVBC.Add(d.ID);
                    }

                    if (lstCTVBC.Count > 0)
                        new D_BAOCAOCTNH().XoaNhieu1Ban(lstCTVBC, "BAOCAOCTNH");
                }
                new D_NGANHANG().ChayLaiSD();
                O_LOAIGIAODICH _NCCO = iLoaiGiaoDich.GetSelectedDataRow() as O_LOAIGIAODICH;
                if (CTM.NganHangID == 1)
                { (Owner.ActiveMdiChild as frmTienMat).TaiLaiDuLieu(); }
                else
                {
                    (Owner.ActiveMdiChild as frmNganHang).LayDLNganHang();
                    (Owner.ActiveMdiChild as frmNganHang).TaiLaiDuLieu(true);
                }
                GhiChuCmt(CTM.ID);
                Close();
            }
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
                dic.Add("NVGiaoDich", ClsDuLieu.NhanVien.ID);
                dic.Add("LoaiKhachHang", iLoaiKhachHang.EditValue);
                dic.Add("Ma", iMaDL.EditValue);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
            }
        }
        #endregion

        #endregion

        private void frmNHCTThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (new int[] { 0, 1, 2, 3, 8 }.Contains(int.Parse(iLoaiKhachHang.EditValue.ToString())))
            {
                if ((iMaDL.Text ?? "").ToString().Length < 1 && iLoaiKhachHang.EditValue.ToString() == "8")
                {
                    XuLyGiaoDien.ShowToolTip(iMaDL, "Chọn nhà cung cấp");
                    return;
                }

                switch (e.Button.Properties.Caption)
                {
                    case "Hoàn":
                        new frmNHVH(int.Parse(iMaDL.EditValue.ToString()), iLoaiKhachHang.EditValue.ToString() == "8", CTM.ID).ShowDialog(this);
                        break;
                    case "Vé":
                        new frmNHV(int.Parse(iMaDL.EditValue.ToString()), iLoaiKhachHang.EditValue.ToString() == "8", CTM.ID).ShowDialog(this);
                        break;
                    case "Cấn trừ KS":
                        new frmNHKSCT(iLoaiKhachHang.EditValue.ToString() == "8", CTM.ID).ShowDialog(this);
                        break;
                    default:
                        new frmNHKS(int.Parse(iMaDL.EditValue.ToString()), iLoaiKhachHang.EditValue.ToString() == "8", CTM.ID).ShowDialog(this);
                        break;
                }
            }
            else
                XuLyGiaoDien.ShowToolTip(iLoaiKhachHang, "Chọn nguồn tới không được hỗ trợ");
        }

        public void DSSOVE(List<O_BAOCAOCTNH> gd)
        {
            _GiaoDich.AddRange(gd);
            baoCaoCTNHOBindingSource.DataSource = null;
            baoCaoCTNHOBindingSource.DataSource = _GiaoDich;
            if (iSoTien.Value == 0)
            {
                iSoTien.Value = _GiaoDich.Sum(w => w.SoTien);
                if (iSoTien.Value == 0)
                    iSoTien.Value = _GiaoDich.Sum(w => w.SoTien);
            }
            gridView2.InvalidateFooter();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            O_BAOCAOCTNH c = (gridView2.GetRow(gridView2.GetSelectedRows()[0]) as O_BAOCAOCTNH);
            switch (c.LoaiGiaoDich)
            {
                case 1:
                case 2:
                    List<O_KHACHSAN> ks = new D_KHACHSAN().DuLieu_ID(c.IDGDLienKet);
                    new frmKhachSanThem(ks).ShowDialog(this);
                    break;
                case 3:
                case 0:
                    List<O_GIAODICH> gd = new D_GIAODICH().DuLieu_ID(c.IDGDLienKet);
                    new frmVeThem(gd).ShowDialog(this);
                    break;
            }
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            O_BAOCAOCTNH c = (gridView2.GetRow(gridView2.GetSelectedRows()[0]) as O_BAOCAOCTNH);
            _GiaoDich.Remove(c);
            baoCaoCTNHOBindingSource.DataSource = null;
            baoCaoCTNHOBindingSource.DataSource = _GiaoDich;
            gridView2.InvalidateFooter();
        }

    }
}
