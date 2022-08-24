using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.State
{
    public class CreateStateViewModel
    {
        [MaxLength(100, ErrorMessage = "نام استان حداکثر باید 100 حرف باشد!")]
        public string StateName { get; set; }
    }
}
