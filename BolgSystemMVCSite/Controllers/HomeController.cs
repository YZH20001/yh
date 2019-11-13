using BlogSystem;
using BlogSystem.BLL;
using BolgSystemMVCSite.Fillters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BolgSystemMVCSite.Controllers
{
    public class HomeController : Controller
    {
       
        private BlogContent db = new BlogContent();
        [BlogSystemAuth]
        public ActionResult Index()
        {
            var sidebars = db.sideBars.ToList();
            ViewBag.SideBars = sidebars;
            return View();
        }
        [BlogSystemAuth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [BlogSystemAuth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
       
        public ActionResult Regieter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Regieter(Models.UserViewModels.Register model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IUserManager user = new UserManager();
                await user.Register(model.Emali, model.Password);
                return Content("注册成功!");
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(Models.UserViewModels.LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IUserManager user = new UserManager();
                Guid userId;
               if (  user.Login(model.Email, password: model.LoginPwd,out userId))
                {
                    if (model.Remember)
                    {
                        Response.Cookies.Add(new HttpCookie(name: "loginName")
                        {
                            Value=model.Email,
                            Expires=DateTime.Now.AddDays(7)
                        });
                        Response.Cookies.Add(new HttpCookie(name: "userId")
                        {
                            Value = userId.ToString(),
                            Expires = DateTime.Now.AddDays(7)
                        });
                    }
                    else
                    {
                        Session["loginName"] = model.Email;
                        Session["userId"] = userId;
                    }
                    return RedirectToAction("AritcleList2", "Article");
                }
                else
                {
                    ModelState.AddModelError(key: "", errorMessage: "用户名或密码错误!");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeInformation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeInformation(Models.ChangeInformation model )
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IUserManager user = new UserManager();
                user.ChangeInformation(model.Email,model.SiteName,model.ImagePath);
                return Content("修改成功");
            }
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult SideBar()
        {
            var sidebars = db.sideBars.ToList();
            ViewBag.SideBars = sidebars;
            return PartialView("~/Views/Home/SideBar.cshtml");
        }
    }
}