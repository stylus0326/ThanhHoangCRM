using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmVeThem : DevExpress.XtraEditors.XtraForm
    {
        O_GIAODICH _GiaoDichO = new O_GIAODICH();
        D_GIAODICH _GiaoDichD = new D_GIAODICH();
        List<O_DAILY> _ListDaiLyO = new List<O_DAILY>();
        List<O_HANGBAY> _ListHangBayO = new List<O_HANGBAY>();
        List<O_TUYENBAY> _ListTuyenBayO = new List<O_TUYENBAY>();
        List<Dictionary<string, object>> _LSTDIC = new List<Dictionary<string, object>>();
        List<O_NHACUNGCAP> _ListNCC = new List<O_NHACUNGCAP>();
        int LoaiKhachHang = 0;
        public frmVeThem()
        {
            InitializeComponent();
            Text += " thêm";
            btnLS.Visible = false;
        }

        public frmVeThem(List<O_GIAODICH> lst)
        {
            InitializeComponent();
            GCGD.EmbeddedNavigator.Buttons.Append.Visible = false;
            GCGD.EmbeddedNavigator.Buttons.Remove.Visible = false;
            _GiaoDichO = lst[0];
            DSGiaoDich.DataSource = lst;
            Text += " sửa";
        }

        public frmVeThem(O_GIAODICH lst)
        {
            InitializeComponent();
            GCGD.EmbeddedNavigator.Buttons.Append.Visible = false;
            GCGD.EmbeddedNavigator.Buttons.Remove.Visible = false;
            _GiaoDichO = lst;
            DSGiaoDich.DataSource = lst;
            Text += " xem";
            btnLuu.Visible = false;
        }

        private void frmVeThem_Load(object sender, EventArgs e)
        {
            chkDen.Checked = _GiaoDichO.SoLuongVe == 2;
            _ListDaiLyO = new D_DAILY().All();
            _ListHangBayO = new D_HANGBAY().DuLieu();
            _ListTuyenBayO = new D_TUYENBAY().DuLieu();
            NhanVienDB.DataSource = new D_DAILY().NhanVien();
            LoaiKhachDB.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();
            LoaiVeDB.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve(true).Where(w => !w.ID.Equals(8) && !w.ID.Equals(9));
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            _ListNCC = new D_NHACUNGCAP().DuLieu();
            NCCDB.DataSource = _ListNCC;
            tuyenBayOBindingSource.DataSource = _ListTuyenBayO;
            rHD.DataSource = DuLieuTaoSan.HinhThucHoaDon();
            iAn.Visible = ClsDuLieu.Quyen.VeAdmin;

            #region NVGiaoDich
            iNVGiaoDich.Properties.ReadOnly = _GiaoDichO.NVGiaoDich != ClsDuLieu.NhanVien.ID;

            if (_GiaoDichO.NVGiaoDich == ClsDuLieu.NhanVien.ID || _GiaoDichO.NVGiaoDich < 1 || ClsDuLieu.NhanVien.MienPhat)
                _GiaoDichO.NVGiaoDich = ClsDuLieu.NhanVien.ID;
            else if (_GiaoDichO.NVHoTro < 1 || ClsDuLieu.NhanVien.MienPhat)
                _GiaoDichO.NVHoTro = ClsDuLieu.NhanVien.ID;
            #endregion

            iGhiChu.Text = _GiaoDichO.GhiChu;
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _GiaoDichO);
            _LSTDIC = XuLyDuLieu.BanTamGrid(GVGD);
            ClsChucNang.OpenForm(this);
            btnLuu.Visible = ClsDuLieu.Quyen.VeThemSua;
        }

        public void DuLieuKhachLe(long a)
        {
            _ListDaiLyO = new D_DAILY().All();
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
        }

        private void iHTTT_EditValueChanged(object sender, EventArgs e)
        {
            switch ((int)iHTTT.EditValue)
            {
                case 3:
                    NganHangDB.DataSource = new D_NGANHANG().DuLieu(true);
                    iNganHang.Properties.ReadOnly = false;
                    iNganHang.EditValue = 1;
                    break;
                case 4:
                    NganHangDB.DataSource = new D_NGANHANG().DuLieu(false);
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
                O_NHACUNGCAP _NCCO = iNhaCungCap.GetSelectedDataRow() as O_NHACUNGCAP;
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
                                    O_HANGBAY hb = _ListHangBayO.Where(w => w.TenTat.Equals(iHang.EditValue)).First();
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
            O_HANGBAY hb = _ListHangBayO.Where(w => w.TenTat.Equals(iHang.EditValue)).First();
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

        private void GVGD_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            long GiaThu = 0;
            if (new string[] { "GiaNet", "PhiCK", "PhiCoDinh", "HoaHong", "GiaHeThong" }.Contains(e.Column.FieldName))
            {
                foreach (GridColumn col in view.Columns)
                {
                    if (new string[] { "PhiCK", "PhiCoDinh", "HoaHong", "GiaHeThong" }.Contains(col.FieldName))
                        GiaThu += long.Parse(view.GetRowCellValue(e.RowHandle, col).ToString());
                }
                view.SetRowCellValue(e.RowHandle, view.Columns["GiaThu"], GiaThu);
                view.SetRowCellValue(e.RowHandle, view.Columns["LoiNhuan"], GiaThu - (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaNet"]));
                if ((int)iLoaiKhachHang.EditValue == 3 && Text.EndsWith("thêm"))
                    view.SetRowCellValue(e.RowHandle, view.Columns["PhiCK"], (iIDKhachHang.GetSelectedDataRow() as O_DAILY).Phi);
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

            O_KHOANGAY kn = new D_KHOANGAY().KiemTraNgayKhoa(_GiaoDichO.NgayGD);

            if (_GiaoDichO.TinhCongNo)
            {
                if (!ClsDuLieu.Quyen.TheoDoiHoanAdmin)
                    if ((kn.HoatDong) && !(kn.Code ?? string.Empty).Contains(iMaCho.Text.Replace(" ", string.Empty)))
                    {
                        XuLyGiaoDien.Alert("Ngày đã bị khóa", Form_Alert.enmType.Warning);
                        return;
                    }

                if (DateTime.Now.Date.Subtract(iNgayGD.DateTime.Date).Days > 30 || DateTime.Now.Date.Subtract(_GiaoDichO.NgayGD.Date).Days > 30)
                {
                    XuLyGiaoDien.Alert("Ngày đã bị khóa", Form_Alert.enmType.Warning);
                    return;
                }
            }


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

            //xuLy(lstDicS[0]);

            a = (_GiaoDichO.ID > 0) ? _GiaoDichD.SuaNhieu1Ban(lstDicS, lstCTV) : _GiaoDichD.ThemNhieu1Ban(lstDicS);
            if (XuLyGiaoDien.ThongBao(Text, a == lstDicS.Count))
            {
                GhiChuCmt(_GiaoDichO.ID);
                if (iLoaiKhachHang.EditValue.ToString() != "3")
                    new D_DAILY().ChayLaiPhi((_GiaoDichO.NgayGD > iNgayGD.DateTime) ? iNgayGD.DateTime : _GiaoDichO.NgayGD);
                (Owner.ActiveMdiChild as frmVe).DuLieu(true);
                Close();
            }
        }

        #region Tạo Ghi Chú
        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("Sửa {0}: {1}", f, XuLyDuLieu.GhiChuCMT(this) + XuLyDuLieu.GhiChuGrid(GVGD, _LSTDIC));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", "Vé");
                dic.Add("MaCho", iMaCho.Text);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", ClsDuLieu.NhanVien.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
            }
            else if (long.Parse(f.ToString()) == 0)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", "Vé");
                dic.Add("MaCho", iMaCho.Text);
                dic.Add("NoiDung", "Thêm tay");
                dic.Add("NVGiaoDich", ClsDuLieu.NhanVien.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                new D_LS_GIAODICH().ThemMoi(dic);
            }
        }
        #endregion

        private void btnLS_Click(object sender, EventArgs e)
        {
            new frmLichSu(iMaCho.Text).ShowDialog();
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
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
                O_GIAODICH giaoDichO = new O_GIAODICH();
                List<O_GIAODICH> giaoDichOs = new List<O_GIAODICH>();
                mText.Text = mText.Text.Replace("  ", " ");
                lines = mText.Lines;
                D_SANBAY sbB = new D_SANBAY();
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
                                    giaoDichO.TuyenBayDi = new D_TUYENBAY().TuyenBay(sbB.SanBay(Az[4].Substring(0, 3)).ID, sbB.SanBay(Az[4].Substring(3, 3)).ID).ID;
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
                                    giaoDichO.TuyenBayVe = new D_TUYENBAY().TuyenBay(sbB.SanBay(Az[4].Substring(0, 3)).ID, sbB.SanBay(Az[4].Substring(3, 3)).ID).ID;
                                    if (giaoDichO.TuyenBayVe == 0)
                                    { XtraMessageBox.Show("Tuyến bay không tồn tại", "Thông báo"); return; }
                                }
                                else if (lines[i].Contains("/"))
                                {
                                    Az = lines[i].Split('-');
                                    if (Az.Length == 3)
                                        giaoDichOs.Add(new O_GIAODICH()
                                        {
                                            TenKhach = Az[0].TrimStart(),
                                            SoVeVN = Az[1].Replace("/", string.Empty),
                                            GiaNet = long.Parse(Az[2].Split('/')[1]),
                                            GiaHeThong = long.Parse(Az[2].Split('/')[1]),
                                            GiaThu = long.Parse(Az[2].Split('/')[1]),
                                        });
                                    else
                                        giaoDichOs.Add(new O_GIAODICH()
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
                giaoDichO.NVGiaoDich = ClsDuLieu.NhanVien.ID;
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