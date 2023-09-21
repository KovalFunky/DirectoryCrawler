using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerateAllFiles
{
    public class EnumerateAllFilesClass
    {
        
        private ConcurrentBag<FileInfo> allFileList = new ConcurrentBag<FileInfo>();
        private ConcurrentBag<DirectoryInfo> allDirectories = new ConcurrentBag<DirectoryInfo>();
        private ConcurrentBag<DirectoryInfo> blockDirectories = new ConcurrentBag<DirectoryInfo>();
        private readonly bool _multi;

        private EventManagerLibraryClass EventManager=new EventManagerLibraryClass();
        public event EventHandler<OwnArgsLibraryClass> ReportStatus;
        public event EventHandler<OwnArgsLibraryClass> EndOfProgress;

        public EnumerateAllFilesClass(bool multi=true)  //  konstruktor - multithreading ON - OFF
        {
            _multi = multi;
        } 
        public void Initialize(DirectoryInfo directory)   //  procedura startowa dla całego procesu enumeracji
        {            
            var data = FirstPass(directory);
            AddFilesToList(data.GrabFiles);
            CrawlingDirectories(data.GrabDirectories);
            EventManager.FireEvent(EndOfProgress);
        }

        private void CrawlingDirectories(IEnumerable<DirectoryInfo> grabDirectories)    //  główna procedura rekurencyjna - główna pętla
        {
            if (_multi)
            {
                Parallel.ForEach(grabDirectories, directory =>
                {
                    var data = FirstPass(directory);
                    AddFilesToList(data.GrabFiles);
                    CrawlingDirectories(data.GrabDirectories);

                });
            }
            else
            {
                foreach (var directory in grabDirectories)
                {
                    var data = FirstPass(directory);
                    AddFilesToList(data.GrabFiles);
                    CrawlingDirectories(data.GrabDirectories);
                }
            }


        }
        private (IEnumerable<FileInfo> GrabFiles, IEnumerable<DirectoryInfo> GrabDirectories) FirstPass(DirectoryInfo actualDirectory)  //  pobranie podkatalogów ze wskazanego katalogu
        {
            var ret = GrabFilesFromDirectory(actualDirectory);
            var ret1 = GrabSubDirectories(actualDirectory);
            return (GrabFiles: ret, GrabDirectories: ret1);
        }
        private void AddFilesToList(IEnumerable<FileInfo> grabFiles)    //  dodanie plików do listy końcowych wyników programu
        {
            foreach (FileInfo file in grabFiles)
            {
                allFileList.Add(file);
            }
            EventManager.FireEvent(ReportStatus, new OwnArgsLibraryClass()
            { allFilesCount = allFileList.Count, allDirectoryCount = allDirectories.Count, blockDirectoryCount = blockDirectories.Count });
            
            
        }      

        private IEnumerable<FileInfo> GrabFilesFromDirectory(DirectoryInfo actualDirectory) //  pobranie listy plików ze wskazanego katalogu
        {
            IEnumerable<string> col = null;
            try
            {
                col = Directory.EnumerateFiles(actualDirectory.FullName);
            }
            catch (Exception err)  // nie można pobrać plików z wskazanego katalogu 
            {
                return new List<FileInfo>();
            }            
            var newList = new List<FileInfo>();            
            foreach (var item in col)
            {
                try
                {
                    newList.Add(new FileInfo(item));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return newList;
        }
        private IEnumerable<DirectoryInfo> GrabSubDirectories (DirectoryInfo actualDirectory)   // pobranie listy podkatalogów ze wskazanej lokalizacji
        {           

            IEnumerable<string> col = null;
            try
            {                
                col = Directory.EnumerateDirectories(actualDirectory.FullName);
                allDirectories.Add(actualDirectory);
            }
            catch (Exception err)  // nie można pobrać plików z wskazanego katalogu 
            {                
                blockDirectories.Add(actualDirectory);  //  dodanie zablokowanego katalogu do listy blokowanych
                return new List<DirectoryInfo>();
            }
            var newList = new List<DirectoryInfo>();
            foreach (var item in col)
            {
                try
                {
                    newList.Add(new DirectoryInfo(item));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return newList;
        }
    }
}
