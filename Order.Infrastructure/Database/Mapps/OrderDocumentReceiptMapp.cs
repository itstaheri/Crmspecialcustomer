using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.OrderAgg;
using Order.Domain.OrderDocumentReceiptAgg;

namespace Order.Infrastructure.Database.Mapps
{
    public class OrderDocumentReceiptMapp : IEntityTypeConfiguration<OrderDocumentReceiptModel>
    {
        public void Configure(EntityTypeBuilder<OrderDocumentReceiptModel> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.DocumentReceipt).HasForeignKey(x => x.OrderId);
        }
    }
}
