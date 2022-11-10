using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Contract.UserMessage
{
    public class UserMessageViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public bool IsRead { get; set; }
        public long MessageId { get; set; }
    }
}
