using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "您输入的邮箱有误!")]
        [Display(Name ="电子邮箱:")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "密码:")]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        [DataType(dataType:DataType.Password)]
        public string LoginPwd { get; set; }
        [Display(Name = "记住")]
        public bool Remember { get; set; }
    }
}