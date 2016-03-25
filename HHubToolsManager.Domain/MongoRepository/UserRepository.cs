using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHubToolsManager.Domain.Entities;
using HHubToolsManager.Domain.MongoDb;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HHubToolsManager.Domain.MongoRepository
{
    public class UserRepository : IUserRepository
    {
        private MongoDatabase db = new MongoDbProvider().GetMongoDatabase();

        public User Add(User entity)
        {
            var collection = db.GetCollection<User>("User");
            var c = collection.Save(entity);

            return entity;
        }

        public bool CheckUser(string name)
        {
            var collection = db.GetCollection<User>("User");
            return collection.Count(Query.EQ("UserName", name)) > 0;

        }

        public User CheckPassword(string name, string pass)
        {
            var collection = db.GetCollection<User>("User");
            var user = collection.FindOne(Query.And(Query.EQ("UserName", name), Query.EQ("Password", pass)));

            return user;
        }

        public User GetUser(string gid)
        {
            var collection = db.GetCollection<User>("User");
            collection.FindOne(Query.EQ("Gid", gid));
            return collection.FindOne();
        }

        public IEnumerable<User> GetAll()
        {
            var collection = db.GetCollection<User>("User");
            return collection.FindAll().ToList();
        }

        public long GetCount()
        {
            var collection = db.GetCollection<User>("User");
            return collection.Count();
        }

        public void Delete(string uid)
        {
            var collection = db.GetCollection<User>("User");
            collection.Remove(Query.EQ("Gid", uid));
        }

        public void UpdatePassword(string uid, string password)
        {
            var collection = db.GetCollection<User>("User");
            collection.Update(Query.EQ("UserName", uid), Update.Set("Password", password));
        }
    }
}
