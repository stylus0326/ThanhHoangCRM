namespace CRM
{
    partial class frmTuyenBay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuyenBay));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GCSB = new DevExpress.XtraGrid.GridControl();
            this.sanBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVSB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKyHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDayDu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnLoad1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.GCTB = new DevExpress.XtraGrid.GridControl();
            this.tuyenBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVTB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKyHieuDi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rSanBay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKyHieuDen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.btnLoad2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.colNoiDia = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCSB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyenBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSanBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.GCSB);
            this.groupControl1.Controls.Add(this.barDockControlLeft);
            this.groupControl1.Controls.Add(this.barDockControlRight);
            this.groupControl1.Controls.Add(this.barDockControlBottom);
            this.groupControl1.Controls.Add(this.barDockControlTop);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(326, 488);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Sân bay";
            // 
            // GCSB
            // 
            this.GCSB.DataSource = this.sanBayOBindingSource;
            this.GCSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSB.Location = new System.Drawing.Point(2, 44);
            this.GCSB.MainView = this.GVSB;
            this.GCSB.MenuManager = this.barManager1;
            this.GCSB.Name = "GCSB";
            this.GCSB.Size = new System.Drawing.Size(322, 442);
            this.GCSB.TabIndex = 4;
            this.GCSB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVSB});
            // 
            // sanBayOBindingSource
            // 
            this.sanBayOBindingSource.DataSource = typeof(DataTransferObject.SanBayO);
            // 
            // GVSB
            // 
            this.GVSB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colKyHieu,
            this.colTenDayDu,
            this.colNoiDia});
            this.GVSB.GridControl = this.GCSB;
            this.GVSB.Name = "GVSB";
            this.GVSB.OptionsBehavior.ReadOnly = true;
            this.GVSB.OptionsView.ShowAutoFilterRow = true;
            this.GVSB.OptionsView.ShowGroupPanel = false;
            this.GVSB.RowHeight = 25;
            this.GVSB.DoubleClick += new System.EventHandler(this.GVSB_DoubleClick);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 41;
            // 
            // colKyHieu
            // 
            this.colKyHieu.Caption = "Tên tắt";
            this.colKyHieu.FieldName = "KyHieu";
            this.colKyHieu.Name = "colKyHieu";
            this.colKyHieu.Visible = true;
            this.colKyHieu.VisibleIndex = 1;
            this.colKyHieu.Width = 44;
            // 
            // colTenDayDu
            // 
            this.colTenDayDu.Caption = "Tên";
            this.colTenDayDu.FieldName = "TenDayDu";
            this.colTenDayDu.Name = "colTenDayDu";
            this.colTenDayDu.Visible = true;
            this.colTenDayDu.VisibleIndex = 2;
            this.colTenDayDu.Width = 147;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this.groupControl1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLoad1,
            this.btnThem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLoad1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnLoad1
            // 
            this.btnLoad1.Id = 0;
            this.btnLoad1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLoad1.ImageOptions.SvgImage")));
            this.btnLoad1.Name = "btnLoad1";
            this.btnLoad1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoad1_ItemClick);
            // 
            // btnThem1
            // 
            this.btnThem1.Caption = "Thêm";
            this.btnThem1.Id = 1;
            this.btnThem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem1.ImageOptions.SvgImage")));
            this.btnThem1.Name = "btnThem1";
            this.btnThem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(2, 20);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(322, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(2, 486);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(322, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(2, 44);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 442);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(324, 44);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 442);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.GCTB);
            this.groupControl2.Controls.Add(this.barDockControl3);
            this.groupControl2.Controls.Add(this.barDockControl4);
            this.groupControl2.Controls.Add(this.barDockControl2);
            this.groupControl2.Controls.Add(this.barDockControl1);
            this.groupControl2.Location = new System.Drawing.Point(337, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(428, 488);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Tuyến bay";
            // 
            // GCTB
            // 
            this.GCTB.DataSource = this.tuyenBayOBindingSource;
            this.GCTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCTB.Location = new System.Drawing.Point(2, 44);
            this.GCTB.MainView = this.GVTB;
            this.GCTB.MenuManager = this.barManager1;
            this.GCTB.Name = "GCTB";
            this.GCTB.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rSanBay});
            this.GCTB.Size = new System.Drawing.Size(424, 442);
            this.GCTB.TabIndex = 4;
            this.GCTB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVTB});
            // 
            // tuyenBayOBindingSource
            // 
            this.tuyenBayOBindingSource.DataSource = typeof(DataTransferObject.TuyenBayO);
            // 
            // GVTB
            // 
            this.GVTB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colTen,
            this.colKyHieuDi,
            this.colKyHieuDen});
            this.GVTB.GridControl = this.GCTB;
            this.GVTB.Name = "GVTB";
            this.GVTB.OptionsBehavior.ReadOnly = true;
            this.GVTB.OptionsView.ShowAutoFilterRow = true;
            this.GVTB.OptionsView.ShowGroupPanel = false;
            this.GVTB.RowHeight = 25;
            this.GVTB.DoubleClick += new System.EventHandler(this.GVTB_DoubleClick);
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.Name = "colID1";
            this.colID1.Visible = true;
            this.colID1.VisibleIndex = 0;
            this.colID1.Width = 54;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            this.colTen.Width = 74;
            // 
            // colKyHieuDi
            // 
            this.colKyHieuDi.Caption = "Nơi đi";
            this.colKyHieuDi.ColumnEdit = this.rSanBay;
            this.colKyHieuDi.FieldName = "KyHieuDi";
            this.colKyHieuDi.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colKyHieuDi.Name = "colKyHieuDi";
            this.colKyHieuDi.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colKyHieuDi.Visible = true;
            this.colKyHieuDi.VisibleIndex = 2;
            this.colKyHieuDi.Width = 176;
            // 
            // rSanBay
            // 
            this.rSanBay.AutoHeight = false;
            this.rSanBay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rSanBay.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDayDu", "", 66, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rSanBay.DataSource = this.sanBayOBindingSource;
            this.rSanBay.DisplayMember = "TenDayDu";
            this.rSanBay.Name = "rSanBay";
            this.rSanBay.ValueMember = "ID";
            // 
            // colKyHieuDen
            // 
            this.colKyHieuDen.Caption = "Nơi đến";
            this.colKyHieuDen.ColumnEdit = this.rSanBay;
            this.colKyHieuDen.FieldName = "KyHieuDen";
            this.colKyHieuDen.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colKyHieuDen.Name = "colKyHieuDen";
            this.colKyHieuDen.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colKyHieuDen.Visible = true;
            this.colKyHieuDen.VisibleIndex = 3;
            this.colKyHieuDen.Width = 180;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(2, 44);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(0, 442);
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar5});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this.groupControl2;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLoad2,
            this.btnThem2});
            this.barManager2.MainMenu = this.bar5;
            this.barManager2.MaxItemId = 2;
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLoad2),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // btnLoad2
            // 
            this.btnLoad2.Id = 0;
            this.btnLoad2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLoad2.ImageOptions.SvgImage")));
            this.btnLoad2.Name = "btnLoad2";
            this.btnLoad2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoad2_ItemClick);
            // 
            // btnThem2
            // 
            this.btnThem2.Caption = "Thêm";
            this.btnThem2.Id = 1;
            this.btnThem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem2.ImageOptions.SvgImage")));
            this.btnThem2.Name = "btnThem2";
            this.btnThem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem2_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(2, 20);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Size = new System.Drawing.Size(424, 24);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(2, 486);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(424, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(426, 44);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 442);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Id = 0;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Thêm";
            this.barButtonItem4.Id = 1;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // colNoiDia
            // 
            this.colNoiDia.Caption = "Nội địa";
            this.colNoiDia.FieldName = "NoiDia";
            this.colNoiDia.Name = "colNoiDia";
            this.colNoiDia.Visible = true;
            this.colNoiDia.VisibleIndex = 3;
            // 
            // frmTuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 497);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(780, 525);
            this.Name = "frmTuyenBay";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tuyến bay";
            this.Load += new System.EventHandler(this.frmTuyenBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCSB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyenBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSanBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnLoad1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarButtonItem btnLoad2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem btnThem1;
        private DevExpress.XtraBars.BarButtonItem btnThem2;
        private DevExpress.XtraGrid.GridControl GCSB;
        private DevExpress.XtraGrid.Views.Grid.GridView GVSB;
        private DevExpress.XtraGrid.GridControl GCTB;
        private DevExpress.XtraGrid.Views.Grid.GridView GVTB;
        private System.Windows.Forms.BindingSource sanBayOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHieu;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDayDu;
        private System.Windows.Forms.BindingSource tuyenBayOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHieuDi;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHieuDen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rSanBay;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDia;
    }
}