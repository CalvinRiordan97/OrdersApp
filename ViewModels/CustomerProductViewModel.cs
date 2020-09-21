using OrdersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdersApp.ViewModels
{
    public class CustomerProductViewModel
    {
        
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public Order Order { get; set; }
    }
}