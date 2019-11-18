using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models.UserViewModels
{
    public class ChangePassWordViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="当前密码")]
        [DataType(dataType: DataType.Password)]
        public string OldPwd { get; set; }
        [Required]
        [Display(Name ="新密码")]
        [DataType(dataType: DataType.Password)]
        public string NewPwd { get; set; }
        [Required]
        [Display(Name = "确认新密码")]
        [DataType(dataType:DataType.Password)]
        [Compare(otherProperty:nameof(NewPwd))]
        public string ConfirmePwd { get; set; }
    }
}