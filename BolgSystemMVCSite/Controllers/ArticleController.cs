using BlogSystem.BLL;
using BolgSystemMVCSite.Fillters;
using BolgSystemMVCSite.Models.ArticleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BolgSystemMVCSite.Controllers
{
    [BlogSystemAuth]
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
    
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CreateCategory model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IArticleManager articleManager = new ArticleManager();
                articleManager.CreateCategory(model.CategoryName, Guid.Parse(Session["userId"].ToString()));
                return RedirectToAction("CategoryList");

            }
            ModelState.AddModelError(key: "", errorMessage: "您的信息有误!");
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> CategoryList()
        {
            var userId = Guid.Parse(Session["userId"].ToString());
            return View(await new ArticleManager().GetAllCategories(userId));
        }
        [HttpGet]
       [BlogSystemAuth]
        public async Task< ActionResult> CreateArticle()
        {
            var userId = Guid.Parse(Session["userId"].ToString());
            ViewBag.CategoryIds = await new ArticleManager().GetAllCategories(userId);
            return View();
        }
        [HttpPost]
      
        public async Task<ActionResult> CreateArticle(Models.ArticleViewModels.CreateArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = Guid.Parse(Session["userId"].ToString());
                await new ArticleManager().CreateArticle(model.Title, model.Content, model.CategoryIds, userId);
                return RedirectToAction("AritcleList");
            }
            ModelState.AddModelError(key: "", errorMessage: "添加失败");
            return View(model);
        }
        [HttpGet]
      
        public async Task<ActionResult> AritcleList()
        {
            var userId = Guid.Parse(Session["userId"].ToString());
          var articles=  await new ArticleManager().GetAllArticlesByuserId(userId);
                 return View(articles);
        }
    }
}