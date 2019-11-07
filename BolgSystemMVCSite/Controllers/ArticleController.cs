using BlogSystem.BLL;
using BlogSyster.DAL;
using BolgSystemMVCSite.Fillters;
using BolgSystemMVCSite.Models.ArticleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

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
                return RedirectToAction("AritcleList2");
            }
            ModelState.AddModelError(key: "", errorMessage: "添加失败");
            return View(model);
        }
        [HttpGet]
      
        public async Task<ActionResult> AritcleList( int pageIndex = 0,int pagesize = 1)
        {
            //需要给页面前端 总页面数，当前页面，可显示的总页面数
            var articleMgr = new ArticleManager();
            var userId = Guid.Parse(Session["userId"].ToString());
            var articles = await articleMgr.GetAllArticlesByuserId(userId,pageIndex,pagesize);
            var dataCount = await articleMgr.GetDataCount(userId);
            ViewBag.PageCount = dataCount % pagesize == 0 ? dataCount / pagesize : dataCount / pagesize + 1;
            ViewBag.PageIndex = pageIndex;     
            return View(articles);
        }
        [HttpGet]

        public async Task<ActionResult> AritcleList2(int pageIndex = 1, int pageSize = 4)
        {
            //需要给页面前端 总页面数，当前页面，可显示的总页面数
            var articleMgr = new ArticleManager();
            var userId = Guid.Parse(Session["userId"].ToString());
            //当前用户第n页数据
            var articles = await articleMgr.GetAllArticlesByuserId(userId, pageIndex-1, pageSize);
            //获取当前文章总数
            var dataCount = await articleMgr.GetDataCount(userId);
            return View(new PagedList<BlogSystem.Dto.ArticleDto>(articles,pageIndex,pageSize,dataCount));
        }
        public async Task<ActionResult>ArticleDetails(Guid ? id)
        {
            var articleMgr = new ArticleManager();
            if (!(await new ArticleManager().ExistsArticle(id.Value))|| id == null)
                return RedirectToAction(nameof(AritcleList2));
                ViewBag.Comments = await articleMgr.GetCommentsByArticleId(id.Value);
            
            return View( await articleMgr.GetOneArticleById(id.Value));
        }
        [HttpGet]
        public async Task<ActionResult> EditArticle( Guid id)
        {
            BlogSystem.IBLL.IArticleManager articleManager = new ArticleManager();
            var data = await articleManager.GetOneArticleById(id);

            return View( new Models.ArticleViewModels.EditArticle() { 
            Title=data.Title,
            Content=data.Content,
            categoryIds=data.CategoryIds,
            Id=data.Id
            });
        }
        [HttpPost]
        public async Task<ActionResult> EditArticle(Models.ArticleViewModels.EditArticle model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IArticleManager articleManager = new ArticleManager();
                await articleManager.EditArticle(model.Id, model.Title, model.Content, model.categoryIds);
                return RedirectToAction("AritcleList2");
            }
            else
            {
                var userId = Guid.Parse(Session["userId"].ToString());
                ViewBag.CategoryIds = await new ArticleManager().GetAllCategories(userId);
                return View(model);
            }
        }
        [HttpGet]
        public async Task<ActionResult> RemoveArticle(Guid id)
        {
            BlogSystem.IBLL.IArticleManager articleManager = new ArticleManager();
            BlogSystem.IdAL.IArticleService articleService = new ArticleService();
            var data = await articleManager.GetOneArticleById(id);
            return View(new Models.ArticleViewModels.RemoveArticleViewModels()
            {
                Title = data.Title,
                CreateTime = data.CreateTime,
                Email = data.Email,
                GoodCount = data.GoodCount,
                BadCount=data.BadCount,
                Id=data.Id,
            });
        }
        [HttpPost]
        public async Task<ActionResult> RemoveArticle(Models.ArticleViewModels.RemoveArticleViewModels model)
        {
            if (ModelState.IsValid)
            {
                BlogSystem.IBLL.IArticleManager articleManager = new ArticleManager();
                await articleManager.RemoveArticle(model.Id);
                return RedirectToAction("AritcleList2");
            }
            else
            {
                var userId = Guid.Parse(Session["userId"].ToString());
                ViewBag.CategoryIds = await new ArticleManager().GetAllCategories(userId);
                return View(model);
            }
        }
        [HttpPost]
        public async Task<ActionResult> GoodCount(Guid id)
        {
         BlogSystem.IBLL.IArticleManager articlrManager = new ArticleManager();
           await articlrManager.GoodCountAdd(id);
            return Json(data: new { result = "OK" });
        }
        [HttpPost]
        public async Task<ActionResult> BadCount(Guid id)
        {
            BlogSystem.IBLL.IArticleManager articlrManager = new ArticleManager();
            await articlrManager.BadCountAdd(id);
            return Json(data: new { result = "OK" });
        }
        [HttpPost]
        public async Task<ActionResult> AddComment(Models.ArticleViewModels.CreateCommentViewModel model)
        {
            var userid = Guid.Parse(Session["userid"].ToString());
            BlogSystem.IBLL.IArticleManager articleManager = new ArticleManager();
            await articleManager.CreateComment(userid, model.Id, model.Content);
            return Json(new { result = "ok" });
        }
    }
}