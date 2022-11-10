using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediary.Repository
{
    public interface IMessageToUserRepository
    {
        Task<string> GetUserInfoById(long UserId);

    }
}
