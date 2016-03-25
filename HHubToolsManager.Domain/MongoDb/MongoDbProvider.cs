using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using NLog.MongoDB;

namespace HHubToolsManager.Domain.MongoDb
{
    public class MongoDbProvider : IDisposable
    {
        public Func<IRepositoryProvider> GetProvider = () => new MongoServerProvider();

        private MongoUrlBuilder _mongoUrlBuilder;

        private MongoServer _server;

        public MongoServer CreateServer()
        {
            var settings = new MongoServerSettings();
            _mongoUrlBuilder = new MongoUrlBuilder()
            {
                DatabaseName = "HHubToolsManagerDb",
                Server = new MongoServerAddress("10.1.249.219", 27017),
            };
            settings = MongoServerSettings.FromUrl(_mongoUrlBuilder.ToMongoUrl());
            _server = new MongoServer(settings);
            _server.Connect();
            return _server;
        }

        public MongoDatabase GetMongoDatabase()
        {
            CreateServer();
            return _server != null ? _server.GetDatabase("HHubToolsManagerDb") : null;
        }

        public void Dispose()
        {
            _server.Disconnect();
            _server = null;
        }
    }
}
