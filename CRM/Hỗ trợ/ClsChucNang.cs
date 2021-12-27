using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    class ClsChucNang
    {
        #region Instance
        private static ClsChucNang instance;

        public static ClsChucNang Ins
        {
            get
            {
                if (instance == null) instance = new ClsChucNang(); return instance;
            }
            set
            {
                instance = value;
            }
        }

        private ClsChucNang() { }
        #endregion

        #region Thông báo taskbar
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }
        public const uint FLASHW_STOP = 0;
        public const uint FLASHW_CAPTION = 1;
        public const uint FLASHW_TRAY = 2;
        public const uint FLASHW_ALL = 3;
        public const uint FLASHW_TIMER = 4;
        public const uint FLASHW_TIMERNOFG = 12;
        private static bool Flash(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }
        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }

        public static bool Start(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }
        public static bool Stop(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }
        private static bool Win2000OrLater
        {
            get { return System.Environment.OSVersion.Version.Major >= 5; }
        }

        public static bool NhapNhayTaskBar(System.Windows.Forms.Form form, uint count)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }
        #endregion

        public static void OpenForm(Form frm)
        {
            if (ClsGiaoDien.KichThoatMau)
                ClsGiaoDien.FocusControl(frm);
            new Thread(() =>
            {
                frm.KeyPreview = true;
                for (double i = 0; i <= 1; i += 0.1)
                {
                    frm.Invoke(new MethodInvoker(() =>
                    {
                        frm.Opacity = i;
                    }));
                    Thread.Sleep(10);
                }

                frm.Invoke(new MethodInvoker(() =>
                {
                    frm.Opacity = 1;
                }));

                frm.KeyDown += (s, e) =>
                {
                    if (e.Control && e.KeyCode == Keys.D1 && !frm.Name.Equals("frmChinh"))
                    {
                        using (var g = new Bitmap(frm.Width, frm.Height))
                        {
                            frm.DrawToBitmap(g, new Rectangle(0, 0, g.Width, g.Height));
                            Clipboard.SetImage(g);

                            if (!wait.IsSplashFormVisible)
                                wait.ShowWaitForm();
                            wait.SetWaitFormCaption("Thông báo");
                            wait.SetWaitFormDescription("Đã sao chép hình ảnh");
                            Thread.Sleep(500);
                            if (wait.IsSplashFormVisible)
                                wait.CloseWaitForm();
                        }
                    }
                    else if (e.Control && e.KeyCode == Keys.D2)
                    {
                        frm.TopMost = true;
                        Bitmap g;
                        if (frm.Name.Equals("frmChinh"))
                        {
                            g = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                          Screen.PrimaryScreen.Bounds.Height);
                            Graphics graphics = Graphics.FromImage(g as Image);
                            graphics.CopyFromScreen(0, 0, 0, 0, g.Size);
                        }
                        else
                        {
                            g = new Bitmap(frm.Width, frm.Height);
                            frm.DrawToBitmap(g, new Rectangle(0, 0, g.Width, g.Height));
                        }
                        new Snipping(g).ShowDialog(frm);
                    }
                    else if (e.Control && e.KeyCode == Keys.D3)
                    {
                        if (wait.IsSplashFormVisible)
                            wait.CloseWaitForm();
                    }
                };

                GridViewHelper.SetFromGrid(frm);
            }).Start();
        }

        public static DevExpress.XtraSplashScreen.SplashScreenManager wait;
        public static void SplashScreen(Form frm)
        {
            wait = new DevExpress.XtraSplashScreen.SplashScreenManager(frm, typeof(global::CRM.CRMWaitForm), true, true);
        }
    }
}
