using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

namespace EWSBenchmark
{
    public partial class Form1 : Form
    {
        private ClassStats _stats;
        private ClassLogger _logger;
        private ClassBenchmark _benchmark = null;

        public Form1()
        {
            InitializeComponent();
            _stats = new ClassStats();
            _stats.StatUpdated += _stats_StatUpdated;
            _logger = new ClassLogger("EWSBenchmark.log");
            _logger.LogAdded += _logger_LogAdded;
        }

        void _logger_LogAdded(object sender, LoggerEventArgs a)
        {
            listBoxLog.Invoke(new MethodInvoker(delegate()
                {
                    if (listBoxLog.Items.Count > 1000)
                        listBoxLog.Items.RemoveAt(0);
                    listBoxLog.Items.Add(String.Format("{0:HH:mm:ss} {1}", a.LogTime, a.LogDetails));
                    listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
                }));
        }

        void _stats_StatUpdated(object sender, StatsUpdatedEventArgs a)
        {
            dataGridViewStats.Invoke(new MethodInvoker(delegate()
                {
                    int iUpdateRow = -1;
                    for (int i = 0; i < dataGridViewStats.Rows.Count; i++)
                    {
                        if (((string)dataGridViewStats[0, i].Value) == a.StatDescription)
                        {
                            iUpdateRow = i;
                            break;
                        }
                    }
                    if (iUpdateRow < 0)
                    {
                        dataGridViewStats.Rows.Add();
                        iUpdateRow = dataGridViewStats.Rows.Count - 1;
                        dataGridViewStats[0, iUpdateRow].Value = a.StatDescription;
                    }

                    dataGridViewStats[1, iUpdateRow].Value = a.Average;
                    dataGridViewStats[2, iUpdateRow].Value = a.Minimum;
                    dataGridViewStats[3, iUpdateRow].Value = a.Maximum;
                    dataGridViewStats[4, iUpdateRow].Value = a.Total;
                }));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessBenchmark), null);
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        void ProcessBenchmark(object e)
        {
            ExchangeCredentials cred = new WebCredentials(textBoxUsername.Text, textBoxPassword.Text);
            string mailbox = textBoxMailbox.Text;
            if (String.IsNullOrEmpty(mailbox))
                mailbox = textBoxUsername.Text;
            if (radioButtonOffice365.Checked)
            {
                _benchmark = new ClassBenchmark(mailbox, cred, _stats, _logger, "https://outlook.office365.com/EWS/Exchange.asmx");
            }
            else if (radioButtonCustomUrl.Checked)
            {
                _benchmark = new ClassBenchmark(mailbox, cred, _stats, _logger, textBoxCustomEWSUrl.Text);
                ClassBenchmark.IgnoreSSLErrors = true;
            }
            else
                _benchmark = new ClassBenchmark(mailbox, cred, _stats, _logger);

            _benchmark.MaxThreads = (int)numericUpDownThreads.Value;

            if (checkBoxImpersonate.Checked)
            {
                _benchmark.Impersonate(textBoxMailbox.Text);
            }
            _benchmark.MaxItems = (int)numericUpDownMaxItems.Value;
            if (checkBoxRetrieveAllItems.Checked)
                _benchmark.MaxItems = -1;
            _benchmark.TestRuns = (int)numericUpDownTestRepeats.Value;
            _benchmark.RunBenchmark();

            Action action = new Action(() =>
            {
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            });
            if (buttonStart.InvokeRequired)
                buttonStart.Invoke(action);
            else
                action();
        }

        private void UpdateAuthBoxes()
        {
            bool bEnableBoxes = true;
            textBoxUsername.Enabled = bEnableBoxes;
            textBoxPassword.Enabled = bEnableBoxes;
        }

        private void radioButtonDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthBoxes();
        }

        private void radioButtonSpecificCredentials_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthBoxes();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (_benchmark == null)
                return;
            _benchmark.Stop();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        private void checkBoxRetrieveAllItems_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMaxItems.Enabled = !checkBoxRetrieveAllItems.Checked;
        }
    }
}
