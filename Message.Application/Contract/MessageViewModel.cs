using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Contract
{
    public class MessageViewModel
    {
        public long Id { get; set; }
        public long FormUserId { get;  set; }
        public string FromUserName { get;  set; }
        public long ToUserId { get;  set; }
        public string Subject { get;  set; }
        public string BodyMessage { get;  set; }
        public bool IsHide { get;  set; }
        public bool IsReadByCurrentUser { get; set; }
        public  DateTime CreationDate { get; set; }
    }
}
