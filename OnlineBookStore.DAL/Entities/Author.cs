using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Entities
{
    public class Author
    {
        public virtual int Id { get; set; }
        public virtual string First { get; set; }
        public virtual string Last { get; set; }

        public virtual IList<Book> Books { get; set; }
    }
}
