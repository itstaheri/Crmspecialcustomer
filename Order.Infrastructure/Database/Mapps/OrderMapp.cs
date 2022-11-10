using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.OrderAgg;
using Order.Domain.OrderSupportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Database.Mapps
{
    public partial class OrderMapp : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany(x => x.DocumentReceipt).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        }
    }
}
