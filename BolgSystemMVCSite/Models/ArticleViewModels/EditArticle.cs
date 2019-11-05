using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.ArticleViewModels
{
    public class EditArticle
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public Guid[] categoryIds { get; set; }
    }
}