using Frameworkes.Auth;
using System.Web;

namespace Crmspecialcustomer.HostFrameworks.Permission
{
    public class PermissionAttr : Attribute
    {
        private readonly string _permission;

        public PermissionAttr(IAuth auth, string permission)
        {
            _permission = permission;
            
        }

      
        
    }
}
