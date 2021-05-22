using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmChinhSachThem : DevExpress.XtraEditors.XtraForm
    {
        O_CHINHSACH _ChinhSachO = new O_CHINHSACH();
        D_CHINHSACH _ChinhSachD = new D_CHINHSACH();

        public frmChinhSachThem(int LoaiKhachHang)
        {
            InitializeComponent();
            _ChinhSachO.LoaiKhachHang = LoaiKhachHang;
            Text += " thêm";
        }

        public frmChinhSachThem(O_CHINHSACH chinhSach)
        {
            InitializeComponent();
            _ChinhSachO = chinhSach;
            Text += " sửa";
        }

        private void frmChinhSachThem_Load(object sender, EventArgs e)
        {
            intStringBindingSource.DataSource = DuLieuTaoSan.LoaiKhachHang_Ve();
            XuLyDuLieu.ConvertClassToTable(this, _ChinhSachO);
            XuLyGiaoDien.OpenForm(this);
            btnLuu.Visible = DuLieuTaoSan.Q.ChinhSachThemSua;
        }

        #region Sự kiện nút
        private void iAnhCty_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            XtraOpenFileDialog open = new XtraOpenFileDialog();
            open.Title = "Open Image";
            open.Filter = "Image files (*.jpg;*.jpeg,*.png)|*.JPG;*.JPEG;*.PNG";
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (iAnhCS.Image != null)
                        new frmXemAnh(iAnhCS.Image).ShowDialog();
                    else
                    {
                        if (open.ShowDialog() == DialogResult.OK)
                            iAnhCS.Image = new Bitmap(open.FileName);
                    }
                    break;

                case MouseButtons.Right:
                    if (open.ShowDialog() == DialogResult.OK)
                        iAnhCS.Image = new Bitmap(open.FileName);
                    break;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>();
            kiemTras.Add(new KiemTra() { _Control = iTen, _Tu = 5, _Den = 30, _ChoQua = !_ChinhSachD.DaTonTai("Ten", iTen.Text, _ChinhSachO.ID), _ThongBao2 = "Đã tồn tại" });

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);

            long a = (_ChinhSachO.ID > 0) ? _ChinhSachD.CapNhat(dic, _ChinhSachO.ID) : _ChinhSachD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, a > 0))
            {
                (Owner.ActiveMdiChild as frmChinhSach).DuLieu();
                Close();
            }
        }
        #endregion

        private void frmChinhSachThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}