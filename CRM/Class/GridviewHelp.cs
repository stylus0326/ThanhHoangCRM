using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorPick.Picker;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CRM
{
    class GridViewHelper
    {

        public static string TEMP_PATH = Path.GetTempPath() + Assembly.GetExecutingAssembly().GetName().Name + "\\";

        public static void SetFromGrid(Form frm, GridControl GC = null, GridView GV = null)
        {
            if (GC == null)
                foreach (Control GVc in frm.Controls)
                {
                    if (GVc is GridControl)
                    {
                        if (GVc.Name.Substring(0, 2).Equals("GC"))
                        {
                            GC = GVc as GridControl;
                            GV = (GridView)GC.MainView;
                            break;
                        }
                    }
                }
            if (GC != null)
            {
                var folder = TEMP_PATH + "\\" + frm.Name + "\\" + GC.Name;
                if (!Directory.Exists(folder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folder);
                }
                var path = TEMP_PATH + "\\" + frm.Name + "\\" + GC.Name + "\\default_layout.xml";
                GC.MainView.SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
                GV.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
                GV.GroupSummary.AddRange(new GridSummaryItem[] {new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "(Số dòng: {0:#,##0;-#,##0})", null, "")});
                GV.CustomDrawCell += GridView_CustomDrawCell;
                GV.MouseWheel += GV_MouseWheel; ;
                CustomDrawEmptyForeground(GC, GV);
                GV.PopupMenuShowing += (s, e) => { AddFontAndColortoPopupMenuShowing(s, e, GC, frm.Name); };
                frm.Shown += (s, e) => { SaveAndRestoreLayout(GC, frm.Name); };
            }
        }

        private static void GV_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((sender as GridView).IsEditing)
            {
                (sender as GridView).CloseEditor();
                (sender as GridView).UpdateCurrentRow();
            }
        }

        public static void SaveAndRestoreLayout(GridControl gridControl, string FormName)
        {
            gridControl.ForceInitialize();
            var path = TEMP_PATH + "\\" + FormName + "\\" + gridControl.Name + "\\custom_layout.xml";
            if (File.Exists(path))
            {
                gridControl.ForceInitialize();
                gridControl.MainView.RestoreLayoutFromXml(path, OptionsLayoutBase.FullLayout);
            }
        }

        public static void GridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            if (!view.OptionsView.ShowAutoFilterRow || !view.IsDataRow(e.RowHandle))
                return;

            string filterCellText = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column);

            if (e.Column.ColumnType.FullName == "System.Boolean")
                return;

            if (String.IsNullOrEmpty(filterCellText))
                return;

            int filterTextIndex = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase);
            if (filterTextIndex == -1)
                return;

            DevExpress.Utils.Paint.XPaint.Graphics.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, false, filterTextIndex);
            e.Handled = true;
        }

        public static void GridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (!gridView.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    gridView.IndicatorWidth = gridView.IndicatorWidth < _Width ? _Width : gridView.IndicatorWidth;
                    //gridControl.BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                gridView.IndicatorWidth = gridView.IndicatorWidth < _Width ? _Width : gridView.IndicatorWidth;
            }
        }

        public static void GridView_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.Name != "GVCTNH")
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
                string caption = info.Column.Caption;
                if (info.Column.Caption == string.Empty)
                    caption = info.Column.ToString();
                info.GroupText = string.Format("{0} : {1} (Số dòng = {2})", caption, info.GroupValueText, view.GetChildRowCount(e.RowHandle));
            }
        }

        public static bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        public static void CustomDrawEmptyForeground(GridControl gridControl, GridView gridView)
        {
            string searchName = string.Empty;
            Font noMatchesFoundTextFont = new Font("Tahoma", 10);
            Font trySearchingAgainTextFont = new Font("Tahoma", 15, FontStyle.Underline);
            Font trySearchingAgainTextFontBold = new Font(trySearchingAgainTextFont, FontStyle.Underline | FontStyle.Bold);
            SolidBrush linkBrush = new SolidBrush(DevExpress.Skins.EditorsSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel).Colors["HyperLinkTextColor"]);
            string noMatchesFoundText = "Không tìm thấy dữ liệu, bạn ơi...";
            string trySearchingAgainText = "Nhấp vào để hủy mọi điều kiện lọc";
            Rectangle noMatchesFoundBounds = Rectangle.Empty;
            Rectangle trySearchingAgainBounds = Rectangle.Empty;
            bool trySearchingAgainBoundsContainCursor = false;
            int offset = 10;


            gridView.CustomDrawEmptyForeground += (s, e) =>
            {
                e.DefaultDraw();
                e.Appearance.Options.UseFont = true;
                e.Appearance.Font = noMatchesFoundTextFont;

                Size size = e.Appearance.CalcTextSize(e.Cache, noMatchesFoundText, e.Bounds.Width).ToSize();
                int x = (e.Bounds.Width - size.Width) / 2;
                int y = e.Bounds.Y + offset;
                noMatchesFoundBounds = new Rectangle(new Point(x, y), size);
                e.Appearance.DrawString(e.Cache, noMatchesFoundText, noMatchesFoundBounds);

                e.Appearance.Font = trySearchingAgainBoundsContainCursor ? trySearchingAgainTextFontBold : trySearchingAgainTextFont;
                size = e.Appearance.CalcTextSize(e.Cache, trySearchingAgainText, e.Bounds.Width).ToSize();
                x = noMatchesFoundBounds.X - (size.Width - noMatchesFoundBounds.Width) / 2;
                y = noMatchesFoundBounds.Bottom + offset;
                size.Width += offset;
                trySearchingAgainBounds = new Rectangle(new Point(x, y), size);
                e.Appearance.DrawString(e.Cache, trySearchingAgainText, trySearchingAgainBounds, linkBrush);

                GridViewInfo vi = (GridViewInfo)gridView.GetViewInfo();
                var image = global::CRM.Properties.Resource.Untitled_1;

                int a = (gridControl.Width < image.Width) ? 2 : 1;

                var imageStartX = (vi.ViewRects.EmptyRows.X + (vi.ViewRects.EmptyRows.Width / 2)) - (image.Width / a / 2);

                var imageStartY = (vi.ViewRects.EmptyRows.Y + (vi.ViewRects.EmptyRows.Height / 2)) - (image.Height / a / 2) + 40;

                var rect = new Rectangle(imageStartX, imageStartY, image.Width / a, image.Height / a);
                e.Graphics.DrawImage(image, rect);
            };


            gridView.MouseMove += (s, e) =>
            {
                trySearchingAgainBoundsContainCursor = trySearchingAgainBounds.Contains(e.Location);
                gridControl.Cursor = trySearchingAgainBoundsContainCursor ? (gridView.RowCount < 1) ? Cursors.Hand : Cursors.Default : Cursors.Default;
                gridView.InvalidateRect(trySearchingAgainBounds);
            };

            gridView.MouseDown += (s, e) =>
            {
                if (gridView.RowCount < 1)
                    if (trySearchingAgainBoundsContainCursor)
                        gridView.ActiveFilter.Clear();
            };
        }

        public static Image createImage(Color color)
        {
            Bitmap flag = new Bitmap(16, 16);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Pen blackPen = new Pen(Color.Black, 2);
            Rectangle rect = new Rectangle(0, 0, 16, 16);
            flagGraphics.DrawRectangle(blackPen, rect);
            flagGraphics.FillRectangle(new SolidBrush(color), 1, 1, 14, 14);
            return flag;
        }

        public static void AddFontAndColortoPopupMenuShowing(object sender, PopupMenuShowingEventArgs e, GridControl gridcontrol, string FormName)
        {
            //nếu sử dụng thì tích hợp save layout.          
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                //menu.Items.Clear();
                if (menu.Column != null)
                {
                    var renameCap = new DXMenuCheckItem("Đổi tên cột");
                    renameCap.ImageOptions.SvgImage = Properties.Resource.editnames;
                    renameCap.Click += (ss, ee) =>
                    {
                        var caption = menu.Column.Caption;
                        frmRenameCaption frm = new frmRenameCaption(caption);

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            menu.Column.Caption = frm.Caption;
                        }
                    };

                    menu.Items.Add(renameCap);

                    var fixLeft = new DXMenuCheckItem("Ghim Trái");
                    fixLeft.ImageOptions.SvgImage = Properties.Resource.showlegendinsideverticalcenterleft;
                    menu.Items.Add(fixLeft);
                    fixLeft.Click += (ss, ee) =>
                    {
                        menu.Column.Fixed = FixedStyle.Left;
                    };

                    var fixRight = new DXMenuCheckItem("Ghim Phải");
                    fixRight.ImageOptions.SvgImage = Properties.Resource.showlegendinsideverticalcenterright;
                    menu.Items.Add(fixRight);
                    fixRight.Click += (ss, ee) =>
                    {
                        menu.Column.Fixed = FixedStyle.Right;
                    };

                    var unFix = new DXMenuCheckItem("Xóa Ghim");
                    unFix.ImageOptions.SvgImage = Properties.Resource.manual;
                    unFix.Enabled = menu.Column.Fixed != FixedStyle.None;
                    menu.Items.Add(unFix);
                    unFix.Click += (ss, ee) =>
                    {
                        menu.Column.Fixed = FixedStyle.None;
                    };
                    // font chữ

                    DXMenuCheckItem font = new DXMenuCheckItem("Fonts", true);
                    font.ImageOptions.SvgImage = Properties.Resource.changetextcase;
                    font.Click += new EventHandler(OnFixedClick);
                    font.Tag = new MenuInfo(menu.Column, FixedStyle.None);
                    menu.Items.Add(font);

                    // Màu nền
                    DXSubMenuItem sItem = new DXSubMenuItem("Màu Nền");
                    sItem.ImageOptions.SvgImage = Properties.Resource.pagecolor;
                    Color mauhong = ColorTranslator.FromHtml("#FFC2BE");
                    Color mauxanh = ColorTranslator.FromHtml("#A8D5FF");
                    Color xanhduong = ColorTranslator.FromHtml("#C1F49C");
                    Color mauvang = ColorTranslator.FromHtml("#FEF7A5");
                    Color mautim = ColorTranslator.FromHtml("#E0CFE9");
                    Color xanhlam = ColorTranslator.FromHtml("#8DE9DF");
                    Color mautrang = ColorTranslator.FromHtml("#FFFFFF");
                    Color mauden = ColorTranslator.FromHtml("#000000");

                    sItem.Items.Add(CreateCheckItem("Color White", menu.Column, FixedStyle.None, mautrang));
                    sItem.Items.Add(CreateCheckItem("Color Black", menu.Column, FixedStyle.None, mauden));
                    sItem.Items.Add(CreateCheckItem("Color Pink", menu.Column, FixedStyle.None, mauhong));
                    sItem.Items.Add(CreateCheckItem("Color Blue", menu.Column, FixedStyle.None, mauxanh));
                    sItem.Items.Add(CreateCheckItem("Color Green", menu.Column, FixedStyle.None, xanhduong));
                    sItem.Items.Add(CreateCheckItem("Color Yellow", menu.Column, FixedStyle.None, mauvang));
                    sItem.Items.Add(CreateCheckItem("Color Purple", menu.Column, FixedStyle.None, mautim));
                    sItem.Items.Add(CreateCheckItem("Color Cyan", menu.Column, FixedStyle.None, xanhlam));

                    sItem.Items.Add(CreateCheckItem("Color Customize...", menu.Column, FixedStyle.None, Color.Transparent));
                    menu.Items.Add(sItem);

                    // màu chữ
                    var mauchu = new DXSubMenuItem("Màu Chữ");
                    mauchu.ImageOptions.SvgImage = Properties.Resource.floatingobjectfillcolor;
                    Color Red = Color.Red;
                    Color pink = ColorTranslator.FromHtml("#E91E63");
                    Color purple = ColorTranslator.FromHtml("#9C27B0");
                    Color DeepPurple = ColorTranslator.FromHtml("#673AB7");
                    Color Indigo = ColorTranslator.FromHtml("#E0CFE9");
                    Color blue = ColorTranslator.FromHtml("#3F51B5");
                    Color cyan = ColorTranslator.FromHtml("#00BCD4");
                    Color Teal = ColorTranslator.FromHtml("#009688");
                    Color green = ColorTranslator.FromHtml("#4CAF50");
                    Color Lime = ColorTranslator.FromHtml("#CDDC39");
                    Color Amber = ColorTranslator.FromHtml("#FFC107");
                    Color Orange = ColorTranslator.FromHtml("#FF9800");
                    Color depOrange = ColorTranslator.FromHtml("#FF5722");
                    Color brown = ColorTranslator.FromHtml("#795548");
                    Color grey = ColorTranslator.FromHtml("#9E9E9E");
                    Color BlueGrey = ColorTranslator.FromHtml("#607D8B");
                    Color Black = ColorTranslator.FromHtml("#000000");
                    Color White = ColorTranslator.FromHtml("#FFFFFF");

                    mauchu.Items.Add(CreateCheckItem("Black", menu.Column, FixedStyle.None, Black));
                    mauchu.Items.Add(CreateCheckItem("White", menu.Column, FixedStyle.None, White));
                    mauchu.Items.Add(CreateCheckItem("Pink", menu.Column, FixedStyle.None, pink));
                    mauchu.Items.Add(CreateCheckItem("Purple", menu.Column, FixedStyle.None, purple));
                    mauchu.Items.Add(CreateCheckItem("Deep Purple", menu.Column, FixedStyle.None, DeepPurple));
                    mauchu.Items.Add(CreateCheckItem("Indigo", menu.Column, FixedStyle.None, Indigo));
                    // mauchu.Items.Add(CreateCheckItem("Red", menu.Column, FixedStyle.None, Red));
                    mauchu.Items.Add(CreateCheckItem("Blue", menu.Column, FixedStyle.None, blue));
                    mauchu.Items.Add(CreateCheckItem("Cyan", menu.Column, FixedStyle.None, cyan));
                    mauchu.Items.Add(CreateCheckItem("Teal", menu.Column, FixedStyle.None, Teal));
                    mauchu.Items.Add(CreateCheckItem("Green", menu.Column, FixedStyle.None, green));
                    mauchu.Items.Add(CreateCheckItem("Lime", menu.Column, FixedStyle.None, Lime));
                    mauchu.Items.Add(CreateCheckItem("Amber", menu.Column, FixedStyle.None, Amber));
                    mauchu.Items.Add(CreateCheckItem("Orange", menu.Column, FixedStyle.None, Orange));
                    mauchu.Items.Add(CreateCheckItem("Deep Orange", menu.Column, FixedStyle.None, depOrange));
                    mauchu.Items.Add(CreateCheckItem("Brown", menu.Column, FixedStyle.None, brown));
                    mauchu.Items.Add(CreateCheckItem("Grey", menu.Column, FixedStyle.None, grey));
                    mauchu.Items.Add(CreateCheckItem("Blue Grey", menu.Column, FixedStyle.None, BlueGrey));

                    mauchu.Items.Add(CreateCheckItem("ForeColor Customize...", menu.Column, FixedStyle.None, Color.Transparent));
                    menu.Items.Add(mauchu);

                    DXMenuCheckItem save_layout = new DXMenuCheckItem("Lưu Kiểu", true);
                    save_layout.ImageOptions.SvgImage = Properties.Resource.saveas;
                    save_layout.CheckedChanged += (ss, ee) =>
                    {
                        var path = TEMP_PATH + "\\" + FormName + "\\" + gridcontrol.Name + "\\custom_layout.xml";
                        gridcontrol.MainView.SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
                        //FrmMain.Instance.ShowMessageInfo("Đã lưu cấu hình layout.");
                    };
                    DXMenuCheckItem reset_layout = new DXMenuCheckItem("Kiểu mặc định", true);
                    reset_layout.CheckedChanged += (ss, ee) =>
                    {
                        var path = TEMP_PATH + "\\" + FormName + "\\" + gridcontrol.Name + "\\default_layout.xml";
                        var path_custom = TEMP_PATH + "\\" + FormName + "\\" + gridcontrol.Name + "\\custom_layout.xml";
                        if (File.Exists(path))
                        {
                            gridcontrol.MainView.RestoreLayoutFromXml(path, OptionsLayoutBase.FullLayout);
                            //FrmMain.Instance.ShowMessageInfo("Reset layout thành công.");
                        }

                        if (File.Exists(path_custom))
                        {
                            File.Delete(path_custom);
                        }

                    };
                    reset_layout.ImageOptions.SvgImage = Properties.Resource.bo_audit_changehistory;
                    menu.Items.Add(save_layout);
                    menu.Items.Add(reset_layout);
                }
            }
        }

        //Create a menu item 
        public static DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, FixedStyle style, Color color)
        {
            Image image = createImage(color);
            DXMenuCheckItem item = new DXMenuCheckItem(caption, column.Fixed == style, image, new EventHandler(OnFixedClick));
            item.Tag = new MenuInfo(column, style);
            return item;
        }

        //Menu item click handler 
        public static void OnFixedClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuInfo info = item.Tag as MenuInfo;
            if (info == null) return;

            if (item.Caption.Substring(0, 3) == "Col")
            {
                if (item.Caption == "Color Customize...")
                {
                    ColorPickEdit colorPickerEdit = new ColorPickEdit();
                    FrmColorPicker frm = new FrmColorPicker(colorPickerEdit.Properties);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.TopMost = true;
                    if (frm.ShowDialog(colorPickerEdit.FindForm()) == DialogResult.OK)
                    {
                        info.Column.AppearanceCell.BackColor = frm.SelectedColor;
                    }

                }
                else
                {
                    info.Column.AppearanceCell.BackColor = ((Bitmap)item.Image).GetPixel(5, 5);
                }
            }
            else if (item.Caption.Substring(0, 4) == "Font")
            {
                FontDialog fontDialog = new FontDialog();
                fontDialog.ShowDialog();
                info.Column.AppearanceCell.Font = fontDialog.Font;
            }
            else
            {
                if (item.Caption == "ForeColor Customize...")
                {
                    ColorPickEdit colorPickerEdit = new ColorPickEdit();
                    FrmColorPicker frm = new FrmColorPicker(colorPickerEdit.Properties);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.TopMost = true;
                    if (frm.ShowDialog(colorPickerEdit.FindForm()) == System.Windows.Forms.DialogResult.OK)
                    {
                        info.Column.AppearanceCell.ForeColor = frm.SelectedColor;
                    }

                }
                else
                {
                    info.Column.AppearanceCell.ForeColor = ((Bitmap)item.Image).GetPixel(5, 5);
                }
            }


        }
        class MenuInfo
        {
            public MenuInfo(GridColumn column, FixedStyle style)
            {
                this.Column = column;
                this.Style = style;
            }
            public FixedStyle Style;
            public GridColumn Column;
        }
    }
}