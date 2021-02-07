using DatabaseFiller1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseFiller1.DataAccessLayer.interfaces
{
    interface IDbDA
    {
        void AddSaleToDb(Sale sale);
        void AddSalesToDb(List<Sale> sale);
        List<Sale> GetSalesByManager(string manager);
        List<Sale> GetSalesByClient(string client);
        List<Sale> GetSalesByProduct(string product);
        void SetConnection();
        void CloseConnection();

    }
}
