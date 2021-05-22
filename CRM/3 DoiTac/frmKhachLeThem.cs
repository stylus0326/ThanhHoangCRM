using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmKhachLeThem : DevExpress.XtraEditors.XtraForm
    {

        public frmKhachLeThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmKhachLeThem(O_DAILY _doiTuongO)
        {
            InitializeComponent();
            _DaiLyO = _doiTuongO;
            Text += " sửa";
        }

        private void frmKhachLeThem_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.ConvertClassToTable(this, _DaiLyO);
            btnLuu.Visible = DuLieuTaoSan.Q.KhachLeThemSua;
            XuLyGiaoDien.OpenForm(this);
        }

        #region Biến
        D_DAILY _DaiLyD = new D_DAILY();
        O_DAILY _DaiLyO = new O_DAILY();
        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTen, _Tu = 3, _Den = 30, });
            kiemTras.Add(new KiemTra() { _Control = iNguoiDaiDienHD, _Tu = 3, _Den = 30, });
            kiemTras.Add(new KiemTra() { _Control = iDiDong, _SDT = true, _ChoQua = !_DaiLyD.DaTonTai("DiDong", iDiDong.Text, _DaiLyO.ID, "AND LoaiKhachHang = 3"), _ThongBao2 = "Đã tồn tại" });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("LoaiKhachHang", 3);
            long a = (_DaiLyO.ID > 0) ? _DaiLyD.CapNhat(dic, _DaiLyO.ID) : _DaiLyD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, a > 0))
            {
                if (Owner.ActiveMdiChild is frmKhachLe)
                    (Owner.ActiveMdiChild as frmKhachLe).DuLieu();
                else if (Owner is frmVeThem)
                    (Owner as frmVeThem).DuLieuKhachLe(a);
                else
                    (Owner as frmKhachSanThem).DuLieuKhachLe(a);
                Close();
            }
        }


        private void frmKhachLeThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}