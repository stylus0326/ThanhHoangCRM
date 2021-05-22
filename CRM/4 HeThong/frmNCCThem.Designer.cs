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
            this.sanBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.iLoai = new DevExpress.XtraEditors.MemoEdit();
            this.iG1 = new DevExpress.XtraEditors.GroupControl();
            this.iGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl32 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iThongTinKhac = new DevExpress.XtraEditors.MemoEdit();
            this.iSTK = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.iDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.DSNH = new System.Windows.Forms.BindingSource(this.components);
            this.iG2 = new DevExpress.XtraEditors.GroupControl();
            this.iKhachSan = new DevExpress.XtraEditors.CheckEdit();
            this.iG3 = new DevExpress.XtraEditors.GroupControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.sanBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iG1)).BeginInit();
            this.iG1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iThongTinKhac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSNH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iG2)).BeginInit();
            this.iG2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iKhachSan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iG3)).BeginInit();
            this.iG3.SuspendLayout();
            this.SuspendLayout();
            // 
            // iTenDayDu
            // 
            this.iTenDayDu.Location = new System.Drawing.Point(64, 26);
            this.iTenDayDu.Name = "iTenDayDu";
            this.iTenDayDu.Size = new System.Drawing.Size(245, 20);
            this.iTenDayDu.TabIndex = 10;
            this.iTenDayDu.Tag = "Tên";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 29);
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
            this.btnLuu.Location = new System.Drawing.Point(852, 526);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(59, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lueNCC
            // 
            this.lueNCC.Location = new System.Drawing.Point(70, 104);
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
            this.lueNCC.TabIndex = 3;
            this.lueNCC.EditValueChanged += new System.EventHandler(this.lueNCC_EditValueChanged);
            // 
            // hangBayOBindingSource
            // 
            this.hangBayOBindingSource.DataSource = typeof(DataTransferObject.O_HANGBAY);
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
            this.GCNCC.Location = new System.Drawing.Point(15, 130);
            this.GCNCC.MainView = this.GVNCC;
            this.GCNCC.Name = "GCNCC";
            this.GCNCC.Size = new System.Drawing.Size(197, 401);
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
            this.labelControl10.Location = new System.Drawing.Point(32, 107);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(29, 13);
            this.labelControl10.TabIndex = 46;
            this.labelControl10.Text = "Hãng:";
            // 
            // iHang
            // 
            this.iHang.Location = new System.Drawing.Point(444, 12);
            this.iHang.Name = "iHang";
            this.iHang.Properties.Caption = "";
            this.iHang.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.iHang.Properties.RadioGroupIndex = 0;
            this.iHang.Size = new System.Drawing.Size(75, 20);
            this.iHang.TabIndex = 5;
            this.iHang.CheckedChanged += new System.EventHandler(this.iHang_CheckedChanged);
            // 
            // iTen
            // 
            this.iTen.Location = new System.Drawing.Point(363, 26);
            this.iTen.Name = "iTen";
            this.iTen.Size = new System.Drawing.Size(54, 20);
            this.iTen.TabIndex = 11;
            this.iTen.Tag = "Tên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(315, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "Tên tắt:";
            // 
            // iMaHang
            // 
            this.iMaHang.Location = new System.Drawing.Point(70, 26);
            this.iMaHang.Name = "iMaHang";
            this.iMaHang.Size = new System.Drawing.Size(142, 20);
            this.iMaHang.TabIndex = 0;
            this.iMaHang.Tag = "";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 29);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 85;
            this.labelControl5.Text = "Mã ĐN:";
            // 
            // iMatKhau
            // 
            this.iMatKhau.Location = new System.Drawing.Point(70, 78);
            this.iMatKhau.Name = "iMatKhau";
            this.iMatKhau.Properties.PasswordChar = '*';
            this.iMatKhau.Size = new System.Drawing.Size(142, 20);
            this.iMatKhau.TabIndex = 2;
            this.iMatKhau.Tag = "";
            // 
            // iTaiKhoan
            // 
            this.iTaiKhoan.Location = new System.Drawing.Point(70, 52);
            this.iTaiKhoan.Name = "iTaiKhoan";
            this.iTaiKhoan.Size = new System.Drawing.Size(142, 20);
            this.iTaiKhoan.TabIndex = 1;
            this.iTaiKhoan.Tag = "";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 82;
            this.labelControl4.Text = "Mật khẩu:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 83;
            this.labelControl3.Text = "Tài khoản:";
            // 
            // sanBayOBindingSource
            // 
            this.sanBayOBindingSource.DataSource = typeof(DataTransferObject.O_SANBAY);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Loại phòng: (1 loại 1 dòng)";
            // 
            // iLoai
            // 
            this.iLoai.Location = new System.Drawing.Point(5, 41);
            this.iLoai.Name = "iLoai";
            this.iLoai.Size = new System.Drawing.Size(191, 456);
            this.iLoai.TabIndex = 0;
            this.iLoai.Tag = "Loại vé";
            // 
            // iG1
            // 
            this.iG1.Controls.Add(this.iGhiChu);
            this.iG1.Controls.Add(this.labelControl32);
            this.iG1.Controls.Add(this.label3);
            this.iG1.Controls.Add(this.label2);
            this.iG1.Controls.Add(this.iThongTinKhac);
            this.iG1.Controls.Add(this.iSTK);
            this.iG1.Controls.Add(this.labelControl7);
            this.iG1.Controls.Add(this.iDiaChi);
            this.iG1.Controls.Add(this.iTenDayDu);
            this.iG1.Controls.Add(this.labelControl1);
            this.iG1.Controls.Add(this.labelControl2);
            this.iG1.Controls.Add(this.iTen);
            this.iG1.Location = new System.Drawing.Point(12, 12);
            this.iG1.Name = "iG1";
            this.iG1.Size = new System.Drawing.Size(428, 537);
            this.iG1.TabIndex = 0;
            this.iG1.Text = "Thông tin chung";
            // 
            // iGhiChu
            // 
            this.iGhiChu.Location = new System.Drawing.Point(15, 387);
            this.iGhiChu.Name = "iGhiChu";
            this.iGhiChu.Size = new System.Drawing.Size(402, 144);
            this.iGhiChu.TabIndex = 15;
            this.iGhiChu.Tag = "GhiChu";
            // 
            // labelControl32
            // 
            this.labelControl32.Location = new System.Drawing.Point(15, 368);
            this.labelControl32.Name = "labelControl32";
            this.labelControl32.Size = new System.Drawing.Size(39, 13);
            this.labelControl32.TabIndex = 103;
            this.labelControl32.Text = "Ghi chú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "Thông tin liên lạc (1 thông tin1 dòng)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "STK (1 STK 1 dòng) cú pháp XXX:012...65";
            // 
            // iThongTinKhac
            // 
            this.iThongTinKhac.Location = new System.Drawing.Point(15, 310);
            this.iThongTinKhac.Name = "iThongTinKhac";
            this.iThongTinKhac.Size = new System.Drawing.Size(402, 47);
            this.iThongTinKhac.TabIndex = 14;
            this.iThongTinKhac.Tag = "Loại vé";
            // 
            // iSTK
            // 
            this.iSTK.Location = new System.Drawing.Point(15, 108);
            this.iSTK.Name = "iSTK";
            this.iSTK.Size = new System.Drawing.Size(402, 183);
            this.iSTK.TabIndex = 13;
            this.iSTK.Tag = "Loại vé";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(25, 55);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 55;
            this.labelControl7.Text = "Địa chỉ:";
            // 
            // iDiaChi
            // 
            this.iDiaChi.Location = new System.Drawing.Point(64, 52);
            this.iDiaChi.Name = "iDiaChi";
            this.iDiaChi.Size = new System.Drawing.Size(353, 20);
            this.iDiaChi.TabIndex = 12;
            this.iDiaChi.Tag = "Tên";
            // 
            // DSNH
            // 
            this.DSNH.DataSource = typeof(DataTransferObject.O_NGANHANG);
            // 
            // iG2
            // 
            this.iG2.Controls.Add(this.iMaHang);
            this.iG2.Controls.Add(this.labelControl3);
            this.iG2.Controls.Add(this.labelControl4);
            this.iG2.Controls.Add(this.iTaiKhoan);
            this.iG2.Controls.Add(this.iMatKhau);
            this.iG2.Controls.Add(this.GCNCC);
            this.iG2.Controls.Add(this.lueNCC);
            this.iG2.Controls.Add(this.labelControl5);
            this.iG2.Controls.Add(this.labelControl10);
            this.iG2.Location = new System.Drawing.Point(463, 12);
            this.iG2.Name = "iG2";
            this.iG2.Size = new System.Drawing.Size(223, 536);
            this.iG2.TabIndex = 1;
            this.iG2.Text = "Hãng";
            // 
            // iKhachSan
            // 
            this.iKhachSan.Location = new System.Drawing.Point(692, 12);
            this.iKhachSan.Name = "iKhachSan";
            this.iKhachSan.Properties.Caption = "";
            this.iKhachSan.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.iKhachSan.Properties.RadioGroupIndex = 0;
            this.iKhachSan.Size = new System.Drawing.Size(75, 20);
            this.iKhachSan.TabIndex = 94;
            this.iKhachSan.TabStop = false;
            this.iKhachSan.CheckedChanged += new System.EventHandler(this.iHang_CheckedChanged);
            // 
            // iG3
            // 
            this.iG3.Controls.Add(this.iLoai);
            this.iG3.Controls.Add(this.label1);
            this.iG3.Enabled = false;
            this.iG3.Location = new System.Drawing.Point(711, 12);
            this.iG3.Name = "iG3";
            this.iG3.Size = new System.Drawing.Size(200, 508);
            this.iG3.TabIndex = 2;
            this.iG3.Text = "Khách sạn";
            // 
            // frmNCCThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 560);
            this.Controls.Add(this.iG3);
            this.Controls.Add(this.iKhachSan);
            this.Controls.Add(this.iG2);
            this.Controls.Add(this.iG1);
            this.Controls.Add(this.iHang);
            this.Controls.Add(this.btnLuu);
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
            ((System.ComponentModel.ISupportInitialize)(this.sanBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iG1)).EndInit();
            this.iG1.ResumeLayout(false);
            this.iG1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iThongTinKhac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSNH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iG2)).EndInit();
            this.iG2.ResumeLayout(false);
            this.iG2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iKhachSan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iG3)).EndInit();
            this.iG3.ResumeLayout(false);
            this.iG3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.MemoEdit iLoai;
        private System.Windows.Forms.BindingSource sanBayOBindingSource;
        private DevExpress.XtraEditors.GroupControl iG1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit iDiaChi;
        private DevExpress.XtraEditors.GroupControl iG2;
        private DevExpress.XtraEditors.CheckEdit iKhachSan;
        private DevExpress.XtraEditors.GroupControl iG3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.MemoEdit iThongTinKhac;
        private DevExpress.XtraEditors.MemoEdit iSTK;
        private System.Windows.Forms.BindingSource DSNH;
        private DevExpress.XtraEditors.MemoEdit iGhiChu;
        private DevExpress.XtraEditors.LabelControl labelControl32;
    }
}