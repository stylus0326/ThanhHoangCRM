using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmChinhSach : DevExpress.XtraEditors.XtraForm
    {
        public frmChinhSach()
        {
            InitializeComponent();
            GridViewHelper.SetFromGrid(this, GCCTCS, GVCTCS);
        }

        private void frmChinhSach_Load(object sender, EventArgs e)
        {
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu();
            loaiPhiBindingSource.DataSource = DuLieuTaoSan.LoaiPhi();
            TuyenBayOs = new D_TUYENBAY().DuLieu();
            tuyenBayOBindingSource.DataSource = TuyenBayOs;
            _ListHangBayO = new D_HANGBAY().DuLieu();
            DuLieu();
            XuLyGiaoDien.OpenForm(this);
            btnLuu.Enabled = DuLieuTaoSan.Q.ChinhSachThemSua;
        }

        #region Dữ liệu 
        public void LayChiTiet()
        {
            if (HienDu2)
                cTChinhSachOBindingSource.DataSource = _CTChinhSachD.DuLieu(_ChinhSachO.ID);
            else
                cTChinhSachOBindingSource.DataSource = _CTChinhSachD.DuLieu(_ChinhSachO.ID).Where(w => w.NgayB.Date > DateTime.Now.Date).ToList();
            GVCTCS.BestFitColumns();
        }

        public void DuLieu()
        {
            List<O_CHINHSACH> chinhSachOs = new D_CHINHSACH().DuLieu(HienDu, _LoaiKhachHang);
            chinhSachOBindingSource.DataSource = chinhSachOs;
            if (_ChinhSachO == null && chinhSachOs.Count > 0)
                _ChinhSachO = chinhSachOs[0];
            LayChiTiet();
        }
        #endregion

        #region Biến
        bool HienDu = false;
        bool HienDu2 = false;
        List<O_TUYENBAY> TuyenBayOs = new List<O_TUYENBAY>();
        DateTime Date = new DateTime();
        O_CTCHINHSACH _CTchinhSachO = new O_CTCHINHSACH();
        O_CHINHSACH _ChinhSachO;
        D_CTCHINHSACH _CTChinhSachD = new D_CTCHINHSACH();
        List<O_HANGBAY> _ListHangBayO = new List<O_HANGBAY>();
        int _LoaiKhachHang = 1;
        #endregion

        #region Giao diện
        private void iNCC_EditValueChanged(object sender, EventArgs e)
        {
            if (nCCOBindingSource.Count > 0)
            {
                O_NHACUNGCAP _NCCO = iNCC.GetSelectedDataRow() as O_NHACUNGCAP;
                if (_NCCO != null)
                {
                    if ((_NCCO.HangBay ?? string.Empty).Length > 1)
                    {
                        string[] NCCA = _NCCO.HangBay.Split('|');
                        if (NCCA.Length > 0)
                        {
                            hangBayOBindingSource.DataSource = _ListHangBayO.Where(w => NCCA.Contains(w.ID.ToString())).ToList();
                            iHang.EditValue = _ListHangBayO.Where(w => NCCA.Contains(w.ID.ToString())).ToList()[0].TenTat;
                        }
                    }
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            chk.Checked = btnHuy.Enabled = btnLuu.Enabled = false;
        }

        private void iDoanhSo_CheckedChanged(object sender, EventArgs e)
        {
            iDSTu.Enabled = iDSDen.Enabled = iDoanhSo.Checked;
            iDSTu.Value = iDSDen.Value = 0;
        }

        private void iThoiGianBay_CheckedChanged(object sender, EventArgs e)
        {
            iNgayBayA.Enabled = iNgayBayB.Enabled = iThoiGianBay.Checked;
            if (!iNgayBayA.Enabled)
                iNgayBayA.EditValue = iNgayBayB.EditValue = null;
        }

        private void iTatCaTuyenBay_CheckedChanged(object sender, EventArgs e)
        {
            iHanhTrinh.Text = string.Empty;
            iHanhTrinh.Enabled = !iTatCaTuyenBay.Checked;
        }

        private void iTatCaHangCho_CheckedChanged(object sender, EventArgs e)
        {
            iHangCho.Text = string.Empty;
            iHangCho.Enabled = !iTatCaHangCho.Checked;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iHang, _Tu = 3, _Den = 30, });
            kiemTras.Add(new KiemTra() { _Control = iLoaiPhi, _Tu = 3, _Den = 30, });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            if (!chk.Checked && _CTchinhSachO.NgayA < DateTime.Now.AddDays(30))
                if (XtraMessageBox.Show("Chỉnh chính sách sẽ ảnh hưởng tới số dư bạn muốn chỉnh sửa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;


            List<string> lstString = iHanhTrinh.Lines.ToList();
            string lstint = ",";
            if (!iTatCaTuyenBay.Checked)
                foreach (string str in lstString)
                {
                    if (str.Length > 0)
                        if (TuyenBayOs.Where(w => w.Ten.Replace(" ", string.Empty).Equals(str.Replace(" ", string.Empty))).Count() == 0)
                        {
                            XuLyGiaoDien.Alert("Hành trình " + str + " không tồn tại", Form_Alert.enmType.Warning);
                            lstint = string.Empty;
                            return;
                        }
                        else
                            lstint += TuyenBayOs.Where(w => w.Ten.Replace(" ", string.Empty).Equals(str.Replace(" ", string.Empty))).ToList()[0].ID.ToString() + " ,";
                }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("IDChinhSach", _ChinhSachO.ID);
            if (!iHanhTrinh.Text.Contains("-"))
                dic.Add("HanhTrinhID", iHanhTrinh.Text);
            else
                dic.Add("HanhTrinhID", lstint);

            long a = (!chk.Checked) ? _CTChinhSachD.CapNhat(dic, _CTchinhSachO.IDCT, "WHERE IDCT = {0}") : _CTChinhSachD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(igroupControl1.Text, a > 0))
                LayChiTiet();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            igroupControl1.Text = chk.Checked ? "Chi tiết chính sách thêm" : "Chi tiết chính sách sửa";
        }
        #endregion

        #region Sự khiện bản 

        private void GVCTCS_DoubleClick(object sender, EventArgs e)
        {
            if (GVCTCS.GetSelectedRows().Count() > 0)
            {
                _CTchinhSachO = GVCTCS.GetRow(GVCTCS.GetSelectedRows()[0]) as O_CTCHINHSACH;
                if (_CTchinhSachO != null)
                {
                    btnHuy.Enabled = btnLuu.Enabled = true;
                    XuLyDuLieu.ConvertClassToTable(this, _CTchinhSachO);
                    igroupControl1.Text = "Chi tiết chính sách sửa";
                }
            }
        }

        private void GVCTCS_Click(object sender, EventArgs e)
        {
            if (GVCTCS.GetSelectedRows().Count() > 0)
            {
                _CTchinhSachO = GVCTCS.GetRow(GVCTCS.GetSelectedRows()[0]) as O_CTCHINHSACH;
                if (_CTchinhSachO != null)
                {
                    XuLyDuLieu.ConvertClassToTable(this, _CTchinhSachO);
                    igroupControl1.Text = "Chi tiết chính sách";
                }
            }
        }

        private void GVCTCS_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is DateTime && (DateTime)e.Value == Date || e.Value == null)
                e.DisplayText = string.Empty;
        }

        private void GVCS_Click(object sender, EventArgs e)
        {
            if (GVCS.GetSelectedRows().Count() > 0)
            {
                _ChinhSachO = GVCS.GetRow(GVCS.GetSelectedRows()[0]) as O_CHINHSACH;
                if (_ChinhSachO != null)
                    LayChiTiet();
            }
        }

        private void grpc1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Hiện đủ":
                    HienDu = !HienDu;
                    DuLieu();
                    break;
                default:
                    new frmChinhSachThem(_LoaiKhachHang).ShowDialog(this);
                    break;
            }
        }

        private void GVCS_DoubleClick(object sender, EventArgs e)
        {
            if (GVCS.GetSelectedRows().Count() > 0)
            {
                _ChinhSachO = GVCS.GetRow(GVCS.GetSelectedRows()[0]) as O_CHINHSACH;
                if (_ChinhSachO != null)
                    new frmChinhSachThem(_ChinhSachO).ShowDialog(this);
            }
        }

        private void grpc2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (chinhSachOBindingSource.Count > 1)
            {
                switch (e.Button.Properties.Caption)
                {
                    case "Thêm":
                        XuLyDuLieu.ConvertClassToTable(this, new O_CTCHINHSACH());
                        igroupControl1.Text = "Chi tiết chính sách thêm";
                        btnHuy.Enabled = btnLuu.Enabled = true;
                        chk.Checked = true;
                        break;
                    default:
                        if (GVCTCS.GetSelectedRows().Count() > 0)
                        {
                            _CTchinhSachO = GVCTCS.GetRow(GVCTCS.GetSelectedRows()[0]) as O_CTCHINHSACH;
                            if (_CTchinhSachO != null)
                            {
                                btnHuy.Enabled = btnLuu.Enabled = true;
                                igroupControl1.Text = "Chi tiết chính sách sửa";
                                XuLyDuLieu.ConvertClassToTable(this, _CTchinhSachO);
                                chk.Checked = false;
                            }
                        }
                        break;
                }
            }
        }

        #endregion

        private void iHang_EditValueChanged(object sender, EventArgs e)
        {
            O_HANGBAY hb = (O_HANGBAY)iHang.Properties.GetRowByKeyValue(iHang.EditValue);
            List<IntString> lstis = new List<IntString>();
            if (hb != null)
            {
                if (hb.LoaiVe != null)
                {
                    string[] vs = hb.LoaiVe.Replace("\r", string.Empty).Split('\n');
                    for (int i = 0; i < vs.Count(); i++)
                    {
                        if (vs[i].Length > 0)
                            lstis.Add(new IntString() { Name = vs[i] });
                    }
                }
                loaiVeBindingSource.DataSource = lstis;
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!iTatCaHangCho.Checked)
                if (!iHangCho.Text.Contains(lookUpEdit1.Text))
                    iHangCho.Text += lookUpEdit1.Text + "\r\n";
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!iTatCaTuyenBay.Checked)
            {
                O_TUYENBAY tb = lookUpEdit2.GetSelectedDataRow() as O_TUYENBAY;
                string[] a = tb.Ten.Split('-');
                if (!iHanhTrinh.Text.Contains(a[0] + "-" + a[1]))
                    iHanhTrinh.Text += a[0] + "-" + a[1] + "\r\n";
            }
        }

        private void grpc1_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Đại lý" && e.Button.Properties.Checked == true)
                _LoaiKhachHang = 1; DuLieu();
        }

        private void grpc1_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Đại lý" && e.Button.Properties.Checked == false)
                _LoaiKhachHang = 2; DuLieu();
        }

        private void GVCTCS_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                O_CTCHINHSACH dl = View.GetRow(e.RowHandle) as O_CTCHINHSACH;
                if (dl.NgayB.Date > DateTime.Now.Date && e.Column.FieldName == "NgayB")
                    e.Appearance.BackColor = Color.Gold;
                if (dl.NgayA.Date > DateTime.Now.Date && e.Column.FieldName == "NgayA")
                    e.Appearance.BackColor = Color.Gold;
            }
        }

        private void grpc2_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Hiện đủ" && e.Button.Properties.Checked == true)
                HienDu2 = true;
            LayChiTiet();
        }

        private void grpc2_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Hiện đủ" && e.Button.Properties.Checked == false)
                HienDu2 = false;
            LayChiTiet();
        }

        private void iNgayA_EditValueChanged(object sender, EventArgs e)
        {
            iNgayB.Properties.MinValue = iNgayA.DateTime;
        }

        private void iNgayB_EditValueChanged(object sender, EventArgs e)
        {
            iNgayA.Properties.MaxValue = iNgayB.DateTime;
        }

        private void iNgayBayA_EditValueChanged(object sender, EventArgs e)
        {

            iNgayBayB.Properties.MinValue = iNgayBayA.DateTime;
        }

        private void iNgayBayB_EditValueChanged(object sender, EventArgs e)
        {
            iNgayBayA.Properties.MaxValue = iNgayBayB.DateTime;
        }
    }
}