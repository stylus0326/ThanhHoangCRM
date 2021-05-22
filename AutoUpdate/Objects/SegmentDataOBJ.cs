using System;

namespace AutoUpdate.Objects
{
    public class SegmentDataOBJ
    {
        public string SegmentID { set; get; }
        public string SegmentName { set; get; }
        public byte[] Data { set; get; }
        public long Length { set; get; }
        public string VersionID { set; get; }
        public string Date { set; get; }
        public string Notes { set; get; }

        public SegmentDataOBJ()
        {
            SegmentID = string.Empty;
            SegmentName = string.Empty;
            Data = null;
            Length = 0;
            VersionID = string.Empty;
            Date = string.Empty;
            Notes = string.Empty;
        }
    }
}
