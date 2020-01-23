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
        }

        void ProcessBenchmark(object e)
        {
            ClassBenchmark benchmark = null;

            ExchangeCredentials cred = new WebCredentials(textBoxUsername.Text, textBoxPassword.Text);
            if (radioButtonOffice365.Checked)
            {
                benchmark = new ClassBenchmark(textBoxMailbox.Text, cred, _stats, _logger, "https://outlook.office365.com/EWS/Exchange.asmx");
            }
            else
                benchmark = new ClassBenchmark(textBoxMailbox.Text, cred, _stats, _logger);

            if (checkBoxImpersonate.Checked)
            {
                benchmark.Impersonate(textBoxMailbox.Text);
            }
            benchmark.MaxItems = (int)numericUpDownMaxItems.Value;
            benchmark.TestRuns = (int)numericUpDownTestRepeats.Value;
            benchmark.StartBenchmark();
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

    }
}
