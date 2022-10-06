//using System;
using System.Collections.Generic;
//using System.IO;

using Microsoft.Extensions.Configuration; //ATTENTION : NuGet indispensable : Microsoft.Extensions.Configuration.Json
                                          //            pour pouvoir bénéficier ici de l'ensemble des fonctionnalités utilisées.

using Transverse.Common.DebugTools;
using Infra.Common.DataAccess.Interfaces;

namespace Infra.Common.DataAccess.Abstracts
{
    public abstract class AServerAccessConfiguration : IServerAccessConfiguration
    {
        private readonly string serverName; //Clef pour les infos du serveur, dans le fichier .json.
        private readonly string jsonFile;

        public string Url { get; private set; }

        public string Login { get; private set; }
        public string Password { get; private set; }

        public string Options { get; init;  } = "";

        protected abstract Dictionary<string, string> GetInfosAsDictionary();


        protected AServerAccessConfiguration(
            string serverName = "Server1",
            string jsonFile = "./_MyAssets/ServersAccess.json" //Chemin relatif au chemin des DLL du projet de Démarrage : du projet client final !!
        )
        {
            this.serverName = serverName;
            this.jsonFile = jsonFile;

            Init();
        }

        public string GetConnectionString()
        {
            var infosAsList = GetInfosAsList();
            var retour = string.Join("; ", infosAsList);
            return retour;
        }

        private IList<string> GetInfosAsList()
        {
            var infosAsDictionary = GetInfosAsDictionary();
            IList<string> retours = new List<string>();

            foreach (var keyValue in infosAsDictionary)
            {
                retours.Add($"{keyValue.Key}={keyValue.Value}");
            }

            if (!string.IsNullOrWhiteSpace(Options))
            {
                retours.Add(Options);
            }

            return retours;
        }

        private void Init()
        {
            //Console.WriteLine( File.ReadAllText(jsonFile) );

            var configuration = GetConfiguration();

            Url = configuration.GetSection($"{serverName}:Url").Value;
            Login = configuration.GetSection($"{serverName}:Login").Value;
            Password = configuration.GetSection($"{serverName}:Password").Value;

            //Debug.ShowData(this);
        }

        private IConfiguration GetConfiguration()
        {
            IConfigurationBuilder oConfigBuilder = new ConfigurationBuilder()
                .AddJsonFile(jsonFile, optional: false); //false => le fichier DOIT exister (chemin relatif au répertoire des DLL du projet de démarrage)
                                                         // Il peut y être copié automatiquement après Build du projet de démarrage,
                                                         //  ceci moyennant paramétrage correct du .csproj de démarrage. 

            IConfiguration retour = oConfigBuilder.Build();
            return (retour);
        }
    }
}