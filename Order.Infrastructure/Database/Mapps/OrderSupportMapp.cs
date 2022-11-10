using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.OrderAgg;
using Order.Domain.OrderSupportAgg;

namespace Order.Infrastructure.Database.Mapps
{
    public class OrderSupportMapp : IEntityTypeConfiguration<OrderSupportModel>
    {
        public void Configure(EntityTypeBuilder<OrderSupportModel> builder)
        {
            //builder.HasOne(x=>x.OrderDetail).WithOne(x => x.OrderSupport).HasForeignKey<OrderSupportModel>(x => x.OrderDetailId);
        }

    }
}
