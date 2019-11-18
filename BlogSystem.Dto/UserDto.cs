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
