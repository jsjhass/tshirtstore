using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tshirtstore.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }
        [Required(ErrorMessage="Please enter User Name")]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage="Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage="Please enter Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$",ErrorMessage="Please enter valid Mobile Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage="Please enter Email ID")]
        [DataType(DataType.EmailAddress,ErrorMessage="Please enter vaild Email ID")]
        public string Email { get; set; }
    }
}