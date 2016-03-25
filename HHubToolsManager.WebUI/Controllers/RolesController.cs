using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HHubToolsManager.Core.Entites;
using HHubToolsManager.Core.Providers;
using HHubToolsManager.Core.Services;
using HHubToolsManager.Domain.Entities;
using HHubToolsManager.WebUI.Models;

namespace HHubToolsManager.WebUI.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPageDataList()
        {
            var dataList = UserServices.GetRolePageList();
            var pagerList = new BtpTableData<Roles>();
            pagerList.total = UserServices.GetRolePageCount();
            pagerList.rows = dataList;
            return new JsonNetResult()
            {
                Data = pagerList,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult AddRole(string rolename, string menuid, int status = 0)
        {
            if (string.IsNullOrEmpty(rolename))
                return Content("");
            if (string.IsNullOrEmpty(menuid))
                return Content("");
            var role = new Roles()
            {
                RoleName = rolename.Trim(),
                ModulesId = menuid.Trim().Split(',').ToList(),
                IsUse = Convert.ToBoolean(status)
            };
            UserServices.AddRole(role);
            return Content("");
        }

        public JsonResult GetRolesTreeList(string uid)
        {
            var jsonTreeData = UserServices.GetRolesByUid(uid);

            return new JsonNetResult(jsonTreeData);
        }

        public ActionResult DeleteRole(string gid)
        {
            return Content("");
        }

        public ActionResult AddModulesToRole(string roleid, string modules)
        {
            if (string.IsNullOrEmpty(roleid))
                return Content("");
            if (string.IsNullOrEmpty(modules))
                return Content("");
            UserServices.UpdateRoleModule(new Roles()
            {
                Gid = roleid,
                ModulesId = modules.Trim().Split(',').ToList()
            });
            return Content("OK");
        }
    }
}