using DataBaseFiller1.BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFiller1.Clients
{
    partial class WindowsFileWatcher : ServiceBase
    {
        Observer observer;
        public WindowsFileWatcher()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.log.Info("Service started");
            observer = new Observer();
        }

        protected override void OnStop()
        {
            Logger.log.Info("Service stopped");
            observer.Dispose();
        }
    }
}
