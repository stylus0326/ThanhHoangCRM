namespace CRM
{
    partial class frmNhomKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhomKhachHang));
            this.GCNKH = new DevExpress.XtraGrid.GridControl();
            this.nhomKhachHangOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVNKH = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTen = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTu = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDen = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.iTen = new DevExpress.XtraEditors.TextEdit();
            this.iTu = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iDen = new DevExpress.XtraEditors.SpinEdit();
            this.lbl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lbl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.pMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.GCTTKH = new DevExpress.XtraGrid.GridControl();
            this.trangThaiOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVTTKH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.btnLuu2 = new DevExpress.XtraEditors.SimpleButton();
            this.iTenTrangThai = new DevExpress.XtraEditors.TextEdit();
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GCNKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhomKhachHangOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCTTKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trangThaiOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTTKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTenTrangThai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GCNKH
            // 
            this.GCNKH.DataSource = this.nhomKhachHangOBindingSource;
            this.GCNKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCNKH.Location = new System.Drawing.Point(2, 20);
            this.GCNKH.MainView = this.GVNKH;
            this.GCNKH.Name = "GCNKH";
            this.GCNKH.Size = new System.Drawing.Size(453, 290);
            this.GCNKH.TabIndex = 0;
            this.GCNKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVNKH});
            // 
            // nhomKhachHangOBindingSource
            // 
            this.nhomKhachHangOBindingSource.DataSource = typeof(DataTransferObject.O_NHOMDAILY);
            // 
            // GVNKH
            // 
            this.GVNKH.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.GVNKH.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colTen,
            this.colTu,
            this.colDen});
            this.GVNKH.GridControl = this.GCNKH;
            this.GVNKH.IndicatorWidth = 30;
            this.GVNKH.Name = "GVNKH";
            this.GVNKH.OptionsBehavior.ReadOnly = true;
            this.GVNKH.OptionsView.ShowAutoFilterRow = true;
            this.GVNKH.OptionsView.ShowGroupPanel = false;
            this.GVNKH.RowHeight = 25;
            this.GVNKH.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GVNKH_PopupMenuShowing);
            this.GVNKH.Click += new System.EventHandler(this.GVNKH_Click);
            // 
            // gridBand2
            // 
            this.gridBand2.Columns.Add(this.colTen);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 122;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.Width = 122;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Tổng tiền mua vé trong tháng";
            this.gridBand1.Columns.Add(this.colTu);
            this.gridBand1.Columns.Add(this.colDen);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 225;
            // 
            // colTu
            // 
            this.colTu.Caption = "Từ";
            this.colTu.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colTu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTu.FieldName = "Tu";
            this.colTu.Name = "colTu";
            this.colTu.Visible = true;
            this.colTu.Width = 111;
            // 
            // colDen
            // 
            this.colDen.Caption = "Đến";
            this.colDen.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colDen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDen.FieldName = "Den";
            this.colDen.Name = "colDen";
            this.colDen.Visible = true;
            this.colDen.Width = 114;
            // 
            // iTen
            // 
            this.iTen.EditValue = "";
            this.iTen.Location = new System.Drawing.Point(65, 316);
            this.iTen.Name = "iTen";
            this.iTen.Size = new System.Drawing.Size(169, 20);
            this.iTen.TabIndex = 74;
            this.iTen.Tag = "Ten";
            // 
            // iTu
            // 
            this.iTu.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iTu.Location = new System.Drawing.Point(65, 342);
            this.iTu.Name = "iTu";
            this.iTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.iTu.Properties.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.iTu.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iTu.Properties.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.iTu.Size = new System.Drawing.Size(131, 20);
            this.iTu.TabIndex = 75;
            this.iTu.Tag = "Từ";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(210, 345);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 79;
            this.labelControl3.Text = "Đến:";
            // 
            // iDen
            // 
            this.iDen.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iDen.Location = new System.Drawing.Point(240, 342);
            this.iDen.Name = "iDen";
            this.iDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.iDen.Properties.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.iDen.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iDen.Properties.EditFormat.FormatString = "####";
            this.iDen.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iDen.Properties.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.iDen.Size = new System.Drawing.Size(131, 20);
            this.iDen.TabIndex = 76;
            this.iDen.Tag = "Đến";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(42, 345);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(17, 13);
            this.lbl2.TabIndex = 78;
            this.lbl2.Text = "Từ:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 319);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 13);
            this.labelControl5.TabIndex = 77;
            this.labelControl5.Text = "Tên nhóm:";
            // 
            // lbl5
            // 
            this.lbl5.Location = new System.Drawing.Point(377, 345);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(21, 13);
            this.lbl5.TabIndex = 81;
            this.lbl5.Text = "VNĐ";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.Location = new System.Drawing.Point(410, 319);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(40, 39);
            this.btnLuu.TabIndex = 82;
            this.btnLuu.TabStop = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(240, 316);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Thêm";
            this.checkEdit1.Size = new System.Drawing.Size(47, 19);
            this.checkEdit1.TabIndex = 83;
            // 
            // pMenu
            // 
            this.pMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa)});
            this.pMenu.Manager = this.barManager1;
            this.pMenu.Name = "pMenu";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 0;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnXoa});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(753, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 369);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(753, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 369);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(753, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 369);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GCNKH);
            this.groupControl1.Controls.Add(this.checkEdit1);
            this.groupControl1.Controls.Add(this.lbl5);
            this.groupControl1.Controls.Add(this.btnLuu);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.iTen);
            this.groupControl1.Controls.Add(this.lbl2);
            this.groupControl1.Controls.Add(this.iTu);
            this.groupControl1.Controls.Add(this.iDen);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(457, 369);
            this.groupControl1.TabIndex = 88;
            this.groupControl1.Text = "Nhóm khách hàng";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.checkEdit2);
            this.groupControl2.Controls.Add(this.GCTTKH);
            this.groupControl2.Controls.Add(this.btnLuu2);
            this.groupControl2.Controls.Add(this.iTenTrangThai);
            this.groupControl2.Controls.Add(this.lbl);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(457, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(296, 369);
            this.groupControl2.TabIndex = 89;
            this.groupControl2.Text = "Tình Trạng khách hàng";
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(193, 342);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Thêm";
            this.checkEdit2.Size = new System.Drawing.Size(47, 19);
            this.checkEdit2.TabIndex = 86;
            // 
            // GCTTKH
            // 
            this.GCTTKH.DataSource = this.trangThaiOBindingSource;
            this.GCTTKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.GCTTKH.Location = new System.Drawing.Point(2, 20);
            this.GCTTKH.MainView = this.GVTTKH;
            this.GCTTKH.Name = "GCTTKH";
            this.GCTTKH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rColor});
            this.GCTTKH.Size = new System.Drawing.Size(292, 290);
            this.GCTTKH.TabIndex = 85;
            this.GCTTKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVTTKH});
            // 
            // trangThaiOBindingSource
            // 
            this.trangThaiOBindingSource.DataSource = typeof(DataTransferObject.O_TRANGTHAI);
            // 
            // GVTTKH
            // 
            this.GVTTKH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenTrangThai});
            this.GVTTKH.GridControl = this.GCTTKH;
            this.GVTTKH.IndicatorWidth = 30;
            this.GVTTKH.Name = "GVTTKH";
            this.GVTTKH.OptionsBehavior.ReadOnly = true;
            this.GVTTKH.OptionsView.ShowAutoFilterRow = true;
            this.GVTTKH.OptionsView.ShowGroupPanel = false;
            this.GVTTKH.RowHeight = 25;
            this.GVTTKH.Click += new System.EventHandler(this.GVTTKH_Click);
            // 
            // colTenTrangThai
            // 
            this.colTenTrangThai.Caption = "Tên";
            this.colTenTrangThai.FieldName = "TenTrangThai";
            this.colTenTrangThai.Name = "colTenTrangThai";
            this.colTenTrangThai.Visible = true;
            this.colTenTrangThai.VisibleIndex = 0;
            // 
            // rColor
            // 
            this.rColor.AutoHeight = false;
            this.rColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rColor.Name = "rColor";
            // 
            // btnLuu2
            // 
            this.btnLuu2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu2.Appearance.Options.UseFont = true;
            this.btnLuu2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu2.ImageOptions.SvgImage")));
            this.btnLuu2.Location = new System.Drawing.Point(246, 319);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(40, 39);
            this.btnLuu2.TabIndex = 84;
            this.btnLuu2.TabStop = false;
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // iTenTrangThai
            // 
            this.iTenTrangThai.Location = new System.Drawing.Point(84, 316);
            this.iTenTrangThai.Name = "iTenTrangThai";
            this.iTenTrangThai.Size = new System.Drawing.Size(156, 20);
            this.iTenTrangThai.TabIndex = 55;
            this.iTenTrangThai.Tag = "Ten";
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(6, 319);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(72, 13);
            this.lbl.TabIndex = 59;
            this.lbl.Text = "Tên tình trạng:";
            // 
            // frmNhomKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 369);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNhomKhachHang";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmNhomKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCNKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhomKhachHangOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCTTKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trangThaiOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTTKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTenTrangThai.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCNKH;
        private System.Windows.Forms.BindingSource nhomKhachHangOBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView GVNKH;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTen;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTu;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDen;
        private DevExpress.XtraEditors.TextEdit iTen;
        private DevExpress.XtraEditors.SpinEdit iTu;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit iDen;
        private DevExpress.XtraEditors.LabelControl lbl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lbl5;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraBars.PopupMenu pMenu;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl GCTTKH;
        private System.Windows.Forms.BindingSource trangThaiOBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GVTTKH;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit rColor;
        private DevExpress.XtraEditors.SimpleButton btnLuu2;
        private DevExpress.XtraEditors.TextEdit iTenTrangThai;
        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
    }
}