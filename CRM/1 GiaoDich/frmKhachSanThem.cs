using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM
{
    public partial class frmKhachSanThem : DevExpress.XtraEditors.XtraForm
    {
        O_KHACHSAN _ks = new O_KHACHSAN();
        D_KHACHSAN _ksD = new D_KHACHSAN();

        public frmKhachSanThem()
        {
            InitializeComponent();
        }

        public frmKhachSanThem(List<O_KHACHSAN> frm)
        {
            InitializeComponent();
            khachSanOBindingSource.DataSource = frm;
            _ks = frm[0];
            btnLuu.Enabled = !(Owner is frmNHCTThem);
        }

        private void frmKhachSanThem_Load(object sender, EventArgs e)
        {
            #region NVGiaoDich
            iNVGiaoDich.Properties.ReadOnly = iNVHoTro.Properties.ReadOnly = _ks.NVGiaoDich != DuLieuTaoSan.NV.ID;
            LoaiKhachDB.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();

            if (_ks.NVGiaoDich == DuLieuTaoSan.NV.ID || _ks.NVGiaoDich < 1 || DuLieuTaoSan.NV.MienPhat)
                _ks.NVGiaoDich = DuLieuTaoSan.NV.ID;
            else if (_ks.NVHoTro < 1 || DuLieuTaoSan.NV.MienPhat)
                _ks.NVHoTro = DuLieuTaoSan.NV.ID;
            #endregion

            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _ks);
            XuLyGiaoDien.OpenForm(this);
            DuLieu();
        }

        List<O_DAILY> _ListDaiLyO = new List<O_DAILY>();
        void DuLieu()
        {
            _ListDaiLyO = new D_DAILY().All();
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            NganHangDB.DataSource = new D_NGANHANG().DuLieu(false);
            NhanVienDB.DataSource = new D_DAILY().NhanVien();
            KSDB.DataSource = new D_NHACUNGCAP().DuLieu(false, true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iKhachSan, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iMaCho, _Tu = 1, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iIDKhachHang, _Tu = 1, _Den = 50 });
            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();


            dic = XuLyDuLieu.FormToDictionary(this, dic);
            XulyDuLieuTruocKhiThem(dic);
        }

        void XulyDuLieuTruocKhiThem(Dictionary<string, object> Dic)
        {
            long a = 0;
            List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
            List<string> lstCTV = new List<string>();
            for (int i = 0; i < GaVGD.RowCount; i++)
            {
                Dictionary<string, object> dicS = new Dictionary<string, object>(Dic);
                for (int y = 0; y < GaVGD.Columns.Count; y++) //Dòng
                {
                    if (GaVGD.Columns[y].Visible)//Cột
                    {
                        object G = GaVGD.GetRowCellValue(i, GaVGD.Columns[y]);
                        dicS.Add(GaVGD.Columns[y].FieldName, G);
                    }
                    else if (y == GaVGD.Columns.Count - 1)
                    {
                        object G = GaVGD.GetRowCellValue(i, GaVGD.Columns[y]);
                        lstCTV.Add(string.Format("WHERE ID = {0}", G));
                        lstDicS.Add(dicS);
                    }
                }
            }

            a = (_ks.ID > 0) ? _ksD.SuaNhieu1Ban(lstDicS, lstCTV) : _ksD.ThemNhieu1Ban(lstDicS);
            if (XuLyGiaoDien.ThongBao(Text, a == lstDicS.Count))
            {
                GhiChuCmt(_ks.ID);
                (Owner.ActiveMdiChild as frmKhachSan).DuLieu();
                Close();
            }
        }

        public void DuLieuKhachLe(long a)
        {
            _ListDaiLyO = new D_DAILY().All();
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            iIDKhachHang.EditValue = a;
        }

        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", iMaCho.Text);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
            }
        }

        private void GVGD_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            string[] a = new string[] { "SoPhong", "SoDem", "TienPhuThu", "GiaHeThong", "DonGia" };
            if (a.Contains(e.Column.FieldName))
            {
                long SoPhong = long.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["SoPhong"]).ToString());
                long SoDem = long.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["SoDem"]).ToString());
                long DonGia = long.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["DonGia"]).ToString());
                long TienPhuThu = long.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["TienPhuThu"]).ToString());
                long GiaThu = SoPhong * SoDem * DonGia + TienPhuThu;

                view.SetRowCellValue(e.RowHandle, view.Columns["GiaNet"], GiaThu);

                view.SetRowCellValue(e.RowHandle, view.Columns["LoiNhuan"], (long)view.GetRowCellValue(e.RowHandle, view.Columns["GiaHeThong"]) - GiaThu);
            }
        }

        private void iNgayGD_EditValueChanged(object sender, EventArgs e)
        {
            if (_ks.ID < 1)
            {
                DateTime d = iNgayGD.DateTime;
                string STT = _ksD.GetSTT(d);
                if (STT.Split('-')[0].EndsWith(d.ToString("MM")))
                    _ks.MaCho = $"{d.ToString("yy")}T{d.ToString("MM")}-{(int.Parse(STT.ToString().Split('-')[1]) + 1).ToString("000#")}";
                else
                    _ks.MaCho = $"{d.ToString("yy")}T{d.ToString("MM")}-0001";
                iMaCho.Text = _ks.MaCho;
            }
        }

        int LoaiKhachHang = 0;
        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            LoaiKhachHang = (int)iLoaiKhachHang.EditValue;
            DaiLyDB.DataSource = _ListDaiLyO.Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang));
            btnAdd.Visible = LoaiKhachHang == 3;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmKhachLeThem frm = new frmKhachLeThem();
            frm.ShowDialog(this);
        }

        private void GaVGD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if ("NgayBaoLuu SoTienBaoLuu".Contains(e.Column.FieldName))
            {
                if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    if (int.Parse((view.GetListSourceRowCellValue(e.ListSourceRowIndex, "SoTienBaoLuu") ?? 0).ToString()) == 0)
                        e.DisplayText = string.Empty;
                }
            }
        }
    }
}