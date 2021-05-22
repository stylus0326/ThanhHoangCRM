using System;

namespace DataTransferObject
{
    public class ChinhSachO
    {
        public int LoaiKhachHang { set; get; }
        public int ID { set; get; }
        public string Ten { set; get; }
        public double PhatQuyAm { set; get; }
        public string GhiChu { set; get; }
        public byte[] AnhCS { set; get; }
        public bool An { set; get; }
    }

    public class CTChinhSachO
    {
        public int IDCT { set; get; }
        public int IDChinhSach { set; get; }
        public DateTime NgayA { set; get; }
        public DateTime NgayB { set; get; }
        public string Hang { set; get; }
        public int NCC { set; get; }
        public int PhiCoDinh { set; get; }
        public int PhiCoDinhAm { set; get; }
        public int LoaiPhi { set; get; }
        public int GioiHanTien { set; get; }

        public double Duong { set; get; }
        public double Am { set; get; }
        public double BkDuong { set; get; }
        public double BkAm { set; get; }

        public DateTime NgayBayA { set; get; }
        public DateTime NgayBayB { set; get; }
        public string HanhTrinh { set; get; }
        public string HanhTrinhID { set; get; }

        public string HangCho { set; get; }
        public bool TatCaTuyenBay { set; get; } = true;
        public bool TatCaHangCho { set; get; } = true;
        public bool ThoiGianBay { set; get; }
        public bool DoanhSo { set; get; }
        public long DSTu { set; get; }
        public long DSDen { set; get; }
        public long MocAm { set; get; }
        public bool HaiChieu { set; get; } = true;
        public string DauVe { set; get; }
        public bool End { set; get; }


        public string Phi
        {
            set { }
            get
            {
                return String.Format("{0:#,##0.#;(#,##0.#)}", PhiCoDinh) + ((PhiCoDinh != PhiCoDinhAm) ? " - " + String.Format("{0:#,##0.#;(#,##0.#)}", PhiCoDinhAm) : "");
            }
        }

        public string CK
        {
            set { }
            get
            {
                if (LoaiPhi == 2)
                    return Duong + ((Duong != Am) ? "% - " + Am + "%" : "");
                else
                    return String.Format("{0:#,##0.#;(#,##0.#)}", Duong) + ((Duong != Am) ? " - " + String.Format("{0:#,##0.#;(#,##0.#)}", Am) : "");

            }
        }

        public string Bk
        {
            set { }
            get
            {
                if (LoaiPhi == 2)
                    return BkDuong + ((BkDuong != BkAm) ? "% - " + BkAm + "%" : "");
                else
                    return String.Format("{0:#,##0.#;(#,##0.#)}", BkDuong) + ((BkDuong != BkAm) ? " - " + String.Format("{0:#,##0.#;(#,##0.#)}", BkAm) : "");

            }
        }
    }
}
