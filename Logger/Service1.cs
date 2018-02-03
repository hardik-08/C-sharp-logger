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

namespace MainApp
{
    public partial class Service1 : ServiceBase
    {
        private EventLog eventLog_1;
        public string FileList = FileLocation.FileList;
        public string FileLog = FileLocation.FileLog;
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
            System.IO.StreamReader file = new System.IO.StreamReader(FileList);
            if (!System.IO.Directory.Exists(FileLog))
                System.IO.Directory.CreateDirectory(FileLog);



            while ((line = file.ReadLine()) != null)
            {
                string hash = SHA1Hash.GetHash(FileLog + line);

                DirectoryLogger directoryInfo = new DirectoryLogger(line, FileLog + hash);

            }
            file.Close();

        }

        protected override void OnStop()
        {
            eventLog_1.WriteEntry("In OnStop");

        }
    }
}
