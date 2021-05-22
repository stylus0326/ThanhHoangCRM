namespace CRM
{
    partial class frmThongKeDoanhSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeDoanhSo));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bcmbThoiGian = new DevExpress.XtraBars.BarEditItem();
            this.ecmbThoiGian = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bdtpTu = new DevExpress.XtraBars.BarEditItem();
            this.edtpTu = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bdtpDen = new DevExpress.XtraBars.BarEditItem();
            this.edtpDen = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem3 = new DevExpress.XtraBars.BarCheckItem();
            this.chk = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GCTK = new DevExpress.XtraGrid.GridControl();
            this.GVTK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.Gb1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSale = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rKhachHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.daiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colDaiLy = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.rNhaCungCap = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.nCCOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecmbThoiGian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpTu.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpDen.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCOBindingSource)).BeginInit();
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
            this.bdtpTu,
            this.bdtpDen,
            this.bcmbThoiGian,
            this.barStaticItem1,
            this.barStaticItem2,
            this.chk,
            this.barButtonItem1,
            this.barCheckItem1,
            this.barHeaderItem1,
            this.barCheckItem2,
            this.barCheckItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 16;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edtpTu,
            this.edtpDen,
            this.ecmbThoiGian});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.bcmbThoiGian, "", false, true, true, 75, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.bdtpTu, "", true, true, true, 98, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.bdtpDen, "", false, true, true, 105, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barCheckItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barCheckItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.chk, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barCheckItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bcmbThoiGian
            // 
            this.bcmbThoiGian.Caption = "Xem theo";
            this.bcmbThoiGian.Edit = this.ecmbThoiGian;
            this.bcmbThoiGian.EditValue = "Tháng";
            this.bcmbThoiGian.Id = 3;
            this.bcmbThoiGian.Name = "bcmbThoiGian";
            // 
            // ecmbThoiGian
            // 
            this.ecmbThoiGian.AutoHeight = false;
            this.ecmbThoiGian.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ecmbThoiGian.Items.AddRange(new object[] {
            "Năm",
            "Quý",
            "Tháng",
            "Tuần"});
            this.ecmbThoiGian.Name = "ecmbThoiGian";
            this.ecmbThoiGian.SelectedIndexChanged += new System.EventHandler(this.ecmbThoiGian_SelectedIndexChanged);
            // 
            // bdtpTu
            // 
            this.bdtpTu.Caption = "Lấy dữ liệu từ";
            this.bdtpTu.Edit = this.edtpTu;
            this.bdtpTu.Id = 0;
            this.bdtpTu.Name = "bdtpTu";
            // 
            // edtpTu
            // 
            this.edtpTu.AutoHeight = false;
            this.edtpTu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtpTu.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtpTu.Name = "edtpTu";
            // 
            // bdtpDen
            // 
            this.bdtpDen.Caption = "đến";
            this.bdtpDen.Edit = this.edtpDen;
            this.bdtpDen.Id = 1;
            this.bdtpDen.Name = "bdtpDen";
            // 
            // edtpDen
            // 
            this.edtpDen.AutoHeight = false;
            this.edtpDen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtpDen.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtpDen.Name = "edtpDen";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Tính tổng theo:";
            this.barHeaderItem1.Id = 12;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "Đại lý";
            this.barCheckItem2.GroupIndex = 1;
            this.barCheckItem2.Id = 13;
            this.barCheckItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barCheckItem2.ImageOptions.SvgImage")));
            this.barCheckItem2.Name = "barCheckItem2";
            this.barCheckItem2.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            // 
            // barCheckItem3
            // 
            this.barCheckItem3.BindableChecked = true;
            this.barCheckItem3.Caption = "Mặc định";
            this.barCheckItem3.Checked = true;
            this.barCheckItem3.GroupIndex = 1;
            this.barCheckItem3.Id = 15;
            this.barCheckItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barCheckItem3.ImageOptions.SvgImage")));
            this.barCheckItem3.Name = "barCheckItem3";
            this.barCheckItem3.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            // 
            // chk
            // 
            this.chk.Caption = "Tắt màu";
            this.chk.Id = 7;
            this.chk.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("chk.ImageOptions.SvgImage")));
            this.chk.Name = "chk";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "Excel";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "Hoàn";
            this.barCheckItem1.Id = 10;
            this.barCheckItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barCheckItem1.ImageOptions.SvgImage")));
            this.barCheckItem1.Name = "barCheckItem1";
            this.barCheckItem1.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Nhỏ hơn doanh số trung bình cộng";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.ItemAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.barStaticItem1.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.barStaticItem1.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.barStaticItem1.ItemAppearance.Normal.Options.UseBackColor = true;
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Lớn hơn doanh số trung bình cộng";
            this.barStaticItem2.Id = 5;
            this.barStaticItem2.ItemAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(172)))), ((int)(((byte)(65)))));
            this.barStaticItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem2.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.barStaticItem2.ItemAppearance.Normal.Options.UseBackColor = true;
            this.barStaticItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem2.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(989, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 608);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(989, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 584);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(989, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 584);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GCTK);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(989, 584);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Danh sách";
            // 
            // GCTK
            // 
            this.GCTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCTK.Location = new System.Drawing.Point(2, 23);
            this.GCTK.MainView = this.GVTK;
            this.GCTK.MenuManager = this.barManager1;
            this.GCTK.Name = "GCTK";
            this.GCTK.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rKhachHang,
            this.rNhaCungCap});
            this.GCTK.Size = new System.Drawing.Size(985, 559);
            this.GCTK.TabIndex = 0;
            this.GCTK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVTK});
            // 
            // GVTK
            // 
            this.GVTK.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.Gb1});
            this.GVTK.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSale,
            this.colDaiLy,
            this.colHang});
            this.GVTK.GridControl = this.GCTK;
            this.GVTK.Name = "GVTK";
            this.GVTK.OptionsBehavior.ReadOnly = true;
            this.GVTK.OptionsView.AllowCellMerge = true;
            this.GVTK.OptionsView.ColumnAutoWidth = false;
            this.GVTK.OptionsView.ShowAutoFilterRow = true;
            this.GVTK.OptionsView.ShowFooter = true;
            this.GVTK.OptionsView.ShowGroupPanel = false;
            this.GVTK.RowHeight = 25;
            this.GVTK.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.bandedGridView1_CellMerge);
            this.GVTK.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bandedGridView1_RowCellStyle);
            this.GVTK.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.bandedGridView1_CustomColumnDisplayText);
            // 
            // Gb1
            // 
            this.Gb1.Caption = "Thông tin";
            this.Gb1.Columns.Add(this.colSale);
            this.Gb1.Columns.Add(this.colDaiLy);
            this.Gb1.Columns.Add(this.colHang);
            this.Gb1.Name = "Gb1";
            this.Gb1.VisibleIndex = 0;
            this.Gb1.Width = 225;
            // 
            // colSale
            // 
            this.colSale.Caption = "Sales";
            this.colSale.ColumnEdit = this.rKhachHang;
            this.colSale.FieldName = "NVGiaoDich";
            this.colSale.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colSale.Name = "colSale";
            this.colSale.Visible = true;
            // 
            // rKhachHang
            // 
            this.rKhachHang.AutoHeight = false;
            this.rKhachHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rKhachHang.DataSource = this.daiLyOBindingSource;
            this.rKhachHang.DisplayMember = "Ten";
            this.rKhachHang.Name = "rKhachHang";
            this.rKhachHang.NullText = "-";
            this.rKhachHang.ValueMember = "ID";
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.O_DAILY);
            // 
            // colDaiLy
            // 
            this.colDaiLy.Caption = "Đại lý";
            this.colDaiLy.ColumnEdit = this.rKhachHang;
            this.colDaiLy.FieldName = "IDKhachHang";
            this.colDaiLy.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDaiLy.Name = "colDaiLy";
            this.colDaiLy.Visible = true;
            // 
            // colHang
            // 
            this.colHang.Caption = "Hãng";
            this.colHang.ColumnEdit = this.rNhaCungCap;
            this.colHang.FieldName = "NhaCungCap";
            this.colHang.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colHang.Name = "colHang";
            this.colHang.Visible = true;
            // 
            // rNhaCungCap
            // 
            this.rNhaCungCap.AutoHeight = false;
            this.rNhaCungCap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rNhaCungCap.DataSource = this.nCCOBindingSource;
            this.rNhaCungCap.DisplayMember = "TenDayDu";
            this.rNhaCungCap.Name = "rNhaCungCap";
            this.rNhaCungCap.ValueMember = "ID";
            // 
            // nCCOBindingSource
            // 
            this.nCCOBindingSource.DataSource = typeof(DataTransferObject.O_NHACUNGCAP);
            // 
            // frmThongKeDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 630);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmThongKeDoanhSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh số";
            this.Load += new System.EventHandler(this.frmThongKeDoanhSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ecmbThoiGian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpTu.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpDen.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtpDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCCOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem bcmbThoiGian;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ecmbThoiGian;
        private DevExpress.XtraBars.BarEditItem bdtpTu;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit edtpTu;
        private DevExpress.XtraBars.BarEditItem bdtpDen;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit edtpDen;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GCTK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView GVTK;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Gb1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSale;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDaiLy;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rKhachHang;
        private System.Windows.Forms.BindingSource daiLyOBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rNhaCungCap;
        private System.Windows.Forms.BindingSource nCCOBindingSource;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarCheckItem chk;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.BarCheckItem barCheckItem3;
    }
}