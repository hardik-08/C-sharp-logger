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
                Console.WriteLine("You have chosen : "+directoryInfo.Path);
            }
            else
                Console.WriteLine("Invalid Path, exiting");
            Console.ReadLine();
        }
    }
}
