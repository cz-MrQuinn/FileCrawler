namespace FileCrawler.forms
{
    partial class DirectoryContent
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContMain = new System.Windows.Forms.SplitContainer();
            this.cbProtokolTargetDir = new System.Windows.Forms.CheckBox();
            this.cbMakeHash = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStartWorker = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ContMain)).BeginInit();
            this.ContMain.Panel1.SuspendLayout();
            this.ContMain.Panel2.SuspendLayout();
            this.ContMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(754, 665);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 231;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 185;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 205;
            // 
            // ContMain
            // 
            this.ContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContMain.Location = new System.Drawing.Point(0, 0);
            this.ContMain.Margin = new System.Windows.Forms.Padding(4);
            this.ContMain.Name = "ContMain";
            this.ContMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContMain.Panel1
            // 
            this.ContMain.Panel1.Controls.Add(this.cbProtokolTargetDir);
            this.ContMain.Panel1.Controls.Add(this.cbMakeHash);
            this.ContMain.Panel1.Controls.Add(this.label1);
            this.ContMain.Panel1.Controls.Add(this.progressBar1);
            this.ContMain.Panel1.Controls.Add(this.btnStartWorker);
            this.ContMain.Panel1.Controls.Add(this.btnBrowse);
            this.ContMain.Panel1.Controls.Add(this.textBox1);
            // 
            // ContMain.Panel2
            // 
            this.ContMain.Panel2.Controls.Add(this.listView1);
            this.ContMain.Size = new System.Drawing.Size(754, 807);
            this.ContMain.SplitterDistance = 137;
            this.ContMain.SplitterWidth = 5;
            this.ContMain.TabIndex = 1;
            // 
            // cbProtokolTargetDir
            // 
            this.cbProtokolTargetDir.AutoSize = true;
            this.cbProtokolTargetDir.Checked = true;
            this.cbProtokolTargetDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProtokolTargetDir.Location = new System.Drawing.Point(522, 53);
            this.cbProtokolTargetDir.Name = "cbProtokolTargetDir";
            this.cbProtokolTargetDir.Size = new System.Drawing.Size(145, 21);
            this.cbProtokolTargetDir.TabIndex = 5;
            this.cbProtokolTargetDir.Text = "protokol v adresáři";
            this.cbProtokolTargetDir.UseVisualStyleBackColor = true;
            this.cbProtokolTargetDir.CheckedChanged += new System.EventHandler(this.cbProtokolTargetDir_CheckedChanged);
            // 
            // cbMakeHash
            // 
            this.cbMakeHash.AutoSize = true;
            this.cbMakeHash.Location = new System.Drawing.Point(267, 53);
            this.cbMakeHash.Name = "cbMakeHash";
            this.cbMakeHash.Size = new System.Drawing.Size(161, 21);
            this.cbMakeHash.TabIndex = 5;
            this.cbMakeHash.Text = "Počítat hash souborů";
            this.cbMakeHash.UseVisualStyleBackColor = true;
            this.cbMakeHash.CheckedChanged += new System.EventHandler(this.cbMakeHash_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 100);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(724, 27);
            this.progressBar1.TabIndex = 3;
            // 
            // btnStartWorker
            // 
            this.btnStartWorker.Location = new System.Drawing.Point(12, 47);
            this.btnStartWorker.Name = "btnStartWorker";
            this.btnStartWorker.Size = new System.Drawing.Size(221, 30);
            this.btnStartWorker.TabIndex = 2;
            this.btnStartWorker.Text = "start";
            this.btnStartWorker.UseVisualStyleBackColor = true;
            this.btnStartWorker.Click += new System.EventHandler(this.btnStartWorker_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(13, 12);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(34, 28);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(59, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(695, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // DirectoryContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 807);
            this.Controls.Add(this.ContMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DirectoryContent";
            this.Text = "DirectoryContent";
            this.Load += new System.EventHandler(this.DirectoryContent_Load);
            this.ContMain.Panel1.ResumeLayout(false);
            this.ContMain.Panel1.PerformLayout();
            this.ContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContMain)).EndInit();
            this.ContMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer ContMain;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnStartWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbProtokolTargetDir;
        private System.Windows.Forms.CheckBox cbMakeHash;
    }
}