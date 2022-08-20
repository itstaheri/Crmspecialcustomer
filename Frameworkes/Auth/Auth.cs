using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes.Auth
{
    public class Auth : IAuth
    {
        private readonly IHttpContextAccessor _httpContext;

        public Auth(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public long GetCurrentId()
        {
            return  IsAuthenticated()
               ? long.Parse(_httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId")?.Value)
               : 0;
        }

        public string GetCurrentRole()
        {
            if (IsAuthenticated())
            {
                return _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            }
            else
            {
                return null;
            }

        }

        public async Task<AuthViewModel> GetCurrentUserInfofromClaims()
        {
            var model = new AuthViewModel();
            if(!IsAuthenticated()) return model;

            var claims = _httpContext.HttpContext.User.Claims.ToList();
            model.FullName = claims.FirstOrDefault(x => x.Type == "Fullname")?.Value;
            model.Username = claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            model.ProfilePicture = claims.FirstOrDefault(x => x.Type == "ProfilePicture")?.Value;
            model.Code = claims.FirstOrDefault(x => x.Type == "Code")?.Value;
            model.UserId = long.Parse(claims.FirstOrDefault(x => x.Type == "UserId").Value);
            model.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            var per = JsonConvert.DeserializeObject<string>(claims.FirstOrDefault(x => x.Type == "Permissions").Value).ToList();

            return model;

        }

        public string GetCurrentUsername()
        {
            return _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;
        }

        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task<AuthResultMessage> Login(AuthViewModel model)
        {
            //convert permission list to jsonType for set in claims
            var permissions = JsonConvert.SerializeObject(model.Permissions);
            var claims = new List<Claim>
            {
                new Claim("Fullname",model.FullName),
                new Claim("Username",model.Username),
                new Claim("Phone",model.Phone),
                new Claim("Code",model.Code),
                new Claim("ProfilePicture",model.ProfilePicture),
                new Claim(ClaimTypes.Role,model.RoleId.ToString()),
                new Claim("Permissions",permissions)
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddDays(1),
                AllowRefresh = true,
                
            };
            try
            {
                await _httpContext.HttpContext
               .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
                return new AuthResultMessage("Login Seuccessful.", true);

            }
            catch (Exception ex)
            {

                return new AuthResultMessage(ex.Message,false);
            }
           
          
        }

        public async Task<AuthResultMessage> LogOut()
        {
            try
            {
                await _httpContext.HttpContext.SignOutAsync();
                return new AuthResultMessage("LogOut Seuccessful.",true);
            }
            catch (Exception ex)
            {

                return new AuthResultMessage(ex.Message, false);
            }
        }
    }
}
