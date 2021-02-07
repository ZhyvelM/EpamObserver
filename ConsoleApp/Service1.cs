using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DataBaseFiller1.BusinessLayer;

namespace ConsoleApp
{
    public partial class WindowsFileWatcher : ServiceBase
    {
        Observer observer;
        public WindowsFileWatcher()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            observer = new Observer();
        }

        protected override void OnStop()
        {
            observer.Dispose();
        }
    }
}
