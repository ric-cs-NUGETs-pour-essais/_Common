using System;
using System.IO;

namespace Infra.Common
{
    public static class Environment
    {
        public static bool IsHome()
        {
            var retour = Directory.Exists("I:");
            return retour;
        }
    }
}
