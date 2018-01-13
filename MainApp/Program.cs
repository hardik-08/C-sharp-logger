using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter directoy you want to listen to, (absolute path)");
            String directory = Console.ReadLine();

            if (Directory.Exists(directory))
            {
                Console.WriteLine("It is a directory!");
                DirectoryInformation directoryInfo = new DirectoryInformation(directory);
                Console.WriteLine("You have chosen : "+directoryInfo.Path+" We are now listening to it!");

                FileSystemWatcher fsw = new FileSystemWatcher();
                fsw.Path = directory;
                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                fsw.Changed += new FileSystemEventHandler(printChange);
                fsw.Renamed += new RenamedEventHandler(printChange);
                fsw.Created += new FileSystemEventHandler(printChange);
                fsw.Deleted += new FileSystemEventHandler(printChange);
                fsw.IncludeSubdirectories = true;
                fsw.EnableRaisingEvents = true;



            }
            else
                Console.WriteLine("Invalid Path, exiting");
            while (true) ; 
            Console.ReadLine();
        }

        static void printChange(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("CHANGED, NAME: " + e.Name);
            Console.WriteLine("CHANGED, FULLPATH: " + e.FullPath);
            Console.WriteLine("WHAT HAPPENED? :"+e.ChangeType);
        }
    }
}
