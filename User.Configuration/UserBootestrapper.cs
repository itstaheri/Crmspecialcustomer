using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Implements;
using User.Application.Services;
using User.Domain.UserAgg;
using User.Domain.UserRoleAgg;
using User.Infrastructure.Database;
using User.Infrastructure.Database.Repositories;

namespace User.Configuration
{
    public class UserBootestrapper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRoleRepository,UserRoleRepository>();
            services.AddTransient<IUserRoleApplication,UserRoleApplication>();
        }
    }
}