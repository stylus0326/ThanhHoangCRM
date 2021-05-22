using System.Drawing;

namespace CRM
{
    public partial class Design1 : DevExpress.XtraReports.UI.XtraReport
    {
        public Design1(int MauChu, int MauNen, int MauChinh, int HanhLy)
        {
            InitializeComponent();
            xrLine1.ForeColor = xrLine2.ForeColor = xrLine3.ForeColor = xrLine4.ForeColor = xrLine5.ForeColor =
            xrTableCell41.BorderColor = xrTableCell41.BorderColor = xrTableCell41.BorderColor =
            xrTableCell16.BorderColor = xrTableCell18.BorderColor = xrTableCell19.BorderColor =
             xrTableCell29.BorderColor = xrTableCell30.BorderColor =
            xrTableCell31.BorderColor = xrTableCell39.BorderColor = xrTableCell40.BorderColor =
            xrLabel1.BorderColor = xrLabel2.BorderColor = xrLabel3.BorderColor =
            xrTableCell27.BackColor = xrTableCell28.BackColor = xrTableCell33.BackColor =
            xrTableCell35.BackColor = xrTableCell36.BackColor = xrTableCell37.BackColor =
            xrTableCell9.BackColor = xrTableCell10.BackColor =
            xrTableCell17.BackColor = xrTableCell12.BackColor = xrTableCell13.BackColor =
            xrTableCell14.BackColor = Color.FromArgb(MauChinh);

            xrLabel1.BackColor = xrLabel2.BackColor = xrLabel3.BackColor = Color.FromArgb(MauNen);
            xrLabel1.ForeColor = xrLabel2.ForeColor = xrLabel3.ForeColor = Color.FromArgb(MauChu);

            xrLabel24.Text = string.Format("Hành lý xách tay : {0} Kg", HanhLy.ToString());
        }

    }
}
