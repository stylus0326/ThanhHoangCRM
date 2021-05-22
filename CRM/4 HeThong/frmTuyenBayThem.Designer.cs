namespace CRM
{
    partial class frmTuyenBayThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuyenBayThem));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iKyHieuDi = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.sanBayOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iKyHieuDen = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKyHieu1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDayDu1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLuu2 = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iKyHieuDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBayOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKyHieuDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Sân bay đến:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Sân bay đi:";
            // 
            // iKyHieuDi
            // 
            this.iKyHieuDi.Location = new System.Drawing.Point(78, 12);
            this.iKyHieuDi.Name = "iKyHieuDi";
            this.iKyHieuDi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iKyHieuDi.Properties.DataSource = this.sanBayOBindingSource;
            this.iKyHieuDi.Properties.DisplayMember = "KyHieu";
            this.iKyHieuDi.Properties.NullText = "";
            this.iKyHieuDi.Properties.PopupView = this.searchLookUpEdit1View;
            this.iKyHieuDi.Properties.ValueMember = "ID";
            this.iKyHieuDi.Size = new System.Drawing.Size(150, 20);
            this.iKyHieuDi.TabIndex = 0;
            this.iKyHieuDi.Tag = "KyHieuDi";
            this.iKyHieuDi.EditValueChanged += new System.EventHandler(this.iKyHieuDi_EditValueChanged);
            // 
            // sanBayOBindingSource
            // 
            this.sanBayOBindingSource.DataSource = typeof(DataTransferObject.O_SANBAY);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ký hiệu";
            this.gridColumn2.FieldName = "KyHieu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên đầy đủ";
            this.gridColumn3.FieldName = "TenDayDu";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // iKyHieuDen
            // 
            this.iKyHieuDen.Location = new System.Drawing.Point(78, 38);
            this.iKyHieuDen.Name = "iKyHieuDen";
            this.iKyHieuDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iKyHieuDen.Properties.DataSource = this.bindingSource1;
            this.iKyHieuDen.Properties.DisplayMember = "KyHieu";
            this.iKyHieuDen.Properties.NullText = "";
            this.iKyHieuDen.Properties.PopupView = this.gridView1;
            this.iKyHieuDen.Properties.ValueMember = "ID";
            this.iKyHieuDen.Size = new System.Drawing.Size(150, 20);
            this.iKyHieuDen.TabIndex = 1;
            this.iKyHieuDen.Tag = "KyHieuDen";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DataTransferObject.O_SANBAY);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.colKyHieu1,
            this.colTenDayDu1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "ID";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // colKyHieu1
            // 
            this.colKyHieu1.Caption = "Ký hiệu";
            this.colKyHieu1.FieldName = "KyHieu";
            this.colKyHieu1.Name = "colKyHieu1";
            this.colKyHieu1.Visible = true;
            this.colKyHieu1.VisibleIndex = 0;
            // 
            // colTenDayDu1
            // 
            this.colTenDayDu1.Caption = "Tên đầy đủ";
            this.colTenDayDu1.FieldName = "TenDayDu";
            this.colTenDayDu1.Name = "colTenDayDu1";
            this.colTenDayDu1.Visible = true;
            this.colTenDayDu1.VisibleIndex = 1;
            // 
            // btnLuu2
            // 
            this.btnLuu2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu2.Appearance.Options.UseFont = true;
            this.btnLuu2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu2.ImageOptions.SvgImage")));
            this.btnLuu2.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLuu2.Location = new System.Drawing.Point(167, 64);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(61, 22);
            this.btnLuu2.TabIndex = 2;
            this.btnLuu2.TabStop = false;
            this.btnLuu2.Text = "Lưu";
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // frmTuyenBayThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 92);
            this.Controls.Add(this.btnLuu2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iKyHieuDi);
            this.Controls.Add(this.iKyHieuDen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTuyenBayThem";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tuyến bay";
            this.Load += new System.EventHandler(this.frmTuyenBayThem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTuyenBayThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.iKyHieuDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBayOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iKyHieuDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit iKyHieuDi;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SearchLookUpEdit iKyHieuDen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHieu1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDayDu1;
        private DevExpress.XtraEditors.SimpleButton btnLuu2;
        private System.Windows.Forms.BindingSource sanBayOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}