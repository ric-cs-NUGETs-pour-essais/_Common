using System;


using Infra.Common.DataAccess.Interfaces;

using Infra.Common.DataAccess;
using Transverse.Common.DebugTools;

namespace ConsolePrj
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var c = new Chrono();  c.Start();

            //Le présent projet fait office de testeur, en lieu et place d'un projet externe qui souhaiterait utiliser les fonctionnalités ci-dessous :
            IDBServerAccessConfiguration dbServerAccessConfiguration = new DBServerAccessConfiguration()
            {
                DatabaseName = "MaBase",
                Options = "yyy=true"
            };
            Debug.ShowData(dbServerAccessConfiguration);
            
            //c.StopAndShowDuration();

            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

    }
}
