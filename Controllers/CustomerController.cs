using OrdersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdersApp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer/Customers
        public ActionResult Customers()
        {
            var customer = _context.Customers.ToList();
            return View(customer);
        }

        //[Route("customer/addcustomer")]
        public ActionResult AddCustomer()
        {
            return View();
        }

        public ActionResult EditCustomer(int id) 
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            Customer cust = customer;

            return View("AddCustomer", cust);
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Customers", "Customer");
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else 
            { 
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id );
                customerInDb.Fname = customer.Fname;
                customerInDb.Lname = customer.Lname;
                customerInDb.Address = customer.Address;
                customerInDb.Phone = customer.Phone;
            }
            _context.SaveChanges();

            return RedirectToAction("Customers", "Customer");
        }
    }
}