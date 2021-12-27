using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmKPIHangMucThem : DevExpress.XtraEditors.XtraForm
    {
        O_KPIHANGMUC kpi = new O_KPIHANGMUC();
        D_KPIHANGMUC kpid = new D_KPIHANGMUC();

        public frmKPIHangMucThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmKPIHangMucThem(O_KPIHANGMUC tb)
        {
            InitializeComponent();
            Text += " sửa";
            kpi = tb;
            txtMauEmail.Text = tb.NoiDung;
        }

        private void frmKPIHangMucThem_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.ConvertClassToTable(this, kpi);
            ClsChucNang.OpenForm(this);
            btnLuu2.Visible = ClsDuLieu.Quyen.ChinhSachThemSua;
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("NoiDung", txtMauEmail.Text);
            long CapNhatNum = (kpi.ID > 0) ? (kpid.CapNhat(dic, kpi.ID) > 0 ? kpi.ID : 0) : kpid.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                (Owner.ActiveMdiChild as frmKPIHangMuc).TaiLaiKPI();
                Close();
            }
        }

        private void frmKPIHangMucThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu2.PerformClick();
        }
    }
}