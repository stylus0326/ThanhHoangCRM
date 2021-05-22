namespace DataTransferObject
{
    public class NganHangO
    {
        public int ID { set; get; }
        public string Ten { set; get; }
        public string SoTK { set; get; }
        public string TenTK { set; get; }
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public string NgayGD { set; get; }
        public string NgayHT { set; get; }
        public string Nap { set; get; }
        public string Rut { set; get; }
        public string PhepTinh { set; get; }
        public string GhiChu { set; get; }
        public string WURL { set; get; }
        public bool Ex { set; get; }
        public int Nhom { set; get; }
        public bool End { set; get; }
        public string Nhomstring
        {
            set { }
            get
            {
                switch (Nhom)
                {
                    case 0:
                        return "Cá nhân";
                    case 1:
                        return "Công ty";
                    default:
                        return "Đóng";
                }
            }
        }
        public long SoDu { set; get; }
        public long SoDuCuoi { set; get; }
        public int Sai { set; get; }
    }
}
