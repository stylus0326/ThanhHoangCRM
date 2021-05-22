using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmKPIThem : DevExpress.XtraEditors.XtraForm
    {
        O_KPI kpi = new O_KPI();
        D_KPI kpid = new D_KPI();
        int _NhanVien = 0;
        int _Diem = 0;

        public frmKPIThem(int NhanVien, int diem)
        {
            InitializeComponent();
            Text += " thêm";
            _NhanVien = NhanVien;
            _Diem = diem;
        }

        public frmKPIThem(O_KPI tb, int diem)
        {
            InitializeComponent();
            Text += " sửa";
            kpi = tb;
            _NhanVien = tb.NhanVien;
            _Diem = diem;
        }

        private void frmKPIThem_Load(object sender, EventArgs e)
        {
            kPIHangMucOBindingSource.DataSource = new D_KPIHANGMUC().DuLieu1();
            XuLyDuLieu.ConvertClassToTable(this, kpi);
            XuLyGiaoDien.OpenForm(this);
            btnLuu2.Visible = DuLieuTaoSan.Q.TuyenBayThemSua;
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            if (iDiem.Value == 0)
            {
                XuLyGiaoDien.ShowToolTip(iDiem, "Vui lòng cho điểm");
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("NhanVien", _NhanVien);
            long CapNhatNum = (kpi.ID > 0) ? (kpid.CapNhat(dic, kpi.ID) > 0 ? kpi.ID : 0) : kpid.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                (Owner as frmNhanVienThem).TaiLaiKPI();
                Close();
            }
        }

        private void frmKPIThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu2.PerformClick();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            O_KPIHANGMUC _lpid = lookUpEdit1.GetSelectedDataRow() as O_KPIHANGMUC;
            iDiem.Value = _lpid.Diem;
            iNoiDung.Text = _lpid.Muc;
        }

        private void iDiem_EditValueChanged(object sender, EventArgs e)
        {
            if (iDiem.Value + _Diem > 100)
                iDiem.Value = 100 - _Diem;
            else if (iDiem.Value + _Diem < 0)
                iDiem.Value = 0 - _Diem;
        }
    }
}