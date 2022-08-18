using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contract;

namespace User.Application.Services
{
    public interface IUserApplication 
    {
        Task CreateUser(CreateUserViewModel commend);
        Task EditUser(EditUserViewModel commend);
        Task<EditUserViewModel> GetValueForEdit(long UserId);
        Task ActiveUser(long UserId);
        Task DeActiveUser(long UserId);
        Task<List<UserViewModel>> GetAllInfo();
        
    }
}
