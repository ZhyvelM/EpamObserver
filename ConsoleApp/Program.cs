using DataBaseFiller1.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            if (!Environment.UserInteractive)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new WindowsFileWatcher()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                using (Observer obs = new Observer())
                {
                    Console.WriteLine("Press 'q' to quit the sample.");
                    while (Console.Read() != 'q') ;
                }
            }
        }
    }
}
