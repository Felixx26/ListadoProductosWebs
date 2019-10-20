using ListadoProductosWebs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ListadoProductosWebs.Services
{
    public class ProductsRepository
    {
        public List<Product> GetProducts()
        {
            using (var db = new ProductsContext())
            {
                return db.Products.ToList();
            }
        }

        internal void Create(Product model)
        {
            using (var db = new ProductsContext())
            {
                db.Products.Add(model);
                db.SaveChanges();
            }

        }

        internal void getDetails()
        {
            throw new NotImplementedException();
        }

        internal object ExistProduct(int? id)
        {
            using (var db = new ProductsContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return new HttpNotFoundResult();
                }
                return product;
            }
        }

        internal void UpdateProduct(Product product)
        {
            using (var db = new ProductsContext())
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        internal void DeleteProduct(int id)
        {
            using (var db = new ProductsContext())
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}