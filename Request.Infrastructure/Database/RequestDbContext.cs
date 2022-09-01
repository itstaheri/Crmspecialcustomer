using Microsoft.EntityFrameworkCore;
using Request.Domain.RequestAgg;
using Request.Domain.RequestServiceAgg;
using Request.Infrastructure.Database.Mapps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Infrastructure.Database
{
    public class RequestDbContext : DbContext
    {
        public RequestDbContext(DbContextOptions<RequestDbContext> options) : base(options)
        {

        }
        public DbSet<RequestModel> requests { get; set; }
        public DbSet<ServiceModel> services { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RequestMapp());
            builder.ApplyConfiguration(new ServiceMapp());
            base.OnModelCreating(builder);
        }
    }
}
