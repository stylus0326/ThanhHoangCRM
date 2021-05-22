namespace CRM
{
    partial class frmTongHopThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTongHopThem));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iIDKhachHang = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.daiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iMaCho = new DevExpress.XtraEditors.TextEdit();
            this.iGiaThu = new DevExpress.XtraEditors.SpinEdit();
            this.btn = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.iTenKhach = new DevExpress.XtraEditors.MemoEdit();
            this.iNgayGD = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iLoaiKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.iLoaiGiaoDich = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.loaiGiaoDichOBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.loaiKhachOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iIDKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMaCho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGiaThu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTenKhach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiGiaoDich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiGiaoDichOBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiKhachOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mã chỗ:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 169);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Nội dung:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(58, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Giá:";
            // 
            // iIDKhachHang
            // 
            this.iIDKhachHang.EditValue = "[Chọn khách hàng...]";
            this.iIDKhachHang.Location = new System.Drawing.Point(83, 64);
            this.iIDKhachHang.Name = "iIDKhachHang";
            this.iIDKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIDKhachHang.Properties.DataSource = this.daiLyOBindingSource;
            this.iIDKhachHang.Properties.DisplayMember = "Ten";
            this.iIDKhachHang.Properties.NullText = "[Chọn khách hàng...";
            this.iIDKhachHang.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.iIDKhachHang.Properties.PopupView = this.searchLookUpEdit1View;
            this.iIDKhachHang.Properties.ValueMember = "ID";
            this.iIDKhachHang.Size = new System.Drawing.Size(158, 20);
            this.iIDKhachHang.TabIndex = 2;
            this.iIDKhachHang.Tag = "Khách";
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.O_DAILY);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTen});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.TextAndVisual;
            this.searchLookUpEdit1View.OptionsFind.FindFilterColumns = "Ten";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTen
            // 
            this.colTen.FieldName = "Ten";
            this.colTen.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTen.Name = "colTen";
            this.colTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 0;
            // 
            // iMaCho
            // 
            this.iMaCho.Location = new System.Drawing.Point(83, 90);
            this.iMaCho.Name = "iMaCho";
            this.iMaCho.Size = new System.Drawing.Size(158, 20);
            this.iMaCho.TabIndex = 3;
            this.iMaCho.Tag = "Mã chỗ";
            // 
            // iGiaThu
            // 
            this.iGiaThu.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iGiaThu.Location = new System.Drawing.Point(83, 116);
            this.iGiaThu.Name = "iGiaThu";
            this.iGiaThu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iGiaThu.Properties.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iGiaThu.Size = new System.Drawing.Size(124, 20);
            this.iGiaThu.TabIndex = 4;
            this.iGiaThu.Tag = "Thu";
            // 
            // btn
            // 
            this.btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn.ImageOptions.Image")));
            this.btn.Location = new System.Drawing.Point(186, 270);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(56, 23);
            this.btn.TabIndex = 7;
            this.btn.Text = "Lưu";
            this.btn.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "VNĐ";
            // 
            // iTenKhach
            // 
            this.iTenKhach.Location = new System.Drawing.Point(83, 168);
            this.iTenKhach.Name = "iTenKhach";
            this.iTenKhach.Size = new System.Drawing.Size(159, 96);
            this.iTenKhach.TabIndex = 6;
            // 
            // iNgayGD
            // 
            this.iNgayGD.EditValue = null;
            this.iNgayGD.Location = new System.Drawing.Point(83, 12);
            this.iNgayGD.Name = "iNgayGD";
            this.iNgayGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNgayGD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iNgayGD.Size = new System.Drawing.Size(100, 20);
            this.iNgayGD.TabIndex = 0;
            this.iNgayGD.Tag = "Ngày GD";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Ngày GD:";
            // 
            // iLoaiKhachHang
            // 
            this.iLoaiKhachHang.Location = new System.Drawing.Point(83, 38);
            this.iLoaiKhachHang.Name = "iLoaiKhachHang";
            this.iLoaiKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iLoaiKhachHang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iLoaiKhachHang.Properties.DataSource = this.loaiKhachOBindingSource;
            this.iLoaiKhachHang.Properties.DisplayMember = "Name";
            this.iLoaiKhachHang.Properties.NullText = "";
            this.iLoaiKhachHang.Properties.ValueMember = "ID";
            this.iLoaiKhachHang.Size = new System.Drawing.Size(144, 20);
            this.iLoaiKhachHang.TabIndex = 1;
            this.iLoaiKhachHang.EditValueChanged += new System.EventHandler(this.iLoaiKhachHang_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(44, 67);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 13);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Khách:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(23, 41);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(54, 13);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Loại khách:";
            // 
            // iLoaiGiaoDich
            // 
            this.iLoaiGiaoDich.Location = new System.Drawing.Point(83, 142);
            this.iLoaiGiaoDich.Name = "iLoaiGiaoDich";
            this.iLoaiGiaoDich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iLoaiGiaoDich.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iLoaiGiaoDich.Properties.DataSource = this.loaiGiaoDichOBindingSource1;
            this.iLoaiGiaoDich.Properties.DisplayMember = "Name";
            this.iLoaiGiaoDich.Properties.ValueMember = "ID";
            this.iLoaiGiaoDich.Size = new System.Drawing.Size(158, 20);
            this.iLoaiGiaoDich.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(27, 145);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 13);
            this.labelControl7.TabIndex = 41;
            this.labelControl7.Text = "Hình thức:";
            // 
            // loaiGiaoDichOBindingSource1
            // 
            this.loaiGiaoDichOBindingSource1.DataSource = typeof(CRM.IntString);
            // 
            // loaiKhachOBindingSource
            // 
            this.loaiKhachOBindingSource.DataSource = typeof(CRM.IntString);
            // 
            // frmTongHopThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 300);
            this.Controls.Add(this.iLoaiGiaoDich);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iLoaiKhachHang);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iNgayGD);
            this.Controls.Add(this.iTenKhach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.iGiaThu);
            this.Controls.Add(this.iMaCho);
            this.Controls.Add(this.iIDKhachHang);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTongHopThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CK/ hỗ trợ";
            this.Load += new System.EventHandler(this.frmTongHopThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTongHopThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iIDKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMaCho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGiaThu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTenKhach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNgayGD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoaiGiaoDich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiGiaoDichOBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiKhachOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.SearchLookUpEdit iIDKhachHang;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraEditors.TextEdit iMaCho;
        private DevExpress.XtraEditors.SpinEdit iGiaThu;
        private DevExpress.XtraEditors.SimpleButton btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource daiLyOBindingSource;
        private DevExpress.XtraEditors.MemoEdit iTenKhach;
        private DevExpress.XtraEditors.DateEdit iNgayGD;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit iLoaiKhachHang;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.BindingSource loaiKhachOBindingSource;
        private System.Windows.Forms.BindingSource loaiGiaoDichOBindingSource1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LookUpEdit iLoaiGiaoDich;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}