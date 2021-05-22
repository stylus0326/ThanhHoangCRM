namespace CRM
{
    partial class frmChinhSachThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChinhSachThem));
            this.iTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iPhatQuyAm = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.iAnhCS = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iLoaiKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.iAn = new DevExpress.XtraEditors.CheckEdit();
            this.intStringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPhatQuyAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnhCS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intStringBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // iTen
            // 
            this.iTen.Location = new System.Drawing.Point(89, 12);
            this.iTen.Name = "iTen";
            this.iTen.Size = new System.Drawing.Size(208, 20);
            this.iTen.TabIndex = 0;
            this.iTen.Tag = "Tên chính sách:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(238, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "x Số dư cuối";
            // 
            // iGhiChu
            // 
            this.iGhiChu.Location = new System.Drawing.Point(89, 90);
            this.iGhiChu.Name = "iGhiChu";
            this.iGhiChu.Size = new System.Drawing.Size(208, 215);
            this.iGhiChu.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(44, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Ghi chú:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(40, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Phạt âm:";
            // 
            // iPhatQuyAm
            // 
            this.iPhatQuyAm.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iPhatQuyAm.Location = new System.Drawing.Point(89, 38);
            this.iPhatQuyAm.Name = "iPhatQuyAm";
            this.iPhatQuyAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iPhatQuyAm.Size = new System.Drawing.Size(143, 20);
            this.iPhatQuyAm.TabIndex = 1;
            this.iPhatQuyAm.Tag = "Phạt âm";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Tên chính sách:";
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu.Location = new System.Drawing.Point(446, 311);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(57, 23);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // iAnhCS
            // 
            this.iAnhCS.Location = new System.Drawing.Point(303, 41);
            this.iAnhCS.Name = "iAnhCS";
            this.iAnhCS.Properties.NullText = "Nhấn để chọn";
            this.iAnhCS.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.iAnhCS.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.iAnhCS.Size = new System.Drawing.Size(200, 264);
            this.iAnhCS.TabIndex = 4;
            this.iAnhCS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.iAnhCty_MouseClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(303, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 85;
            this.labelControl1.Text = "Ảnh chi tiết:";
            // 
            // iLoaiKhachHang
            // 
            this.iLoaiKhachHang.Location = new System.Drawing.Point(89, 64);
            this.iLoaiKhachHang.Name = "iLoaiKhachHang";
            this.iLoaiKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iLoaiKhachHang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iLoaiKhachHang.Properties.DataSource = this.intStringBindingSource;
            this.iLoaiKhachHang.Properties.DisplayMember = "Name";
            this.iLoaiKhachHang.Properties.DropDownRows = 4;
            this.iLoaiKhachHang.Properties.NullText = "[Chọn...]";
            this.iLoaiKhachHang.Properties.PopupSizeable = false;
            this.iLoaiKhachHang.Properties.ValueMember = "ID";
            this.iLoaiKhachHang.Size = new System.Drawing.Size(143, 20);
            this.iLoaiKhachHang.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(29, 67);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(54, 13);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "Loại khách:";
            // 
            // iAn
            // 
            this.iAn.Location = new System.Drawing.Point(89, 309);
            this.iAn.Name = "iAn";
            this.iAn.Properties.Caption = "Ẩn";
            this.iAn.Size = new System.Drawing.Size(75, 20);
            this.iAn.TabIndex = 88;
            // 
            // intStringBindingSource
            // 
            this.intStringBindingSource.DataSource = typeof(CRM.IntString);
            // 
            // frmChinhSachThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 341);
            this.Controls.Add(this.iAn);
            this.Controls.Add(this.iLoaiKhachHang);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iAnhCS);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.iTen);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iGhiChu);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iPhatQuyAm);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmChinhSachThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chính sách";
            this.Load += new System.EventHandler(this.frmChinhSachThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChinhSachThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPhatQuyAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnhCS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intStringBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit iTen;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit iGhiChu;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit iPhatQuyAm;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.PictureEdit iAnhCS;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit iLoaiKhachHang;
        private System.Windows.Forms.BindingSource intStringBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit iAn;
    }
}