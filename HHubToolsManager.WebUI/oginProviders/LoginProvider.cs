using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using HHubToolsManager.Core.Enums;
using HHubToolsManager.Core.Providers;
using HHubToolsManager.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HHubToolsManager.WebUI.oginProviders
{
    public class LoginProvider
    {
        private static IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public static async Task<LoginCheckResultEnum> UserLogin(string name, string password)
        {
            var result = new LoginCheckResultEnum();
            if (string.IsNullOrEmpty(name))
            {
                result = LoginCheckResultEnum.UserNameIsNull;
                //throw new Exception("用户名参数为空");
                return result;
            }

            if (string.IsNullOrEmpty(password))
            {
                result = LoginCheckResultEnum.UserPassIsNull;
                return result;
                //throw new Exception("密码参数为空");
            }

            if (UserLoginProvider.CheckUser(name))
            {
                var user = UserLoginProvider.CheckPassword(name, password);
                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Sid, user.Gid.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.DisplayName));
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    if (user.DisplayName.Equals("admin"))
                        claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    //var principal = new ClaimsPrincipal(identity);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        RedirectUri = "/Admin/Index",
                        AllowRefresh = true
                    }, identity);
                    result = LoginCheckResultEnum.Success;
                }
                else
                {
                    result = LoginCheckResultEnum.UserPasswordError;
                }
            }
            else
            {
                result = LoginCheckResultEnum.UeerIsNull;
            }
            return result;
        }

        public static async Task LoginOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static User GetLoginUserInfo(ClaimsIdentity user)
        {
            User _user = null;
            if (user.IsAuthenticated)
            {
                IEnumerable<Claim> claims = ClaimsPrincipal.Current.Claims;
                var c = HttpContext.Current.Request.GetOwinContext().Authentication.User.Claims;
                var identitys = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var claimss = identitys.Claims;
                var identity = (ClaimsIdentity)identitys.Identity;
                _user.Email = identity.FindFirst(ClaimTypes.Email).Value;
                _user.Gid = identity.FindFirst(ClaimTypes.Sid).Value;
                _user.DisplayName = identity.FindFirst(ClaimTypes.Name).Value;
            }
            return _user;
        }
    }
}