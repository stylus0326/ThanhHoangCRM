using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNCCThem : DevExpress.XtraEditors.XtraForm
    {
        O_NHACUNGCAP _NCCO = new O_NHACUNGCAP();
        D_NHACUNGCAP _NCCD = new D_NHACUNGCAP();
        public frmNCCThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmNCCThem(O_NHACUNGCAP nCCO)
        {
            InitializeComponent();
            _NCCO = nCCO;
            Text += " sửa";
        }

        private void frmNCCThem_Load(object sender, EventArgs e)
        {
            KhuVuc();
            _DataHangBay.Columns.Add("ID", typeof(int));
            _DataHangBay.Columns.Add("Ten", typeof(string));
            _lstHangBayO = new D_HANGBAY().DuLieu();
            hangBayOBindingSource.DataSource = _lstHangBayO;

            if ((_NCCO.HangBay ?? string.Empty).Length > 1)
            {
                string[] NCCA = _NCCO.HangBay.Split('|');
                for (int i = 0; i < NCCA.Length - 1; i++)
                {
                    _HangBayO = _lstHangBayO.Where(w => w.ID.Equals(int.Parse(NCCA[i]))).ToList()[0];
                    _DataHangBay.Rows.Add(_HangBayO.ID, _HangBayO.TenHang);
                }
                GCNCC.DataSource = _DataHangBay;
            }
            DSNH.DataSource = new D_NGANHANG().All();
            XuLyDuLieu.ConvertClassToTable(this, _NCCO);
            XuLyGiaoDien.OpenForm(this);
        }

        public void KhuVuc()
        {
            sanBayOBindingSource.DataSource = new D_SANBAY().DuLieu(1);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string NCC = string.Empty;
            if (_DataHangBay.Rows.Count > 0)
            {
                foreach (DataRow row in _DataHangBay.Rows)
                {
                    NCC += row["ID"].ToString() + "|";
                }
            }

            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTenDayDu, _Tu = 2, _Den = 50 });
            kiemTras.Add(new KiemTra() { _Control = iTen, _Tu = 2, _Den = 50, _ChoQua = !_NCCD.DaTonTai("Ten", iTen.Text, _NCCO.ID), _ThongBao2 = "Đã tồn tại" });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("HangBay", NCC);
            long CapNhatNum = (_NCCO.ID > 0) ? _NCCD.CapNhat(dic, _NCCO.ID) : _NCCD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                if (_NCCO.ID < 1)
                {
                    List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
                    for (int i = 0; i < 180; i++)
                    {
                        dic = new Dictionary<string, object>();
                        dic.Add("NCCID", CapNhatNum);
                        dic.Add("SoDuCuoi", 0);
                        dic.Add("SoDuThucTe", 0);
                        dic.Add("Ngay", "getdate() - " + i);
                        lstDicS.Add(dic);
                    }
                    new D_SODU_HANG().ThemNhieu1Ban(lstDicS);
                }

                (Owner.ActiveMdiChild as frmHangBay).DuLieu();
                Close();
            }
        }

        DataTable _DataHangBay = new DataTable();
        O_HANGBAY _HangBayO = new O_HANGBAY();
        List<O_HANGBAY> _lstHangBayO = new List<O_HANGBAY>();
        private void lueNCC_EditValueChanged(object sender, EventArgs e)
        {
            _HangBayO = (O_HANGBAY)lueNCC.GetSelectedDataRow();
            if ((from row in _DataHangBay.AsEnumerable() where row.Field<int>("ID") == _HangBayO.ID select row.Field<int>("ID")).Count() == 0)
                _DataHangBay.Rows.Add(_HangBayO.ID, _HangBayO.TenHang);
            GCNCC.DataSource = _DataHangBay;
        }

        private void frmNCCThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }

        private void iHang_CheckedChanged(object sender, EventArgs e)
        {
            iG2.Enabled = iHang.Checked;
            iG3.Enabled = !iHang.Checked;
        }
    }
}