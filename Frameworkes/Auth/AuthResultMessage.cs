using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes.Auth
{
    public class AuthResultMessage
    {
        public AuthResultMessage(string message,bool seuccess)
        {
            Message = message;
            Success = seuccess;
        }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
