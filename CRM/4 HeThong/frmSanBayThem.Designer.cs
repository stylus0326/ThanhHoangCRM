namespace CRM
{
    partial class frmSanBayThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanBayThem));
            this.btnLuu2 = new DevExpress.XtraEditors.SimpleButton();
            this.iTenDayDu = new DevExpress.XtraEditors.TextEdit();
            this.iKyHieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iNoiDia = new DevExpress.XtraEditors.CheckEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iTenDayDu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKyHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNoiDia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu2
            // 
            this.btnLuu2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu2.Appearance.Options.UseFont = true;
            this.btnLuu2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu2.ImageOptions.SvgImage")));
            this.btnLuu2.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu2.Location = new System.Drawing.Point(170, 64);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(61, 22);
            this.btnLuu2.TabIndex = 2;
            this.btnLuu2.TabStop = false;
            this.btnLuu2.Text = "Lưu";
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // iTenDayDu
            // 
            this.iTenDayDu.Location = new System.Drawing.Point(81, 38);
            this.iTenDayDu.Name = "iTenDayDu";
            this.iTenDayDu.Size = new System.Drawing.Size(150, 20);
            this.iTenDayDu.TabIndex = 1;
            this.iTenDayDu.Tag = "Tên đầy đủ";
            // 
            // iKyHieu
            // 
            this.iKyHieu.Location = new System.Drawing.Point(81, 12);
            this.iKyHieu.Name = "iKyHieu";
            this.iKyHieu.Size = new System.Drawing.Size(150, 20);
            this.iKyHieu.TabIndex = 0;
            this.iKyHieu.Tag = "Ký hiệu";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "Tên đầy đủ:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 27;
            this.labelControl4.Text = "Ký hiệu:";
            // 
            // iNoiDia
            // 
            this.iNoiDia.Location = new System.Drawing.Point(9, 65);
            this.iNoiDia.Name = "iNoiDia";
            this.iNoiDia.Properties.Caption = "Nội địa";
            this.iNoiDia.Size = new System.Drawing.Size(75, 20);
            this.iNoiDia.TabIndex = 28;
            // 
            // frmSanBayThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 93);
            this.Controls.Add(this.iNoiDia);
            this.Controls.Add(this.btnLuu2);
            this.Controls.Add(this.iTenDayDu);
            this.Controls.Add(this.iKyHieu);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSanBayThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sân bay";
            this.Load += new System.EventHandler(this.frmSanBayThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSanBayThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iTenDayDu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKyHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNoiDia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLuu2;
        private DevExpress.XtraEditors.TextEdit iTenDayDu;
        private DevExpress.XtraEditors.TextEdit iKyHieu;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit iNoiDia;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}