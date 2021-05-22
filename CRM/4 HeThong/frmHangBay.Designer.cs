namespace CRM
{
    partial class frmHangBay
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangBay));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.GrHang = new DevExpress.XtraEditors.GroupControl();
            this.GCHB = new DevExpress.XtraGrid.GridControl();
            this.hangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVHB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtxtMatKhau = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.GrNCC = new DevExpress.XtraEditors.GroupControl();
            this.GCNCC = new DevExpress.XtraGrid.GridControl();
            this.nCCOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVNCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTen1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDu1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDayDu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpThem = new DevExpress.XtraEditors.GroupControl();
            this.GCNCCGD = new DevExpress.XtraGrid.GridControl();
            this.nCCGDOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVNCCGD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rNCC = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNgayGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiGiaoDich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLoai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.intStringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnLoad = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.GrHang)).BeginInit();
            this.GrHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCHB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVHB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtMatKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrNCC)).BeginInit();
            this.GrNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpThem)).BeginInit();
            this.grpThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCNCCGD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCGDOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNCCGD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intStringBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrHang
            // 
            this.GrHang.Controls.Add(this.GCHB);
            buttonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions1.SvgImage")));
            buttonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            this.GrHang.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.GrHang.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.GrHang.Dock = System.Windows.Forms.DockStyle.Left;
            this.GrHang.Location = new System.Drawing.Point(0, 24);
            this.GrHang.Name = "GrHang";
            this.GrHang.Size = new System.Drawing.Size(252, 548);
            this.GrHang.TabIndex = 1;
            this.GrHang.Text = "Danh sách hãng bay";
            this.GrHang.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.GrHang_CustomButtonClick);
            // 
            // GCHB
            // 
            this.GCHB.DataSource = this.hangBindingSource;
            this.GCHB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCHB.Location = new System.Drawing.Point(2, 29);
            this.GCHB.MainView = this.GVHB;
            this.GCHB.Name = "GCHB";
            this.GCHB.Size = new System.Drawing.Size(248, 517);
            this.GCHB.TabIndex = 4;
            this.GCHB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVHB});
            // 
            // hangBindingSource
            // 
            this.hangBindingSource.DataSource = typeof(DataTransferObject.HangBayO);
            // 
            // GVHB
            // 
            this.GVHB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTen,
            this.colTenTat,
            this.colID});
            this.GVHB.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.GVHB.GridControl = this.GCHB;
            this.GVHB.Name = "GVHB";
            this.GVHB.OptionsBehavior.ReadOnly = true;
            this.GVHB.OptionsView.ShowAutoFilterRow = true;
            this.GVHB.OptionsView.ShowGroupPanel = false;
            this.GVHB.RowHeight = 25;
            this.GVHB.DoubleClick += new System.EventHandler(this.GVHB_DoubleClick);
            // 
            // colTen
            // 
            this.colTen.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colTen.AppearanceCell.ForeColor = System.Drawing.Color.Crimson;
            this.colTen.AppearanceCell.Options.UseFont = true;
            this.colTen.AppearanceCell.Options.UseForeColor = true;
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "TenHang";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 2;
            this.colTen.Width = 137;
            // 
            // colTenTat
            // 
            this.colTenTat.Caption = "Tên tắt";
            this.colTenTat.FieldName = "TenTat";
            this.colTenTat.Name = "colTenTat";
            this.colTenTat.OptionsColumn.FixedWidth = true;
            this.colTenTat.Visible = true;
            this.colTenTat.VisibleIndex = 1;
            this.colTenTat.Width = 45;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.FixedWidth = true;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 50;
            // 
            // rtxtMatKhau
            // 
            this.rtxtMatKhau.Name = "rtxtMatKhau";
            // 
            // GrNCC
            // 
            this.GrNCC.Controls.Add(this.GCNCC);
            buttonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions2.SvgImage")));
            buttonImageOptions2.SvgImageSize = new System.Drawing.Size(16, 16);
            this.GrNCC.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.GrNCC.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.GrNCC.Dock = System.Windows.Forms.DockStyle.Left;
            this.GrNCC.Location = new System.Drawing.Point(252, 24);
            this.GrNCC.Name = "GrNCC";
            this.GrNCC.Size = new System.Drawing.Size(309, 548);
            this.GrNCC.TabIndex = 2;
            this.GrNCC.Text = "Nhà cung cấp";
            this.GrNCC.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.GrNCC_CustomButtonClick);
            // 
            // GCNCC
            // 
            this.GCNCC.DataSource = this.nCCOBindingSource;
            this.GCNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCNCC.Location = new System.Drawing.Point(2, 29);
            this.GCNCC.MainView = this.GVNCC;
            this.GCNCC.Name = "GCNCC";
            this.GCNCC.Size = new System.Drawing.Size(305, 517);
            this.GCNCC.TabIndex = 8;
            this.GCNCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVNCC});
            this.GCNCC.DoubleClick += new System.EventHandler(this.GVNCC_DoubleClick);
            // 
            // nCCOBindingSource
            // 
            this.nCCOBindingSource.DataSource = typeof(DataTransferObject.NCCO);
            // 
            // GVNCC
            // 
            this.GVNCC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTen1,
            this.colSoDu1,
            this.colTenDayDu,
            this.colID2});
            this.GVNCC.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.GVNCC.GridControl = this.GCNCC;
            this.GVNCC.Name = "GVNCC";
            this.GVNCC.OptionsBehavior.ReadOnly = true;
            this.GVNCC.OptionsView.ShowAutoFilterRow = true;
            this.GVNCC.OptionsView.ShowGroupPanel = false;
            this.GVNCC.RowHeight = 25;
            // 
            // colTen1
            // 
            this.colTen1.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colTen1.AppearanceCell.ForeColor = System.Drawing.Color.Crimson;
            this.colTen1.AppearanceCell.Options.UseFont = true;
            this.colTen1.AppearanceCell.Options.UseForeColor = true;
            this.colTen1.Caption = "Viết tắt";
            this.colTen1.FieldName = "Ten";
            this.colTen1.Name = "colTen1";
            this.colTen1.OptionsColumn.FixedWidth = true;
            this.colTen1.Visible = true;
            this.colTen1.VisibleIndex = 2;
            this.colTen1.Width = 51;
            // 
            // colSoDu1
            // 
            this.colSoDu1.Caption = "Số dư";
            this.colSoDu1.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDu1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDu1.FieldName = "SoDu";
            this.colSoDu1.Name = "colSoDu1";
            this.colSoDu1.Visible = true;
            this.colSoDu1.VisibleIndex = 3;
            this.colSoDu1.Width = 104;
            // 
            // colTenDayDu
            // 
            this.colTenDayDu.Caption = "Tên";
            this.colTenDayDu.FieldName = "TenDayDu";
            this.colTenDayDu.Name = "colTenDayDu";
            this.colTenDayDu.Visible = true;
            this.colTenDayDu.VisibleIndex = 1;
            this.colTenDayDu.Width = 74;
            // 
            // colID2
            // 
            this.colID2.FieldName = "ID";
            this.colID2.Name = "colID2";
            this.colID2.Visible = true;
            this.colID2.VisibleIndex = 0;
            this.colID2.Width = 34;
            // 
            // grpThem
            // 
            this.grpThem.Controls.Add(this.GCNCCGD);
            buttonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonImageOptions3.SvgImage")));
            buttonImageOptions3.SvgImageSize = new System.Drawing.Size(16, 16);
            this.grpThem.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.grpThem.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.grpThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThem.Location = new System.Drawing.Point(561, 24);
            this.grpThem.Name = "grpThem";
            this.grpThem.Size = new System.Drawing.Size(370, 548);
            this.grpThem.TabIndex = 3;
            this.grpThem.Text = "Phí/CK";
            this.grpThem.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.grpThem_CustomButtonClick);
            // 
            // GCNCCGD
            // 
            this.GCNCCGD.DataSource = this.nCCGDOBindingSource;
            this.GCNCCGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCNCCGD.Location = new System.Drawing.Point(2, 29);
            this.GCNCCGD.MainView = this.GVNCCGD;
            this.GCNCCGD.Name = "GCNCCGD";
            this.GCNCCGD.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rNCC,
            this.rLoai});
            this.GCNCCGD.Size = new System.Drawing.Size(366, 517);
            this.GCNCCGD.TabIndex = 4;
            this.GCNCCGD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVNCCGD});
            // 
            // nCCGDOBindingSource
            // 
            this.nCCGDOBindingSource.DataSource = typeof(DataTransferObject.NCCGDO);
            // 
            // GVNCCGD
            // 
            this.GVNCCGD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colNCC,
            this.colNgayGD,
            this.colSoTien,
            this.colLoaiGiaoDich,
            this.colGhiChu});
            this.GVNCCGD.GridControl = this.GCNCCGD;
            this.GVNCCGD.Name = "GVNCCGD";
            this.GVNCCGD.OptionsView.ShowAutoFilterRow = true;
            this.GVNCCGD.OptionsView.ShowFooter = true;
            this.GVNCCGD.OptionsView.ShowGroupPanel = false;
            this.GVNCCGD.RowHeight = 25;
            this.GVNCCGD.DoubleClick += new System.EventHandler(this.GVNCCGD_DoubleClick);
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.Name = "colID1";
            this.colID1.OptionsColumn.FixedWidth = true;
            this.colID1.Visible = true;
            this.colID1.VisibleIndex = 0;
            this.colID1.Width = 44;
            // 
            // colNCC
            // 
            this.colNCC.Caption = "Tên";
            this.colNCC.ColumnEdit = this.rNCC;
            this.colNCC.FieldName = "NCC";
            this.colNCC.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNCC.Name = "colNCC";
            this.colNCC.Visible = true;
            this.colNCC.VisibleIndex = 2;
            this.colNCC.Width = 129;
            // 
            // rNCC
            // 
            this.rNCC.AutoHeight = false;
            this.rNCC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rNCC.DataSource = this.nCCOBindingSource;
            this.rNCC.DisplayMember = "TenDayDu";
            this.rNCC.Name = "rNCC";
            this.rNCC.ValueMember = "ID";
            // 
            // colNgayGD
            // 
            this.colNgayGD.Caption = "Ngày";
            this.colNgayGD.FieldName = "NgayGD";
            this.colNgayGD.Name = "colNgayGD";
            this.colNgayGD.Visible = true;
            this.colNgayGD.VisibleIndex = 1;
            this.colNgayGD.Width = 129;
            // 
            // colSoTien
            // 
            this.colSoTien.Caption = "Số tiền";
            this.colSoTien.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTien.FieldName = "SoTien";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTien", "{0:#,##0;(#,##0)}")});
            this.colSoTien.Visible = true;
            this.colSoTien.VisibleIndex = 4;
            this.colSoTien.Width = 129;
            // 
            // colLoaiGiaoDich
            // 
            this.colLoaiGiaoDich.Caption = "Loại giao dịch";
            this.colLoaiGiaoDich.ColumnEdit = this.rLoai;
            this.colLoaiGiaoDich.FieldName = "LoaiGiaoDich";
            this.colLoaiGiaoDich.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLoaiGiaoDich.Name = "colLoaiGiaoDich";
            this.colLoaiGiaoDich.Visible = true;
            this.colLoaiGiaoDich.VisibleIndex = 3;
            this.colLoaiGiaoDich.Width = 129;
            // 
            // rLoai
            // 
            this.rLoai.AutoHeight = false;
            this.rLoai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLoai.DataSource = this.intStringBindingSource;
            this.rLoai.DisplayMember = "Name";
            this.rLoai.Name = "rLoai";
            this.rLoai.ValueMember = "ID";
            // 
            // intStringBindingSource
            // 
            this.intStringBindingSource.DataSource = typeof(CRM.IntString);
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 5;
            this.colGhiChu.Width = 132;
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
            this.btnLoad});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLoad, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnLoad
            // 
            this.btnLoad.Caption = "Làm mới";
            this.btnLoad.Id = 0;
            this.btnLoad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLoad.ImageOptions.SvgImage")));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadHB_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(931, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 572);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(931, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 548);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(931, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 548);
            // 
            // frmHangBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 572);
            this.Controls.Add(this.grpThem);
            this.Controls.Add(this.GrNCC);
            this.Controls.Add(this.GrHang);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmHangBay";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hãng bay & NCC";
            this.Load += new System.EventHandler(this.frmHangBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrHang)).EndInit();
            this.GrHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCHB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVHB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtMatKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrNCC)).EndInit();
            this.GrNCC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpThem)).EndInit();
            this.grpThem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCNCCGD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCGDOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNCCGD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intStringBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GrHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtMatKhau;
        private DevExpress.XtraEditors.GroupControl GrNCC;
        private DevExpress.XtraGrid.GridControl GCHB;
        private System.Windows.Forms.BindingSource hangBindingSource;
        private DevExpress.XtraGrid.GridControl GCNCC;
        private System.Windows.Forms.BindingSource nCCOBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GVHB;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTat;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.GroupControl grpThem;
        private DevExpress.XtraGrid.GridControl GCNCCGD;
        private DevExpress.XtraGrid.Views.Grid.GridView GVNCCGD;
        private System.Windows.Forms.BindingSource nCCGDOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colNCC;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayGD;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiGiaoDich;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rNCC;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLoai;
        private System.Windows.Forms.BindingSource intStringBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GVNCC;
        private DevExpress.XtraGrid.Columns.GridColumn colTen1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDu1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDayDu;
        private DevExpress.XtraGrid.Columns.GridColumn colID2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnLoad;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}