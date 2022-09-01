using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.Domain.RequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Infrastructure.Database.Mapps
{
    public class RequestMapp : IEntityTypeConfiguration<RequestModel>
    {
        public void Configure(EntityTypeBuilder<RequestModel> builder)
        {
            builder.HasOne(x => x.Service).WithMany(x => x.Requests).HasForeignKey(x => x.ServiceId);
        }
    }
}
