using DatabaseFiller1.Model;
using DataBaseFiller1;
using DataBaseFiller1.BuisnessLayer;
using DataBaseFiller1.BuisnessLayer.Intefaces;
using DataBaseFiller1.Clients;
using System;
using System.ServiceProcess;

namespace DatabaseFiller1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                Logger.log.Info("UserNotInteractive mod");
                using (var service = new WindowsFileWatcher())
                {
                    ServiceBase.Run(service);
                }
            }
            else
            {
                Logger.log.Info("Console app started");
                using (Observer obs = new Observer())
                {
                    Console.WriteLine("Press 'q' to quit the sample.");
                    while (Console.Read() != 'q') ;
                }
            }
        }

    }
}
