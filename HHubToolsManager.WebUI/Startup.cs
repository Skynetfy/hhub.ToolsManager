using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(HHubToolsManager.WebUI.Startup))]

namespace HHubToolsManager.WebUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //CookieDomain = "./",
                LoginPath = new PathString("/Login/index"),
                LogoutPath = new PathString("/Login/LoginOut"),
                CookieSecure = CookieSecureOption.Never,
                ExpireTimeSpan = TimeSpan.FromHours(1)
            });
        }
    }
}
