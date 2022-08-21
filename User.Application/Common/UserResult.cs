using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public  class UserResult
    {
        public UserResult(string key,int status)
        {
            Message = $"کاربری با مشخصه {key} وجود دارد!";
            Status = status;

        }
        public  string Message { get; set; }
        public int Status { get; set; }
        
    }
}
