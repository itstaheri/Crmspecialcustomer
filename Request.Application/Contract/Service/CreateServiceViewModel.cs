using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Service
{
    public class CreateServiceViewModel
    {
        [MinLength(5, ErrorMessage ="نام سرویس باید حداعقل 5 حرف باشد!")]
        public string ServiceName { get; set; }
    }
}
