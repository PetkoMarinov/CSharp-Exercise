using System.Diagnostics;

namespace Chronometer
{
    public class Start
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Started");
            Console.WriteLine();
            Thread.Sleep(1000);
            sw.Stop();
            var time = sw.Elapsed;
            Console.WriteLine("Stopped");
            Console.WriteLine(time);
        }
    }
}
