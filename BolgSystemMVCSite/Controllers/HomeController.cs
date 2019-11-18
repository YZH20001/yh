using BlogSystem;
using BlogSystem.BLL;
using BolgSystemMVCSite.Fillters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace BolgSystemMVCSite.Controllers
{
    public class HomeController : Controller
    {
       
        private BlogContent db = new BlogContent();
        [BlogSystemAuth]
        public ActionResult Index()
        {
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
                return RedirectToAction("Login");
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
        public  ActionResult ChangePassWord()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassWord(Models.UserViewModels.ChangePassWordViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IUserManager userManager = new BlogSystem.BLL.UserManager();
               await userManager.ChangePassWord(model.Email,model.OldPwd, model.NewPwd);
                return Content("修改成功");
            }
            return View(model);
        }
        //[HttpGet]
        //public async Task<ActionResult> ChangeInformation(string email)
        //{
        //    BlogSystem.IBLL.IUserManager userManager = new UserManager();
        //    var data = await userManager.GetUserEmail(email);
        //    return View(new Models.ChangeInformationViewModel()
        //    {
        //       Email=data.Email,
        //       SiteName=data.SiteName,
        //       ImagePath=data.ImagePath,
        //    });
        //}
        [HttpGet]
        public ActionResult ChangeInformation()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ChangeInformation(Models.ChangeInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IUserManager userManager = new UserManager();
              await userManager.ChangeInformation(model.Email,model.SiteName,model.ImagePath);
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