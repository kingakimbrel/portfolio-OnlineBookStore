using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Models
{
    public class AuthorModel : BaseModel
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}