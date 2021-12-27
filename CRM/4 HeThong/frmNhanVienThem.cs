using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace CRM
{
    public partial class frmNhanVienThem : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public frmNhanVienThem()
        {
            InitializeComponent();
            btnlock.Visible = false;
            txtMatKhauCty.Enabled = true;
            _KhachHangO = ClsDuLieu.NhanVien;
        }

        public frmNhanVienThem(bool Xem)
        {
            InitializeComponent();
            btnlock.Visible = false;
            txtMatKhauCty.Enabled = true;
            txtMatKhauCty.Properties.PasswordChar = '\0';
            Text += " thêm";
            btnLuu.Visible = ClsDuLieu.Quyen.NhanVienThemSua;
            iAC1.Enabled = false;
        }

        public frmNhanVienThem(O_DAILY DaiLyO)
        {
            InitializeComponent();
            Text += " sửa";
            btnLuu.Visible = ClsDuLieu.Quyen.NhanVienThemSua;
            _KhachHangO = DaiLyO;
        }

        private void frmNhanVienThem_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Columns.Add("col3");
            ClsChucNang.OpenForm(this);
            _HoHang = _KhachHangO.ThongTinLienLac;
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _KhachHangO);
            quyenOBindingSource.DataSource = new D_NHOMQUYEN().DuLieu();
            gioiTinhBindingSource.DataSource = DuLieuTaoSan.GioiTinh();
            e2.EditValue = DateTime.Now;
            NguoiThanKhach();
        }

        #region Dữ liệu 

        public void TaiLaiKPI()
        {
            if (e1.EditValue != null && e2.EditValue != null)
            {
                D_KPI KP = new D_KPI();
                kPIOBindingSource.DataSource = KP.DuLieu(_KhachHangO.ID, ((DateTime)e1.EditValue), ((DateTime)e2.EditValue));
                barStaticItem2.Caption = "Điểm theo điều kiện:" + KP.DiemTinh(_KhachHangO.ID, ((DateTime)e2.EditValue)).ToString();
                barStaticItem1.Caption = "Điểm hiện tại:" + KP.DiemTinh(_KhachHangO.ID).ToString();
            }
        }

        string _HoHang = "";
        void NguoiThanKhach(bool IsIn = true)
        {
            if (IsIn)
            {
                if (!String.IsNullOrEmpty(_HoHang))
                {
                    string[] rows = _HoHang.Replace("\r\n", ",").Split(',');
                    foreach (string row in rows)
                    {
                        if (!String.IsNullOrEmpty(row))
                        {
                            string[] columns = row.Replace("\t", "|").Split('|');
                            DataRow dataRow = dt.NewRow();
                            dataRow["col1"] = columns[0];
                            dataRow["col2"] = columns[1];
                            dataRow["col3"] = columns[2];
                            dt.Rows.Add(dataRow);
                        }
                    }
                }
                GCNT.DataSource = dt;
            }
            else
            {
                _HoHang = "";

                Regex digitsOnly = new Regex(@"[^\w\d\s]");
                foreach (DataRow row in dt.Rows)
                { _HoHang += row[0] + "\t" + digitsOnly.Replace(XuLyDuLieu.NotVietKey(row[1].ToString()), "") + "\t" + row[2] + "\r\n"; }
            }
        }
        #endregion

        #region Biến
        O_DAILY _KhachHangO = new O_DAILY();
        D_DAILY _DaiLyD = new D_DAILY();
        #endregion

        #region Sự kiện nút
        private void btnlock_Click(object sender, EventArgs e)
        {
            txtMatKhauCty.Enabled = !txtMatKhauCty.Enabled;
            txtMatKhauCty.Text = txtMatKhauCty.Enabled ? string.Empty : _KhachHangO.MatKhauCty;
            txtMatKhauCty.Properties.PasswordChar = txtMatKhauCty.Enabled ? '\0' : '*';
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTenDangNhapCty, _Tu = 5, _Den = 30, _ChoQua = !_DaiLyD.KiemTraTonTai(_KhachHangO.ID,"TenDangNhapCty", iTenDangNhapCty.Text), _ThongBao2 = "Đã tồn tại" });
            kiemTras.Add(new KiemTra() { _Control = txtMatKhauCty, _Tu = 5, _Den = 30, _ChoQuaThang = !txtMatKhauCty.Enabled });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("Ten", iTenDangNhapCty.Text);
            if (txtMatKhauCty.Enabled)
                dic.Add("MatKhauCty", TMD5.TMd5Hash(txtMatKhauCty.Text));
            dic.Add("LoaiKhachHang", 0);
            NguoiThanKhach(false);
            dic.Add("ThongTinLienLac", _HoHang);
            long a = (_KhachHangO.ID > 0) ? _DaiLyD.CapNhat(dic, _KhachHangO.ID) : _DaiLyD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, a > 0))
            {
                if (_KhachHangO.ID < 1)
                {
                    List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
                    for (int i = 0; i < 90; i++)
                    {
                        dic = new Dictionary<string, object>();
                        dic.Add("LoaiKhachHangSD", _KhachHangO.LoaiKhachHang);
                        dic.Add("ChinhSachID", iChinhSach.EditValue);
                        dic.Add("DaiLyID", a);
                        dic.Add("Ngay", "getdate() - " + i);
                        lstDicS.Add(dic);
                    }
                    new D_SODU_DAILY().ThemNhieu1Ban(lstDicS);
                }
                (Owner.ActiveMdiChild as frmNhanVien).DuLieu();
                Close();
            }
        }

        private void iAnhCty_MouseClick(object sender, MouseEventArgs e)
        {
            XtraOpenFileDialog open = new XtraOpenFileDialog();
            open.Title = "Open Image";
            open.Filter = "Image files (*.jpg;*.jpeg,*.png)|*.JPG;*.JPEG;*.PNG";
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (iAnhCty.Image != null)
                        new frmXemAnh(iAnhCty.Image).ShowDialog();
                    else
                    {
                        if (open.ShowDialog() == DialogResult.OK)
                            iAnhCty.Image = new Bitmap(open.FileName);
                    }
                    break;

                case MouseButtons.Right:
                    if (open.ShowDialog() == DialogResult.OK)
                        iAnhCty.Image = new Bitmap(open.FileName);
                    break;
            }
        }
        #endregion

        private void frmNhanVienThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }

        private void iAC1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            BindingSource bs = (BindingSource)GVKPI.DataSource;
            List<O_KPI> dt = bs.DataSource as List<O_KPI>;
            int sumObject = 0;
            if (dt != null)
                sumObject = dt.Select(w => w.Diem).Sum();
            else
                sumObject = 0;

            switch (int.Parse(e.Button.Properties.Tag.ToString()))
            {
                case 1:
                    new frmKPIThem(_KhachHangO.ID, sumObject).ShowDialog(this);
                    break;
                case 2:
                    if (dt.Count > 0)
                    {
                        O_KPI SignInOz = GVKPI.GetRow(GVKPI.GetSelectedRows()[0]) as O_KPI;
                        if (SignInOz != null)
                            new frmKPIThem(SignInOz, sumObject).ShowDialog(this);
                    }
                    break;
                case 3:
                    if (dt.Count > 0)
                    {
                        O_KPI SignInOz = GVKPI.GetRow(GVKPI.GetSelectedRows()[0]) as O_KPI;
                        XuLyGiaoDien.ThongBao(Text, new D_KPI().Xoa(SignInOz.ID) > 0, true);
                        TaiLaiKPI();
                    }
                    break;
            }
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            TaiLaiKPI();
        }
    }
}