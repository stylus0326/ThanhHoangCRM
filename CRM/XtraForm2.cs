using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CRM
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm2()
        {
            InitializeComponent();
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pic_origin.Image = Image.FromFile(dlg.FileName);
            }
        }

        private void btn_crop_Click(object sender, EventArgs e)
        {
            Image croppedImage = pic_origin.GetCroppedImage();
            pic_crop.Image = croppedImage;
        }
    }
}