using AutoUpdate.Controllers;
using AutoUpdate.Objects;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace AutoUpdate
{
    public partial class frmAutoUpdateManagement : Form
    {
        public string[] lstUploadFiles;
        public long totalFileSizes = 0;
        private Thread thread;
        private Thread thread2;

        public frmAutoUpdateManagement()
        {
            InitializeComponent();
        }

        private void btn_GetLastestVersion_Click(object sender, EventArgs e)
        {
            VersionOBJ verObj = VersionCTL.GetLastestVersion();
            MessageBox.Show("VersionID: " + verObj.VersionID + " - VersionName: " + verObj.VersionName + " - FileName: " + verObj.FileName);

        }

        public void CreateNewVersion()
        {
            int ID;
            VersionOBJ verObj = VersionCTL.GetLastestVersion();
            if (verObj.VersionID == string.Empty)
                ID = 1;
            else
                ID = int.Parse(verObj.VersionID) + 1;
            txt_VersionID.Text = ID.ToString();

            txt_VersionName.Text = "CRM-ver" + ID.ToString();
            txt_FileName.Text = "CRM.zip";

        }
        private void frmAutoUpdateManagement_Load(object sender, EventArgs e)
        {
            CreateNewVersion();
            btn_Upload.Enabled = false;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDlg = new FolderBrowserDialog();
            if (fbDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_Path.Text = fbDlg.SelectedPath;

                ShowUploadFilesInListView();

                //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }

        public void ShowUploadFilesInListView()
        {
            try
            {
                string[] files = Directory.GetFiles(txt_Path.Text);

                lstUploadFiles = new string[files.Length];
                lstUploadFiles = files;

                lv_ListUploadFiles.Items.Clear();
                int idx = 1;
                totalFileSizes = 0;
                foreach (string filePath in lstUploadFiles)
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Exists)
                    {
                        DateTime fileDate = fi.LastWriteTime;

                        string[] subItems = new string[4];
                        subItems[0] = idx.ToString();
                        subItems[1] = Path.GetFileName(filePath);
                        subItems[2] = fileDate.ToString("dd/MM/yyyy hh:mm:ss tt");
                        subItems[3] = fi.Length.ToString("###,###");
                        ListViewItem item = new ListViewItem(subItems);
                        lv_ListUploadFiles.Items.Add(item);

                        totalFileSizes += fi.Length;
                        idx++;
                    }
                }
                this.lv_ListUploadFiles.Sort();

                lbl_TotalSize.Text = ((float)Math.Round((float)totalFileSizes / 1024, 1)).ToString("###,###") + " KB";
                if (lv_ListUploadFiles.Items.Count > 0)
                    btn_Upload.Enabled = true;

            }
            catch
            {
                lv_ListUploadFiles.Items.Clear();
                btn_Upload.Enabled = false;
                totalFileSizes = 0;
            }
        }

        private void txt_Path_TextChanged(object sender, EventArgs e)
        {
            ShowUploadFilesInListView();
        }


        public void UpdateStatusProgressBar(int value, string status = "")
        {
            progressBar1.Value += value;
            progressBar1.PerformStep();
            //progressBar1.ca;
            int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);

            if (status != string.Empty)
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "% - " + status, new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 60, progressBar1.Height / 2 - 7));
            else
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 60, progressBar1.Height / 2 - 7));


        }


        public void UploadNewVersion()
        {
            DateTime startDT = DateTime.Now;
            try
            {

                UpdateStatusProgressBar(0, "Preparing data...");

                //Step 0: Prepare data
                string sPath = Path.GetDirectoryName(Application.ExecutablePath);
                string szipFilePath = sPath + "\\" + txt_FileName.Text;

                UpdateStatusProgressBar(0, "Creating new zip file...");

                //Step 1: Create new zip file (includes list of update files)
                try
                {
                    string sUpdateFolder = sPath;
                    ZipArchiveMOD.CreateArchive(szipFilePath, sUpdateFolder, this.lstUploadFiles, true);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error! Create zip file: " + ex1.Message);
                    btn_Upload.Enabled = true;
                    btn_Download.Enabled = true;

                    return;
                }

                UpdateStatusProgressBar(45, "Inserting version...");

                //Step 2: Insert version
                VersionOBJ verObj = new VersionOBJ();
                verObj.VersionID = txt_VersionID.Text;
                verObj.VersionName = txt_VersionName.Text;
                verObj.FileName = txt_FileName.Text;
                //FileInfo fi = new FileInfo(szipFilePath);
                //verObj.FileSize = fi.Length;
                verObj.FileSize = (new FileInfo(szipFilePath)).Length;
                verObj.VersionType = "TH-CRM";
                verObj.Notes = txt_Notes.Text;

                UpdateStatusProgressBar(0, "Inserting version...");

                if (VersionCTL.InsertNewVersion(verObj) == false)
                {
                    MessageBox.Show("Error! Insert Version");
                    btn_Upload.Enabled = true;
                    btn_Download.Enabled = true;
                    return;
                }

                UpdateStatusProgressBar(0, "Uploading file to server...");

                //Step 3: Upload file to server
                if (SegmentDataCTL.UploadFileToServer(szipFilePath, verObj.VersionID, verObj.Notes))
                {
                    DateTime endDT = DateTime.Now;
                    //DateTime delta = endDT - startDT;
                    long totalSecond = 0;
                    if (endDT.Second > startDT.Second)
                        totalSecond = (endDT.Hour - startDT.Hour) * 60 * 60 + (endDT.Minute - startDT.Minute) * 60 + (endDT.Second - startDT.Second);
                    else
                        totalSecond = (endDT.Hour - startDT.Hour) * 60 * 60 + (endDT.Minute - startDT.Minute - 1) * 60 + (endDT.Second + 60 - startDT.Second);

                    UpdateStatusProgressBar(25, "Finished");

                    MessageBox.Show("Files uploaded successfully! Total second: " + totalSecond.ToString());

                }
                else
                    MessageBox.Show("Error! Upload file!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btn_Upload.Enabled = true;
            btn_Download.Enabled = true;

            //thread.Abort();
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 5;

            btn_Upload.Enabled = false;
            btn_Download.Enabled = false;
            UploadNewVersion();
            //thread = new Thread(new ThreadStart(UploadNewVersion));
            //thread.Start();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 5;

            btn_Upload.Enabled = false;
            btn_Download.Enabled = false;

            DownloadTheLastestVersion();
        }

        public void DownloadTheLastestVersion()
        {
            UpdateStatusProgressBar(0, "Preparing data...");

            //Step 0: Prepare data
            string sPath = Path.GetDirectoryName(Application.ExecutablePath);

            UpdateStatusProgressBar(10, "Getting lastest version...");
            //Step 1: Get the lastest version
            VersionOBJ verObj = VersionCTL.GetLastestVersion();
            if (verObj.VersionID == string.Empty)
            {
                MessageBox.Show("Error! Can't get new version!");
                return;
            }
            //string szipFilePath = sPath + "\\" + verObj.FileName;
            string szipFilePath = sPath + "\\CRM_Download.zip";

            UpdateStatusProgressBar(45, "Downloading file...");
            //Step 2: Download zip file from server and save in the Path
            if (SegmentDataCTL.DownloadFileFromServer(verObj.VersionID, szipFilePath) == false)
            {
                MessageBox.Show("Error! Can't download upload file!");
                return;
            }

            UpdateStatusProgressBar(20, "Updating file...");
            //Step 3: Extract zip file
            try
            {
                string sOutputPath = sPath + "\\tmp1";
                ZipArchiveMOD.UnzipFile(szipFilePath, sOutputPath);
            }
            catch
            {
                MessageBox.Show("Error! Can't extract zip file!");
                return;
            }

            UpdateStatusProgressBar(0, "Finished");
            MessageBox.Show("Download file successfully!");
            //Step 4: Copy and overwrite (maybe) to folder QuanLyDiem

            btn_Upload.Enabled = true;
            btn_Download.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
