using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.UserAgg
{
    public interface IUserRepository : IGenericRepository<UserModel,UserModel>
    {
        Task<UserModel> GetInfoBy(string Code); 
        
        
    }
}
