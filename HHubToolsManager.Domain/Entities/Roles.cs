using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHubToolsManager.Domain.Entities
{
    public class Roles : BaseEntity
    {
        public string RoleName { get; set; }

        public List<string> ModulesId { get; set; }

        public bool IsUse { get; set; }
    }
}
