namespace CRM
{
    partial class frmCongNoKS
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
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtp2 = new DevExpress.XtraEditors.DateEdit();
            this.dtp1 = new DevExpress.XtraEditors.DateEdit();
            this.GCCN = new DevExpress.XtraGrid.GridControl();
            this.khachSanOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVCN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBooking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienBaoLuu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLoaiGiaoDich = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rTuyenBay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachSanOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoaiGiaoDich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTuyenBay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(274, 3);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(44, 23);
            this.btnTim.TabIndex = 17;
            this.btnTim.Text = "Xem";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(138, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Đến:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(17, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Từ:";
            // 
            // dtp2
            // 
            this.dtp2.EditValue = null;
            this.dtp2.Location = new System.Drawing.Point(168, 5);
            this.dtp2.Name = "dtp2";
            this.dtp2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp2.Size = new System.Drawing.Size(100, 20);
            this.dtp2.TabIndex = 14;
            // 
            // dtp1
            // 
            this.dtp1.EditValue = null;
            this.dtp1.Location = new System.Drawing.Point(32, 5);
            this.dtp1.Name = "dtp1";
            this.dtp1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp1.Size = new System.Drawing.Size(100, 20);
            this.dtp1.TabIndex = 13;
            // 
            // GCCN
            // 
            this.GCCN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GCCN.DataSource = this.khachSanOBindingSource;
            gridLevelNode1.RelationName = "Level1";
            this.GCCN.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GCCN.Location = new System.Drawing.Point(0, 32);
            this.GCCN.MainView = this.GVCN;
            this.GCCN.Name = "GCCN";
            this.GCCN.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLoaiGiaoDich,
            this.rTuyenBay});
            this.GCCN.Size = new System.Drawing.Size(1021, 474);
            this.GCCN.TabIndex = 18;
            this.GCCN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVCN});
            // 
            // khachSanOBindingSource
            // 
            this.khachSanOBindingSource.DataSource = typeof(DataTransferObject.O_KHACHSAN);
            // 
            // GVCN
            // 
            this.GVCN.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GVCN.Appearance.FooterPanel.Options.UseFont = true;
            this.GVCN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GVCN.Appearance.HeaderPanel.Options.UseFont = true;
            this.GVCN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn14,
            this.gridColumn18,
            this.gridColumn19,
            this.colBooking,
            this.colSoTienBaoLuu,
            this.colGhiChu});
            this.GVCN.GridControl = this.GCCN;
            this.GVCN.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaThu", null, "{0:#,##0;(#,##0)}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TaiKhoanCo", this.gridColumn19, "{0:#,##0;(#,##0)}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhiCK", null, "{0:#,##0;(#,##0)}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaHeThong", this.gridColumn14, "{0:#,##0;(#,##0)}")});
            this.GVCN.Name = "GVCN";
            this.GVCN.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.GVCN.OptionsBehavior.ReadOnly = true;
            this.GVCN.OptionsPrint.PrintFilterInfo = true;
            this.GVCN.OptionsPrint.PrintFooter = false;
            this.GVCN.OptionsPrint.PrintGroupFooter = false;
            this.GVCN.OptionsPrint.PrintHorzLines = false;
            this.GVCN.OptionsPrint.PrintVertLines = false;
            this.GVCN.OptionsView.ShowAutoFilterRow = true;
            this.GVCN.OptionsView.ShowFooter = true;
            this.GVCN.OptionsView.ShowGroupPanel = false;
            this.GVCN.RowHeight = 25;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày";
            this.gridColumn2.DisplayFormat.FormatString = "d/M/yy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "NgayGD";
            this.gridColumn2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã GD";
            this.gridColumn4.FieldName = "MaCho";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Giá Hệ Thống";
            this.gridColumn14.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "GiaNet";
            this.gridColumn14.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaHeThong", "{0:#,##0;(#,##0)}")});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 109;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Lũy Kế";
            this.gridColumn18.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "LuyKe";
            this.gridColumn18.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 5;
            this.gridColumn18.Width = 123;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Tài Khoản Có";
            this.gridColumn19.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "TaiKhoanCo";
            this.gridColumn19.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TaiKhoanCo", "{0:#,##0;(#,##0)}")});
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 6;
            this.gridColumn19.Width = 107;
            // 
            // colBooking
            // 
            this.colBooking.Caption = "Mã phòng";
            this.colBooking.FieldName = "Booking";
            this.colBooking.Name = "colBooking";
            this.colBooking.Visible = true;
            this.colBooking.VisibleIndex = 2;
            // 
            // colSoTienBaoLuu
            // 
            this.colSoTienBaoLuu.Caption = "Tiền bảo lưu";
            this.colSoTienBaoLuu.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoTienBaoLuu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTienBaoLuu.FieldName = "SoTienBaoLuu";
            this.colSoTienBaoLuu.Name = "colSoTienBaoLuu";
            this.colSoTienBaoLuu.Visible = true;
            this.colSoTienBaoLuu.VisibleIndex = 7;
            this.colSoTienBaoLuu.Width = 99;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Nội dung";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 3;
            this.colGhiChu.Width = 217;
            // 
            // rLoaiGiaoDich
            // 
            this.rLoaiGiaoDich.AutoHeight = false;
            this.rLoaiGiaoDich.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLoaiGiaoDich.DisplayMember = "Name";
            this.rLoaiGiaoDich.Name = "rLoaiGiaoDich";
            this.rLoaiGiaoDich.ValueMember = "IDGiaoDich";
            // 
            // rTuyenBay
            // 
            this.rTuyenBay.AutoHeight = false;
            this.rTuyenBay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rTuyenBay.DisplayMember = "Ten";
            this.rTuyenBay.Name = "rTuyenBay";
            this.rTuyenBay.ValueMember = "ID";
            // 
            // frmCongNoKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 505);
            this.Controls.Add(this.GCCN);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCongNoKS";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công nợ";
            this.Load += new System.EventHandler(this.frmCongNoKS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachSanOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoaiGiaoDich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTuyenBay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtp2;
        private DevExpress.XtraEditors.DateEdit dtp1;
        private DevExpress.XtraGrid.GridControl GCCN;
        private DevExpress.XtraGrid.Views.Grid.GridView GVCN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLoaiGiaoDich;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rTuyenBay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private System.Windows.Forms.BindingSource khachSanOBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBooking;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienBaoLuu;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
    }
}