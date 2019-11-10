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
    /// 文章表
    /// </summary>
   public class Artcile:BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }
        /// <summary>
        /// 谁发的
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UseId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int GoodCount { get; set; }
        /// <summary>
        /// 反对数
        /// </summary>
        public int BadCount { get; set; }

    } 
}
 