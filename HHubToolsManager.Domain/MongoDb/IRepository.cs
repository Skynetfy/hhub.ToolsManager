using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HHubToolsManager.Domain.MongoDb
{
    public interface IRepository : IDisposable
    {
        void Insert(string collectionName, BsonDocument item);

        void CheckCollection(string collectionName, long collectionSize, long? collectionMaxItems, bool createIdField);
    }
}
