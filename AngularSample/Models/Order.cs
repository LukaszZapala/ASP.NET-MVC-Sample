using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new List<OrderProducts>();
        }

        public string Id { get; set; }

        public decimal Ammount { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public OrderAddress OrderAddress { get; set; }
        public ICollection<OrderProducts> ProductOrders { get; set; }
    }
}