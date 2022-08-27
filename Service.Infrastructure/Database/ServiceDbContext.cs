using Microsoft.EntityFrameworkCore;
using Service.Domain.ServiceAgg;
using Service.Infrastructure.Database.Mapps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Infrastructure.Database
{
    public class ServiceDbContext : DbContext
    {
        
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
            
        }
        public DbSet<MaterialModel> materials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MaterialMapp());
            base.OnModelCreating(builder);
        }
    }
}
