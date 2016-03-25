using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HHubToolsManager.Domain.Entities
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }

        public string Gid { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime CreateDate { get; set; }

        public BaseEntity()
        {
            Gid = Guid.NewGuid().ToString("N");
            Id = ObjectId.GenerateNewId();
            ModifyDate = DateTime.Now;
            CreateDate = DateTime.Now;
        }
    }
}
