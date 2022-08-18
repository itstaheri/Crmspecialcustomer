using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserAgg;

namespace User.Infrastructure.Database.Mapps
{
    public class UserMapp : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            
            builder.HasOne(x => x.userRole).WithMany(x => x.users).HasForeignKey(x => x.RoleId); // UserTable To UserRoleTable OnToMany Relation
        }
    }
}
