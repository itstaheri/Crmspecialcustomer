using Intermediary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.UserAgg;

namespace Intermediary.Implement
{
    public class MessageToUserRepository : IMessageToUserRepository
    {
        private readonly IUserRepository repository;

        public MessageToUserRepository(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> GetUserInfoById(long UserId)
        {
            return (await repository.GetBy(UserId)).Username;
        }
    }
}
