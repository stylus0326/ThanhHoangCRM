using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace CRM
{
    public partial class frmVeHoanThem : DevExpress.XtraEditors.XtraForm
    {
        GiaoDichO _GiaoDichO = new GiaoDichO();
        GiaoDichD _GiaoDichD = new GiaoDichD();
        List<DaiLyO> _ListDaiLyO = new List<DaiLyO>();
        List<HangBayO> _ListHangBayO = new List<HangBayO>();
        List<TuyenBayO> _ListTuyenBayO = new List<TuyenBayO>();
        List<Dictionary<string, object>> _LSTDIC = new List<Dictionary<string, object>>();
        int LoaiKhachHang = 1;
        public frmVeHoanThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmVeHoanThem(List<GiaoDichO> lst)
        {
            InitializeComponent();
            _GiaoDichO = lst[0];
            DSGiaoDich.DataSource = lst;
            Text += " sửa";
            if (lst[0].Hang == "VN")
            {
                List<GiaoDichO> Sos = _GiaoDichD.VeThuongVN(lst);
                foreach (GiaoDichO a in lst)
                {
                    if (Sos.Where(w => (w.SoVeVN ?? string.Empty).Equals(a.SoVeVN)).Count() > 0)
                    {
                        GiaoDichO b = Sos.Where(w => (w.SoVeVN ?? string.Empty).Equals(a.SoVeVN)).ToList()[0];
                        if (b.GiaThu != a.GiaHoan)
                        {
                            memoEdit1.Text += string.Format("Số vé {0} thay đổi giá {1} sang {2}\r\n", a.SoVeVN, b.GiaThu.ToString("#,##0"), a.GiaHoan.ToString("#,##0"));
                        }
                    }
                }
            }
        }

        private void frmVeHoanThem_Load(object sender, EventArgs e)
        {
            chkDen.Checked = _GiaoDichO.SoLuongVe == 2;
            DuLieuKhachLe();
            _ListHangBayO = new HangBayD().DuLieu();
            _ListTuyenBayO = new TuyenBayD().DuLieu();
            LoaiKhachDB.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();
            NCCDB.DataSource = new NCCD().DuLieu();
            NhanVienDB.DataSource = new DaiLyD().NhanVien();
            tuyenBayOBindingSource.DataSource = _ListTuyenBayO;
            if (Owner.ActiveMdiChild is frmVe)
                iTinhCongNo.Checked = true;
            iTinhCongNo.Visible = DuLieuTaoSan.Q.TheoDoiHoanAdmin;
            iAn.Visible = DuLieuTaoSan.Q.VeAdmin;

            #region NVGiaoDich
            iNVGiaoDich.Properties.ReadOnly = _GiaoDichO.NVGiaoDich != DuLieuTaoSan.NV.ID;
            if (_GiaoDichO.NVGiaoDich < 1)
                _GiaoDichO.NVGiaoDich = DuLieuTaoSan.NV.ID;
            else if (DuLieuTaoSan.NV.MienPhat)
                _GiaoDichO.NVGiaoDich = DuLieuTaoSan.NV.ID;
            #endregion

            iGhiChu.Text = _GiaoDichO.GhiChu;
            _LSTDIC = XuLyDuLieu.BanTamGrid(GVH);
            XuLyDuLieu.ConvertClassToTable(this, _GiaoDichO);
            XuLyGiaoDien.OpenForm(this);
            if (!_GiaoDichO.TinhCongNo)
                iNgayGD.DateTime = DateTime.Now;
            btnLuu.Visible = DuLieuTaoSan.Q.TheoDoiHoanThemSua;
        }

        public void DuLieuKhachLe()
        {
            _ListDaiLyO = new DaiLyD().All();
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
        }

        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            LoaiKhachHang = (int)iLoaiKhachHang.EditValue;
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            HinhThucDB.DataSource = DuLieuTaoSan.HinhThuc_Ve(LoaiKhachHang);
            if (LoaiKhachHang != _GiaoDichO.LoaiKhachHang || iNganHang.EditValue == null)
                iHTTT.EditValue = LoaiKhachHang == 3 ? 4 : 1;
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
                                    HangBayO hb = (HangBayO)iHang.Properties.GetRowByKeyValue(iHang.EditValue);
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
            HangBayO hb = (HangBayO)iHang.Properties.GetRowByKeyValue(iHang.EditValue);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region Bước kiểm tra nhập
            Dictionary<string, object> dic = new Dictionary<string, object>();

            KhoaNgayO kn = new KhoaNgayD().KiemTraNgayKhoa(_GiaoDichO.NgayGD);

            if (!(iLoaiKhachHang.EditValue.ToString() == "3" && _GiaoDichO.Khoa))
                if (_GiaoDichO.TinhCongNo)
                {
                    if (!DuLieuTaoSan.Q.TheoDoiHoanAdmin)
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
            if (_GiaoDichO.ID < 1)
                dic.Add("NgayCuonChieu", iNgayGD.DateTime);
            dic.Add("LoaiGiaoDich", 9);

            if (_GiaoDichO.ID < 1)
                dic.Add("Khoa", 0);


            #endregion

            XulyDuLieuTruocKhiThem(dic);
        }

        void XulyDuLieuTruocKhiThem(Dictionary<string, object> Dic)
        {
            long a = 0;
            List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
            List<string> lstCTV = new List<string>();
            for (int i = 0; i < GVH.RowCount; i++)
            {
                Dictionary<string, object> dicS = new Dictionary<string, object>(Dic);
                for (int y = 0; y < GVH.Columns.Count; y++) //Dòng
                {
                    if (y == GVH.Columns.Count - 1)
                    {
                        object G = GVH.GetRowCellValue(i, GVH.Columns[y]);
                        lstCTV.Add(string.Format("WHERE ID = {0}", G));
                        lstDicS.Add(dicS);
                    }
                    else
                    {
                        object G = GVH.GetRowCellValue(i, GVH.Columns[y]);
                        dicS.Add(GVH.Columns[y].FieldName, G);
                    }
                }
            }
            a = (_GiaoDichO.ID > 0) ? _GiaoDichD.SuaNhieu1Ban(lstDicS, lstCTV) : _GiaoDichD.ThemNhieu1Ban(lstDicS);
            if (XuLyGiaoDien.ThongBao(Text, a == lstDicS.Count))
            {
                GhiChuCmt(_GiaoDichO.ID);
                if (iLoaiKhachHang.EditValue.ToString() != "3")
                    new DaiLyD().ChayLaiPhi((_GiaoDichO.NgayGD > iNgayGD.DateTime) ? iNgayGD.DateTime : _GiaoDichO.NgayGD);
                if (Owner.ActiveMdiChild is frmVe)
                    (Owner.ActiveMdiChild as frmVe).DuLieu();
                else
                    (Owner.ActiveMdiChild as frmTheoDoiHoan).DuLieu();
                Close();
            }
        }

        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this) + XuLyDuLieu.GhiChuGrid(GVH, _LSTDIC));
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

        private void GVH_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            long LoiNhuan = 0;
            if ("GiaNet GiaHeThong HangHoan GiaHoan".Contains(e.Column.FieldName))
            {
                foreach (GridColumn col in view.Columns)
                {
                    switch (e.Column.FieldName)
                    {
                        case "GiaHeThong":
                            view.SetRowCellValue(e.RowHandle, view.Columns["GiaThu"], (long)e.Value);
                            break;
                        case "GiaHoan":
                            view.SetRowCellValue(e.RowHandle, view.Columns["TaiKhoanCo"], (long)e.Value);
                            break;
                    }
                    if ("GiaNet GiaHoan".Contains(col.FieldName))
                        LoiNhuan -= (long)view.GetRowCellValue(e.RowHandle, col);
                    if ("GiaHeThong HangHoan".Contains(col.FieldName))
                        LoiNhuan += (long)view.GetRowCellValue(e.RowHandle, col);
                }
                view.SetRowCellValue(e.RowHandle, view.Columns["LoiNhuan"], LoiNhuan);
            }
        }

        private void GVH_ShownEditor(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                GVH.ActiveEditor.SelectAll();
            }));
        }

        private void GVH_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
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
                case "GiaHeThong":
                case "GiaHoan":
                case "HangHoan":
                    long a = 0;
                    if (!long.TryParse(e.Value as String, out a))
                    {
                        e.Valid = false;
                        e.ErrorText = "Chỉ nhập số";
                    }
                    break;
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (_GiaoDichD.KiemTraGiaoDich(iMaCho.Text, false))
            {
                XuLyGiaoDien.Alert("Mã chỗ đã tồn tại", Form_Alert.enmType.Warning);
                return;
            }
            Xuli(_GiaoDichD.LayGiaoDichHoan(iMaCho.Text, false));
            iTheoDoi.Checked = !(Owner.ActiveMdiChild is frmVe);
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            if (_GiaoDichD.KiemTraGiaoDich(txtSoVe.Text, true))
            {
                XuLyGiaoDien.Alert("Số vé đã tồn tại", Form_Alert.enmType.Warning);
                return;
            }
            Xuli(_GiaoDichD.LayGiaoDichHoan(txtSoVe.Text, true));
            iTheoDoi.Checked = !(Owner.ActiveMdiChild is frmVe);
        }

        List<GiaoDichO> _ListGiaoDichO = new List<GiaoDichO>();
        void Xuli(List<GiaoDichO> lstgd)
        {
            foreach (GiaoDichO gd in lstgd)
            {
                if (_ListGiaoDichO.Where(w => (w.SoVeVN ?? string.Empty).Equals(gd.SoVeVN) && w.GiaHoan.Equals(gd.GiaThu)).Count() > 0)
                    continue;
                GiaoDichO g1 = new GiaoDichO(gd);
                g1.GiaHoan = g1.GiaThu;
                g1.GiaNet = g1.GiaHeThong = g1.GiaThu = 0;
                g1.LoiNhuan = g1.GiaHeThong + g1.HangHoan - g1.GiaNet + g1.GiaHoan;
                g1.TenKhach += "/Hoàn vé";
                g1.LoaiGiaoDich = 9;
                g1.NVHoTro = g1.NVHoTro;
                _ListGiaoDichO.Add(g1);
            }

            if (lstgd.Count > 0)
            {
                DSGiaoDich.DataSource = null;
                DSGiaoDich.DataSource = _ListGiaoDichO;

                lstgd[0].NVHoTro = _ListGiaoDichO[0].NVGiaoDich;
                lstgd[0].NVGiaoDich = DuLieuTaoSan.NV.ID;

                lstgd[0].NgayGD = DateTime.Now;
                XuLyDuLieu.ConvertClassToTable(this, lstgd[0]);

                iTinhCongNo.Checked = false;
                btnLuu.Visible = true;
            }
        }

        private void frmVeHoanThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}