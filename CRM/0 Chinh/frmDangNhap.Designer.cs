namespace CRM
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblver = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.chk = new DevExpress.XtraEditors.CheckEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPassword.Location = new System.Drawing.Point(69, 217);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(161, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUserName.Location = new System.Drawing.Point(69, 191);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(161, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl3.Location = new System.Drawing.Point(12, 220);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 22;
            this.labelControl3.Text = "Mật khẩu:";
            // 
            // lblver
            // 
            this.lblver.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblver.Location = new System.Drawing.Point(5, 308);
            this.lblver.Name = "lblver";
            this.lblver.Size = new System.Drawing.Size(57, 13);
            this.lblver.TabIndex = 18;
            this.lblver.Text = "Phiên bản : ";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogin.ImageOptions.SvgImage")));
            this.btnLogin.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLogin.Location = new System.Drawing.Point(144, 243);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 32);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chk
            // 
            this.chk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chk.Location = new System.Drawing.Point(69, 281);
            this.chk.Name = "chk";
            this.chk.Properties.Caption = "Nhớ tài khoản";
            this.chk.Size = new System.Drawing.Size(91, 20);
            this.chk.TabIndex = 0;
            this.chk.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnExit.Location = new System.Drawing.Point(69, 243);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 32);
            this.btnExit.TabIndex = 26;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chúc bạn có một ngày mới vui vẻ !!";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(4, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "\"Think again and make difference\"";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl2.Location = new System.Drawing.Point(45, 194);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 13);
            this.labelControl2.TabIndex = 39;
            this.labelControl2.Text = "ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CRM.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 126);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 324);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.lblver);
            this.Controls.Add(this.btnLogin);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmDangNhap";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý phòng vé";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDangNhap_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblver;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.CheckEdit chk;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}