using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        public Chronometer()
        {
        }

        public string GetTime => this.GetTime;

        public List<string> Laps => throw new NotImplementedException();

        public string Lap()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
    }
}