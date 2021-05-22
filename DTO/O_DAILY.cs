﻿using System;

namespace DataTransferObject
{
    public class O_DAILY
    {
        public int ID { set; get; }
        public int LoaiKhachHang { set; get; }
        public string LuuY { set; get; }

        public string ThongTinLienLac { set; get; }
        public int NVGiaoDich { set; get; }//
        public DateTime NgayKiQuy { set; get; } = DateTime.Now;
        public string Ten { set; get; }
        public string NguoiDaiDienHD { set; get; }
        public int GioiTinhHD { set; get; }
        public DateTime NgaySinhHD { set; get; } = DateTime.Now.AddYears(-10);
        public string CMND { set; get; }
        public DateTime NgayCap { set; get; } = DateTime.Now.AddYears(-10);
        public string NoiCap { set; get; }
        public string DienThoaiHD { set; get; }
        public string EmailHD { set; get; }
        public string DiaChiHD { set; get; }
        public string GhiChu { set; get; }
        public int ChinhSach { set; get; }
        public int TinhTrang { set; get; }
        public bool Nghi { set; get; }
        public int TrangThaiHoatDong { set; get; } = 1;

        public string MaDL { set; get; }
        public string MaAGS { set; get; }
        public string DiDong { set; get; }
        public string EmailKeToan { set; get; }
        public string DienThoai { set; get; }
        public string EmailGiaoDich { set; get; }
        public string Skype { set; get; }
        public string Zalo { set; get; }
        public string Viber { set; get; }

        public string TenCty { set; get; }
        public string TenDangNhapCty { set; get; }
        public string MatKhauCty { set; get; }
        public string DienThoaiCty { set; get; }
        public string WebsiteCty { set; get; }
        public string EmailCty { set; get; }
        public string DiaChiCty { set; get; }
        public string KeyCty { set; get; }
        public byte[] AnhCty { set; get; }
        public bool HoatDongCty { set; get; }
        public bool MienPhat { set; get; }
        public bool DuHoSo { set; get; }
        public int Phi { set; get; }
        public int SoCT { set; get; }
        public long HanMuc { set; get; }
        public bool GuiMail { set; get; } = true;
        

        public bool End { set; get; }
        public int Diem { set; get; }
        public int SIC { set; get; }
        public string TenTam { set; get; }
        public long SoDu { set; get; }
        public DateTime GiaoDichGanNhat { set; get; }
        public string Nhom { set; get; }
        public long QuyChet { set; get; }//
        public long SoDuCuoi1 { set; get; }
        public long SoDuCuoi2 { set; get; }
        public long SoDuCuoi3 { set; get; }
        public double TienPhat { set; get; }
        public double PhatQuyAm { set; get; }
    }
}
