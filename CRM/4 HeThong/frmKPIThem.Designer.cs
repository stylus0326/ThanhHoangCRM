namespace CRM
{
    partial class frmKPIThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPIThem));
            this.btnLuu2 = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.iThoiGian = new DevExpress.XtraEditors.DateEdit();
            this.iDiem = new DevExpress.XtraEditors.SpinEdit();
            this.iNoiDung = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.kPIHangMucOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iGhiChu = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iThoiGian.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iThoiGian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kPIHangMucOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu2
            // 
            this.btnLuu2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu2.Appearance.Options.UseFont = true;
            this.btnLuu2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu2.ImageOptions.SvgImage")));
            this.btnLuu2.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu2.Location = new System.Drawing.Point(213, 256);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(61, 22);
            this.btnLuu2.TabIndex = 2;
            this.btnLuu2.TabStop = false;
            this.btnLuu2.Text = "Lưu";
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // iThoiGian
            // 
            this.iThoiGian.EditValue = null;
            this.iThoiGian.Location = new System.Drawing.Point(70, 38);
            this.iThoiGian.Name = "iThoiGian";
            this.iThoiGian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iThoiGian.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iThoiGian.Size = new System.Drawing.Size(100, 20);
            this.iThoiGian.TabIndex = 3;
            // 
            // iDiem
            // 
            this.iDiem.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iDiem.Location = new System.Drawing.Point(221, 38);
            this.iDiem.Name = "iDiem";
            this.iDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iDiem.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.iDiem.Properties.MinValue = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.iDiem.Size = new System.Drawing.Size(56, 20);
            this.iDiem.TabIndex = 4;
            this.iDiem.EditValueChanged += new System.EventHandler(this.iDiem_EditValueChanged);
            // 
            // iNoiDung
            // 
            this.iNoiDung.Location = new System.Drawing.Point(70, 64);
            this.iNoiDung.Name = "iNoiDung";
            this.iNoiDung.Size = new System.Drawing.Size(207, 90);
            this.iNoiDung.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Ngày:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(187, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Điểm:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Nội dung:";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(70, 12);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietTat", "", 47, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Muc", "", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Diem", "", 15, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit1.Properties.DataSource = this.kPIHangMucOBindingSource;
            this.lookUpEdit1.Properties.DisplayMember = "Muc";
            this.lookUpEdit1.Properties.NullText = "[Chọn....]";
            this.lookUpEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(600, 400);
            this.lookUpEdit1.Properties.ValueMember = "ID";
            this.lookUpEdit1.Size = new System.Drawing.Size(207, 20);
            this.lookUpEdit1.TabIndex = 9;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // kPIHangMucOBindingSource
            // 
            this.kPIHangMucOBindingSource.DataSource = typeof(DataTransferObject.O_KPIHANGMUC);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Chọn mục:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 162);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Ghi chú:";
            // 
            // iGhiChu
            // 
            this.iGhiChu.Location = new System.Drawing.Point(70, 160);
            this.iGhiChu.Name = "iGhiChu";
            this.iGhiChu.Size = new System.Drawing.Size(207, 90);
            this.iGhiChu.TabIndex = 11;
            // 
            // frmKPIThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 290);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iGhiChu);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iNoiDung);
            this.Controls.Add(this.iDiem);
            this.Controls.Add(this.iThoiGian);
            this.Controls.Add(this.btnLuu2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKPIThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điểm KPI";
            this.Load += new System.EventHandler(this.frmKPIThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKPIThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iThoiGian.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iThoiGian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kPIHangMucOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnLuu2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.DateEdit iThoiGian;
        private DevExpress.XtraEditors.SpinEdit iDiem;
        private DevExpress.XtraEditors.MemoEdit iNoiDung;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.BindingSource kPIHangMucOBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit iGhiChu;
    }
}