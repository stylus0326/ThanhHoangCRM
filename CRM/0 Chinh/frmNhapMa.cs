using DataTransferObject;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmNhapMa : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapMa()
        {
            InitializeComponent();
        }

        private void frmNhapMa_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
        }

        #region Dữ liệu 
        void ActiveSoft()
        {
            if (btnActive.Text != "Tiếp tục")
            {
                try
                {
                    string Key = TMD5.Base64Decode(TMD5.Base64Decode(TMD5.Base64Decode(txtKey.Text)));
                    string[] subs = Key.Split(new char[] { '@' });
                    DateTime ngayBQ = new DateTime(int.Parse(subs[2].Substring(4)), int.Parse(subs[2].Substring(2, 2)), int.Parse(subs[2].Substring(0, 2)));
                    DateTime ngaySV = DateTime.Now;

                    if (subs.Length != 4 || subs[0] != "ThanhHoangCRM" || subs[1] != "TTTTUNG")
                    {
                        BaoLoi(false, "Mã kích hoạt không bợp lệ !!", Color.Crimson);
                        return;
                    }
                    else if (ngaySV.Date.Subtract(ngayBQ.Date.AddYears(int.Parse(subs[3]))).Days > 0)
                    {
                        BaoLoi(false, "Key hết hạn", Color.Crimson);
                        return;
                    }
                    else
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
                        if (key == null)
                            key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\THCRM");

                        key.SetValue("MaKichHoat", txtKey.Text);
                        key.Close();
                        BaoLoi(true, "Kích hoạt thành công", Color.Green);

                    }
                }
                catch
                {
                    BaoLoi(false, "Mã kích hoạt không bợp lệ !!", Color.Crimson);
                    return;
                }
            }
            else
            {
                if (Owner is frmDangNhap)
                    (Owner as frmDangNhap).CheckBanQuyen();
                this.Close();
            }
        }

        void BaoLoi(bool Success, string Loi, Color clr)
        {
            lblMess.Text = Loi;
            groupBox1.ForeColor = lblMess.ForeColor = clr;
            if (Success)
                btnActive.Text = "Tiếp tục";
        }

        #endregion

        #region Sự kiện nút
        private void btnActive_Click(object sender, EventArgs e)
        {
            ActiveSoft();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Sự khiện khác 
        private void frmNhapMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                ActiveSoft();
        }
        #endregion
    }
}