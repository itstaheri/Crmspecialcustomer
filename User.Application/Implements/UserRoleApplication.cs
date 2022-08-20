using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contract.UserRole;
using User.Application.Services;
using User.Domain.UserRoleAgg;

namespace User.Application.Implements
{
    public class UserRoleApplication : IUserRoleApplication
    {
        private readonly IUserRoleRepository _repository;

        public UserRoleApplication(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task ActionPermissions(List<string> permissions,long RoleId)
        {
            //sampling empty list ofUSerPermissionModel
            List<UserPermissionModel> permissionsModel = new List<UserPermissionModel>();

            //Add enteries to permissionsModel for add to CreatePermission Method
            foreach (var item in permissions)
            {
                var permission = new UserPermissionModel(item, RoleId);
                permissionsModel.Add(permission);

            }
            await _repository.CreatePermission(permissionsModel);

        }

        public async Task<List<PermissionViewModel>> GetAllPermissions()
        {
            return (await _repository.GetPermissions())
                .Select(x=>new PermissionViewModel { PermissionKey = x.PermissionKey,RoleId=x.RoleId}).ToList();
        }

        public async Task<List<UserRoleViewModel>> GetAllRoles()
        {
            return (await _repository.GetAll()).Select(x=>new UserRoleViewModel { RoleId = x.Id,RoleName = x.RoleName}).ToList();
        }

        public async Task<List<string>> GetPermissionBy(long RoleId)
        {
            //return permissions from RoleId 
           return (await _repository.GetPermissionsKeysBy(RoleId))
               .ToList();

            
        }

        public async Task<UserRoleViewModel> GetRoleInfoBy(long RoleId)
        {
            var userRole = await _repository.GetBy(RoleId);
            return new UserRoleViewModel
            {
                RoleId = userRole.Id,
                RoleName = userRole.RoleName,
            };
        }
    }
}
