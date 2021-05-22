using System;

namespace CRM
{
    public class ClsHanhKhach
    {
        public string Khach { set; get; }
        public int so { set; get; }
        public string Loaive { set; get; }
        public string HanhLy { set; get; }

        public ClsHanhKhach()
        {
            Khach = string.Empty;
            so = 1;
            Loaive = string.Empty;
            HanhLy = string.Empty;
        }
    }
}
