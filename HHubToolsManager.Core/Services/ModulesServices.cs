using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Core.Services
{
    public class ModulesServices
    {
        private static IModulesRepository modulesRepository = RepositoryFactory.ModulesRepository;

        public static long GetCount()
        {
            return modulesRepository.GetPageCount();
        }

        public static IEnumerable<Modules> GetPageList()
        {
            return modulesRepository.GetPageList();
        }

        public static void AddModules(Modules entity)
        {
            modulesRepository.Add(entity);
        }

        public static Modules GetModuleById(string id)
        {
            return modulesRepository.FindById(id);
        }

        public static void Update(Modules entity)
        {
            modulesRepository.Update(entity);
        }

        public static void DeleteModules(params string[] ids)
        {
            foreach (var id in ids)
            {
                modulesRepository.Delete(id);
            }
        }
    }
}
