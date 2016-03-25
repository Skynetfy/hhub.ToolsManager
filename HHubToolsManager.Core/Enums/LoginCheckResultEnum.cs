using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHubToolsManager.Core.Enums
{
    public enum LoginCheckResultEnum
    {
        //用户名为空
        UserNameIsNull,
        //密码为空
        UserPassIsNull,
        //用户不存在
        UeerIsNull,
        //密码错误
        UserPasswordError,
        //登录成功
        Success
    }
}
