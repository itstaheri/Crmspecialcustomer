using Frameworkes.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes.Auth  
{
    public interface IAuth
    {
        Task<AuthResultMessage> Login(AuthViewModel model);
        Task<AuthViewModel> GetCurrentUserInfofromClaims();
        long GetCurrentId();
        Task<AuthResultMessage> LogOut();
        string GetCurrentRole();
        string GetCurrentUsername();
        bool IsAuthenticated();
    }
}
