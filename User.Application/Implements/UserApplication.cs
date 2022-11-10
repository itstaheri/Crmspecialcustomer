using Exceptions;
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
using User.Application.Contract.UserLog;
using User.Application.Services;
using User.Domain.UserAgg;
using User.Domain.UserLogAgg;
using User.Domain.UserRoleAgg;

namespace User.Application.Implements
{
    public class UserApplication : IUserApplication
    {
        private readonly IAuth _auth;
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _hash;
        private readonly IUserRoleRepository _role;
        private readonly IFileHelper _fileHelper;

        public UserApplication(IAuth auth, IUserRepository repository, IPasswordHasher hash, IUserRoleRepository role, IFileHelper fileHelper)
        {
            _auth = auth;
            _repository = repository;
            _hash = hash;
            _role = role;
            _fileHelper = fileHelper;
        }

        public async Task ActiveUser(long UserId)
        {
            //get userInfo
            var user = await _repository.GetBy(UserId);

            //active user & savechange
            user.ActiveUser();
            await _repository.SaveChanges();

        }
        //if oldpassword & userpassword was equal return true & change that else return false 
        public async Task<bool> ChangePassword(ChangePassword commend)
        {
            var user = await _repository.GetBy(commend.UserId);
            if (user == null) return false;
            var passwrod = await _hash.Hash(commend.NewPassword);

            user.ChangePassword(passwrod);
            await _repository.SaveChanges();
            return true;


        }

        public async Task<UserResult> CreateUser(CreateUserViewModel commend)
        {
            //get all users & check the Unique check of values
            var usersDetail = (await _repository.GetAll());
            if (usersDetail.Any(x => x.Username == commend.Username)) return new UserResult(commend.Username, UserStatus.RepetitiousUserName);
            if (usersDetail.Any(x => x.Code == commend.Code)) return new UserResult(commend.Code, UserStatus.RepetitiousUserCode);

            //convet password to hash string
            var password = await _hash.Hash(commend.Password);

            //make new of usermodel for create User
            var user = new UserModel
                (commend.Username, password, commend.FullName, commend.Code, "avatar.jpg", commend.Phone, commend.RoleId,_auth.GetCurrentId());


            await _repository.Create(user);

            return new UserResult(commend.Username, UserStatus.CreateSuccess);
        }

       

        public async Task DeActiveUser(long UserId)
        {
            //get userInfo
            var user = await _repository.GetBy(UserId);

            //Deactive user & savechange
            user.DeActiveUser();
            await _repository.SaveChanges();
        }

        public async Task<UserResult> EditUser(EditUserViewModel commend)
        {
            var userDetail = await _repository.GetAll();

            var checkUsername = userDetail.Any(x => x.Username == commend.Username && x.Id != commend.UserId);
            if (checkUsername) return new UserResult(commend.Username, UserStatus.RepetitiousUserName);

            var checkCode = userDetail.Any(x => x.Code == commend.Code && x.Id != commend.UserId);
            if (checkCode) return new UserResult(commend.Code, UserStatus.RepetitiousUserCode);
            //upload profilepicture and return image name
            var picture = await _fileHelper.SingleUploader(commend.ProfilePicture, "Users", commend.UserId.ToString());
            //get userInfo
            var user = await _repository.GetBy(commend.UserId);

            user.Edit(commend.Username, commend.FullName, commend.Code, picture, commend.Phone, commend.RoleId,_auth.GetCurrentId());

            await _repository.SaveChanges();
            //login again current user
            if(user.Id == _auth.GetCurrentId())
                await Login(new LoginViewModel { Code = user.Code, Password = user.Password });

            return new UserResult(user.Username, UserStatus.CreateSuccess);
        }

        public async Task<List<UserViewModel>> GetAllInfo()
        {
            var query = (await _repository.GetAll()).Select(x => new UserViewModel
            {
                Username = x.Username,
                FullName = x.FullName,
                Code = x.Code,
                ProfilePicture = x.ProfilePicture,
                Phone = x.Phone,
                RoleId = x.RoleId,
                UserId = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                IsActive = x.IsActive,

            }).ToList();
            query.ForEach(x => x.RoleName = _role.GetRoleName(x.RoleId));
            return query;
        }

        public async Task<List<UserLogViewModel>> GetAllUsersLogInfo()
        {
            var query = (await _repository.GetAllUsersLogInfo()).Select(x => new UserLogViewModel
            {
                Action = x.Action,
                ActionDate = x.ActionDate,
                UserId = x.UserId,
                LogId = x.Id
            }).ToList();
            foreach (var item in query)
            {
                item.UserName = (await _repository.GetBy(item.UserId)).Username;
            }
            return query;
        }

        public async Task<EditUserViewModel> GetValueForEdit(long UserId)
        {
            //get userInfo
            var user = await _repository.GetBy(UserId);
            if (user == null) throw new NotFoundException(nameof(user), user);
            return new EditUserViewModel
            {
                Code = user.Code,
                FullName = user.FullName,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Username = user.Username,
                UserId = user.Id

            };

        }

        public async Task<LoginResult> Login(LoginViewModel commend)
        {
            //get user info by code
            var user = await _repository.GetInfoBy(commend.Code);
            if (!user.IsActive) return new LoginResult(nameof(LoginResultMessage.DeActiveUser));

            if (user == null) return new LoginResult(nameof(LoginResultMessage.WrongUsername));


            (bool Verified, bool NeedsUpgrade) = _hash.Check(user.Password, commend.Password);
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
            //get user role and permission by roleId
            auth.RoleName = _role.GetRoleName(auth.RoleId);
            auth.Permissions = await _role.GetPermissionsKeysBy(auth.RoleId);

            try
            {
                //do login
                await _auth.Login(auth);
                //Add login log to database
                await _repository.CreateUserLog(new UserLogModel(user.Id, UserLogActions.Login));
                return new LoginResult(nameof(LoginResultMessage.SuccessLogin));
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task Logout()
        {
            //logout
            await _auth.LogOut();
            //Add logout log to database
            await _repository.CreateUserLog(new UserLogModel(_auth.GetCurrentId(), UserLogActions.Logout));
        }
    }
}
