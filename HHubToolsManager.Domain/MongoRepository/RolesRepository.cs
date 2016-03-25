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
    public class RolesRepository : IRolesRepository
    {
        private MongoDatabase db = new MongoDbProvider().GetMongoDatabase();

        public Roles Add(Roles entity)
        {
            var collection = db.GetCollection<Roles>("Roles");
            var c = collection.Save(entity);
            return entity;
        }

        public IEnumerable<Roles> GetPageList()
        {
            var collection = db.GetCollection<Roles>("Roles");
            return collection.FindAll().ToList();
        }

        public long GetPageCount()
        {
            var collection = db.GetCollection<Roles>("Roles");
            return collection.Count();
        }

        public void Delete(string gid)
        {
            var collection = db.GetCollection<Roles>("Roles");
            collection.Remove(Query.EQ("Gid", gid));
        }

        public IEnumerable<Roles> GetDataList()
        {
            var collection = db.GetCollection<Roles>("Roles");
            return collection.FindAll().ToList();
        }

        public IEnumerable<string> GetModulesByRids(IList<string> roleids)
        {
            var ret = new List<string>();
            var collection = db.GetCollection<Roles>("Roles");
            if (roleids != null)
            {
                var query = Query.And(Query<Roles>.In(x => x.Gid, roleids));
                var roles = collection.Find(query).ToList();
                roles.ForEach(x =>
                {
                    ret.AddRange(x.ModulesId);
                });
            }
            return ret;
        }

        public void Update(Roles entity)
        {
            var collection = db.GetCollection<Roles>("Roles");
            collection.Update(Query.EQ("Gid", entity.Gid),
                MongoDB.Driver.Builders.Update.SetWrapped("ModulesId", entity.ModulesId));
        }

        public IEnumerable<string> GetModulesByRid(string id)
        {
            var collection = db.GetCollection<Roles>("Roles");
            return collection.FindOne(Query.EQ("Gid", id)).ModulesId;
        }
    }
}
