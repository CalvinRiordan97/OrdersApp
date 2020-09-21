using OrdersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdersApp.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        public ActionResult Products()
        {
            var product = _context.Products.ToList();
            return View(product);
        }

        //[Route("customer/addcustomer")]
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult EditProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();

            Product productToEdit = product;

            return View("AddProduct", productToEdit);
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Products", "Product");
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product.Id == 0)
            {
                product.CreationDate = DateTime.Now.ToString();
                product.ExpiredDate = DateTime.Now.AddDays(100).ToString();
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.SingleOrDefault(c => c.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Price = product.Price;
                productInDb.Description = product.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("Products", "Product");
        }

    }
}