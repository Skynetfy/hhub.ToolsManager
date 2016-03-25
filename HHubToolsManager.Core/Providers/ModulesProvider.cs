using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Core.Providers
{
    public class ModulesProvider
    {
        private static readonly IModulesRepository Repository = RepositoryFactory.ModulesRepository;
        public static IList<Modules> FindAll()
        {
            return Repository.FindAll();
        }
    }
}
