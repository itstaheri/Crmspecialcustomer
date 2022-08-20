using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public class LoginResult
    {
        public LoginResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
