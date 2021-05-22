using System;

namespace DataTransferObject
{
    public class O_GHICHU
    {
        public int ID { get; set; }
        public string TenNV { get; set; }
        public bool Loai { set; get; }
        public DateTime NgayLuu { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string GhiChuRieng { get; set; }
        public bool DaThanhToan { get; set; }
    }

}
