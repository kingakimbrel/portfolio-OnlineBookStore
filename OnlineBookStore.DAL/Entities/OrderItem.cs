using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.DAL.Entities
{
    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
        public virtual int Amount { get; set; }
    }
}
