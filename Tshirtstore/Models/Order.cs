using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tshirtstore.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        [Display(Name="Shipping Address")]
        [Required(ErrorMessage="Please enter Shipping Address")]
        public string ShippingAddress { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}