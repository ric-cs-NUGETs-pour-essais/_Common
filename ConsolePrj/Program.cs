using System;
using System.Collections.Generic;


using Infra.Common.DataAccess.Interfaces;

using Infra.Common.DataAccess;
using Infra.Common.DiskElements;

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
            //TestDiskElements();

            //TestDBServerAccess();

            //TestSerializationCyclicDependencies();

            //TestEnvironment();

            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

        private static void TestEnvironment()
        {
            Console.WriteLine($"Environment.IsHome() : {Infra.Common.Environment.IsHome()}");
        }

        private static void TestSerializationCyclicDependencies()
        {
            //Handling of Cyclic dependency in Serialization, OK :
            var oSerializeMe = new SerializeMe();
            var oSerializeMe2 = new SerializeMe();
            oSerializeMe.listeOfMe.Add(oSerializeMe);
            oSerializeMe.listeOfMe.Add(oSerializeMe2);
            Debug.ShowData(oSerializeMe);
        }

        private static void TestDBServerAccess()
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
        }

        private static void TestDiskElements()
        {

            Console.WriteLine(URLsHelper.BackSlash(@"d:", true) == @"d:\");
            Console.WriteLine(URLsHelper.BackSlash(@"D:", true) == @"D:\");
            Console.WriteLine(URLsHelper.BackSlash(@"d:", false) == @"d:/");
            Console.WriteLine(URLsHelper.BackSlash(@"d:\aaa\bbb/ccc", false) == @"d:/aaa/bbb/ccc");
            Console.WriteLine(URLsHelper.BackSlash(@"d:\aaa\bbb/ccc", true) == @"d:\aaa\bbb\ccc");
            Console.WriteLine(URLsHelper.BackSlash(@"E:\aaa\bbb/ccc", true) == @"E:\aaa\bbb\ccc");
            Console.WriteLine(URLsHelper.BackSlash(@"E:\aaa\bbb/ccc/", true) == @"E:\aaa\bbb\ccc\");
            Console.WriteLine(URLsHelper.BackSlash(@"E:\aaa\bbb/ccc\", false) == @"E:/aaa/bbb/ccc/");

            Console.WriteLine(URLsHelper.CreateFolderIfNotExist(@"E:\zjjj"));
            Console.WriteLine(URLsHelper.CreateFolderIfNotExist(@"E:\zkkk\"));
            Console.WriteLine(URLsHelper.CreateFolderIfNotExist(@"E:/zlll"));
            Console.WriteLine(URLsHelper.CreateFolderIfNotExist(@"E:/zmmm/"));
            Console.WriteLine(URLsHelper.CreateFolderIfNotExist(@"E:znnn"));

            Console.WriteLine(URLsHelper.ExtractPath(@"") == string.Empty);
            Console.WriteLine(URLsHelper.ExtractPath(@"d:", false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:", false, false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:", false, true) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:", true) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:", true, false) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:", true, true) == @"d:\");

            Console.WriteLine(URLsHelper.ExtractPath(@"toto") == string.Empty);
            Console.WriteLine(URLsHelper.ExtractPath(@"d:toto", false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:toto", false, false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:toto", false, true) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:toto", true) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:toto", true, false) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:toto", true, true) == @"d:\");

            Console.WriteLine(URLsHelper.ExtractPath(@"/") == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"/", false) == "");
            Console.WriteLine(URLsHelper.ExtractPath(@"/", true) == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"/", true, true) == @"\");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/", false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/", false, false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/", false, true) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/", true) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/", true, false) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/", true, true) == @"d:\");

            Console.WriteLine(URLsHelper.ExtractPath(@"/toto") == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"/toto", false) == "");
            Console.WriteLine(URLsHelper.ExtractPath(@"/toto", true) == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"/toto", true, true) == @"\");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/toto", false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/toto", false, false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/toto", false, true) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/toto", true) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/toto", true, false) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:/toto", true, true) == @"d:\");

            Console.WriteLine(URLsHelper.ExtractPath(@"\") == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"\", false) == "");
            Console.WriteLine(URLsHelper.ExtractPath(@"\", true) == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"\", true, true) == @"\");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\", false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\", false, false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\", false, true) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\", true) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\", true, false) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\", true, true) == @"d:\");

            Console.WriteLine(URLsHelper.ExtractPath(@"\toto") == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"\toto", false) == "");
            Console.WriteLine(URLsHelper.ExtractPath(@"\toto", true) == "/");
            Console.WriteLine(URLsHelper.ExtractPath(@"\toto", true, true) == @"\");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto", false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto", false, false) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto", false, true) == "d:");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto", true) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto", true, false) == "d:/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto", true, true) == @"d:\");

            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto/eee\yyy") == "d:/toto/eee/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto/eee\yyy", true, false) == "d:/toto/eee/");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto/eee\yyy", false) == "d:/toto/eee");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto/eee\yyy", false, false) == "d:/toto/eee");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto/eee\yyy", false, true) == @"d:\toto\eee");
            Console.WriteLine(URLsHelper.ExtractPath(@"d:\toto/eee\yyy", true, true) == @"d:\toto\eee\");



            Console.WriteLine(URLsHelper.ExtractAfterPath(@"") == string.Empty);
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:") == string.Empty);

            Console.WriteLine(URLsHelper.ExtractAfterPath(@"toto") == "toto");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:toto") == "toto");

            Console.WriteLine(URLsHelper.ExtractAfterPath(@"/") == "");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:/") == "");

            Console.WriteLine(URLsHelper.ExtractAfterPath(@"/toto") == "toto");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:/toto") == "toto");

            Console.WriteLine(URLsHelper.ExtractAfterPath(@"\") == "");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:\") == "");

            Console.WriteLine(URLsHelper.ExtractAfterPath(@"\toto") == "toto");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:\toto") == "toto");

            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:\toto/eee\yyy") == "yyy");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:/toto/eee/yyy") == "yyy");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:\toto\eee\yyy") == "yyy");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:toto/eee/yyy") == "yyy");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:toto\eee\yyy") == "yyy");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:toto\eee\yyy\") == "");
            Console.WriteLine(URLsHelper.ExtractAfterPath(@"d:toto\eee\yyy/") == "");




            //var path = @"D:/zzzz\yyy/hhh\\wwww//qqqq"; FilesHelper.SetFileContent($"{path}/uuu.txt", "xxx");
        }


    }
}
