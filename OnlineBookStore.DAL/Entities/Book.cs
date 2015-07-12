using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OnlineBookStore.DAL.Dictionaries;
using System.Collections.Generic;

namespace OnlineBookStore.DAL.Entities
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual CategoryDictionary Category { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Description { get; set; }
        public virtual Author Author { get; set; }
        
    }
}