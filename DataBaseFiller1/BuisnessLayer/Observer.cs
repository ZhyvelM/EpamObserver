using DatabaseFiller1.DataAccessLayer;
using DatabaseFiller1.DataAccessLayer.interfaces;
using DataBaseFiller1.BuisnessLayer.Intefaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBaseFiller1.BuisnessLayer
{
    class Observer
    {
        FileWatcher FW;
        Parser parser;
        IDbDA db;

        public Observer()
        {
            Logger.log.Info("Observer initializing");
            parser = new Parser();
            db = new DbDA();
            db.SetConnection();
            FW = new FileWatcher();
            FW.Created += FileAdded;
        }

        ~Observer()
        {
            db.CloseConnection();
        }

        private void FileAdded(object sender, FileSystemEventArgs e)
        {
            Logger.log.Info("Event triggered");
            Thread thread = new Thread(() => FileHandler(e));
            thread.Start();
        }

        private void FileHandler(FileSystemEventArgs e)
        {
            try
            {
                db.AddSalesToDb(parser.GetSales(e.FullPath));
            } catch (Exception ex)
            {
                Logger.log.Error(ex.Message);
            }
        }
    }
}
