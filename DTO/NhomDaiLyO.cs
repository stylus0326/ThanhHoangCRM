namespace DataTransferObject
{
    public class NhomDaiLyO
    {
        public int ID { set; get; }
        public string Ten { set; get; }
        public int LoaiKhachHang { set; get; }
        public long Tu { set; get; }
        public long Den { set; get; }
    }

    public class TinhTrangO
    {
        public int ID { set; get; }
        public string TenTrangThai { set; get; }
        public int MauSac { set; get; }
        public int LoaiKhachHang { set; get; }
    }
}
