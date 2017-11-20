using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tshirtstore.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Display(Name="Product Name")]
        [Required(ErrorMessage="Please enter Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage="Please enter Price")]
        public int Price { get; set; }
        [Display(Name="Category")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage="Please select Image")]
        public string Image { get; set; }
        [Required(ErrorMessage="Please select thumb Image")]
        [Display(Name="Image Thumb")]
        public string ImageThumb { get; set; }
        public DateTime UploadDate { get; set; }
    }
}