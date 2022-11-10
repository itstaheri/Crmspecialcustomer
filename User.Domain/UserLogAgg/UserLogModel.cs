using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.UserLogAgg
{
    public class UserLogModel
    {
        public UserLogModel(long userId, string action)
        {
            UserId = userId;
            ActionDate = DateTime.Now;
            Action = action;
        }

        public long Id { get;private set; }
        public long UserId { get; private set; }
        public DateTime ActionDate { get; private set; }
        public string Action { get; private set; }

    }
}
