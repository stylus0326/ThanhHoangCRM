using DataAccessLayer;
using DataTransferObject;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
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
            _DaiLyO.LoaiKhachHang = LoaiKhach;
            _DaiLyO.NVGiaoDich = ClsDuLieu.NhanVien.ID;
        }

        public frmDaiLyThem(O_DAILY Dl)
        {
            InitializeComponent();
            Text += " sửa";
            _DaiLyO = Dl;
            iNgayKiQuy.Enabled = false;
        }

        private void frmDaiLyThem_Load(object sender, EventArgs e)
        {
            hangBayOBindingSource.DataSource = new D_HANGBAY().DuLieu();
            iTinhTrang.Properties.DataSource = new D_TRANGTHAI().DuLieu(_DaiLyO.LoaiKhachHang);
            iChinhSach.Properties.DataSource = new D_CHINHSACH().DuLieuDL(_DaiLyO.LoaiKhachHang);
            btnLuu.Visible = ClsDuLieu.Quyen.DaiLyThemSua;
            lbl15.Visible = iDuHoSo.Visible = iNVGiaoDich.Visible = ClsDuLieu.NhanVien.TenDangNhapCty.ToUpper().Equals("ITADMIN");
            NhanVienDB.DataSource = new D_DAILY().NhanVien();
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _DaiLyO);
            ClsChucNang.OpenForm(this);
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

        #region Biến
        D_DAILY _DaiLyD = new D_DAILY();
        O_DAILY _DaiLyO = new O_DAILY();
        TypeAssistant assistant;
        #endregion

        #region Sự kiện nút

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTen, _Tu = 2 });
            kiemTras.Add(new KiemTra() { _Control = iMaDL, _ChoQua = !_DaiLyD.KiemTraTonTai(_DaiLyO.ID,"MaDL", iMaDL.Text), _ThongBao2 = "Đã tồn tại", _Tu = 3, _Den = 10 });
            kiemTras.Add(new KiemTra() { _Control = iMaAGS, _Tu = 3, _Den = 10 });
            kiemTras.Add(new KiemTra() { _Control = iDiDong, _SDT = true });
            kiemTras.Add(new KiemTra() { _Control = iChinhSach });
            kiemTras.Add(new KiemTra() { _Control = iTinhTrang });
            kiemTras.Add(new KiemTra() { _Control = iNguoiDaiDienHD, _Tu = 3, _Den = 1000 });
            kiemTras.Add(new KiemTra() { _Control = iDienThoaiHD, _SDT = true });
            kiemTras.Add(new KiemTra() { _Control = iEmailHD, _Mail = true });
            kiemTras.Add(new KiemTra() { _Control = iEmailGiaoDich, _Tu = 10, _Den = 1000 });

            if (iEmailGiaoDich.Text.StartsWith("\r\n"))
                iEmailGiaoDich.Text = iEmailGiaoDich.Text.Substring(4);

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
                    for (int i = 0; i < 90; i++)
                    {
                        dic = new Dictionary<string, object>();
                        dic.Add("LoaiKhachHangSD", _DaiLyO.LoaiKhachHang);
                        dic.Add("ChinhSachID", iChinhSach.EditValue);
                        dic.Add("DaiLyID", CapNhatNum);
                        dic.Add("Ngay", "getdate() - " + i);
                        lstDicS.Add(dic);
                    }
                    new D_SODU_DAILY().ThemNhieu1Ban(lstDicS);
                    DaiLy();
                }
                GhiChuCmt(_DaiLyO.ID);
                (Owner.ActiveMdiChild as frmDaiLy).DuLieu(true);
                Close();
            }
        }

        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", iMaDL.Text);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", ClsDuLieu.NhanVien.ID);
                dic.Add("LoaiKhachHang", _DaiLyO.LoaiKhachHang);
                dic.Add("Ma", 0);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
            }
        }

        private void btnLS_Click(object sender, EventArgs e)
        {
            frmLSCS frm = new frmLSCS(_DaiLyO.ID, _DaiLyO.LoaiKhachHang);
            frm.ShowDialog(this);
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
           }));
        }

    }
}