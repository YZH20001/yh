using BlogSystem.IdAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSyster.DAL
{
   public class ArticleToCategory:BaseService<BlogSystem.ArtcleToCategory>, IArticleToCategoryService
    {
        public ArticleToCategory():base(new BlogSystem.BlogContent())
        {

        }
    }
}
