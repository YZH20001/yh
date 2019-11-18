using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.ArticleViewModels
{
    public class CreateArticleViewModel
    {
        [Required]
        [Display(Name ="文章名:")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "文章内容:")]
        public string Content { get; set; }
        [Display(Name ="用户文章分类:")]
        public Guid[] CategoryIds { get; set; }
    }
}