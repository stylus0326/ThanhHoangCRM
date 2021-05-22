using System;

namespace AutoUpdate.Objects
{
    public class VersionOBJ
    {
        public string VersionID { set; get; }
        public string VersionName { set; get; }
        public string VersionType { set; get; }
        public string FileName { set; get; }
        public long FileSize { set; get; }
        public string Date { set; get; }
        public string Notes { set; get; }

        public VersionOBJ()
        {
            VersionID = string.Empty;
            VersionName = string.Empty;
            VersionType = string.Empty;
            FileName = string.Empty;
            FileSize = 0;
            Date = string.Empty;
            Notes = string.Empty;
        }


    }
}
