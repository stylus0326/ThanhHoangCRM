namespace CRM
{
    partial class frmQuyAGS
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.btnCapQuy = new DevExpress.XtraEditors.SimpleButton();
            this.wVJ = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.spinEdit1);
            this.groupControl1.Controls.Add(this.btnCapQuy);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(978, 55);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Thông tin";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Số tiền:";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(52, 26);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.DisplayFormat.FormatString = "#,##0";
            this.spinEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.Increment = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(100, 20);
            this.spinEdit1.TabIndex = 17;
            // 
            // btnCapQuy
            // 
            this.btnCapQuy.Location = new System.Drawing.Point(158, 24);
            this.btnCapQuy.Name = "btnCapQuy";
            this.btnCapQuy.Size = new System.Drawing.Size(65, 23);
            this.btnCapQuy.TabIndex = 11;
            this.btnCapQuy.Text = "Cấp quỹ";
            this.btnCapQuy.Click += new System.EventHandler(this.btnCapQuy_Click);
            // 
            // wVJ
            // 
            this.wVJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wVJ.Location = new System.Drawing.Point(0, 55);
            this.wVJ.MinimumSize = new System.Drawing.Size(20, 20);
            this.wVJ.Name = "wVJ";
            this.wVJ.ScriptErrorsSuppressed = true;
            this.wVJ.Size = new System.Drawing.Size(978, 633);
            this.wVJ.TabIndex = 14;
            this.wVJ.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wVJ_DocumentCompleted);
            // 
            // frmQuyAGS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 688);
            this.Controls.Add(this.wVJ);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmQuyAGS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Up Quỹ AGS";
            this.Load += new System.EventHandler(this.frmQuyAGS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.WebBrowser wVJ;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.SimpleButton btnCapQuy;
    }
}