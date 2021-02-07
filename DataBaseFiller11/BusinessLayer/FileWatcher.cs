using DataBaseFiller1.BusinessLayer.Intefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFiller1.BusinessLayer
{
    class FileWatcher : IFileWatcher
    {
        private FileSystemWatcher FW { get; set; }

        public event EventHandler<FileSystemEventArgs> Created;

        public FileWatcher()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["pathToFolder"];
            FW = new FileSystemWatcher(path);
            FWInit();
        }
        ~FileWatcher()
        {
            FW.Dispose();            
        }

        private void FWInit()
        {
            FW.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
            FW.Filter = "*.csv";
            FW.Created += OnCreated;
            FW.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Created?.Invoke(sender, e);
        }
    }
}
