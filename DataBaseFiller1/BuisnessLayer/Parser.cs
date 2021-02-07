using CsvHelper;
using CsvHelper.Configuration;
using DatabaseFiller1.Model;
using DataBaseFiller1.BuisnessLayer.Intefaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFiller1.BuisnessLayer
{
    class Parser : Intefaces.IParser
    {
        public List<Sale> GetSales(string filePath)
        {
            List<Sale> sales = new List<Sale>();
            if (!File.Exists(filePath)) return null;

            Logger.log.Info("parsing of file started");

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var cult = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    cult.TextInfo.ListSeparator = ",";
                    using (var csv = new CsvReader(reader, cult))
                    {                        
                        Logger.log.Info("Delimeter:" + csv.Configuration.Delimiter);
                        csv.Context.RegisterClassMap<SaleMap>();
                        sales = csv.GetRecords<Sale>().ToList();
                    }
                }
            }catch(Exception e)
            {
                Logger.log.Error(e.Message);
            }

            string fileName = Path.GetFileName(filePath);
            string[] str = fileName.Split('_');
            string manager = str[0];
            sales.ForEach(o =>
            {
                o.SaleManager = manager;
            });

            Logger.log.Info("parsing of file ended");
            return sales;
        }

        public sealed class SaleMap : ClassMap<Sale>
        {
            public SaleMap()
            {
                Map(m => m.Id).Ignore();
                Map(m => m.Date).Name("Date").TypeConverterOption.Format("yyyyMMdd");
                Map(m => m.ClientName).Name("ClientName");
                Map(m => m.Product).Name("Product");
                Map(m => m.Price).Name("Price");
            }
        }

    }
}
