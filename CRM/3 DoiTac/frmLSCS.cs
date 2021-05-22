using DataAccessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmLSCS : DevExpress.XtraEditors.XtraForm
    {
        public frmLSCS(int ID, int LoaiKH)
        {
            InitializeComponent();
            IDDaiLy = ID;
            chinhSachOBindingSource.DataSource = new ChinhSachD().All();
        }

        private void frmSoDuHang_Load(object sender, EventArgs e)
        {
            iTN.Properties.MinValue = iTN.DateTime = DateTime.Now.AddDays(-30);
            iDN.DateTime = DateTime.Now;
            soDuDaiLyOBindingSource.DataSource = _SODU_DAILYD.DuLieu(IDDaiLy, new DateTime(2019, 01, 01), DateTime.Now);
            XuLyGiaoDien.OpenForm(this);
            btn.Visible = DuLieuTaoSan.Q.ChinhSachThemSua;
        }

        #region Biến
        int IDDaiLy = 0;
        SoDu_DaiLyD _SODU_DAILYD = new SoDu_DaiLyD();
        DaiLyD DaiLyD = new DaiLyD();
        #endregion

        #region Sự kiện nút
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (iTN.DateTime < iDN.DateTime && iCS.EditValue != null)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("ChinhSachID", iCS.EditValue);
                if (XuLyGiaoDien.ThongBao("Chi tiết chính sách sửa", _SODU_DAILYD.CapNhat(dic, IDDaiLy, "WHERE DAILYID= {0} and convert(date,Ngay) between '" + iTN.DateTime.ToString("yyyyMMdd") + "' and '" + iDN.DateTime.ToString("yyyyMMdd") + "'") > 0))
                {

                    if (DateTime.Now.ToString("ddMMyyyy") == iDN.DateTime.ToString("ddMMyyyy"))
                    {
                        (Owner as frmDaiLyThem).iChinhSach.EditValue = iCS.EditValue;
                        dic = new Dictionary<string, object>();
                        dic.Add("ChinhSach", iCS.EditValue);
                        DaiLyD.CapNhat(dic, IDDaiLy);
                    }
                    DaiLyD.ChayLaiPhi(iTN.DateTime);
                    Close();
                }
            }
            else
                XtraMessageBox.Show("Thông tin nhập không hợp lệ. Vui lòng kiểm tra lại", "Thông báo");
        }
        #endregion
    }
}