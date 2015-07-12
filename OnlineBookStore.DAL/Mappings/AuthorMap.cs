using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.DAL.Mappings
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Table("AUTHORS");

            Id(x => x.Id).Column("Id");

            Map(x => x.First).Column("First");
            Map(x => x.Last).Column("Last");

            HasMany(x => x.Books).KeyColumn("AuthorId").Cascade.None();
        }
    }
}
