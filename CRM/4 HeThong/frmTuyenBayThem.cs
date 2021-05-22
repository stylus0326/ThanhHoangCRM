using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmTuyenBayThem : DevExpress.XtraEditors.XtraForm
    {
        List<O_SANBAY> _list = new List<O_SANBAY>();
        O_TUYENBAY _TuyenBayO = new O_TUYENBAY();
        D_TUYENBAY _TuyenBayD = new D_TUYENBAY();
        public frmTuyenBayThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmTuyenBayThem(O_TUYENBAY tb)
        {
            InitializeComponent();
            iKyHieuDen.ReadOnly = iKyHieuDi.ReadOnly = true;
            _TuyenBayO = tb;
            Text += " sửa";
        }

        private void frmTuyenBayThem_Load(object sender, EventArgs e)
        {
            _list = new D_SANBAY().DuLieu();
            sanBayOBindingSource.DataSource = _list;
            XuLyDuLieu.ConvertClassToTable(this, _TuyenBayO);
            XuLyGiaoDien.OpenForm(this);
            btnLuu2.Visible = DuLieuTaoSan.Q.TuyenBayThemSua;
        }

        private void iKyHieuDi_EditValueChanged(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _list.Where(w => !w.ID.Equals(iKyHieuDi.EditValue));
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iKyHieuDi,_Tu=3,_Den = 100, },
            new KiemTra() { _Control = iKyHieuDen,_Tu=3,_Den = 5,_ChoQua = !_TuyenBayD.DaTonTai("Ten",iKyHieuDi.Text + "-" + iKyHieuDen.Text,_TuyenBayO.ID), _ThongBao2 = "Tuyến bay đã tồn tại" }};

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            List<Dictionary<string, object>> Lstdic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("KyHieuDen", iKyHieuDi.EditValue);
            dic.Add("KyHieuDi", iKyHieuDen.EditValue);
            dic.Add("Ten", iKyHieuDen.Text + "-" + iKyHieuDi.Text);
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            dic2.Add("KyHieuDen", iKyHieuDen.EditValue);
            dic2.Add("KyHieuDi", iKyHieuDi.EditValue);
            dic2.Add("Ten", iKyHieuDi.Text + "-" + iKyHieuDen.Text);
            Lstdic.Add(dic);
            Lstdic.Add(dic2);

            long a = _TuyenBayD.ThemNhieu1Ban(Lstdic);
            if (XuLyGiaoDien.ThongBao(Text, a > 0))
            {
                (Owner.ActiveMdiChild as frmTuyenBay).DuLieuSanBay();
                Close();
            }
        }

        private void frmTuyenBayThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu2.PerformClick();
        }
    }
}