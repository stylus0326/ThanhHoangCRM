using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace CRM
{
    public partial class frmNCCGD : DevExpress.XtraEditors.XtraForm
    {
        O_NHACUNGCAP_GIAODICHPHATSINH _nCCGDO = new O_NHACUNGCAP_GIAODICHPHATSINH();
        D_NHACUNGCAP_GIAODICHPHATSINH _nCCGDD = new D_NHACUNGCAP_GIAODICHPHATSINH();
        public frmNCCGD()
        {
            InitializeComponent();
            Text += " thêm";
        }

        public frmNCCGD(O_NHACUNGCAP_GIAODICHPHATSINH nCCGDO)
        {
            InitializeComponent();
            Text += " sửa";
            _nCCGDO = nCCGDO;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iNCC,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iLoaiGiaoDich,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iGhiChu,_Tu=2,_Den = 50 },
            new KiemTra() { _Control = iSoTien, _Tu = 2, _Den = 5000 } };

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);

            if (XuLyGiaoDien.ThongBao(Text, _nCCGDO.ID != 0 ? (_nCCGDD.CapNhat(dic, _nCCGDO.ID) > 0) : (_nCCGDD.ThemMoi(dic) > 0)))
            {
                (Owner.ActiveMdiChild as frmHangBay).DuLieu();
                Close();
            }
        }

        private void frmNCCGD_Load(object sender, EventArgs e)
        {
            nCCOBindingSource.DataSource = new D_NHACUNGCAP().DuLieu();
            intStringBindingSource.DataSource = DuLieuTaoSan.LoaiPhi(false);
            ClsChucNang.OpenForm(this);
            XuLyDuLieu.ConvertClassToTable(this, _nCCGDO);
        }
    }
}