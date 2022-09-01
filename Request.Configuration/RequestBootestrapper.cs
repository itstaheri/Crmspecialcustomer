using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Request.Application.Contract;
using Request.Application.Contract.Request;
using Request.Application.Contract.Service;
using Request.Application.Implements;
using Request.Domain.RequestAgg;
using Request.Domain.RequestServiceAgg;
using Request.Infrastructure.Database;
using Request.Infrastructure.Database.Implement;

namespace Request.Configuration
{
    public class RequestBootestrapper
    {
        public static void Configuration(IServiceCollection service,string connectionString)
        {
            service.AddDbContext<RequestDbContext>(x => x.UseSqlServer(connectionString));
            service.AddTransient<IServiceRepository, ServiceRepository>();
            service.AddTransient<IServiceApplication, ServiceApplication>();
            service.AddTransient<IRequestApplication, RequestApplication>();
            service.AddTransient<IRequestRepository, RequestRepository>();

        }
    }
}