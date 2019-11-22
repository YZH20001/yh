using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required, StringLength(40), Column(TypeName = "varchar")]//必填，长度，类型
        public string Email { get; set; }
        [Display(Name ="头像")]
        public string ImagePath { get; set; }
        /// <summary>
        /// 粉丝数量
        /// </summary>
        [Display(Name = "粉丝数量")]
        public int FansCount { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        [Display(Name = "关注数")]
        public int FocusCount { get; set; }
        /// <summary>
        /// 匿名
        /// </summary>
        [Display(Name = "匿名")]
        public string SiteName { get; set; }
    }
}
