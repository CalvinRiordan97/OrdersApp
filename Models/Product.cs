using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public string ExpiredDate{ get; set; }
    }
}