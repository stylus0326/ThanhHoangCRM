namespace CRM
{
    partial class frmNCCThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNCCThem));
            this.iTenDayDu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.lueNCC = new DevExpress.XtraEditors.LookUpEdit();
            this.hangBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GCNCC = new DevExpress.XtraGrid.GridControl();
            this.GVNCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.iHang = new DevExpress.XtraEditors.CheckEdit();
            this.iTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iMaHang = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.iTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.iTenDayDu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMaHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTaiKhoan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // iTenDayDu
            // 
            this.iTenDayDu.Location = new System.Drawing.Point(68, 12);
            this.iTenDayDu.Name = "iTenDayDu";
            this.iTenDayDu.Size = new System.Drawing.Size(142, 20);
            this.iTenDayDu.TabIndex = 0;
            this.iTenDayDu.Tag = "Tên";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Tên NCC:";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu.Location = new System.Drawing.Point(354, 193);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(59, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lueNCC
            // 
            this.lueNCC.Location = new System.Drawing.Point(68, 64);
            this.lueNCC.Name = "lueNCC";
            this.lueNCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNCC.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHang", "Tên NCC", 28, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueNCC.Properties.DataSource = this.hangBayOBindingSource;
            this.lueNCC.Properties.DisplayMember = "TenHang";
            this.lueNCC.Properties.NullText = "---";
            this.lueNCC.Properties.ValueMember = "ID";
            this.lueNCC.Size = new System.Drawing.Size(142, 20);
            this.lueNCC.TabIndex = 48;
            this.lueNCC.EditValueChanged += new System.EventHandler(this.lueNCC_EditValueChanged);
            // 
            // hangBayOBindingSource
            // 
            this.hangBayOBindingSource.DataSource = typeof(DataTransferObject.HangBayO);
            // 
            // GCNCC
            // 
            this.GCNCC.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.EnabledAutoRepeat = false;
            this.GCNCC.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.First.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.GCNCC.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.GCNCC.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.GCNCC.Location = new System.Drawing.Point(216, 12);
            this.GCNCC.MainView = this.GVNCC;
            this.GCNCC.Name = "GCNCC";
            this.GCNCC.Size = new System.Drawing.Size(197, 175);
            this.GCNCC.TabIndex = 47;
            this.GCNCC.UseEmbeddedNavigator = true;
            this.GCNCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVNCC});
            // 
            // GVNCC
            // 
            this.GVNCC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colTen});
            this.GVNCC.GridControl = this.GCNCC;
            this.GVNCC.Name = "GVNCC";
            this.GVNCC.OptionsView.ShowGroupPanel = false;
            this.GVNCC.RowHeight = 25;
            // 
            // colID
            // 
            this.colID.Caption = "CT";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 202;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 0;
            this.colTen.Width = 563;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(30, 67);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(29, 13);
            this.labelControl10.TabIndex = 46;
            this.labelControl10.Text = "Hãng:";
            // 
            // iHang
            // 
            this.iHang.Location = new System.Drawing.Point(68, 168);
            this.iHang.Name = "iHang";
            this.iHang.Properties.Caption = "Hãng";
            this.iHang.Size = new System.Drawing.Size(75, 20);
            this.iHang.TabIndex = 5;
            // 
            // iTen
            // 
            this.iTen.Location = new System.Drawing.Point(68, 38);
            this.iTen.Name = "iTen";
            this.iTen.Size = new System.Drawing.Size(142, 20);
            this.iTen.TabIndex = 1;
            this.iTen.Tag = "Tên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "Tên tắt:";
            // 
            // iMaHang
            // 
            this.iMaHang.Location = new System.Drawing.Point(68, 90);
            this.iMaHang.Name = "iMaHang";
            this.iMaHang.Size = new System.Drawing.Size(142, 20);
            this.iMaHang.TabIndex = 2;
            this.iMaHang.Tag = "";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(23, 93);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 85;
            this.labelControl5.Text = "Mã ĐN:";
            // 
            // iMatKhau
            // 
            this.iMatKhau.Location = new System.Drawing.Point(68, 142);
            this.iMatKhau.Name = "iMatKhau";
            this.iMatKhau.Properties.PasswordChar = '*';
            this.iMatKhau.Size = new System.Drawing.Size(142, 20);
            this.iMatKhau.TabIndex = 4;
            this.iMatKhau.Tag = "";
            // 
            // iTaiKhoan
            // 
            this.iTaiKhoan.Location = new System.Drawing.Point(68, 116);
            this.iTaiKhoan.Name = "iTaiKhoan";
            this.iTaiKhoan.Size = new System.Drawing.Size(142, 20);
            this.iTaiKhoan.TabIndex = 3;
            this.iTaiKhoan.Tag = "";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 145);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 82;
            this.labelControl4.Text = "Mật khẩu:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 119);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 83;
            this.labelControl3.Text = "Tài khoản:";
            // 
            // frmNCCThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 223);
            this.Controls.Add(this.iMaHang);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iMatKhau);
            this.Controls.Add(this.iTaiKhoan);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iTen);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iHang);
            this.Controls.Add(this.lueNCC);
            this.Controls.Add(this.GCNCC);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.iTenDayDu);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNCCThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhà cung cấp";
            this.Load += new System.EventHandler(this.frmNCCThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNCCThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iTenDayDu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hangBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMaHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTaiKhoan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit iTenDayDu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LookUpEdit lueNCC;
        private DevExpress.XtraGrid.GridControl GCNCC;
        private DevExpress.XtraGrid.Views.Grid.GridView GVNCC;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.BindingSource hangBayOBindingSource;
        private DevExpress.XtraEditors.CheckEdit iHang;
        private DevExpress.XtraEditors.TextEdit iTen;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iMaHang;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iMatKhau;
        private DevExpress.XtraEditors.TextEdit iTaiKhoan;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}