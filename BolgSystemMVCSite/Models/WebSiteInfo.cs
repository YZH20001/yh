using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models
{
    public class ActionLink
    {
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

    }
    public class WebSiteInfo
    {
        public const string SiteName = "";  
        public List<ActionLink>actionLinks { get; set; }

        public WebSiteInfo()
        {
            actionLinks = new List<ActionLink>
            {
                new ActionLink{Name="",Controller="",Action=""}
            };
        }
    }
}