using System;
using System.Text.Json;

namespace Transverse.Common.DebugTools
{
    public static class Debug
    {
        public static void ShowData(object data)
        {
            Console.WriteLine(GetSerializedData(data));
        }

        public static string GetSerializedData(object data, bool indented = true)
        {
            var retour = JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = indented });

            return retour;
        }
    }
}
