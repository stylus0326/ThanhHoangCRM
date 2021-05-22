using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmSignInThem : DevExpress.XtraEditors.XtraForm
    {
        public frmSignInThem()
        {
            InitializeComponent();
            Text += " thêm";
            iDaiLy.Properties.ReadOnly = false;
        }

        public frmSignInThem(DaiLyO dl)
        {
            InitializeComponent();
            _SignInO.DaiLy = dl.ID;
            Text += " thêm";
        }

        public frmSignInThem(SignInO si)
        {
            InitializeComponent();
            _SignInO = si;
            Text += " sửa";
        }


        private void frmThemSignIn_Load(object sender, EventArgs e)
        {
            daiLyOBindingSource.DataSource = new DaiLyD().All(false);
            hangBayOBindingSource.DataSource = new HangBayD().DuLieu().Where(w => w.SapXep);
            if (hangBayOBindingSource.Count < 21)
                iHangBay.Properties.DropDownRows = hangBayOBindingSource.Count;
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, _SignInO);
            XuLyGiaoDien.OpenForm(this);
        }

        #region Biến
        SignInO _SignInO = new SignInO();
        SignInD _SignInD = new SignInD();
        #endregion

        #region Sự kiện nút
        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iSignIn,_Tu=2,_Den = 20,_ChoQuaThang = !new SignInD().DaTonTai(string.Format("WHERE SignIn='{0}' AND ID <> {1}",iSignIn.Text,_SignInO.ID)), _ThongBao2 = "Đã tồn tại" }};

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            long CapNhatNum = (_SignInO.ID > 0) ? (_SignInD.CapNhat(dic, _SignInO.ID) > 0 ? _SignInO.ID : 0) : _SignInD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                if (Owner is frmSignIn)
                    (Owner as frmSignIn).TaiLaiSignIn();
                else if (Owner is frmDaiLyThem)
                    (Owner as frmDaiLyThem).TaiLaiSignIn();
                else if (Owner is frmNhanVienThem)
                    (Owner as frmNhanVienThem).TaiLaiSignIn();
                Close();
            }
        }
        #endregion

        private void frmSignInThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}