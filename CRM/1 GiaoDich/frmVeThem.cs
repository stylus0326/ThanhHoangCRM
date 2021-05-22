using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using mshtml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmVeThem : DevExpress.XtraEditors.XtraForm
    {
        GiaoDichO _GiaoDichO = new GiaoDichO();
        GiaoDichD _GiaoDichD = new GiaoDichD();
        List<DaiLyO> _ListDaiLyO = new List<DaiLyO>();
        List<HangBayO> _ListHangBayO = new List<HangBayO>();
        List<TuyenBayO> _ListTuyenBayO = new List<TuyenBayO>();
        List<Dictionary<string, object>> _LSTDIC = new List<Dictionary<string, object>>();
        List<NCCO> _ListNCC = new List<NCCO>();
        int LoaiKhachHang = 0;
        public frmVeThem()
        {
            InitializeComponent();
            Text += " thêm";
            btnLS.Visible = false;
        }

        public frmVeThem(List<GiaoDichO> lst)
        {
            InitializeComponent();
            GCGD.EmbeddedNavigator.Buttons.Append.Visible = false;
            GCGD.EmbeddedNavigator.Buttons.Remove.Visible = false;
            _GiaoDichO = lst[0];
            DSGiaoDich.DataSource = lst;
            Text += " sửa";
        }

        private void frmVeThem_Load(object sender, EventArgs e)
        {
            chkDen.Checked = _GiaoDichO.SoLuongVe == 2;
            _ListDaiLyO = new DaiLyD().All();
            _ListHangBayO = new HangBayD().DuLieu();
            _ListTuyenBayO = new TuyenBayD().DuLieu();
            NhanVienDB.DataSource = new DaiLyD().NhanVien();
            LoaiKhachDB.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();
            LoaiVeDB.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve(true).Where(w => !w.ID.Equals(8) && !w.ID.Equals(9));
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            _ListNCC = new NCCD().DuLieu();
            NCCDB.DataSource = _ListNCC;
            tuyenBayOBindingSource.DataSource = _ListTuyenBayO;
            rHD.DataSource = DuLieuTaoSan.HinhThucHoaDon();
            iAn.Visible = DuLieuTaoSan.Q.VeAdmin;

            #region NVGiaoDich
            iNVGiaoDich.Properties.ReadOnly = _GiaoDichO.NVGiaoDich != DuLieuTaoSan.NV.ID;

            if (_GiaoDichO.NVGiaoDich == DuLieuTaoSan.NV.ID || _GiaoDichO.NVGiaoDich < 1 || DuLieuTaoSan.NV.MienPhat)
                _GiaoDichO.NVGiaoDich = DuLieuTaoSan.NV.ID;
            else if (_GiaoDichO.NVHoTro < 1 || DuLieuTaoSan.NV.MienPhat)
                _GiaoDichO.NVHoTro = DuLieuTaoSan.NV.ID;
            #endregion

            iGhiChu.Text = _GiaoDichO.GhiChu;
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _GiaoDichO);
            _LSTDIC = XuLyDuLieu.BanTamGrid(GVGD);
            XuLyGiaoDien.OpenForm(this);
            btnLuu.Visible = DuLieuTaoSan.Q.VeThemSua;
        }

        public void DuLieuKhachLe(long a)
        {
            _ListDaiLyO = new DaiLyD().All();
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            iIDKhachHang.EditValue = a;
        }

        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            LoaiKhachHang = (int)iLoaiKhachHang.EditValue;
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            HinhThucDB.DataSource = DuLieuTaoSan.HinhThuc_Ve(LoaiKhachHang);
            if (LoaiKhachHang != _GiaoDichO.LoaiKhachHang || iNganHang.EditValue == null)
            {
                iHTTT.EditValue = LoaiKhachHang == 3 ? 4 : 1;
                if (_GiaoDichO.ID == 0)
                    _GiaoDichO.HTTT = (int)iHTTT.EditValue;
            }
            btnAdd.Visible = LoaiKhachHang == 3;
        }

        private void iHTTT_EditValueChanged(object sender, EventArgs e)
        {
            switch ((int)iHTTT.EditValue)
            {
                case 3:
                    NganHangDB.DataSource = new NganHangD().DuLieu(true);
                    iNganHang.Properties.ReadOnly = false;
                    iNganHang.EditValue = 1;
                    break;
                case 4:
                    NganHangDB.DataSource = new NganHangD().DuLieu(false);
                    iNganHang.Properties.ReadOnly = false;
                    break;
                default:
                    NganHangDB.DataSource = null;
                    iNganHang.Properties.ReadOnly = true;
                    iNganHang.EditValue = null;
                    break;
            }
        }

        private void iNhaCungCap_EditValueChanged(object sender, EventArgs e)
        {
            if (NCCDB.Count > 0)
            {
                NCCO _NCCO = iNhaCungCap.GetSelectedDataRow() as NCCO;
                if (_NCCO != null)
                {
                    if ((_NCCO.HangBay ?? string.Empty).Length > 1)
                    {
                        string[] NCCA = _NCCO.HangBay.Split('|');
                        if (NCCA.Length > 0)
                        {
                            HangBayDB.DataSource = _ListHangBayO.Where(w => NCCA.Contains(w.ID.ToString())).ToList();
                            if ((int)iNhaCungCap.EditValue != _GiaoDichO.NhaCungCap)
                            {
                                iHang.EditValue = _ListHangBayO.Where(w => NCCA.Contains(w.ID.ToString())).ToList()[0].TenTat;
                                if (iHang.EditValue.ToString() == _GiaoDichO.Hang)
                                {
                                    HangBayO hb = _ListHangBayO.Where(w => w.TenTat.Equals(iHang.EditValue)).First();
                                    List<IntString> lstis = new List<IntString>();
                                    if (hb != null)
                                    {
                                        if (hb.LoaiVe != null)
                                        {
                                            string[] vs = hb.LoaiVe.Replace("\r", string.Empty).Split('\n');
                                            for (int i = 0; i < vs.Count(); i++)
                                            {
                                                if (vs[i].Length > 0)
                                                    lstis.Add(new IntString() { Name = vs[i] });
                                            }
                                            if (vs.Count() == 0)
                                                lstis.Add(new IntString() { Name = "Khác" });
                                        }
                                        else
                                            lstis.Add(new IntString() { Name = "Khác" });
                                        iLoaiVeDi.Properties.DataSource = lstis;
                                        iLoaiVeVe.Properties.DataSource = lstis;
                                        if (_GiaoDichO.LoaiVeDi.Length < 1)
                                            iLoaiVeDi.EditValue = iLoaiVeVe.EditValue = lstis.First().Name;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void iHang_EditValueChanged(object sender, EventArgs e)
        {
            HangBayO hb = _ListHangBayO.Where(w => w.TenTat.Equals(iHang.EditValue)).First();
            List<IntString> lstis = new List<IntString>();
            if (hb != null)
            {
                if (hb.LoaiVe != null)
                {
                    string[] vs = hb.LoaiVe.Replace("\r", string.Empty).Split('\n');
                    for (int i = 0; i < vs.Count(); i++)
                    {
                        if (vs[i].Length > 0)
                            lstis.Add(new IntString() { Name = vs[i] });
                    }
                    if (vs.Count() == 0)
                        lstis.Add(new IntString() { Name = "Khác" });
                }
                else
                    lstis.Add(new IntString() { Name = "Khác" });
                iLoaiVeDi.Properties.DataSource = lstis;
                iLoaiVeVe.Properties.DataSource = lstis;
                if ((_GiaoDichO.LoaiVeDi ?? string.Empty).Length < 1)
                    iLoaiVeDi.EditValue = iLoaiVeVe.EditValue = lstis.First().Name;
            }
        }

        private void iChieuDi_EditValueChanged(object sender, EventArgs e)
        {
            iTuyenBayVe.Properties.DataSource = _ListTuyenBayO.Where(w => !w.ID.Equals(iTuyenBayDi.EditValue));
            if (!chkDen.Checked)
            {
                string[] Tb = iTuyenBayDi.Text.Split('-');
                if (Tb.Length > 1)
                    iTuyenBayVe.EditValue = _ListTuyenBayO.Where(w => w.Ten.Equals(Tb[1] + "-" + Tb[0])).ToList()[0].ID;
            }
        }

        private void chkDen_CheckedChanged(object sender, EventArgs e)
        {
            iLoaiVeVe.Properties.ReadOnly = iHanhLyVe.Properties.ReadOnly = iSoHieuVe.Properties.ReadOnly =
           iTuyenBayVe.Properties.ReadOnly = iGioBayVe.Properties.ReadOnly = iGioBayVe_Den.Properties.ReadOnly = !chkDen.Checked;
            if (iGioBayVe.DateTime.Year < 2000)
                iGioBayVe.EditValue = iGioBayVe_Den.EditValue = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmKhachLeThem frm = new frmKhachLeThem();
            frm.ShowDialog(ParentForm);
        }

        private void GVGD_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            long GiaThu = 0;
            if ("GiaNet PhiCK PhiCoDinh HoaHong GiaHeThong".Contains(e.Column.FieldName))
            {
                foreach (GridColumn col in view.Columns)
                {
                    if ("GiaHeThong PhiCK PhiCoDinh HoaHong".Contains(col.FieldName))
                        GiaThu += long.Parse(view.GetRowCellValue(e.RowHandle, col).ToString());
                }
                view.SetRowCellValue(e.RowHandle, view.Columns["GiaThu"], GiaThu);
                view.SetRowCellValue(e.RowHandle, view.Columns["LoiNhuan"], GiaThu - (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaNet"]));
                if ((int)iLoaiKhachHang.EditValue == 3 && Text.EndsWith("thêm"))
                    view.SetRowCellValue(e.RowHandle, view.Columns["PhiCK"], (iIDKhachHang.GetSelectedDataRow() as DaiLyO).Phi);
            }
        }

        private void GVGD_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            switch (view.FocusedColumn.FieldName)
            {
                case "SoVeVN":
                    if (System.Text.RegularExpressions.Regex.IsMatch(e.Value as String, "[^0-9^-]"))
                    {
                        e.Valid = false;
                        e.ErrorText = "Chỉ nhập số";
                    }
                    break;
                case "Fare":
                case "GiaNet":
                case "PhiCK":
                case "PhiCoDinh":
                case "HoaHong":
                case "GiaHeThong":
                case "HangCK":
                    long a = 0;
                    if (!long.TryParse(e.Value as String, out a))
                    {
                        e.Valid = false;
                        e.ErrorText = "Chỉ nhập số";
                    }
                    break;
                case "HoaDon":
                    if (e.Value.ToString() == "2")
                        e.Value = 1;
                    break;
            }
        }

        private void GVGD_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                GVGD.ActiveEditor.SelectAll();
            }));
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            iGhiChu.Text += comboBoxEdit1.Text + " ";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region Bước kiểm tra nhập
            Dictionary<string, object> dic = new Dictionary<string, object>();

            KhoaNgayO kn = new KhoaNgayD().KiemTraNgayKhoa(_GiaoDichO.NgayGD);

            if (!(iLoaiKhachHang.EditValue.ToString() == "3" && _GiaoDichO.Khoa))
                if (_GiaoDichO.HTTT != 7)
                {
                    if (!DuLieuTaoSan.Q.VeAdmin)
                        if ((kn.HoatDong) && !(kn.Code ?? string.Empty).Contains(iMaCho.Text.Replace(" ", string.Empty)))
                        {
                            XuLyGiaoDien.Alert("Ngày đã bị khóa", Form_Alert.enmType.Warning);
                            return;
                        }
                    if (_GiaoDichO.Khoa)
                        if (DateTime.Now.Date.Subtract(iNgayGD.DateTime.Date).Days > 30 || DateTime.Now.Date.Subtract(_GiaoDichO.NgayGD.Date).Days > 30)
                        {
                            XuLyGiaoDien.Alert("Ngày đã bị khóa", Form_Alert.enmType.Warning);
                            return;
                        }
                }
                else
                    iNgayGD.DateTime = _GiaoDichO.NgayGD;

            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iNganHang, _Tu = 1, _Den = 50, _ChoQuaThang = iNganHang.Properties.ReadOnly });

            kiemTras.Add(new KiemTra() { _Control = iIDKhachHang, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iNhaCungCap, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iLoaiGiaoDich, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iHTTT, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iHang, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iMaCho, _Tu = 5, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iLoaiVeDi, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iTuyenBayDi, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iIDKhachHang, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iSoHieuVe, _ChoQuaThang = iGioBayVe.Properties.ReadOnly, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iLoaiVeVe, _ChoQuaThang = iLoaiVeVe.Properties.ReadOnly, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iTuyenBayVe, _ChoQuaThang = iTuyenBayVe.Properties.ReadOnly, _Tu = 1, _Den = 50 });

            if (!chkDen.Checked)
            {
                dic.Add("SoHieuVe", null);
                dic.Add("LoaiVeVe", null);
                dic.Add("HanhLyVe", null);
                dic.Add("TuyenBayVe", null);
                dic.Add("GioBayVe_Den", null);
                dic.Add("GioBayVe", null);
            }

            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("GhiChu", iGhiChu.Text);

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            if ((int)iHTTT.EditValue == 7)
                dic.Add("SMS", 1);
            dic.Add("SoLuongVe", (chkDen.Checked) ? 2 : 1);
            dic.Add("NgayCuonChieu", iNgayGD.DateTime);
            #endregion

            XulyDuLieuTruocKhiThem(dic);
        }

        void XulyDuLieuTruocKhiThem(Dictionary<string, object> Dic)
        {
            long a = 0;
            List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
            List<string> lstCTV = new List<string>();
            for (int i = 0; i < GVGD.RowCount; i++)
            {
                Dictionary<string, object> dicS = new Dictionary<string, object>(Dic);
                for (int y = 0; y < GVGD.Columns.Count; y++) //Dòng
                {
                    if (GVGD.Columns[y].Visible)//Cột
                    {
                        object G = GVGD.GetRowCellValue(i, GVGD.Columns[y]);
                        dicS.Add(GVGD.Columns[y].FieldName, G);
                    }
                    else if (y == GVGD.Columns.Count - 1)
                    {
                        object G = GVGD.GetRowCellValue(i, GVGD.Columns[y]);
                        lstCTV.Add(string.Format("WHERE ID = {0}", G));
                        lstDicS.Add(dicS);
                    }
                }
            }
            a = (_GiaoDichO.ID > 0) ? _GiaoDichD.SuaNhieu1Ban(lstDicS, lstCTV) : _GiaoDichD.ThemNhieu1Ban(lstDicS);
            if (XuLyGiaoDien.ThongBao(Text, a == lstDicS.Count))
            {
                GhiChuCmt(_GiaoDichO.ID);
                if (iLoaiKhachHang.EditValue.ToString() != "3")
                    new DaiLyD().ChayLaiPhi((_GiaoDichO.NgayGD > iNgayGD.DateTime) ? iNgayGD.DateTime : _GiaoDichO.NgayGD);
                (Owner.ActiveMdiChild as frmVe).DuLieu();
                Close();
            }
        }

        #region Tạo Ghi Chú
        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this) + XuLyDuLieu.GhiChuGrid(GVGD, _LSTDIC));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", iMaCho.Text);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                if (NoiDung.Length > 10)
                    new LichSuD().ThemMoi(dic);
            }
        }
        #endregion

        private void btnLS_Click(object sender, EventArgs e)
        {
            new frmLichSu(iMaCho.Text).ShowDialog();
        }

        #region Tạm thời
        NCCO hb = new NCCO();
        NCCGDD hbb = new NCCGDD();
        private void iMaCho_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private HtmlElement GetElementByClass(string tag, string classname)
        {
            HtmlElementCollection eles = wVJ.Document.GetElementsByTagName(tag);
            foreach (HtmlElement ele in eles)
            {
                if (ele.GetAttribute("className") == classname)
                {
                    return ele;
                }
            }
            return null;
        }

        List<GiaoDichO> _Mail = new List<GiaoDichO>();
        private int nSearch = 0;
        List<GiaoDichO> BanTam = new List<GiaoDichO>();
        TuyenBayD tbB = new TuyenBayD();
        SanBayD sbB = new SanBayD();

        private void wVJ_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wVJ.ReadyState == WebBrowserReadyState.Complete && !wVJ.IsBusy)
            {
                HtmlElement head = wVJ.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = wVJ.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;

                if (wVJ.Url.AbsolutePath.Contains("/EWRevisedItinerary.aspx")) // Thông tin chi tiết
                {
                    HtmlElementCollection tables = wVJ.Document.GetElementsByTagName("table");
                    HtmlElement tblThongTinDatCho = tables[1];
                    HtmlElementCollection tblThongTinDatCho_trs = tblThongTinDatCho.GetElementsByTagName("tr");

                    BanTam[0].NgayGD = DateTime.ParseExact(tables[tables.Count - 6].GetElementsByTagName("td")[0].InnerText, "dd/MM/yyyy", null);
                    for (int i = 0; i < BanTam.Count; i++)
                    {
                        string lienlac = tblThongTinDatCho_trs[0].GetElementsByTagName("td")[1].InnerText;
                        int idx = lienlac.IndexOf(' ');
                        if (idx > 0)
                            BanTam[i].DienThoaiKhachHang = lienlac.Substring(0, idx);
                        BanTam[i].EmailKhachHang = tblThongTinDatCho_trs[1].GetElementsByTagName("td")[1].InnerText;
                        if (BanTam[i].LoaiKhachHang < 1)
                        {
                            List<DaiLyO> Dl = _ListDaiLyO.Where(w => (w.EmailGiaoDich ?? string.Empty).ToUpper().Contains((BanTam[i].EmailKhachHang ?? string.Empty).ToUpper())
                            && (w.EmailGiaoDich ?? string.Empty).Length > 0 && (BanTam[i].EmailKhachHang ?? string.Empty).Length > 0).ToList();
                            if (Dl.Count > 0)
                            {
                                BanTam[i].IDKhachHang = Dl[0].ID;
                                BanTam[i].LoaiKhachHang = Dl[0].LoaiKhachHang;
                                BanTam[i].HTTT = 1;
                            }
                        }

                        if (BanTam[i].LoaiKhachHang == 0 && !(BanTam[i].EmailKhachHang ?? string.Empty).Contains("@THANHHOANG.VN"))
                        {
                            if (_Mail.Where(w => w.EmailKhachHang.ToLower().Contains(BanTam[i].EmailKhachHang.ToLower())).Count() > 0)
                            {
                                BanTam[i].LoaiKhachHang = 1;
                                BanTam[i].IDKhachHang = _Mail.Where(w => w.EmailKhachHang.ToLower().Contains(BanTam[i].EmailKhachHang.ToLower())).ToList()[0].IDKhachHang;
                                BanTam[i].HTTT = 1;
                            }
                        }

                    }
                    chkDen.Checked = BanTam[0].SoLuongVe == 2;
                    XuLyDuLieu.ConvertClassToTable(this, BanTam[0]);
                    DSGiaoDich.DataSource = BanTam;

                    if (XuLyGiaoDien.wait.IsSplashFormVisible)
                        XuLyGiaoDien.wait.CloseWaitForm();
                }
                else if (wVJ.Url.AbsolutePath.Contains("/EditRes.aspx"))
                {
                    HtmlElement CD = wVJ.Document.GetElementById("leg1");
                    HtmlElement CV = wVJ.Document.GetElementById("leg2");

                    HtmlElement Step1 = GetElementByClass("table", "hdrTable900");
                    int SLKhach = Step1.GetElementsByTagName("TR").Count - 1;
                    for (int i = 0; i < SLKhach; i++)
                    {
                        GiaoDichO GDTam = new GiaoDichO();
                        GDTam.SoLuongVe = 1;
                        GDTam.MaCho = iMaCho.Text.Replace(" ", string.Empty).ToUpper();
                        GDTam.NgayGD = DateTime.Now;
                        GDTam.NhaCungCap = hb.ID;
                        GDTam.NVGiaoDich = DuLieuTaoSan.NV.ID;
                        GDTam.LoaiKhachHang = 0;
                        GDTam.Hang = "VJ";
                        GDTam.TenKhach = Step1.GetElementsByTagName("TD")[1 + (i * 7)].InnerText.Replace(",", string.Empty);
                        GDTam.GiaNet = GDTam.GiaHeThong = GDTam.GiaThu = int.Parse(Step1.GetElementsByTagName("TD")[5 + (i * 7)].InnerText.Split(' ')[0].Replace(",", string.Empty));
                        if (CD != null)
                        {
                            if (CD.Document.GetElementById("grdPaxFareDetails") != null)
                            {
                                HtmlElementCollection CDCellData1 = CD.Document.GetElementById("grdPaxFareDetails").GetElementsByTagName("TD");
                                GDTam.Fare = long.Parse(new String(CDCellData1[2].InnerText.Where(Char.IsDigit).ToArray()));
                                GDTam.LoaiVeDi = CDCellData1[1].InnerText.Split('-')[1].Replace(" ", string.Empty);
                            }
                            else
                            {
                                GDTam.LoaiVeDi = "ECO";
                                GDTam.Fare = 0;
                            }

                            if (CD.Document.GetElementById("grdFlightInfo") != null)
                            {
                                HtmlElementCollection CDCellData2 = CD.Document.GetElementById("grdFlightInfo").GetElementsByTagName("TD");
                                GDTam.SoHieuDi = CDCellData2[1].InnerText;
                                GDTam.TuyenBayDi = tbB.TuyenBay(sbB.SanBay(CDCellData2[2].InnerText.Split(' ')[1]).ID, sbB.SanBay(CDCellData2[3].InnerText.Split(' ')[1]).ID).ID;
                                GDTam.GioBayDi = DateTime.ParseExact(CDCellData2[0].InnerText.Substring(0, CDCellData2[0].InnerText.IndexOf(' ')) + " " + CDCellData2[2].InnerText.Split(' ')[0], "dd/MM/yyyy H:mm", null);
                                GDTam.GioBayDi_Den = DateTime.ParseExact(CDCellData2[0].InnerText.Substring(0, CDCellData2[0].InnerText.IndexOf(' ')) + " " + CDCellData2[3].InnerText.Split(' ')[0], "dd/MM/yyyy H:mm", null);
                            }
                        }

                        if (CV != null)
                        {
                            if (CV.GetElementsByTagName("tbody")[0].Document.GetElementById("grdPaxFareDetails") != null)
                            {
                                HtmlElementCollection CVCellData1 = CV.GetElementsByTagName("tbody")[0].Document.GetElementById("grdPaxFareDetails").GetElementsByTagName("TD");
                                GDTam.Fare += long.Parse(new String(CVCellData1[2].InnerText.Where(Char.IsDigit).ToArray()));
                                GDTam.LoaiVeVe = CVCellData1[1].InnerText.Split('-')[1].Replace(" ", string.Empty);
                            }

                            if (CV.GetElementsByTagName("tbody")[0].Document.GetElementById("grdFlightInfo") != null)
                            {
                                HtmlElementCollection CVCellData2 = CV.GetElementsByTagName("tbody")[0].Document.GetElementById("grdFlightInfo").GetElementsByTagName("TD");
                                GDTam.SoHieuVe = CVCellData2[1].InnerText;
                                GDTam.TuyenBayVe = tbB.TuyenBay(sbB.SanBay(CVCellData2[2].InnerText.Split(' ')[1]).ID, sbB.SanBay(CVCellData2[3].InnerText.Split(' ')[1]).ID).ID;
                                GDTam.GioBayVe = DateTime.ParseExact(CVCellData2[0].InnerText.Substring(0, CVCellData2[0].InnerText.IndexOf(' ')) + " " + CVCellData2[2].InnerText.Split(' ')[0], "dd/MM/yyyy H:mm", null);
                                GDTam.GioBayVe_Den = DateTime.ParseExact(CVCellData2[0].InnerText.Substring(0, CVCellData2[0].InnerText.IndexOf(' ')) + " " + CVCellData2[3].InnerText.Split(' ')[0], "dd/MM/yyyy H:mm", null);
                            }
                        }

                        BanTam.Add(GDTam);
                    }
                    element.text = "function doPost() { document.forms['Edit'].button.value='newitinerary';SubmitForm(); }";
                    head.AppendChild(scriptEl);
                    wVJ.Document.InvokeScript("doPost");
                }
                else if (wVJ.Url.AbsolutePath.Contains("/SearchRes.aspx"))
                {
                    if (nSearch == 0)
                    {
                        nSearch++;
                        wVJ.Document.GetElementById("txtSearchResNum").SetAttribute("value", iMaCho.Text);
                        wVJ.Document.GetElementById("Search").InvokeMember("submit");
                    }
                    else
                    {
                        nSearch = 0;
                        HtmlElement error = GetElementByClass("p", "ErrorCaption");
                        if (error != null)
                        {
                            XtraMessageBox.Show("Mã chỗ không tồn tại");
                            return;
                        }
                        else
                        {
                            element.text = "function doPost() { document.forms['Search'].button.value='continue';pop('?lang=vi'); setTimeout('document.forms[\"Search\"].submit()', 100); }";
                            head.AppendChild(scriptEl);
                            wVJ.Document.InvokeScript("doPost");
                        }
                    }
                }
                else if (wVJ.Url.AbsolutePath.Contains("/AgentOptions.aspx"))//Đăng nhập thành công
                {
                    wVJ.Navigate("https://agents.vietjetair.com/SearchRes.aspx?lang=vi&st=sl&sesid=");
                }
                else if (wVJ.Url.AbsolutePath.Contains("/sitelogin.aspx"))//Bước đăng nhập
                {
                    head = wVJ.Document.GetElementById("wrapper");
                    if (head != null)
                        if (head.InnerText.ToLower().Contains("mật khẩu chưa đúng") || head.InnerText.ToLower().Contains("wrong password input"))
                            Close();

                    wVJ.Document.GetElementById("txtAgentID").SetAttribute("value", hb.TaiKhoan);
                    wVJ.Document.GetElementById("txtAgentPswd").SetAttribute("value", hb.MatKhau);
                    wVJ.Document.GetElementById("SiteLogin").InvokeMember("submit");
                }
                else if (wVJ.Url.AbsolutePath.Contains("/Home"))
                {
                    element.text = "function doPost() { location.href = 'https://agents.vietjetair.com/sitelogin.aspx?lang=vi'; }";
                    head.AppendChild(scriptEl);
                    wVJ.Document.InvokeScript("doPost");
                }
            }
        }


        #endregion

        private void btnCode_Click(object sender, EventArgs e)
        {
            //1128, 573
            Width = (Width == 1128) ? 799 : 1128;
            Location = new System.Drawing.Point((Width == 1128) ? Location.X - 165 : Location.X + 165, Location.Y);
        }

        string[] lines;
        private void mText_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(22))
                {
                    MemoEdit me = new MemoEdit();
                    me.Text = Clipboard.GetText(TextDataFormat.UnicodeText).Replace("  ", " ").Replace("\r\n\r\n", "\r\n");
                    lines = me.Lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    List<string> strlst = lines.ToList();

                    for (int i = 2; i < lines.Length; i++)
                    {
                        switch (i)
                        {
                            case 2:
                                if (!strlst[2].Contains("về chuyến bay") && !strlst[2].Contains("Flight details"))
                                { strlst.Remove(strlst[2]); i--; }
                                break;
                            case 3:
                                string[] Az3 = strlst[3].Split('-');
                                if (Az3.Length == 3)
                                    strlst[3] = Az3[0] + "-" + Az3[2];
                                break;
                            case 5:
                                string[] Az5 = strlst[3].Replace(" ", string.Empty).Split('-');
                                if (!strlst[5].Contains(Az5[0].Substring(Az5[0].Length - 3, 3)))
                                { strlst.Remove(strlst[5]); i--; }
                                break;
                            case 8:
                                string[] Az8 = strlst[3].Replace(" ", string.Empty).Split('-');
                                if (!strlst[8].Contains(Az8[1]))
                                { strlst.Remove(strlst[8]); i--; }
                                break;
                            default:
                                if (i > 10 && me.Text.Contains("Chiều về"))
                                {
                                    switch (i)
                                    {
                                        case 11:
                                            string[] Az11 = strlst[11].Split('-');
                                            if (Az11.Length == 3)
                                                strlst[11] = Az11[0] + "-" + Az11[2];
                                            break;
                                        case 13:
                                            string[] Az13 = strlst[11].Replace(" ", string.Empty).Split('-');
                                            if (!strlst[13].Contains(Az13[0].Substring(Az13[0].Length - 3, 3)))
                                            { strlst.Remove(strlst[13]); i--; }
                                            break;
                                        case 16:
                                            string[] Az16 = strlst[11].Replace(" ", string.Empty).Split('-');
                                            if (!strlst[16].Contains(Az16[1]))
                                            { strlst.Remove(strlst[16]); i--; }
                                            break;
                                    }
                                }
                                break;
                        }

                    }
                    lines = strlst.ToArray();
                    Clipboard.SetText(string.Join(System.Environment.NewLine, lines), TextDataFormat.UnicodeText);
                }
            }
            catch { }
        }

        private void mText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && mText.Text != string.Empty)
            {
                GiaoDichO giaoDichO = new GiaoDichO();
                List<GiaoDichO> giaoDichOs = new List<GiaoDichO>();
                mText.Text = mText.Text.Replace("  ", " ");
                lines = mText.Lines;
                SanBayD sbB = new SanBayD();
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] Az;
                    switch (i)
                    {
                        case 0:
                            giaoDichO.MaCho = lines[0].Split('/')[0];
                            break;
                        default:
                            if (lines[i].Length < 3)
                                break;

                            if (giaoDichO.SoLuongVe == 0)
                            {
                                if (lines[i].Substring(0, 5).Contains(" ."))
                                {
                                    Az = lines[i].Split('.')[1].TrimStart().Replace("  ", " ").Split(' ');
                                    giaoDichO.Hang = Az[0];
                                    giaoDichO.SoHieuDi = Az[0] + Az[1];
                                    giaoDichO.LoaiVeDi = Az[2];
                                    giaoDichO.SoLuongVe = 1;
                                    giaoDichO.GioBayDi = DateTime.ParseExact(Az[3] + DateTime.Now.Year + Az[6].Replace("#", string.Empty), "ddMMMyyyyHHmm", CultureInfo.InvariantCulture);
                                    giaoDichO.GioBayDi_Den = DateTime.ParseExact(Az[3] + DateTime.Now.Year + Az[7].Replace("#", string.Empty), "ddMMMyyyyHHmm", CultureInfo.InvariantCulture);
                                    giaoDichO.TuyenBayDi = new TuyenBayD().TuyenBay(sbB.SanBay(Az[4].Substring(0, 3)).ID, sbB.SanBay(Az[4].Substring(3, 3)).ID).ID;
                                    if (giaoDichO.TuyenBayDi == 0)
                                    { XtraMessageBox.Show("Tuyến bay không tồn tại", "Thông báo"); return; }
                                }
                            }
                            else
                            {
                                if (lines[i].Substring(0, 5).Contains(" ."))
                                {
                                    Az = lines[i].Split('.')[1].TrimStart().Replace("  ", " ").Split(' ');
                                    giaoDichO.SoHieuVe = Az[0] + Az[1];
                                    giaoDichO.LoaiVeVe = Az[2];
                                    giaoDichO.SoLuongVe = 2;
                                    giaoDichO.GioBayVe = DateTime.ParseExact(Az[3] + DateTime.Now.Year + Az[6].Replace("#", string.Empty), "ddMMMyyyyHHmm", CultureInfo.InvariantCulture);
                                    giaoDichO.GioBayVe_Den = DateTime.ParseExact(Az[3] + DateTime.Now.Year + Az[7].Replace("#", string.Empty), "ddMMMyyyyHHmm", CultureInfo.InvariantCulture);
                                    giaoDichO.TuyenBayVe = new TuyenBayD().TuyenBay(sbB.SanBay(Az[4].Substring(0, 3)).ID, sbB.SanBay(Az[4].Substring(3, 3)).ID).ID;
                                    if (giaoDichO.TuyenBayVe == 0)
                                    { XtraMessageBox.Show("Tuyến bay không tồn tại", "Thông báo"); return; }
                                }
                                else if (lines[i].Contains("/"))
                                {
                                    Az = lines[i].Split('-');
                                    if (Az.Length == 3)
                                        giaoDichOs.Add(new GiaoDichO()
                                        {
                                            TenKhach = Az[0].TrimStart(),
                                            SoVeVN = Az[1].Replace("/", string.Empty),
                                            GiaNet = long.Parse(Az[2].Split('/')[1]),
                                            GiaHeThong = long.Parse(Az[2].Split('/')[1]),
                                            GiaThu = long.Parse(Az[2].Split('/')[1]),
                                        });
                                    else
                                        giaoDichOs.Add(new GiaoDichO()
                                        {
                                            TenKhach = Az[0].TrimStart(),
                                            SoVeVN = (Az[1] + "-" + Az[2]).Replace("/", string.Empty),
                                            GiaNet = long.Parse(Az[3].Split('/')[1]),
                                            GiaHeThong = long.Parse(Az[3].Split('/')[1]),
                                            GiaThu = long.Parse(Az[3].Split('/')[1]),
                                        });
                                }
                            }
                            break;
                    }
                }
                chkDen.Checked = giaoDichO.SoLuongVe == 2;
                giaoDichO.NVGiaoDich = DuLieuTaoSan.NV.ID;
                XuLyDuLieu.ConvertClassToTable(this, giaoDichO);
                DSGiaoDich.DataSource = giaoDichOs;
            }
        }

        private void frmVeThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}