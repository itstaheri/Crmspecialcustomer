using Area.Domain.CityAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Area.Infrastructure.Database.Mapps
{
    public class CityMapp : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> builder)
        {
            builder.HasMany(x => x.Centers).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            builder.HasOne(x => x.State).WithMany(x => x.Cities).HasForeignKey(x => x.StateId);
        }
    }
}
