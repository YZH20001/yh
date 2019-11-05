using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.ArticleViewModels
{
    public class RemoveArticleViewModels
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public string Email { get; set; }
      
        public int GoodCount { get; set; }
        public int BadCount { get; set; }
    }
}