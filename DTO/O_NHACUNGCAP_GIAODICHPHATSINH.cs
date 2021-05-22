using System;

namespace DataTransferObject
{
    public class O_NHACUNGCAP_GIAODICHPHATSINH
    {
        public int ID { set; get; }
        public int NCC { set; get; }
        public DateTime NgayGD { set; get; } = DateTime.Now;
        public long SoTien { set; get; }
        public int LoaiGiaoDich { set; get; }
        public string GhiChu { set; get; }
    }
}
