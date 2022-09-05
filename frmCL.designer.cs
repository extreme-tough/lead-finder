namespace Craigslist_Emailer
{
    partial class frmCL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCL));
            this.trvCate = new System.Windows.Forms.TreeView();
            this.trvLocations = new System.Windows.Forms.TreeView();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.txtSkipKeywords = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteLog = new System.Windows.Forms.Button();
            this.lblSkipped = new System.Windows.Forms.Label();
            this.lblEmailsSent = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnEmailSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drpTemplate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStop2 = new System.Windows.Forms.Button();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.btnEmail = new System.Windows.Forms.Button();
            this.trvResults = new System.Windows.Forms.TreeView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvCate
            // 
            this.trvCate.CheckBoxes = true;
            this.trvCate.Location = new System.Drawing.Point(142, 22);
            this.trvCate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvCate.Name = "trvCate";
            this.trvCate.Size = new System.Drawing.Size(254, 167);
            this.trvCate.TabIndex = 0;
            this.trvCate.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvCate_AfterCheck);
            // 
            // trvLocations
            // 
            this.trvLocations.CheckBoxes = true;
            this.trvLocations.Location = new System.Drawing.Point(144, 197);
            this.trvLocations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvLocations.Name = "trvLocations";
            this.trvLocations.Size = new System.Drawing.Size(254, 199);
            this.trvLocations.TabIndex = 1;
            this.trvLocations.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvLocations_AfterCheck);
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Checked = true;
            this.chkEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmail.Location = new System.Drawing.Point(15, 404);
            this.chkEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(344, 20);
            this.chkEmail.TabIndex = 2;
            this.chkEmail.Text = "Should emails be sent to emails like ..@craigslist.org :";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(99, 432);
            this.txtKeywords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(306, 22);
            this.txtKeywords.TabIndex = 3;
            // 
            // txtSkipKeywords
            // 
            this.txtSkipKeywords.Location = new System.Drawing.Point(144, 462);
            this.txtSkipKeywords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSkipKeywords.Name = "txtSkipKeywords";
            this.txtSkipKeywords.Size = new System.Drawing.Size(261, 22);
            this.txtSkipKeywords.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(286, 492);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 28);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(166, 492);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 28);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Categories:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Locations:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keywords:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Keywords to skip:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Current Category under extraction:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Current Area under extraction      :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 607);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "No. of listings skipped/duplicate  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 584);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "No. of emails sent                      :";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(286, 639);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 28);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteLog
            // 
            this.btnDeleteLog.Location = new System.Drawing.Point(166, 639);
            this.btnDeleteLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteLog.Name = "btnDeleteLog";
            this.btnDeleteLog.Size = new System.Drawing.Size(114, 28);
            this.btnDeleteLog.TabIndex = 16;
            this.btnDeleteLog.Text = "Delete log";
            this.btnDeleteLog.UseVisualStyleBackColor = true;
            this.btnDeleteLog.Visible = false;
            // 
            // lblSkipped
            // 
            this.lblSkipped.AutoSize = true;
            this.lblSkipped.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipped.Location = new System.Drawing.Point(218, 607);
            this.lblSkipped.Name = "lblSkipped";
            this.lblSkipped.Size = new System.Drawing.Size(0, 16);
            this.lblSkipped.TabIndex = 21;
            // 
            // lblEmailsSent
            // 
            this.lblEmailsSent.AutoSize = true;
            this.lblEmailsSent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailsSent.Location = new System.Drawing.Point(218, 584);
            this.lblEmailsSent.Name = "lblEmailsSent";
            this.lblEmailsSent.Size = new System.Drawing.Size(0, 16);
            this.lblEmailsSent.TabIndex = 20;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(218, 558);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 16);
            this.lblLocation.TabIndex = 19;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(218, 533);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(0, 16);
            this.lblCategory.TabIndex = 18;
            // 
            // btnEmailSettings
            // 
            this.btnEmailSettings.Location = new System.Drawing.Point(19, 492);
            this.btnEmailSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmailSettings.Name = "btnEmailSettings";
            this.btnEmailSettings.Size = new System.Drawing.Size(141, 28);
            this.btnEmailSettings.TabIndex = 22;
            this.btnEmailSettings.Text = "&Email Settings";
            this.btnEmailSettings.UseVisualStyleBackColor = true;
            this.btnEmailSettings.Click += new System.EventHandler(this.btnEmailSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvCate);
            this.groupBox1.Controls.Add(this.trvLocations);
            this.groupBox1.Controls.Add(this.btnEmailSettings);
            this.groupBox1.Controls.Add(this.chkEmail);
            this.groupBox1.Controls.Add(this.lblSkipped);
            this.groupBox1.Controls.Add(this.txtKeywords);
            this.groupBox1.Controls.Add(this.lblEmailsSent);
            this.groupBox1.Controls.Add(this.txtSkipKeywords);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnDeleteLog);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 676);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Search Criteria\'s";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drpTemplate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnStop2);
            this.groupBox2.Controls.Add(this.wb);
            this.groupBox2.Controls.Add(this.btnEmail);
            this.groupBox2.Controls.Add(this.trvResults);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(433, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 676);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // drpTemplate
            // 
            this.drpTemplate.FormattingEnabled = true;
            this.drpTemplate.Location = new System.Drawing.Point(109, 278);
            this.drpTemplate.Name = "drpTemplate";
            this.drpTemplate.Size = new System.Drawing.Size(396, 24);
            this.drpTemplate.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Email Template :";
            // 
            // btnStop2
            // 
            this.btnStop2.Enabled = false;
            this.btnStop2.Location = new System.Drawing.Point(523, 275);
            this.btnStop2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Size = new System.Drawing.Size(114, 28);
            this.btnStop2.TabIndex = 8;
            this.btnStop2.Text = "S&top";
            this.btnStop2.UseVisualStyleBackColor = true;
            this.btnStop2.Click += new System.EventHandler(this.btnStop2_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(6, 309);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(791, 358);
            this.wb.TabIndex = 7;
            this.wb.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(643, 275);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(154, 28);
            this.btnEmail.TabIndex = 6;
            this.btnEmail.Text = "Email Seleted Ads";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // trvResults
            // 
            this.trvResults.CheckBoxes = true;
            this.trvResults.Location = new System.Drawing.Point(8, 21);
            this.trvResults.Name = "trvResults";
            this.trvResults.Size = new System.Drawing.Size(789, 247);
            this.trvResults.TabIndex = 0;
            this.trvResults.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvResults_AfterSelect);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 691);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(136, 16);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "Last Status Message:";
            // 
            // frmCL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 778);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCL";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Craigslist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvCate;
        private System.Windows.Forms.TreeView trvLocations;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.TextBox txtSkipKeywords;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteLog;
        private System.Windows.Forms.Label lblSkipped;
        private System.Windows.Forms.Label lblEmailsSent;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnEmailSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.TreeView trvResults;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Button btnStop2;
        private System.Windows.Forms.ComboBox drpTemplate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStatus;

    }
}

