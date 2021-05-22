using System;

namespace DataTransferObject
{
    public class O_SIGNINTRONG
    {
        public int ID { get; set; }
        public string SignIn { get; set; }
        public int HangBay { get; set; }
        public bool Chinh { get; set; } = true;
        public DateTime NgayCap { get; set; }
        public string MatKhau { get; set; }
        public bool End { get; set; }
    }
}
