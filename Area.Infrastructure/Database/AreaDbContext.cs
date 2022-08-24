using Area.Domain.CenterAgg;
using Area.Domain.CityAgg;
using Area.Domain.StateAgg;
using Area.Infrastructure.Database.Mapps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Infrastructure.Database
{
    public class AreaDbContext : DbContext
    {
        public AreaDbContext(DbContextOptions<AreaDbContext> options) : base(options)
        {
        }

        public DbSet<CityModel> cities { get; set; }
        public DbSet<StateModel> states { get; set; }
        public DbSet<CenterModel> centers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CityMapp());
            builder.ApplyConfiguration(new StateMapp());
            builder.ApplyConfiguration(new CenterMapp());

            base.OnModelCreating(builder);
        }
    }
}
