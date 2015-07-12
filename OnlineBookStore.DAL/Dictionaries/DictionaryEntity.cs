using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Dictionaries
{
    public class DictionaryEntity
    {
        public virtual int Id { get; set; }
        public virtual string Value { get; set; }
    }
}
