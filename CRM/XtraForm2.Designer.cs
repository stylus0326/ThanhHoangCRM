namespace CRM
{
    partial class XtraForm2
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
            this.pic_crop = new DevExpress.XtraEditors.PictureEdit();
            this.btn_crop = new System.Windows.Forms.Button();
            this.btn_browser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_origin = new DevExpress.XtraEditors.CropPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_crop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_origin)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_crop
            // 
            this.pic_crop.Location = new System.Drawing.Point(240, 126);
            this.pic_crop.Name = "pic_crop";
            this.pic_crop.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_crop.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_crop.Size = new System.Drawing.Size(218, 196);
            this.pic_crop.TabIndex = 1;
            // 
            // btn_crop
            // 
            this.btn_crop.Location = new System.Drawing.Point(256, 49);
            this.btn_crop.Name = "btn_crop";
            this.btn_crop.Size = new System.Drawing.Size(92, 23);
            this.btn_crop.TabIndex = 10;
            this.btn_crop.Text = "Crop";
            this.btn_crop.UseVisualStyleBackColor = true;
            this.btn_crop.Click += new System.EventHandler(this.btn_crop_Click);
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(141, 49);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(92, 23);
            this.btn_browser.TabIndex = 9;
            this.btn_browser.Text = "Browser...";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Origin Image:";
            // 
            // pic_origin
            // 
            this.pic_origin.Location = new System.Drawing.Point(12, 126);
            this.pic_origin.Name = "pic_origin";
            this.pic_origin.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.pic_origin.SelectionBorderDashPattern = null;
            this.pic_origin.SelectionResizeMode = DevExpress.XtraEditors.CropPictureBox.CropBoxSelectionResizeMode.Unrestricted;
            this.pic_origin.Size = new System.Drawing.Size(221, 196);
            this.pic_origin.TabIndex = 0;
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 359);
            this.Controls.Add(this.btn_crop);
            this.Controls.Add(this.btn_browser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_crop);
            this.Controls.Add(this.pic_origin);
            this.Name = "XtraForm2";
            this.Text = "XtraForm2";
            ((System.ComponentModel.ISupportInitialize)(this.pic_crop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_origin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CropPictureBox pic_origin;
        private DevExpress.XtraEditors.PictureEdit pic_crop;
        private System.Windows.Forms.Button btn_crop;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.Label label1;
    }
}