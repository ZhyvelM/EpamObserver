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
        public List<Sale> GetSales(StreamReader reader)
        {
            List<Sale> sales = new List<Sale>();
            Logger.log.Info("parsing of file started");

            try
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
            catch (Exception e)
            {
                Logger.log.Error(e.Message);
            }

            Logger.log.Info("parsing of file ended");
            return sales;
        }

    }
}
