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
using Newtonsoft.Json;

namespace HHubToolsManager.WebUI.Controllers
{
    public class ModulesController : Controller
    {
        // GET: Modules
        public ActionResult Index()
        {
            var dataList = ModulesServices.GetPageList().Where(x => x.Level == 1).ToList();
            return View(dataList);
        }

        public JsonResult GetModulesList()
        {
            var dataList = ModulesServices.GetPageList();
            var pagerList = new BtpTableData<Modules>();
            pagerList.total = ModulesServices.GetCount();
            pagerList.rows = dataList;
            return new JsonNetResult()
            {
                Data = pagerList,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        public JsonResult GetTreeJsonDataList(string rid)
        {
            var jsonTreeData = UserServices.GetModulesByRid(rid);
            var json = JsonConvert.SerializeObject(jsonTreeData);
            return new JsonNetResult(jsonTreeData);
        }

        public ActionResult AddModules(string moduleid, string menuname, string url, string parentid, string iconimage, int level = 1, int status = 1)
        {
            if (string.IsNullOrEmpty(menuname))
                return Content("");
            if (string.IsNullOrEmpty(moduleid))
            {
                ModulesServices.AddModules(new Modules()
                {
                    MenuName = menuname.Trim(),
                    MenuUrl = url.Trim(),
                    ParentId = parentid.Trim(),
                    ImgIcon = iconimage.Trim(),
                    Level = level,
                    IsUse = Convert.ToBoolean(status)
                });
            }
            else
            {
                ModulesServices.Update(new Modules()
                {
                    Gid = moduleid.Trim(),
                    MenuName = menuname.Trim(),
                    MenuUrl = url.Trim(),
                    ParentId = parentid.Trim(),
                    ImgIcon = iconimage.Trim(),
                    Level = level,
                    IsUse = Convert.ToBoolean(status)
                });
            }
            return Content("");
        }

        [HttpGet]
        public ActionResult GetModulesById(string id)
        {
            var result = new JsonResponseResult<Modules>();
            var model = ModulesServices.GetModuleById(id);
            if (model != null)
            {
                result.Status = 0;
                result.Message = "Success";
                result.Result = model;
            }
            else
            {
                result.Status = -1;
                result.Message = "数据为空";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpDelete]
        public ActionResult DeleteModules(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                string[] idarray = ids.Split(',');
                ModulesServices.DeleteModules(idarray);
            }
            var result = new JsonResponseResult<Modules>();
            return Json(result);
        }
    }
}