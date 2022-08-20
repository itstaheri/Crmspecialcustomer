using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserAgg;

namespace User.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      

        public async Task Create(UserModel entity)
        {
            //add UserToDatabase
            try
            {
                await _dbContext.users.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

       

        public async Task<List<UserModel>> GetAll()
        {
            //GetAll UsersInfo from database
            return await _dbContext.users.ToListAsync();
        }

        public async Task<UserModel> GetBy(long Id)
        {
            //GetUserInfo by UserId from database
            return await _dbContext.users.FirstOrDefaultAsync(x=>x.Id == Id);
        }

        public async Task<UserModel> GetInfoBy(string Code)
        {
            //GetUserInfo by Username from database
            return await _dbContext.users.FirstOrDefaultAsync(x => x.Code == Code);
        }

        public async Task SaveChanges()
        {
            
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }
    }
}
