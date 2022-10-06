using System.Collections.Generic;

using Infra.Common.DataAccess.Interfaces;
using Infra.Common.DataAccess.Abstracts;

namespace Infra.Common.DataAccess
{
    public class DBServerAccessConfiguration : AServerAccessConfiguration, IDBServerAccessConfiguration
    {
        public string DatabaseName { get; init; } = "";

        public DBServerAccessConfiguration(
            string serverName = "Server1",
            string jsonFile = "./_MyAssets/DBServersAccess.json" //Chemin relatif au chemin des DLL du projet de Démarrage(client final !!)
        ): base(serverName, jsonFile)
        {
        }

        protected override Dictionary<string, string> GetInfosAsDictionary()
        {
            var retour = new Dictionary<string, string>()
            {
                { "Server", Url },
                { "User Id", Login },
                { "Password", Password },
            };
            retour.Add("Database", DatabaseName);

            return retour;
        }
    }
}