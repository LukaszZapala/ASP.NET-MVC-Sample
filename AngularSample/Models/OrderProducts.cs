using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class OrderProducts
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

    }
}