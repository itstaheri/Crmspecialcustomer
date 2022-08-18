using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.UserRoleAgg;

namespace User.Infrastructure.Database.Mapps
{
    public class UserRoleMapp : IEntityTypeConfiguration<UserRoleModel>
    {
        public void Configure(EntityTypeBuilder<UserRoleModel> builder)
        {
            builder.HasMany(x=>x.users).WithOne(x=>x.userRole).HasForeignKey(x => x.RoleId); // UserTable To UserRoleTable OnToMany Relation
            builder.HasMany(x=>x.permissions).WithOne(x=>x.userRole).HasForeignKey(x=>x.RoleId); // UserPermissionTable To  UserRoleTable OnToMany Relation
        }
    }
}
