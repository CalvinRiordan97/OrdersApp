
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }

        public string CreationDate { get; set; }

        public string ExpiredDate{ get; set; }

        //public Status Status { get; set; }
        
    }
}