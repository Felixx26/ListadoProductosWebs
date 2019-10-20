using ListadoProductosWebs.Models;
using ListadoProductosWebs.Services;
using System;
using System.Web.Mvc;

namespace ListadoProductosWebs.Controllers
{
    public class ProductController : Controller
    {
        private ProductsRepository _repo;

        public ProductController()
        {
            _repo = new ProductsRepository();
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = _repo.GetProducts();
            
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            var model = _repo.ExistProduct(id);
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Create(model);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {

            }
            return View(model);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _repo.ExistProduct(id);
            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Name,Brand,Category,Price,Quantity,Date")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            var model = _repo.ExistProduct(id);
            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _repo.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
