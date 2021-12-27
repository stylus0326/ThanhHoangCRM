using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class Snipping : DevExpress.XtraEditors.XtraForm
    {
        Bitmap printscreen;

        public Snipping(Bitmap a)
        {
            InitializeComponent();
            printscreen = a;
        }

        private void Snipping_Load(object sender, EventArgs e)
        {
            this.Hide();
            using (MemoryStream s = new MemoryStream())
            {
                printscreen.Save(s, ImageFormat.Bmp);
                pic_origin.Image = Image.FromStream(s);
            }
            Owner.TopMost = false;
            this.Show();
            Cursor = Cursors.Cross;
        }

        //int selectX;
        //int selectY;
        //int selectWidth;
        //int selectHeight;
        //public Pen selectPen;
        //bool start = false;

        //private void Pic_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (Pic.Image == null)
        //        return;
        //    //validate if right-click was trigger
        //    if (start)
        //    {
        //        //refresh picture box
        //        Pic.Refresh();
        //        //set corner square to mouse coordinates
        //        selectWidth = e.X - selectX;
        //        selectHeight = e.Y - selectY;
        //        //draw dotted rectangle
        //        Pic.CreateGraphics().DrawRectangle(selectPen,
        //                  selectX, selectY, selectWidth, selectHeight);
        //    }
        //}

        //private void Pic_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (start)
        //    {
        //        //validate if there is image
        //        if (Pic.Image == null)
        //            return;
        //        //same functionality when mouse is over
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            Pic.Refresh();
        //            selectWidth = e.X - selectX;
        //            selectHeight = e.Y - selectY;
        //            Pic.CreateGraphics().DrawRectangle(selectPen, selectX,
        //                     selectY, selectWidth, selectHeight);

        //        }
        //        start = false;
        //        //function save image to clipboard
        //        if (selectWidth > 100)
        //            SaveToClipboard();
        //    }
        //}

        //private void Pic_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (!start)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            //starts coordinates for rectangle
        //            selectX = e.X;
        //            selectY = e.Y;
        //            selectPen = new Pen(Color.Red, 1);
        //            selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
        //        }
        //        //refresh picture box
        //        Pic.Refresh();
        //        //start control variable for draw rectangle
        //        start = true;
        //    }
        //}

        //private void SaveToClipboard()
        //{
        //    validate if something selected
        //if (selectWidth > 0)
        //    {

        //        Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
        //        //create bitmap with original dimensions
        //        Bitmap OriginalImage = new Bitmap(Pic.Image, Pic.Width, Pic.Height);
        //        //create bitmap with selected dimensions
        //        Bitmap _img = new Bitmap(selectWidth, selectHeight);
        //        //create graphic variable
        //        Graphics g = Graphics.FromImage(_img);
        //        //set graphic attributes
        //        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //        g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
        //        //insert image stream into clipboard
        //        Clipboard.SetImage(_img);
        //        System.Threading.Thread.Sleep(500);
        //    }
        //    End application
        //Close();
        //}

        private void btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            ClsChucNang.wait.SetWaitFormCaption("Thông báo");
            ClsChucNang.wait.SetWaitFormDescription("Đã sao chép hình ảnh");
            Clipboard.SetImage(pic_origin.GetCroppedImage());
            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
            Close();
        }

        private void Snipping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}