using Microsoft.EntityFrameworkCore;
using Order.Domain.OrderAgg;
using Order.Domain.OrderDocumentReceiptAgg;
using Order.Domain.OrderSupportAgg;
using Order.Infrastructure.Database.Mapps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Database
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<OrderModel> orders { get; set; }   
        public DbSet<OrderDetailModel> orderDetails { get; set; }
        public DbSet<OrderDocumentReceiptModel>  orderDocumentReceipts { get; set; }
        public DbSet<OrderSupportModel>  orderSupports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderMapp());
            builder.ApplyConfiguration(new OrderDetailMapp());
            builder.ApplyConfiguration(new OrderDocumentReceiptMapp());
           // builder.ApplyConfiguration(new OrderSupportMapp());
            base.OnModelCreating(builder);
        }
    }
}
