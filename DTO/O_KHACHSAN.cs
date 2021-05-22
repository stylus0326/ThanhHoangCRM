using System;

namespace DataTransferObject
{
    public class O_KHACHSAN
    {
        public int ID { get; set; }
        public DateTime NgayGD { get; set; } = DateTime.Now;
        public string MaCho { get; set; }
        public int KhachSan { get; set; }
        public string Booking { get; set; }
        public int NVGiaoDich { get; set; }
        public int NVHoTro { get; set; }
        public long IDKhachHang { get; set; }
        public int SoPhong { get; set; } = 0;
        public int SoDem { get; set; } = 0;
        public long DonGia { get; set; } = 0;
        public long GiaNet { get; set; } = 0;
        public long GiaHeThong { get; set; } = 0;
        public long LoiNhuan { get; set; } = 0;
        public int NganHang { get; set; }
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public DateTime CheckOut { get; set; } = DateTime.Now;
        public string LoaiPhong { get; set; }
        public string GhiChu { get; set; }
        public string GhiChuHD { get; set; }
        public string PhuThu { get; set; }
        public Int64 TienPhuThu { get; set; } = 0;
        public int LoaiKhachHang { get; set; }
        public long SoTienBaoLuu { get; set; } = 0;
        public string LyDoBaoLuu { get; set; }
        public DateTime NgayBaoLuu { get; set; }

        public bool End { get; set; }
        public long LuyKe { get; set; }
        public long TaiKhoanCo { get; set; }
        public long ThanhToanBL { get; set; }
        public long KhachThanhToan { get; set; }
        public long ThanhToanKS { get; set; }
        public long KhachThanhToanNo { get; set; }
        public long ThanhToanKSNo { get; set; }
    }
}
