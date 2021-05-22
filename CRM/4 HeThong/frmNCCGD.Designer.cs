namespace CRM
{
    partial class frmNCCGD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNCCGD));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iNCC = new DevExpress.XtraEditors.LookUpEdit();
            this.nCCOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iSoTien = new DevExpress.XtraEditors.SpinEdit();
            this.iLoaiGiaoDich = new DevExpress.XtraEditors.LookUpEdit();
            this.intStringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iNgayGD = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiGiaoDich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intStringBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nhà cung cấp:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Loại giao dịch:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(50, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Số tiền:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(48, 118);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Ghi chú:";
            // 
            // iNCC
            // 
            this.iNCC.Location = new System.Drawing.Point(93, 38);
            this.iNCC.Name = "iNCC";
            this.iNCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNCC.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDayDu", "", 66, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iNCC.Properties.DataSource = this.nCCOBindingSource;
            this.iNCC.Properties.DisplayMember = "TenDayDu";
            this.iNCC.Properties.ValueMember = "ID";
            this.iNCC.Size = new System.Drawing.Size(130, 20);
            this.iNCC.TabIndex = 1;
            // 
            // nCCOBindingSource
            // 
            this.nCCOBindingSource.DataSource = typeof(DataTransferObject.NCCO);
            // 
            // iSoTien
            // 
            this.iSoTien.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iSoTien.Location = new System.Drawing.Point(93, 90);
            this.iSoTien.Name = "iSoTien";
            this.iSoTien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iSoTien.Size = new System.Drawing.Size(100, 20);
            this.iSoTien.TabIndex = 2;
            // 
            // iLoaiGiaoDich
            // 
            this.iLoaiGiaoDich.Location = new System.Drawing.Point(93, 64);
            this.iLoaiGiaoDich.Name = "iLoaiGiaoDich";
            this.iLoaiGiaoDich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iLoaiGiaoDich.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iLoaiGiaoDich.Properties.DataSource = this.intStringBindingSource;
            this.iLoaiGiaoDich.Properties.DisplayMember = "Name";
            this.iLoaiGiaoDich.Properties.ValueMember = "ID";
            this.iLoaiGiaoDich.Size = new System.Drawing.Size(100, 20);
            this.iLoaiGiaoDich.TabIndex = 1;
            // 
            // intStringBindingSource
            // 
            this.intStringBindingSource.DataSource = typeof(CRM.IntString);
            // 
            // iGhiChu
            // 
            this.iGhiChu.Location = new System.Drawing.Point(93, 116);
            this.iGhiChu.Name = "iGhiChu";
            this.iGhiChu.Size = new System.Drawing.Size(130, 96);
            this.iGhiChu.TabIndex = 3;
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnLuu.Location = new System.Drawing.Point(148, 218);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(41, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Ngày GD:";
            // 
            // iNgayGD
            // 
            this.iNgayGD.EditValue = null;
            this.iNgayGD.Location = new System.Drawing.Point(93, 12);
            this.iNgayGD.Name = "iNgayGD";
            this.iNgayGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNgayGD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNgayGD.Size = new System.Drawing.Size(100, 20);
            this.iNgayGD.TabIndex = 35;
            this.iNgayGD.Tag = "Ngày GD";
            // 
            // frmNCCGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 249);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iNgayGD);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.iGhiChu);
            this.Controls.Add(this.iSoTien);
            this.Controls.Add(this.iLoaiGiaoDich);
            this.Controls.Add(this.iNCC);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNCCGD";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao dịch phát sinh";
            this.Load += new System.EventHandler(this.frmNCCGD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiGiaoDich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intStringBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit iNCC;
        private System.Windows.Forms.BindingSource nCCOBindingSource;
        private DevExpress.XtraEditors.SpinEdit iSoTien;
        private DevExpress.XtraEditors.LookUpEdit iLoaiGiaoDich;
        private System.Windows.Forms.BindingSource intStringBindingSource;
        private DevExpress.XtraEditors.MemoEdit iGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit iNgayGD;
    }
}