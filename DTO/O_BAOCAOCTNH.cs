using System;

namespace DataTransferObject
{

    public class O_BAOCAOCTNH
    {
        public int ID { get; set; }
        public int LoaiGiaoDich { get; set; }
        public Int64 IDCTNganHang { get; set; }
        public Int64 IDGDLienKet { get; set; }
        public Int64 SoTien { get; set; }
        public string Code { get; set; }
        public bool Thu { get; set; }
        public bool End { get; set; }
    }
}
