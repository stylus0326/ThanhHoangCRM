using DataTransferObject;
using System.Collections.Generic;
using System.Reflection;

namespace CRM
{
    class ClsDuLieu
    {
        public static string PhienBan = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static O_DAILY NhanVien = new O_DAILY();
        public static O_NHOMQUYEN Quyen = new O_NHOMQUYEN();
        public static List<O_QUANLYPHANMEM> QuanLy = new List<O_QUANLYPHANMEM>();

    }
}
