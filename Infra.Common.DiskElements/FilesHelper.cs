using System;
using System.IO;

namespace Infra.Common.DiskElements
{
    public static class FilesHelper
    {
        public static void SetFileContent(string fileFullName, string fileContent)
        {
            fileFullName = fileFullName.Trim();

            var filePath = URLsHelper.ExtractPath(fileFullName);
            if (filePath != "")
            {
                URLsHelper.CreateFolderIfNotExist(filePath); //Créera automatiquement l'ARBORESCENCE nécessaire.
            }

            File.WriteAllText(fileFullName, fileContent);
        }

    }
}
