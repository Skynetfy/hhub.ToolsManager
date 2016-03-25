
using System;
using HHubToolsManager.Core.Enums;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Core.Providers
{
    public class UserLoginProvider
    {
        private static IUserRepository repository = RepositoryFactory.UserRepository;

        public static bool CheckUserLogin(User user)
        {
            return true;
        }

        public static bool CheckUser(string name)
        {
            return repository.CheckUser(name);
        }

        public static User CheckPassword(string name, string pass)
        {
            return repository.CheckPassword(name, pass);
        }

        public static string GetLoginMessage(LoginCheckResultEnum result)
        {
            var ret = string.Empty;
            switch (result)
            {
                case LoginCheckResultEnum.UserPasswordError:
                    ret = "密码错误";
                    break;
                case LoginCheckResultEnum.Success:
                    ret = "登录成功";
                    break;
                case LoginCheckResultEnum.UeerIsNull:
                    ret = "用户不存在";
                    break;
                case LoginCheckResultEnum.UserNameIsNull:
                    ret = "用户名为空";
                    break;
                case LoginCheckResultEnum.UserPassIsNull:
                    ret = "密码为空";
                    break;
            }
            return ret;
        }
    }
}
