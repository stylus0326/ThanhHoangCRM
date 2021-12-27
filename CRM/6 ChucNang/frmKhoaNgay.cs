using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace CRM
{
    public partial class frmKhoaNgay : DevExpress.XtraEditors.XtraForm
    {
        O_KHOANGAY _KhoaNgayO = new O_KHOANGAY();
        public frmKhoaNgay()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private void frmKhoaNgay_Load(object sender, EventArgs e)
        {
            DuLieu();
            dt.Columns.Add("MaCho", typeof(string));
            ClsChucNang.OpenForm(this);
        }

        private void main_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                O_KHOANGAY dl = View.GetRow(e.RowHandle) as O_KHOANGAY;
                if (e.Column.FieldName == "StrTrangThai")
                {
                    if (dl.HoatDong)
                        e.Appearance.BackColor = Color.Green;
                    else
                        e.Appearance.BackColor = Color.Crimson;
                }
                if (e.Column.FieldName == "StrNganHang")
                {
                    if (dl.NganHang)
                        e.Appearance.BackColor = Color.Green;
                    else
                        e.Appearance.BackColor = Color.Crimson;
                }
            }
        }

        private void main_Click(object sender, EventArgs e)
        {
            dt.Clear();
            _KhoaNgayO = (O_KHOANGAY)main.GetRow(main.GetSelectedRows()[0]);
            if (_KhoaNgayO.Code != null)
                if (_KhoaNgayO.Code.Length > 1)
                {
                    string[] Chuoico = _KhoaNgayO.Code.Replace(", ", "|").Split('|');
                    for (int i = 0; i < Chuoico.Length; i++)
                    {
                        dt.Rows.Add(Chuoico[i]);
                    }
                }
            gridControl2.DataSource = dt;
            chkNH.Checked = _KhoaNgayO.NganHang;
            chkSua.Checked = _KhoaNgayO.Sua;
            chkThem.Checked = _KhoaNgayO.Them;
            chkXoa.Checked = _KhoaNgayO.Xoa;
            chkSuaNH.Checked = _KhoaNgayO.SuaNH;
            chkThemNH.Checked = _KhoaNgayO.ThemNH;
            chkXoaNH.Checked = _KhoaNgayO.XoaNH;
            chkGD.Checked = _KhoaNgayO.HoatDong;
        }

        int _IDThoiGian = 2;
        private void chk2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bcmbThoiGian.Enabled = chk1.Checked;
            bdtpDen.Enabled = bdtpTu.Enabled = chk2.Checked;
        }

        void DuLieu()
        {
            string _Query = string.Empty;
            if (chk1.Checked)
                _Query += DuLieuTaoSan.ThoiGianRutGon("TuNgay")[_IDThoiGian];
            else if (chk2.Checked)
            {
                if (bdtpTu.EditValue != null && bdtpDen.EditValue != null)
                    _Query += string.Format("AND (convert(date, TuNgay) BETWEEN '{0}' AND '{1}')", ((DateTime)bdtpTu.EditValue).ToString("yyyyMMdd"), ((DateTime)bdtpDen.EditValue).ToString("yyyyMMdd"));
            }
            khoaNgayOBindingSource.DataSource = new D_KHOANGAY().DuLieu(_Query);
        }

        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IDThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DuLieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string CoDe = string.Empty;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CoDe += row[0].ToString() + ", ";
                }
                CoDe = CoDe.Substring(0, CoDe.Length - 2);
            }

            D_KHOANGAY bus = new D_KHOANGAY();
            Dictionary<string, object> dic = new Dictionary<string, object>()
                {
                    {"HoatDong",chkGD.Checked},
                    {"Them",chkThem.Checked},
                    {"Sua",chkSua.Checked},
                    {"Xoa",chkXoa.Checked},
                    {"NganHang",chkNH.Checked},
                    {"Code",CoDe},
                    {"ThemNH",chkThemNH.Checked},
                    {"SuaNH",chkSuaNH.Checked},
                    {"XoaNH",chkXoaNH.Checked},
                };
            if (XuLyGiaoDien.ThongBao(Text + " sửa", bus.CapNhat(dic, _KhoaNgayO.MaNgay, "WHERE MaNgay = {0}") > 0))
            {
                chkGD.Checked = chkNH.Checked = chkSua.Checked = chkThem.Checked = chkXoa.Checked = chkSuaNH.Checked = chkThemNH.Checked = chkXoaNH.Checked = false;
                dt.Clear();
                GM.Enabled = false;
                DuLieu();
            }
        }

        private void btnThemCode_Click(object sender, EventArgs e)
        {
            if (txtcode.Text.Length > 4)
            {
                dt.Rows.Add(txtcode.Text);
                gridControl2.DataSource = dt;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chkGD.Checked = chkNH.Checked = chkSua.Checked = chkThem.Checked = chkXoa.Checked = chkSuaNH.Checked = chkThemNH.Checked = chkXoaNH.Checked = false;
            dt.Clear();
            GM.Enabled = false;
        }

        private void main_DoubleClick(object sender, EventArgs e)
        {
            GM.Enabled = true;
        }

        string HangX = string.Empty;
        private void gridControl2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && HangX != string.Empty)
            {
                if (dt.Select("MaCho = '" + HangX + "'").Length > 0)
                {
                    dt.Rows.Remove(dt.Select("MaCho = '" + HangX + "'")[0]);
                    gridControl2.DataSource = dt;
                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            HangX = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaCho").ToString();
        }
    }
}