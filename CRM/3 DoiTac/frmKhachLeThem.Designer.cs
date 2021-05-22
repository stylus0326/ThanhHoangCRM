namespace CRM
{
    partial class frmKhachLeThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachLeThem));
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.iActive2 = new DevExpress.XtraEditors.GroupControl();
            this.iGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.iActive1 = new DevExpress.XtraEditors.GroupControl();
            this.iNgayKiQuy = new DevExpress.XtraEditors.DateEdit();
            this.iNguoiDaiDienHD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.iPhi = new DevExpress.XtraEditors.SpinEdit();
            this.iDiaChiHD = new DevExpress.XtraEditors.TextEdit();
            this.iZalo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.iDiDong = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iActive2)).BeginInit();
            this.iActive2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iActive1)).BeginInit();
            this.iActive1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayKiQuy.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayKiQuy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNguoiDaiDienHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPhi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiaChiHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iZalo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiDong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnLuu.Location = new System.Drawing.Point(370, 219);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(54, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.TabStop = false;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // iActive2
            // 
            this.iActive2.Controls.Add(this.iGhiChu);
            this.iActive2.Location = new System.Drawing.Point(233, 5);
            this.iActive2.Name = "iActive2";
            this.iActive2.Size = new System.Drawing.Size(191, 210);
            this.iActive2.TabIndex = 1;
            this.iActive2.Text = "Ghi chú";
            // 
            // iGhiChu
            // 
            this.iGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iGhiChu.Location = new System.Drawing.Point(2, 23);
            this.iGhiChu.Name = "iGhiChu";
            this.iGhiChu.Size = new System.Drawing.Size(187, 185);
            this.iGhiChu.TabIndex = 3;
            // 
            // iActive1
            // 
            this.iActive1.Controls.Add(this.iNgayKiQuy);
            this.iActive1.Controls.Add(this.iNguoiDaiDienHD);
            this.iActive1.Controls.Add(this.labelControl1);
            this.iActive1.Controls.Add(this.labelControl10);
            this.iActive1.Controls.Add(this.labelControl9);
            this.iActive1.Controls.Add(this.iPhi);
            this.iActive1.Controls.Add(this.iDiaChiHD);
            this.iActive1.Controls.Add(this.iZalo);
            this.iActive1.Controls.Add(this.labelControl3);
            this.iActive1.Controls.Add(this.labelControl7);
            this.iActive1.Controls.Add(this.iDiDong);
            this.iActive1.Controls.Add(this.labelControl5);
            this.iActive1.Controls.Add(this.iTen);
            this.iActive1.Controls.Add(this.labelControl4);
            this.iActive1.Controls.Add(this.labelControl2);
            this.iActive1.Location = new System.Drawing.Point(5, 5);
            this.iActive1.Name = "iActive1";
            this.iActive1.Size = new System.Drawing.Size(222, 206);
            this.iActive1.TabIndex = 0;
            this.iActive1.Text = "Thông tin";
            // 
            // iNgayKiQuy
            // 
            this.iNgayKiQuy.EditValue = null;
            this.iNgayKiQuy.Location = new System.Drawing.Point(71, 179);
            this.iNgayKiQuy.Name = "iNgayKiQuy";
            this.iNgayKiQuy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNgayKiQuy.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNgayKiQuy.Properties.DisplayFormat.FormatString = "dd-MM-yy";
            this.iNgayKiQuy.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.iNgayKiQuy.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.iNgayKiQuy.Size = new System.Drawing.Size(142, 20);
            this.iNgayKiQuy.TabIndex = 6;
            // 
            // iNguoiDaiDienHD
            // 
            this.iNguoiDaiDienHD.Location = new System.Drawing.Point(71, 75);
            this.iNguoiDaiDienHD.Name = "iNguoiDaiDienHD";
            this.iNguoiDaiDienHD.Size = new System.Drawing.Size(142, 20);
            this.iNguoiDaiDienHD.TabIndex = 2;
            this.iNguoiDaiDienHD.Tag = "Tên đại diện";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 79;
            this.labelControl1.Text = "Tên đầy đủ:";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(177, 26);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(36, 13);
            this.labelControl10.TabIndex = 77;
            this.labelControl10.Text = "VND/Vé";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(47, 26);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(18, 13);
            this.labelControl9.TabIndex = 76;
            this.labelControl9.Text = "Phí:";
            // 
            // iPhi
            // 
            this.iPhi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iPhi.Location = new System.Drawing.Point(71, 23);
            this.iPhi.Name = "iPhi";
            this.iPhi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iPhi.Properties.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iPhi.Size = new System.Drawing.Size(100, 20);
            this.iPhi.TabIndex = 0;
            this.iPhi.Tag = "Phí";
            // 
            // iDiaChiHD
            // 
            this.iDiaChiHD.Location = new System.Drawing.Point(71, 153);
            this.iDiaChiHD.Name = "iDiaChiHD";
            this.iDiaChiHD.Size = new System.Drawing.Size(142, 20);
            this.iDiaChiHD.TabIndex = 5;
            this.iDiaChiHD.Tag = "Địa chỉ";
            // 
            // iZalo
            // 
            this.iZalo.Location = new System.Drawing.Point(71, 127);
            this.iZalo.Name = "iZalo";
            this.iZalo.Size = new System.Drawing.Size(142, 20);
            this.iZalo.TabIndex = 4;
            this.iZalo.Tag = "Zalo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 182);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Ngày tạo:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(29, 156);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Địa chỉ:";
            // 
            // iDiDong
            // 
            this.iDiDong.Location = new System.Drawing.Point(71, 101);
            this.iDiDong.Name = "iDiDong";
            this.iDiDong.Size = new System.Drawing.Size(142, 20);
            this.iDiDong.TabIndex = 3;
            this.iDiDong.Tag = "SĐT";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(41, 130);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Zalo:";
            // 
            // iTen
            // 
            this.iTen.Location = new System.Drawing.Point(71, 49);
            this.iTen.Name = "iTen";
            this.iTen.Size = new System.Drawing.Size(142, 20);
            this.iTen.TabIndex = 1;
            this.iTen.Tag = "Tên đại diện";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(41, 104);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "SĐT:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên đại diện:";
            // 
            // frmKhachLeThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 246);
            this.Controls.Add(this.iActive1);
            this.Controls.Add(this.iActive2);
            this.Controls.Add(this.btnLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKhachLeThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách lẻ";
            this.Load += new System.EventHandler(this.frmKhachLeThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKhachLeThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iActive2)).EndInit();
            this.iActive2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iActive1)).EndInit();
            this.iActive1.ResumeLayout(false);
            this.iActive1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayKiQuy.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayKiQuy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNguoiDaiDienHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPhi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiaChiHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iZalo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiDong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.GroupControl iActive2;
        private DevExpress.XtraEditors.MemoEdit iGhiChu;
        private DevExpress.XtraEditors.GroupControl iActive1;
        private DevExpress.XtraEditors.DateEdit iNgayKiQuy;
        private DevExpress.XtraEditors.TextEdit iNguoiDaiDienHD;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit iPhi;
        private DevExpress.XtraEditors.TextEdit iDiaChiHD;
        private DevExpress.XtraEditors.TextEdit iZalo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit iDiDong;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iTen;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}