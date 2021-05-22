namespace AutoUpdate
{
    partial class frmAutoUpdateManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_VersionID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_VersionName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Notes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_GetLastestVersion = new System.Windows.Forms.Button();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.lv_ListUploadFiles = new System.Windows.Forms.ListView();
            this.colSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_TotalSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Download = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version ID:";
            // 
            // txt_VersionID
            // 
            this.txt_VersionID.Location = new System.Drawing.Point(123, 21);
            this.txt_VersionID.Name = "txt_VersionID";
            this.txt_VersionID.ReadOnly = true;
            this.txt_VersionID.Size = new System.Drawing.Size(81, 20);
            this.txt_VersionID.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version Name:";
            // 
            // txt_VersionName
            // 
            this.txt_VersionName.Location = new System.Drawing.Point(123, 56);
            this.txt_VersionName.Name = "txt_VersionName";
            this.txt_VersionName.Size = new System.Drawing.Size(181, 20);
            this.txt_VersionName.TabIndex = 1;
            this.txt_VersionName.Text = "CRM-ver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Update File (zip file):";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(123, 92);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(181, 20);
            this.txt_FileName.TabIndex = 2;
            this.txt_FileName.Text = "CRM.zip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Notes:";
            // 
            // txt_Notes
            // 
            this.txt_Notes.Location = new System.Drawing.Point(123, 128);
            this.txt_Notes.Multiline = true;
            this.txt_Notes.Name = "txt_Notes";
            this.txt_Notes.Size = new System.Drawing.Size(181, 51);
            this.txt_Notes.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Notes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_FileName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_VersionName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_VersionID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(95, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version Information";
            // 
            // btn_GetLastestVersion
            // 
            this.btn_GetLastestVersion.Location = new System.Drawing.Point(12, 444);
            this.btn_GetLastestVersion.Name = "btn_GetLastestVersion";
            this.btn_GetLastestVersion.Size = new System.Drawing.Size(110, 27);
            this.btn_GetLastestVersion.TabIndex = 7;
            this.btn_GetLastestVersion.Text = "Get Lastest Version";
            this.btn_GetLastestVersion.UseVisualStyleBackColor = true;
            this.btn_GetLastestVersion.Click += new System.EventHandler(this.btn_GetLastestVersion_Click);
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(432, 444);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(75, 27);
            this.btn_Upload.TabIndex = 9;
            this.btn_Upload.Text = "Upload";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // lv_ListUploadFiles
            // 
            this.lv_ListUploadFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSTT,
            this.colFileName,
            this.colDateModified,
            this.colFileSize});
            this.lv_ListUploadFiles.FullRowSelect = true;
            this.lv_ListUploadFiles.GridLines = true;
            this.lv_ListUploadFiles.Location = new System.Drawing.Point(17, 18);
            this.lv_ListUploadFiles.Name = "lv_ListUploadFiles";
            this.lv_ListUploadFiles.Size = new System.Drawing.Size(461, 124);
            this.lv_ListUploadFiles.TabIndex = 10;
            this.lv_ListUploadFiles.UseCompatibleStateImageBehavior = false;
            this.lv_ListUploadFiles.View = System.Windows.Forms.View.Details;
            // 
            // colSTT
            // 
            this.colSTT.Text = "STT";
            this.colSTT.Width = 34;
            // 
            // colFileName
            // 
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 189;
            // 
            // colDateModified
            // 
            this.colDateModified.Text = "Date Modified";
            this.colDateModified.Width = 148;
            // 
            // colFileSize
            // 
            this.colFileSize.Text = "Size(Byte)";
            this.colFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colFileSize.Width = 66;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_TotalSize);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lv_ListUploadFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 172);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of Update Files";
            // 
            // lbl_TotalSize
            // 
            this.lbl_TotalSize.AutoSize = true;
            this.lbl_TotalSize.Location = new System.Drawing.Point(409, 150);
            this.lbl_TotalSize.Name = "lbl_TotalSize";
            this.lbl_TotalSize.Size = new System.Drawing.Size(30, 13);
            this.lbl_TotalSize.TabIndex = 12;
            this.lbl_TotalSize.Text = "0 KB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Folder:";
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(54, 239);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(372, 20);
            this.txt_Path.TabIndex = 4;
            this.txt_Path.TextChanged += new System.EventHandler(this.txt_Path_TextChanged);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(432, 237);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 25);
            this.btn_Browse.TabIndex = 5;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_Download
            // 
            this.btn_Download.Location = new System.Drawing.Point(128, 444);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(75, 27);
            this.btn_Download.TabIndex = 14;
            this.btn_Download.Text = "Download";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(137, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "CẬP NHẬT THÀNH HOÀNG CMR";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.progressBar1.Location = new System.Drawing.Point(12, 480);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // frmAutoUpdateManagement
            // 
            this.AcceptButton = this.btn_Upload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 511);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Download);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.btn_GetLastestVersion);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmAutoUpdateManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Update Management";
            this.Load += new System.EventHandler(this.frmAutoUpdateManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_VersionID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_VersionName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Notes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GetLastestVersion;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.ListView lv_ListUploadFiles;
        private System.Windows.Forms.ColumnHeader colSTT;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colDateModified;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.Label lbl_TotalSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}