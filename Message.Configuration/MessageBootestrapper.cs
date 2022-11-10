using Message.Application.Implement;
using Message.Application.Services;
using Message.Domain.MessageAgg;
using Message.Infrastructure.Database;
using Message.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Configuration
{
    public class MessageBootestrapper
    {
        public static void Configuration(IServiceCollection service,string connectionString)
        {
            service.AddDbContext<MessageDbContext>(x=>x.UseSqlServer(connectionString));
            service.AddTransient<IMessageRepository, MessageRepository>();
            service.AddTransient<IMessageApplication, MessageApplication>();
        }
    }
}