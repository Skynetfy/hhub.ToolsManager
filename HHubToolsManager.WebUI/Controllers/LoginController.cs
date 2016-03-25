using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HHubToolsManager.Core.Enums;
using HHubToolsManager.Core.Providers;
using HHubToolsManager.WebUI.oginProviders;

namespace HHubToolsManager.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login 
        public async Task<ActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("index", "admin");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string name, string password)
        {

            var megenum = await LoginProvider.UserLogin(name, password);
            var result = UserLoginProvider.GetLoginMessage(megenum);
            //if (megenum == LoginCheckResultEnum.Success)
            //    return Redirect("/Home/index");
            return Content(result);
        }

        public async Task<ActionResult> LoginOut()
        {
            await LoginProvider.LoginOut();
            return Redirect("/Login/index");
        }
    }
}