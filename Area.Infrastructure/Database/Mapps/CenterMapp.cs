using Area.Domain.CenterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Area.Infrastructure.Database.Mapps
{
    public class CenterMapp : IEntityTypeConfiguration<CenterModel>
    {
        public void Configure(EntityTypeBuilder<CenterModel> builder)
        {
            builder.HasOne(x => x.City).WithMany(x => x.Centers).HasForeignKey(x => x.CityId);
        }
    }
}
