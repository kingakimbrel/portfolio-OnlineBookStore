using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.DAL.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");

            Id(x => x.Id).Column("Id");
            Map(x => x.OrderDate).Column("OrderDate").Nullable();

            References(x => x.ShippingDetails).Column("ShippingDetailId").Cascade.SaveUpdate();

            HasMany(x => x.OrderItems).KeyColumn("OrderId").Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
