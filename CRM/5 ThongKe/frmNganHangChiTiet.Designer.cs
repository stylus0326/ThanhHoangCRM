namespace CRM
{
    partial class frmNganHangChiTiet
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridCtNganHang = new DevExpress.XtraGrid.GridControl();
            this.cTNganHangOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grvCtNganHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiGiaoDich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rHinhThuc = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChuNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loaiGiaoDichOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTNganHangOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCtNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiGiaoDichOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridCtNganHang);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1074, 576);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "Danh sách giao dịch";
            // 
            // gridCtNganHang
            // 
            this.gridCtNganHang.DataSource = this.cTNganHangOBindingSource;
            this.gridCtNganHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtNganHang.Location = new System.Drawing.Point(2, 23);
            this.gridCtNganHang.MainView = this.grvCtNganHang;
            this.gridCtNganHang.Name = "gridCtNganHang";
            this.gridCtNganHang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rHinhThuc});
            this.gridCtNganHang.Size = new System.Drawing.Size(1070, 551);
            this.gridCtNganHang.TabIndex = 0;
            this.gridCtNganHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCtNganHang});
            // 
            // cTNganHangOBindingSource
            // 
            this.cTNganHangOBindingSource.DataSource = typeof(DataTransferObject.O_CTNGANHANG);
            // 
            // grvCtNganHang
            // 
            this.grvCtNganHang.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.grvCtNganHang.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCtNganHang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNgayGD,
            this.colMaCode,
            this.colSoTien,
            this.colGhiChu,
            this.colNgayHT,
            this.colLoaiGiaoDich,
            this.colTen,
            this.colGhiChuNV});
            this.grvCtNganHang.GridControl = this.gridCtNganHang;
            this.grvCtNganHang.IndicatorWidth = 50;
            this.grvCtNganHang.Name = "grvCtNganHang";
            this.grvCtNganHang.OptionsBehavior.ReadOnly = true;
            this.grvCtNganHang.OptionsView.EnableAppearanceEvenRow = true;
            this.grvCtNganHang.OptionsView.ShowAutoFilterRow = true;
            this.grvCtNganHang.OptionsView.ShowFooter = true;
            this.grvCtNganHang.OptionsView.ShowGroupPanel = false;
            this.grvCtNganHang.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTen, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            // colMaCode
            // 
            this.colMaCode.Caption = "Code";
            this.colMaCode.FieldName = "MaCode";
            this.colMaCode.Name = "colMaCode";
            this.colMaCode.Visible = true;
            this.colMaCode.VisibleIndex = 5;
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
            this.colSoTien.VisibleIndex = 3;
            this.colSoTien.Width = 108;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Nội dung";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 4;
            this.colGhiChu.Width = 361;
            // 
            // colNgayHT
            // 
            this.colNgayHT.Caption = "Ngày HT";
            this.colNgayHT.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayHT.FieldName = "NgayHT";
            this.colNgayHT.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNgayHT.Name = "colNgayHT";
            this.colNgayHT.Width = 81;
            // 
            // colLoaiGiaoDich
            // 
            this.colLoaiGiaoDich.Caption = "Hình thức";
            this.colLoaiGiaoDich.ColumnEdit = this.rHinhThuc;
            this.colLoaiGiaoDich.FieldName = "LoaiGiaoDich";
            this.colLoaiGiaoDich.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLoaiGiaoDich.Name = "colLoaiGiaoDich";
            this.colLoaiGiaoDich.Visible = true;
            this.colLoaiGiaoDich.VisibleIndex = 1;
            this.colLoaiGiaoDich.Width = 94;
            // 
            // rHinhThuc
            // 
            this.rHinhThuc.AutoHeight = false;
            this.rHinhThuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rHinhThuc.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rHinhThuc.DataSource = this.loaiGiaoDichOBindingSource;
            this.rHinhThuc.DisplayMember = "Name";
            this.rHinhThuc.Name = "rHinhThuc";
            this.rHinhThuc.NullText = "-";
            this.rHinhThuc.ValueMember = "ID";
            // 
            // colTen
            // 
            this.colTen.Caption = "Nguồn tới/từ";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 2;
            this.colTen.Width = 100;
            // 
            // colGhiChuNV
            // 
            this.colGhiChuNV.Caption = "Ghi chú";
            this.colGhiChuNV.FieldName = "GhiChuNV";
            this.colGhiChuNV.Name = "colGhiChuNV";
            this.colGhiChuNV.Width = 210;
            // 
            // loaiGiaoDichOBindingSource
            // 
            this.loaiGiaoDichOBindingSource.DataSource = typeof(DataTransferObject.O_LOAIGIAODICH);
            // 
            // frmNganHangChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 576);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmNganHangChiTiet";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết giao dịch ngân hàng";
            this.Load += new System.EventHandler(this.frmNganHangChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTNganHangOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCtNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiGiaoDichOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridCtNganHang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCtNganHang;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayGD;
        private DevExpress.XtraGrid.Columns.GridColumn colMaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayHT;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiGiaoDich;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rHinhThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChuNV;
        private System.Windows.Forms.BindingSource cTNganHangOBindingSource;
        private System.Windows.Forms.BindingSource loaiGiaoDichOBindingSource;
    }
}