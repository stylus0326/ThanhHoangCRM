using System;

namespace DataTransferObject
{
    public class O_CTNGANHANG
    {
        public int ID { set; get; }
        public DateTime NgayGD { set; get; } = DateTime.Now;
        public int NganHangID { set; get; }
        public int MaDL { set; get; }
        public string MaCode { set; get; }
        public long SoTien { set; get; }
        public string GhiChu { set; get; }
        public string GhiChuNV { set; get; }
        public string MaLienKet { set; get; }
        public bool TrangThaiID { set; get; }
        public DateTime NgayHT { set; get; } = DateTime.Now;
        public DateTime NgayTT { set; get; } = DateTime.Now;
        public int LoaiGiaoDich { set; get; }
        public int LoaiKhachHang { set; get; } = -1;
        public int NVGiaoDich { set; get; }//
        public bool End { set; get; }
        public string LienKet { set; get; }
        public string Ten { set; get; }
        public string IDGiaoDich { set; get; }

        // dung de luu
        public string TenNganHang { set; get; }
        public string TenHinhThuc { set; get; }
        public string ChiThu { set; get; }
    }
}
