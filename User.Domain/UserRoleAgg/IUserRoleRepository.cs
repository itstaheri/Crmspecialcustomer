using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.UserRoleAgg
{
    public interface IUserRoleRepository : IGenericRepository<UserRoleModel,UserRoleModel>
    {
        Task<List<UserPermissionModel>> GetPermissions(); //Get all permissions 
        Task<List<string>> GetPermissionsKeysBy(long RoleId); // Get permissions of a role
        Task CreatePermission(List<UserPermissionModel> permissions);
        Task<bool> RemovePermissionsBy(long RoleId);
        string GetRoleName(long RoleId);
       
    }
}
