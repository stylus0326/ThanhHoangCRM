using System;

namespace DataTransferObject
{
    public class SoDu_DaiLyO
    {
        public int ChinhSachID { set; get; }
        public DateTime Ngay { set; get; }
        public int SoDuCuoi { set; get; }
    }

    public class SoDu_HangO
    {
        public long SoDuCuoi { set; get; }
        public DateTime Ngay { set; get; }
        public string End { set; get; }
        public long SoDuDau { set; get; }
        public long SoDuThucTe { set; get; }
        public long TienVe { set; get; }
        public long NopQuy { set; get; }
        public long PhiHoan { set; get; }
        public long Hoan { set; get; }
        public long Incentive { set; get; }
        public long HangThu { set; get; }
        public string Error { set; get; }
    }

    public class SoDu_NganHangO
    {
        public long SoDuCuoi { set; get; }
        public DateTime Ngay { set; get; }
    }
}
