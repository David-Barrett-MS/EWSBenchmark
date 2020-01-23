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
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMaxItems = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTestRepeats = new System.Windows.Forms.NumericUpDown();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxImpersonate = new System.Windows.Forms.CheckBox();
            this.textBoxMailbox = new System.Windows.Forms.TextBox();
            this.radioButtonOffice365 = new System.Windows.Forms.RadioButton();
            this.radioButtonAutodiscover = new System.Windows.Forms.RadioButton();
            this.groupBoxAuth.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestRepeats)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAuth
            // 
            this.groupBoxAuth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxAuth.Controls.Add(this.radioButtonAutodiscover);
            this.groupBoxAuth.Controls.Add(this.radioButtonOffice365);
            this.groupBoxAuth.Controls.Add(this.label3);
            this.groupBoxAuth.Controls.Add(this.textBoxUsername);
            this.groupBoxAuth.Controls.Add(this.textBoxPassword);
            this.groupBoxAuth.Controls.Add(this.label2);
            this.groupBoxAuth.Location = new System.Drawing.Point(18, 18);
            this.groupBoxAuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxAuth.Name = "groupBoxAuth";
            this.groupBoxAuth.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxAuth.Size = new System.Drawing.Size(717, 111);
            this.groupBoxAuth.TabIndex = 2;
            this.groupBoxAuth.TabStop = false;
            this.groupBoxAuth.Text = "EWS Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(100, 63);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(247, 26);
            this.textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(462, 63);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(247, 26);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewStats);
            this.groupBox1.Location = new System.Drawing.Point(18, 138);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(717, 359);
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
            this.dataGridViewStats.Location = new System.Drawing.Point(9, 29);
            this.dataGridViewStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.ReadOnly = true;
            this.dataGridViewStats.RowHeadersVisible = false;
            this.dataGridViewStats.Size = new System.Drawing.Size(690, 313);
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
            this.buttonStart.Location = new System.Drawing.Point(898, 445);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(136, 35);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownMaxItems);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownTestRepeats);
            this.groupBox2.Location = new System.Drawing.Point(744, 138);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(300, 297);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max items per folder:";
            // 
            // numericUpDownMaxItems
            // 
            this.numericUpDownMaxItems.Location = new System.Drawing.Point(202, 71);
            this.numericUpDownMaxItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownMaxItems.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMaxItems.Name = "numericUpDownMaxItems";
            this.numericUpDownMaxItems.Size = new System.Drawing.Size(88, 26);
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
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Repeat test:";
            // 
            // numericUpDownTestRepeats
            // 
            this.numericUpDownTestRepeats.Location = new System.Drawing.Point(202, 31);
            this.numericUpDownTestRepeats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownTestRepeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTestRepeats.Name = "numericUpDownTestRepeats";
            this.numericUpDownTestRepeats.Size = new System.Drawing.Size(88, 26);
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
            this.listBoxLog.ItemHeight = 20;
            this.listBoxLog.Location = new System.Drawing.Point(18, 506);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1024, 284);
            this.listBoxLog.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxImpersonate);
            this.groupBox3.Controls.Add(this.textBoxMailbox);
            this.groupBox3.Location = new System.Drawing.Point(744, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(300, 111);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mailbox";
            // 
            // checkBoxImpersonate
            // 
            this.checkBoxImpersonate.AutoSize = true;
            this.checkBoxImpersonate.Location = new System.Drawing.Point(165, 69);
            this.checkBoxImpersonate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxImpersonate.Name = "checkBoxImpersonate";
            this.checkBoxImpersonate.Size = new System.Drawing.Size(125, 24);
            this.checkBoxImpersonate.TabIndex = 1;
            this.checkBoxImpersonate.Text = "Impersonate";
            this.checkBoxImpersonate.UseVisualStyleBackColor = true;
            // 
            // textBoxMailbox
            // 
            this.textBoxMailbox.Location = new System.Drawing.Point(9, 29);
            this.textBoxMailbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMailbox.Name = "textBoxMailbox";
            this.textBoxMailbox.Size = new System.Drawing.Size(280, 26);
            this.textBoxMailbox.TabIndex = 0;
            // 
            // radioButtonOffice365
            // 
            this.radioButtonOffice365.AutoSize = true;
            this.radioButtonOffice365.Checked = true;
            this.radioButtonOffice365.Location = new System.Drawing.Point(9, 31);
            this.radioButtonOffice365.Name = "radioButtonOffice365";
            this.radioButtonOffice365.Size = new System.Drawing.Size(107, 24);
            this.radioButtonOffice365.TabIndex = 14;
            this.radioButtonOffice365.TabStop = true;
            this.radioButtonOffice365.Text = "Office 365";
            this.radioButtonOffice365.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutodiscover
            // 
            this.radioButtonAutodiscover.AutoSize = true;
            this.radioButtonAutodiscover.Location = new System.Drawing.Point(122, 31);
            this.radioButtonAutodiscover.Name = "radioButtonAutodiscover";
            this.radioButtonAutodiscover.Size = new System.Drawing.Size(126, 24);
            this.radioButtonAutodiscover.TabIndex = 15;
            this.radioButtonAutodiscover.TabStop = true;
            this.radioButtonAutodiscover.Text = "Autodiscover";
            this.radioButtonAutodiscover.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 809);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "EWS Benchmark";
            this.groupBoxAuth.ResumeLayout(false);
            this.groupBoxAuth.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

