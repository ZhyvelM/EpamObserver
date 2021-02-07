using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DatabaseFiller1.Model
{
    class SaleContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public SaleContext() : base("DbConnection")
        { }
    }
}
