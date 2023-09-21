using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrawler
{
    public class ClassOwnArgs
    {
        internal string message;
        internal ErrorCode errorCode;

        public class OwnEventArgs : EventArgs
        {
            
        }
    }
}
