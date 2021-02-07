using CsvHelper.Configuration;
using DatabaseFiller1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFiller1.BuisnessLayer
{
    class SaleMap : ClassMap<Sale>
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
