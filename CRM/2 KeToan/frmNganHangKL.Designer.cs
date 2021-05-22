namespace CRM
{
    partial class frmNganHangKL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNganHangKL));
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GCDSC = new DevExpress.XtraGrid.GridControl();
            this.giaoDichOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVDSC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayGD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNganHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rNganHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.nganHangOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colMaCho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaHoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rKhachLe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.daiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colTenKhach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaHeThong = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCDSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaoDichOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nganHangOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKhachLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu.Location = new System.Drawing.Point(739, 436);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(63, 23);
            this.btnLuu.TabIndex = 104;
            this.btnLuu.TabStop = false;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GCDSC);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(797, 425);
            this.groupControl1.TabIndex = 102;
            this.groupControl1.Text = "Danh sách chờ";
            // 
            // GCDSC
            // 
            this.GCDSC.DataSource = this.giaoDichOBindingSource;
            this.GCDSC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCDSC.Location = new System.Drawing.Point(2, 23);
            this.GCDSC.MainView = this.GVDSC;
            this.GCDSC.Name = "GCDSC";
            this.GCDSC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rNganHang,
            this.rKhachLe});
            this.GCDSC.Size = new System.Drawing.Size(793, 400);
            this.GCDSC.TabIndex = 0;
            this.GCDSC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVDSC});
            // 
            // giaoDichOBindingSource
            // 
            this.giaoDichOBindingSource.DataSource = typeof(DataTransferObject.GiaoDichO);
            // 
            // GVDSC
            // 
            this.GVDSC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNgayGD1,
            this.colNganHang,
            this.colMaCho,
            this.colGiaThu,
            this.colGiaHoan,
            this.colIDKhachHang,
            this.colTenKhach,
            this.colGiaHeThong});
            this.GVDSC.GridControl = this.GCDSC;
            this.GVDSC.IndicatorWidth = 30;
            this.GVDSC.Name = "GVDSC";
            this.GVDSC.OptionsBehavior.ReadOnly = true;
            this.GVDSC.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.GVDSC.OptionsSelection.MultiSelect = true;
            this.GVDSC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.GVDSC.OptionsView.ColumnAutoWidth = false;
            this.GVDSC.OptionsView.ShowAutoFilterRow = true;
            this.GVDSC.OptionsView.ShowFooter = true;
            this.GVDSC.OptionsView.ShowGroupPanel = false;
            this.GVDSC.RowHeight = 25;
            this.GVDSC.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.GVDSC_CustomDrawFooterCell);
            this.GVDSC.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.GVDSC_SelectionChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 1;
            this.colID.Width = 52;
            // 
            // colNgayGD1
            // 
            this.colNgayGD1.Caption = "Ngày";
            this.colNgayGD1.DisplayFormat.FormatString = "dd/MM/yy";
            this.colNgayGD1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayGD1.FieldName = "NgayGD";
            this.colNgayGD1.Name = "colNgayGD1";
            this.colNgayGD1.Visible = true;
            this.colNgayGD1.VisibleIndex = 2;
            this.colNgayGD1.Width = 58;
            // 
            // colNganHang
            // 
            this.colNganHang.Caption = "Ngân hàng";
            this.colNganHang.ColumnEdit = this.rNganHang;
            this.colNganHang.FieldName = "NganHang";
            this.colNganHang.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNganHang.Name = "colNganHang";
            this.colNganHang.Visible = true;
            this.colNganHang.VisibleIndex = 4;
            // 
            // rNganHang
            // 
            this.rNganHang.AutoHeight = false;
            this.rNganHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rNganHang.DataSource = this.nganHangOBindingSource;
            this.rNganHang.DisplayMember = "Ten";
            this.rNganHang.Name = "rNganHang";
            this.rNganHang.ValueMember = "ID";
            // 
            // nganHangOBindingSource
            // 
            this.nganHangOBindingSource.DataSource = typeof(DataTransferObject.NganHangO);
            // 
            // colMaCho
            // 
            this.colMaCho.Caption = "Mã chỗ";
            this.colMaCho.FieldName = "MaCho";
            this.colMaCho.Name = "colMaCho";
            this.colMaCho.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.colMaCho.Visible = true;
            this.colMaCho.VisibleIndex = 5;
            this.colMaCho.Width = 59;
            // 
            // colGiaThu
            // 
            this.colGiaThu.Caption = "Giá thu";
            this.colGiaThu.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colGiaThu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGiaThu.FieldName = "GiaThu";
            this.colGiaThu.Name = "colGiaThu";
            this.colGiaThu.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.colGiaThu.Visible = true;
            this.colGiaThu.VisibleIndex = 6;
            // 
            // colGiaHoan
            // 
            this.colGiaHoan.Caption = "Giá Hoàn";
            this.colGiaHoan.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colGiaHoan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGiaHoan.FieldName = "GiaHoan";
            this.colGiaHoan.Name = "colGiaHoan";
            this.colGiaHoan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.colGiaHoan.Visible = true;
            this.colGiaHoan.VisibleIndex = 7;
            // 
            // colIDKhachHang
            // 
            this.colIDKhachHang.Caption = "Khách";
            this.colIDKhachHang.ColumnEdit = this.rKhachLe;
            this.colIDKhachHang.FieldName = "IDKhachHang";
            this.colIDKhachHang.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colIDKhachHang.Name = "colIDKhachHang";
            this.colIDKhachHang.Visible = true;
            this.colIDKhachHang.VisibleIndex = 3;
            // 
            // rKhachLe
            // 
            this.rKhachLe.AutoHeight = false;
            this.rKhachLe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rKhachLe.DataSource = this.daiLyOBindingSource;
            this.rKhachLe.DisplayMember = "Ten";
            this.rKhachLe.Name = "rKhachLe";
            this.rKhachLe.ValueMember = "ID";
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.DaiLyO);
            // 
            // colTenKhach
            // 
            this.colTenKhach.Caption = "Tên";
            this.colTenKhach.FieldName = "TenKhach";
            this.colTenKhach.Name = "colTenKhach";
            this.colTenKhach.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.colTenKhach.Visible = true;
            this.colTenKhach.VisibleIndex = 9;
            // 
            // colGiaHeThong
            // 
            this.colGiaHeThong.Caption = "Phí hoàn";
            this.colGiaHeThong.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colGiaHeThong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGiaHeThong.FieldName = "GiaHeThong";
            this.colGiaHeThong.Name = "colGiaHeThong";
            this.colGiaHeThong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.colGiaHeThong.Visible = true;
            this.colGiaHeThong.VisibleIndex = 8;
            // 
            // frmNganHangKL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 466);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNganHangKL";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao dịch chưa nhận";
            this.Load += new System.EventHandler(this.frmNganHangKL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCDSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaoDichOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nganHangOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKhachLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GCDSC;
        private System.Windows.Forms.BindingSource giaoDichOBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GVDSC;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayGD1;
        private DevExpress.XtraGrid.Columns.GridColumn colNganHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rNganHang;
        private System.Windows.Forms.BindingSource nganHangOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMaCho;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaThu;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaHoan;
        private DevExpress.XtraGrid.Columns.GridColumn colIDKhachHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rKhachLe;
        private System.Windows.Forms.BindingSource daiLyOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhach;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaHeThong;
    }
}