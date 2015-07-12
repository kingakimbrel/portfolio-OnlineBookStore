using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.DAL.Mappings
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("BOOKS");

            Id(x => x.Id).Column("Id");

            Map(x => x.Title).Column("Title");
            Map(x => x.Description).Column("Description");

            References(x => x.Category).Column("CategoryId").Cascade.SaveUpdate();
            References(x => x.Author).Column("AuthorId").Cascade.SaveUpdate();

            Map(x => x.Price).Column("Price");
        }
    }
}
