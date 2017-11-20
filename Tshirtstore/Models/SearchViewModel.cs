using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tshirtstore.Models
{
    public class SearchViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageThumb { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
    }
}