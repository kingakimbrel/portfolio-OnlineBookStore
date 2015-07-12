using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.DAL.Mappings
{
    public class ShippingDetailsMap : ClassMap<ShippingDetails>
    {
        public ShippingDetailsMap()
        {
            Table("ShippingDetails");

            Id(x => x.Id).Column("Id");
            Map(x => x.FirstName).Column("FirstName");
            Map(x => x.LastName).Column("LastName");
            Map(x => x.Line1).Column("Line1");
            Map(x => x.Line2).Column("Line2");
            Map(x => x.Line3).Column("Line3");
            Map(x => x.City).Column("City");
            Map(x => x.Zip).Column("Zip");
            Map(x => x.Country).Column("Country");

            HasMany(x => x.Orders).KeyColumn("ShippingDetailId").Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
