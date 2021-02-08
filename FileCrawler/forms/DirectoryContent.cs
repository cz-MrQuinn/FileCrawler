using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCrawler.forms
{
    public partial class DirectoryContent : Form
    {

        public string Path { get; set; }
        public bool SubDirs { get; set; }

        public bool MakeHash { get; set; }
        public bool ProtokolTargetDir { get; set; }

        int id = 0;

        public List<viewmodels.DirListingItem> Polozky = new List<viewmodels.DirListingItem>();
        public DirectoryContent()
        {
            InitializeComponent();
        }

        private void DirectoryContent_Load(object sender, EventArgs e)
        {

            //this.Path = @"O:\!_Movies";
            //StartRecursiveTrace(this.Path);
            //classes.exportCSV<viewmodels.DirListingItem> exportCSV = new classes.exportCSV<viewmodels.DirListingItem>(Polozky);
            //exportCSV.ExportToFile(@"O:\!_Movies\content.csv");

            this.cbMakeHash_CheckedChanged(this, EventArgs.Empty);
            this.cbProtokolTargetDir_CheckedChanged(this, EventArgs.Empty);

        }

        private void StartRecursiveTrace(string DirPath)
        {
            if (Directory.Exists(DirPath))
            {
                string[] files = Directory.GetFiles(DirPath);

                foreach (string s in files)
                {
                    long filesize = new System.IO.FileInfo(s).Length;

                    id++;
                    Polozky.Add(new viewmodels.DirListingItem()
                    {
                        DirName = DirPath,
                        FileName = s.Substring(DirPath.Length + 1),
                        id = id,
                        FileSize = filesize,
                        FileCreated = File.GetCreationTime(s),
                        FileLastAccess = File.GetLastAccessTime(s),
                        FileLastWrite = File.GetLastWriteTime(s)
                        //FileHash = classes.FileChecksum.GetChecksum(s)
                    });
                }

                string[] dirs = Directory.GetDirectories(DirPath);

                foreach (string d in dirs)
                {
                    string pathToCheck = DirPath + "\\" + d;
                    StartRecursiveTrace(d);
                }


            }
            else
            {
                MessageBox.Show(String.Format("Directory {0} does not exist;", DirPath));
            }

        }

        private void updateListView()
        {
            Cursor.Current = Cursors.WaitCursor;

            listView1.BeginUpdate();
            listView1.Items.Clear();


            foreach (var v in Polozky)
            {
                ListViewItem lvi = new ListViewItem(v.id.ToString());
                lvi.Tag = v;
                lvi.SubItems.Add(v.DirName);
                lvi.SubItems.Add(v.FileName);
                lvi.SubItems.Add(v.FileHash);
                listView1.Items.Add(lvi);
            }

            listView1.EndUpdate();

            Cursor.Current = Cursors.Default;
        }

        private void StartCountingHash()
        {
            int Aktualni_polozka = 0;
            int PocetCelkem = Polozky.Count;
            int hodnota0 = 0;

            foreach (var v in Polozky)
            {
                v.FileHash = classes.FileChecksum.GetChecksum(v.DirName + "//" + v.FileName);

                Aktualni_polozka++;
                int hodnota1 = (int)(((float)Aktualni_polozka / (float)PocetCelkem) * 100);

                backgroundWorker1.ReportProgress(hodnota0, "počítám soubor: " + v.DirName + "//" + v.FileName);

                //if (hodnota0 < hodnota1)
                //{
                //    hodnota0 = hodnota1;
                //    backgroundWorker1.ReportProgress(hodnota0, "počítám soubor: " + v.DirName + "//" + v.FileName);
                //} else
                //{
                //    backgroundWorker1.ReportProgress(hodnota0, "počítám soubor: " + v.DirName + "//" + v.FileName);
                //}
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var vysl = folderBrowserDialog1.ShowDialog();

            if (vysl == DialogResult.OK)
            {
                this.textBox1.TextChanged -= new System.EventHandler(this.textBox1_TextChanged);
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
                this.Path = folderBrowserDialog1.SelectedPath;
                this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            StartRecursiveTrace(this.Path);
            backgroundWorker1.ReportProgress(2, (object)"itemsDone");

            if (MakeHash)
            { 
                StartCountingHash();
                backgroundWorker1.ReportProgress(100, (object)"itemsDone");
            }
        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;

            if (e.UserState == (object)"itemsDone")
                updateListView();

            if (e.UserState.ToString().StartsWith("počítám soubor:"))
            {
                label1.Text = e.UserState.ToString();
                this.Update();
            }

        }

        private void btnStartWorker_Click(object sender, EventArgs e)
        {
            //this.Path = textBox1.Text;

            this.progressBar1.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Value = 100;
            this.progressBar1.Hide();
            updateListView();

            classes.exportCSV<viewmodels.DirListingItem> exportCSV = new classes.exportCSV<viewmodels.DirListingItem>(Polozky);

            if (ProtokolTargetDir)
                exportCSV.ExportToFile(Path + @"\content.csv");
            else
                exportCSV.ExportToFile(String.Format("content{0:yyyy-MM-dd_hhmmss}.csv", DateTime.Now));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Path = textBox1.Text;
        }

        private void cbMakeHash_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMakeHash.Checked)
                this.MakeHash = true;
            else
                this.MakeHash = false;
        }

        private void cbProtokolTargetDir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProtokolTargetDir.Checked)
                this.ProtokolTargetDir = true;
            else
                this.ProtokolTargetDir = false;
        }
    }
}
