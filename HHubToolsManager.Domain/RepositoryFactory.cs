using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain.MongoRepository;

namespace HHubToolsManager.Domain
{
    public class RepositoryFactory
    {
        public static IUserRepository UserRepository
        {
            get { return new UserRepository(); }
        }

        public static IModulesRepository ModulesRepository
        {
            get { return new ModulesRepository(); }
        }

        public static IRolesRepository RolesRepository
        {
            get { return new RolesRepository(); }
        }

        public static IUserRolesRepository UserRolesRepository
        {
            get { return new UserRolesRepository(); }
        }
    }
}
