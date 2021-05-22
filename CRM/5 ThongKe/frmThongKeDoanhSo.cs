using DataAccessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace CRM
{
    public partial class frmThongKeDoanhSo : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeDoanhSo()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhSo_Load(object sender, EventArgs e)
        {
            daiLyOBindingSource.DataSource = new DaiLyD().All();
            nCCOBindingSource.DataSource = new NCCD().DuLieu();
            bdtpTu.EditValue = DateTime.Now.AddDays(-240);
            bdtpTu.EditValueChanged += BdtpTu_EditValueChanged;
            bdtpDen.EditValueChanged += BdtpTu_EditValueChanged;
            bdtpDen.EditValue = DateTime.Now;
        }

        private void BdtpTu_EditValueChanged(object sender, EventArgs e)
        {
            DieuChinh();
        }

        int _IDThoiGian = 2;
        private void ecmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IDThoiGian = (sender as ComboBoxEdit).SelectedIndex;
            DieuChinh();
        }

        void DieuChinh(string azs = "GiaNet")
        {
            if (bdtpTu.EditValue == null || bdtpDen.EditValue == null)
                return;
            DataTable dt = new DataTable();
            for (int i = 0; i < GVTK.Bands.Count; i++)
            {
                if (!GVTK.Bands[i].Name.Equals("Gb1"))
                {
                    GVTK.Bands.Remove(GVTK.Bands[i]); i--;
                }
            }

            for (int i = 0; i < GVTK.Columns.Count; i++)
            {
                if (!"colDaiLy, colHang, colSale".Contains(GVTK.Columns[i].Name))
                {
                    GVTK.GroupSummary.Remove(GVTK.GroupSummary[i - 3]);
                    GVTK.Columns.Remove(GVTK.Columns[i]);
                }
            }

            DateTime startDate = ((DateTime)bdtpTu.EditValue).Date;
            DateTime endDate = ((DateTime)bdtpDen.EditValue).Date;

            var dates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
              .Select(x => startDate.AddDays(x))
              .ToList();
            List<DateTime> Ngay = dates.ToList();
            List<string> Nam;
            List<string> Quy;
            List<string> Thang;
            List<string> Tuan;
            List<string> ListTenCot = new List<string>();
            string TenCot = string.Empty;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            Nam = Ngay.Select(w => w.Year.ToString()).Distinct().AsEnumerable().Reverse().ToList();
            Quy = Ngay.Select(w => (1 + (w.Month - 1) / 3) + "/" + w.Year).Distinct().AsEnumerable().Reverse().ToList();
            Thang = Ngay.Select(w => w.Month + "/" + (1 + (w.Month - 1) / 3) + "/" + w.Year).Distinct().AsEnumerable().Reverse().ToList();
            Tuan = Ngay.Select(w => cul.Calendar.GetWeekOfYear(w, CalendarWeekRule.FirstDay, DayOfWeek.Monday) + "/" + w.Year).Distinct().AsEnumerable().Reverse().ToList();
            string TenCotTao = string.Empty;
            string TenCotTao2 = string.Empty;
            switch (_IDThoiGian)
            {
                case 0:
                    TenCotTao = "datepart(YEAR, NgayGD)";
                    TenCotTao2 = "datepart(YEAR, NgayGD)";
                    GridBand gridBand = new GridBand() { Caption = "Năm", Name = "Gb2", VisibleIndex = 1, Width = 225 };
                    GVTK.Bands.Add(gridBand);
                    foreach (string a in Nam)
                    {
                        TenCot = a;
                        ListTenCot.Add(TenCot);
                        dt.Columns.Add(TenCot, typeof(long));
                        BandedGridColumn bandedGridColumn = new BandedGridColumn() { Caption = $"-{a}-", FieldName = TenCot, Name = $"col{a}", Visible = true, Width = 50 };
                        bandedGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bandedGridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        bandedGridColumn.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
                        bandedGridColumn.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, TenCot, "{0:#,##0;(#,##0)}") });
                        gridBand.Columns.Add(bandedGridColumn);
                    }
                    break;
                case 1:
                    foreach (string a in Nam)
                    {
                        TenCotTao = "cast(datepart(QUARTER, NgayGD) as varchar)+cast(datepart(YEAR, NgayGD) as varchar)";
                        TenCotTao2 = "datepart(YEAR, NgayGD), datepart(QUARTER, NgayGD)";
                        GridBand gridBand1 = new GridBand() { Caption = $"-{a}-", Name = $"Gb{a}", VisibleIndex = 1, Width = 225 };
                        GVTK.Bands.Add(gridBand1);
                        List<string> _Quy = Quy.Where(w => w.Split('/')[1].Contains(a)).ToList();
                        foreach (string b in _Quy)
                        {
                            TenCot = b.Replace("/", string.Empty);
                            ListTenCot.Add(TenCot);
                            dt.Columns.Add(TenCot, typeof(long));
                            BandedGridColumn bandedGridColumn = new BandedGridColumn() { Caption = $"Quý {b.Split('/')[0]}", FieldName = TenCot, Name = $"col{b.Replace("/", string.Empty)}", Visible = true, Width = 50 };
                            bandedGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            bandedGridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                            bandedGridColumn.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
                            bandedGridColumn.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, TenCot, "{0:#,##0;(#,##0)}") });
                            gridBand1.Columns.Add(bandedGridColumn);
                        }
                    }
                    break;
                case 2:
                    foreach (string a in Nam)
                    {
                        TenCotTao = "cast(datepart(MONTH, NgayGD) as varchar)+cast(datepart(YEAR, NgayGD) as varchar)";
                        TenCotTao2 = "datepart(YEAR, NgayGD), datepart(MONTH, NgayGD)";
                        GridBand gridBand1 = new GridBand() { Caption = $"-{a}-", Name = $"Gb{a}", VisibleIndex = 1, Width = 225 };
                        GVTK.Bands.Add(gridBand1);
                        List<string> _Quy = Quy.Where(w => w.Contains(a)).ToList();
                        foreach (string b in _Quy)
                        {
                            GridBand gridBand2 = new GridBand() { Caption = $"Quý {b.Split('/')[0]}", Name = $"Gb{a}", VisibleIndex = 1, Width = 225 };
                            gridBand1.Children.Add(gridBand2);
                            List<string> _Thang = Thang.Where(w => w.Split('/')[2].Equals(a) && w.EndsWith(b)).ToList();
                            foreach (string c in _Thang)
                            {
                                TenCot = c.Replace($"/{b}", string.Empty) + a;
                                ListTenCot.Add(TenCot);
                                dt.Columns.Add(TenCot, typeof(long));
                                BandedGridColumn bandedGridColumn = new BandedGridColumn() { Caption = $"Tháng {c.Split('/')[0]}", FieldName = TenCot, Name = $"col{c.Replace("/", string.Empty)}", Visible = true, Width = 50 };
                                bandedGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                bandedGridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                                bandedGridColumn.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
                                bandedGridColumn.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, TenCot, "{0:#,##0;(#,##0)}") });

                                gridBand2.Columns.Add(bandedGridColumn);
                                GVTK.GroupSummary.Add(new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, bandedGridColumn.FieldName, bandedGridColumn, "{0:#,##0;(#,##0)}"));
                            }
                        }
                    }
                    break;
                case 3:
                    foreach (string a in Nam)
                    {
                        TenCotTao = "cast(datepart(WEEK, NgayGD) as varchar)+cast(datepart(YEAR, NgayGD) as varchar)";
                        TenCotTao2 = "datepart(YEAR, NgayGD), datepart(WEEK, NgayGD)";
                        GridBand gridBand1 = new GridBand() { Caption = $"-{a}-", Name = $"Gb{a}", VisibleIndex = 1, Width = 225 };
                        GVTK.Bands.Add(gridBand1);
                        List<string> _Tuan = Tuan.Where(w => w.Split('/')[1].Contains(a)).ToList();
                        foreach (string b in _Tuan)
                        {
                            TenCot = b.Replace("/", string.Empty);
                            ListTenCot.Add(TenCot);
                            dt.Columns.Add(TenCot, typeof(long));
                            BandedGridColumn bandedGridColumn = new BandedGridColumn() { Caption = $"Tuần {b.Split('/')[0]}", FieldName = TenCot, Name = $"col{b.Replace("/", string.Empty)}", Visible = true, Width = 50 };
                            bandedGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            bandedGridColumn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                            bandedGridColumn.DisplayFormat.FormatString = "{0:#,##0;(#,##0)}";
                            bandedGridColumn.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, TenCot, "{0:#,##0;(#,##0)}") });
                            gridBand1.Columns.Add(bandedGridColumn);
                        }
                    }
                    break;
            }
            string az = string.Format(@"
        SET DATEFIRST 1
        select * from (
                    select IDKhachHang,dl.NVGiaoDich,NhaCungCap,{0} 'CotMoc',SUM({5}) Gia from GIAODICH
                    left join (select ID MaIDDL,NVGiaoDich from DAILY where LoaiKhachHang = 1) dl on IDKhachHang = MaIDDL where MaIDDL is not null and LoaiGiaoDich in ({6}) and CONVERT(date,NgayGD) between '{2}' and '{3}' and coalesce(NhaCungCap,0)>0 group by {1} ,IDKhachHang,NhaCungCap ,dl.NVGiaoDich
                    ) Y pivot (max(Gia) for CotMoc in ([{4}])) as pv
                    order by IDKhachHang,NhaCungCap", TenCotTao, TenCotTao2, startDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"), String.Join("],[", ListTenCot.ToArray()), azs, azs == "GiaNet" ? "4,13,14" : "9");
            dt = new GiaoDichD().LayDataTable(az);
            GCTK.DataSource = dt;
            GVTK.BestFitColumns();
        }

        private void bandedGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "IDKhachHang" || e.Column.FieldName == "NVGiaoDich" || e.Column.FieldName == "NhaCungCap")
            {
                string _mark3 = (view.GetRowCellValue(e.RowHandle1, e.Column) ?? string.Empty).ToString();
                string _mark4 = (view.GetRowCellValue(e.RowHandle2, e.Column) ?? string.Empty).ToString();
                e.Merge = _mark3 == _mark4;
                e.Handled = true;
            }
        }

        int a;
        private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (!chk.Checked)
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName != "IDKhachHang" && e.Column.FieldName != "NVGiaoDich" && e.Column.FieldName != "NhaCungCap")
                    {
                        DataRowView dl = View.GetRow(e.RowHandle) as DataRowView;
                        object[] a = dl.Row.ItemArray.Where(w => w.GetType() == typeof(long)).ToArray();
                        long GF = a.Sum(w => (long)w) / a.Length;
                        if ((e.CellValue ?? 0).ToString().Length < 1)
                        {
                            e.Appearance.BackColor = Color.LightGray;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else if (long.Parse((e.CellValue ?? 0).ToString()) >= GF)
                        {
                            e.Appearance.BackColor = Color.FromArgb(100, 36, 172, 65);
                            e.Appearance.ForeColor = Color.FromArgb(36, 172, 65);
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.FromArgb(100, 196, 32, 37);
                            e.Appearance.ForeColor = Color.FromArgb(196, 32, 37);
                        }
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "IDKhachHang" && e.Column.FieldName != "NVGiaoDich" && e.Column.FieldName != "NhaCungCap")
                if ((e.Value ?? string.Empty).ToString() == string.Empty)
                    e.DisplayText = "0";

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuLyGiaoDien.ExportExcel(GCTK, GVTK, "ExTK-" + DateTime.Now.ToString("dd-MM-yyy"));
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DieuChinh(barCheckItem1.Checked ? "GiaHoan" : "GiaNet");
        }
    }
}