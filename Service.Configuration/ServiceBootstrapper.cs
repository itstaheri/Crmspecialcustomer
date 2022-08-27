using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Application.Contract.Material;
using Service.Application.Implements;
using Service.Domain.ServiceAgg;
using Service.Infrastructure.Database;
using Service.Infrastructure.Database.Repositories;

namespace Service.Configuration
{
    public class ServiceBootstrapper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ServiceDbContext>(x=>x.UseSqlServer(connectionString));
            services.AddTransient<IMaterialApplication, MaterialApplication>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
        }

    }
}