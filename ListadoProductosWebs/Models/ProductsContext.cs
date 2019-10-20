using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListadoProductosWebs.Models
{
    public class ProductsContext: DbContext
    {

        public ProductsContext()
            :base("DefaultConnection")
        {

        }


        public DbSet<Product> Products { get; set; }

    }
}