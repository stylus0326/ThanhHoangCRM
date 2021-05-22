using AutoUpdate.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AutoUpdate.Models
{
    public class SegmentDataMOD
    {
        public static bool InsertSegmentData(SegmentDataOBJ segObj)
        {
            bool result;

            try
            {
                string sSql = "INSERT INTO SegmentData(SegmentID, SegmentName, Data, Length, VersionID, Date, Notes) VALUES(@SegmentID, @SegmentName, @Data, @Length, @VersionID, GETDATE(), @Notes)";
                SqlCommand cmd = new SqlCommand(sSql);
                cmd.Parameters.Add("@SegmentID", SqlDbType.VarChar).Value = segObj.SegmentID;
                cmd.Parameters.Add("@SegmentName", SqlDbType.VarChar).Value = segObj.SegmentName;
                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = segObj.Data;
                cmd.Parameters.Add("@Length", SqlDbType.Int).Value = segObj.Length;
                cmd.Parameters.Add("@VersionID", SqlDbType.VarChar).Value = segObj.VersionID;
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar).Value = segObj.Notes;

                result = DataProvider.ExecuteQuery(cmd);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static bool DeleteAllSegmentData()
        {
            bool result = true;

            try
            {
                string sSql = "DELETE FROM SegmentData";
                SqlCommand cmd = new SqlCommand(sSql);

                result = DataProvider.ExecuteQuery(cmd);

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static List<SegmentDataOBJ> GetAllSegmentData(string VersionID)
        {
            List<SegmentDataOBJ> lst = new List<SegmentDataOBJ>();

            try
            {
                DataTable dt = new DataTable();

                string sSql = "SELECT * FROM SegmentData WHERE VersionID=" + VersionID + "  ORDER BY SegmentID ASC";

                dt = DataProvider.GetData(sSql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SegmentDataOBJ segObj = new SegmentDataOBJ();
                        segObj.SegmentID = dt.Rows[i]["SegmentID"].ToString();
                        segObj.SegmentName = dt.Rows[i]["SegmentName"].ToString();
                        segObj.Data = (byte[])dt.Rows[i]["Data"];
                        segObj.Length = long.Parse(dt.Rows[i]["Length"].ToString());
                        segObj.VersionID = dt.Rows[i]["VersionID"].ToString();
                        segObj.Date = dt.Rows[i]["Date"].ToString();
                        segObj.Notes = dt.Rows[i]["Notes"].ToString();

                        lst.Add(segObj);
                    }
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

        #region Upload file to server (SQL Server)
        public static int GetMaxSegmentID()
        {
            int MaxID;

            MaxID = 0; //giả sử chưa có dữ liệu

            try
            {
                DataTable dt = new DataTable();

                string sSql = "SELECT * FROM SegmentData ORDER BY SegmentID ASC";
                dt = DataProvider.GetData(sSql);

                if (dt.Rows.Count > 0)
                {
                    string sSegmentID = dt.Rows[dt.Rows.Count - 1]["SegmentID"].ToString();
                    MaxID = int.Parse(sSegmentID);
                }

            }
            catch (Exception ex)
            {
            }

            return MaxID;
        }

        public static bool UploadFileToServer(string sfilePath, string VersionID, string Notes)
        {
            bool result = true;
            try
            {
                Byte[] Data = ReadFile(sfilePath);
                InsertDataFileIntoDB(Data, VersionID, Notes);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        private static bool InsertDataFileIntoDB(Byte[] Data, string VersionID, string Notes)
        {
            bool result = true;
            long SegmentSz = 8000;
            long numSegments = Data.Length / SegmentSz;

            if (Data.Length % SegmentSz > 0)
                numSegments++;

            Byte[] segData = new Byte[SegmentSz];
            //long idx = 0;
            long MaxSegID = GetMaxSegmentID();
            long idx = MaxSegID;
            long i = 0;
            long j = 0;

            while (i < Data.Length)
            {
                try
                {
                    SegmentDataOBJ segObj = new SegmentDataOBJ();
                    //xet du lieu Segment thu idx
                    long k = 0; //so byte cua segment (do dai cua segment idx)
                    while (k < SegmentSz && i < Data.Length)
                    {
                        segData[k] = Data[i];
                        i++;
                        k++;
                    }
                    idx++;

                    segObj.SegmentID = idx.ToString();
                    segObj.SegmentName = "Ver" + VersionID + "_Seg" + (idx - MaxSegID).ToString();
                    segObj.Data = segData;
                    segObj.Length = k;
                    segObj.VersionID = VersionID;
                    segObj.Notes = Notes;

                    InsertSegmentData(segObj);

                }
                catch (Exception ex)
                {
                    result = false;
                }
            }


            return result;
        }

        #endregion

        #region Download file from server (SQL Server)
        public static bool DownloadFileFromServer(string VersionID, string sfilePath)
        {
            bool result;

            result = true;
            try
            {
                //DataTable dt = GetAllSegmentData(VersionID);
                List<SegmentDataOBJ> lst = GetAllSegmentData(VersionID);
                if (lst.Count > 0)
                {
                    long MaxLength = 0;
                    for (int i = 0; i < lst.Count; i++)
                        MaxLength += lst[i].Length;

                    Byte[] arrData = new Byte[MaxLength];

                    int idx = 0;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        //string sFileName = dt.Rows[0]["FileName"].ToString();
                        Byte[] SegData = lst[i].Data;
                        long SegLength = lst[i].Length;
                        for (int j = 0; j < SegLength; j++)
                        {
                            arrData[idx] = SegData[j];
                            idx++;
                        }
                    }


                    WriteFile(sfilePath, arrData);

                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        #endregion


        #region Read, Write binary file
        public static Byte[] ReadFile(string sfilePath)
        {
            Byte[] arr;

            FileStream fs = new FileStream(sfilePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            arr = br.ReadBytes((Int32)fs.Length);

            br.Close();
            fs.Close();

            return arr;
        }

        public static bool WriteFile(string sfilePath, Byte[] Data)
        {
            bool result;
            result = true;
            try
            {
                FileStream fs = new FileStream(sfilePath, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Data);
                bw.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        #endregion

    }
}
