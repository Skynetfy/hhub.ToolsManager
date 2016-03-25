using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Core.Providers
{
    public class UserProvider
    {
        private static IUserRepository userRepository = RepositoryFactory.UserRepository;

        public static IEnumerable<User> GetUserList()
        {
            return userRepository.GetAll();
        }

        public static long GetCount()
        {
            return userRepository.GetCount();
        }
    }
}
