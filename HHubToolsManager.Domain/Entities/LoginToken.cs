using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHubToolsManager.Domain.Entities
{
    public class LoginToken : BaseEntity
    {
        public string EchoToken { get; set; }

        public string Uid { get; set; }

        public DateTime Expired { get; set; }
    }
}
