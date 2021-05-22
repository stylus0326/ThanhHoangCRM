namespace CRM
{
    partial class frmLSCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLSCS));
            this.chinhSachOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.iTN = new DevExpress.XtraEditors.DateEdit();
            this.iDN = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn = new DevExpress.XtraEditors.SimpleButton();
            this.iCS = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.GCLSCS = new DevExpress.XtraGrid.GridControl();
            this.soDuDaiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GVLSCS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChinhSachID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDuCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chinhSachOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTN.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDN.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCLSCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soDuDaiLyOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVLSCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // chinhSachOBindingSource
            // 
            this.chinhSachOBindingSource.DataSource = typeof(DataTransferObject.O_CHINHSACH);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(558, 536);
            this.panelControl1.TabIndex = 4;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.iTN);
            this.groupControl3.Controls.Add(this.iDN);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.btn);
            this.groupControl3.Controls.Add(this.iCS);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(2, 481);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(554, 53);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Sửa chính sách";
            // 
            // iTN
            // 
            this.iTN.EditValue = null;
            this.iTN.Location = new System.Drawing.Point(239, 23);
            this.iTN.Name = "iTN";
            this.iTN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iTN.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.iTN.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.iTN.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.iTN.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.iTN.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.iTN.Size = new System.Drawing.Size(100, 20);
            this.iTN.TabIndex = 13;
            // 
            // iDN
            // 
            this.iDN.EditValue = null;
            this.iDN.Location = new System.Drawing.Point(375, 23);
            this.iDN.Name = "iDN";
            this.iDN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iDN.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.iDN.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.iDN.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.iDN.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.iDN.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.iDN.Size = new System.Drawing.Size(100, 20);
            this.iDN.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(345, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Đến:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(216, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(17, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Từ:";
            // 
            // btn
            // 
            this.btn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn.Appearance.Options.UseFont = true;
            this.btn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn.ImageOptions.SvgImage")));
            this.btn.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btn.Location = new System.Drawing.Point(481, 21);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(63, 23);
            this.btn.TabIndex = 9;
            this.btn.Text = "Lưu";
            this.btn.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // iCS
            // 
            this.iCS.Location = new System.Drawing.Point(68, 23);
            this.iCS.Name = "iCS";
            this.iCS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iCS.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Ten", 28, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iCS.Properties.DataSource = this.chinhSachOBindingSource;
            this.iCS.Properties.DisplayMember = "Ten";
            this.iCS.Properties.DropDownRows = 10;
            this.iCS.Properties.NullText = "[Chọn chính sách...]";
            this.iCS.Properties.ValueMember = "ID";
            this.iCS.Size = new System.Drawing.Size(139, 20);
            this.iCS.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Chính sách:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.GCLSCS);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(554, 479);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Sửa chính sách";
            // 
            // GCLSCS
            // 
            this.GCLSCS.DataSource = this.soDuDaiLyOBindingSource;
            this.GCLSCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCLSCS.Location = new System.Drawing.Point(2, 23);
            this.GCLSCS.MainView = this.GVLSCS;
            this.GCLSCS.Name = "GCLSCS";
            this.GCLSCS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.GCLSCS.Size = new System.Drawing.Size(550, 454);
            this.GCLSCS.TabIndex = 9;
            this.GCLSCS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVLSCS});
            // 
            // soDuDaiLyOBindingSource
            // 
            this.soDuDaiLyOBindingSource.DataSource = typeof(DataTransferObject.O_SODU_DAILY);
            // 
            // GVLSCS
            // 
            this.GVLSCS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChinhSachID,
            this.colNgay,
            this.colSoDuCuoi});
            this.GVLSCS.GridControl = this.GCLSCS;
            this.GVLSCS.IndicatorWidth = 50;
            this.GVLSCS.Name = "GVLSCS";
            this.GVLSCS.OptionsBehavior.ReadOnly = true;
            this.GVLSCS.OptionsCustomization.AllowGroup = false;
            this.GVLSCS.OptionsView.ShowAutoFilterRow = true;
            this.GVLSCS.OptionsView.ShowFooter = true;
            this.GVLSCS.OptionsView.ShowGroupPanel = false;
            this.GVLSCS.RowHeight = 25;
            // 
            // colChinhSachID
            // 
            this.colChinhSachID.Caption = "Chính Sách";
            this.colChinhSachID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colChinhSachID.FieldName = "ChinhSachID";
            this.colChinhSachID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colChinhSachID.Name = "colChinhSachID";
            this.colChinhSachID.Visible = true;
            this.colChinhSachID.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.chinhSachOBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Ten";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // colNgay
            // 
            this.colNgay.Caption = "Ngày";
            this.colNgay.DisplayFormat.FormatString = "dd-MM-yy";
            this.colNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgay.FieldName = "Ngay";
            this.colNgay.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNgay.Name = "colNgay";
            this.colNgay.Visible = true;
            this.colNgay.VisibleIndex = 0;
            // 
            // colSoDuCuoi
            // 
            this.colSoDuCuoi.Caption = "Số dư";
            this.colSoDuCuoi.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
            this.colSoDuCuoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoDuCuoi.FieldName = "SoDuCuoi";
            this.colSoDuCuoi.Name = "colSoDuCuoi";
            this.colSoDuCuoi.Visible = true;
            this.colSoDuCuoi.VisibleIndex = 2;
            // 
            // frmLSCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 536);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(568, 617);
            this.Name = "frmLSCS";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử chính sách";
            this.Load += new System.EventHandler(this.frmSoDuHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chinhSachOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTN.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDN.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCLSCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soDuDaiLyOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVLSCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource chinhSachOBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.DateEdit iTN;
        private DevExpress.XtraEditors.DateEdit iDN;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn;
        private DevExpress.XtraEditors.LookUpEdit iCS;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl GCLSCS;
        private DevExpress.XtraGrid.Views.Grid.GridView GVLSCS;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colChinhSachID;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDuCuoi;
        private System.Windows.Forms.BindingSource soDuDaiLyOBindingSource;
    }
}