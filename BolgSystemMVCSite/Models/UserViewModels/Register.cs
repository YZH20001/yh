using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.UserViewModels
{
    public class Register
    {
       
        [Required]
        [EmailAddress]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "您输入的邮箱有误!")]
        [Display(Name = "电子邮箱:")]
        public string Emali { get; set; }
        [Required]
        [Display(Name = "密码:")]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "确认密码:")]
        [DataType(dataType: DataType.Password)]
        [Compare(otherProperty:nameof(Password))]
        public string Confirme { get; set; }
    }
}