using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolgSystemMVCSite.Models
{
    public class ChangeInformation
    {
        [Required]
        [EmailAddress]
        [Display(Name ="邮箱")]
        public string Email { get; set; }
        [Display(Name = "匿名")]
        public string SiteName { get; set; }
        [Display(Name = "头像")]
        public string ImagePath { get; set; }
    }
}