using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CRM
{
    class ClsGiaoDien
    {
        #region Tô màu control được chọn
        public static bool KichThoatMau = true;
        public static Color MauChon = Color.Crimson;
        public static string TEMP_PATH = Path.GetTempPath() + Assembly.GetExecutingAssembly().GetName().Name;
        static string frmName = "";
        public static void FocusControl(Control ctrl)
        {
            if (ctrl.GetType() == typeof(TextEdit))
            {
                (ctrl as TextEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as TextEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as TextEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as TextEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as TextEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(DateEdit))
            {
                (ctrl as DateEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as DateEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as DateEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as DateEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as DateEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(LookUpEdit))
            {
                (ctrl as LookUpEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as LookUpEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as LookUpEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as LookUpEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as LookUpEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(SearchLookUpEdit))
            {
                (ctrl as SearchLookUpEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as SearchLookUpEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as SearchLookUpEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as SearchLookUpEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as SearchLookUpEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(MemoEdit))
            {
                (ctrl as MemoEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as MemoEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as MemoEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as MemoEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as MemoEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(SpinEdit))
            {
                (ctrl as SpinEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as SpinEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as SpinEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as SpinEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as SpinEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(CheckEdit))
            {
                (ctrl as CheckEdit).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as CheckEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    (ctrl as CheckEdit).Properties.Appearance.BorderColor = MauChon;
                });
                (ctrl as CheckEdit).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as CheckEdit).BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                });
            }

            else if (ctrl.GetType() == typeof(GroupControl))
            {
                (ctrl as GroupControl).Enter += new EventHandler((s, e) =>
                {
                    (ctrl as GroupControl).Appearance.BorderColor = MauChon;
                });
                (ctrl as GroupControl).Leave += new EventHandler((s, e) =>
                {
                    (ctrl as GroupControl).Appearance.BorderColor = Color.Transparent;
                });
            }

            foreach (Control ctrlChild in ctrl.Controls)
                FocusControl(ctrlChild);
        }

        public static void setGrid(Control ctrl)
        {
            if (ctrl.GetType() == typeof(GridControl))
            {
                if (ctrl.Name.Substring(0, 2).Equals("GC"))
                {
                    string gridName = (ctrl as GridControl).Name;


                    var folder = TEMP_PATH + "\\" + frmName + "\\" + gridName;
                    if (!Directory.Exists(folder))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folder);
                    }
                    var path = TEMP_PATH + "\\" + frmName + "\\" + gridName + "\\default_layout.xml";
                    (ctrl as GridControl).MainView.SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
                    ((GridView)(ctrl as GridControl).MainView).CustomDrawRowIndicator += GridViewHelper.GridView_CustomDrawRowIndicator;
                    ((GridView)(ctrl as GridControl).MainView).GroupSummary.AddRange(new GridSummaryItem[] { new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "(Số dòng: {0:#,##0;-#,##0})", null, "") });
                    ((GridView)(ctrl as GridControl).MainView).CustomDrawCell += GridViewHelper.GridView_CustomDrawCell;
                    ((GridView)(ctrl as GridControl).MainView).MouseWheel += GridViewHelper.GV_MouseWheel; ;
                    GridViewHelper.CustomDrawEmptyForeground((ctrl as GridControl), ((GridView)(ctrl as GridControl).MainView));
                    ((GridView)(ctrl as GridControl).MainView).PopupMenuShowing += (s, e) => { GridViewHelper.AddFontAndColortoPopupMenuShowing(s, e, (ctrl as GridControl), frmName); };
                    GridViewHelper.SaveAndRestoreLayout(ctrl as GridControl, TEMP_PATH + "\\" + frmName + "\\" + gridName + "\\custom_layout.xml");
                }
            }
            foreach (Control ctrlChild in ctrl.Controls)
                setGrid(ctrlChild);
        }
        #endregion

    }
}
