namespace CRM
{
    partial class frmAutoNganHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoNganHang));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnLoad = new DevExpress.XtraBars.BarButtonItem();
            this.eNganHang = new DevExpress.XtraBars.BarEditItem();
            this.rNganHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.nganHangOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNgay = new DevExpress.XtraBars.BarEditItem();
            this.rNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnCH = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnLo = new DevExpress.XtraBars.BarButtonItem();
            this.btnBC = new DevExpress.XtraBars.BarButtonItem();
            this.btnLBC = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lblSD1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblSD2 = new DevExpress.XtraBars.BarStaticItem();
            this.lblSD3 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.cTNganHangOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.DataHinhThuc = new System.Windows.Forms.BindingSource(this.components);
            this.GCCTNH = new DevExpress.XtraGrid.GridControl();
            this.GVCTNH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNVGiaoDich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rKhachHang = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.DataTen = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiGiaoDich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rHinhThuc = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLoaiKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLoaiKhachHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.DataLoaiKhach = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nganHangOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNgay.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTNganHangOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCCTNH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCTNH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoaiKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLoaiKhach)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblSD1,
            this.lblSD2,
            this.lblSD3,
            this.eNganHang,
            this.eNgay,
            this.btnLoad,
            this.btnCH,
            this.btnLo,
            this.btnBC,
            this.btnLBC,
            this.btnThem,
            this.btnExcel,
            this.btnXoa});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 20;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rNganHang,
            this.rNgay});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLoad, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.eNganHang, "", true, true, true, 127, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.eNgay, "", false, true, true, 90, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCH, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExcel),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLo, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnBC, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLBC, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnLoad
            // 
            this.btnLoad.Caption = "Làm mới";
            this.btnLoad.Id = 9;
            this.btnLoad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLoad.ImageOptions.SvgImage")));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoad_ItemClick);
            // 
            // eNganHang
            // 
            this.eNganHang.Caption = "Ngân hàng:";
            this.eNganHang.Edit = this.rNganHang;
            this.eNganHang.Id = 5;
            this.eNganHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("eNganHang.ImageOptions.SvgImage")));
            this.eNganHang.Name = "eNganHang";
            // 
            // rNganHang
            // 
            this.rNganHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rNganHang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "", 28, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rNganHang.DataSource = this.nganHangOBindingSource;
            this.rNganHang.DisplayMember = "Ten";
            this.rNganHang.Name = "rNganHang";
            this.rNganHang.NullText = "[Chọn...]";
            this.rNganHang.ValueMember = "ID";
            this.rNganHang.EditValueChanged += new System.EventHandler(this.rNganHang_EditValueChanged);
            // 
            // nganHangOBindingSource
            // 
            this.nganHangOBindingSource.DataSource = typeof(DataTransferObject.NganHangO);
            // 
            // eNgay
            // 
            this.eNgay.Caption = "Lấy từ ngày:";
            this.eNgay.Edit = this.rNgay;
            this.eNgay.Id = 6;
            this.eNgay.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("eNgay.ImageOptions.SvgImage")));
            this.eNgay.Name = "eNgay";
            this.eNgay.EditValueChanged += new System.EventHandler(this.eNgay_EditValueChanged);
            // 
            // rNgay
            // 
            this.rNgay.AutoHeight = false;
            this.rNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rNgay.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rNgay.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.rNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.rNgay.Mask.EditMask = "dd-MM-yyyy";
            this.rNgay.Name = "rNgay";
            // 
            // btnCH
            // 
            this.btnCH.Id = 13;
            this.btnCH.ImageOptions.SvgImage = global::CRM.Properties.Resources.chrome;
            this.btnCH.Name = "btnCH";
            this.btnCH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCH_ItemClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Up Excel";
            this.btnExcel.Id = 18;
            this.btnExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.Image")));
            this.btnExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.LargeImage")));
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel_ItemClick);
            // 
            // btnLo
            // 
            this.btnLo.Caption = "Đăng nhập";
            this.btnLo.Id = 14;
            this.btnLo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLo.ImageOptions.SvgImage")));
            this.btnLo.Name = "btnLo";
            this.btnLo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLo_ItemClick);
            // 
            // btnBC
            // 
            this.btnBC.Caption = "Vào báo cáo";
            this.btnBC.Id = 15;
            this.btnBC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBC.ImageOptions.SvgImage")));
            this.btnBC.Name = "btnBC";
            this.btnBC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBC_ItemClick);
            // 
            // btnLBC
            // 
            this.btnLBC.Caption = "Lấy báo cáo";
            this.btnLBC.Id = 16;
            this.btnLBC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLBC.ImageOptions.SvgImage")));
            this.btnLBC.Name = "btnLBC";
            this.btnLBC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLBC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLBC_ItemClick);
            // 
            // btnThem
            // 
            this.btnThem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 17;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblSD1),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblSD2),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblSD3)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lblSD1
            // 
            this.lblSD1.Caption = "Số dư phần mềm:";
            this.lblSD1.Id = 2;
            this.lblSD1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSD1.ItemAppearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.lblSD1.ItemAppearance.Normal.Options.UseFont = true;
            this.lblSD1.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblSD1.Name = "lblSD1";
            // 
            // lblSD2
            // 
            this.lblSD2.Caption = "Số dư ngân hàng:";
            this.lblSD2.Id = 3;
            this.lblSD2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSD2.ItemAppearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.lblSD2.ItemAppearance.Normal.Options.UseFont = true;
            this.lblSD2.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblSD2.Name = "lblSD2";
            // 
            // lblSD3
            // 
            this.lblSD3.Caption = "Số dư tự tính:";
            this.lblSD3.Id = 4;
            this.lblSD3.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSD3.ItemAppearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.lblSD3.ItemAppearance.Normal.Options.UseFont = true;
            this.lblSD3.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblSD3.Name = "lblSD3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1003, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 556);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1003, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 532);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1003, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 532);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 19;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // cTNganHangOBindingSource
            // 
            this.cTNganHangOBindingSource.DataSource = typeof(DataTransferObject.CTNganHangO);
            // 
            // pMenu
            // 
            this.pMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa)});
            this.pMenu.Manager = this.barManager1;
            this.pMenu.MinWidth = 200;
            this.pMenu.Name = "pMenu";
            // 
            // DataHinhThuc
            // 
            this.DataHinhThuc.DataSource = typeof(CRM.IntString);
            // 
            // GCCTNH
            // 
            this.GCCTNH.DataSource = this.cTNganHangOBindingSource;
            this.GCCTNH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCCTNH.Location = new System.Drawing.Point(0, 24);
            this.GCCTNH.MainView = this.GVCTNH;
            this.GCCTNH.Name = "GCCTNH";
            this.GCCTNH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rHinhThuc,
            this.rLoaiKhachHang,
            this.rKhachHang});
            this.GCCTNH.Size = new System.Drawing.Size(1003, 532);
            this.GCCTNH.TabIndex = 9;
            this.GCCTNH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVCTNH});
            // 
            // GVCTNH
            // 
            this.GVCTNH.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.GVCTNH.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GVCTNH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNgayGD,
            this.colSoTien,
            this.colGhiChu,
            this.colTrangThaiID,
            this.colNgayHT,
            this.colNVGiaoDich,
            this.colLoaiGiaoDich,
            this.colLoaiKhachHang});
            this.GVCTNH.GridControl = this.GCCTNH;
            this.GVCTNH.IndicatorWidth = 50;
            this.GVCTNH.Name = "GVCTNH";
            this.GVCTNH.OptionsView.EnableAppearanceEvenRow = true;
            this.GVCTNH.OptionsView.ShowAutoFilterRow = true;
            this.GVCTNH.OptionsView.ShowFooter = true;
            this.GVCTNH.OptionsView.ShowGroupPanel = false;
            this.GVCTNH.RowHeight = 25;
            this.GVCTNH.ShownEditor += new System.EventHandler(this.GVCTNH_ShownEditor);
            this.GVCTNH.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GVCTNH_CellValueChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colNgayGD
            // 
            this.colNgayGD.Caption = "Ngày GD";
            this.colNgayGD.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayGD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayGD.FieldName = "NgayGD";
            this.colNgayGD.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNgayGD.Name = "colNgayGD";
            this.colNgayGD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "NgayGD", "{0:#,##0;(#,##0)}")});
            this.colNgayGD.Visible = true;
            this.colNgayGD.VisibleIndex = 0;
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
            this.colSoTien.VisibleIndex = 5;
            this.colSoTien.Width = 108;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Nội dung";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 7;
            this.colGhiChu.Width = 361;
            // 
            // colTrangThaiID
            // 
            this.colTrangThaiID.Caption = "TT";
            this.colTrangThaiID.FieldName = "TrangThaiID";
            this.colTrangThaiID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTrangThaiID.Name = "colTrangThaiID";
            this.colTrangThaiID.Visible = true;
            this.colTrangThaiID.VisibleIndex = 6;
            this.colTrangThaiID.Width = 29;
            // 
            // colNgayHT
            // 
            this.colNgayHT.Caption = "Ngày HT";
            this.colNgayHT.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayHT.FieldName = "NgayHT";
            this.colNgayHT.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNgayHT.Name = "colNgayHT";
            this.colNgayHT.Visible = true;
            this.colNgayHT.VisibleIndex = 1;
            this.colNgayHT.Width = 81;
            // 
            // colNVGiaoDich
            // 
            this.colNVGiaoDich.Caption = "Nguồn tới/từ";
            this.colNVGiaoDich.ColumnEdit = this.rKhachHang;
            this.colNVGiaoDich.FieldName = "MaDL";
            this.colNVGiaoDich.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNVGiaoDich.Name = "colNVGiaoDich";
            this.colNVGiaoDich.Visible = true;
            this.colNVGiaoDich.VisibleIndex = 3;
            // 
            // rKhachHang
            // 
            this.rKhachHang.AutoHeight = false;
            this.rKhachHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rKhachHang.DataSource = this.DataTen;
            this.rKhachHang.DisplayMember = "Name";
            this.rKhachHang.Name = "rKhachHang";
            this.rKhachHang.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.rKhachHang.ValueMember = "ID";
            // 
            // DataTen
            // 
            this.DataTen.DataSource = typeof(CRM.IntString);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colName2});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Tên";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colName2
            // 
            this.colName2.Caption = "Mã";
            this.colName2.FieldName = "Name2";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 0;
            // 
            // colLoaiGiaoDich
            // 
            this.colLoaiGiaoDich.Caption = "Hình thức";
            this.colLoaiGiaoDich.ColumnEdit = this.rHinhThuc;
            this.colLoaiGiaoDich.FieldName = "LoaiGiaoDich";
            this.colLoaiGiaoDich.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLoaiGiaoDich.Name = "colLoaiGiaoDich";
            this.colLoaiGiaoDich.Visible = true;
            this.colLoaiGiaoDich.VisibleIndex = 4;
            this.colLoaiGiaoDich.Width = 94;
            // 
            // rHinhThuc
            // 
            this.rHinhThuc.AutoHeight = false;
            this.rHinhThuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rHinhThuc.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rHinhThuc.DataSource = this.DataHinhThuc;
            this.rHinhThuc.DisplayMember = "Name";
            this.rHinhThuc.Name = "rHinhThuc";
            this.rHinhThuc.NullText = "-";
            this.rHinhThuc.ValueMember = "ID";
            // 
            // colLoaiKhachHang
            // 
            this.colLoaiKhachHang.Caption = "Đối tác";
            this.colLoaiKhachHang.ColumnEdit = this.rLoaiKhachHang;
            this.colLoaiKhachHang.FieldName = "LoaiKhachHang";
            this.colLoaiKhachHang.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLoaiKhachHang.Name = "colLoaiKhachHang";
            this.colLoaiKhachHang.Visible = true;
            this.colLoaiKhachHang.VisibleIndex = 2;
            // 
            // rLoaiKhachHang
            // 
            this.rLoaiKhachHang.AutoHeight = false;
            this.rLoaiKhachHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLoaiKhachHang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rLoaiKhachHang.DataSource = this.DataLoaiKhach;
            this.rLoaiKhachHang.DisplayMember = "Name";
            this.rLoaiKhachHang.Name = "rLoaiKhachHang";
            this.rLoaiKhachHang.ValueMember = "ID";
            // 
            // DataLoaiKhach
            // 
            this.DataLoaiKhach.DataSource = typeof(CRM.IntString);
            // 
            // frmAutoNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 578);
            this.Controls.Add(this.GCCTNH);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAutoNganHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dữ liệu ngân hàng [Auto]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAutoNganHang_FormClosing);
            this.Load += new System.EventHandler(this.frmAutoNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nganHangOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNgay.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTNganHangOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCCTNH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCTNH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoaiKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataLoaiKhach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarEditItem eNganHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rNganHang;
        private DevExpress.XtraBars.BarEditItem eNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rNgay;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lblSD1;
        private DevExpress.XtraBars.BarStaticItem lblSD2;
        private DevExpress.XtraBars.BarStaticItem lblSD3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource nganHangOBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnLoad;
        private System.Windows.Forms.BindingSource cTNganHangOBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnCH;
        private DevExpress.XtraBars.BarButtonItem btnLo;
        private DevExpress.XtraBars.BarButtonItem btnBC;
        private DevExpress.XtraBars.BarButtonItem btnLBC;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
        private DevExpress.XtraBars.PopupMenu pMenu;
        private System.Windows.Forms.BindingSource DataHinhThuc;
        private DevExpress.XtraGrid.GridControl GCCTNH;
        private DevExpress.XtraGrid.Views.Grid.GridView GVCTNH;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayGD;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiID;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayHT;
        private DevExpress.XtraGrid.Columns.GridColumn colNVGiaoDich;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiGiaoDich;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rHinhThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiKhachHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLoaiKhachHang;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private System.Windows.Forms.BindingSource DataLoaiKhach;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rKhachHang;
        private System.Windows.Forms.BindingSource DataTen;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
    }
}