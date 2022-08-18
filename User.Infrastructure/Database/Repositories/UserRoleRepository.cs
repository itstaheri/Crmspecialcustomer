using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserRoleAgg;

namespace User.Infrastructure.Database.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRoleRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(UserRoleModel entity)
        {
           throw new NotImplementedException();
        }

        public async Task CreatePermission(List<UserPermissionModel> permissions)
        {
            var RoleId = permissions.Select(x => x.RoleId).FirstOrDefault();
            //check for remove current Specified_RoleId permission for replace new permissions
            if (RoleId!=0) await RemovePermissionsBy(RoleId); else { throw new NotFoundException(nameof(RoleId),RoleId); }

            try
            {
                //add list of permission to database
                await _dbContext.userPermissions.AddRangeAsync(permissions);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<UserRoleModel>> GetAll()
        {
            return await _dbContext.userRoles.ToListAsync();
        }

        public async Task<UserRoleModel> GetBy(long Id)
        {
            var role = await _dbContext.userRoles.FirstOrDefaultAsync(x=>x.Id == Id);
            if (role == null) throw new NotFoundException(nameof(role),Id);
            return role;
        }

        public async Task<List<UserPermissionModel>> GetPermissions()
        {
            return await _dbContext.userPermissions.ToListAsync();
        }

        public async Task<List<UserPermissionModel>> GetPermissionsBy(long RoleId)
        {
            return await _dbContext.userPermissions.Where(x=>x.RoleId == RoleId).ToListAsync();
        }

        public async Task<bool> RemovePermissionsBy(long RoleId)
        {
            //get all permission by RoleId
            var permissions = await _dbContext.userPermissions.Where(x=>x.RoleId==RoleId).ToListAsync();
            //if permissions was null! return false , mean : we dont have any permission for remove it
            if (permissions == null) return false;
          
            try
            {
                //remove permissions
                _dbContext.userPermissions.RemoveRange(permissions);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
