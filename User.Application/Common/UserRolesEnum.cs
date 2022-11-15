using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public enum UserRolesEnum
    {
        Admin = 3, // ادمین کل
        RequestCreator = 4, // مسئول درخواست
        NetworkManager = 5, // مدیر شبکه مخابرات
        MaterialCreator = 6, // مسئول فهرست بهاء
        OrderExpert = 7, // کارشناس برآورد

    }
}
