using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HHubToolsManager.Domain;
using HHubToolsManager.Domain.Entities;
using HHubToolsManager.Domain.MongoDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HHubToolsManager.TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = 15000;
            var x = 21.75;
            var t = 15;
            var n = c/x*t;
        }

        [TestMethod]
        public void InsertMoudles()
        {
            IModulesRepository repository = RepositoryFactory.ModulesRepository;

            //repository.AddList(new List<Modules>()
            //{
            //    new Modules()
            //    {
            //        MenuName = "一级菜单A",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId=string.Empty,
            //        ImgIcon = "fa fa-paint-brush",
            //        Level = 1,
            //        OrderBy=1
            //    },
            //     new Modules()
            //    {
            //        MenuName = "一级菜单B",
            //        MenuUrl="http://www.baidu.com",
            //       ParentId=string.Empty,
            //        ImgIcon = "fa fa-code",
            //        Level = 1,
            //        OrderBy=2
            //    },
            //     new Modules()
            //    {
            //        MenuName = "一级菜单C",
            //        MenuUrl="http://www.baidu.com",
            //         ParentId=string.Empty,
            //        ImgIcon = "fa fa-mobile",
            //        Level = 1,
            //        OrderBy=3
            //    },
            //     new Modules()
            //    {
            //        MenuName = "一级菜单AD",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId=string.Empty,
            //        ImgIcon = "fa fa-globe",
            //        Level = 1,
            //        OrderBy=4
            //    },
            //     new Modules()
            //    {
            //        MenuName = "一级菜单AE",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId=string.Empty,
            //        ImgIcon = "glyphicon glyphicon-cloud",
            //        Level = 1,
            //        OrderBy=5
            //    },
            //});
            //repository.AddList(new List<Modules>()
            //{
            //    new Modules()
            //    {
            //        MenuName = "A-二级菜单A",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="6c06893d2b1b48ff9b722dbb1c880850",
            //        Level = 2,
            //        OrderBy=1
            //    },
            //     new Modules()
            //    {
            //        MenuName = "A-二级菜单B",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="6c06893d2b1b48ff9b722dbb1c880850",
            //        Level = 2,
            //        OrderBy=2
            //    },
            //     new Modules()
            //    {
            //        MenuName = "A-二级菜单C",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="6c06893d2b1b48ff9b722dbb1c880850",
            //        Level = 2,
            //        OrderBy=3
            //    },
            //     new Modules()
            //    {
            //        MenuName = "A-二级菜单D",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="6c06893d2b1b48ff9b722dbb1c880850",
            //        Level = 2,
            //        OrderBy=4
            //    },
            //     new Modules()
            //    {
            //        MenuName = "A-二级菜单E",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="6c06893d2b1b48ff9b722dbb1c880850",
            //        Level = 2,
            //        OrderBy=5
            //    },
            //});

            //repository.AddList(new List<Modules>()
            //{
            //    new Modules()
            //    {
            //        MenuName = "C-二级菜单A",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="bf333736a6184653b21db60c3a014d49",
            //        Level = 2,
            //        OrderBy=1
            //    },
            //     new Modules()
            //    {
            //        MenuName = "C-二级菜单B",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="bf333736a6184653b21db60c3a014d49",
            //        Level = 2,
            //        OrderBy=2
            //    },
            //     new Modules()
            //    {
            //        MenuName = "C-二级菜单C",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="bf333736a6184653b21db60c3a014d49",
            //        Level = 2,
            //        OrderBy=3
            //    },
            //     new Modules()
            //    {
            //        MenuName = "C-二级菜单D",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="bf333736a6184653b21db60c3a014d49",
            //        Level = 2,
            //        OrderBy=4
            //    },
            //     new Modules()
            //    {
            //        MenuName = "C-二级菜单E",
            //        MenuUrl="http://www.baidu.com",
            //        ParentId="bf333736a6184653b21db60c3a014d49",
            //        Level = 2,
            //        OrderBy=5
            //    },
            //});
        }

        [TestMethod]
        public void MonogdbDriverFind()
        {
            // or use a connection string
            var client = new MongoClient("mongodb://10.1.249.219:27017");
            var database = client.GetDatabase("HHubToolsManagerDb");
            var collection = database.GetCollection<BsonDocument>("Modules");
            var names = database.GetCollection<Modules>("Modules");
            MongoDatabase db = new MongoDbProvider().GetMongoDatabase();
            //获取Users集合
            MongoCollection col = db.GetCollection<Modules>("Modules");
            //定义获取“Name”值为“test”的查询条件
            var query = new QueryDocument { { "Name", "test" } };

            //查询全部集合里的数据
            var result1 = col.FindAllAs<Modules>().ToList();
            //查询指定查询条件的第一条数据，查询条件可缺省。
            var result2 = col.FindOneAs<Modules>();
            //查询指定查询条件的全部数据
            var result3 = col.FindAs<Modules>(query);
        }

    }
}
