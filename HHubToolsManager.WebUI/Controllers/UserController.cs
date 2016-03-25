using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HHubToolsManager.Core.Entites;
using HHubToolsManager.Core.Providers;
using HHubToolsManager.Core.Services;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;
using HHubToolsManager.WebUI.Models;

namespace HHubToolsManager.WebUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserList()
        {
            var dataList = UserProvider.GetUserList();
            var pagerList = new BtpTableData<User>();
            pagerList.total = UserProvider.GetCount();
            pagerList.rows = dataList;
            return new JsonNetResult()
            {
                Data = pagerList,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpDelete]
        public ActionResult DeleteUser(string uids)
        {
            if (!string.IsNullOrEmpty(uids))
            {
                List<string> list = uids.Split(',').ToList();
                UserServices.DeleteList(list);
            }
            return Content("OK");
        }

        public ActionResult AddUser(string username, string email, string displayname, string passwold)
        {
            var result = new JsonResponseResult<string>();
            result.Status = 0;
            if (string.IsNullOrEmpty(username))
            {
                result.Status = -1;
                result.Message = "用户名不能为空";
                return new JsonNetResult(result);
            }
            if (string.IsNullOrEmpty(email))
            {
                result.Status = -1;
                result.Message = "Email地址不能为空";
                return new JsonNetResult(result);
            }
            if (string.IsNullOrEmpty(displayname))
            {
                result.Status = -1;
                result.Message = "姓名不能为空";
                return new JsonNetResult(result);
            }
            if (string.IsNullOrEmpty(passwold))
            {
                result.Status = -1;
                result.Message = "密码不能为空";
                return new JsonNetResult(result);
            }
            if (UserServices.CheckUserName(username.Trim()))
            {
                result.Status = -1;
                result.Message = "用户名已存在";
                return new JsonNetResult(result);
            }
            var user = new User()
            {
                UserName = username.Trim(),
                Email = email.Trim(),
                DisplayName = displayname.Trim(),
                Password = passwold.Trim()
            };
            if (result.Status == 0)
            {
                UserServices.AddUser(user);
                result.Message = "Success";
            }
            return new JsonNetResult(result);
        }

        public ActionResult AddUserRole(string uid, string roleids)
        {
            if (string.IsNullOrEmpty(uid))
                return Content("Email is not null");
            if (string.IsNullOrEmpty(roleids))
                return Content("displayname is not null");
            UserServices.AddUserRoles(new UserRoles()
            {
                UserId = uid,
                Roles = roleids.Trim().Split(',').ToList()
            });
            return Content("");
        }

        [HttpGet]
        public ActionResult AddUserView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUserView(string email, string displayname, string passwold)
        {
            return View();
        }

        public ActionResult UpdatePassword(string oldpassword, string newpassword, string wnewpassword)
        {
            var result = new JsonResponseResult<string>();
            result.Status = 0;
            if (string.IsNullOrEmpty(oldpassword))
            {
                result.Status = -1;
                result.Message = "旧密码不能为空";
                return new JsonNetResult(result);
            }

            if (string.IsNullOrEmpty(newpassword))
            {
                result.Status = -1;
                result.Message = "新密码不能为空";
                return new JsonNetResult(result);
            }
            if (string.IsNullOrEmpty(wnewpassword))
            {
                result.Status = -1;
                result.Message = "确认密码不能为空";
                return new JsonNetResult(result);
            }
            if (newpassword.Equals(wnewpassword))
            {
                result.Status = -1;
                result.Message = "确认密码不正确";
                return new JsonNetResult(result);
            }
            var uname = HttpContext.User.Identity.Name;
            var user = UserLoginProvider.CheckPassword(uname, oldpassword);
            if (user == null)
            {
                result.Status = -1;
                result.Message = "旧密码不正确";
                return new JsonNetResult(result);
            }
            if (result.Status == 0)
            {
                UserServices.UpdatePassWord(uname, wnewpassword.Trim());
                result.Message = "Success";
            }
            return new JsonNetResult(result);
        }

    }
}