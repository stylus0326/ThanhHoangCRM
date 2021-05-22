using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNhanVienThem : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVienThem()
        {
            InitializeComponent();
            btnlock.Visible = false;
            txtMatKhauCty.Enabled = true;
            Grp3.Enabled = false;
            txtMatKhauCty.Properties.PasswordChar = '\0';
            Text += " thêm";
        }

        public frmNhanVienThem(DaiLyO DaiLyO)
        {
            InitializeComponent();
            Text += " sửa";
            _KhachHangO = DaiLyO;
        }

        private void frmNhanVienThem_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _KhachHangO);
            quyenOBindingSource.DataSource = new QuyenNhanVienD().DuLieu();
            gioiTinhBindingSource.DataSource = DuLieuTaoSan.GioiTinh();
            hangBayOBindingSource.DataSource = new HangBayD().DuLieu();
            TaiLaiSignIn();
            btnLuu.Visible = DuLieuTaoSan.Q.NhanVienThemSua;
        }

        #region Dữ liệu 
        public void TaiLaiSignIn()
        {
            signInOBindingSource.DataSource = new SignInD().TimSignIn(_KhachHangO.ID);
        }
        #endregion

        #region Biến
        SignInO SignInOz = new SignInO();
        DaiLyO _KhachHangO = new DaiLyO();
        PhongBanO PhongBanOz = new PhongBanO();
        DaiLyD _DaiLyD = new DaiLyD();
        string TrangThai = "T";
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
            kiemTras.Add(new KiemTra() { _Control = iTenDangNhapCty, _Tu = 5, _Den = 30, _ChoQua = !_DaiLyD.DaTonTai("TenDangNhapCty", iTenDangNhapCty.Text, _KhachHangO.ID), _ThongBao2 = "Đã tồn tại" });
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
            long a = (_KhachHangO.ID > 0) ? _DaiLyD.CapNhat(dic, _KhachHangO.ID) : _DaiLyD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, a > 0))
            {
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

        #region Sự khiện bản 
        private void Grp3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (DuLieuTaoSan.Q.SignInThemSua)
            {
                switch (int.Parse(e.Button.Properties.Tag.ToString()))
                {
                    case 1:
                        new frmSignInThem(_KhachHangO).ShowDialog(this);
                        break;
                    case 2:
                        if (signInOBindingSource.Count > 0)
                        {
                            SignInO SignInOz = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
                            if (SignInOz != null)
                                new frmSignInThem(SignInOz).ShowDialog(this);
                        }
                        break;
                    case 3:
                        if (DuLieuTaoSan.Q.SignInXoa)
                            if (signInOBindingSource.Count > 0)
                            {
                                XuLyGiaoDien.ThongBao(Text, new SignInD().Xoa(_KhachHangO.ID) > 0, true);
                                TaiLaiSignIn();
                            }
                        break;
                }
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
    }
}