using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.OrderAgg;
using Order.Domain.OrderSupportAgg;

namespace Order.Infrastructure.Database.Mapps
{
    public class OrderDetailMapp : IEntityTypeConfiguration<OrderDetailModel>
    {
        public void Configure(EntityTypeBuilder<OrderDetailModel> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            //builder.HasOne(x => x.OrderSupport).WithOne(x => x.OrderDetail).HasForeignKey<OrderSupportModel>(x => x.OrderDetailId);
        }
    }
}
