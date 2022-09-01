using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.Domain.RequestServiceAgg;

namespace Request.Infrastructure.Database.Mapps
{
    public class ServiceMapp : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder.HasMany(x=>x.Requests).WithOne(x=>x.Service).HasForeignKey(x => x.ServiceId);
        }
    }
}
