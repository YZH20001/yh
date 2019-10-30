using BlogSystem.BLL;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

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
        public async Task< ActionResult> Login(Models.UserViewModels.LoginViewModel model)
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
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(key: "", errorMessage: "用户名或密码错误!");
                }
            }
            return View(model);
        }
    }
}