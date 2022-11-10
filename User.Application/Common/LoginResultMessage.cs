using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public static class LoginResultMessage
    {
        public const string WrongPassword = "کلمه عبور وارد شده اشتباه است!";
        public const string WrongUsername = "نام کاربری وارد شده در سیستم ثبت نشده است!";
        public const string SuccessLogin = "ورود با موفقیت انجام شد!";
        public const string DeActiveUser = "این حساب کاربری غیرفعال می باشد!";
    }
}
