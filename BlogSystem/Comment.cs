using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem
{
    /// <summary>
    /// 评论表
    /// </summary>
   public class Comment:BaseEntity
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { set; get; }
        public User User { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        /// 
        [Required]
        [StringLength(maximumLength:800)]
        public string Content { get; set; }

        [ForeignKey(nameof(Artcile))]
        public Guid ArticleId { get; set; }
        public Artcile Artcile { get; set; }

    }
}
