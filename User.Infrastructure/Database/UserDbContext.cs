using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserAgg;
using User.Domain.UserRoleAgg;
using User.Infrastructure.Database.Mapps;

namespace User.Infrastructure.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> users { get; set; }
        public DbSet<UserPermissionModel> userPermissions { get; set; }
        public DbSet<UserRoleModel> userRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //mapping registers
            builder.ApplyConfiguration(new UserMapp());
            builder.ApplyConfiguration(new UserPermissionsMapp());
            builder.ApplyConfiguration(new UserRoleMapp());
            base.OnModelCreating(builder);
        }
    }
}
