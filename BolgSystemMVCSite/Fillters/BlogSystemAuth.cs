using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolgSystemMVCSite.Fillters
{
    public class BlogSystemAuth:AuthorizeAttribute
    {
        //public bool IsSkip { get; set; } = false;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
          
            base.OnAuthorization(filterContext);
            if(!(filterContext.HttpContext.Session["loginName"]!=null||filterContext.HttpContext.Request.Cookies
                ["loginName"] != null))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary()
                {
                    {"controller","Home" },
                    {"action","Login" }
                });
            }
        }
    }
}