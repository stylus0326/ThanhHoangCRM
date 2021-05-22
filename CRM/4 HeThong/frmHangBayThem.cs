using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmHangBayThem : DevExpress.XtraEditors.XtraForm
    {
        public frmHangBayThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmHangBayThem(HangBayO _hangBay)
        {
            InitializeComponent();
            _HangBay = _hangBay;
            Text += " sửa";
        }

        private void frmHangBayThem_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.ConvertClassToTable(this, _HangBay);
            XuLyGiaoDien.OpenForm(this);
            btnLuu.Visible = DuLieuTaoSan.Q.HangBayThemSua;
        }

        #region Biến
        HangBayD _HangBayD = new HangBayD();
        HangBayO _HangBay = new HangBayO();
        #endregion

        #region sự kiện controls
        private void iLogoHang_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog open = new XtraOpenFileDialog();
            open.Title = "Open Image";
            open.Filter = "Image files (*.jpg;*.jpeg,*.png)|*.JPG;*.JPEG;*.PNG";
            if (open.ShowDialog() == DialogResult.OK)
                iLogoHang.Image = new Bitmap(open.FileName);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTenHang, _Tu = 5, _Den = 30, });
            kiemTras.Add(new KiemTra() { _Control = iTenTat, _Tu = 2, _Den = 5, _ChoQua = !_HangBayD.DaTonTai("TenTat", iTenTat.Text, _HangBay.ID), _ThongBao2 = "Đã tồn tại" });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            long a = (_HangBay.ID > 0) ? _HangBayD.CapNhat(dic, _HangBay.ID) : _HangBayD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, a > 0))
            {
                (Owner.ActiveMdiChild as frmHangBay).DuLieu();
                Close();
            }
        }
        #endregion

        private void frmHangBayThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}