using System;

namespace DataTransferObject
{
    public class O_HOADON
    {
        public long ID { set; get; }//
        public DateTime NgayThanhToan { set; get; } = DateTime.Now;//
        public DateTime NgayThucHien { set; get; } = DateTime.Now;//
        public int LoaiKhachHang { set; get; } = 1;//
        public long IDKhachHang { set; get; }//
        public string MaSoThue { set; get; }//
        public string DiaChi { set; get; }//
        public string Mail { set; get; }//
        public string MaHD { set; get; } = "0";//
        public string CongTy { set; get; }//
        public string Ten { set; get; }//
        public string Hang { set; get; }//
        public int HanhTrinhDi { set; get; }//
        public int HanhTrinhVe { set; get; }//
        public long GiaYeuCau { set; get; }
        public string MaCho { set; get; }
        public string SoVe { set; get; }
        public long GiaHeThong { set; get; }
        public long GiaNet { set; get; }
        public float PhanTram { set; get; }
        public string MaCho2 { set; get; }
        public string SoVe2 { set; get; }
        public long GiaHeThong2 { set; get; }
        public float PhanTram2 { set; get; }
        public long NhanVien { set; get; }
        public long HoTro { set; get; }
        public string GhiChu { set; get; }
        public long SoChungTu { set; get; }
        public long IDGiaoDich { set; get; }

        public bool DaGui { set; get; }
        public bool DaThanhToan { set; get; }
        public bool DaBaoGia { set; get; }
        public DateTime NgayGDV { set; get; }
        public DateTime NgayGDV2 { set; get; }
        public bool Xoa { set; get; }
        public int NhaCungCap { set; get; }//

        public bool End { set; get; }
        public long CL1 { set; get; }
        public long CL2 { set; get; }
        public long CL3 { set; get; }
        public long CL4 { set; get; }
        public long CL5 { set; get; }
        public long CL6 { set; get; }
    }
}
