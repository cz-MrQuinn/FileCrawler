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

        int id = 0;

        public List<viewmodels.DirListingItem> Polozky = new List<viewmodels.DirListingItem>();
        public DirectoryContent()
        {
            InitializeComponent();
        }

        private void DirectoryContent_Load(object sender, EventArgs e)
        {

            this.Path = @"O:\!_Movies";
            StartRecursiveTrace(this.Path);
            classes.exportCSV<viewmodels.DirListingItem> exportCSV = new classes.exportCSV<viewmodels.DirListingItem>(Polozky);
            exportCSV.ExportToFile(@"O:\!_Movies\content.csv");
        }

        private void StartRecursiveTrace(string DirPath)
        {
            if (Directory.Exists(DirPath))
            {
                string[] files = Directory.GetFiles(DirPath);

                foreach (string s in files)
                {
                    id++;
                    Polozky.Add(new viewmodels.DirListingItem()
                    {
                        DirName = DirPath,
                        FileName = s,
                        id = id,
                        FileHash = classes.FileChecksum.GetChecksum(s)
                    });
                }

                string[] dirs = Directory.GetDirectories(DirPath);

                foreach (string d in dirs)
                {
                    string pathToCheck = DirPath + "\\" + d;
                    StartRecursiveTrace(d);
                }


            } else
            { 
                MessageBox.Show(String.Format("Directory {0} does not exist;", DirPath));                
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var vysl = folderBrowserDialog1.ShowDialog();

            if (vysl == DialogResult.OK)
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
