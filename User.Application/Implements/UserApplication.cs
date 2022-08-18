using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contract;
using User.Application.Services;
using User.Domain.UserAgg;

namespace User.Application.Implements
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _repository;

        public UserApplication(IUserRepository repository)
        {
            _repository = repository;
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
            var user = new UserModel
                (commend.Username, commend.Password, commend.FullName, commend.Code, commend.ProfilePicture, commend.Phone, commend.RoleId);
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
    }
}
