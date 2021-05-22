using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNganHangThem : DevExpress.XtraEditors.XtraForm
    {

        public frmNganHangThem()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmNganHangThem(O_NGANHANG nh)
        {
            InitializeComponent();
            nho = nh;
            Text += " sửa";
        }

        private void frmThemNganHang_Load(object sender, EventArgs e)
        {
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, nho);
            XuLyGiaoDien.OpenForm(this);
        }

        #region Biến
        private O_NGANHANG nho = new O_NGANHANG();
        #endregion

        #region Sự kiện nút

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            D_NGANHANG nhb = new D_NGANHANG();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            long CapNhatNum = nho.ID > 0 ? nhb.CapNhat(dic, nho.ID) : nhb.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text, CapNhatNum > 0))
            {
                if (nho.ID < 1)
                {
                    List<Dictionary<string, object>> lstDicS = new List<Dictionary<string, object>>();
                    for (int i = 0; i < 30; i++)
                    {
                        dic = new Dictionary<string, object>();
                        dic.Add("NganHangID", CapNhatNum);
                        dic.Add("SoDuCuoi", 0);
                        dic.Add("Ngay", "getdate() - " + i);
                        lstDicS.Add(dic);
                    }
                    new D_SODU_NGANHANG().ThemNhieu1Ban(lstDicS);
                }

                (Owner.ActiveMdiChild as frmNganHang).LayDLNganHang();
                (Owner.ActiveMdiChild as frmNganHang).TaiLaiDuLieu();
                (Owner.ActiveMdiChild as frmNganHang).LayDLKhac();
                GhiChuCmt(nho.ID);
                Close();
            }
        }

        private void iEx_CheckedChanged(object sender, EventArgs e)
        {
            iActive2.Enabled = iEx.Checked;
        }

        #region Tạo Ghi Chú
        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", string.Empty);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
            }
        }
        #endregion

        #endregion

        private void frmNganHangThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btnLuu.PerformClick();
        }
    }
}