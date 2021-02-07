using DatabaseFiller1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFiller1.BuisnessLayer.Intefaces
{
    interface IParser
    {
        List<Sale> GetSales(StreamReader reader);
    }
}
