using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Drawing;
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

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\THCRM");
            if (key != null && key.GetValue("Skin") != null)
                UserLookAndFeel.Default.SetSkinStyle(key.GetValue("Skin").ToString());
            else
                UserLookAndFeel.Default.SetSkinStyle("Money Twins");
            if (key != null)
                if (key.GetValue("Color") != null)
                {
                    ClsGiaoDien.KichThoatMau = key.GetValue("Color").ToString().Length > 1;
                    if (ClsGiaoDien.KichThoatMau)
                        ClsGiaoDien.MauChon = Color.FromArgb(Convert.ToInt32(key.GetValue("Color").ToString(), 16));
                }

            //WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Fluent;


            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
            Application.Run(new frmDangNhap());
            //Vmtkb2FHSnRhRWxpTWtaMVdqQk9VMVJWUWxWV1JsSlZWbFUxU0ZGRVFYaE5SRVY1VFVSSmVGRkVWVDA9
        }
    }
}