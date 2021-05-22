using AutoUpdate.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AutoUpdate.Models
{
    public class VersionMOD
    {
        public static VersionOBJ GetLastestVersion()
        {
            VersionOBJ verObj = new VersionOBJ();

            List<VersionOBJ> lst = GetAllVersions();

            if (lst != null)
            {
                verObj.VersionID = lst[lst.Count - 1].VersionID;
                verObj.VersionName = lst[lst.Count - 1].VersionName;
                verObj.VersionType = lst[lst.Count - 1].VersionType;
                verObj.FileName = lst[lst.Count - 1].FileName;
                verObj.FileSize = lst[lst.Count - 1].FileSize;
                verObj.Date = lst[lst.Count - 1].Date;
                verObj.Notes = lst[lst.Count - 1].Notes;
            }

            return verObj;
        }

        public static List<VersionOBJ> GetAllVersions()
        {
            List<VersionOBJ> lst = new List<VersionOBJ>();

            try
            {
                DataTable dt = new DataTable();

                string sSql = "SELECT * FROM Version ORDER BY VersionID ASC";
                dt = DataProvider.GetData(sSql);

                if (dt.Rows.Count > 0)
                {
                    VersionOBJ verObj = new VersionOBJ();

                    verObj.VersionID = dt.Rows[dt.Rows.Count - 1]["VersionID"].ToString();
                    verObj.VersionName = dt.Rows[dt.Rows.Count - 1]["VersionName"].ToString();
                    verObj.VersionType = dt.Rows[dt.Rows.Count - 1]["VersionType"].ToString();
                    verObj.FileName = dt.Rows[dt.Rows.Count - 1]["FileName"].ToString();
                    verObj.FileSize = long.Parse(dt.Rows[dt.Rows.Count - 1]["FileSize"].ToString());
                    verObj.Date = dt.Rows[dt.Rows.Count - 1]["Date"].ToString();
                    verObj.Notes = dt.Rows[dt.Rows.Count - 1]["Notes"].ToString();

                    lst.Add(verObj);
                }
                else
                {
                    lst = null;
                }
            }
            catch (Exception ex)
            {
                lst = null;
            }

            return lst;
        }

        public static bool InsertNewVersion(VersionOBJ verObj)
        {
            bool result;

            result = true;

            try
            {
                string sSql = "INSERT INTO Version(VersionID, VersionName, VersionType, FileName, FileSize, Date, Notes) VALUES(@VersionID, @VersionName, @VersionType, @FileName, @FileSize, GETDATE(), @Notes)";
                SqlCommand cmd = new SqlCommand(sSql);
                cmd.Parameters.Add("@VersionID", SqlDbType.VarChar).Value = verObj.VersionID;
                cmd.Parameters.Add("@VersionName", SqlDbType.VarChar).Value = verObj.VersionName;
                cmd.Parameters.Add("@VersionType", SqlDbType.VarChar).Value = verObj.VersionType;
                cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = verObj.FileName;
                cmd.Parameters.Add("@FileSize", SqlDbType.Int).Value = verObj.FileSize;
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = verObj.Notes;

                result = DataProvider.ExecuteQuery(cmd);

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        #region Read, Write version (text file)
        public static bool WriteNewVersion(VersionOBJ verObj, string sfilePath)
        {
            bool result;
            result = true;

            try
            {
                string s;

                s = verObj.VersionID + "\r\n";
                s += verObj.VersionName + "\r\n";
                s += verObj.FileName + "\r\n";
                s += verObj.Date;

                StreamWriter sw = new StreamWriter(sfilePath);
                sw.WriteLine(s);
                sw.Close();

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static string ReadCurrentVersion(string sfilePath)
        {
            string result;
            result = string.Empty;

            try
            {
                StreamReader sr = new StreamReader(sfilePath);
                result = sr.ReadLine();
                sr.Close();

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        #endregion

    }
}
