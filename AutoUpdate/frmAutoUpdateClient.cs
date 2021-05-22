using AutoUpdate.Controllers;
using AutoUpdate.Objects;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace AutoUpdate
{
    public partial class frmAutoUpdateClient : Form
    {
        public Thread thread;

        public frmAutoUpdateClient()
        {
            InitializeComponent();
        }

        public void UpdateStatusProgressBar(int value, string status = "")
        {
            progressBar1.Value += value;
            progressBar1.PerformStep();


            int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);

            if (status != string.Empty)
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "% - " + status, new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 60, progressBar1.Height / 2 - 7));
            else
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 60, progressBar1.Height / 2 - 7));


        }

        public bool DownloadTheLastestVersion()
        {
            bool result = true;
            UpdateStatusProgressBar(0, "Chuẩn bị dữ liệu...");

            //Step 0: Prepare data
            string sPath = Path.GetDirectoryName(Application.ExecutablePath);

            UpdateStatusProgressBar(10, "Đang lấy thông tin phiên bản mới...");
            //Step 1: Get the lastest version
            VersionOBJ verObj = VersionCTL.GetLastestVersion();
            if (verObj.VersionID == string.Empty)
            {
                MessageBox.Show("Lỗi! Không thể cập nhật phiên bản mới!");
                return false;
            }

            string szipFilePath = sPath + "\\CRM_ver_" + verObj.VersionID + ".zip";

            UpdateStatusProgressBar(45, "Đang tải tập tin...");
            //Step 2: Download zip file from server and save in the Path
            if (SegmentDataCTL.DownloadFileFromServer(verObj.VersionID, szipFilePath) == false)
            {
                MessageBox.Show("Lỗi! Không thể tải tập tin!");
                return false;
            }

            UpdateStatusProgressBar(20, "Đang cập nhật phiên bản mới...");
            //Step 3: Extract zip file
            try
            {
                string sOutputPath = sPath;
                ZipArchiveMOD.UnzipFile(szipFilePath, sOutputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể giải nVN tập tin! Chi tiết: " + ex.Message);
                return false;
            }

            UpdateStatusProgressBar(0, "Hoàn tất");
            //Step 4: Write a new version to file
            string sfileVerPath = sPath + "\\version.dat";
            VersionCTL.WriteNewVersion(verObj, sfileVerPath);
            File.Delete(szipFilePath);
            MessageBox.Show("Cập nhật phiên bản mới thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public bool CheckNewVersion()
        {
            bool result;

            //result = true;

            VersionOBJ verObj = VersionCTL.GetLastestVersion();
            if (verObj.VersionID == string.Empty)
            {
                return false;
            }

            string sPath = Path.GetDirectoryName(Application.ExecutablePath);
            string sfilePath = sPath + "\\version.dat";
            string sCurVersionID = VersionCTL.ReadCurrentVersion(sfilePath);
            if (sCurVersionID == string.Empty || verObj.VersionID != sCurVersionID)
                result = true;
            else
                result = false;

            return result;
        }

        public void StopApplication(string AppName)
        {
            if (AppName != null)
            {
                Process[] pProcess;
                pProcess = System.Diagnostics.Process.GetProcessesByName(AppName);

                foreach (Process p in pProcess)
                {
                    p.Kill();
                }
            }
        }

        public void StartApplication(string sfilePath)
        {
            try
            {
                Process.Start(sfilePath);
            }
            catch (Exception ex)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            if (CheckNewVersion() == true)
            {
                this.WindowState = FormWindowState.Normal;
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Step = 5;
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            //Stop ung dung
            StopApplication("ThanhHoangCRM");

            lbl_Status.Text = "Đang tải phiên bản cập nhật, vui lòng chờ ...";

            if (DownloadTheLastestVersion() == true)
            {
                string sPath = Path.GetDirectoryName(Application.ExecutablePath);
                string sfilePath = sPath + "\\ThanhHoangCRM.exe";
                StartApplication(sfilePath);
            }
            Application.Exit();
        }

        private void frmAutoUpdateClient_Load(object sender, EventArgs e)
        {

        }
    }
}
