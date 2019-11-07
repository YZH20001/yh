using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSyster.DAL
{
    public class CommentService : BaseService<BlogSystem.Comment>,BlogSystem.IdAL.ICommentService
    {
        public CommentService() : base(new BlogSystem.BlogContent())
        {
        }
    }
}
