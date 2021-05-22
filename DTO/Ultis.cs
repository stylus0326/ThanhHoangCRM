using System;
using System.Security.Cryptography;
using System.Text;

namespace DataTransferObject
{
    public class Ultis
    {
        public static string ChuoiKetNoi = string.Format(@"Server=103.104.121.10,2109;Database=CRMDB;User Id=tuan; Password=AdGr2xjzeJnQE29;");
        //public static string ChuoiKetNoi = string.Format(@"Server=14.225.17.156,8079;Database=CRMDB;User Id=CRMDB; Password=admin@123;");
        //public static string ChuoiKetNoi = string.Format(@"Data Source=.\SQLEXPRESS;Initial Catalog=CRMDB;Integrated Security=True");
    }

    public class TMD5
    {
        public static string TMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
