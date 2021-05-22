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
        NCCO _NCCO = new NCCO();
        NCCD _NCCD = new NCCD();
        public frmNCCThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmNCCThem(NCCO nCCO)
        {
            InitializeComponent();
            _NCCO = nCCO;
            Text += " sửa";
        }

        private void frmNCCThem_Load(object sender, EventArgs e)
        {
            _DataHangBay.Columns.Add("ID", typeof(int));
            _DataHangBay.Columns.Add("Ten", typeof(string));
            _lstHangBayO = new HangBayD().DuLieu();
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
            XuLyDuLieu.ConvertClassToTable(this, _NCCO);
            XuLyGiaoDien.OpenForm(this);
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
                    for (int i = 0; i < 30; i++)
                    {
                        dic = new Dictionary<string, object>();
                        dic.Add("NCCID", CapNhatNum);
                        dic.Add("SoDuCuoi", 0);
                        dic.Add("SoDuThucTe", 0);
                        dic.Add("Ngay", "getdate() - " + i);
                        lstDicS.Add(dic);
                    }
                    new SoDu_HangD().ThemNhieu1Ban(lstDicS);
                }

                (Owner.ActiveMdiChild as frmHangBay).DuLieu();
                Close();
            }
        }

        DataTable _DataHangBay = new DataTable();
        HangBayO _HangBayO = new HangBayO();
        List<HangBayO> _lstHangBayO = new List<HangBayO>();
        private void lueNCC_EditValueChanged(object sender, EventArgs e)
        {
            _HangBayO = (HangBayO)lueNCC.GetSelectedDataRow();
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
    }
}