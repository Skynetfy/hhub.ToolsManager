using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain.Entities;
using HHubToolsManager.Domain.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HHubToolsManager.Domain.MongoRepository
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private MongoDatabase db = new MongoDbProvider().GetMongoDatabase();

        public UserRoles Add(UserRoles entity)
        {
            var collection = db.GetCollection<UserRoles>("UserRoles");
            if (collection.Count(Query.EQ("UserId", entity.UserId)) > 0)
            {
                collection.Update(Query.EQ("UserId", entity.UserId), Update.SetWrapped("Roles", entity.Roles), UpdateFlags.Upsert);
            }
            else
            {
                collection.Save(entity);
            }
            return entity;
        }

        public IEnumerable<UserRoles> GetPageList()
        {
            var collection = db.GetCollection<UserRoles>("UserRoles");
            return collection.FindAll().ToList();
        }

        public long GetPageCount()
        {
            var collection = db.GetCollection<UserRoles>("UserRoles");
            return collection.Count();
        }

        public void Delete(string gid)
        {
            var collection = db.GetCollection<UserRoles>("UserRoles");
            collection.Remove(Query.EQ("Gid", gid));
        }

        public UserRoles GetUserRoleByUid(string uid)
        {
            var collection = db.GetCollection<UserRoles>("UserRoles");
            return collection.FindOne(Query.EQ("UserId", uid));
        }
    }
}
