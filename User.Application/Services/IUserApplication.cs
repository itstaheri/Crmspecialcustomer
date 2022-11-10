using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Common;
using User.Application.Contract;
using User.Application.Contract.UserLog;

namespace User.Application.Services
{
    public interface IUserApplication 
    {
        Task<UserResult> CreateUser(CreateUserViewModel commend);
        Task<UserResult> EditUser(EditUserViewModel commend);
        Task<EditUserViewModel> GetValueForEdit(long UserId);
        Task ActiveUser(long UserId);
        Task DeActiveUser(long UserId);
        Task<List<UserViewModel>> GetAllInfo();
        Task<LoginResult> Login(LoginViewModel commend);
        Task Logout();
        Task<bool> ChangePassword(ChangePassword commend);
        Task<List<UserLogViewModel>> GetAllUsersLogInfo();
        
    }
}
