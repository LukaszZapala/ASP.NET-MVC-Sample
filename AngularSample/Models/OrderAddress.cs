using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class OrderAddress
    {
        public string OrderId { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string HomeNumber { get; set; }

        public virtual Order Order { get; set; }
    }
}