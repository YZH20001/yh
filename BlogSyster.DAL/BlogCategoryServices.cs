using BlogSystem;
using BlogSystem.IdAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSyster.DAL
{
   public class BlogCategoryServices:BaseService<BlogSystem.BlogCategory>, IBlogCategory
    {
        public BlogCategoryServices() : base(new BlogContent())
        {

        }
    }
}
