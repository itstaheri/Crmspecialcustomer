using Area.Domain.StateAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Infrastructure.Database.Mapps
{
    public class StateMapp : IEntityTypeConfiguration<StateModel>
    {
        public void Configure(EntityTypeBuilder<StateModel> builder)
        {
            builder.HasMany(x=>x.Cities).WithOne(x=>x.State).HasForeignKey(x=>x.StateId);
        }
    }
}
