using System;
using System.IO;
using System.Text.RegularExpressions;

using Transverse.Common.Strings;

namespace Infra.Common.DiskElements
{
    public static class URLsHelper
    {
        private static readonly string backSlash = @"\";
        private static readonly string slash = "/";

        public static bool CreateFolderIfNotExist(string folderFullName)
        {
            var newlyCreated = false;

            if (!Directory.Exists(folderFullName))
            {
                Directory.CreateDirectory(folderFullName);
                newlyCreated = true;
            }

            return newlyCreated;
        }

        public static string ExtractAfterPath(string url)
        {
            url = url.Trim();
            url = BackSlashDrive(url, false);

            var afterPathPosition = GetAfterPathPosition(url);

            var retour = url.Substring_(afterPathPosition);
            return retour;
        }

        public static string ExtractPath(string url, bool endBySeparator = true, bool backSlashedPath = false)
        {
            url = url.Trim();
            url = BackSlash(url, backSlashedPath);

            var afterPathPosition = GetAfterPathPosition(url);

            var retour = url.Substring(0, afterPathPosition);
            if (retour != string.Empty)
            {
                var separator = (backSlashedPath) ? backSlash : slash;
                retour = retour.EndsWith_(endBySeparator, separator);
            }
            return retour;
        }

        private static int GetAfterPathPosition(string url)
        {
            var separator = slash;
            url = url.Replace(backSlash, slash);

            var lastSeparatorPosition = url.LastIndexOf(separator);
            var retour = (lastSeparatorPosition == -1) ? 0 : (lastSeparatorPosition + 1);
            return retour;
        }

        public static string BackSlash(string url, bool backSlashedPath = true)
        {
            url = BackSlashDrive(url, backSlashedPath);

            string toReplace = (backSlashedPath) ? slash : backSlash;
            string replaceBy = (backSlashedPath) ? backSlash : slash;

            var retour = url.Replace(toReplace, replaceBy);
            return retour;
        }

        private static string BackSlashDrive(string url, bool backSlashedPath = true)
        {
            var retour = url;

            if (StartsByDrive(url))
            {
                url = url.Trim();
                const int afterDrivePosition = 2;
                var justAfterDrive = url.Substring_(afterDrivePosition, 1);
                if (justAfterDrive != slash && justAfterDrive != backSlash)
                {
                    var separator = (backSlashedPath) ? backSlash : slash;
                    var drivePart = url.Substring(0, afterDrivePosition);
                    var afterDrivePart = url.Substring_(afterDrivePosition);
                    retour = $"{drivePart}{separator}{afterDrivePart}";
                }
            }

            return retour;
        }

        private static bool StartsByDrive(string url)
        {
            url = url.Trim();
            var retour = Regex.IsMatch(url, @"^[A-Z][:]", RegexOptions.IgnoreCase);
            return retour;
        }
    }
}
