using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmDoiMatKhau : XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = txtMatKhauCu, _ChoQuaThang = TMD5.TMd5Hash(txtMatKhauCu.Text) == DuLieuTaoSan.NV.MatKhauCty, _ThongBao2 = "Mật khẩu sai" } ,
            new KiemTra() { _Control = txtMatKhauMoi },
            new KiemTra() { _Control = iMatKhauCty, _ChoQuaThang = iMatKhauCty.Text == txtMatKhauMoi.Text, _ThongBao2 = "Mật khẩu mới không khớp" }};

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("MatKhauCty", TMD5.TMd5Hash(iMatKhauCty.Text));

            if (XuLyGiaoDien.ThongBao(Text, new D_DAILY().CapNhat(dic, DuLieuTaoSan.NV.ID) > 0))
                Close();
        }
    }
}