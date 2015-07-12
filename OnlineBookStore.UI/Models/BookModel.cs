using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Models
{
    public class BookModel : BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public CategoryModel Category { get; set; }
        [Required]
        [Range(1, 500000000)]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        public AuthorModel Author { get; set; }
    }
}