using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HHubToolsManager.Domain.Entities;

namespace HHubToolsManager.Core
{
    public static class HtmlMvcExtensions
    {
        public static MvcHtmlString HtmlLeftMenu(this HtmlHelper html, IList<Modules> modules)
        {
            var query = modules.Where(x => x.Level == 1).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in query)
            {
                sb.AppendLine(@"<li><div class='link'>");
                sb.AppendLine(@"" + item.MenuName + "<i class='" + item.ImgIcon + "'></i><i class='fa fa-chevron-down'></i>");
                sb.AppendLine(@"</div>" + BuildChildrenMenu(item.Gid, modules.Where(x => x.ParentId.Equals(item.Gid)).ToList()) + " </li>");
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        private static string BuildChildrenMenu(string parentid, IList<Modules> modules)
        {
            StringBuilder sb = new StringBuilder();
            if (modules.Count > 0)
            {
                sb.AppendLine(@"<ul class='submenu'>");
                foreach (var item in modules)
                {
                    sb.AppendLine(@"<li><a href='#' data-href='" + item.MenuUrl + "'>" + item.MenuName + "</a></li>");
                }
                sb.AppendLine(@"</ul>");
            }
            return sb.ToString();
        }
    }
}
