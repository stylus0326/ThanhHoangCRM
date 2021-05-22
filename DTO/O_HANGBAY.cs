namespace DataTransferObject
{
    public class O_HANGBAY
    {
        public int ID { set; get; }
        public string TenHang { set; get; }
        public string TenTat { set; get; }
        public string TaiKhoan { set; get; }
        public string MatKhau { set; get; }
        public long SoDu { set; get; }
        public int MauChinh { set; get; }
        public int MauNen { set; get; }
        public int MauChu { set; get; }
        public int HanhLy { set; get; }
        public byte[] LogoHang { set; get; }
        public string LoaiVe { set; get; }
        public bool SapXep { set; get; }
    }
}
