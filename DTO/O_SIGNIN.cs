using System;

namespace DataTransferObject
{
    public class O_SIGNIN
    {
        public int ID { set; get; }
        public int DaiLy { set; get; }
        public string SignIn { set; get; }
        public int HangBay { set; get; }
        public bool Chinh { set; get; } = true;
        public bool Khoa { set; get; }
        public string MatKhau { set; get; }
        public DateTime NgayKhoa { set; get; }
        public DateTime NgayCap { set; get; }
        public bool End { set; get; }
        public int CanLam { set; get; }
        public string DaiLyTT { set; get; }
        public string HangTT { set; get; }
        public DateTime NgayGanNhat { set; get; }
    }
}
