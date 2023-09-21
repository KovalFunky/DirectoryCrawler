using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace FileCrawler
{
    public enum ErrorCode
    {
        FileError,
        NoDirectoryExits,
        AllOkey
    }
    public class ClassFileCrawler
    {
        public DirectoryInfo fcStartingDirectory { get; private set; }
        private ConcurrentBag<FileInfo> listFileInfoList = new ConcurrentBag<FileInfo>();
        private ConcurrentBag<DirectoryInfo> listBlankDirectories = new ConcurrentBag<DirectoryInfo>();
        private ConcurrentBag<DirectoryInfo> listDenyAccessDirectories = new ConcurrentBag<DirectoryInfo>();
        private readonly int multi;


        public event EventHandler<ClassOwnArgs> EventAddFileToListPassed;
        public event EventHandler<ClassOwnArgs> EventDirectoryValidated;



        public ClassFileCrawler(int v)
        {
            multi = v;
            EventAddFileToListPassed += ErrorMaintenance;
            EventDirectoryValidated += ErrorMaintenance;
        }

        private void ErrorMaintenance(object sender, ClassOwnArgs e)
        {
            switch (e.errorCode)
            {
                case ErrorCode.FileError:
                    break;
                case ErrorCode.NoDirectoryExits:
                    break;
                case ErrorCode.AllOkey:
                    break;
            }
        }
        private void FireEvent(EventHandler<ClassOwnArgs> MyEvent, ClassOwnArgs ownEventArgs)
        {
            MyEvent?.Invoke(this, ownEventArgs);
        }
        private void AddFileToList(List<FileInfo> retFileList) // dopisanie listy plików do głównej bazy
        {
            foreach (var item in retFileList)
            {
                try
                {
                    listFileInfoList.Add(item);
                    FireEvent(EventAddFileToListPassed, ownEventArgs: new ClassOwnArgs() { errorCode = ErrorCode.AllOkey, message = $@"{item.FullName}" });

                }
                catch (Exception errorM)
                {
                    FireEvent(EventAddFileToListPassed, ownEventArgs: new ClassOwnArgs() { errorCode = ErrorCode.FileError, message = $@"{errorM.Message}" });
                }
                
            }
        }
        private (List<FileInfo> retFileList, List<DirectoryInfo> retDirList) IfBlankDirectoryMarkIt(DirectoryInfo dir) // sprawdzenie czy katalog nie jest pusty
        {
            var retFileList = FirstPassGetFiles(dir);
            var retDirList = FirstPassGetDirectories(dir);
            if (retFileList.Count == 0 && retDirList.Count == 0)
            {
                AddBlankDirToList(dir);
            }
            return (retFileList, retDirList);
        }
        private void AddBlankDirToList(DirectoryInfo dir) // dopisanie pustego katalogu do głównej bazy pustych
        {
            listBlankDirectories.Add(dir);
        }
        private void AddDenyAccessDirToList(DirectoryInfo dir) // dopisanie katalogu bez dostępu do głównej bazy pustych
        {
            listDenyAccessDirectories.Add(dir);
        }
        private List<FileInfo> FirstPassGetFiles(DirectoryInfo dir) // sprawdzenie dostępności wskazanego katalogu , nie - dopisanie do bazy , tak - zwrot listy plików we wskazanym katalogu
        {
            var arr = new object();
            try
            {
                arr = Directory.GetFiles(dir.FullName);
            }
            catch (Exception)
            {
                AddDenyAccessDirToList(dir);
                return new List<FileInfo>();
            }
            
            var listStartingFiles = new List<FileInfo>();
            var _arr = arr as string[];
            foreach (var file in _arr)
            {
                listStartingFiles.Add(new FileInfo(file));
            }
            return listStartingFiles;
        }
        private List<DirectoryInfo> FirstPassGetDirectories(DirectoryInfo dir) // sprawdzenie dostępności wskazanego katalogu , nie - dopisanie do bazy , tak - zwrot listy pod katalogów we wskazanym katalogu
        {
            var arr = new object();
            try
            {
                arr = Directory.GetDirectories(dir.FullName);
            }
            catch (Exception)
            {
                
                return new List<DirectoryInfo>();
            }            
            var listStartingDirectories = new List<DirectoryInfo>();
            var _arr = arr as string[];
            foreach (var _dir in _arr)
            {
                listStartingDirectories.Add(new DirectoryInfo(_dir));
            }
            return listStartingDirectories;
        }
        private DirectoryInfo ValidateDirecotry(object startDirectory=null) // Sprawdzenie poprawności oraz obecności wskazanego katalogu
        {
            if (startDirectory!=null)
            {
                var di = new DirectoryInfo(startDirectory as string);
                var r = (int)di.Attributes;
                if (di.Exists)
                {
                    FireEvent(EventDirectoryValidated, ownEventArgs: new ClassOwnArgs() { errorCode = ErrorCode.AllOkey, message = $@"{di.FullName}" });
                    return di;
                }
                else
                {
                    FireEvent(EventDirectoryValidated, ownEventArgs: new ClassOwnArgs() { errorCode = ErrorCode.NoDirectoryExits, message = $@"{di.FullName}" });
                    return null;
                }                
            }
            else
            {
                var di = new DirectoryInfo(Environment.CurrentDirectory);
                FireEvent(EventDirectoryValidated, ownEventArgs: new ClassOwnArgs() { errorCode = ErrorCode.AllOkey, message = $@"{di.FullName}" });
                return di;
            }
        }
        internal (List<FileInfo>, List<DirectoryInfo>, List<DirectoryInfo>) Start(string _startDirectory=null)
        {
            
            fcStartingDirectory = ValidateDirecotry(_startDirectory);
            if (fcStartingDirectory!=null)
            {
                var retDirList = FirstPassGetDirectories(fcStartingDirectory);
                var retFilesList = FirstPassGetFiles(fcStartingDirectory);
                if (retFilesList.Count > 0)
                {
                    foreach (var item in retFilesList)
                    {
                        listFileInfoList.Add(item);
                    }
                }
                if (multi == 0)
                {
                    foreach (var item in retDirList)
                    {
                        Crawling(item);
                    }
                }
                else
                {
                    Parallel.ForEach(retDirList, dir =>
                    {
                        Crawling(dir);

                    });
                }
                return (listFileInfoList.ToList(), listDenyAccessDirectories.ToList(), listBlankDirectories.ToList());
            }
            return (null, null, null);
            
        }
        private void Crawling(DirectoryInfo dir)
        {
            var ret = IfBlankDirectoryMarkIt(dir); // sprawdzenie czy są pliki i katalogi w dir - jeżeli nie to dodajemy dir do pustych
            if (ret.retFileList.Count>0)
            {
                AddFileToList(ret.retFileList);
            }            
            var retDirList = ret.retDirList;
            foreach (var item in retDirList)
            {
                Crawling(item);
            }

        }


        }
    }

