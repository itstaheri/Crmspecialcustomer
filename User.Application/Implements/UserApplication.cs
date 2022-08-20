using Frameworkes;
using Frameworkes.Auth;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Common;
using User.Application.Contract;
using User.Application.Services;
using User.Domain.UserAgg;
using User.Domain.UserRoleAgg;

namespace User.Application.Implements
{
    public class UserApplication : IUserApplication
    {
        private readonly IAuth _auth;
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _hash;
        private readonly IUserRoleRepository _role;

        public UserApplication(IAuth auth, IUserRepository repository, IPasswordHasher hash, IUserRoleRepository role)
        {
            _auth = auth;
            _repository = repository;
            _hash = hash;
            _role = role;
        }

        public async Task ActiveUser(long UserId)
        {
            //get userInfo
            var user = await _repository.GetBy(UserId);

            //active user & savechange
            user.ActiveUser();
            await _repository.SaveChanges();

        }

        public async Task CreateUser(CreateUserViewModel commend)
        {
            var password = await _hash.Hash(commend.Password);
            var user = new UserModel
                (commend.Username, password, commend.FullName, commend.Code, commend.ProfilePicture, commend.Phone, commend.RoleId);
            await _repository.Create(user);
        }

        public async Task DeActiveUser(long UserId)
        {
            //get userInfo
            var user = await _repository.GetBy(UserId);

            //Deactive user & savechange
            user.DeActiveUser();
            await _repository.SaveChanges();
        }

        public async Task EditUser(EditUserViewModel commend)
        {
            //get userInfo
            var user = await _repository.GetBy(commend.UserId);
            user.Edit(commend.Username,commend.Password,commend.FullName,commend.Code,commend.ProfilePicture,commend.Phone, commend.RoleId);

            await _repository.SaveChanges();
            
        }

        public async Task<List<UserViewModel>> GetAllInfo()
        {
           return (await _repository.GetAll()).Select(x=>new UserViewModel
           {
               Username = x.Username,
               FullName = x.FullName,
               Code = x.Code,
               ProfilePicture = x.ProfilePicture,
               Phone = x.Phone,
               RoleId = x.RoleId
               
           }).ToList();
        }

        public async Task<EditUserViewModel> GetValueForEdit(long UserId)
        {
            //get userInfo
            var user = await _repository.GetBy(UserId);
            return new EditUserViewModel
            {
                Code = user.Code,
                FullName = user.FullName,
                ProfilePicture = user.ProfilePicture,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Username = user.Username,
                UserId = user.Id

            };
        }

        public async Task<LoginResult> Login(LoginViewModel commend)
        {
            var user = await _repository.GetInfoBy(commend.Code);
            if (user == null) return new LoginResult(nameof(LoginResultMessage.WrongUsername));
            (bool Verified, bool NeedsUpgrade) =  _hash.Check(user.Password, commend.Password);
            if (!Verified) return new LoginResult(nameof(LoginResultMessage.WrongPassword));

            AuthViewModel auth = new()
            {
                Code = user.Code,
                FullName = user.FullName,
                Phone = user.Phone,
                ProfilePicture = user.ProfilePicture,
                RoleId = user.RoleId,
                UserId = user.Id,
                Username = user.Username
                
            };
            auth.RoleName = _role.GetRoleName(auth.RoleId);
            auth.Permissions = await _role.GetPermissionsKeysBy(auth.RoleId);

            try
            {
                await _auth.Login(auth);
                return new LoginResult(nameof(LoginResultMessage.SuccessLogin));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }

        }
    }
}
