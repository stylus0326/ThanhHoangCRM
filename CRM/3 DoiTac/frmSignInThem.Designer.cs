namespace CRM
{
    partial class frmSignInThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignInThem));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iChinh = new DevExpress.XtraEditors.CheckEdit();
            this.iSignIn = new DevExpress.XtraEditors.TextEdit();
            this.iHangBay = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iDaiLy = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.daiLyOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hangBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iKhoa = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iMatKhau = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iChinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSignIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHangBay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDaiLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "SignIn:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Hãng Bay:";
            // 
            // iChinh
            // 
            this.iChinh.EditValue = true;
            this.iChinh.Location = new System.Drawing.Point(81, 113);
            this.iChinh.Name = "iChinh";
            this.iChinh.Properties.Caption = "Thanh Toán";
            this.iChinh.Size = new System.Drawing.Size(91, 20);
            this.iChinh.TabIndex = 3;
            this.iChinh.Tag = "Chinh";
            // 
            // iSignIn
            // 
            this.iSignIn.Location = new System.Drawing.Point(81, 35);
            this.iSignIn.Name = "iSignIn";
            this.iSignIn.Size = new System.Drawing.Size(166, 20);
            this.iSignIn.TabIndex = 1;
            this.iSignIn.Tag = "SignIn";
            // 
            // iHangBay
            // 
            this.iHangBay.Location = new System.Drawing.Point(81, 87);
            this.iHangBay.Name = "iHangBay";
            this.iHangBay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iHangBay.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 34, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHang", "Hãng Bay", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTat", "Ten Tat", 47, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.iHangBay.Properties.DataSource = this.hangBayOBindingSource;
            this.iHangBay.Properties.DisplayMember = "TenHang";
            this.iHangBay.Properties.NullText = "[Chọn hãng ...";
            this.iHangBay.Properties.ValueMember = "ID";
            this.iHangBay.Size = new System.Drawing.Size(166, 20);
            this.iHangBay.TabIndex = 2;
            this.iHangBay.Tag = "Hãng";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu.Location = new System.Drawing.Point(194, 111);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(53, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.TabStop = false;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Đại lý:";
            // 
            // iDaiLy
            // 
            this.iDaiLy.EditValue = "[Chọn khách hàng...]";
            this.iDaiLy.Location = new System.Drawing.Point(81, 9);
            this.iDaiLy.Name = "iDaiLy";
            this.iDaiLy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iDaiLy.Properties.DataSource = this.daiLyOBindingSource;
            this.iDaiLy.Properties.DisplayMember = "Ten";
            this.iDaiLy.Properties.NullText = "[Chọn khách hàng...";
            this.iDaiLy.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.iDaiLy.Properties.PopupView = this.searchLookUpEdit1View;
            this.iDaiLy.Properties.ReadOnly = true;
            this.iDaiLy.Properties.ValueMember = "ID";
            this.iDaiLy.Size = new System.Drawing.Size(166, 20);
            this.iDaiLy.TabIndex = 0;
            this.iDaiLy.Tag = "Khách";
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTen});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.TextAndVisual;
            this.searchLookUpEdit1View.OptionsFind.FindFilterColumns = "Ten";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTen
            // 
            this.colTen.FieldName = "Ten";
            this.colTen.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTen.Name = "colTen";
            this.colTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 0;
            // 
            // daiLyOBindingSource
            // 
            this.daiLyOBindingSource.DataSource = typeof(DataTransferObject.DaiLyO);
            // 
            // hangBayOBindingSource
            // 
            this.hangBayOBindingSource.DataSource = typeof(DataTransferObject.HangBayO);
            // 
            // iKhoa
            // 
            this.iKhoa.EditValue = true;
            this.iKhoa.Location = new System.Drawing.Point(12, 113);
            this.iKhoa.Name = "iKhoa";
            this.iKhoa.Properties.Caption = "Khóa";
            this.iKhoa.Size = new System.Drawing.Size(54, 20);
            this.iKhoa.TabIndex = 6;
            this.iKhoa.Tag = "Khóa";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mật khẩu tạm:";
            // 
            // iMatKhau
            // 
            this.iMatKhau.Location = new System.Drawing.Point(81, 61);
            this.iMatKhau.Name = "iMatKhau";
            this.iMatKhau.Size = new System.Drawing.Size(166, 20);
            this.iMatKhau.TabIndex = 1;
            this.iMatKhau.Tag = "SignIn";
            // 
            // frmSignInThem
            // 
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 151);
            this.Controls.Add(this.iKhoa);
            this.Controls.Add(this.iDaiLy);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.iHangBay);
            this.Controls.Add(this.iMatKhau);
            this.Controls.Add(this.iSignIn);
            this.Controls.Add(this.iChinh);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignInThem";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignIn";
            this.Load += new System.EventHandler(this.frmThemSignIn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSignInThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iChinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSignIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHangBay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDaiLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daiLyOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhau.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit iChinh;
        private DevExpress.XtraEditors.TextEdit iSignIn;
        private DevExpress.XtraEditors.LookUpEdit iHangBay;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.BindingSource hangBayOBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SearchLookUpEdit iDaiLy;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private System.Windows.Forms.BindingSource daiLyOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.CheckEdit iKhoa;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iMatKhau;
    }
}