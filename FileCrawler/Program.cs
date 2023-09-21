using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrawler
{
    //public class OwnEventArgs : EventArgs
    //{
    //    internal bool toFile;
    //    internal int filesCount;
    //    internal int directoriesCount;

    //    public string message { get; internal set; }
    //}
    //public class Storage
    //{
    //    internal List<FileInfo> Files { get; set; } = new List<FileInfo>();

    //    //internal List<string> Files { get; set; } = new List<string>();
    //    internal List<string> Directories { get; set; } = new List<string>();
    //}
    //public sealed class Logger
    //{
    //    private readonly StringCollection log;        

    //    private Logger() 
    //    { 
    //        log = new StringCollection(); log.Clear();
    //        using (var file = new StreamWriter("WriteLines2.txt"))
    //        {
    //            file.WriteLine("START_LOG\n\r\n\r");
    //        }
            
    //    }
    //    private static Logger Instance;
    //    public static Logger GetInstance()
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = new Logger();
    //        }
    //        return Instance;
    //    }
    //    internal void Add(object sender, EventArgs e)
    //    {
    //        using (var file = new StreamWriter("WriteLines2.txt", append: true))
    //        {
    //            var oa = e as OwnEventArgs;
    //            file.WriteLine($@"{DateTime.Now.ToLocalTime()} -> {oa.message}");
    //        }
    //    }
    //}
    //public class FileCrawler
    //{
    //    public event EventHandler<EventArgs> FilePassed;
    //    public event EventHandler<EventArgs> RaportFilesCount;
    //    public event EventHandler<EventArgs> RaportDirectoriesCount;
    //    public string StartingPath { get; internal set; } = Environment.CurrentDirectory;
    //    OwnEventArgs ownArg = new OwnEventArgs() { message = $@"Directory: {Environment.CurrentDirectory} - Starting crawling" };
    //    private Storage storage;

    //    public FileCrawler()
    //    {
    //        storage = new Storage();
    //    }
    //    internal object Start()
    //    {
    //        #region Initialize Starting Path
    //        if (StartingPath != Environment.CurrentDirectory)
    //        {
    //            if (string.IsNullOrEmpty(StartingPath))
    //            {
    //                StartingPath = Environment.CurrentDirectory;
    //            }
    //            else if (!Directory.Exists(StartingPath))
    //            {
    //                StartingPath = Environment.CurrentDirectory;
    //            }
    //        }
    //        FireEvent(FilePassed, new OwnEventArgs() { message = $@"Directory: {StartingPath} - Starting crawling", toFile = true });
    //        #endregion 
    //        #region First Pass - - Starting entry in Storage
    //        var retFiles = GetFilesFromDirectory(new DirectoryInfo(StartingPath));
    //        AddFilesToStorage(retFiles);
    //        var retDirectories = GetFoldersFromPath(new DirectoryInfo(StartingPath));
    //        //var retFileList = CheckAccessToFiles(retFiles);            


    //        //var retDirList = CheckAccessToDirectories(retDirectories);

    //        #endregion
    //        //foreach (var item in retDirList)
    //        //{
    //        //    var newList=new List<string>();newList.Add(item);
    //        //    var mainTask = Task.Run(() => SecondPass(newList)); Console.WriteLine(mainTask.ToString());
    //        //}
    //        //Task.WaitAll();

    //        //SecondPass(retDirectories.ToList());
    //        Console.WriteLine("END");
    //        FireEvent(FilePassed, new OwnEventArgs() { message = $@"Directories: {storage.Directories.Count} - Adding to base", toFile = false });
    //        FireEvent(FilePassed, new OwnEventArgs() { message = $@"Files: {storage.Files.Count} - Adding to base", toFile = true });

    //        return null;
    //    }

       

    //    private void SecondPass(List<string> directories)
    //    {
    //        foreach (var dir in directories)
    //        {
    //            try
    //            {
    //                storage.Directories.Add(dir);
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"Directory: {dir} - Adding to base", toFile = false });
    //                FireEvent(RaportDirectoriesCount, new OwnEventArgs() { directoriesCount = storage.Directories.Count });
    //                var _retFiles = GetFilesFromDirectory(new DirectoryInfo(dir));
    //                if (_retFiles.Length>0)
    //                {
    //                    //var _retFilesList = CheckAccessToFiles(_retFiles);
    //                    //AddFilesToStorage(_retFilesList);

    //                }
    //                var _retDirectories = GetFoldersFromPath(new DirectoryInfo(dir));
    //                SecondPass(_retDirectories.ToList()); 

    //            }
    //            catch (Exception)
    //            {
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"Directory: {dir} - Access error", toFile = true });
    //                continue;
                    
    //            }
    //        }
    //    }

    //    private FileInfo[] GetFilesFromDirectory(DirectoryInfo dirInfo)
    //    {
    //        var files = Directory.EnumerateFiles(dirInfo.FullName, "*", SearchOption.TopDirectoryOnly).ToArray();
    //        var listFileInfo = new List<FileInfo>();
    //        foreach (var item in files)     
    //        {
    //            try
    //            {
    //                var f = new FileInfo(item);
    //                listFileInfo.Add(f);
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"{f.FullName} - Adding to base", toFile = true });
    //            }
    //            catch (Exception)
    //            {
    //                throw;
    //            }
                
    //        }
    //        return listFileInfo.ToArray<FileInfo>();
    //    }
    //    private List<string> CheckAccessToFiles(string[] fileTable)
    //    {
    //        var retList = new List<string>();
    //        foreach (var file in fileTable)
    //        {
    //            try
    //            {
    //                retList.Add(file);
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"File: {file} - Adding to base", toFile = false });

    //            }
    //            catch (Exception)
    //            {
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"File: {file} - Access error", toFile = true });
    //                continue;
    //            }
    //        }
    //        return retList;
    //    }
    //    private string[] GetFoldersFromPath(DirectoryInfo startingPath)
    //    {
    //        return Directory.EnumerateDirectories(startingPath.FullName, "*", SearchOption.TopDirectoryOnly).ToArray();
    //    }
    //    private List<string> CheckAccessToDirectories(string[] retDirectories)
    //    {
    //        var retList = new List<string>();
    //        foreach (var dir in retDirectories)
    //        {
    //            try
    //            {
    //                retList.Add(dir);
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"Directory: {dir} - Adding to base", toFile = false });

    //            }
    //            catch (Exception)
    //            {
    //                FireEvent(FilePassed, new OwnEventArgs() { message = $@"Directory: {dir} - Access error", toFile = true });
    //                continue;
    //            }
    //        }
    //        return retList;
    //    }
    //    private void FireEvent(EventHandler<EventArgs> MyEvent, OwnEventArgs ownEventArgs)
    //    {
    //        MyEvent?.Invoke(this, ownEventArgs);
    //    }
    //    private void AddFilesToStorage(List<string> retFileList)
    //    {
    //        //storage.Files.AddRange(retFileList);
    //        //FireEvent(RaportFilesCount, new OwnEventArgs() { filesCount = storage.Files.Count });
    //    }
    //    private void AddFilesToStorage(FileInfo[] retFiles)
    //    {
    //        storage.Files.AddRange(retFiles.ToList());            
    //    }

    //}
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var fileCrawler = new ClassFileCrawler(1);
            var ret = fileCrawler.Start(@"D:\MUZA");
            //var ret = fileCrawler.Start($@"C:\Us564ers\");
            //fileCrawler.Start($@"D:\Jdownloader2\!!!POBRANE");
            //Logger Log = Logger.GetInstance();
            //var fileCrawler = new FileCrawler();
            ////fileCrawler.StartingPath = @"C:\!ONEDRIVES\";
            //fileCrawler.StartingPath = @"D:\Jdownloader2\!!!POBRANE";
            //fileCrawler.FilePassed += Log.Add;

            //fileCrawler.Start();


            //var qq = new FileCrawler();
            //var qqq = new FileCrawler("");
            //var qqqq = new FileCrawler(@"C:\");

            //    // Start with drives if you have to search the entire computer.
            //    string[] drives = System.Environment.GetLogicalDrives();

            //    foreach (string dr in drives)
            //    {
            //        System.IO.DriveInfo di = new System.IO.DriveInfo(dr);

            //        // Here we skip the drive if it is not ready to be read. This
            //        // is not necessarily the appropriate action in all scenarios.
            //        if (!di.IsReady)
            //        {
            //            Console.WriteLine("The drive {0} could not be read", di.Name);
            //            continue;
            //        }
            //        System.IO.DirectoryInfo rootDir = di.RootDirectory;
            //        WalkDirectoryTree(rootDir);
            //    }

            //    // Write out all the files that could not be processed.
            //    Console.WriteLine("Files with restricted access:");
            //    foreach (string s in log)
            //    {
            //        Console.WriteLine(s);
            //    }
            //    // Keep the console window open in debug mode.
            //    Console.WriteLine("Press any key");
            //    Console.ReadKey();
            //}

            //private static void WalkDirectoryTree(DirectoryInfo rootDir)
            //{
            //    System.IO.FileInfo[] files = null;
            //    System.IO.DirectoryInfo[] subDirs = null;

            //    // First, process all the files directly under this folder
            //    try
            //    {
            //        files = Root.GetFiles("*.*");
            //    }
            //    // This is thrown if even one of the files requires permissions greater
            //    // than the application provides.
            //    catch (UnauthorizedAccessException e)
            //    {
            //        // This code just writes out the message and continues to recurse.
            //        // You may decide to do something different here. For example, you
            //        // can try to elevate your privileges and access the file again.
            //        log.Add(e.Message);
            //    }

            //    catch (System.IO.DirectoryNotFoundException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }

            //    if (files != null)
            //    {
            //        foreach (System.IO.FileInfo fi in files)
            //        {
            //            // In this example, we only access the existing FileInfo object. If we
            //            // want to open, delete or modify the file, then
            //            // a try-catch block is required here to handle the case
            //            // where the file has been deleted since the call to TraverseTree().
            //            Console.WriteLine(fi.FullName);
            //        }

            //        // Now find all the subdirectories under this directory.
            //        subDirs = root.GetDirectories();

            //        foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            //        {
            //            // Resursive call for each subdirectory.
            //            WalkDirectoryTree(dirInfo);
            //        }
            //    }
        }
    }

}
//using System;
//using System.ServiceProcess;

