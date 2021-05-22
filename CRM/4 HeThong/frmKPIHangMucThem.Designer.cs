namespace CRM
{
    partial class frmKPIHangMucThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPIHangMucThem));
            this.btnLuu2 = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.iDiem = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iMuc = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iVietTat = new DevExpress.XtraEditors.TextEdit();
            this.iNhom = new DevExpress.XtraEditors.TextEdit();
            this.txtMauEmail = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iVietTat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMauEmail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu2
            // 
            this.btnLuu2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu2.Appearance.Options.UseFont = true;
            this.btnLuu2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu2.ImageOptions.SvgImage")));
            this.btnLuu2.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu2.Location = new System.Drawing.Point(734, 448);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(61, 22);
            this.btnLuu2.TabIndex = 2;
            this.btnLuu2.TabStop = false;
            this.btnLuu2.Text = "Lưu";
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // iDiem
            // 
            this.iDiem.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iDiem.Location = new System.Drawing.Point(755, 12);
            this.iDiem.Name = "iDiem";
            this.iDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iDiem.Size = new System.Drawing.Size(40, 20);
            this.iDiem.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(721, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Điểm:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(32, 114);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Nội dung:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Nhóm:";
            // 
            // iMuc
            // 
            this.iMuc.EditValue = "";
            this.iMuc.Location = new System.Drawing.Point(84, 38);
            this.iMuc.Name = "iMuc";
            this.iMuc.Size = new System.Drawing.Size(711, 47);
            this.iMuc.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Tên khoản:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(390, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Kí Hiệu:";
            // 
            // iVietTat
            // 
            this.iVietTat.Location = new System.Drawing.Point(432, 12);
            this.iVietTat.Name = "iVietTat";
            this.iVietTat.Size = new System.Drawing.Size(283, 20);
            this.iVietTat.TabIndex = 15;
            // 
            // iNhom
            // 
            this.iNhom.Location = new System.Drawing.Point(84, 12);
            this.iNhom.Name = "iNhom";
            this.iNhom.Size = new System.Drawing.Size(300, 20);
            this.iNhom.TabIndex = 18;
            // 
            // txtMauEmail
            // 
            this.txtMauEmail.Location = new System.Drawing.Point(85, 91);
            this.txtMauEmail.Name = "txtMauEmail";
            this.txtMauEmail.Properties.AcceptsTab = true;
            this.txtMauEmail.Size = new System.Drawing.Size(710, 351);
            this.txtMauEmail.TabIndex = 19;
            // 
            // frmKPIHangMucThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 478);
            this.Controls.Add(this.txtMauEmail);
            this.Controls.Add(this.iNhom);
            this.Controls.Add(this.iVietTat);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iMuc);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iDiem);
            this.Controls.Add(this.btnLuu2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKPIHangMucThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điểm KPI";
            this.Load += new System.EventHandler(this.frmKPIHangMucThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKPIHangMucThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iVietTat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMauEmail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnLuu2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SpinEdit iDiem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit iMuc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iVietTat;
        private DevExpress.XtraEditors.TextEdit iNhom;
        private DevExpress.XtraEditors.MemoEdit txtMauEmail;
    }
}