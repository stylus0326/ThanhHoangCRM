using System;
using System.Drawing;

namespace CRM
{
    public partial class frmXemAnh : DevExpress.XtraEditors.XtraForm
    {
        public frmXemAnh(Image image)
        {
            InitializeComponent();
            pictureEdit1.Image = image;
        }

        private void frmXemAnh_Load(object sender, EventArgs e)
        {
            ClsChucNang.OpenForm(this);
        }

        private void frmXemAnh_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}