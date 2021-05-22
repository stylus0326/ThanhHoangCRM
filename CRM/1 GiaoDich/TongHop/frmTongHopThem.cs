using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmTongHopThem : DevExpress.XtraEditors.XtraForm
    {
        public frmTongHopThem()
        {
            InitializeComponent();
            TT = " thêm";
        }

        public frmTongHopThem(O_GIAODICH gd)
        {
            InitializeComponent();
            Gd = gd;
            TT = " sửa";
        }


        private void frmTongHopThem_Load(object sender, EventArgs e)
        {
            daiLyOs = new D_DAILY().All();
            DuLieuTaoSan.Adic = XuLyDuLieu.ConvertClassToTable(this, Gd);
            loaiKhachOBindingSource.DataSource = DuLieuTaoSan.LoaiKhachHang_GiaoDich().Where(w => w.ID.Equals(1) || w.ID.Equals(2));
            loaiGiaoDichOBindingSource1.DataSource = DuLieuTaoSan.LoaiGiaoDich_Ve(false);
            XuLyGiaoDien.OpenForm(this);
            iTenKhach.Text = "Thời gian: " + DateTime.Now.ToString("HH:mm");
            if ((new List<int>() { 7, 11, 12 }).Contains(Gd.LoaiGiaoDich))
            {
                iGiaThu.Value = Gd.GiaHoan;
                iTenKhach.Text = Gd.TenKhach;
            }
        }

        #region Biến
        string TT = string.Empty;
        O_GIAODICH Gd = new O_GIAODICH();
        List<O_DAILY> daiLyOs = new List<O_DAILY>();
        #endregion

        #region Sự kiện nút
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            D_GIAODICH nhb = new D_GIAODICH();

            switch (iLoaiGiaoDich.EditValue.ToString())
            {
                case "1":
                case "0":
                    if (!DuLieuTaoSan.Q.KhacThemSua)
                        return;
                    break;
                default:
                    if (!DuLieuTaoSan.Q.Lv2KhacAdmin)
                        return;
                    break;

            }

            List<KiemTra> kiemTras = new List<KiemTra>() {
            new KiemTra() { _Control = iIDKhachHang,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iLoaiKhachHang,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iLoaiGiaoDich,_Tu=2 ,_Den = 50} ,
            new KiemTra() { _Control = iTenKhach,_Tu=2,_Den = 50 },
            new KiemTra() { _Control = iMaCho, _Tu = 2, _Den = 50,_ChoQuaThang = !(new List<int>() { 1,0}).Contains((int)iLoaiGiaoDich.EditValue) } };

            XuLyGiaoDien.KiemTra(kiemTras, dxValidationProvider1);
            if (!dxValidationProvider1.Validate())
            {
                XuLyGiaoDien.Alert("Thông tin không hợp lệ", Form_Alert.enmType.Warning);
                return;
            }

            #region Lưu
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic = XuLyDuLieu.FormToDictionary(this, dic);
            dic.Add("NgayCuonChieu", "getdate()");
            dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
            dic.Add("CoDinh", 1);

            if ((new List<int>() { 7, 11, 12 }).Contains((int)iLoaiGiaoDich.EditValue))
            {
                dic.Remove("GiaThu");
                dic.Add("GiaHeThong", 0);
                dic.Add("GiaThu", 0);
                dic.Add("GiaHoan", iGiaThu.Value);
            }
            else
                dic.Add("GiaHeThong", iGiaThu.Value);


            if (XuLyGiaoDien.ThongBao(Text, Gd.ID != 0 ? (nhb.CapNhat(dic, Gd.ID) > 0) : (nhb.ThemMoi(dic) > 0)))
            {
                (Owner.ActiveMdiChild as frmTongHop).NapDatCho();
                GhiChuCmt(Gd.ID);
                Close();
            }
            #endregion
        }

        private void iLoaiKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            Text = iLoaiGiaoDich.Text + TT;
            daiLyOBindingSource.DataSource = daiLyOs.Where(w => w.LoaiKhachHang.Equals(int.Parse(iLoaiKhachHang.EditValue.ToString())));
        }

        #region Tạo Ghi Chú
        void GhiChuCmt(object f)
        {
            if (long.Parse(f.ToString()) > 0)
            {
                string NoiDung = string.Format("{0}: {1}", f, XuLyDuLieu.GhiChuCMT(this));
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("FormName", Text);
                dic.Add("MaCho", string.Empty);
                dic.Add("NoiDung", NoiDung);
                dic.Add("NVGiaoDich", DuLieuTaoSan.NV.ID);
                dic.Add("LoaiKhachHang", 0);
                dic.Add("Ma", 0);
                if (NoiDung.Length > 10)
                    new D_LS_GIAODICH().ThemMoi(dic);
            }
        }
        #endregion

        #endregion

        private void frmTongHopThem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                Close();
            else if (e.Control && e.KeyCode == Keys.S)
                btn.PerformClick();
        }
    }
}