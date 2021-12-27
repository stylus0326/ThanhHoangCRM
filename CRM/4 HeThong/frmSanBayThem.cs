using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmSanBayThem : DevExpress.XtraEditors.XtraForm
    {
        O_SANBAY _SanBayO = new O_SANBAY();
        D_SANBAY _SanBayD = new D_SANBAY();
        public frmSanBayThem(bool a = false)
        {
            InitializeComponent();
            if (a)
                Text = "Khu vực";
            Text += " thêm";
        }

        public frmSanBayThem(O_SANBAY sanBayO, bool a = false)
        {
            InitializeComponent();
            iKyHieu.ReadOnly = true;
            _SanBayO = sanBayO;
            if (a)
                Text = "Khu vực";
            Text += " sửa";
        }

        private void frmSanBayThem_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.ConvertClassToTable(this, _SanBayO);
            ClsChucNang.OpenForm(this);
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iTenDayDu,_Tu=3,_Den = 100,_ChoQuaThang = !_SanBayD.KiemTraTonTai(_SanBayO.ID,"TenDayDu",iKyHieu.Text), _ThongBao2 = "Sân bay đã tồn tại" },
            new KiemTra() { _Control = iKyHieu,_Tu=3,_Den = 5,_ChoQuaThang = !_SanBayD.KiemTraTonTai(_SanBayO.ID,"KyHieu",iKyHieu.Text), _ThongBao2 = "Sân bay đã tồn tại" }};

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("TenDayDu", iTenDayDu.Text);
            dic.Add("KyHieu", iKyHieu.Text);
            dic.Add("NoiDia", iNoiDia.Checked);
            dic.Add("KhuVuc", (Text.StartsWith("Khu vực")));
            long CapNhatNum = (_SanBayO.ID > 0) ? (_SanBayD.CapNhat(dic, _SanBayO.ID) > 0 ? _SanBayO.ID : 0) : _SanBayD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                if (Text.StartsWith("Khu vực"))
                    (Owner as frmNCCThem).KhuVuc();
                else
                    (Owner.ActiveMdiChild as frmTuyenBay).DuLieuSanBay();
                Close();
            }
        }

        private void frmSanBayThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu2.PerformClick();
        }
    }
}