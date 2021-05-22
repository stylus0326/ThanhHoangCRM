using System;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmRenameCaption : DevExpress.XtraEditors.XtraForm
    {
        // public string Result;
        public string Caption;
        public frmRenameCaption(string caption)
        {
            InitializeComponent();
            Caption = caption;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txt_name.Text = Caption;
            txt_name.SelectAll();
            txt_name.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Caption = txt_name.Text;
            this.Close();
        }

        private void FrmRenameCaption_Load(object sender, EventArgs e)
        {
            XuLyGiaoDien.OpenForm(this);
        }

        private void FrmRenameCaption_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}