using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public static class FileLocation
    {
        public static  string FileList
        {
            get;private set;
        }
        public static string FileLog
        {
            get; private set;
        }

        static FileLocation()
        {
            FileList = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\logger\filelist.txt";
            FileLog = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\logger\filelog.txt";
        }

    }
}
