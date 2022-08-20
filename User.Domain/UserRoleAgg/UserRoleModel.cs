using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserAgg;

namespace User.Domain.UserRoleAgg
{
    public class UserRoleModel : BaseEntity
    {
        public UserRoleModel(string roleName)
        {
            RoleName = roleName;
            permissions = new();
            users = new();
        }

        public string RoleName { get;private set; }
        public List<UserModel> users { get;private set; }
        public List<UserPermissionModel> permissions { get;private set; }

    }
}
