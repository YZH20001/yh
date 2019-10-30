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
    /// 用户表
    /// </summary>
   public class User:BaseEntity
    {
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Required,StringLength(40),Column(TypeName ="varchar")]//必填，长度，类型
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required, StringLength(30), Column(TypeName = "varchar")]
        public string Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Required, StringLength(300), Column(TypeName = "varchar")]
        public string ImagePath { get; set; }
        /// <summary>
        /// 粉丝数量
        /// </summary>
        public int FansCount { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int FocusCount { get; set; }
        /// <summary>
        /// 匿名
        /// </summary>
        public string SiteName { get; set; }
    }
}
