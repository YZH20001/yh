using BlogSystem.Dto;
using BlogSystem.IBLL;
using BlogSystem.IdAL;
using BlogSyster.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.BLL
{
    public  class ArticleManager : IArticleManager
    {
        public async Task CreateArticle(string title, string content, Guid[] categoryIds, Guid userId)
        {
           using (var articleSvc=new ArticleService())
            {
                var article = new Artcile()
                {
                    Title = title,
                    Content = content,
                    UseId = userId,
                };
               await articleSvc.CreateAsync(article);
                Guid articleId = article.Id;
                using(var articleToCategory=new ArticleToCategory())
                {
                    foreach(var elem in categoryIds)
                    {
                        await articleToCategory.CreateAsync(new ArtcleToCategory()
                        {
                            ArticleId=articleId,
                            //BlogCategoryId=categoryId,
                        }, saved: false);
                    }
                    await articleToCategory.Save();
                }
            }
        }

        public async Task CreateCategory(string name, Guid userId)
        {
            using(var categorySvc=new BlogCategoryServices())
            {
               await categorySvc.CreateAsync(new BlogCategory()
                {
                    CategoryName = name,
                    UserId=userId,
                });
            }
        }

        public Task EditArticle(Guid articleId, string title, string content, Guid[] categoryIds)
        {
            throw new NotImplementedException();
        }

        public Task EditCatrgory(Guid categoryId, string newCategoryName)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleDto>> GetAllArticleBycategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleDto>> GetAllArticlesByuserEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDto>> GetAllArticlesByuserId(Guid userId)
        {
            using (var articleSvc = new ArticleService())
            {
              var list= await articleSvc.GetAllAsync().Include(m=>m.User). Where(m => m.UseId == userId).Select(m=>new Dto.ArticleDto()
              {
                  Title=m.Title,
                  BadCount=m.BadCount,
                  GoodCount=m.GoodCount,
                  Content=m.Content,
                  Email=m.User.Email,
                  CreateTime=m.CreateTime,
                  Id=m.Id,
                  ImagePath= m.User.ImagePath,
              }
              ).ToListAsync();
                using(IArticleToCategoryService articleToCategoryService=new ArticleToCategory())
                {
                    foreach (var elem in list)
                    {
                        var cates = await articleToCategoryService.GetAllAsync().Include(m=>m.BlogCategory).Where(m => m.ArticleId == elem.Id).ToListAsync();
                        elem.CategoryIds = cates.Select(m => m.BlogCategoryId).ToArray();
                        elem.CategoryNames = cates.Select(m => m.BlogCategory.CategoryName).ToArray();
                    }
                    return list;
                }
            }
        }
        public async Task<List<BlogCategoryDto>> GetAllCategories(Guid userId)
        {
            using (IdAL.IBlogCategory blogCategory = new BlogCategoryServices())
            {
                return await blogCategory.GetAllAsync().Where(m => m.UserId == userId).Select(m => new BlogCategoryDto()
                {
                    Id = m.Id,
                    CategoryName = m.CategoryName
                }).ToListAsync();
            }
        }

        public Task RemoveArticle(Guid articleId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCatrgory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
