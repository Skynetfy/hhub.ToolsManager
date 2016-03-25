using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HHubToolsManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }

        public string Md5Password { get; set; }

        public bool IsUse { get; set; }

        public User()
        {
            //Id = ObjectId.GenerateNewId();
            IsUse = true;
        }
    }
}
