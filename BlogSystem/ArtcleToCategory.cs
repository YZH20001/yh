using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem
{
    /// <summary>
    /// 文章分类表
    /// </summary>
    public  class ArtcleToCategory:BaseEntity
    {
       /// <summary>
       /// 类别编号
       /// </summary>
       /// 
       [ForeignKey(nameof(BlogCategory))]
        public Guid BlogCategoryId { get; set; }
        public BlogCategory BlogCategory{ get; set; }

        [ForeignKey(nameof(Artcile))]
        public Guid ArticleId { get; set; }
        public Artcile Artcile { get; set; }
    }

}
