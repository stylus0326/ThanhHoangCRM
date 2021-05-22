using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmGhiChuTong : DevExpress.XtraEditors.XtraForm
    {
        public frmGhiChuTong()
        {
            InitializeComponent();
        }

        private void frmGhiChuTong_Load(object sender, EventArgs e)
        {
            DSGhiChu.DataSource = ghiChuD.LayDanhSach();
        }

        O_GHICHU ghiChu = new O_GHICHU();
        D_GHICHU ghiChuD = new D_GHICHU();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (!btnHuy.Enabled)
                dic.Add("NgayLuu", "GETDATE()");
            dic.Add("TieuDe", iTieuDe.Text);
            dic.Add("NoiDung", iNoiDung.Text);
            dic.Add("GhiChuRieng", iGhiChu.Text);
            dic.Add("TenNV", DuLieuTaoSan.NV.TenDangNhapCty);
            long CapNhatNum = (ghiChu.ID > 0) ? (ghiChuD.CapNhat(dic, ghiChu.ID) > 0 ? ghiChu.ID : 0) : ghiChuD.ThemMoi(dic, true);
            if (XuLyGiaoDien.ThongBao(Text + ((ghiChu.ID > 0) ? " sửa" : " thêm"), CapNhatNum > 0))
            {
                DSGhiChu.DataSource = ghiChuD.LayDanhSach();
                iTieuDe.Text = iNoiDung.Text = iGhiChu.Text = string.Empty;
                btnHuy.Enabled = false;
            }
        }
        //? "S" : "T"
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ghiChu = new O_GHICHU();
            iTieuDe.Text = iNoiDung.Text = iGhiChu.Text = string.Empty;
            btnHuy.Enabled = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ghiChu = gridView1.GetRow(gridView1.GetSelectedRows()[0]) as O_GHICHU;
            if (ghiChu.TenNV.Equals(DuLieuTaoSan.NV.TenDangNhapCty))
            {
                iTieuDe.Text = ghiChu.TieuDe;
                iNoiDung.Text = ghiChu.NoiDung;
                iGhiChu.Text = ghiChu.GhiChuRieng;
                btnHuy.Enabled = true;
            }
            else
                ghiChu = new O_GHICHU();
        }
    }
}