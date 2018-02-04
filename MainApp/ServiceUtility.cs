using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class ServiceUtility
    {
        public static bool IsServiceRunning(string servicename)
        {
            using (ServiceController sc = new ServiceController(servicename))
            {
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool RestartService(string servicename)
        {
            try
            {
                using (ServiceController service = new ServiceController(servicename))
                {
                    if (service.Status.Equals(ServiceControllerStatus.Running))
                    {
                        service.Stop();
                        service.WaitForStatus(desiredStatus: ServiceControllerStatus.Stopped);
                    }
                    service.Start();
                    service.WaitForStatus(desiredStatus: ServiceControllerStatus.Running);

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }


    }
}
