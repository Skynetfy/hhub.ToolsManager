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
    public class ModulesRepository : IModulesRepository
    {
        private MongoDatabase db = new MongoDbProvider().GetMongoDatabase();

        public Modules Add(Modules entity)
        {
            var collection = db.GetCollection<Modules>("Modules");
            var c = collection.Insert(entity);
            return entity;
        }

        public void AddList(IList<Modules> list)
        {
            var collection = db.GetCollection<Modules>("Modules");
            collection.InsertBatch(list);
        }

        public IList<Modules> FindAll()
        {
            var list = new List<Modules>();
            var collection = db.GetCollection<Modules>("Modules");
            var c = collection.FindAll().Count();
            var reslut = collection.FindAllAs<Modules>();
            //foreach (var item in c)
            //{

            //}
            return collection.FindAll().ToList();
        }

        public long GetPageCount()
        {
            var collection = db.GetCollection<Modules>("Modules");
            return collection.Count();
        }

        public IEnumerable<Modules> GetPageList()
        {
            var collection = db.GetCollection<Modules>("Modules");
            return collection.FindAll().ToList();
        }

        public IEnumerable<Modules> GetUserModulesList(IEnumerable<string> moduleids)
        {
            var collection = db.GetCollection<Modules>("Modules");
            var query = Query.And(Query<Modules>.In(x => x.Gid, moduleids));
            return collection.Find(query).ToList();
        }

        public Modules FindById(string id)
        {
            var collection = db.GetCollection<Modules>("Modules");
            return collection.FindOne(Query.EQ("Gid", id));
        }

        public void Update(Modules entity)
        {
            var collection = db.GetCollection<Modules>("Modules");
            var update =
                MongoDB.Driver.Builders.Update.Combine(MongoDB.Driver.Builders.Update.Set("MenuName", entity.MenuName),
                    MongoDB.Driver.Builders.Update.Set("MenuUrl", entity.MenuUrl),
                    MongoDB.Driver.Builders.Update.Set("ParentId", entity.ParentId),
                    MongoDB.Driver.Builders.Update.Set("Level", entity.Level),
                    MongoDB.Driver.Builders.Update.Set("ImgIcon", entity.ImgIcon),
                    MongoDB.Driver.Builders.Update.Set("IsUse", entity.IsUse));
            collection.Update(Query.EQ("Gid", entity.Gid), update);
        }

        public void Delete(string id)
        {
            var collection = db.GetCollection<Modules>("Modules");
            collection.Remove(Query.EQ("Gid", id));
        }
    }
}
