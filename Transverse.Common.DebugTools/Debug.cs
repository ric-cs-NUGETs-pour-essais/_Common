using System;

//using System.Text.Json; //En .net5, ne permet pas d'ignorer simplement les dépendances cycliques.
using Newtonsoft.Json;

namespace Transverse.Common.DebugTools
{
    public static class Debug
    {
        public static void ShowData(object data)
        {
            Console.WriteLine(GetSerializedData(data, true));
        }

        // using System.Text.Json; //En .net5, ne permet pas d'ignorer simplement les dépendances cycliques.
        /*public static string GetSerializedData(object data, bool indented = true)
        {
            var retour = JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = indented });

            return retour;
        }*/

        public static string GetSerializedData(object data, bool indented = false)
        {
            Formatting formatting = (indented) ? Formatting.Indented : Formatting.None;
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

            var retour = JsonConvert.SerializeObject(data, formatting, jsonSerializerSettings);

            return retour;
        }
    }
}
