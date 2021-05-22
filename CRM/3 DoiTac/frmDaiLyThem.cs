using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmDaiLyThem : DevExpress.XtraEditors.XtraForm
    {
        public frmDaiLyThem(int LoaiKhach)
        {
            InitializeComponent();
            Text += " thêm";
            iNghi.Enabled = Grp3.Enabled = false;
            _DaiLyO.LoaiKhachHang = LoaiKhach;
            _DaiLyO.NVGiaoDich = DuLieuTaoSan.NV.ID;
        }

        public frmDaiLyThem(DaiLyO Dl)
        {
            InitializeComponent();
            Text += " sửa";
            _DaiLyO = Dl;
            iNgayKiQuy.Enabled = false;
            TaiLaiSignIn();
        }

        private void frmDaiLyThem_Load(object sender, EventArgs e)
        {
            GVSI.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            hangBayOBindingSource.DataSource = new HangBayD().DuLieu();
            XuLyGiaoDien.OpenForm(this);
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _DaiLyO);
            iTinhTrang.Properties.DataSource = new TinhTrangD().DuLieu(_DaiLyO.LoaiKhachHang);
            iChinhSach.Properties.DataSource = new ChinhSachD().DuLieuDL(_DaiLyO.LoaiKhachHang);
            btnLuu.Visible = DuLieuTaoSan.Q.DaiLyThemSua;
            lbl15.Visible = iNVGiaoDich.Visible = iDuHoSo.Visible = DuLieuTaoSan.Q.DaiLyAdmin;
            NhanVienDB.DataSource = new DaiLyD().NhanVien();
        }

        void DaiLy()
        {
            SheetsService SService = new SheetsService();
            string SpreadsheetId = "1t8x2TVkPszbOk4h5Lkvc-ZPFT8naNB2w3ZuRHpY4YIM";
            string ApplicationName = "Google SpeadSheet API";
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            UserCredential cre1;

            using (var stream = new FileStream("credentials-Sheet.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, "credentials-Sheet.json");

                cre1 = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            SService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = cre1,
                ApplicationName = ApplicationName,
            });

            string range1 = $"Đại lý!A:A";
            if (_DaiLyO.LoaiKhachHang == 2)
                range1 = $"Đại lý!B:B";
            var valueRange = new ValueRange();
            List<IList<object>> lstList = new List<IList<object>>();
            var objectList = new List<object>() { (_DaiLyO.LoaiKhachHang == 1) ? iTen.Text : string.Empty, (_DaiLyO.LoaiKhachHang == 2) ? iTen.Text : string.Empty };
            lstList.Add(objectList);
            valueRange.Values = lstList;
            var appendRequest = SService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range1);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            appendRequest.Execute();
        }

        #region Dữ liệu    
        public void TaiLaiSignIn()
        {
            signInOBindingSource.DataSource = new SignInD().TimSignIn(_DaiLyO.ID);
        }
        #endregion

        #region Biến
        DaiLyD _DaiLyD = new DaiLyD();
        SignInO _SignInOz = new SignInO();
        DaiLyO _DaiLyO = new DaiLyO();
        TypeAssistant assistant;
        #endregion

        #region Sự kiện nút

        private void Grp3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (DuLieuTaoSan.Q.SignInThemSua)
            {
                switch (int.Parse(e.Button.Properties.Tag.ToString()))
                {
                    case 1:
                        new frmSignInThem(_DaiLyO).ShowDialog(this);
                        break;
                    case 2:
                        _SignInOz = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
                        new frmSignInThem(_SignInOz).ShowDialog(this);
                        break;
                    case 3:
                        if (DuLieuTaoSan.Q.SignInXoa)
                            if (signInOBindingSource.Count > 0)
                            {
                                _SignInOz = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
                                XuLyGiaoDien.ThongBao("Sign in", new SignInD().Xoa(_SignInOz.ID) > 0, true);
                                TaiLaiSignIn();
                            }
                        break;
                }
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

        private void iTen_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTen, _Tu = 2 });
            kiemTras.Add(new KiemTra() { _Control = iMaDL, _ChoQua = !_DaiLyD.DaTonTai("MaDL", iMaDL.Text, _DaiLyO.ID), _ThongBao2 = "Đã tồn tại", _Tu = 3, _Den = 10 });
            kiemTras.Add(new KiemTra() { _Control = iMaAGS, _Tu = 3, _Den = 10 });
            kiemTras.Add(new KiemTra() { _Control = iDiDong, _SDT = true });
            kiemTras.Add(new KiemTra() { _Control = iChinhSach });
            kiemTras.Add(new KiemTra() { _Control = iTinhTrang });
            kiemTras.Add(new KiemTra() { _Control = iNguoiDaiDienHD, _Tu = 3, _Den = 1000 });
            kiemTras.Add(new KiemTra() { _Control = iDienThoaiHD, _SDT = true });
            kiemTras.Add(new KiemTra() { _Control = iEmailHD, _Mail = true });
            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            if (_DaiLyO.ID < 1)
                dic.Add("LoaiKhachHang", _DaiLyO.LoaiKhachHang);

            long CapNhatNum = (_DaiLyO.ID > 0) ? (_DaiLyD.CapNhat(dic, _DaiLyO.ID) > 0 ? _DaiLyO.ID : 0) : _DaiLyD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                if (_DaiLyO.ID < 1)
                {
                    List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
                    for (int i = 0; i < 30; i++)
                    {
                        dic = new Dictionary<string, object>();
                        dic.Add("LoaiKhachHangSD", _DaiLyO.LoaiKhachHang);
                        dic.Add("ChinhSachID", iChinhSach.EditValue);
                        dic.Add("DaiLyID", CapNhatNum);
                        dic.Add("Ngay", "getdate() - " + i);
                        lstDicS.Add(dic);
                    }
                    new SoDu_DaiLyD().ThemNhieu1Ban(lstDicS);
                    DaiLy();
                }
                (Owner.ActiveMdiChild as frmDaiLy).DuLieu();
                Close();
            }
        }

        private void btnLS_Click(object sender, EventArgs e)
        {
            frmLSCS frm = new frmLSCS(_DaiLyO.ID, _DaiLyO.LoaiKhachHang);
            frm.ShowDialog(this);
        }

        #endregion

        #region Sự khiện bản 
        private void grvSignIn_DoubleClick(object sender, EventArgs e)
        {
            if (signInOBindingSource.Count > 0)
            {
                _SignInOz = GVSI.GetRow(GVSI.GetSelectedRows()[0]) as SignInO;
                new frmSignInThem(_SignInOz).ShowDialog(this);
            }
        }
        #endregion

        private void iTinhTrang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }

        private void iMaDL_TextChanged(object sender, EventArgs e)
        {

            int delay = 1000;
            assistant = new TypeAssistant(delay);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();

        }

        void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
           new MethodInvoker(() =>
           {
               if (_DaiLyO.ID == 0)
                   iMaAGS.Text = iMaDL.Text;
               iKeyCty.Text = TMD5.Base64Encode(TMD5.Base64Encode(TMD5.Base64Encode(iTen.Text + iMaDL.Text)));
           }));
        }

    }
}