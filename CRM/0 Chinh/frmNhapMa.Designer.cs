namespace CRM
{
    partial class frmNhapMa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapMa));
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnActive = new DevExpress.XtraEditors.SimpleButton();
            this.lblMess = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.EditValue = "";
            this.txtKey.Location = new System.Drawing.Point(6, 20);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Properties.Appearance.Options.UseFont = true;
            this.txtKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKey.Size = new System.Drawing.Size(591, 20);
            this.txtKey.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phần nhập mã kích hoạt";
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnExit.Location = new System.Drawing.Point(318, 183);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnActive
            // 
            this.btnActive.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnActive.ImageOptions.SvgImage")));
            this.btnActive.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnActive.Location = new System.Drawing.Point(237, 183);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(75, 23);
            this.btnActive.TabIndex = 1;
            this.btnActive.Text = "Kích hoạt";
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // lblMess
            // 
            this.lblMess.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMess.Appearance.Options.UseFont = true;
            this.lblMess.Location = new System.Drawing.Point(18, 104);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(0, 13);
            this.lblMess.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CRM.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(219, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 90);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // frmNhapMa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 215);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMess);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNhapMa";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNhapMa";
            this.Load += new System.EventHandler(this.frmNhapMa_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNhapMa_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnActive;
        private DevExpress.XtraEditors.LabelControl lblMess;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}