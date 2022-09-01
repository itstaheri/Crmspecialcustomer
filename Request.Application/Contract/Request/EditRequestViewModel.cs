using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Request
{
    public class EditRequestViewModel : CreateRequestViewModel
    {
        public long RequestId { get; set; }
        public string LetterId { get; set; }
    }
}
