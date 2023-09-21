using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumerateAllFiles;

namespace ConsolaTestowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var eaf = new EnumerateAllFiles.EnumerateAllFilesClass();
            eaf.ReportStatus += Eaf_ReportStatus;
            eaf.EndOfProgress += Eaf_EndOfProgress;
            eaf.Initialize(new System.IO.DirectoryInfo(@"C:\"));
        }

        private static void Eaf_EndOfProgress(object sender, OwnArgsLibraryClass e)
        {
            Console.WriteLine("KONIEC");Console.ReadKey();
        }

        private static void Eaf_ReportStatus(object sender, OwnArgsLibraryClass e)
        {
            Console.WriteLine(e.allFilesCount);
        }
    }
}
