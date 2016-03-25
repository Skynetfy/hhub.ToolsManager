using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHubToolsManager.Core.Entites
{
    public class BtpTableData<T> where T : class
    {
        public long total { get; set; }
        public IEnumerable<T> rows { get; set; }
    }
}
