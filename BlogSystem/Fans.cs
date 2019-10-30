using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem
{
    /// <summary>
    /// 粉丝表
    /// </summary>
    public class Fans:BaseEntity
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }
        public User user { get; set; }
       /// <summary>
       /// 关注的用户编号
       /// </summary>
        [ForeignKey(nameof(FocuseUser))]
        public Guid FocuseUserId { get; set; }
        public User FocuseUser { get; set; }
    }
}
