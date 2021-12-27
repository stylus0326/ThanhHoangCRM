using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace CRM
{
    public partial class frmQuyenNhanVienThem : XtraForm
    {
        private int ID = 0;
        public frmQuyenNhanVienThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmQuyenNhanVienThem(O_NHOMQUYEN Nq)
        {
            InitializeComponent();
            iTen.Text = Nq.Ten;
            ID = Nq.ID;
            Text += " sửa";

            foreach (Control ctl in Controls)
            {
                if (ctl is GroupControl)
                {
                    if ((ctl as GroupControl).CustomHeaderButtons.Count > 0)
                        Check(ctl, Nq);
                    foreach (Control ctl1 in (ctl as GroupControl).Controls)
                    {
                        if (ctl1 is CheckEdit)
                            Check(ctl1, Nq);
                        else if (ctl1 is GroupControl)
                        {
                            if ((ctl1 as GroupControl).CustomHeaderButtons.Count > 0)
                                Check(ctl1, Nq);
                            foreach (Control ctl2 in (ctl1 as GroupControl).Controls)
                            {
                                Check(ctl2, Nq);
                            }
                        }
                    }
                }
            }
        }

        void Check(Control ctl, O_NHOMQUYEN Nq)
        {
            foreach (PropertyInfo propertyInfo in Nq.GetType().GetProperties())
            {
                if (propertyInfo.Name == ctl.Name)
                {
                    if (ctl is GroupControl)
                        (ctl as GroupControl).CustomHeaderButtons[0].Properties.Checked = (bool)propertyInfo.GetValue(Nq, null);
                    else if (ctl is CheckEdit)
                        (ctl as CheckEdit).Checked = (bool)propertyInfo.GetValue(Nq, null);
                }
            }
        }

        private void frmQuyenNhanVienThem_Load(Object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
            btnSave.Visible = ClsDuLieu.Quyen.QuyenThemSua;
        }

        private void btnSave_Click(Object sender, EventArgs e)
        {
            #region kiểm tra điều kiện
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iTen } };

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }
            #endregion

            D_NHOMQUYEN cvb = new D_NHOMQUYEN();

            #region Kiểm tra tên tắt hãng bay
            if (cvb.KiemTraTonTai(iTen.Text, ID))
            {
                XuLyGiaoDien.Alert("Tên nhóm quyền đã tồn tại", Form_Alert.enmType.Warning);
                return;
            }
            #endregion

            #region Lưu
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Ten", iTen.Text);
            foreach (Control ctl in Controls)
            {
                if (ctl is GroupControl)
                {
                    if ((ctl as GroupControl).CustomHeaderButtons.Count > 0)
                        dic.Add(ctl.Name, (ctl as GroupControl).CustomHeaderButtons[0].Properties.Checked);
                    foreach (Control ctl1 in (ctl as GroupControl).Controls)
                    {
                        if (ctl1 is CheckEdit)
                            dic.Add(ctl1.Name, (ctl1 as CheckEdit).Checked);
                        else if (ctl1 is GroupControl)
                        {
                            if ((ctl1 as GroupControl).CustomHeaderButtons.Count > 0)
                                dic.Add(ctl1.Name, (ctl1 as GroupControl).CustomHeaderButtons[0].Properties.Checked);
                            foreach (Control ctl2 in (ctl1 as GroupControl).Controls)
                            {
                                dic.Add(ctl2.Name, (ctl2 as CheckEdit).Checked);
                            }
                        }
                    }
                }
            }
            if (XuLyGiaoDien.ThongBao(Text, (ID != 0) ? (cvb.CapNhat(dic, ID) > 0) : (cvb.ThemMoi(dic) > 0)))
            {
                (Owner.ActiveMdiChild as frmQuyenNhanVien).QuyenNhanVienOBindingSource.DataSource = new D_NHOMQUYEN().DuLieu();
                Close();
            }
            #endregion
        }

        private void Lv1TheoDoi_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            GroupControl Gp = sender as GroupControl;
            foreach (Control ctl1 in Gp.Controls)
            {
                ctl1.Enabled = true;
            }
        }

        private void Lv1TheoDoi_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            GroupControl Gp = sender as GroupControl;

            foreach (Control ctl1 in Gp.Controls)
            {
                ctl1.Enabled = false;
                if (ctl1 is CheckEdit)
                    (ctl1 as CheckEdit).Checked = false;
                else if (ctl1 is GroupControl)
                {
                    if ((ctl1 as GroupControl).CustomHeaderButtons.Count > 0)
                        (ctl1 as GroupControl).CustomHeaderButtons[0].Properties.Checked = false;
                    foreach (Control ctl2 in (ctl1 as GroupControl).Controls)
                    {
                        (ctl2 as CheckEdit).Checked = false;
                    }
                }
            }
        }

        private void chAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in Controls)
            {
                if (ctl is GroupControl)
                {
                    if ((ctl as GroupControl).CustomHeaderButtons.Count > 0)
                        (ctl as GroupControl).CustomHeaderButtons[0].Properties.Checked = chAll.Checked;
                    foreach (Control ctl1 in (ctl as GroupControl).Controls)
                    {
                        if (ctl1 is CheckEdit)
                            (ctl1 as CheckEdit).Checked = chAll.Checked;
                        else if (ctl1 is GroupControl)
                        {
                            if ((ctl1 as GroupControl).CustomHeaderButtons.Count > 0)
                                (ctl1 as GroupControl).CustomHeaderButtons[0].Properties.Checked = chAll.Checked;
                            foreach (Control ctl2 in (ctl1 as GroupControl).Controls)
                            {
                                (ctl2 as CheckEdit).Checked = chAll.Checked;
                            }
                        }
                    }
                }
            }
            iTen.Focus();
        }
    }
}