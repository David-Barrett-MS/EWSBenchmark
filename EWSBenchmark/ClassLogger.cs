/*
 * By David Barrett, Microsoft Ltd. 2012. Use at your own risk.  No warranties are given.
 * 
 * DISCLAIMER:
 * THIS CODE IS SAMPLE CODE. THESE SAMPLES ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND.
 * MICROSOFT FURTHER DISCLAIMS ALL IMPLIED WARRANTIES INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OF MERCHANTABILITY OR OF FITNESS FOR
 * A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF THE USE OR PERFORMANCE OF THE SAMPLES REMAINS WITH YOU. IN NO EVENT SHALL
 * MICROSOFT OR ITS SUPPLIERS BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
 * BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE
 * SAMPLES, EVEN IF MICROSOFT HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
 * OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EWSBenchmark
{
    public class LoggerEventArgs : EventArgs
    {
        private DateTime _logTime;
        private string _logDetails;

        public LoggerEventArgs(DateTime LogTime, string LogDetails)
        {
            _logTime = LogTime;
            _logDetails = LogDetails;
        }

        public DateTime LogTime
        {
            get { return _logTime; }
        }

        public string LogDetails
        {
            get { return _logDetails; }
        }
    }

    public class ClassLogger
    {
        private StreamWriter _logStream = null;
        private string _logPath = "";
        private bool _logDateAndTime = true;
        private bool _storeLogs = false;
        private Dictionary<DateTime, string> _logHistory = null;

        public delegate void LoggerEventHandler(object sender, LoggerEventArgs a);
        public event LoggerEventHandler LogAdded;

        public ClassLogger(string LogFile)
        {
            if (!String.IsNullOrEmpty(LogFile))
            {
                try
                {
                    _logStream = File.AppendText(LogFile);
                    _logPath = LogFile;
                }
                catch { }
            }
            ClearHistory();
        }

        ~ClassLogger()
        {
            try
            {
                _logStream.Flush();
                _logStream.Close();
            }
            catch { }
        }

        protected virtual void OnLogAdded(LoggerEventArgs e)
        {
            LoggerEventHandler handler = LogAdded;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public bool LogDateAndTime
        {
            get { return _logDateAndTime; }
            set { _logDateAndTime = value; }
        }

        public bool StoreLogs
        {
            get { return _storeLogs; }
            set { _storeLogs = value; }
        }

        public Dictionary<DateTime, string> LogHistory
        {
            get { return _logHistory; }
        }

        public void ClearHistory()
        {
            _logHistory = new Dictionary<DateTime, string>();
        }

        public void ClearFile()
        {
        }

        public void Log(string Details)
        {
            try
            {
                DateTime oLogTime = DateTime.Now;
                if (_storeLogs)
                {
                    // If we log too quickly, we'll hit an error here (duplicate dates), so we add a tick if that is the case
                    while (_logHistory.ContainsKey(oLogTime))
                        oLogTime = oLogTime.AddTicks(1);
                    if (!_logHistory.ContainsKey(oLogTime))
                    {
                        _logHistory.Add(oLogTime, Details);
                    }
                }
                if (!(_logStream == null))
                {
                    if (_logDateAndTime)
                        _logStream.WriteLine(String.Format("{0:dd/MM/yy HH:mm:ss}  {1}", oLogTime, Details));
                    _logStream.Flush();
                }
                OnLogAdded(new LoggerEventArgs(oLogTime, Details));
            }
            catch { }
        }
    }
}
