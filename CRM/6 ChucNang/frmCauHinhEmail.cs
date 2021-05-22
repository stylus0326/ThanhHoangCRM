using DataAccessLayer;
using DataTransferObject;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CRM
{
    public partial class frmCauHinhEmail : DevExpress.XtraEditors.XtraForm
    {
        MauEmailD mauEmailD = new MauEmailD();
        CauHinhSMTPD cauHinhSMTPD = new CauHinhSMTPD();
        public frmCauHinhEmail()
        {
            InitializeComponent();
        }

        private void frmCauHinhEmail_Load(object sender, EventArgs e)
        {
            if (!XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.ShowWaitForm();
            mauEmailOBindingSource.DataSource = mauEmailD.DuLieu();
            CauHinhSMTPO cauHinhSMTPO = cauHinhSMTPD.DuLieu();
            if (cauHinhSMTPO.Port > 0)
            {
                txtHost.Text = cauHinhSMTPO.Host;
                nudPort.Value = cauHinhSMTPO.Port;
                chkSSL.Checked = cauHinhSMTPO.SSL;
                txtEmail.Text = cauHinhSMTPO.Email;
                txtMatKhau.Text = cauHinhSMTPO.Password;
            }
            if (XuLyGiaoDien.wait.IsSplashFormVisible)
                XuLyGiaoDien.wait.CloseWaitForm();
        }

        #region Sự kiện nút
        private void btnLuuMau_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("NoiDung", txtMauEmail.HtmlText);
            dic.Add("TenMau", iTen.Text);
            long Suc = (iThem.Checked) ? mauEmailD.ThemMoi(dic, false) : mauEmailD.CapNhat(dic, iMau.EditValue);
            if (XuLyGiaoDien.ThongBao("Mẫu Email" + (!iThem.Checked ? " sửa" : " thêm"), Suc > 0))
                mauEmailOBindingSource.DataSource = mauEmailD.DuLieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Host", txtHost.Text);
            dic.Add("Port", nudPort.Value);
            dic.Add("SSL", chkSSL.Checked);
            dic.Add("Email", txtEmail.Text);
            dic.Add("Password", txtMatKhau.Text);
            long Suc = cauHinhSMTPD.CapNhat(dic, nudPort.Value, " WHERE Port <> 0");
            XuLyGiaoDien.ThongBao("Cấu hình Email sửa", Suc > 0);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            client.Host = txtHost.Text;
            client.Port = (int)nudPort.Value;
            client.EnableSsl = chkSSL.Checked;
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(txtEmail.Text, txtMatKhau.Text);

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(txtEmail.Text, "Thành Hoàng");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.IsBodyHtml = true;
            RichEditMailMessageExporter exporter = new RichEditMailMessageExporter(txtMauEmail, mm);
            exporter.Export();
            mm.To.Add(new MailAddress("stylus0326@gmail.com"));
            client.Send(mm);
            XtraMessageBox.Show("Send OK");
        }

        private void iMau_EditValueChanged(object sender, EventArgs e)
        {
            MauEmailO mau = iMau.GetSelectedDataRow() as MauEmailO;
            txtMauEmail.HtmlText = mau.NoiDung;
            iTen.Text = mau.TenMau;
        }
        #endregion
    }
}