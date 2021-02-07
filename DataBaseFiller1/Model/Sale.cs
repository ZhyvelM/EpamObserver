using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseFiller1.Model
{
    class Sale
    {
        public int Id { get; set; }
        public string SaleManager { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }

        public Sale() { }
        public Sale(string manager, DateTime date, string clientName, string product, double price)
        {
            SaleManager = manager;
            Date = date;
            ClientName = clientName;
            Product = product;
            Price = price;
        }

        public override string ToString()
        {
            return $"manger {SaleManager} sold {Product} to {ClientName} for {Price}";
        }

        public override bool Equals(object obj)
        {
            var o1 = (Sale)obj;
            return (SaleManager.Equals(o1.SaleManager) &&
                Date.Equals(o1.Date) &&
                ClientName.Equals(o1.ClientName) &&
                Product.Equals(o1.Product) &&
                Price == o1.Price);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
