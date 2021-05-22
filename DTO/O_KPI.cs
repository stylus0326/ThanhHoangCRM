using System;

namespace DataTransferObject
{
    public class O_KPI
    {
        public int ID { get; set; }
        public int NhanVien { get; set; }
        public DateTime ThoiGian { get; set; } = DateTime.Now;
        public int Diem { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public bool End { get; set; }
    }
}
