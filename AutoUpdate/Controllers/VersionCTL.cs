using AutoUpdate.Models;
using AutoUpdate.Objects;
using System;
using System.Collections.Generic;

namespace AutoUpdate.Controllers
{
    public class VersionCTL
    {
        public static VersionOBJ GetLastestVersion()
        {
            return VersionMOD.GetLastestVersion();
        }

        public static List<VersionOBJ> GetAllVersions()
        {
            return VersionMOD.GetAllVersions();
        }

        public static bool InsertNewVersion(VersionOBJ verObj)
        {
            return VersionMOD.InsertNewVersion(verObj);
        }

        public static bool WriteNewVersion(VersionOBJ verObj, string sfilePath)
        {
            return VersionMOD.WriteNewVersion(verObj, sfilePath);
        }

        public static string ReadCurrentVersion(string sfilePath)
        {
            return VersionMOD.ReadCurrentVersion(sfilePath);
        }
    }
}
