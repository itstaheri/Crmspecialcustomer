using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Contract
{
    public class CreateMessageViewModel
    {
        public long FormUserId { get; set; }
        public string[] ToUsersId { get; set; }
        public string Subject { get; set; }
        public string BodyMessage { get; set; }
    }
}
