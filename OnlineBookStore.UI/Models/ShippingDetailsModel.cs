using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Models
{
    public class ShippingDetailsModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last")]
        public string LastName { get; set; }
        [Required]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }

        public IList<OrderModel> Orders { get; set; }
    }
}