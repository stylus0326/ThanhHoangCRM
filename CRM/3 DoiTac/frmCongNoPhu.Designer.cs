namespace CRM
{
    partial class frmCongNoPhu
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
            this.giaoDichOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tuyenBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GCCN = new DevExpress.XtraGrid.GridControl();
            this.GVCN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLoaiGiaoDich = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rTuyenBay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaHoan1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhiCoDinh1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loaiGiaoDichOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaoDichOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyenBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoaiGiaoDich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTuyenBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiGiaoDichOBindingSource)).BeginInit();
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
            // giaoDichOBindingSource
            // 
            this.giaoDichOBindingSource.DataSource = typeof(DataTransferObject.O_GIAODICH);
            // 
            // tuyenBayOBindingSource
            // 
            this.tuyenBayOBindingSource.DataSource = typeof(DataTransferObject.O_TUYENBAY);
            // 
            // GCCN
            // 
            this.GCCN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GCCN.DataSource = this.giaoDichOBindingSource;
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
            // GVCN
            // 
            this.GVCN.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GVCN.Appearance.FooterPanel.Options.UseFont = true;
            this.GVCN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GVCN.Appearance.HeaderPanel.Options.UseFont = true;
            this.GVCN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn20,
            this.gridColumn3,
            this.colAgent,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.colGiaHoan1,
            this.colPhiCoDinh1});
            this.GVCN.GridControl = this.GCCN;
            this.GVCN.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaThu", this.gridColumn17, "{0:#,##0;(#,##0)}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TaiKhoanCo", this.gridColumn19, "{0:#,##0;(#,##0)}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhiCK", this.gridColumn15, "{0:#,##0;(#,##0)}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaHeThong", this.gridColumn14, "{0:#,##0;(#,##0)}")});
            this.GVCN.Name = "GVCN";
            this.GVCN.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.GVCN.OptionsBehavior.ReadOnly = true;
            this.GVCN.OptionsPrint.PrintFilterInfo = true;
            this.GVCN.OptionsPrint.PrintFooter = false;
            this.GVCN.OptionsPrint.PrintGroupFooter = false;
            this.GVCN.OptionsPrint.PrintHorzLines = false;
            this.GVCN.OptionsPrint.PrintVertLines = false;
            this.GVCN.OptionsView.ColumnAutoWidth = false;
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
            // gridColumn20
            // 
            this.gridColumn20.Caption = "#";
            this.gridColumn20.ColumnEdit = this.rLoaiGiaoDich;
            this.gridColumn20.FieldName = "LoaiGiaoDich";
            this.gridColumn20.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            this.gridColumn20.Width = 71;
            // 
            // rLoaiGiaoDich
            // 
            this.rLoaiGiaoDich.AutoHeight = false;
            this.rLoaiGiaoDich.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLoaiGiaoDich.DataSource = this.loaiGiaoDichOBindingSource;
            this.rLoaiGiaoDich.DisplayMember = "Name";
            this.rLoaiGiaoDich.Name = "rLoaiGiaoDich";
            this.rLoaiGiaoDich.ValueMember = "IDGiaoDich";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nội dung";
            this.gridColumn3.FieldName = "TenKhach";
            this.gridColumn3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TenKhach", "TỔNG CỘNG:")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 240;
            // 
            // colAgent
            // 
            this.colAgent.Caption = "Sign In";
            this.colAgent.FieldName = "Agent";
            this.colAgent.Name = "colAgent";
            this.colAgent.Visible = true;
            this.colAgent.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã chỗ";
            this.gridColumn4.FieldName = "MaCho";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Hãng";
            this.gridColumn5.FieldName = "Hang";
            this.gridColumn5.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 39;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số Vé";
            this.gridColumn6.FieldName = "SoVeVN";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Loại Vé";
            this.gridColumn7.FieldName = "LoaiVe";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Hành Trình Đi";
            this.gridColumn8.ColumnEdit = this.rTuyenBay;
            this.gridColumn8.FieldName = "TuyenBayDi";
            this.gridColumn8.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // rTuyenBay
            // 
            this.rTuyenBay.AutoHeight = false;
            this.rTuyenBay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rTuyenBay.DataSource = this.tuyenBayOBindingSource;
            this.rTuyenBay.DisplayMember = "Ten";
            this.rTuyenBay.Name = "rTuyenBay";
            this.rTuyenBay.ValueMember = "ID";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Hành Trình Về";
            this.gridColumn11.ColumnEdit = this.rTuyenBay;
            this.gridColumn11.FieldName = "TuyenBayVe";
            this.gridColumn11.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Giá Hệ Thống/Phí hoàn";
            this.gridColumn14.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "GiaHeThong";
            this.gridColumn14.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaHeThong", "{0:#,##0;(#,##0)}")});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 10;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Chiết Khấu";
            this.gridColumn15.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "PhiCK";
            this.gridColumn15.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhiCK", "{0:#,##0;(#,##0)}")});
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Hoa Hồng";
            this.gridColumn16.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "HoaHong";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HoaHong", "{0:#,##0;(#,##0)}")});
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 13;
            this.gridColumn16.Width = 27;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Giá Thu";
            this.gridColumn17.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "GiaThu";
            this.gridColumn17.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaThu", "{0:#,##0;(#,##0)}")});
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 14;
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
            this.gridColumn18.VisibleIndex = 15;
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
            this.gridColumn19.VisibleIndex = 16;
            this.gridColumn19.Width = 82;
            // 
            // colGiaHoan1
            // 
            this.colGiaHoan1.Caption = "Tiền Hoàn Vé";
            this.colGiaHoan1.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colGiaHoan1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGiaHoan1.FieldName = "GiaHoan";
            this.colGiaHoan1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colGiaHoan1.Name = "colGiaHoan1";
            this.colGiaHoan1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaHoan", "{0:#,##0;(#,##0)}")});
            this.colGiaHoan1.Visible = true;
            this.colGiaHoan1.VisibleIndex = 17;
            // 
            // colPhiCoDinh1
            // 
            this.colPhiCoDinh1.Caption = "Phí";
            this.colPhiCoDinh1.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colPhiCoDinh1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPhiCoDinh1.FieldName = "PhiCoDinh";
            this.colPhiCoDinh1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPhiCoDinh1.Name = "colPhiCoDinh1";
            this.colPhiCoDinh1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PhiCoDinh", "{0:#,##0;(#,##0)}")});
            this.colPhiCoDinh1.Visible = true;
            this.colPhiCoDinh1.VisibleIndex = 11;
            // 
            // loaiGiaoDichOBindingSource
            // 
            this.loaiGiaoDichOBindingSource.DataSource = typeof(DataTransferObject.O_LOAIGIAODICH);
            // 
            // frmCongNoPhu
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
            this.Name = "frmCongNoPhu";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công nợ";
            this.Load += new System.EventHandler(this.frmCongNoPhu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaoDichOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyenBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLoaiGiaoDich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTuyenBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiGiaoDichOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtp2;
        private DevExpress.XtraEditors.DateEdit dtp1;
        private System.Windows.Forms.BindingSource giaoDichOBindingSource;
        private System.Windows.Forms.BindingSource tuyenBayOBindingSource;
        private DevExpress.XtraGrid.GridControl GCCN;
        private DevExpress.XtraGrid.Views.Grid.GridView GVCN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLoaiGiaoDich;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colAgent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rTuyenBay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaHoan1;
        private DevExpress.XtraGrid.Columns.GridColumn colPhiCoDinh1;
        private System.Windows.Forms.BindingSource loaiGiaoDichOBindingSource;
    }
}