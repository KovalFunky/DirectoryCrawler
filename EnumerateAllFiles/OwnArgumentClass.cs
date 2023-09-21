using System;

namespace EnumerateAllFiles
{
    public class OwnArgsLibraryClass : EventArgs
    {
        public int allFilesCount {  get;internal set; }
        public int blockDirectoryCount { get;internal set; }
        public int allDirectoryCount {  get;internal set; }
    }
}
