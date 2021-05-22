using System.Drawing;

using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;

namespace CRM
{
    public class CustomOverlayWindowPainter : OverlayWindowPainterBase
    {


        private static readonly Font _font;

        static CustomOverlayWindowPainter()
        {
            _font = new Font("Tahoma", 16, FontStyle.Bold);
        }

        protected override void Draw(OverlayWindowCustomDrawContext context)
        {
            context.Handled = true;

            GraphicsCache cache = context.DrawArgs.Cache;

            cache.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;


            Rectangle boundRectangle = context.DrawArgs.Bounds;

            context.DrawBackground();

            string message = "";

            SizeF textSize = cache.Graphics.MeasureString(message, _font);

            PointF point = new PointF
            (
                (boundRectangle.Width - textSize.Width) / 2,
                (boundRectangle.Height - textSize.Height) / 2
            );

            cache.Graphics.DrawString(message, _font, Brushes.Black, point);
        }


    }
}
