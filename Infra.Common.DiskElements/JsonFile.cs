using System;
using System.IO;
using System.Text.Json;

namespace Infra.Common.DiskElements
{
    public class JsonFile<TContentType>
        where TContentType : class, new()
    {
        private readonly string jsonFile;

        private TContentType content;
        public TContentType Content
        {
            get
            {
                return content ?? (content = GetFileContentAsObject());
            }
        }

        public JsonFile(string jsonFile)
        {
            if (string.IsNullOrWhiteSpace(jsonFile))
            {
                throw new ArgumentException($"'{nameof(jsonFile)}' ne peut pas avoir une valeur null ou être un espace blanc.", nameof(jsonFile));
            }

            this.jsonFile = jsonFile;
        }

        public void Save()
        {
            var contentAsSerialized = GetContentAsSerialized();
            FilesHelper.SetFileContent(jsonFile, contentAsSerialized);
        }

        private string GetContentAsSerialized()
        {
            var retour = JsonSerializer.Serialize<TContentType>(Content);
            return retour;
        }

        private TContentType GetFileContentAsObject()
        {
            TContentType retour;
            var jsonFileContent = GetFileContent();
            if (!string.IsNullOrWhiteSpace(jsonFileContent))
            {
                retour = JsonSerializer.Deserialize<TContentType>(jsonFileContent);

            }
            else
            {
                retour = new TContentType();
            }

            return retour;
        }

        private string GetFileContent()
        {
            string retour = null;

            try
            {
                retour = File.ReadAllText(jsonFile);
            }
            catch (Exception) 
            { 
                //throw new Exception($"Pas de fichier '{jsonFile}' accessible.");
            }

            return retour;
        }

    }
}
