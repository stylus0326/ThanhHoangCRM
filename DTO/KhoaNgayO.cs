using System;

namespace DataTransferObject
{
    public class KhoaNgayO
    {
        public int MaNgay { set; get; }
        public DateTime TuNgay { set; get; }
        public bool HoatDong { set; get; }

        public bool ThemNH { set; get; }
        public bool SuaNH { set; get; }
        public bool XoaNH { set; get; }
        public bool NganHang { set; get; }
        public bool Them { set; get; }
        public bool Sua { set; get; }
        public bool Xoa { set; get; }
        public bool KhoaAdmin { set; get; }
        public string Code { set; get; }
        public bool End { set; get; }

        public string StrTrangThai { get { return HoatDong ? "Khóa" : "Không Khoá"; } }
        public string StrNganHang { get { return NganHang ? "Khóa" : "Không Khoá"; } }

    }
}
