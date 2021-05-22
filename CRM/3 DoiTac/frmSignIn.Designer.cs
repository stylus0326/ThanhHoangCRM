namespace CRM
{
    partial class frmSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignIn));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCSI = new DevExpress.XtraGrid.GridControl();
            this.signInOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVSI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSignIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHangTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueHangBay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.hangBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colChinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaiLyTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueDaiLy = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.daiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayGanNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.signInTrongOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHangBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDaiLy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInTrongOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTaiLai,
            this.btnThem});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTaiLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Caption = "làm mới";
            this.btnTaiLai.Id = 0;
            this.btnTaiLai.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaiLai.ImageOptions.SvgImage")));
            this.btnTaiLai.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaiLai_ItemClick);
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 1;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(985, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 540);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(985, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 516);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(985, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 516);
            // 
            // GCSI
            // 
            this.GCSI.DataSource = this.signInOBindingSource;
            this.GCSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSI.Location = new System.Drawing.Point(2, 23);
            this.GCSI.MainView = this.GVSI;
            this.GCSI.Name = "GCSI";
            this.GCSI.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueHangBay,
            this.lueDaiLy});
            this.GCSI.Size = new System.Drawing.Size(564, 491);
            this.GCSI.TabIndex = 4;
            this.GCSI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVSI});
            // 
            // signInOBindingSource
            // 
            this.signInOBindingSource.DataSource = typeof(DataTransferObject.O_SIGNIN);
            // 
            // GVSI
            // 
            this.GVSI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSignIn,
            this.colHangTT,
            this.colChinh,
            this.colDaiLyTT,
            this.colKhoa,
            this.colMatKhau,
            this.colNgayCap,
            this.colNgayKhoa,
            this.colNgayGanNhat});
            this.GVSI.GridControl = this.GCSI;
            this.GVSI.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", this.colDaiLyTT, "")});
            this.GVSI.Name = "GVSI";
            this.GVSI.OptionsBehavior.ReadOnly = true;
            this.GVSI.OptionsView.ShowAutoFilterRow = true;
            this.GVSI.OptionsView.ShowFooter = true;
            this.GVSI.OptionsView.ShowGroupPanel = false;
            this.GVSI.RowHeight = 25;
            this.GVSI.DoubleClick += new System.EventHandler(this.GVSI_DoubleClick);
            // 
            // colSignIn
            // 
            this.colSignIn.Caption = "Sign In";
            this.colSignIn.FieldName = "SignIn";
            this.colSignIn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colSignIn.Name = "colSignIn";
            this.colSignIn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSignIn.Visible = true;
            this.colSignIn.VisibleIndex = 3;
            this.colSignIn.Width = 111;
            // 
            // colHangTT
            // 
            this.colHangTT.Caption = "Hãng";
            this.colHangTT.ColumnEdit = this.lueHangBay;
            this.colHangTT.FieldName = "HangBay";
            this.colHangTT.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colHangTT.Name = "colHangTT";
            this.colHangTT.OptionsColumn.AllowEdit = false;
            this.colHangTT.Visible = true;
            this.colHangTT.VisibleIndex = 2;
            this.colHangTT.Width = 32;
            // 
            // lueHangBay
            // 
            this.lueHangBay.AutoHeight = false;
            this.lueHangBay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueHangBay.DataSource = this.hangBayOBindingSource;
            this.lueHangBay.DisplayMember = "TenTat";
            this.lueHangBay.Name = "lueHangBay";
            this.lueHangBay.ValueMember = "ID";
            // 
            // hangBayOBindingSource
            // 
            this.hangBayOBindingSource.DataSource = typeof(DataTransferObject.O_HANGBAY);
            // 
            // colChinh
            // 
            this.colChinh.Caption = "Xuất";
            this.colChinh.FieldName = "Chinh";
            this.colChinh.Name = "colChinh";
            this.colChinh.OptionsColumn.AllowEdit = false;
            this.colChinh.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colChinh.Visible = true;
            this.colChinh.VisibleIndex = 4;
            this.colChinh.Width = 24;
            // 
            // colDaiLyTT
            // 
            this.colDaiLyTT.Caption = "Đại lý";
            this.colDaiLyTT.ColumnEdit = this.lueDaiLy;
            this.colDaiLyTT.FieldName = "DaiLy";
            this.colDaiLyTT.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDaiLyTT.Name = "colDaiLyTT";
            this.colDaiLyTT.Visible = true;
            this.colDaiLyTT.VisibleIndex = 1;
            this.colDaiLyTT.Width = 85;
            // 
            // lueDaiLy
            // 
            this.lueDaiLy.AutoHeight = false;
            this.lueDaiLy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDaiLy.DataSource = this.daiLyOBindingSource;
            this.lueDaiLy.DisplayMember = "Ten";
            this.lueDaiLy.Name = "lueDaiLy";
            this.lueDaiLy.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueDaiLy.ValueMember = "ID";
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.O_DAILY);
            // 
            // colKhoa
            // 
            this.colKhoa.Caption = "Khóa";
            this.colKhoa.FieldName = "Khoa";
            this.colKhoa.Name = "colKhoa";
            this.colKhoa.Visible = true;
            this.colKhoa.VisibleIndex = 5;
            this.colKhoa.Width = 23;
            // 
            // colMatKhau
            // 
            this.colMatKhau.Caption = "Mật khẩu tạm khóa";
            this.colMatKhau.FieldName = "MatKhau";
            this.colMatKhau.Name = "colMatKhau";
            this.colMatKhau.Visible = true;
            this.colMatKhau.VisibleIndex = 6;
            this.colMatKhau.Width = 103;
            // 
            // colNgayCap
            // 
            this.colNgayCap.Caption = "Ngày cấp";
            this.colNgayCap.DisplayFormat.FormatString = "dd-MM-yy";
            this.colNgayCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNgayCap.FieldName = "NgayCap";
            this.colNgayCap.Name = "colNgayCap";
            this.colNgayCap.Visible = true;
            this.colNgayCap.VisibleIndex = 0;
            this.colNgayCap.Width = 55;
            // 
            // colNgayKhoa
            // 
            this.colNgayKhoa.Caption = "Ngày khóa";
            this.colNgayKhoa.DisplayFormat.FormatString = "dd-MM-yy";
            this.colNgayKhoa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayKhoa.FieldName = "NgayKhoa";
            this.colNgayKhoa.Name = "colNgayKhoa";
            this.colNgayKhoa.Visible = true;
            this.colNgayKhoa.VisibleIndex = 7;
            this.colNgayKhoa.Width = 47;
            // 
            // colNgayGanNhat
            // 
            this.colNgayGanNhat.Caption = "Ngày gần nhất";
            this.colNgayGanNhat.FieldName = "NgayGanNhat";
            this.colNgayGanNhat.Name = "colNgayGanNhat";
            this.colNgayGanNhat.Visible = true;
            this.colNgayGanNhat.VisibleIndex = 8;
            this.colNgayGanNhat.Width = 61;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.signInTrongOBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.gridControl1.Size = new System.Drawing.Size(403, 491);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // signInTrongOBindingSource
            // 
            this.signInTrongOBindingSource.DataSource = typeof(DataTransferObject.O_SIGNINTRONG);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sign In";
            this.gridColumn1.FieldName = "SignIn";
            this.gridColumn1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 121;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Hãng";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn2.FieldName = "HangBay";
            this.gridColumn2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 37;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.hangBayOBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "TenTat";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Xuất";
            this.gridColumn3.FieldName = "Chinh";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 49;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Mật khẩu";
            this.gridColumn6.FieldName = "MatKhau";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 113;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ngày tạo";
            this.gridColumn7.DisplayFormat.FormatString = "dd-MM-yy";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "NgayCap";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 60;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.DataSource = this.daiLyOBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "Ten";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEdit2.ValueMember = "ID";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GCSI);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(568, 516);
            this.groupControl1.TabIndex = 15;
            this.groupControl1.Text = "SignIn đang sử dụng";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(568, 24);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(10, 516);
            this.splitterControl1.TabIndex = 16;
            this.splitterControl1.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            buttonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions1.SvgImage")));
            buttonImageOptions1.SvgImageSize = new System.Drawing.Size(18, 18);
            this.groupControl2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.groupControl2.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(578, 24);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(407, 516);
            this.groupControl2.TabIndex = 17;
            this.groupControl2.Text = "SignIn trống";
            this.groupControl2.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl2_CustomButtonClick);
            // 
            // frmSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 540);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSignIn";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In";
            this.Load += new System.EventHandler(this.frmSignIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHangBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDaiLy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInTrongOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnTaiLai;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl GCSI;
        private DevExpress.XtraGrid.Views.Grid.GridView GVSI;
        private DevExpress.XtraGrid.Columns.GridColumn colSignIn;
        private DevExpress.XtraGrid.Columns.GridColumn colHangTT;
        private DevExpress.XtraGrid.Columns.GridColumn colChinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDaiLyTT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueHangBay;
        private System.Windows.Forms.BindingSource signInOBindingSource;
        private System.Windows.Forms.BindingSource hangBayOBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDaiLy;
        private System.Windows.Forms.BindingSource daiLyOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn colMatKhau;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCap;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayGanNhat;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.BindingSource signInTrongOBindingSource;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}