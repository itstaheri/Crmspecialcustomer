using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contract.UserRole;

namespace User.Application.Services
{
    public interface IUserRoleApplication
    {
        Task<UserRoleViewModel> GetRoleInfoBy(long RoleId);
        Task<List<UserRoleViewModel>> GetAllRoles();
        Task ActionPermissions(List<string> permissions, long RoleId);
        Task<List<PermissionViewModel>> GetPermissionBy(long RoleId);
        Task<List<PermissionViewModel>> GetAllPermissions();
        
    }
}
