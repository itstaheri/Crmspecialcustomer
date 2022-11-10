using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contract
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="فیلد {0}اجباری است")]
        public string Code { get; set; }
        [Required(ErrorMessage = "فیلد {0}اجباری است")]
        public string Password { get; set; }
    }
}
