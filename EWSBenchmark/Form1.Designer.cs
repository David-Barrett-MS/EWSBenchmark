namespace EWSBenchmark
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAuth = new System.Windows.Forms.GroupBox();
            this.radioButtonAutodiscover = new System.Windows.Forms.RadioButton();
            this.radioButtonOffice365 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.Request = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageResponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimumResponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaximumResponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxRetrieveAllItems = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMaxItems = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTestRepeats = new System.Windows.Forms.NumericUpDown();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxImpersonate = new System.Windows.Forms.CheckBox();
            this.textBoxMailbox = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.radioButtonCustomUrl = new System.Windows.Forms.RadioButton();
            this.textBoxCustomEWSUrl = new System.Windows.Forms.TextBox();
            this.groupBoxAuth.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestRepeats)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAuth
            // 
            this.groupBoxAuth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxAuth.Controls.Add(this.textBoxCustomEWSUrl);
            this.groupBoxAuth.Controls.Add(this.radioButtonCustomUrl);
            this.groupBoxAuth.Controls.Add(this.radioButtonAutodiscover);
            this.groupBoxAuth.Controls.Add(this.radioButtonOffice365);
            this.groupBoxAuth.Controls.Add(this.label3);
            this.groupBoxAuth.Controls.Add(this.textBoxUsername);
            this.groupBoxAuth.Controls.Add(this.textBoxPassword);
            this.groupBoxAuth.Controls.Add(this.label2);
            this.groupBoxAuth.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAuth.Name = "groupBoxAuth";
            this.groupBoxAuth.Size = new System.Drawing.Size(478, 72);
            this.groupBoxAuth.TabIndex = 2;
            this.groupBoxAuth.TabStop = false;
            this.groupBoxAuth.Text = "EWS Settings";
            // 
            // radioButtonAutodiscover
            // 
            this.radioButtonAutodiscover.AutoSize = true;
            this.radioButtonAutodiscover.Location = new System.Drawing.Point(81, 20);
            this.radioButtonAutodiscover.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonAutodiscover.Name = "radioButtonAutodiscover";
            this.radioButtonAutodiscover.Size = new System.Drawing.Size(87, 17);
            this.radioButtonAutodiscover.TabIndex = 15;
            this.radioButtonAutodiscover.Text = "Autodiscover";
            this.radioButtonAutodiscover.UseVisualStyleBackColor = true;
            // 
            // radioButtonOffice365
            // 
            this.radioButtonOffice365.AutoSize = true;
            this.radioButtonOffice365.Checked = true;
            this.radioButtonOffice365.Location = new System.Drawing.Point(6, 20);
            this.radioButtonOffice365.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonOffice365.Name = "radioButtonOffice365";
            this.radioButtonOffice365.Size = new System.Drawing.Size(74, 17);
            this.radioButtonOffice365.TabIndex = 14;
            this.radioButtonOffice365.TabStop = true;
            this.radioButtonOffice365.Text = "Office 365";
            this.radioButtonOffice365.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(67, 41);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(166, 20);
            this.textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(308, 41);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(166, 20);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewStats);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 233);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.AllowUserToAddRows = false;
            this.dataGridViewStats.AllowUserToDeleteRows = false;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Request,
            this.AverageResponse,
            this.MinimumResponse,
            this.MaximumResponse,
            this.TotalSent});
            this.dataGridViewStats.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.ReadOnly = true;
            this.dataGridViewStats.RowHeadersVisible = false;
            this.dataGridViewStats.Size = new System.Drawing.Size(460, 203);
            this.dataGridViewStats.TabIndex = 0;
            // 
            // Request
            // 
            this.Request.HeaderText = "Request";
            this.Request.Name = "Request";
            this.Request.ReadOnly = true;
            this.Request.Width = 150;
            // 
            // AverageResponse
            // 
            this.AverageResponse.HeaderText = "Average Response";
            this.AverageResponse.Name = "AverageResponse";
            this.AverageResponse.ReadOnly = true;
            this.AverageResponse.Width = 75;
            // 
            // MinimumResponse
            // 
            this.MinimumResponse.HeaderText = "Minimum Response";
            this.MinimumResponse.Name = "MinimumResponse";
            this.MinimumResponse.ReadOnly = true;
            this.MinimumResponse.Width = 75;
            // 
            // MaximumResponse
            // 
            this.MaximumResponse.HeaderText = "Maximum Response";
            this.MaximumResponse.Name = "MaximumResponse";
            this.MaximumResponse.ReadOnly = true;
            this.MaximumResponse.Width = 75;
            // 
            // TotalSent
            // 
            this.TotalSent.HeaderText = "Total Sent";
            this.TotalSent.Name = "TotalSent";
            this.TotalSent.ReadOnly = true;
            this.TotalSent.Width = 75;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(599, 289);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(91, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownThreads);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.checkBoxRetrieveAllItems);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownMaxItems);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownTestRepeats);
            this.groupBox2.Location = new System.Drawing.Point(496, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 193);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Options";
            // 
            // numericUpDownThreads
            // 
            this.numericUpDownThreads.Location = new System.Drawing.Point(135, 95);
            this.numericUpDownThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThreads.Name = "numericUpDownThreads";
            this.numericUpDownThreads.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownThreads.TabIndex = 6;
            this.numericUpDownThreads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Threads:";
            // 
            // checkBoxRetrieveAllItems
            // 
            this.checkBoxRetrieveAllItems.AutoSize = true;
            this.checkBoxRetrieveAllItems.Location = new System.Drawing.Point(88, 72);
            this.checkBoxRetrieveAllItems.Name = "checkBoxRetrieveAllItems";
            this.checkBoxRetrieveAllItems.Size = new System.Drawing.Size(106, 17);
            this.checkBoxRetrieveAllItems.TabIndex = 4;
            this.checkBoxRetrieveAllItems.Text = "Retrieve all items";
            this.checkBoxRetrieveAllItems.UseVisualStyleBackColor = true;
            this.checkBoxRetrieveAllItems.CheckedChanged += new System.EventHandler(this.checkBoxRetrieveAllItems_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max items per folder:";
            // 
            // numericUpDownMaxItems
            // 
            this.numericUpDownMaxItems.Location = new System.Drawing.Point(135, 46);
            this.numericUpDownMaxItems.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMaxItems.Name = "numericUpDownMaxItems";
            this.numericUpDownMaxItems.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownMaxItems.TabIndex = 2;
            this.numericUpDownMaxItems.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Repeat test:";
            // 
            // numericUpDownTestRepeats
            // 
            this.numericUpDownTestRepeats.Location = new System.Drawing.Point(135, 20);
            this.numericUpDownTestRepeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTestRepeats.Name = "numericUpDownTestRepeats";
            this.numericUpDownTestRepeats.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownTestRepeats.TabIndex = 0;
            this.numericUpDownTestRepeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 329);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(684, 186);
            this.listBoxLog.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxImpersonate);
            this.groupBox3.Controls.Add(this.textBoxMailbox);
            this.groupBox3.Location = new System.Drawing.Point(496, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 72);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mailbox";
            // 
            // checkBoxImpersonate
            // 
            this.checkBoxImpersonate.AutoSize = true;
            this.checkBoxImpersonate.Location = new System.Drawing.Point(110, 45);
            this.checkBoxImpersonate.Name = "checkBoxImpersonate";
            this.checkBoxImpersonate.Size = new System.Drawing.Size(84, 17);
            this.checkBoxImpersonate.TabIndex = 1;
            this.checkBoxImpersonate.Text = "Impersonate";
            this.checkBoxImpersonate.UseVisualStyleBackColor = true;
            // 
            // textBoxMailbox
            // 
            this.textBoxMailbox.Location = new System.Drawing.Point(6, 19);
            this.textBoxMailbox.Name = "textBoxMailbox";
            this.textBoxMailbox.Size = new System.Drawing.Size(188, 20);
            this.textBoxMailbox.TabIndex = 0;
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(518, 289);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // radioButtonCustomUrl
            // 
            this.radioButtonCustomUrl.AutoSize = true;
            this.radioButtonCustomUrl.Location = new System.Drawing.Point(173, 20);
            this.radioButtonCustomUrl.Name = "radioButtonCustomUrl";
            this.radioButtonCustomUrl.Size = new System.Drawing.Size(63, 17);
            this.radioButtonCustomUrl.TabIndex = 16;
            this.radioButtonCustomUrl.Text = "Custom:";
            this.radioButtonCustomUrl.UseVisualStyleBackColor = true;
            // 
            // textBoxCustomEWSUrl
            // 
            this.textBoxCustomEWSUrl.Location = new System.Drawing.Point(242, 19);
            this.textBoxCustomEWSUrl.Name = "textBoxCustomEWSUrl";
            this.textBoxCustomEWSUrl.Size = new System.Drawing.Size(232, 20);
            this.textBoxCustomEWSUrl.TabIndex = 17;
            this.textBoxCustomEWSUrl.Text = "https://e1.e16.local/EWS/Exchange.asmx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 526);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "EWS Benchmark";
            this.groupBoxAuth.ResumeLayout(false);
            this.groupBoxAuth.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestRepeats)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Request;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageResponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimumResponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaximumResponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSent;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTestRepeats;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxImpersonate;
        private System.Windows.Forms.TextBox textBoxMailbox;
        private System.Windows.Forms.RadioButton radioButtonAutodiscover;
        private System.Windows.Forms.RadioButton radioButtonOffice365;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxRetrieveAllItems;
        private System.Windows.Forms.NumericUpDown numericUpDownThreads;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCustomEWSUrl;
        private System.Windows.Forms.RadioButton radioButtonCustomUrl;
    }
}

