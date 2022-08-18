using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contract
{
    public class CreateUserViewModel
    {
        public string Username { get;  set; }
        public string Password { get;  set; }
        public string FullName { get;  set; }
        public string Code { get;  set; }
        public string ProfilePicture { get;  set; }
        public string Phone { get;  set; }
        public long RoleId { get;  set; }
    }
}
