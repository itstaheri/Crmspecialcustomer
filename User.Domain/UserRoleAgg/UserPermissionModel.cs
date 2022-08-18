using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.UserRoleAgg
{
    public class UserPermissionModel : BaseEntity
    {
        public UserPermissionModel(string permissionKey, long roleId)
        {
            PermissionKey = permissionKey;
            RoleId = roleId;
        }

        public string PermissionKey { get;private set; }
        public long RoleId { get; private set; }
        public UserRoleModel userRole { get; private set; }   
    }
}
