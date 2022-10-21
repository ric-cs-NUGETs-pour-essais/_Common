using System;
using System.Collections.Generic;


using Infra.Common.DataAccess.Interfaces;

using Infra.Common.DataAccess;
using Transverse.Common.DebugTools;

namespace ConsolePrj
{
    class SerializeMe
    {
        public List<SerializeMe> listeOfMe { get; } = new List<SerializeMe> { };
        public int p1 = 10;
    }

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


            //Handling of Cyclic dependency in Serialization, OK :
            var oSerializeMe = new SerializeMe();
            var oSerializeMe2 = new SerializeMe();
            oSerializeMe.listeOfMe.Add(oSerializeMe);
            oSerializeMe.listeOfMe.Add(oSerializeMe2);
            Debug.ShowData(oSerializeMe);

            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

    }
}
