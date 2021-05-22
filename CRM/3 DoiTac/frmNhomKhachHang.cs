using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace CRM
{
    public partial class frmNhomKhachHang : DevExpress.XtraEditors.XtraForm
    {
        int _LoaiKhachHang = 1;
        O_NHOMDAILY _NhomDaiLyO = new O_NHOMDAILY();
        D_NHOMDAILY _NhomDaiLyD = new D_NHOMDAILY();
        D_TRANGTHAI _TinhTrangD = new D_TRANGTHAI();
        List<O_NHOMDAILY> _ListNhomDaiLyO = new List<O_NHOMDAILY>();
        List<O_TRANGTHAI> _ListTinhTrangO = new List<O_TRANGTHAI>();

        public frmNhomKhachHang(int LoaiKhachHang)
        {
            InitializeComponent();
            _LoaiKhachHang = LoaiKhachHang;
            GVNKH.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
            GVTTKH.CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
        }

        private void frmNhomKhachHang_Load(object sender, EventArgs e)
        {
            _ListNhomDaiLyO = _NhomDaiLyD.DuLieu(_LoaiKhachHang);
            nhomKhachHangOBindingSource.DataSource = _ListNhomDaiLyO;
            _ListTinhTrangO = _TinhTrangD.DuLieu(_LoaiKhachHang, false);
            trangThaiOBindingSource.DataSource = _ListTinhTrangO;
            XuLyGiaoDien.OpenForm(this);
        }

        private void GVNKH_Click(object sender, EventArgs e)
        {
            if (GVNKH.GetSelectedRows().Count() > 0)
            {
                _NhomDaiLyO = GVNKH.GetRow(GVNKH.GetSelectedRows()[0]) as O_NHOMDAILY;
                if (_NhomDaiLyO != null)
                {
                    iTen.Text = _NhomDaiLyO.Ten;
                    iTu.Value = _NhomDaiLyO.Tu;
                    iDen.Value = _NhomDaiLyO.Den;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!checkEdit1.Checked && _NhomDaiLyO.ID < 1)
            {
                XtraMessageBox.Show("Nếu muốn thêm mới vui lòng chọn vào [Thêm]", "Thông báo");
                return;
            }

            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTen, _Tu = 3, _Den = 30, });
            kiemTras.Add(new KiemTra() { _Control = iTu, _Tu = 0, _Den = 30, _ChoQua = !(_ListNhomDaiLyO.Where(w => iTu.Value > w.Tu - 1 && w.Den + 1 > iTu.Value && !w.ID.Equals(checkEdit1.Checked ? 0 : _NhomDaiLyO.ID)).Count() > 0), _ThongBao2 = "Giá trị này đã tồn tại" });
            kiemTras.Add(new KiemTra() { _Control = iDen, _Tu = 0, _Den = 30, _ChoQua = !(_ListNhomDaiLyO.Where(w => iDen.Value > w.Tu - 1 && w.Den + 1 > iDen.Value && !w.ID.Equals(checkEdit1.Checked ? 0 : _NhomDaiLyO.ID)).Count() > 0) && iDen.Value - 1000000 > iTu.Value, _ThongBao2 = "Giá trị này đã tồn tại" });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("LoaiKhachHang", _LoaiKhachHang);
            dic.Add("Den", iDen.Value);
            dic.Add("Tu", iTu.Value);
            dic.Add("Ten", iTen.EditValue);
            long a = !checkEdit1.Checked ? _NhomDaiLyD.CapNhat(dic, _NhomDaiLyO.ID) : _NhomDaiLyD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao("Nhóm " + (checkEdit1.Checked ? "thêm" : "sửa"), a > 0))
            {
                _ListNhomDaiLyO = _NhomDaiLyD.DuLieu(_LoaiKhachHang);
                nhomKhachHangOBindingSource.DataSource = _ListNhomDaiLyO;
                (Owner.ActiveMdiChild as frmDaiLy).DuLieu();

            }
        }

        private void GVNKH_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                Point p2 = MousePosition;
                pMenu.ShowPopup(p2);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVNKH.GetSelectedRows().Count() > 0)
            {
                _NhomDaiLyO = GVNKH.GetRow(GVNKH.GetSelectedRows()[0]) as O_NHOMDAILY;
                if (_NhomDaiLyO != null)
                {
                    XuLyGiaoDien.ThongBao(Text, _NhomDaiLyD.Xoa(_NhomDaiLyO.ID) > 0, true);
                    _ListNhomDaiLyO = _NhomDaiLyD.DuLieu(_LoaiKhachHang);
                    nhomKhachHangOBindingSource.DataSource = _ListNhomDaiLyO;
                }
            }

        }

        O_TRANGTHAI _TinhTrangO = new O_TRANGTHAI();
        private void GVTTKH_Click(object sender, EventArgs e)
        {
            if (GVTTKH.GetSelectedRows().Count() > 0)
            {
                _TinhTrangO = GVTTKH.GetRow(GVTTKH.GetSelectedRows()[0]) as O_TRANGTHAI;
                if (_TinhTrangO != null)
                {
                    iTenTrangThai.Text = _TinhTrangO.TenTrangThai;
                }
            }
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            if (!checkEdit2.Checked && _TinhTrangO.ID < 1)
            {
                XtraMessageBox.Show("Nếu muốn thêm mới vui lòng chọn vào [Thêm]", "Thông báo");
                return;
            }

            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTenTrangThai, _Tu = 3, _Den = 30, _ChoQua = !(_ListTinhTrangO.Where(w => w.TenTrangThai.Equals(iTenTrangThai.Text) && !w.ID.Equals(checkEdit2.Checked ? 0 : _TinhTrangO.ID)).Count() > 0), _ThongBao2 = "Giá trị này đã tồn tại" });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("TenTrangThai", iTenTrangThai.Text);
            dic.Add("LoaiKhachHang", _LoaiKhachHang);
            long a = !checkEdit2.Checked ? _TinhTrangD.CapNhat(dic, _TinhTrangO.ID) : _TinhTrangD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao("Tình trạng " + (checkEdit1.Checked ? "thêm" : "sửa"), a > 0))
            {
                _ListTinhTrangO = _TinhTrangD.DuLieu(_LoaiKhachHang, false);
                trangThaiOBindingSource.DataSource = _ListTinhTrangO;
                (Owner.ActiveMdiChild as frmDaiLy).DuLieu();
            }
        }
    }
}