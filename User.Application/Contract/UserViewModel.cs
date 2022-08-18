using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contract
{
    public class UserViewModel
    {
        public long UserId { get; set; }
        public string CreationDate { get; set; }
        public string Username { get;  set; }
        public string FullName { get;  set; }
        public string Code { get;  set; }
        public string ProfilePicture { get;  set; }
        public string Phone { get;  set; }
        public long RoleId { get;  set; }
        public bool IsActive { get;  set; }
    }
}
