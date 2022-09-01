using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Service
{
    public class ServiceViewModel
    {
        public long ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string CreationDate { get; set; }
    }
}
