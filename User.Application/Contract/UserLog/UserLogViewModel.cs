using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contract.UserLog
{
    public class UserLogViewModel
    {
        public long LogId { get; set; }
        public long UserId { get; set; }
        public DateTime ActionDate { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }  
    }
}
