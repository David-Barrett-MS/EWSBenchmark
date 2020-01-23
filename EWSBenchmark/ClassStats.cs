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
        private List<long> _statList;

        public StatsUpdatedEventArgs(string StatDescription, List<long> Stats)
        {
            _statDescription = StatDescription;
            _statList = Stats;
        }

        public string StatDescription
        {
            get { return _statDescription; }
        }

        public long Average
        {
            get { return (long)_statList.Average(); }
        }

        public long Minimum
        {
            get { return _statList.Min(); }
        }

        public long Maximum
        {
            get { return _statList.Max(); }
        }

        public long Total
        {
            get { return _statList.Count; }
        }
    }

    class ClassStats
    {
        private Dictionary<string, List<long>> _responseTimes;

        public delegate void StatsUpdatedEventHandler(object sender, StatsUpdatedEventArgs a);
        public event StatsUpdatedEventHandler StatUpdated;

        public ClassStats()
        {
            _responseTimes = new Dictionary<string, List<long>>();
        }

        public void AddStat(string request, long responseTimeInTicks)
        {
            TimeSpan responseTime = new TimeSpan(responseTimeInTicks);
            if (!_responseTimes.ContainsKey(request))
                _responseTimes.Add(request, new List<long>());
            _responseTimes[request].Add((long)responseTime.TotalMilliseconds);
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
