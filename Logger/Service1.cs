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
            DirectoryLogger directoryInfo = new DirectoryLogger(@"F:\capturered", @"F:\hello.txt");


        }

        protected override void OnStop()
        {
            eventLog_1.WriteEntry("In OnStop");

        }
    }
}
