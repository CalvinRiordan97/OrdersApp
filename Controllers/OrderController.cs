using OrdersApp.Models;
using OrdersApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdersApp.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Order
        public ActionResult Orders()
        {
            var order = _context.Orders.Include(c => c.Customer).Include(p => p.Product).ToList();
            return View(order);
        }

        //[Route("customer/addcustomer")]
        public ActionResult AddOrder()
        {
            var customersTable = _context.Customers.ToList();
            var productsTable = _context.Products.ToList();

            var viewModel = new CustomerProductViewModel
            {
                Order = new Order(),
                Customers = customersTable,
                Products = productsTable
            
            };


            return View(viewModel);
        }

        public ActionResult EditOrder(int id)
        {
            var customersTable = _context.Customers.ToList();
            var productsTable = _context.Products.ToList();
            var order = _context.Orders.Include(c => c.Customer).Include(p => p.Product).SingleOrDefault(c => c.Id == id);
            if (order == null)
                return HttpNotFound();

            var viewModel = new CustomerProductViewModel
            {
                Order = order,
                Customers = customersTable,
                Products = productsTable

            };

            return View("AddOrder", viewModel);
        }

        //I dont have the validation implemented to check if the delted order has a customer/product being used because most my time
        // was used learning how to develop in ASP.NET but ideally you would check for such a thing
        public ActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (order == null)
                return HttpNotFound();

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("Orders", "Order");
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == order.Customer.Id);
            var product = _context.Products.SingleOrDefault(p => p.Id == order.Product.Id);

            if (order.Id == 0)
            {
                order.Customer = customer;
                order.Product = product;
                order.CreationDate = DateTime.Now.AddDays(100).ToString();
                order.ExpiredDate = DateTime.Now.AddDays(100).ToString();

                _context.Orders.Add(order);
            }

            else
            {
                var orderInDb = _context.Orders.Include(c => c.Customer).Include(p =>  p.Product).SingleOrDefault(c => c.Id == order.Id);
                orderInDb.Customer = customer;
                orderInDb.Product = product;
            }
            _context.SaveChanges();

            return RedirectToAction("Orders", "Order");
        }
    }
}
