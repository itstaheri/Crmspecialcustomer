using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public static class PermissionTypes
    {
        //Area
        public const string AreaCreate = "Permission.Area.Create";
        public const string AreaEdit = "Permission.Area.Edit";
        public const string AreaView = "Permission.Area.View";
        public const string AreaDelete = "Permission.Area.Delete";
        //Order
        public const string OrderCreate = "Permission.Order.Create";
        public const string OrderEdit = "Permission.Order.Edit";
        public const string OrderView = "Permission.Order.View";
        public const string OrderDelete = "Permission.Order.Delete";
        //Request
        public const string RequestCreate = "Permission.Request.Create";
        public const string RequestEdit = "Permission.Request.Edit";
        public const string RequestView = "Permission.Request.View";
        public const string RequestDelete = "Permission.Request.Delete";
        //User
        public const string UserCreate = "Permission.User.Create";
        public const string UserEdit = "Permission.User.Edit";
        public const string UserView = "Permission.User.View";
        public const string UserDelete = "Permission.User.Delete";
        //Service
        public const string ServiceCreate = "Permission.Service.Create";
        public const string ServiceEdit = "Permission.Service.Edit";
        public const string ServiceView = "Permission.Service.View";
        public const string ServiceDelete = "Permission.Service.Delete";
    }
}
