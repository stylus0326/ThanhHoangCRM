using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoUpdate.Models
{
    public class DataProvider
    {
        public static SqlConnection ConnectToDB()
        {
            try
            {
                // Client
                string ChuoiKetNoi = string.Format(@"Server=103.104.121.10,2109;Database=CRMDB_Update;User Id=tuan; Password=AdGr2xjzeJnQE29;");
                // Management
                //string ChuoiKetNoi = string.Format(@"Server=.\SQL2012;Database=CRMDB_Update;Integrated Security=True;");
                SqlConnection conn = new SqlConnection(ChuoiKetNoi);
                conn.Open();
                return conn;
            }
            catch
            {
                throw new Exception("Lỗi kết nối Cơ Sở Dữ Liệu...");
            }
        }

        public static DataTable GetData(string sSql)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlConnection conn = ConnectToDB();
                SqlDataAdapter da = new SqlDataAdapter(sSql, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public static bool ExecuteQuery(SqlCommand cmd)
        {
            bool result;

            result = true;
            try
            {
                SqlConnection conn = ConnectToDB();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }


    }
}
