using System;
using System.Diagnostics;

namespace Transverse.Common.DebugTools
{
    public class Chrono
    {
        private readonly Stopwatch chrono;

        public Chrono()
        {
            chrono = new Stopwatch();
        }

        public void Start()
        {
            chrono.Start();
        }
        public void StopAndShowDuration(string format = "\n - Temps écoulé : {0}ms -")
        {
            chrono.Stop();

            Console.WriteLine(string.Format(format, chrono.ElapsedMilliseconds));
        }

    }
}
