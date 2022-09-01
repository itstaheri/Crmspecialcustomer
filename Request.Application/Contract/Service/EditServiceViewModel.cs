using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Service
{
    public class EditServiceViewModel : CreateServiceViewModel
    {
        public long ServiceId { get; set; }
    }
}
