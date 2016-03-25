using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Core.Entites;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Core.Services
{
    public class UserServices
    {
        private static IUserRepository userRepository = RepositoryFactory.UserRepository;
        private static IRolesRepository rolesRepository = RepositoryFactory.RolesRepository;
        private static IUserRolesRepository userRolesRepository = RepositoryFactory.UserRolesRepository;

        public static void DeleteList(IList<string> list)
        {
            foreach (var user in list)
            {
                userRepository.Delete(user);
            }
        }

        public static void AddUser(User entity)
        {
            userRepository.Add(entity);
        }

        public static void AddRole(Roles entity)
        {
            rolesRepository.Add(entity);
        }

        public static void AddUserRoles(UserRoles entity)
        {
            userRolesRepository.Add(entity);
        }

        public static IList<Roles> GetRolePageList()
        {
            return rolesRepository.GetPageList().ToList();
        }

        public static long GetRolePageCount()
        {
            return rolesRepository.GetPageCount();
        }
        public static IList<UserRoles> GetUserRolePageList()
        {
            return userRolesRepository.GetPageList().ToList();
        }

        public static long GetUserRolePageCount()
        {
            return userRolesRepository.GetPageCount();
        }

        public static IList<Roles> GetRoleDataList()
        {
            return rolesRepository.GetDataList().ToList();
        }

        public static IList<Modules> GetModulesByUid(string uid)
        {
            var roles = userRolesRepository.GetUserRoleByUid(uid);
            if (roles == null)
            {
                roles = new UserRoles();
            }
            var modules = rolesRepository.GetModulesByRids(roles.Roles);
            var modulesRepository = RepositoryFactory.ModulesRepository;
            return modulesRepository.GetUserModulesList(modules).ToList();
        }

        public static List<ZTreeDataNodes> GetModulesByRid(string rid)
        {
            var modulesRepository = RepositoryFactory.ModulesRepository;
            var fullList = modulesRepository.GetPageList().ToList();

            var jsonTreeData = new List<ZTreeDataNodes>();
            for (var i = 0; i < fullList.Count(); i++)
            {
                jsonTreeData.Add(new ZTreeDataNodes()
                {
                    id = i + 1,
                    pId = 0,
                    pidStr = fullList[i].ParentId,
                    name = fullList[i].MenuName,
                    gid = fullList[i].Gid,
                });
            }

            foreach (var item in jsonTreeData)
            {
                item.pId = jsonTreeData.FirstOrDefault(x => x.gid.Equals(item.pidStr)) == null
                    ? 0
                    : jsonTreeData.FirstOrDefault(x => x.gid.Equals(item.pidStr)).id;
                if (item.pId == 0)
                    item.iconSkin = "diy02";
                else
                {
                    item.iconSkin = "diy01";
                }
            }
            if (!string.IsNullOrEmpty(rid))
            {
                var list = rolesRepository.GetModulesByRid(rid).ToList();
                foreach (var item in jsonTreeData)
                {
                    if (list.Contains(item.gid))
                        item.Checked = true;
                }
            }

            return jsonTreeData;
        }

        public static void UpdateRoleModule(Roles entity)
        {
            rolesRepository.Update(entity);
        }

        public static List<ZTreeDataNodes> GetRolesByUid(string uid)
        {
            var fullRoles = rolesRepository.GetDataList().ToList();
            var list = userRolesRepository.GetUserRoleByUid(uid);
            var jsonTreeData = new List<ZTreeDataNodes>();
            for (var i = 0; i < fullRoles.Count(); i++)
            {
                jsonTreeData.Add(new ZTreeDataNodes()
                {
                    id = i + 1,
                    pId = 0,
                    name = fullRoles[i].RoleName,
                    gid = fullRoles[i].Gid,
                    iconSkin = "diy01"
                });
            }
            if (list != null)
                foreach (var item in jsonTreeData)
                {
                    if (list.Roles.Contains(item.gid))
                        item.Checked = true;
                }
            return jsonTreeData;
        }

        public static void UpdatePassWord(string uid, string password)
        {
            userRepository.UpdatePassword(uid, password);
        }

        public static bool CheckUserName(string username)
        {
            return userRepository.CheckUser(username);
        }
    }
}
