namespace DataTransferObject
{
    public class CauHinhSMTPO
    {
        public string Host { set; get; }
        public int Port { set; get; }
        public bool SSL { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }

    public class MauEmailO
    {
        public int ID { set; get; }
        public string TenMau { set; get; }
        public string NoiDung { set; get; }
    }
}
