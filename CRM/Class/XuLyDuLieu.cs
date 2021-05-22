using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRM
{
    class XuLyDuLieu
    {
        public static string NotVietKey(string value)
        {
            string stFormD = value.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        public static bool IsNumeric(string value)
        {
            try
            {
                double Check;
                return double.TryParse(value.Replace("-", string.Empty), out Check);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static long ConvertStringToLong(string str)
        {
            return long.Parse(new String(str.Where(Char.IsDigit).ToArray()));
        }

        public static DateTime IsDate(string date)
        {
            int M = 0;
            int D = 0;
            int Y = 0;
            int H = 0;
            int m = 0;
            int s = 0;
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            string[] format = date.Replace("/", " ").Replace("-", " ").Split(' ');

            List<int> lstInt = new List<int>();
            List<string> lstStr = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                if (regex.IsMatch(format[i]))
                    lstInt.Add(int.Parse(format[i]));
                else
                    lstStr.Add(format[i]);
            }

            Y = lstInt.Max(); //Số cao nhất là năm
            lstInt.Remove(lstInt.Max()); // Xóa năm ra khỏi danh sách số

            if (lstInt.Count == 1)//tháng định dạng chữ
            {
                D = lstInt.Min();
                M = DateTime.ParseExact(lstStr[0], "MMM", System.Globalization.CultureInfo.CurrentCulture).Month;
            }
            else if (lstInt.Count == 2)
            {
                if (lstInt.Max() > 12)//ngày lớn hơn 12
                {
                    D = lstInt.Max();
                    M = lstInt.Min();
                }
                else if (lstInt[1] == lstInt[0])
                    M = D = lstInt.Max();
                else
                {
                    int Mnow = DateTime.Now.Month;
                    int Dnow = DateTime.Now.Day;
                    if (Mnow == lstInt.Max())
                    {
                        D = lstInt.Min();
                        M = lstInt.Max();
                    }
                    else
                    {
                        D = lstInt.Max();
                        M = lstInt.Min();
                    }
                }
            }

            foreach (string b in lstStr)
            {
                if (b.Length > 4)//Giờ
                {
                    H += int.Parse(b.Split(':')[0]);
                    m += int.Parse(b.Split(':')[1]);
                    s += int.Parse(b.Split(':')[2]);
                }
                if (b.Length == 2 && "PM".Equals(b)) //Giờ định dạng AM/PM
                    H += 12;
            }
            if (H == 24)
                H = 0;
            return new DateTime(Y, M, D, H, m, s);
        }

        #region Chuyển Class qua Form
        public static Dictionary<string, object> ConvertClassToTable<T>(Form frm, T t) where T : new()
        {
            foreach (Control ctl in frm.Controls)
            {
                if (ctl.Name.StartsWith("i") && ctl.Enabled)
                {
                    if (ctl is GroupControl || ctl is PanelControl || ctl is LayoutControl)
                    {
                        foreach (Control _ctl in ctl.Controls)
                        {
                            if (_ctl.Name.StartsWith("i") && ctl.Enabled)
                                SetControl(_ctl, t.GetType().GetProperties().Where(w => w.Name.Equals(_ctl.Name.Substring(1))).ToList()[0].GetValue(t, null));
                        }
                    }
                    else
                        SetControl(ctl, t.GetType().GetProperties().Where(w => w.Name.Equals(ctl.Name.Substring(1))).ToList()[0].GetValue(t, null));
                }
            }
            return BanTam(frm);
        }

        static void SetControl(Control ctl, object propertyInfo)
        {
            if (propertyInfo != null)
            {
                if (ctl is PictureEdit)
                    (ctl as PictureEdit).Image = byteArrayToImage((byte[])propertyInfo);
                else if (ctl is CheckEdit)
                    (ctl as CheckEdit).Checked = (bool)propertyInfo;
                else if (ctl is ComboBoxEdit)
                    (ctl as ComboBoxEdit).SelectedIndex = (int)propertyInfo;
                else if (ctl is SearchLookUpEdit)
                    (ctl as SearchLookUpEdit).EditValue = propertyInfo;
                else if (ctl is LookUpEdit)
                {
                    if (IsNumeric(propertyInfo.ToString()))
                        (ctl as LookUpEdit).EditValue = int.Parse(propertyInfo.ToString());
                    else
                        (ctl as LookUpEdit).EditValue = propertyInfo;
                }
                else if (ctl is DateEdit)
                {
                    try { (ctl as DateEdit).DateTime = (DateTime)propertyInfo; }
                    catch { (ctl as DateEdit).DateTime = DateTime.Now; }
                }
                else if (ctl is ColorEdit)
                    (ctl as ColorEdit).EditValue = propertyInfo;
                else if (ctl is SpinEdit)
                    (ctl as SpinEdit).Value = decimal.Parse(propertyInfo.ToString());
                else
                    (ctl as TextEdit).Text = propertyInfo.ToString();
            }
            else if (ctl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
                (ctl as TextEdit).Text = string.Empty;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Dictionary<string, object> BanTam(Form frm)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (Control ctl in frm.Controls)
            {
                if (ctl.Name.StartsWith("i"))
                    if (ctl is GroupControl || ctl is PanelControl || ctl is LayoutControl)
                        foreach (Control _ctl in ctl.Controls)
                        {
                            if (_ctl.Name.StartsWith("i"))
                                TaoDicBanTam(_ctl, dic);
                        }
                    else
                        TaoDicBanTam(ctl, dic);
            }
            return dic;
        }
        #endregion

        #region Chuyển từ Form qua Dictionary
        public static Dictionary<string, object> FormToDictionary(Form frm, Dictionary<string, object> dic)
        {
            foreach (Control ctl in frm.Controls)
            {
                if (ctl.Name.StartsWith("i"))
                    if (ctl is GroupControl || ctl is PanelControl || ctl is LayoutControl)
                        foreach (Control _ctl in ctl.Controls)
                        {
                            if (_ctl.Name.StartsWith("i"))
                                CreateKeyDic(_ctl, dic);
                        }
                    else
                        CreateKeyDic(ctl, dic);
            }
            return dic;
        }

        public static Dictionary<string, object> FlyToDictionary(FlyoutPanelControl frm)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (Control ctl in frm.Controls)
            {
                if (ctl.Name.StartsWith("u"))
                    CreateKeyDic(ctl, dic);
            }
            return dic;
        }

        public static byte[] ImageToByteArray(Image img, string anme)
        {
            using (var ms = new MemoryStream())
            {
                var ratioX = (double)300 / img.Width;
                var ratioY = (double)300 / img.Height;
                var ratio = Math.Min(ratioX, ratioY);


                var newWidth = (int)(img.Width * ratio);
                var newHeight = (int)(img.Height * ratio);

                if (anme != "iAnhCty")
                {
                    newWidth = img.Width;
                    newHeight = img.Height;
                }
                Bitmap bmp = new Bitmap(img.Width, img.Height);
                Graphics graphic = Graphics.FromImage((Image)bmp);
                graphic.DrawImage(img, 0, 0, newWidth, newHeight);
                graphic.Dispose();
                ((Image)bmp).Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        static void CreateKeyDic(Control ctl, Dictionary<string, object> dic)
        {
            string Ten = ctl.Name.Substring(1);
            if (!dic.ContainsKey(Ten))
            {
                if (ctl is PictureEdit && (ctl as PictureEdit).Image != null)
                    dic.Add(Ten, ImageToByteArray((ctl as PictureEdit).Image, ctl.Name));
                else if (ctl is CheckEdit)
                    dic.Add(Ten, (ctl as CheckEdit).Checked);
                else if (ctl is ComboBoxEdit)
                    dic.Add(Ten, (ctl as ComboBoxEdit).SelectedIndex);
                else if (ctl is SearchLookUpEdit)
                    dic.Add(Ten, (ctl as SearchLookUpEdit).EditValue);
                else if (ctl is LookUpEdit)
                    dic.Add(Ten, (ctl as LookUpEdit).EditValue);
                else if (ctl is DateEdit)
                    dic.Add(Ten, (ctl as DateEdit).DateTime);
                else if (ctl is ColorEdit)
                    dic.Add(Ten, ((Color)(ctl as ColorEdit).EditValue).ToArgb());
                else if (ctl is SpinEdit)
                    dic.Add(Ten, (ctl as SpinEdit).Value);
                else if (ctl is CheckedListBoxControl)
                    foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem check in (ctl as CheckedListBoxControl).Items)
                    { dic.Add(NotVietKey(check.Description).Replace(" ", string.Empty), (check.CheckState == CheckState.Checked)); }
                else if (ctl is TextEdit)
                    dic.Add(Ten, (ctl as TextEdit).Text.TrimEnd().TrimStart());
            }
        }

        #endregion

        #region Tạo Ghi Chú
        public static List<Dictionary<string, object>> BanTamGrid(GridView view)
        {
            List<Dictionary<string, object>> lstDic = new List<Dictionary<string, object>>();
            for (int i = 0; i < view.RowCount; i++)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                for (int y = 0; y < view.Columns.Count; y++)
                {
                    dic.Add(view.Columns[y].Name, view.GetRowCellDisplayText(i, view.Columns[y]));
                }
                lstDic.Add(dic);
            }
            return lstDic;
        }


        static void TaoDicBanTam(Control ctl, Dictionary<string, object> dic)
        {
            string Ten = ctl.Name.Substring(1);
            if (ctl is PictureEdit && (ctl as PictureEdit).Image != null)
                dic.Add(Ten, ImageToByteArray((ctl as PictureEdit).Image, ctl.Name));
            else if (ctl is CheckEdit)
                dic.Add(Ten, (ctl as CheckEdit).Checked);
            else if (ctl is ComboBoxEdit)
                dic.Add(Ten, (ctl as ComboBoxEdit).Text);
            else if (ctl is SearchLookUpEdit)
                dic.Add(Ten, (ctl as SearchLookUpEdit).Text);
            else if (ctl is LookUpEdit)
                dic.Add(Ten, (ctl as LookUpEdit).Text);
            else if (ctl is DateEdit)
                dic.Add(Ten, (ctl as DateEdit).DateTime);
            else if (ctl is ColorEdit)
                dic.Add(Ten, ((Color)(ctl as ColorEdit).EditValue).ToArgb());
            else if (ctl is SpinEdit)
                dic.Add(Ten, (ctl as SpinEdit).Value);
            else if (ctl is TextEdit)
                dic.Add(Ten, (ctl as TextEdit).Text);
        }

        public static string GhiChuGrid(GridView view, List<Dictionary<string, object>> lstDic)
        {
            string GhiChu = string.Empty;

            foreach (Dictionary<string, object> dic in lstDic)
            {
                string Vanban = string.Empty;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (dic.Where(w => w.Key.Equals("colID")).ToList()[0].Value.ToString() == view.GetRowCellDisplayText(i, view.Columns["ID"]).ToString())
                    {
                        Vanban += string.Format("--{0}--\r\n", view.GetRowCellDisplayText(i, view.Columns["ID"]));
                        for (int y = 0; y < view.Columns.Count; y++)
                        {
                            string DuLieu = dic.Where(w => w.Key.Equals(view.Columns[y].Name)).ToList()[0].Value.ToString();
                            if (view.GetRowCellDisplayText(i, view.Columns[y]).ToString() != DuLieu)
                                Vanban += view.Columns[y].Caption + string.Format(" [{0}->{1}]\r\n", DuLieu.ToString(), view.GetRowCellDisplayText(i, view.Columns[y]));
                        }
                        if (Vanban == string.Format("--{0}--\r\n", view.GetRowCellDisplayText(i, view.Columns["ID"])))
                            Vanban = string.Empty;
                    }
                }
                GhiChu += Vanban;
            }

            return GhiChu;
        }

        public static string GhiChuCMT(Form frm)
        {
            string GhiChu = string.Empty;
            Dictionary<string, object> dic = DuLieuTaoSan.Adic;
            foreach (Control ctl in frm.Controls)
            {
                if (ctl.Name.StartsWith("i"))
                    if (ctl is GroupControl || ctl is PanelControl || ctl is LayoutControl)
                        foreach (Control _ctl in ctl.Controls)
                        {
                            if (_ctl.Name.StartsWith("i") && dic.Where(w => w.Key.Equals(_ctl.Name.Substring(1))).Count() > 0)
                                GhiChu += CTGhiChu(_ctl, dic.Where(w => w.Key.Equals(_ctl.Name.Substring(1))).ToList()[0].Value);
                        }
                    else if (dic.Where(w => w.Key.Equals(ctl.Name.Substring(1))).Count() > 0)
                        GhiChu += CTGhiChu(ctl, dic.Where(w => w.Key.Equals(ctl.Name.Substring(1))).ToList()[0].Value);
            }
            return GhiChu;
        }

        static string CTGhiChu(Control ctl, object dic)
        {
            string VanBan = string.Empty;
            if (ctl.Tag != null)
            {
                VanBan = ctl.Tag.ToString();
                if (VanBan.Length > 0)
                {
                    switch (ctl.GetType().ToString())
                    {
                        case "DevExpress.XtraEditors.CheckEdit":
                            if ((ctl as CheckEdit).Checked != (bool)dic)
                                VanBan += string.Format(" [{0}->{1}]\r\n", (bool)dic ? "Chọn" : "Không chọn", (ctl as CheckEdit).Checked ? "Chọn" : "Không chọn");
                            break;
                        case "DevExpress.XtraEditors.ComboBoxEdit":
                        case "DevExpress.XtraEditors.SearchLookUpEdit":
                        case "DevExpress.XtraEditors.LookUpEdit":
                        case "DevExpress.XtraEditors.TextEdit":
                        case "DevExpress.XtraEditors.MemoEdit":
                            if (ctl.Text != dic.ToString() && !ctl.Text.Contains("Chọn"))
                                VanBan += string.Format(" [{0}->{1}]\r\n", dic.ToString(), ctl.Text);
                            break;
                        case "DevExpress.XtraEditors.DateEdit":
                            if ((ctl as DateEdit).DateTime != (DateTime)dic)
                                VanBan += string.Format(" [{0}->{1}]\r\n", ((DateTime)dic).ToString("dd/MM/yyyy"), (ctl as DateEdit).DateTime.ToString("dd/MM/yyyy"));
                            break;
                        case "DevExpress.XtraEditors.SpinEdit":
                            if ((ctl as SpinEdit).Value != decimal.Parse(dic.ToString()))
                                VanBan += string.Format(" [{0}->{1}]\r\n", decimal.Parse(dic.ToString()).ToString("#,###"), (ctl as SpinEdit).Value.ToString("#,###"));
                            break;
                    }
                    if (VanBan == ctl.Tag.ToString())
                        VanBan = string.Empty;
                }
            }
            return VanBan;
        }

        #endregion

        #region Chuyển class thành dic
        public static Dictionary<string, object> ConvertClassToDic<T>(T t) where T : new()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in t.GetType().GetProperties())
            {
                if (propertyInfo.Name.Equals("End"))
                    break;
                if (!propertyInfo.Name.Equals("ID"))
                    if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        string date = ((DateTime)propertyInfo.GetValue(t, null)).ToString("yyyyMMdd");
                        if (!date.Contains("0001"))
                            dic.Add(propertyInfo.Name, ((DateTime)propertyInfo.GetValue(t, null)).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        object a = propertyInfo.GetValue(t, null);
                        if (a != null)
                            dic.Add(propertyInfo.Name, a);
                    }
            }
            return dic;
        }
        #endregion

    }
}
