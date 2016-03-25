using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using HHubToolsManager.Core.Providers;
using HHubToolsManager.Core.Services;
using HHubToolsManager.WebUI.oginProviders;

namespace HHubToolsManager.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.EchoToken = Guid.NewGuid().ToString("N");
            return View();
        }

        public ActionResult TopMenu()
        {
            ViewBag.userName = HttpContext.User.Identity.Name;
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var c = identity.FindFirst(ClaimTypes.Email).Value;
            return PartialView();
        }

        public ActionResult LeftMenu()
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            //var uid=
            var modulesList = UserServices.GetModulesByUid(identity.FindFirst(ClaimTypes.Sid).Value);

            return PartialView(modulesList);
        }

        public ActionResult Context()
        {
            return PartialView();
        }

        public async Task<ActionResult> LoginOut()
        {
            await LoginProvider.LoginOut();
            return RedirectToAction("Index");
        }
    }
}