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
    public class ArticleManager : IArticleManager
    {
        public async Task BadCountAdd(Guid articleId)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                var article = await articleService.GetOneByIdAsync(articleId);
                article.BadCount++;
                await articleService.EditAsync(article);
            }
        }

        public async Task CreateArticle(string title, string content, Guid[] categoryIds, Guid userId)
        {
            using (var articleSvc = new ArticleService())
            {
                var article = new Artcile()
                {
                    Title = title,
                    Content = content,
                    UseId = userId,
                };
                await articleSvc.CreateAsync(article);
                Guid articleId = article.Id;
                using (var articleToCategory = new ArticleToCategory())
                {
                    foreach (var categoryId in categoryIds)
                    {
                        await articleToCategory.CreateAsync(new ArtcleToCategory()
                        {
                            //**********************************************************
                            ArticleId = articleId,
                            BlogCategoryId=categoryId
                        }, saved: false);
                    }
                    await articleToCategory.Save();
                }
            }
        }

        public async Task CreateCategory(string name, Guid userId)
        {
            using (var categorySvc = new BlogCategoryServices())
            {
                await categorySvc.CreateAsync(new BlogCategory()
                {
                    CategoryName = name,
                    UserId = userId,
                });
            }
        }

        public async Task CreateComment(Guid userId, Guid articleId, string content)
        {
            using (BlogSystem.IdAL.ICommentService commentService = new CommentService())
            {
                await commentService.CreateAsync(new Comment()
                {
                    UserId = userId,
                    ArticleId = articleId,
                    Content = content
                });
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="articleId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<List<CommentDto>> GetCommentsByArticleId(Guid articleId)
        {
            using (BlogSystem.IdAL.ICommentService commentService = new CommentService())
            {
                return await commentService.GetAllOrderAsync(false).Where(m => m.ArticleId == articleId)
                     .Include(m => m.User)
                     .Select(m => new Dto.CommentDto()
                     {
                         Id = m.Id,
                         ArticleId = m.ArticleId,
                         UserId = m.UserId,
                         Email = m.User.Email,
                         Content = m.Content,
                         CreateTime = m.CreateTime
                     }).ToListAsync();
            }
        }
        public async Task EditArticle(Guid articleId, string title, string content, Guid[] categoryIds)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                var article = await articleService.GetOneByIdAsync(articleId);
                article.Title = title;
                article.Content = content;
                await articleService.EditAsync(article);

                using (BlogSystem.IdAL.IArticleToCategoryService articleToCategoryService = new ArticleToCategory())
                {
                    //删除原有的类别
                    foreach (var categoryId in articleToCategoryService.GetAllAsync().Where(m => m.ArticleId == articleId))
                    {
                        await articleToCategoryService.RemoveAsync(categoryId, saved: false);
                    }

                    //foreach (var categoryId in categoryIds)
                    //{
                    //    await articleToCategoryService.CreateAsync(new ArtcleToCategory() { ArticleId = articleId, BlogCategoryId = categoryId }, saved: false);
                    //}
                    await articleToCategoryService.Save();
                }
            }
        }

        public Task EditCatrgory(Guid categoryId, string newCategoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsArticle(Guid articleId)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                return await articleService.GetAllAsync().AnyAsync(predicate: m => m.Id == articleId);
            }
        }

        public Task<List<ArticleDto>> GetAllArticleBycategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleDto>> GetAllArticlesByuserEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDto>> GetAllArticlesByuserId(Guid userId, int pageIndex, int pagesize)
        {
            using (var articleSvc = new ArticleService())
            {
                var list = await articleSvc.GetAllByPageOrderAsync(pagesize, pageIndex, false).Include(m =>m.User).Where(m => m.UseId == userId)
                      .Select(m => new Dto.ArticleDto()
                      {
                          Title=m.Title,
                          BadCount = m.BadCount,
                          GoodCount = m.GoodCount,
                          Content = m.Content,
                          Email = m.User.Email,
                          CreateTime = m.CreateTime,
                          Id = m.Id,
                          ImagePath = m.User.ImagePath,
                      }).ToListAsync();
                using (IArticleToCategoryService articleToCategoryService = new ArticleToCategory())
                {
                    foreach (var elem in list)
                    {
                        var cates = await articleToCategoryService.GetAllAsync().Include(m => m.BlogCategory).Where(m => m.ArticleId == elem.Id).ToListAsync();
                        elem.CategoryIds = cates.Select(m => m.BlogCategoryId).ToArray();
                        elem.CategoryNames = cates.Select(m => m.BlogCategory.CategoryName).ToArray();
                    }
                    return list;
                }
            }
        }
        //列表
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
        public async Task<int> GetDataCount(Guid userId)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                return await articleService.GetAllAsync().CountAsync(m => m.UseId == userId);
            }
        }

        public async Task<ArticleDto> GetOneArticleById(Guid articleId)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                var data = await articleService.GetAllAsync()
                    .Include(m => m.User)
                    .Where(m => m.Id == articleId)
                    .Select(m => new Dto.ArticleDto()
                    {
                        Id = m.Id,
                        BadCount = m.BadCount,
                        Title = m.Title,
                        Content = m.Content,
                        CreateTime = m.CreateTime,
                        Email = m.User.Email,
                        GoodCount = m.GoodCount,
                        ImagePath = m.User.ImagePath,
                    }).FirstAsync();
                using (IArticleToCategoryService articleToCategoryService = new ArticleToCategory())
                {
                    var cates = await articleToCategoryService.GetAllAsync().Include(m => m.BlogCategory).Where(m => m.ArticleId == data.Id).ToListAsync();
                    data.CategoryIds = cates.Select(m => m.BlogCategoryId).ToArray();
                    data.CategoryNames = cates.Select(m => m.BlogCategory.CategoryName).ToArray();
                    return data;
                }
            }
        }

        public async Task GoodCountAdd(Guid articleId)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                var article = await articleService.GetOneByIdAsync(articleId);
                article.GoodCount++;
                await articleService.EditAsync(article);
            }
        }

        public async Task RemoveArticle(Guid articleId)
        {
            using (BlogSystem.IdAL.IArticleService articleService = new ArticleService())
            {
                var articles = await articleService.GetOneByIdAsync(articleId);
                await articleService.RemoveAsync(articles);

            }
        }
        public Task RemoveCatrgory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
