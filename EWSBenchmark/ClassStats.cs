using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSBenchmark
{
    public class StatsUpdatedEventArgs : EventArgs
    {
        private string _statDescription;
        private long _average = 0;
        private long _minimum = 0;
        private long _maximum = 0;
        private long _total = 0;

        public StatsUpdatedEventArgs(string StatDescription, List<long> Stats)
        {
            _statDescription = StatDescription;
            lock (Stats)
            {
                try
                {
                    _average = (long)Stats.Average();
                    _minimum = (long)Stats.Min();
                    _maximum = (long)Stats.Max();
                    _total = Stats.Count();
                }
                catch { }
            }
        }

        public string StatDescription
        {
            get { return _statDescription; }
        }

        public long Average
        {
            get { return _average; }
        }

        public long Minimum
        {
            get { return _minimum; }
        }

        public long Maximum
        {
            get { return _maximum; }
        }

        public long Total
        {
            get { return _total; }
        }
    }

    class ClassStats
    {
        private Dictionary<string, List<long>> _responseTimes;

        public delegate void StatsUpdatedEventHandler(object sender, StatsUpdatedEventArgs a);
        public event StatsUpdatedEventHandler StatUpdated;
        private object _statsLock = new object();

        public ClassStats()
        {
            _responseTimes = new Dictionary<string, List<long>>();
        }

        public void AddStat(string request, long responseTimeInTicks)
        {
            TimeSpan responseTime = new TimeSpan(responseTimeInTicks);
            lock (_responseTimes)
            {
                if (!_responseTimes.ContainsKey(request))
                    _responseTimes.Add(request, new List<long>());
                _responseTimes[request].Add((long)responseTime.TotalMilliseconds);
            }
            OnStatUpdated(new StatsUpdatedEventArgs(request, _responseTimes[request]));
        }

        protected virtual void OnStatUpdated(StatsUpdatedEventArgs a)
        {
            StatsUpdatedEventHandler handler = StatUpdated;

            if (handler != null)
            {
                handler(this, a);
            }
        }

        public void LogStats(ClassLogger Logger)
        {
            // Write the current stats to the logger
            foreach (string sStat in _responseTimes.Keys)
            {
                try
                {
                int iAverage = (int)_responseTimes[sStat].Average();
                int iMinimum = (int)_responseTimes[sStat].Min();
                int iMaximum = (int)_responseTimes[sStat].Max();
                int iTotal = _responseTimes[sStat].Count;
                Logger.Log(String.Format("{0}: Average {1}ms, Min {2}ms, Max {3}ms, {4} total requests", sStat, iAverage, iMinimum, iMaximum, iTotal));
                }
                catch { }
            }
        }
    }
}
