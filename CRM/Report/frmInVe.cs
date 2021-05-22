using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CRM
{
    public partial class frmInVe : DevExpress.XtraEditors.XtraForm
    {
        List<GiaoDichO> data1;
        GiaoDichO data;

        public frmInVe(List<GiaoDichO> dr)
        {
            InitializeComponent();
            data1 = dr;
            data = data1[0];
            Load += new EventHandler(frmInVe_Load);
            panelControl1.Visible = false;
        }

        public frmInVe(CTNganHangO dr)
        {
            InitializeComponent();
            if (dr == null)
                return;
            nhanVienOBindingSource.DataSource = new DaiLyD().NhanVien();
            if (dr.LoaiKhachHang < 3)
            {
                DaiLyO dl = new DaiLyD().LayDaiLy(true, dr.MaDL.ToString());
                txtHoTen.Text = dl.Ten;
                if (dl.DiaChiHD != string.Empty)
                    txtDiaChi.Text = dl.DiaChiHD;
                txtLyDo.Text = DuLieuTaoSan.HinhThuc_NganHang(dr.LoaiKhachHang).Where(w => w.ID.Equals(dr.LoaiGiaoDich)).ToList()[0].Name + " ngày " + dr.NgayGD.ToString("dd/MM/yyyy");
            }
            else
                txtLyDo.Text = dr.GhiChu;
            txtID.Value = dr.ID;
            dtpNgayLap.EditValue = DateTime.Now;
            txtSoTien.EditValue = dr.SoTien > 0 ? dr.SoTien : 0 - dr.SoTien;
            txtNguoiLap.EditValue = dr.NVGiaoDich;
        }

        private void frmInVe_Load(object sender, EventArgs e)
        {
            SanBayD sbb = new SanBayD();
            HangBayO hb = new HangBayD().LayHangBay(data.Hang);
            Design1 rpt = new Design1(hb.MauChu, hb.MauNen, hb.MauChinh, hb.HanhLy);
            if (hb.LogoHang != null)
            {
                MemoryStream ms = new MemoryStream(hb.LogoHang);
                Image returnImage = Image.FromStream(ms);
                rpt.XrPic.Image = returnImage; //Ảnh hãng 
            }

            rpt.paHang.Value = hb.TenHang;//Tên hãng
            rpt.paMaCho.Value = data.MaCho;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            string NgayGD = string.Format("{0:dddd, d }", data.NgayGD) + "Tháng " + string.Format("{0:M yyyy}", data.NgayGD);
            string NgayDi = string.Format("{0:dddd, d }", data.GioBayDi) + "Tháng " + string.Format("{0:M yyyy}", data.GioBayDi);
            string NgayVe = string.Format("{0:dddd, d }", data.GioBayVe) + "Tháng " + string.Format("{0:M yyyy}", data.GioBayVe);
            string NgayDiDen = string.Format("{0:dddd, d }", data.GioBayDi_Den) + "Tháng " + string.Format("{0:M yyyy}", data.GioBayDi_Den);
            string NgayVeDen = string.Format("{0:dddd, d }", data.GioBayVe_Den) + "Tháng " + string.Format("{0:M yyyy}", data.GioBayVe_Den);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            NgayGD += "\n" + string.Format("{0:dddd, d MMMM yyyy}", data.NgayGD);
            NgayDi += "\n" + string.Format("{0:dddd, d MMMM yyyy}", data.GioBayDi);
            NgayVe += "\n" + string.Format("{0:dddd, d MMMM yyyy}", data.GioBayVe);
            NgayDiDen += "\n" + string.Format("{0:dddd, d MMMM yyyy}", data.GioBayDi_Den);
            NgayVeDen += "\n" + string.Format("{0:dddd, d MMMM yyyy}", data.GioBayVe_Den);
            rpt.paNgayGD.Value = NgayGD;


            TuyenBayO tb = new TuyenBayD().LayTuyenBay(data.TuyenBayDi);
            SanBayO sbo = sbb.SanBay(tb.Ten.Split('-')[0]);
            rpt.paSoHieuDi.Value = data.SoHieuDi.Replace(" ", string.Empty);
            rpt.paKhoiHanhDi.Value = string.Format("{0} ({1}) {2}\n{3}", sbo.TenDayDu, sbo.KyHieu, data.GioBayDi.ToString("H:mm"), NgayDi);
            sbo = sbb.SanBay(tb.Ten.Split('-')[1]);
            rpt.paDenDi.Value = string.Format("{0} ({1}) {2}\n{3}", sbo.TenDayDu, sbo.KyHieu, data.GioBayDi_Den.ToString("H:mm"), NgayDiDen);
            rpt.paThoiGianDi.Value = string.Format("{1} giờ {0} phút \n{1} hour(s) {0} minutes(s)", data.GioBayDi_Den.Subtract(data.GioBayDi).Minutes, data.GioBayDi_Den.Subtract(data.GioBayDi).Hours);


            if (data.SoLuongVe == 1)
                rpt.gTuyenVe.Visible = false;
            if (rpt.gTuyenVe.Visible)
            {
                tb = new TuyenBayD().LayTuyenBay(data.TuyenBayVe);
                sbo = sbb.SanBay(tb.Ten.Split('-')[0]);
                rpt.paSoHieuVe.Value = data.SoHieuVe.Replace(" ", string.Empty);
                rpt.paKhoiHanhVe.Value = string.Format("{0} ({1}) {2}\n{3}", sbo.TenDayDu, sbo.KyHieu, data.GioBayVe.ToString("H:mm"), NgayVe);
                sbo = sbb.SanBay(tb.Ten.Split('-')[1]);
                rpt.paDenVe.Value = string.Format("{0} ({1}) {2}\n{3}", sbo.TenDayDu, sbo.KyHieu, data.GioBayVe_Den.ToString("H:mm"), NgayVeDen);
                rpt.paThoiGianVe.Value = string.Format("{1} giờ {0} phút \n{1} hour(s) {0} minutes(s)", data.GioBayVe_Den.Subtract(data.GioBayVe).Minutes, data.GioBayVe_Den.Subtract(data.GioBayVe).Hours);
            }

            rpt.bindingSourceHT.DataSource = LayHanhKhach2();

            rpt.CreateDocument();
            // In report
            printControl.PrintingSystem = rpt.PrintingSystem;
        }

        List<ClsHanhKhach> LayHanhKhach2()
        {
            GiaoDichD gdb = new GiaoDichD();
            List<GiaoDichO> lstGD = data1;
            List<ClsHanhKhach> lstHK = new List<ClsHanhKhach>();
            // Danh sách hành khách
            List<string> hks = new List<string>();

            // Lấy tên duy nhất
            for (int i = 0; i < lstGD.Count; i++)
            {
                if (!hks.Contains(lstGD[i].TenKhach))
                {
                    ClsHanhKhach HKC = new ClsHanhKhach();
                    hks.Add(lstGD[i].TenKhach);
                    HKC.Khach = lstGD[i].TenKhach;
                    HKC.so += i;
                    if (lstGD[i].BiDanh == null)
                        HKC.Loaive = "Người lớn";
                    else
                        switch (lstGD[i].BiDanh.ToLower())
                        {
                            case "mstr":
                            case "miss":
                                HKC.Loaive = "Trẻ em";
                                break;
                            case "em bé":
                                HKC.Loaive = "Em bé";
                                break;
                            default:
                                HKC.Loaive = "Người lớn";
                                break;
                        }

                    if (lstGD[i].HanhLyDi == null)
                        HKC.HanhLy = "0 KG";
                    else if (lstGD[i].HanhLyDi == string.Empty)
                        HKC.HanhLy = "0 KG";
                    else
                        HKC.HanhLy = (lstGD[i].HanhLyDi).Replace("KG", string.Empty) + " KG";

                    if (data.SoLuongVe == 2)

                        if (lstGD[i].HanhLyVe == null)
                            HKC.HanhLy += " - 0 KG";
                        else if (lstGD[i].HanhLyVe == string.Empty)
                            HKC.HanhLy += " - 0 KG";
                        else
                            HKC.HanhLy += " - " + (lstGD[i].HanhLyVe).Replace("KG", string.Empty) + " KG";
                    lstHK.Add(HKC);
                }
            }
            return lstHK;
        }
        static string ConvertDecimalToString(long number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín " };
            string[] hang = new string[] { string.Empty, "nghìn ", "triệu ", "tỷ " };
            int i, j, donvi, chuc, tram;
            string str = string.Empty;
            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + "mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + "trăm " + str;
                    }
                }
            }
            if (booAm) str = "Âm " + str;
            return str.Substring(0, 1).ToUpper() + str.Remove(0, 1) + "đồng chẵn";
        }


        private void btnTao_Click(object sender, EventArgs e)
        {
            XtraReport1 rpt = new XtraReport1();
            rpt.paTH.Value = "Số: " + txtID.Text;
            rpt.paDatetime.Value = "Ngày " + dtpNgayLap.DateTime.ToString("dd") + " Tháng " + dtpNgayLap.DateTime.ToString("MM") + " Năm " + dtpNgayLap.DateTime.ToString("yyyy");
            rpt.paHoTen.Value = (chkChi.Checked ? "Họ tên người nhận tiền: " : "Họ tên người nộp tiền: ") + txtHoTen.Text;
            rpt.paDiaChi.Value = "Địa chỉ\t: " + txtDiaChi.Text;
            rpt.paLydonop.Value = (chkChi.Checked ? "Lý do chi\t: " : "Lý do nộp\t: ") + txtLyDo.Text;
            rpt.paSotien.Value = "Số tiền\t: " + txtSoTien.Value.ToString("#,### VNĐ") + " (" + ConvertDecimalToString((long)txtSoTien.Value) + ")";
            rpt.paKemthem.Value = "Kèm theo\t: " + txtKemTheo.Text;
            rpt.paNguoiLap.Value = txtNguoiLap.Text;
            rpt.paTenPhieu.Text = chkChi.Checked ? "PHIẾU CHI" : "PHIẾU THU";
            rpt.xrLabel19.Text = chkChi.Checked ? "Người nhận tiền" : "Người nộp tiền";
            rpt.CreateDocument();
            printControl.PrintingSystem = rpt.PrintingSystem;
        }
    }
}