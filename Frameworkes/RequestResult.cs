using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public class RequestResult
    {
        public RequestResult(string message, object key,bool isSuccessful)
        {
            Message = message;
            Key = key;
            ISsuccessful = isSuccessful;
        }

        public string Message { get; set; }
        public object Key { get; set; }
        public bool ISsuccessful { get; set; }

    }
}
