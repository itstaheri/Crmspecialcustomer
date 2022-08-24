using Area.Application.Contract.Center;
using Area.Application.Contract.City;
using Area.Application.Contract.State;
using Area.Application.Implements;
using Area.Domain.CenterAgg;
using Area.Domain.CityAgg;
using Area.Domain.StateAgg;
using Area.Infrastructure.Database;
using Area.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Area.Configuration
{
    public  class AreaBootstrapper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<AreaDbContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<ICenterRepository, CenterRepository>();
            services.AddTransient<ICenterApplication, CenterApplication>();
            services.AddTransient<ICityApplication, CityApplication>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IStateApplication, StateApplication>();
        }
    }
}