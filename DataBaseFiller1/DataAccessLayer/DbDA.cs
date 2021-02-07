using DatabaseFiller1.DataAccessLayer.interfaces;
using DatabaseFiller1.Model;
using DataBaseFiller1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DatabaseFiller1.DataAccessLayer
{
    class DbDA : IDbDA
    {
        private static bool isUsing;
        private static SaleContext db;


        public DbDA()
        {
            isUsing = false; 
        }

        ~DbDA()
        {
            CloseConnection();
        }

        public void SetConnection()
        {
            db = new SaleContext();
            Logger.log.Info("Data base Connected");
            Logger.log.Info(db.Database.Connection.Database);
        }

        public void CloseConnection()
        {
            if (db != null)
            {
                db.Dispose();
            }
            Logger.log.Info("Data base Disconnected");
        }
        public void AddSaleToDb(Sale sale)
        {
            while (isUsing)
            {
                Thread.CurrentThread.Join(100);
                Logger.log.Info("thread waiting...");
            }
            isUsing = true;
            if (db == null)
            {
                Logger.log.Error("No connection to data base; use SetConnection() method");
            }
            else
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                Logger.log.Info("sale written to data base: " + sale);
            }
            isUsing = false;
        }

        public List<Sale> GetSalesByClient(string client)
        {
            while (isUsing)
            {
                Thread.CurrentThread.Join(100);
            }
            List<Sale> sales = new List<Sale>();
            isUsing = true;
            if (db == null)
            {
                Logger.log.Error("No connection to data base; use SetConnection() method");
            }
            else
            {
                sales = db.Sales.Where(x => x.ClientName == client).ToList();
            }
            isUsing = false;
            if (sales.Count == 0)
            {
                Logger.log.Info("No sales with that client");
                sales = null;
            }
            return sales ?? null;
        }

        public List<Sale> GetSalesByManager(string manager)
        {
            while (isUsing)
            {
                Thread.CurrentThread.Join(100);
            }
            List<Sale> sales = new List<Sale>();
            isUsing = true;
            if (db == null)
            {
                Logger.log.Error("No connection to data base; use SetConnection() method");
            }
            else
            {
                sales = db.Sales.Where(x => x.SaleManager == manager).ToList();
            }
            isUsing = false;
            if (sales.Count == 0)
            {
                Logger.log.Info("No sales with that manager");
                sales = null;
            }
            return sales ?? null;
        }

        public List<Sale> GetSalesByProduct(string product)
        {
            while (isUsing)
            {
                Thread.CurrentThread.Join(100);
            }
            List<Sale> sales = new List<Sale>();
            isUsing = true;
            if (db == null)
            {
                Logger.log.Error("No connection to data base; use SetConnection() method");
            }
            else
            {
                sales = db.Sales.Where(x => x.Product.Equals(product)).ToList();
            }
            isUsing = false;
            if (sales.Count == 0)
            {
                Logger.log.Info("No sales with that product");
            }
            return sales;
        }

        public void AddSalesToDb(List<Sale> sale)
        {
            db.Sales.AddRange(sale);
        }
    }
}
