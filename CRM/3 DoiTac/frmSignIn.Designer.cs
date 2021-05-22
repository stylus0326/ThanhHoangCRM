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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signInOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueHangBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDaiLy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
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
            this.btnThem,
            this.btnXoa});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTaiLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 4;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(554, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 540);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(554, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(554, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 516);
            // 
            // GCSI
            // 
            this.GCSI.DataSource = this.signInOBindingSource;
            this.GCSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSI.Location = new System.Drawing.Point(0, 24);
            this.GCSI.MainView = this.GVSI;
            this.GCSI.Name = "GCSI";
            this.GCSI.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueHangBay,
            this.lueDaiLy});
            this.GCSI.Size = new System.Drawing.Size(554, 516);
            this.GCSI.TabIndex = 4;
            this.GCSI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVSI});
            // 
            // signInOBindingSource
            // 
            this.signInOBindingSource.DataSource = typeof(DataTransferObject.SignInO);
            // 
            // GVSI
            // 
            this.GVSI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSignIn,
            this.colHangTT,
            this.colChinh,
            this.colDaiLyTT,
            this.colKhoa,
            this.colMatKhau});
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
            this.colSignIn.VisibleIndex = 2;
            this.colSignIn.Width = 124;
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
            this.colHangTT.VisibleIndex = 1;
            this.colHangTT.Width = 58;
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
            this.hangBayOBindingSource.DataSource = typeof(DataTransferObject.HangBayO);
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
            this.colChinh.Width = 33;
            // 
            // colDaiLyTT
            // 
            this.colDaiLyTT.Caption = "Đại lý";
            this.colDaiLyTT.ColumnEdit = this.lueDaiLy;
            this.colDaiLyTT.FieldName = "DaiLy";
            this.colDaiLyTT.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDaiLyTT.Name = "colDaiLyTT";
            this.colDaiLyTT.Visible = true;
            this.colDaiLyTT.VisibleIndex = 0;
            this.colDaiLyTT.Width = 145;
            // 
            // lueDaiLy
            // 
            this.lueDaiLy.AutoHeight = false;
            this.lueDaiLy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDaiLy.DataSource = this.daiLyOBindingSource;
            this.lueDaiLy.DisplayMember = "Ten";
            this.lueDaiLy.Name = "lueDaiLy";
            this.lueDaiLy.ValueMember = "ID";
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.DaiLyO);
            // 
            // colKhoa
            // 
            this.colKhoa.Caption = "Khóa";
            this.colKhoa.FieldName = "Khoa";
            this.colKhoa.Name = "colKhoa";
            this.colKhoa.Visible = true;
            this.colKhoa.VisibleIndex = 5;
            this.colKhoa.Width = 41;
            // 
            // colMatKhau
            // 
            this.colMatKhau.Caption = "Mật khẩu tạm khóa";
            this.colMatKhau.FieldName = "MatKhau";
            this.colMatKhau.Name = "colMatKhau";
            this.colMatKhau.Visible = true;
            this.colMatKhau.VisibleIndex = 3;
            this.colMatKhau.Width = 128;
            // 
            // frmSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 540);
            this.Controls.Add(this.GCSI);
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
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn colMatKhau;
    }
}