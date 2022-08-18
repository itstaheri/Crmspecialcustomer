using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.UserRoleAgg;

namespace User.Infrastructure.Database.Mapps
{
    public class UserPermissionsMapp : IEntityTypeConfiguration<UserPermissionModel>
    {
        public void Configure(EntityTypeBuilder<UserPermissionModel> builder)
        {
            builder.HasOne(x=>x.userRole).WithMany(x=>x.permissions).HasForeignKey(x => x.RoleId); // UserRoleTable To UserPermissionTable OnToMany Relation
        }
    }
}
