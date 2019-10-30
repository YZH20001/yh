using BlogSystem.IdAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSyster.DAL
{
   public class ArticleService:BaseService<BlogSystem.Artcile>, IArticleService
    {
        public ArticleService() : base(new BlogSystem.BlogContent())
        {

        }
    }
}
