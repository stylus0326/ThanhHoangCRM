using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmHoaDonThem : DevExpress.XtraEditors.XtraForm
    {
        List<long> IDHD = new List<long>();
        List<O_DAILY> daiLyDs = new List<O_DAILY>();
        public frmHoaDonThem()
        {
            InitializeComponent();
            IDHD.Add(0);
            _HoaDonO.NhanVien = ClsDuLieu.NhanVien.ID;
            Controls.Remove(iSoChungTu);
            aaa.Visible = false;
            Text += " thêm";
        }

        public frmHoaDonThem(O_HOADON HD)
        {
            InitializeComponent();
            HD.ID = 0;
            _HoaDonO = HD;
            _HoaDonO.NhanVien = ClsDuLieu.NhanVien.ID;
            iMaHD.Enabled = false;
            Text += " sửa";
        }

        public frmHoaDonThem(List<O_HOADON> HD)
        {
            InitializeComponent();
            _HoaDonO = HD[0];
            gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            hoaDonOBindingSource.DataSource = HD;
            IDHD = HD.Select(w => w.ID).ToList();
            txtSoVe.Enabled = txtMC.Enabled = btnCode.Enabled = btnSV.Enabled = MaSoThue.Enabled = false;
        }

        private void frmHoaDonThem_Load(object sender, EventArgs e)
        {
            daiLyDs = new D_DAILY().All();
            daiLyOBindingSource1.DataSource = daiLyDs;
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu();
            tuyenBayOBindingSource.DataSource = new D_TUYENBAY().DuLieu();
            bindingSource1.DataSource = daiLyD.NhanVien();
            IntStringBindingSource.DataSource = DuLieuTaoSan.LoaiKhachHang_GiaoDich(false);
            hoaDonOBindingSource1.DataSource = _HoaDonD.LayThongTinMST();
            hangBayOBindingSource.DataSource = new D_HANGBAY().DuLieu();
            ClsChucNang.OpenForm(this);
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _HoaDonO);
            daiLyOBindingSource.DataSource = daiLyDs.Where(w => w.LoaiKhachHang.Equals((int)iLoaiKhachHang.EditValue));
            bandedGridView1.BestFitColumns();
        }


        #region Biến
        D_DAILY daiLyD = new D_DAILY();
        O_HOADON _HoaDonO = new O_HOADON();
        D_HOADON _HoaDonD = new D_HOADON();
        O_GIAODICH _GiaoDichO = new O_GIAODICH();
        #endregion

        #region Giao diện
        #endregion

        #region Sự kiện nút
        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            daiLyOBindingSource.DataSource = daiLyDs.Where(w => w.LoaiKhachHang.Equals((int)iLoaiKhachHang.EditValue));
        }

        private void MaSoThue_EditValueChanged(object sender, EventArgs e)
        {
            if (MaSoThue.EditValue != null)
            {
                O_HOADON hoaDonO = MaSoThue.GetSelectedDataRow() as O_HOADON;
                if (hoaDonO != null)
                {
                    iMaSoThue.Text = hoaDonO.MaSoThue;
                    iDiaChi.Text = hoaDonO.DiaChi;
                    iMail.Text = hoaDonO.Mail;
                    iCongTy.Text = hoaDonO.CongTy;
                }
            }
        }
        #endregion

        #region Sự khiện khác 
        #endregion


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            int HTV = 0;
            switch (e.Column.FieldName)
            {
                case "GiaHeThong2":
                case "GiaHeThong":
                case "GiaYeuCau":
                    view.SetRowCellValue(e.RowHandle, view.Columns["CL1"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaYeuCau"]) - (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaHeThong"]));
                    view.SetRowCellValue(e.RowHandle, view.Columns["CL5"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) * 10 / 11);
                    view.SetRowCellValue(e.RowHandle, view.Columns["CL2"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) * (float)view.GetRowCellValue(e.RowHandle, view.Columns["PhanTram"]) / 100);
                    if ((long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaHeThong2"]) > 0)
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL3"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaYeuCau"]) - (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaHeThong2"]));
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL6"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL3"]) * 10 / 11);
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL4"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL3"]) * (float)view.GetRowCellValue(e.RowHandle, view.Columns["PhanTram2"]) / 100);
                    }

                    HTV = int.Parse((view.GetRowCellValue(e.RowHandle, view.Columns["HanhTrinhVe"]) ?? "0").ToString());


                    if ((long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) / (HTV > 0 ? 2 : 1) > 50000)
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["PhanTram"], 10);
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL2"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) * (float)10 / 100);
                    }
                    else
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["PhanTram"], 0);
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL2"], 0);
                    }
                    bandedGridView1.BestFitColumns();
                    break;
                case "PhanTram2":
                case "PhanTram":
                    view.SetRowCellValue(e.RowHandle, view.Columns["CL2"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) * (float)view.GetRowCellValue(e.RowHandle, view.Columns["PhanTram"]) / 100);
                    if ((long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaHeThong2"]) > 0)
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL4"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL3"]) * (float)view.GetRowCellValue(e.RowHandle, view.Columns["PhanTram2"]) / 100);
                    break;
                case "CL1":
                    HTV = int.Parse((view.GetRowCellValue(e.RowHandle, view.Columns["HanhTrinhVe"]) ?? "0").ToString());

                    if ((long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) / (HTV > 0 ? 2 : 1) > 50000)
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["PhanTram"], 10);
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL2"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["CL1"]) * (float)10 / 100);
                    }
                    else
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns["PhanTram"], 0);
                        view.SetRowCellValue(e.RowHandle, view.Columns["CL2"], 0);
                    }    
                    break;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool ChoQua = false;
            if (iMaHD.Text == "0" || !iMaHD.Enabled)
                ChoQua = true;
            else
                ChoQua = !_HoaDonD.DaTonTai(string.Format("WHERE MaHD = N'{0}' AND ID not in ({1})", iMaHD.Text, String.Join(" ,", IDHD.ToArray())));
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iMaHD, _ChoQuaThang = ChoQua, _ThongBao2 = "Đã tồn tại",_Tu=1 } ,
            new KiemTra() { _Control = iIDKhachHang,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iDiaChi,_Tu = 10,_Den = 500},
            new KiemTra() { _Control = iMail,_Tu = 10,_Den = 200},};

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
            List<string> lstCTV = new List<string>();
            if (!aaa.Visible)
                dic.Add("SoChungTu", _HoaDonD.TaoChungTu());
            else
            if (_HoaDonO.HoTro < 1)
                _HoaDonO.HoTro = ClsDuLieu.NhanVien.ID;
            for (int i = 0; i < bandedGridView1.RowCount; i++)
            {
                Dictionary<string, object> dicS = new Dictionary<string, object>(dic);
                for (int y = 0; y < bandedGridView1.Columns.Count; y++) //Dòng
                {
                    if (bandedGridView1.Columns[y].FieldName.StartsWith("CL"))
                        continue;
                    if (bandedGridView1.Columns[y].Visible)//Cột
                    {
                        object G = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns[y]);
                        dicS.Add(bandedGridView1.Columns[y].FieldName, G);
                    }
                    else if (y == bandedGridView1.Columns.Count - 1)
                    {
                        object G = bandedGridView1.GetRowCellValue(i, bandedGridView1.Columns[y]);
                        lstCTV.Add(string.Format("WHERE ID = {0}", G));
                        lstDicS.Add(dicS);
                    }
                }
            }

            long a = (_HoaDonO.ID > 0) ? _HoaDonD.SuaNhieu1Ban(lstDicS, lstCTV) : _HoaDonD.ThemNhieu1Ban(lstDicS);
            if (XuLyGiaoDien.ThongBao(Text, a == lstDicS.Count))
            {
                (Owner.ActiveMdiChild as frmHoaDon).DuLieu(true);
                Close();
            }
        }

        private void iMaSoThue_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
        }

        private void iMaSoThue_TextChanged(object sender, EventArgs e)
        {
            if (!XuLyDuLieu.IsNumeric(iMaSoThue.Text))
            { iMaSoThue.Text = string.Empty; }
        }

        D_GIAODICH Giao = new D_GIAODICH();
        private void btnCode_Click(object sender, EventArgs e)
        {
            txtMC.Text = txtMC.Text.Replace(" ", string.Empty);
            if (txtMC.Text.Length > 5)
            {
                if (_HoaDonD.KiemTraGiaoDich(txtMC.Text, false))
                {
                    XuLyGiaoDien.Alert("Mã chỗ đã tồn tại", Form_Alert.enmType.Warning);
                    return;
                }
                Xuli(Giao.LayGiaoDichHoan(txtMC.Text, false));
            }
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            txtSoVe.Text = txtSoVe.Text.Replace(" ", string.Empty);
            if (txtSoVe.Text.Length > 10)
            {
                if (_HoaDonD.KiemTraGiaoDich(txtSoVe.Text, true))
                {
                    XuLyGiaoDien.Alert("Số vé đã tồn tại", Form_Alert.enmType.Warning);
                    return;
                }
                Xuli(Giao.LayGiaoDichHoan(txtSoVe.Text, true));
            }
        }

        List<O_HOADON> hoaDonOs = new List<O_HOADON>();
        void Xuli(List<O_GIAODICH> lstgd)
        {
            foreach (O_GIAODICH gd in lstgd)
            {
                if (hoaDonOs.Where(w => (w.SoVe ?? string.Empty).Equals((gd.SoVeVN ?? string.Empty)) && w.MaCho.Equals(gd.MaCho) && w.GiaHeThong.Equals(gd.GiaHeThong)).Count() > lstgd.Where(w => (w.SoVeVN ?? string.Empty).Equals((gd.SoVeVN ?? string.Empty)) && w.MaCho.Equals(gd.MaCho) && w.GiaHeThong.Equals(gd.GiaHeThong)).Count() - 1)
                    continue;

                O_HOADON g1 = new O_HOADON();
                g1.GiaYeuCau = g1.GiaHeThong = gd.GiaHeThong;
                g1.Hang = gd.Hang;
                g1.GiaNet = gd.GiaNet;
                g1.MaCho = gd.MaCho;
                g1.SoVe = gd.SoVeVN;
                g1.NhaCungCap = gd.NhaCungCap;
                g1.HanhTrinhDi = gd.TuyenBayDi;
                g1.HanhTrinhVe = gd.TuyenBayVe;
                g1.CL1 = 0;
                g1.NgayGDV = gd.NgayGD;
                g1.IDGiaoDich = gd.ID;
                hoaDonOs.Add(g1);
            }

            if (lstgd.Count > 0)
            {
                iLoaiKhachHang.EditValue = lstgd[0].LoaiKhachHang;
                iIDKhachHang.EditValue = lstgd[0].IDKhachHang;
                hoaDonOBindingSource.DataSource = null;
                hoaDonOBindingSource.DataSource = hoaDonOs;
                bandedGridView1.BestFitColumns();
            }
        }

        int index = 0;

        private void btnCode2_Click(object sender, EventArgs e)
        {
            txtMC2.Text = txtMC2.Text.Replace(" ", string.Empty);
            if (txtMC2.Text.Length > 5)
            {
                if (_HoaDonD.KiemTraGiaoDich2(txtMC2.Text, false))
                {
                    XuLyGiaoDien.Alert("Mã chỗ đã tồn tại", Form_Alert.enmType.Warning);
                    return;
                }
                Xuli2(Giao.LayGiaoDichHoan(txtMC2.Text, false));
                bandedGridView1.BestFitColumns();
            }
        }

        private void btnSV2_Click(object sender, EventArgs e)
        {
            txtSoVe2.Text = txtSoVe2.Text.Replace(" ", string.Empty);
            if (txtSoVe2.Text.Length > 10)
            {
                if (_HoaDonD.KiemTraGiaoDich2(txtSoVe2.Text, true))
                {
                    XuLyGiaoDien.Alert("Số vé đã tồn tại", Form_Alert.enmType.Warning);
                    return;
                }
                Xuli2(Giao.LayGiaoDichHoan(txtSoVe2.Text, true));
                bandedGridView1.BestFitColumns();
            }
        }

        void Xuli2(List<O_GIAODICH> lstgd)
        {
            if (lstgd.Count == 0)
                return;

            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["MaCho2"], lstgd[0].MaCho);
            if (txtSoVe2.Text.Length > 10)
                bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["SoVe2"], lstgd[0].SoVeVN);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["GiaHeThong2"], lstgd[0].GiaHeThong);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["NgayGDV2"], lstgd[0].NgayGD);
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            switch (e.Column.FieldName)
            {
                case "NgayGDV2":
                    if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        if ((view.GetListSourceRowCellValue(e.ListSourceRowIndex, "MaCho2") ?? string.Empty).ToString().Length == 0)
                            e.DisplayText = string.Empty;
                    }
                    break;
            }
        }

        private void btnDelCell_Click(object sender, EventArgs e)
        {
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["MaCho2"], string.Empty);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["SoVe2"], string.Empty);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["GiaHeThong2"], 0);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["NgayGDV2"], null);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["CL3"], 0);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["CL6"], 0);
            bandedGridView1.SetRowCellValue(index, bandedGridView1.Columns["CL4"], 0);
        }

        private void bandedGridView1_Click(object sender, EventArgs e)
        {
            index = bandedGridView1.FocusedRowHandle;
        }

        private void frmHoaDonThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}