using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public class ChangePassword
    {
        public long UserId { get; set; }


        public string ?NewPassword { get; set; }
       // [Compare("NewPassword", ErrorMessage = "تکرار رمزعبور با رمزعبور وارد شده تطابق ندارد!")]
        public string ?RePassword { get; set; }
    }
}
