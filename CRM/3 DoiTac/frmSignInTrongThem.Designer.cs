namespace CRM
{
    partial class frmSignInTrongThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignInTrongThem));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iChinh = new DevExpress.XtraEditors.CheckEdit();
            this.iSignIn = new DevExpress.XtraEditors.TextEdit();
            this.iHangBay = new DevExpress.XtraEditors.LookUpEdit();
            this.hangBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.btnTT = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iChinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSignIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHangBay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "SignIn:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Hãng Bay:";
            // 
            // iChinh
            // 
            this.iChinh.EditValue = true;
            this.iChinh.Location = new System.Drawing.Point(93, 120);
            this.iChinh.Name = "iChinh";
            this.iChinh.Properties.Caption = "Thanh Toán";
            this.iChinh.Size = new System.Drawing.Size(91, 20);
            this.iChinh.TabIndex = 3;
            this.iChinh.Tag = "Chinh";
            // 
            // iSignIn
            // 
            this.iSignIn.Location = new System.Drawing.Point(84, 12);
            this.iSignIn.Name = "iSignIn";
            this.iSignIn.Size = new System.Drawing.Size(166, 20);
            this.iSignIn.TabIndex = 1;
            this.iSignIn.Tag = "SignIn";
            // 
            // iHangBay
            // 
            this.iHangBay.Location = new System.Drawing.Point(84, 93);
            this.iHangBay.Name = "iHangBay";
            this.iHangBay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iHangBay.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHang", "Hãng Bay", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTat", "Ten Tat", 47, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iHangBay.Properties.DataSource = this.hangBayOBindingSource;
            this.iHangBay.Properties.DisplayMember = "TenHang";
            this.iHangBay.Properties.NullText = "[Chọn hãng ...";
            this.iHangBay.Properties.ValueMember = "ID";
            this.iHangBay.Size = new System.Drawing.Size(166, 20);
            this.iHangBay.TabIndex = 2;
            this.iHangBay.Tag = "Hãng";
            // 
            // hangBayOBindingSource
            // 
            this.hangBayOBindingSource.DataSource = typeof(DataTransferObject.O_HANGBAY);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu.Location = new System.Drawing.Point(200, 119);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(53, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.TabStop = false;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mật khẩu tạm:";
            // 
            // iMatKhau
            // 
            this.iMatKhau.Location = new System.Drawing.Point(84, 67);
            this.iMatKhau.Name = "iMatKhau";
            this.iMatKhau.Size = new System.Drawing.Size(166, 20);
            this.iMatKhau.TabIndex = 1;
            this.iMatKhau.Tag = "SignIn";
            // 
            // btnTT
            // 
            this.btnTT.Location = new System.Drawing.Point(159, 38);
            this.btnTT.Name = "btnTT";
            this.btnTT.Size = new System.Drawing.Size(40, 23);
            this.btnTT.TabIndex = 5;
            this.btnTT.Text = "tạo";
            this.btnTT.Click += new System.EventHandler(this.btnTT_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(84, 38);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(69, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Mở Chrome";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(12, 120);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Tạo liên tục";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 7;
            // 
            // frmSignInTrongThem
            // 
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 152);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnTT);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.iHangBay);
            this.Controls.Add(this.iMatKhau);
            this.Controls.Add(this.iSignIn);
            this.Controls.Add(this.iChinh);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignInTrongThem";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignIn";
            this.Load += new System.EventHandler(this.frmThemSignIn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSignInTrongThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iChinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSignIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHangBay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit iChinh;
        private DevExpress.XtraEditors.TextEdit iSignIn;
        private DevExpress.XtraEditors.LookUpEdit iHangBay;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.BindingSource hangBayOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iMatKhau;
        private DevExpress.XtraEditors.SimpleButton btnTT;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}