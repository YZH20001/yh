using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IdAL
{
   public interface IUserService:IBaseServices<BlogSystem.User>
    {
       // //注册
       // Task Register(string email, string password);
       // //登录
       //Task< bool> Login(string email, string password);
       // //修改密码
       // Task ChangePassWord(string email, string oldPwd, string newPwd);

       // //改个人信息
       // Task ChangeInformation(string email,string SiteName, string ImagePath);
    }
}
