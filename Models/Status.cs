using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApp.Models
{
    public class Status
    {
       
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}