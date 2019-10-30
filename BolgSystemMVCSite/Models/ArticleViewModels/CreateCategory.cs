using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.ArticleViewModels
{
    public class CreateCategory
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        /// 
        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 2)]
        public string CategoryName { get; set; }
    }
}