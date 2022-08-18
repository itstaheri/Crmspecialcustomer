using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contract
{
    public class EditUserViewModel : CreateUserViewModel
    {
        public long UserId { get; set; }
    }
}
