using Frameworkes.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Common
{
    public class PermissionAtrribute : Attribute
    {
        private HttpContext httpContext; 
        private IAuth _auth;
        protected IAuth Auth=>httpContext.RequestServices.GetService<IAuth>();
        public string PermissionCode { get; set; }

        public PermissionAtrribute(string permissionCode)
        {
            PermissionCode = permissionCode;
            var permissionsJson = Auth.GetCurrentUserInfofromClaims().Result.Permissions;
            //var permission = JsonConvert.DeserializeObject<List<string>>(permissionsJson);
            //if (!permission.Any(x => x == PermissionCode))
            //{
            //    new RedirectToActionResult("Index", "Forbidden", "");
            //}
        }
      


    }
}
