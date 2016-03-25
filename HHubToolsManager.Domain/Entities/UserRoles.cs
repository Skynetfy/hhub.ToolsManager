﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHubToolsManager.Domain.Entities
{
    public class UserRoles : BaseEntity
    {
        public string UserId { get; set; }

        public List<string> Roles { get; set; }
    }
}
