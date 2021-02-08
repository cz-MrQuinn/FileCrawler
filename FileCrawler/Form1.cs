using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            forms.DirectoryContent dirForm = new forms.DirectoryContent();
            dirForm.MdiParent = this;
            dirForm.Show();
        }

        private void mnuFile_SearchDirs_Click(object sender, EventArgs e)
        {
            forms.DirectoryContent dirForm = new forms.DirectoryContent();
            dirForm.MdiParent = this;
            dirForm.Show();
        }
    }
}
