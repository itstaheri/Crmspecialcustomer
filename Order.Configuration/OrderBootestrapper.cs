using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Contract;
using Order.Application.Contract.OrderDocumentReceipt;
using Order.Application.Implements;
using Order.Domain.OrderAgg;
using Order.Domain.OrderDocumentReceiptAgg;
using Order.Infrastructure.Database;
using Order.Infrastructure.Database.Repositories;

namespace Order.Configuration
{
    public class OrderBootestrapper
    {
        public static void Configuration(IServiceCollection service,string connectionString)
        {
            service.AddDbContext<OrderDbContext>(x=>x.UseSqlServer(connectionString));
            service.AddTransient<IOrderRepository,OrderRepository>();
            service.AddTransient<IOrderApplication, OrderApplication>();
            service.AddTransient<IOrderDocumentReceiptsApplication, OrderDocumentReceiptsApplication>();
            service.AddTransient<IOrderDocumentReceiptRepository, OrderDocumentReceiptRepository>();

        }

    }
}