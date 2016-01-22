using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class DiscountCode
    {
        public string Id { get; set; }
        
        public Guid Code { get; set; }

        public double Discount { get; set; }

        public bool Used { get; set; }
    }
}