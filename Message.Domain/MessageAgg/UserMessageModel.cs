using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Domain.MessageAgg
{
    public class UserMessageModel
    {
        public UserMessageModel(long userId, long messageId)
        {
            UserId = userId;
            MessageId = messageId;
            IsRead = false;
        }
        public void ReadMeesage() => IsRead = true;

        public long Id { get; private set; }
        public long UserId { get; private set; }
        public long MessageId { get; private set; }
        public bool IsRead { get; private set; }
        public MessageModel Message { get;private set; }


    }
}
