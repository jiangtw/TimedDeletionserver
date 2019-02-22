using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TimedDeletion
{
    class Program
    {
        static void Main(string[] args)
        {
            //TimingCycle timecycle = new TimingCycle();
            //timecycle.init();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                         new MQTTDataSync() //此处是我们的windows服务类名称
            };
            ServiceBase.Run(ServicesToRun);




        }
    }
}
