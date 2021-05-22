namespace CRM
{
    partial class frmNo3Ngay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNo3Ngay));
            this.gridDaiLy = new DevExpress.XtraGrid.GridControl();
            this.daiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailKeToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuCuoi1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuCuoi2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuCuoi3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaKhỏiDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnn = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDaiLy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDaiLy
            // 
            this.gridDaiLy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDaiLy.DataSource = this.daiLyOBindingSource;
            this.gridDaiLy.Location = new System.Drawing.Point(12, 12);
            this.gridDaiLy.MainView = this.gridView1;
            this.gridDaiLy.Name = "gridDaiLy";
            this.gridDaiLy.Size = new System.Drawing.Size(780, 392);
            this.gridDaiLy.TabIndex = 1;
            this.gridDaiLy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.O_DAILY);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colTen,
            this.colDiDong,
            this.colEmailKeToan,
            this.colSoDuCuoi1,
            this.colSoDuCuoi2,
            this.colSoDuCuoi3,
            this.colTienPhat});
            this.gridView1.GridControl = this.gridDaiLy;
            this.gridView1.IndicatorWidth = 25;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên Đại Lý";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ten", "({0:#,##0;(#,##0)} dòng)")});
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 0;
            this.colTen.Width = 127;
            // 
            // colDiDong
            // 
            this.colDiDong.Caption = "Di Động";
            this.colDiDong.FieldName = "DiDong";
            this.colDiDong.Name = "colDiDong";
            this.colDiDong.Visible = true;
            this.colDiDong.VisibleIndex = 1;
            this.colDiDong.Width = 100;
            // 
            // colEmailKeToan
            // 
            this.colEmailKeToan.Caption = "Email Kế Toán";
            this.colEmailKeToan.FieldName = "EmailKeToan";
            this.colEmailKeToan.Name = "colEmailKeToan";
            this.colEmailKeToan.Visible = true;
            this.colEmailKeToan.VisibleIndex = 2;
            this.colEmailKeToan.Width = 118;
            // 
            // colSoDuCuoi1
            // 
            this.colSoDuCuoi1.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuCuoi1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuCuoi1.FieldName = "SoDuCuoi1";
            this.colSoDuCuoi1.Name = "colSoDuCuoi1";
            this.colSoDuCuoi1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoDuCuoi1", "{0:#,##0;(#,##0)}")});
            this.colSoDuCuoi1.Visible = true;
            this.colSoDuCuoi1.VisibleIndex = 3;
            // 
            // colSoDuCuoi2
            // 
            this.colSoDuCuoi2.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuCuoi2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuCuoi2.FieldName = "SoDuCuoi2";
            this.colSoDuCuoi2.Name = "colSoDuCuoi2";
            this.colSoDuCuoi2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoDuCuoi2", "{0:#,##0;(#,##0)}")});
            this.colSoDuCuoi2.Visible = true;
            this.colSoDuCuoi2.VisibleIndex = 4;
            // 
            // colSoDuCuoi3
            // 
            this.colSoDuCuoi3.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuCuoi3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuCuoi3.FieldName = "SoDuCuoi3";
            this.colSoDuCuoi3.Name = "colSoDuCuoi3";
            this.colSoDuCuoi3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoDuCuoi3", "{0:#,##0;(#,##0)}")});
            this.colSoDuCuoi3.Visible = true;
            this.colSoDuCuoi3.VisibleIndex = 5;
            // 
            // colTienPhat
            // 
            this.colTienPhat.Caption = "Phạt âm quỹ";
            this.colTienPhat.DisplayFormat.FormatString = "{0:#,##0.#;(#,##0.#)}";
            this.colTienPhat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTienPhat.FieldName = "TienPhat";
            this.colTienPhat.Name = "colTienPhat";
            this.colTienPhat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienPhat", "{0:#,##0.#;(#,##0.#)}")});
            this.colTienPhat.Visible = true;
            this.colTienPhat.VisibleIndex = 6;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaKhỏiDanhSáchToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(178, 26);
            // 
            // xóaKhỏiDanhSáchToolStripMenuItem
            // 
            this.xóaKhỏiDanhSáchToolStripMenuItem.Name = "xóaKhỏiDanhSáchToolStripMenuItem";
            this.xóaKhỏiDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.xóaKhỏiDanhSáchToolStripMenuItem.Text = "Xóa khỏi danh sách";
            this.xóaKhỏiDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.xóaKhỏiDanhSáchToolStripMenuItem_Click);
            // 
            // btnn
            // 
            this.btnn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnn.Enabled = false;
            this.btnn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnn.ImageOptions.SvgImage")));
            this.btnn.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnn.Location = new System.Drawing.Point(710, 414);
            this.btnn.Name = "btnn";
            this.btnn.Size = new System.Drawing.Size(82, 27);
            this.btnn.TabIndex = 3;
            this.btnn.Text = "Chốt nợ";
            this.btnn.Click += new System.EventHandler(this.btnn_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(79, 418);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(123, 20);
            this.dateEdit1.TabIndex = 4;
            this.dateEdit1.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 421);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Cuối ngày:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.simpleButton1.Location = new System.Drawing.Point(208, 416);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(64, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.TabStop = false;
            this.simpleButton1.Text = "Tìm";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmNo3Ngay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 449);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.btnn);
            this.Controls.Add(this.gridDaiLy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNo3Ngay";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách Đại Lý Nợ 3 Ngày Liên Tiếp";
            this.Load += new System.EventHandler(this.frmNo3Ngay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDaiLy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDaiLy;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colDiDong;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailKeToan;
        private System.Windows.Forms.BindingSource daiLyOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuCuoi1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuCuoi2;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuCuoi3;
        private DevExpress.XtraGrid.Columns.GridColumn colTienPhat;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem xóaKhỏiDanhSáchToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnn;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}