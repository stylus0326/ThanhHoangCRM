using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsFormsSettings.AllowPixelScrolling = DefaultBoolean.True;

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            UserLookAndFeel.Default.SetSkinStyle("Money Twins");

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
            Application.Run(new frmDangNhap());
            //Vmtkb2FHSnRhRWxpTWtaMVdqQk9VMVJWUWxWV1JsSlZWbFUxU0ZGRVFYaE5SRVY1VFVSSmVGRkVWVDA9
        }
    }
}