//namespace CheckSpoolerService
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ServiceController sc = new ServiceController("Spooler");
//            Console.WriteLine("Status usługi Spooler: " + sc.Status);
//            Console.ReadLine();
//        }
//    }
//}

//using System;
//using System.Net;
//using System.Net.Mail;

//namespace SendEmailWithAttachment
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Dane do logowania do serwera SMTP
//            string smtpServer = "smtp.office365.com";
//            int smtpPort = 587;
//            string email = "twojemail@adres.com"; // zmień na swój adres e-mail
//            string password = "twojehaslo"; // zmień na swoje hasło

//            // Tworzenie obiektu klienta SMTP
//            SmtpClient client = new SmtpClient(smtpServer, smtpPort)
//            {
//                Credentials = new NetworkCredential(email, password),
//                EnableSsl = true
//            };

//            // Tworzenie wiadomości e-mail
//            MailMessage message = new MailMessage()
//            {
//                From = new MailAddress(email),
//                Subject = "Przykładowa wiadomość e-mail z załącznikiem",
//                Body = "Witaj, \n\nPrzesyłam Ci przykładowy plik załącznikowy.\n\nPozdrawiam, \nTwoje Imię",
//            };

//            // Dodanie załącznika
//            string attachmentPath = @"C:\sciezka\do\pliku\załącznikowego.pdf"; // zmień na ścieżkę do swojego pliku
//            message.Attachments.Add(new Attachment(attachmentPath));

//            // Adresy e-mail odbiorców
//            message.To.Add("adres@odbiorcy.com");

//            // Wysyłanie wiadomości e-mail
//            try
//            {
//                client.Send(message);
//                Console.WriteLine("Wiadomość e-mail została wysłana.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Wystąpił błąd podczas wysyłania wiadomości e-mail: " + ex.Message);
//            }
//        }
//    }
//}

