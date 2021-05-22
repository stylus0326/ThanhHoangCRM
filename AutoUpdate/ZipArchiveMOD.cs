using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;


namespace AutoUpdate
{
    public class ZipArchiveMOD
    {

        static private string ZipEntry(string FilePath,
            bool IncludeFileName)
        {
            string path = string.Empty;
            DirectoryInfo di = new DirectoryInfo(FilePath);
            if (di.Root.FullName == di.Root.Name)
            {
                path = (di.Parent == null) ? string.Empty : di.Parent.FullName.Replace(di.Root.FullName, string.Empty);
            }
            else
            {
                path = di.Parent.FullName.Substring(
                    di.Parent.FullName.IndexOf(di.Root.Name));
            }
            if ((!path.EndsWith(@"\")) &&
                (path.Length > 0))
            {
                path += @"\";
            }
            if (IncludeFileName)
            {
                path += di.Name;
            }
            return path;
        }
        static private string RootZipEntry(string FilePath, string FullZipEntry,
            ref string RootZipPath, ref string FullRootPath)
        {
            string zipEntry = string.Empty;
            if (FullZipEntry == null)
            {
                FullZipEntry = ZipArchiveMOD.ZipEntry(FilePath, true);
            }
            if ((FilePath != null) && (FilePath != string.Empty))
            {
                zipEntry = ZipArchiveMOD.ZipEntry(FilePath, true);
                if ((zipEntry != FullZipEntry) &&
                    (!zipEntry.EndsWith(@"\")))
                {
                    zipEntry += @"\";
                }
                DirectoryInfo di = new DirectoryInfo(FilePath);
                if ((RootZipPath.IndexOf(zipEntry) == -1) &&
                    (di.Parent != null))
                {
                    FullRootPath = di.Parent.FullName;
                    zipEntry = ZipArchiveMOD.RootZipEntry(FullRootPath,
                        FullZipEntry, ref RootZipPath, ref FullRootPath);
                }
                else
                {
                    RootZipPath = zipEntry;
                    zipEntry = FullZipEntry.Replace(zipEntry, string.Empty);
                }
            }
            return zipEntry;
        }
        static private string RootPathFromFiles(string InitRootPath,
            string[] FilePaths)
        {
            string path = string.Empty;
            DirectoryInfo di = new DirectoryInfo(InitRootPath);
            if (di.Exists)
            {
                path = ZipArchiveMOD.ZipEntry(InitRootPath, true);
            }
            else
            {
                FileInfo fi = new FileInfo(InitRootPath);
                if (fi.Exists)
                {
                    path = ZipArchiveMOD.ZipEntry(InitRootPath, false);
                }
            }
            foreach (string filePath in FilePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    string initPath = ZipArchiveMOD.ZipEntry(
                        InitRootPath, false);
                    string zipRootPath = initPath;
                    string fullRootPath = InitRootPath;
                    string zipPath = ZipArchiveMOD.RootZipEntry(
                        filePath, null, ref zipRootPath, ref fullRootPath);
                    if ((initPath.IndexOf(zipRootPath) == 0) &&
                        (zipRootPath.Length < initPath.Length))
                    {
                        return ZipArchiveMOD.RootPathFromFiles(fullRootPath,
                            FilePaths);
                    }
                }
            }
            return path;
        }


        //public static void CreateArchive(string ArchiveFilePath, string SolutionFilePath, string[] FilePaths, bool RelativePath)
        public static void CreateArchive(string ArchiveFilePath, string SrcFolderPath, string[] FilePaths, bool RelativePath)
        {
            const int blockSize = 16384;
            FileStream fs = new FileStream(ArchiveFilePath, FileMode.Create);
            ZipOutputStream zipStream = new ZipOutputStream(fs);
            string zipRootPath = ZipArchiveMOD.RootPathFromFiles(SrcFolderPath, FilePaths);
            foreach (string filePath in FilePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    FileStream streamToZip = new FileStream(filePath,
                        FileMode.Open, FileAccess.Read);
                    string zipPath = string.Empty;
                    if (RelativePath)
                    {
                        string fullRootPath = filePath;
                        zipPath = ZipArchiveMOD.RootZipEntry(filePath,
                            null, ref zipRootPath, ref fullRootPath);

                        //NBPhuc 30/06/2013 (Khong co thu muc)
                        zipPath = Path.GetFileName(zipPath);
                    }
                    else
                    {
                        zipPath = ZipArchiveMOD.ZipEntry(filePath, true);
                    }
                    ZipEntry zipEntry = new ZipEntry(zipPath);
                    zipStream.PutNextEntry(zipEntry);
                    byte[] buffer = new byte[blockSize];
                    int size = streamToZip.Read(buffer, 0, buffer.Length);
                    zipStream.Write(buffer, 0, size);
                    while (size < streamToZip.Length)
                    {
                        int sizeRead = streamToZip.Read(buffer, 0, buffer.Length);
                        zipStream.Write(buffer, 0, sizeRead);
                        size += sizeRead;
                    }
                    streamToZip.Close();
                }
            }
            zipStream.Finish();
            zipStream.Close();
            fs.Close();
        }
        //public ZipArchive() { }

        public static void UnzipFile(string src, string dest)
        {
            FastZip fz = new FastZip();
            fz.ExtractZip(src, dest, null);
        }
    }

}
