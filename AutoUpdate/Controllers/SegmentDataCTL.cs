using AutoUpdate.Models;
using AutoUpdate.Objects;
using System;


namespace AutoUpdate.Controllers
{
    public class SegmentDataCTL
    {
        public static bool InsertSegmentData(SegmentDataOBJ segObj)
        {
            return SegmentDataMOD.InsertSegmentData(segObj);
        }
        public static bool DeleteAllSegmentData()
        {
            return SegmentDataMOD.DeleteAllSegmentData();
        }

        public static bool DownloadFileFromServer(string VersionID, string sfilePath)
        {
            return SegmentDataMOD.DownloadFileFromServer(VersionID, sfilePath);
        }

        public static bool UploadFileToServer(string sfilePath, string VersionID, string Notes)
        {
            return SegmentDataMOD.UploadFileToServer(sfilePath, VersionID, Notes);
        }

    }
}
