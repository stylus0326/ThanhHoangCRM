
namespace CRM
{
    partial class frmNganHangChinh
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
            this.GCNH = new DevExpress.XtraGrid.GridControl();
            this.BS_NGANHANG = new System.Windows.Forms.BindingSource(this.components);
            this.GVNH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDayDu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKyHieu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GCNH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_NGANHANG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNH)).BeginInit();
            this.SuspendLayout();
            // 
            // GCNH
            // 
            this.GCNH.DataSource = this.BS_NGANHANG;
            this.GCNH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCNH.Location = new System.Drawing.Point(0, 0);
            this.GCNH.MainView = this.GVNH;
            this.GCNH.Name = "GCNH";
            this.GCNH.Size = new System.Drawing.Size(520, 405);
            this.GCNH.TabIndex = 6;
            this.GCNH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVNH});
            // 
            // BS_NGANHANG
            // 
            this.BS_NGANHANG.DataSource = typeof(DataTransferObject.O_NGANHANGSUDUNG);
            // 
            // GVNH
            // 
            this.GVNH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colTenDayDu,
            this.colTenTat,
            this.colKyHieu});
            this.GVNH.GridControl = this.GCNH;
            this.GVNH.Name = "GVNH";
            this.GVNH.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.GVNH.OptionsView.ShowAutoFilterRow = true;
            this.GVNH.OptionsView.ShowGroupPanel = false;
            this.GVNH.RowHeight = 25;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.FixedWidth = true;
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 42;
            // 
            // colTenDayDu
            // 
            this.colTenDayDu.Caption = "Tên";
            this.colTenDayDu.FieldName = "TenDayDu";
            this.colTenDayDu.Name = "colTenDayDu";
            this.colTenDayDu.Visible = true;
            this.colTenDayDu.VisibleIndex = 1;
            this.colTenDayDu.Width = 184;
            // 
            // colTenTat
            // 
            this.colTenTat.Caption = "Tên tắt";
            this.colTenTat.FieldName = "TenTat";
            this.colTenTat.Name = "colTenTat";
            this.colTenTat.Visible = true;
            this.colTenTat.VisibleIndex = 2;
            // 
            // colKyHieu
            // 
            this.colKyHieu.Caption = "kí hiệu";
            this.colKyHieu.FieldName = "KyHieu";
            this.colKyHieu.Name = "colKyHieu";
            this.colKyHieu.OptionsColumn.FixedWidth = true;
            this.colKyHieu.Visible = true;
            this.colKyHieu.VisibleIndex = 3;
            this.colKyHieu.Width = 47;
            // 
            // frmNganHangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 405);
            this.Controls.Add(this.GCNH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(522, 437);
            this.MinimumSize = new System.Drawing.Size(522, 437);
            this.Name = "frmNganHangChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngân hàng";
            ((System.ComponentModel.ISupportInitialize)(this.GCNH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_NGANHANG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVNH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCNH;
        private DevExpress.XtraGrid.Views.Grid.GridView GVNH;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHieu;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDayDu;
        private System.Windows.Forms.BindingSource BS_NGANHANG;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTat;
    }
}