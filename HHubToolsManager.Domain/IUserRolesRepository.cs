using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Domain
{
    public interface IUserRolesRepository:IBaseRepository<UserRoles>
    {
        IEnumerable<UserRoles> GetPageList();

        long GetPageCount();

        void Delete(string gid);

        UserRoles GetUserRoleByUid(string uid);
    }
}
