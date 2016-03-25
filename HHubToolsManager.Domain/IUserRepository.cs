using System;
using System.Collections.Generic;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Domain
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool CheckUser(string name);

        User CheckPassword(string name, string pass);

        User GetUser(string id);

        IEnumerable<User> GetAll();

        long GetCount();

        void Delete(string uid);

        void UpdatePassword(string uid, string password);
    }
}
