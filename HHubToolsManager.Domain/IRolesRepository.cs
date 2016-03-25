using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Domain
{
    public interface IRolesRepository : IBaseRepository<Roles>
    {
        IEnumerable<Roles> GetPageList();

        long GetPageCount();

        void Delete(string gid);

        IEnumerable<Roles> GetDataList();

        IEnumerable<string> GetModulesByRids(IList<string> roleids);

        void Update(Roles entity);

        IEnumerable<string> GetModulesByRid(string id);
    }
}
