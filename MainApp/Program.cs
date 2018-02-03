using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace MainApp
{
    class Program
    {
        private const string SERVICE_NAME = "loggerService";
        

        static void Main(string[] args)
        {
                 using (ServiceController sc = new ServiceController(SERVICE_NAME))
                 {
                 if(sc.Status == ServiceControllerStatus.Running)
                 {
                    Console.WriteLine("Service is active.");
                 }
                 else
                    Console.WriteLine("Service is inactive.");
                 }
            Console.WriteLine("Currently listening to :");
            string line;
            int count=0;
            string FileList = FileLocation.FileList;


            string[] lines = File.ReadAllLines(FileList);

            for(int i=0;i<lines.Length;i++)
            {
                Console.WriteLine("{0}. {1} ",(i+1) ,lines[i]);
            }


            while (true)
            {
                Console.WriteLine("1. Add watcher to dir  \n 2. Remove Watcher from dir \n  3. View Log \n  4. Exit");
                switch(Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Enter directory to be logged");
                        string newDir = Console.ReadLine();
                        if (Directory.Exists(newDir))
                        {

                            using (StreamWriter sw = File.AppendText(FileLocation.FileList))
                            {
                                sw.WriteLine(newDir);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Select file number to delete");
                        int index = Int32.Parse(Console.ReadLine());
                        File.WriteAllLines(FileList,File.ReadLines(FileList).Where(l => l != lines[index-1]).ToList());
                        break;
                    case 3:
                        Console.WriteLine("Select file number to view");
                         index = Int32.Parse(Console.ReadLine());
                         string hash = SHA1Hash.GetHash(FileLocation.FileLog + lines[index-1]);
                           using (System.IO.StreamReader file = new System.IO.StreamReader(FileLocation.FileLog + hash))
                            {
                                while ((line = file.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);

                                }
                            }
                       
                        break;
                    case 4: 
                    default: break;
                }


                using (System.IO.StreamReader file = new System.IO.StreamReader(FileList))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine("{0}. {1}", ++count, line);

                    }
                }
                break;


            }
            try
            {
                using (ServiceController service = new ServiceController(SERVICE_NAME))
                {
                   
                    service.Stop();

                    service.WaitForStatus(desiredStatus: ServiceControllerStatus.Stopped);

               
                    
                    service.Start();
                    service.WaitForStatus(desiredStatus: ServiceControllerStatus.Running);
                    Console.WriteLine("Service Restarted");
                }
            }

            finally { Console.ReadLine();}
        }

        
    }
}
