using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class DirectoryLogger
    {

        private string path;
        private FileSystemWatcher fsw;
        public string LogPath { get; set; }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        public DirectoryLogger(string path,string logPath)
        {
            this.Path = path;
            this.LogPath = logPath;
            setWatcher();
        }

        private void setWatcher()
        {
            fsw = new FileSystemWatcher();
            fsw.Path = path;
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Changed += new FileSystemEventHandler(printChange);
            fsw.Renamed += new RenamedEventHandler(printChange);
            fsw.Created += new FileSystemEventHandler(printChange);
            fsw.Deleted += new FileSystemEventHandler(printChange);
            fsw.IncludeSubdirectories = true;
            fsw.EnableRaisingEvents = true;
        }

        void printChange(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("CHANGED, NAME: " + e.Name);
            //Console.WriteLine("CHANGED, FULLPATH: " + e.FullPath);
            //Console.WriteLine("WHAT HAPPENED? :" + e.ChangeType);
            

            using (StreamWriter sw = File.AppendText(LogPath))
            {
                sw.Write("Logged at {0} : ", DateTime.Now.ToString("h:mm:ss tt"));
                sw.Write(" CHANGED, NAME: " + e.Name);
                sw.Write(" CHANGED, FULLPATH: " + e.FullPath);
                sw.WriteLine(" WHAT HAPPENED? :" + e.ChangeType);
            }

        }
    }
}
