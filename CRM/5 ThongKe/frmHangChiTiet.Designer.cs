namespace CRM
{
    partial class frmHangChiTiet
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.GCHBSD = new DevExpress.XtraGrid.GridControl();
            this.soDuHangOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVHBSD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTienVe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNopQuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncentive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhiHoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHangThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuThucTe = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GCHBSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soDuHangOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVHBSD)).BeginInit();
            this.SuspendLayout();
            // 
            // GCHBSD
            // 
            this.GCHBSD.DataSource = this.soDuHangOBindingSource;
            this.GCHBSD.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.GCHBSD.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GCHBSD.Location = new System.Drawing.Point(0, 0);
            this.GCHBSD.MainView = this.GVHBSD;
            this.GCHBSD.Name = "GCHBSD";
            this.GCHBSD.Size = new System.Drawing.Size(930, 522);
            this.GCHBSD.TabIndex = 13;
            this.GCHBSD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVHBSD});
            // 
            // soDuHangOBindingSource
            // 
            this.soDuHangOBindingSource.DataSource = typeof(DataTransferObject.SoDu_HangO);
            // 
            // GVHBSD
            // 
            this.GVHBSD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTienVe,
            this.colHoan,
            this.colNopQuy,
            this.colIncentive,
            this.colNgay,
            this.colPhiHoan,
            this.colHangThu,
            this.colSoDuDau,
            this.colSoDuCuoi,
            this.colSoDuThucTe});
            this.GVHBSD.GridControl = this.GCHBSD;
            this.GVHBSD.Name = "GVHBSD";
            this.GVHBSD.OptionsView.ShowAutoFilterRow = true;
            this.GVHBSD.OptionsView.ShowFooter = true;
            this.GVHBSD.OptionsView.ShowGroupPanel = false;
            // 
            // colTienVe
            // 
            this.colTienVe.Caption = "Tiền vé";
            this.colTienVe.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colTienVe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTienVe.FieldName = "TienVe";
            this.colTienVe.Name = "colTienVe";
            this.colTienVe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienVe", "{0:#,##0;(#,##0)}")});
            this.colTienVe.Visible = true;
            this.colTienVe.VisibleIndex = 2;
            this.colTienVe.Width = 73;
            // 
            // colHoan
            // 
            this.colHoan.Caption = "Tiền hoàn";
            this.colHoan.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colHoan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHoan.FieldName = "Hoan";
            this.colHoan.Name = "colHoan";
            this.colHoan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Hoan", "{0:#,##0;(#,##0)}")});
            this.colHoan.Visible = true;
            this.colHoan.VisibleIndex = 3;
            // 
            // colNopQuy
            // 
            this.colNopQuy.Caption = "Nộp quỹ";
            this.colNopQuy.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colNopQuy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNopQuy.FieldName = "NopQuy";
            this.colNopQuy.Name = "colNopQuy";
            this.colNopQuy.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NopQuy", "{0:#,##0;(#,##0)}")});
            this.colNopQuy.Visible = true;
            this.colNopQuy.VisibleIndex = 5;
            this.colNopQuy.Width = 71;
            // 
            // colIncentive
            // 
            this.colIncentive.Caption = "Incentive";
            this.colIncentive.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colIncentive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncentive.FieldName = "Incentive";
            this.colIncentive.Name = "colIncentive";
            this.colIncentive.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Incentive", "{0:#,##0;(#,##0)}")});
            this.colIncentive.Visible = true;
            this.colIncentive.VisibleIndex = 6;
            this.colIncentive.Width = 77;
            // 
            // colNgay
            // 
            this.colNgay.Caption = "Ngày";
            this.colNgay.DisplayFormat.FormatString = "dd/MM/yy";
            this.colNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgay.FieldName = "Ngay";
            this.colNgay.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNgay.Name = "colNgay";
            this.colNgay.Visible = true;
            this.colNgay.VisibleIndex = 0;
            this.colNgay.Width = 58;
            // 
            // colPhiHoan
            // 
            this.colPhiHoan.Caption = "Phí hoàn";
            this.colPhiHoan.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colPhiHoan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPhiHoan.FieldName = "PhiHoan";
            this.colPhiHoan.Name = "colPhiHoan";
            this.colPhiHoan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhiHoan", "{0:#,##0;(#,##0)}")});
            this.colPhiHoan.Visible = true;
            this.colPhiHoan.VisibleIndex = 4;
            this.colPhiHoan.Width = 67;
            // 
            // colHangThu
            // 
            this.colHangThu.Caption = "Hãng thu";
            this.colHangThu.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colHangThu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHangThu.FieldName = "HangThu";
            this.colHangThu.Name = "colHangThu";
            this.colHangThu.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HangThu", "{0:#,##0;(#,##0)}")});
            this.colHangThu.Visible = true;
            this.colHangThu.VisibleIndex = 7;
            this.colHangThu.Width = 80;
            // 
            // colSoDuDau
            // 
            this.colSoDuDau.Caption = "Số dư đầu";
            this.colSoDuDau.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuDau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuDau.FieldName = "SoDuDau";
            this.colSoDuDau.Name = "colSoDuDau";
            this.colSoDuDau.Visible = true;
            this.colSoDuDau.VisibleIndex = 1;
            // 
            // colSoDuCuoi
            // 
            this.colSoDuCuoi.Caption = "Số dư cuối";
            this.colSoDuCuoi.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuCuoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuCuoi.FieldName = "SoDuCuoi";
            this.colSoDuCuoi.Name = "colSoDuCuoi";
            this.colSoDuCuoi.Visible = true;
            this.colSoDuCuoi.VisibleIndex = 8;
            // 
            // colSoDuThucTe
            // 
            this.colSoDuThucTe.Caption = "Số dư thực tế";
            this.colSoDuThucTe.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuThucTe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuThucTe.FieldName = "SoDuThucTe";
            this.colSoDuThucTe.Name = "colSoDuThucTe";
            this.colSoDuThucTe.Visible = true;
            this.colSoDuThucTe.VisibleIndex = 9;
            // 
            // frmHangChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 522);
            this.Controls.Add(this.GCHBSD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHangChiTiet";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hãng";
            this.Load += new System.EventHandler(this.frmHangChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCHBSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soDuHangOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVHBSD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCHBSD;
        private DevExpress.XtraGrid.Views.Grid.GridView GVHBSD;
        private DevExpress.XtraGrid.Columns.GridColumn colTienVe;
        private DevExpress.XtraGrid.Columns.GridColumn colHoan;
        private DevExpress.XtraGrid.Columns.GridColumn colNopQuy;
        private DevExpress.XtraGrid.Columns.GridColumn colIncentive;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colPhiHoan;
        private DevExpress.XtraGrid.Columns.GridColumn colHangThu;
        private System.Windows.Forms.BindingSource soDuHangOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuCuoi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuThucTe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuDau;
    }
}