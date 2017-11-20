using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tshirtstore.Models
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string UserName { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}