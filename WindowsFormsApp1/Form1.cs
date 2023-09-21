using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumerateAllFiles;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnumerateAllFilesClass ea;

            if ((sender as Button).Name.Contains("Single"))
            {
                ea = new EnumerateAllFilesClass(false);
            }
            else
            {
                ea = new EnumerateAllFilesClass(true);
            }
            
            ea.ReportStatus += Ea_ReportStatus;
            ea.EndOfProgress += Ea_EndOfProgress;
            ea.Initialize(new System.IO.DirectoryInfo(@"C:\"));

        }

        private void Ea_EndOfProgress(object sender, OwnArgsLibraryClass e)
        {
            Update_Label(statusLabel2, "KONIEC");
        }

        private void Ea_ReportStatus(object sender, OwnArgsLibraryClass e)
        {
            var data = new StorageClass() { allFilesCount = e.allFilesCount };
            Update_Label(statusLabel1, data.allFilesCount.ToString());
        }

        private void Update_Label (Label labelToUpdate , string textToUpdate)
        {
            if (labelToUpdate != null)
            {
                if (labelToUpdate.InvokeRequired)
                {
                    Action safeWrite = delegate { labelToUpdate.Text = textToUpdate; };
                    labelToUpdate.Invoke(safeWrite);
                }

                labelToUpdate.Text = textToUpdate;
            }
        }
    }
}
