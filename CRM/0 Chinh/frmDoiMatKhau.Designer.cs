namespace CRM
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhauCu = new DevExpress.XtraEditors.TextEdit();
            this.txtMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.iMatKhauCty = new DevExpress.XtraEditors.TextEdit();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauCu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhauCty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mật khẩu cũ:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mật khẩu mới:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Nhập lại mật khẩu mới:";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(134, 12);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Properties.PasswordChar = '*';
            this.txtMatKhauCu.Size = new System.Drawing.Size(170, 20);
            this.txtMatKhauCu.TabIndex = 0;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(134, 38);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Properties.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(170, 20);
            this.txtMatKhauMoi.TabIndex = 1;
            // 
            // iMatKhauCty
            // 
            this.iMatKhauCty.Location = new System.Drawing.Point(134, 64);
            this.iMatKhauCty.Name = "iMatKhauCty";
            this.iMatKhauCty.Properties.PasswordChar = '*';
            this.iMatKhauCty.Size = new System.Drawing.Size(170, 20);
            this.iMatKhauCty.TabIndex = 2;
            // 
            // btnDongY
            // 
            this.btnDongY.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDongY.Appearance.Options.UseFont = true;
            this.btnDongY.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDongY.ImageOptions.SvgImage")));
            this.btnDongY.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnDongY.Location = new System.Drawing.Point(229, 90);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 3;
            this.btnDongY.Text = "Đồng Ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 123);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.iMatKhauCty);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauCu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhauCty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMatKhauCu;
        private DevExpress.XtraEditors.TextEdit txtMatKhauMoi;
        private DevExpress.XtraEditors.TextEdit iMatKhauCty;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}