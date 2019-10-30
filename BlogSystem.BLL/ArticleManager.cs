using BlogSystem.Dto;
using BlogSystem.IBLL;
using BlogSystem.IdAL;
using BlogSyster.DAL;
using System;
using System.Collections.Generic;
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

        public Task<List<ArticleDto>> GetAllArticlesByuserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogCategoryDto>> GetAllCategories(Guid userId)
        {
            throw new NotImplementedException();
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
