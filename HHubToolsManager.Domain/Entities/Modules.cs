using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHubToolsManager.Domain.Entities
{
    public class Modules : BaseEntity
    {
        public string MenuName { get; set; }

        public string MenuUrl { get; set; }

        public string ParentId { get; set; }

        public string ImgIcon { get; set; }

        public int Level { get; set; }

        public bool IsUse { get; set; }

        public int OrderBy { get; set; }

        public Modules()
        {
            ImgIcon = "";
            OrderBy = 0;
        }
    }
}
