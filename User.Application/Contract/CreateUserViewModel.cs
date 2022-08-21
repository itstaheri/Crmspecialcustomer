using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contract
{
    public class CreateUserViewModel
    {
        
        [MaxLength(30,ErrorMessage ="نام کاربری حداکثر باید 30 حرف باشد!")]
        [MinLength(5,ErrorMessage = "نام کاربری حداعقل باید 5 حرف باشد")]
        public string? Username { get;  set; }
        [MinLength(8, ErrorMessage = "رمزعبور حداعقل باید 8 حرف باشد")]
        public string Password { get;  set; }
        [Compare(nameof(Password),ErrorMessage ="تکرار رمزعبور با رمزعبور وارد شده تطابق ندارد!")]
        public string RePassword { get;  set; }
        public string? FullName { get;  set; }
        [MaxLength(10, ErrorMessage = "کدملی نمیتواند از 10 رقم بیشتر باشد!")]
        [MinLength(10, ErrorMessage = "کدملی نمیتواند از 10 رقم کمتر باشد!")]
        public string? Code { get;  set; }
        public IFormFile? ProfilePicture { get;  set; }
        public string? Phone { get;  set; }
        public long RoleId { get;  set; }
    }
}
