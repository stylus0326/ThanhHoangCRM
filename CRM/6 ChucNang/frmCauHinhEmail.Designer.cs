namespace CRM
{
    partial class frmCauHinhEmail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinhEmail));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.iThem = new DevExpress.XtraEditors.CheckEdit();
            this.iTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.iMau = new DevExpress.XtraEditors.LookUpEdit();
            this.mauEmailOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtMauEmail = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnLuuMau = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.chkSSL = new DevExpress.XtraEditors.CheckEdit();
            this.nudPort = new DevExpress.XtraEditors.SpinEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iThem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mauEmailOBindingSource)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSSL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(965, 477);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage1});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(963, 452);
            this.xtraTabPage2.Text = "Mẫu Email";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.iThem);
            this.groupControl1.Controls.Add(this.iTen);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.iMau);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtMauEmail);
            this.groupControl1.Controls.Add(this.btnLuuMau);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(963, 452);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Gửi công nợ Đại lý";
            // 
            // iThem
            // 
            this.iThem.Location = new System.Drawing.Point(490, 23);
            this.iThem.Name = "iThem";
            this.iThem.Properties.Caption = "Thêm mới";
            this.iThem.Size = new System.Drawing.Size(75, 20);
            this.iThem.TabIndex = 15;
            // 
            // iTen
            // 
            this.iTen.Location = new System.Drawing.Point(314, 23);
            this.iTen.Name = "iTen";
            this.iTen.Size = new System.Drawing.Size(170, 20);
            this.iTen.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(263, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(45, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Tên mẫu:";
            // 
            // iMau
            // 
            this.iMau.Location = new System.Drawing.Point(63, 23);
            this.iMau.Name = "iMau";
            this.iMau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iMau.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenMau", "", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iMau.Properties.DataSource = this.mauEmailOBindingSource;
            this.iMau.Properties.DisplayMember = "TenMau";
            this.iMau.Properties.NullText = "[Chọn]";
            this.iMau.Properties.ValueMember = "ID";
            this.iMau.Size = new System.Drawing.Size(163, 20);
            this.iMau.TabIndex = 12;
            this.iMau.EditValueChanged += new System.EventHandler(this.iMau_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mẫu cho:";
            // 
            // txtMauEmail
            // 
            this.txtMauEmail.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtMauEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMauEmail.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMauEmail.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.txtMauEmail.Location = new System.Drawing.Point(6, 49);
            this.txtMauEmail.Name = "txtMauEmail";
            this.txtMauEmail.Options.DocumentCapabilities.CharacterFormatting = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.CharacterStyle = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.FloatingObjects = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.Hyperlinks = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.InlinePictures = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.ParagraphFormatting = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.Paragraphs = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.ParagraphStyle = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.ParagraphTabs = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.Tables = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentCapabilities.Undo = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.txtMauEmail.Options.DocumentSaveOptions.DefaultFormat = DevExpress.XtraRichEdit.DocumentFormat.Html;
            this.txtMauEmail.Options.Export.Html.EmbedImages = true;
            this.txtMauEmail.Options.HorizontalRuler.ShowLeftIndent = false;
            this.txtMauEmail.Options.HorizontalRuler.ShowRightIndent = false;
            this.txtMauEmail.Options.HorizontalRuler.ShowTabs = false;
            this.txtMauEmail.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txtMauEmail.Options.Import.FallbackFormat = DevExpress.XtraRichEdit.DocumentFormat.Html;
            this.txtMauEmail.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txtMauEmail.Size = new System.Drawing.Size(953, 394);
            this.txtMauEmail.TabIndex = 10;
            // 
            // btnLuuMau
            // 
            this.btnLuuMau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuMau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuuMau.Appearance.Options.UseFont = true;
            this.btnLuuMau.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuuMau.ImageOptions.SvgImage")));
            this.btnLuuMau.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuuMau.Location = new System.Drawing.Point(891, 21);
            this.btnLuuMau.Name = "btnLuuMau";
            this.btnLuuMau.Size = new System.Drawing.Size(66, 23);
            this.btnLuuMau.TabIndex = 9;
            this.btnLuuMau.Text = "Lưu";
            this.btnLuuMau.Click += new System.EventHandler(this.btnLuuMau_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnTest);
            this.xtraTabPage1.Controls.Add(this.btnLuu);
            this.xtraTabPage1.Controls.Add(this.chkSSL);
            this.xtraTabPage1.Controls.Add(this.nudPort);
            this.xtraTabPage1.Controls.Add(this.txtMatKhau);
            this.xtraTabPage1.Controls.Add(this.txtEmail);
            this.xtraTabPage1.Controls.Add(this.txtHost);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(963, 452);
            this.xtraTabPage1.Text = "Cấu hình Email";
            // 
            // btnTest
            // 
            this.btnTest.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTest.Appearance.Options.UseFont = true;
            this.btnTest.Location = new System.Drawing.Point(169, 144);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test Mail";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(88, 144);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // chkSSL
            // 
            this.chkSSL.Location = new System.Drawing.Point(86, 67);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Properties.Caption = "";
            this.chkSSL.Size = new System.Drawing.Size(75, 20);
            this.chkSSL.TabIndex = 3;
            // 
            // nudPort
            // 
            this.nudPort.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPort.Location = new System.Drawing.Point(88, 41);
            this.nudPort.Name = "nudPort";
            this.nudPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudPort.Size = new System.Drawing.Size(69, 20);
            this.nudPort.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(88, 118);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(227, 20);
            this.txtMatKhau.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(88, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(88, 15);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(227, 20);
            this.txtHost.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 121);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mật khẩu:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 70);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(21, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "SSL:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Email:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Port:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Host:";
            // 
            // frmCauHinhEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 477);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCauHinhEmail";
            this.Text = "Cấu Hình Email";
            this.Load += new System.EventHandler(this.frmCauHinhEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iThem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mauEmailOBindingSource)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSSL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.CheckEdit chkSSL;
        private DevExpress.XtraEditors.SpinEdit nudPort;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit iThem;
        private DevExpress.XtraEditors.TextEdit iTen;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit iMau;
        private System.Windows.Forms.BindingSource mauEmailOBindingSource;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraRichEdit.RichEditControl txtMauEmail;
        private DevExpress.XtraEditors.SimpleButton btnLuuMau;
    }
}