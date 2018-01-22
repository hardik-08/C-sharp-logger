using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MainApp;

namespace Logger
{
    public partial class Service1 : ServiceBase
    {
        private EventLog eventLog_1;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eventLog_1 = new EventLog();
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eventLog_1.Source = "MySource";
            eventLog_1.Log = "MyNewLog";
            eventLog_1.WriteEntry("In OnStart");
            SetUpWatchers();
            


        }

        private void SetUpWatchers()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\logger\filelist.txt");
            while (( line = file.ReadLine()) != null)
            {
                DirectoryLogger directoryInfo = new DirectoryLogger(line, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\logger\filelog.txt");
                
            }
            file.Close();

        }

        protected override void OnStop()
        {
            eventLog_1.WriteEntry("In OnStop");

        }
    }
}
