using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumerateAllFiles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public class DataClass
    {
        internal int a1;
    }
    public partial class Form1 : Form
    {
        private EnumerateAllFilesClass ea;
        private BackgroundWorker bgWorker;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ea = new EnumerateAllFiles.EnumerateAllFilesClass(true);
            ea.ReportStatus += Ea_ReportStatus;
            ea.EndOfProgress += Ea_EndOfProgress;
        }

        private void Ea_EndOfProgress(object sender, OwnArgsLibraryClass e)
        {
            Update("KONIEC");
        }

        private void Update(string v)
        {
            if (label2.InvokeRequired)
            {
                Action safeWrite = delegate { label2.Text = v; };
                label2.Invoke(safeWrite);
            }
            else
            {
                label2.Text = v;
            }
        }

        private void Ea_ReportStatus(object sender, OwnArgsLibraryClass e)
        {
            var data = new DataClass(){ a1 =e.allFilesCount };
            Update(data);            
        }

        private void Update(DataClass data)
        {
            if (label1.InvokeRequired)
            {
                Action safeWrite = delegate { label1.Text = $"{data.a1}"; };
                label1.Invoke(safeWrite);
            }
            else
            {
               label1.Text = $"{data.a1}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ea.Initialize(new System.IO.DirectoryInfo (@"C:\!ONEDRIVES"));
        }
    }
}
