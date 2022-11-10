using Message.Domain.MessageAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Infrastructure.Database.Mapping
{
    public class MessageMapp : IEntityTypeConfiguration<MessageModel>
    {
        public void Configure(EntityTypeBuilder<MessageModel> builder)
        {
            builder.HasMany(x => x.UserMessages).WithOne(x => x.Message).HasForeignKey(x => x.MessageId);
        }
    }

}
