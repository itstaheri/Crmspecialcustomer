using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Common
{
    public class ResultMessage
    {
        public ResultMessage(int status)
        {
            Status = status;
        }
        public ResultMessage(string key, int status)
        {
            Message = $"استانی با مشخصه {key} وجود دارد!";
            Status = status;

        }
        public string Message { get; set; }
        public int Status { get; set; }
    }
}
