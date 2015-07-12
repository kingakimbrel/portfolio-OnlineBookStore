using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OnlineBookStore.DAL.Dictionaries;

namespace OnlineBookStore.DAL.Mappings
{
    public class CategoryMap : ClassMap<CategoryDictionary>
    {
        public CategoryMap()
        {
            Table("Categories");
            ReadOnly();

            Id(x => x.Id).Column("Id");
            Map(x => x.Value, "Value");
        }
    }
}
