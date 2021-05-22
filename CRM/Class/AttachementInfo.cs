using System.IO;

namespace CRM
{
    public class AttachementInfo
    {
        Stream stream;
        string mimeType;
        string contentId;

        public AttachementInfo(Stream stream, string mimeType, string contentId)
        {
            this.stream = stream;
            this.mimeType = mimeType;
            this.contentId = contentId;
        }

        public Stream Stream { get { return stream; } }
        public string MimeType { get { return mimeType; } }
        public string ContentId { get { return contentId; } }
    }
}
