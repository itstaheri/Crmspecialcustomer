using Message.Domain.MessageAgg;
using Message.Infrastructure.Database.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Infrastructure.Database
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> option) : base(option)
        {

        }
        public DbSet<MessageModel> messages { get; set; }
        public DbSet<UserMessageModel> userMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMessageMapp());
            builder.ApplyConfiguration(new MessageMapp());
            base.OnModelCreating(builder);
        }
    }
}
