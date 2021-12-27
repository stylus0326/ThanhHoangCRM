using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmDangNhap : XtraForm
    {
        #region MoveF
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void pnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //string zPath = Path.GetDirectoryName(Application.ExecutablePath);
            //DirectoryInfo d = new DirectoryInfo(zPath);//Assuming Test is your Folder
            //FileInfo[] Files = d.GetFiles("*.xml"); //Getting Text files
            //foreach (FileInfo file in Files)
            //{
            //    File.Delete(file.FullName);
            //}
            //Files = d.GetFiles("*.pdb"); //Getting Text files
            //foreach (FileInfo file in Files)
            //{
            //    File.Delete(file.FullName);
            //}

            CheckBanQuyen();

            #region Khiểm tra phiên bản
            try
            {
                string sPath = Path.GetDirectoryName(Application.ExecutablePath);
                string sAUFilePath = sPath + "\\ThanhHoangUpdate.exe";
                string sNewAUFilePath = sPath + "\\ThanhHoangUpdate.ex_";


                FileInfo newFi = new FileInfo(sNewAUFilePath);
                if (newFi.Exists)
                {
                    File.Delete(sAUFilePath);
                    File.Move(sNewAUFilePath, sAUFilePath);
                }

                FileInfo fi = new FileInfo(sAUFilePath);
                if (fi.Exists)
                {
                    System.Diagnostics.Process.Start(sAUFilePath);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            lblver.Text += ClsDuLieu.PhienBan.Split('-')[0];
        }

        #region Dữ liệu 
        void isLogin()
        {
            D_NHOMQUYEN nqb = new D_NHOMQUYEN();
            List<O_DAILY> nvo = new D_DAILY().NhanVien(txtUserName.Text, TMD5.TMd5Hash(txtPassword.Text));
            if (nvo.Count == 1)
            {
                if (!nvo[0].Nghi)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
                    if (key == null)
                        key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\THCRM");

                    if (chk.Checked)
                    {
                        key.SetValue("cmra", txtUserName.Text);
                        key.SetValue("cmrp", txtPassword.Text);
                    }
                    else
                    {
                        key.SetValue("cmra", string.Empty);
                        key.SetValue("cmrp", string.Empty);
                    }
                    key.Close();

                    ClsDuLieu.NhanVien = nvo[0];

                    ClsDuLieu.QuanLy = new D_QUANLYPHANMEM().DuLieu();
                    if (ClsDuLieu.QuanLy[0].Ten != ClsDuLieu.PhienBan.Split('-')[0] && !nvo[0].TenDangNhapCty.ToLower().Equals("itadmin"))
                    {
                        NotificationManager.Show(this, "Sai phiên bản, phiên bản hiện tại là " + ClsDuLieu.QuanLy[0].Ten, false, 3000);
                        return;
                    }
                    else
                    {
                        ClsDuLieu.Quyen = (nvo[0].TenDangNhapCty.ToLower().Equals("itadmin")) ? nqb.QuyenAdmin() : nqb.QuyenNhanVien(nvo[0].ChinhSach);
                        frmChinh f = new frmChinh();
                        ClsChucNang.SplashScreen(f);
                        TopMost = false;
                        Hide();
                        f.Show(this);
                    }
                }

                else
                    NotificationManager.Show(this, "Tài khoản đã bị khóa", false, 2000);
            }
            else
                NotificationManager.Show(this, "Sai tên đăng nhập hoặc mật khẩu", false, 2000);
        }

        public void CheckBanQuyen()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM", true);
            if (key != null && key.GetValue("MaKichHoat") != null)
            {
                string Key = TMD5.Base64Decode(TMD5.Base64Decode(TMD5.Base64Decode(key.GetValue("MaKichHoat").ToString())));
                string[] subs = Key.Split(new char[] { '@' });
                DateTime ngayBQ = new DateTime(int.Parse(subs[2].Substring(4)), int.Parse(subs[2].Substring(2, 2)), int.Parse(subs[2].Substring(0, 2)));
                DateTime ngaySV = DateTime.Now;

                if (subs.Length != 4 || subs[0] != "ThanhHoangCRM" || subs[1] != "TTTTUNG")
                {
                    XtraMessageBox.Show("Mã kích hoạt không hợp lệ");
                    new frmNhapMa().ShowDialog(this);
                }
                else if (ngaySV.Date.Subtract(ngayBQ.Date.AddYears(int.Parse(subs[3]))).Days > 0)
                {
                    XtraMessageBox.Show("Mã kích hoạt hết hạn sử dụng");
                    new frmNhapMa().ShowDialog(this);
                }
                else
                {
                    ClsChucNang.OpenForm(this);
                    if (key != null)
                    {
                        if (key.GetValue("cmra") != null && key.GetValue("cmrp") != null)
                            if (key.GetValue("cmra").ToString().Length > 0)
                            {
                                chk.Checked = true;
                                txtUserName.Text = key.GetValue("cmra").ToString();
                                txtPassword.Text = key.GetValue("cmrp").ToString();
                            }
                        if (key.GetValue("TKNC") != null)
                            key.SetValue("TKNC", "true");
                    }
                }
            }
            else
                new frmNhapMa().ShowDialog(this);
            if (key != null)
                key.Close();
        }
        #endregion

        #region Sự kiện nút
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            isLogin();
        }


        private void frmDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                isLogin();
        }
        #endregion

        #region Sự khiện khác 
        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}