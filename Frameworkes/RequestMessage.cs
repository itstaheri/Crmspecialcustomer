using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes
{
    public static class RequestMessage
    {

        #region Success
        public const string CreateSuccess = "عملیات ایجاد با موفقیت انجام شد";
        public const string EditSuccess = "عملیات ویرایش با موفقیت انجام شد";
        public const string DeleteSuccess = "عملیات حذف با موفقیت انجام شد";
        #endregion
        #region Failed
        public const string CreateFailed = "عملیات ایجاد با موفقیت انجام نشد!";
        public const string EditFailed = "عملیات ویرایش با موفقیت انجام نشد!";
        public const string DeleteFailed = "عملیات حذف با موفقیت انجام نشد!";
        #endregion
    }
}
