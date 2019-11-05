using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IArticleManager
    {
        Task CreateArticle(string title, string content, Guid[] categoryIds, Guid userId);
        Task CreateCategory(string name,Guid userId);

        Task<List<Dto.BlogCategoryDto>> GetAllCategories(Guid userId);

        Task<List<Dto.ArticleDto>> GetAllArticlesByuserId(Guid userId,int pageIndex,int pagesize);

        Task<int> GetDataCount(Guid userId);

        Task<List<Dto.ArticleDto>> GetAllArticlesByuserEmail(string Email);

        Task<List<Dto.ArticleDto>> GetAllArticleBycategoryId(Guid categoryId);

        ///编辑删除
        Task RemoveCatrgory(string name);

        Task EditCatrgory(Guid categoryId, string newCategoryName);

        Task RemoveArticle(Guid articleId);

        Task EditArticle(Guid articleId, string title ,string content,Guid[] categoryIds);

        Task<bool> ExistsArticle(Guid articleId);

        Task<Dto.ArticleDto> GetOneArticleById(Guid articleId);
    }
}
