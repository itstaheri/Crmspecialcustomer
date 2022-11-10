using Message.Domain.MessageAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Message.Infrastructure.Database.Mapping
{
    public class UserMessageMapp : IEntityTypeConfiguration<UserMessageModel>
    {
        public void Configure(EntityTypeBuilder<UserMessageModel> builder)
        {
            builder.HasOne(x=>x.Message).WithMany(x=>x.UserMessages).HasForeignKey(x => x.MessageId);
        }
    }

}
