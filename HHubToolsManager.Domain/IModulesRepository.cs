using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Domain
{
    public interface IModulesRepository : IBaseRepository<Modules>
    {
        void AddList(IList<Modules> list);

        IList<Modules> FindAll();

        long GetPageCount();

        IEnumerable<Modules> GetPageList();

        IEnumerable<Modules> GetUserModulesList(IEnumerable<string> moduleids);

        Modules FindById(string id);

        void Update(Modules entity);

        void Delete(string id);
    }
}
