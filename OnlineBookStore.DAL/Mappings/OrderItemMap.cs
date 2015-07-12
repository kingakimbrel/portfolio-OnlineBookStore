using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.DAL.Mappings
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table("OrderItems");

            Id(x => x.Id).Column("Id");

            References(x => x.Order).Column("OrderId");
            References(x => x.Book).Column("BookId");

            Map(x => x.Amount).Column("Amount");
        }
    }
}
