using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IUserManager
    {
        //注册
        Task Register(string email, string password);
        //登录
        bool Login(string email, string password,out Guid userId);
        //修改密码
        Task ChangePassWord(string email, string oldPwd, string newPwd);

        //改个人信息
        Task ChangeInformation(string email, string SiteName, string ImagePath);

        Task <Dto.UserInformationDto >GetUserEmail(string emali);
        Task<int> GetDataCount(Guid userId);
        Task<List<Dto.UserDto>> GetAllUsersByuserId(Guid userId, int pageIndex, int pagesize);
       
    }
}
