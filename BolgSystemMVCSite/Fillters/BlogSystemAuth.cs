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

            //base.OnAuthorization(filterContext);
            ///用户存储在cookie中且session数据为空时，把cookie的数据同步到session中
            if (filterContext.HttpContext.Request.Cookies["loginName"] != null &&
                filterContext.HttpContext.Session["loginName"] == null)
            {
                filterContext.HttpContext.Session["loginName"] = filterContext.HttpContext.Request.Cookies["loginName"].Value;
                filterContext.HttpContext.Session["userId"] = filterContext.HttpContext.Request.Cookies["userId"].Value;
            }
            if (!(filterContext.HttpContext.Session["loginName"]!=null||filterContext.HttpContext.Request.Cookies
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